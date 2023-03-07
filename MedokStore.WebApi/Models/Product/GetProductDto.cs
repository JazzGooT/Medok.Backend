using MedokStore.Application.Geleries.Queries.GetGeleryListById;
using MedokStore.Application.Products.Queries.GetProductListById;

namespace MedokStore.WebApi.Models.Product
{
    public class GetProductDto
    {
        public ProductDetailsByIdVm Product { get; set; }
        public GeleryListByIdVm GeleryList { get; set; }
    }
}
