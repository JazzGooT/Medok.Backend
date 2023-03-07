using MediatR;

namespace MedokStore.Application.Geleries.Queries.GetGeleryById
{
    public class GetGeleryByIdQuery : IRequest<GeleryDetailsByIdVm>
    {
        public Guid GeleryId { get; set; }
    }
}
