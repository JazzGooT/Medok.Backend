using FluentValidation;

namespace MedokStore.Application.Geleries.Queries.GetGeleryListById
{
    public class GetGeleryListByIdQueryValidator : AbstractValidator<GetGeleryListByIdQuery>
    {
        public GetGeleryListByIdQueryValidator()
        {
            RuleFor(getGeleryListByIdQuery => getGeleryListByIdQuery.ProductId).NotEmpty();
        }
    }
}
