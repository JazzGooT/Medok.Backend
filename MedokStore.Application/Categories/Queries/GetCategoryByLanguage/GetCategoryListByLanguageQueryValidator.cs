using FluentValidation;

namespace MedokStore.Application.Categories.Queries.GetCategoryByLanguage
{
    public class GetCategoryListByLanguageQueryValidator : AbstractValidator<GetCategoryListByLanguageQuery>
    {
        public GetCategoryListByLanguageQueryValidator()
        {
            RuleFor(getCategoryListByLanguageQuery => getCategoryListByLanguageQuery.Language).NotEmpty().MaximumLength(5);
        }
    }
}
