using FluentValidation;

namespace MedokStore.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryValidator : AbstractValidator<GetProductListQuery>
    {
        public GetProductListQueryValidator()
        {
            RuleFor(getProductListQuery => getProductListQuery.CategoryName).NotEmpty();
        }
    }
}
