using FluentValidation;

namespace MedokStore.Application.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(updateCategoryCommand => updateCategoryCommand.CategoryId).NotEmpty();
            RuleFor(updateCategoryCommand => updateCategoryCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(updateCategoryCommand => updateCategoryCommand.Language).NotEmpty().MaximumLength(5);
        }
    }
}
