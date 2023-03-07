using FluentValidation;

namespace MedokStore.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidator()
        {
            RuleFor(getCategoryByIdQuery => getCategoryByIdQuery.CategoryId).NotEmpty();
        }
    }
}
