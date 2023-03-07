using MediatR;

namespace MedokStore.Application.Geleries.Queries.GetGeleryListById
{
    public class GetGeleryListByIdQuery : IRequest<GeleryListByIdVm>
    {
        public Guid ProductId { get; set; }
    }
}
