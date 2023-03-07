using FluentValidation;

namespace MedokStore.Application.Products.Cammand.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(deleteProductCommand => deleteProductCommand.ProductId).NotEmpty();
        }
    }
}
