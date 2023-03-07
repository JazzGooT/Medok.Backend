using FluentValidation;

namespace MedokStore.Application.Geleries.Queries.GetGeleryById
{
    public class GetGeleryByIdQueryValidator : AbstractValidator<GetGeleryByIdQuery>
    {
        public GetGeleryByIdQueryValidator()
        {
            RuleFor(getGeleryByIdQuery => getGeleryByIdQuery.GeleryId).NotEmpty();
        }
    }
}
