using FluentValidation;

namespace MedokStore.Application.Categories.Queries.GetCategoryByName
{
    public class GetCategoryByNameQueryValidator : AbstractValidator<GetCategoryByNameQuery>
    {
        public GetCategoryByNameQueryValidator()
        {
            RuleFor(getCategoryByNameQuery => getCategoryByNameQuery.Name).NotEmpty().MaximumLength(100);
        }
    }
}
