using FluentValidation;

namespace MedokStore.Application.Products.Queries.GetProductListById
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(getProductByIdQuery => getProductByIdQuery.ProductId).NotEmpty();
        }
    }
}
