using MediatR;

namespace MedokStore.Application.Geleries.Command.DeleteGelery
{
    public class DeleteGeleryCommand : IRequest
    {
        public Guid GeleryId { get; set; }
    }
}
