using FluentValidation;

namespace MedokStore.Application.Products.Cammand.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(updateProductCommand => updateProductCommand.ProductId).NotEmpty();
        }
    }
}
