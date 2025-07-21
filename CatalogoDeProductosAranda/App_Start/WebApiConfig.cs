using CatalogoDeProductosAranda.Handler;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using FluentValidation;

namespace CatalogoDeProductosAranda
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }

    }
}
