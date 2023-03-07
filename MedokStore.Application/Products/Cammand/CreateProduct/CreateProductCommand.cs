using MediatR;
using Microsoft.AspNetCore.Http;

namespace MedokStore.Application.Products.Cammand.CreateProduct
{
    public class CreateProductCommand : IRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Compound { get; set; }
        public string Capacity { get; set; }
        public string CompleteSet { get; set; }
        public IFormFile Image { get; set; }
        public ICollection<IFormFile> Gelery { get; set; }

    }

}
