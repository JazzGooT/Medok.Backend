using FluentValidation;

namespace MedokStore.Application.Geleries.Command.CreateGelery
{
    public class CreateGeleryCommandValidator : AbstractValidator<CreateGeleryCommand>
    {
        public CreateGeleryCommandValidator()
        {
            RuleFor(createGeleryCommand => createGeleryCommand.ProductId).NotEmpty();
            RuleFor(createGeleryCommand => createGeleryCommand.Image).NotEmpty();
        }
    }
}
