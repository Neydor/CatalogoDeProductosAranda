using Aranda.Productos.Application.Interfaces;
using Aranda.Productos.Application.Services;
using Aranda.Productos.Domain.Interfaces;
using Aranda.Productos.Infrastructure.Persistence;
using Aranda.Productos.Infrastructure.Repositories;
using AutoMapper;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Lifetime;

namespace CatalogoDeProductosAranda.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            // Register DbContext with a HierarchicalLifetimeManager to ensure one context per HTTP request.
            container.RegisterType<ApplicationDbContext>(new HierarchicalLifetimeManager());

            // Register Unit of Work with a HierarchicalLifetimeManager.
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            // Register Application Services
            container.RegisterType<IProductService, ProductService>();

            // Configure and register AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Aranda.Productos.Application.Mappers.MappingProfile>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            container.RegisterInstance(mapper);

            return container;
        }
    }
}