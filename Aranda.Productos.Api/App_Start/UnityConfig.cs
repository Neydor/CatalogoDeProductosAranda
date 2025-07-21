using Aranda.Productos.Application.Interfaces;
using Aranda.Productos.Application.Services;
using Aranda.Productos.Domain.Interfaces;
using Aranda.Productos.Infrastructure.Persistence;
using Aranda.Productos.Infrastructure.Repositories;
using AutoMapper;
using System.Reflection;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Lifetime;
using FluentValidation;
using Aranda.Productos.Application.Validators;
using Aranda.Productos.Application.DTOs;

namespace Aranda.Productos.Api.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ApplicationDbContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            container.RegisterType<IProductService, ProductService>();

            container.RegisterType<IValidator<CreateProductDto>, CreateProductValidator>();
            container.RegisterType<IValidator<UpdateProductDto>, UpdateProductValidator>();

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