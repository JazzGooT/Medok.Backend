using MediatR;

namespace MedokStore.Application.Products.Cammand.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
    }
}
