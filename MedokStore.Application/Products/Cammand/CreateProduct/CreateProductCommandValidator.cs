using FluentValidation;

namespace MedokStore.Application.Products.Cammand.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCommand => createProductCommand.CategoryId).NotEmpty();
            RuleFor(createProductCommand => createProductCommand.Name).NotEmpty();
            RuleFor(createProductCommand => createProductCommand.Price).NotEmpty();
            RuleFor(createProductCommand => createProductCommand.Description).NotEmpty();
            RuleFor(createProductCommand => createProductCommand.Compound).NotEmpty();
            RuleFor(createProductCommand => createProductCommand.Capacity).NotEmpty();
            RuleFor(createProductCommand => createProductCommand.CompleteSet).NotEmpty();
        }
    }
}
