using Aranda.Productos.Application.DTOs;
using Aranda.Productos.Domain.Entities;
using AutoMapper;

namespace Aranda.Productos.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo de Entidad a DTO
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Nombre))
                .ForMember(dest => dest.Imagen, opt => opt.MapFrom(src => src.BlobImagen));

            // Mapeo de DTO a Entidad
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.BlobImagen, opt => opt.MapFrom(src => src.Imagen));
            CreateMap<UpdateProductDto, Product>()
                .ForMember(dest => dest.BlobImagen, opt => opt.MapFrom(src => src.Imagen));
        }
    }
} 