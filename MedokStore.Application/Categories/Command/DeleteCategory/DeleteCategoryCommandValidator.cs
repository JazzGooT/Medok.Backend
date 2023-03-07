using FluentValidation;

namespace MedokStore.Application.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(deleteCategoryCommand => deleteCategoryCommand.CatetoryId).NotEmpty();
        }
    }
}
