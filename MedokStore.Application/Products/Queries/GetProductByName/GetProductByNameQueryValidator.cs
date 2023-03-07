using FluentValidation;

namespace MedokStore.Application.Products.Queries.GetProductByName
{
    public class GetProductByNameQueryValidator : AbstractValidator<GetProductByNameQuery>
    {
        public GetProductByNameQueryValidator()
        {
            RuleFor(getProductByNameQuery => getProductByNameQuery.Name).NotEmpty();
        }
    }
}
