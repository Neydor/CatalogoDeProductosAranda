using CatalogoDeProductosAranda.App_Start;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CatalogoDeProductosAranda.UnityWebApiActivator), nameof(CatalogoDeProductosAranda.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(CatalogoDeProductosAranda.UnityWebApiActivator), nameof(CatalogoDeProductosAranda.UnityWebApiActivator.Shutdown))]

namespace CatalogoDeProductosAranda
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
            // Use UnityHierarchicalDependencyResolver if you want to use
            // a new child container for each IHttpController resolution.
            var resolver = new UnityHierarchicalDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
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