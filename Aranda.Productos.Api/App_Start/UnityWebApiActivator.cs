using Aranda.Productos.Api.App_Start;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Aranda.Productos.Api.UnityWebApiActivator), nameof(Aranda.Productos.Api.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Aranda.Productos.Api.UnityWebApiActivator), nameof(Aranda.Productos.Api.UnityWebApiActivator.Shutdown))]

namespace Aranda.Productos.Api
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        private static IUnityContainer container;
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            container = UnityConfig.RegisterComponents();
            var resolver = new UnityHierarchicalDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            
            // Configure WebAPI with the container for validation filters
            WebApiConfig.RegisterWithContainer(GlobalConfiguration.Configuration, container);
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            container.Dispose();
        }
    }
}