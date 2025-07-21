using System.Web.Http;
using WebActivatorEx;
using Aranda.Productos.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Aranda.Productos.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Aranda.Productos.Api");
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
