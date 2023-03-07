using AutoMapper;
using MedokStore.Application.Common.Mappings;
using MedokStore.Application.Products.Cammand.CreateProduct;

namespace MedokStore.WebApi.Models.Product
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
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
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>()
                .ForMember(productDto => productDto.CategoryId, opt => opt.MapFrom(product => product.CategoryId))
                .ForMember(productDto => productDto.Name, opt => opt.MapFrom(product => product.Name))
                .ForMember(productDto => productDto.Price, opt => opt.MapFrom(product => product.Price))
                .ForMember(productDto => productDto.Image, opt => opt.MapFrom(product => product.Image))
                .ForMember(productDto => productDto.Description, opt => opt.MapFrom(product => product.Description))
                .ForMember(productDto => productDto.Compound, opt => opt.MapFrom(product => product.Compound))
                .ForMember(productDto => productDto.Capacity, opt => opt.MapFrom(product => product.Capacity))
                .ForMember(productDto => productDto.CompleteSet, opt => opt.MapFrom(product => product.CompleteSet))
                .ForMember(productDto => productDto.Gelery, opt => opt.MapFrom(product => product.Gelery));
        }
    }
}
