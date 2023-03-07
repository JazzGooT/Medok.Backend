using FluentValidation;

namespace MedokStore.Application.Geleries.Command.UpdateGelery
{
    public class UpdateGeleryCommandValidator : AbstractValidator<UpdateGeleryCommand>
    {
        public UpdateGeleryCommandValidator()
        {
            RuleFor(updateGeleryCommand => updateGeleryCommand.GeleryId).NotEmpty();
        }
    }
}
