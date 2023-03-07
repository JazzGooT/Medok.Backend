using MediatR;

namespace MedokStore.Application.Geleries.Queries.GetGeleryListByName
{
    public class GetGeleryListByNameQuery : IRequest<GeleryListByNameVm>
    {
        public string ProductName { get; set; }
    }
}
