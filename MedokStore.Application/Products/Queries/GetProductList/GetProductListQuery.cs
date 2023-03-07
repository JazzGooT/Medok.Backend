using MediatR;

namespace MedokStore.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
        public string CategoryName { get; set; }
    }
}
