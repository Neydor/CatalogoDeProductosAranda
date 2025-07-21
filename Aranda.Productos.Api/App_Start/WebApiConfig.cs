using Aranda.Productos.Api.Handler;
using FluentValidation;
using System.ComponentModel;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Unity;
using Aranda.Productos.Api.Filters;

namespace Aranda.Productos.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void RegisterWithContainer(HttpConfiguration config, IUnityContainer container)
        {
            // Register validation filter globally
            config.Filters.Add(new ValidationActionFilter(container));
        }
    }
}
