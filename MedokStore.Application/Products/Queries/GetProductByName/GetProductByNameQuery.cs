using MediatR;

namespace MedokStore.Application.Products.Queries.GetProductByName
{
    public class GetProductByNameQuery : IRequest<ProductDetailsByNameVm>
    {
        public string Name { get; set; }
    }
}
