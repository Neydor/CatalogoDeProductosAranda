using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace CatalogoDeProductosAranda.Handler
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            if (context.Exception is ValidationException validationException)
            {
                var errors = validationException.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

                var response = context.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                context.Result = new ResponseMessageResult(response);
                return Task.CompletedTask;
            }

            var genericResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Ocurrió un error inesperado. Por favor, contacte al administrador."),
                ReasonPhrase = "Internal Server Error"
            };
            context.Result = new ResponseMessageResult(genericResponse);

            return Task.CompletedTask;
        }
    }
}