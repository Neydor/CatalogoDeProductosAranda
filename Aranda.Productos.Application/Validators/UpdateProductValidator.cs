using Aranda.Productos.Application.DTOs;
using Aranda.Productos.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aranda.Productos.Application.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(p => p.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");

            RuleFor(p => p.CategoriaId)
               .GreaterThan(0).WithMessage("El ID de la categoría debe ser mayor que 0.")
               .MustAsync(async (categoriaId, cancellation) =>
               {
                   var category = await unitOfWork.Categories.GetByIdAsync(categoriaId);
                   return category != null;
               }).WithMessage("La categoría especificada no existe.");
            RuleFor(p => p.Imagen)
                .MaximumLength(4086).WithMessage("La URL de la imagen es demasiado larga.");
        }
    }
}
