using FluentValidation;

namespace MedokStore.Application.Categories.Command.CreateCategory
{
    public class CreateCategorycommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategorycommandValidator()
        {
            RuleFor(createCategoryCommand => createCategoryCommand.Name).NotEmpty().MaximumLength(100);
        }
    }
}
