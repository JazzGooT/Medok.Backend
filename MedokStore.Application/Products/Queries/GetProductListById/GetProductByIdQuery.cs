using MediatR;

namespace MedokStore.Application.Products.Queries.GetProductListById
{
    public class GetProductByIdQuery : IRequest<ProductDetailsByIdVm>
    {
        public Guid ProductId { get; set; }
    }
}
