using FluentValidation;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Unity;

namespace Aranda.Productos.Api.Filters
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        private readonly IUnityContainer _container;

        public ValidationActionFilter(IUnityContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            foreach (var parameter in actionContext.ActionDescriptor.GetParameters())
            {
                var parameterValue = actionContext.ActionArguments[parameter.ParameterName];
                
                if (parameterValue != null)
                {
                    var parameterType = parameterValue.GetType();
                    var validatorType = typeof(IValidator<>).MakeGenericType(parameterType);
                    
                    try
                    {
                        var validator = _container.Resolve(validatorType) as IValidator;
                        
                        if (validator != null)
                        {
                            var validationResult = await validator.ValidateAsync(
                                new ValidationContext<object>(parameterValue), 
                                cancellationToken);
                            
                            if (!validationResult.IsValid)
                            {
                                var errors = validationResult.Errors
                                    .GroupBy(e => e.PropertyName)
                                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

                                actionContext.Response = actionContext.Request.CreateResponse(
                                    HttpStatusCode.BadRequest, 
                                    errors);
                                return;
                            }
                        }
                    }
                    catch (ResolutionFailedException)
                    {
                        // No validator registered for this type, continue
                        continue;
                    }
                }
            }

            await base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
} 