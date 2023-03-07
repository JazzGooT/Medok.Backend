using FluentValidation;

namespace MedokStore.Application.Geleries.Queries.GetGeleryListByName
{
    public class GetGeleryListByNameQueryValidator : AbstractValidator<GetGeleryListByNameQuery>
    {
        public GetGeleryListByNameQueryValidator()
        {
            RuleFor(getGeleryListByNameQuery => getGeleryListByNameQuery.ProductName).NotEmpty();
        }
    }
}
