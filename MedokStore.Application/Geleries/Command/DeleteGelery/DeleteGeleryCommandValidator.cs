using FluentValidation;

namespace MedokStore.Application.Geleries.Command.DeleteGelery
{
    public class DeleteGeleryCommandValidator : AbstractValidator<DeleteGeleryCommand>
    {
        public DeleteGeleryCommandValidator()
        {
            RuleFor(deleteGeleryCommand => deleteGeleryCommand.GeleryId).NotEmpty();
        }
    }
}
