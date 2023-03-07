using AutoMapper;
using MedokStore.Application.Common.Mappings;
using MedokStore.Domain.Entity;

namespace MedokStore.Application.Products.Queries.GetProductList
{
    public class ProductLookUpDto : IMapWith<Product>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Compound { get; set; }
        public string Capacity { get; set; }
        public string CompleteSet { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookUpDto>()
                .ForMember(productDto => productDto.Name, opt => opt.MapFrom(product => product.Name))
                .ForMember(productDto => productDto.Price, opt => opt.MapFrom(product => product.Price))
                .ForMember(productDto => productDto.Image, opt => opt.MapFrom(product => product.Image))
                .ForMember(productDto => productDto.Description, opt => opt.MapFrom(product => product.Description))
                .ForMember(productDto => productDto.Compound, opt => opt.MapFrom(product => product.Compound))
                .ForMember(productDto => productDto.Capacity, opt => opt.MapFrom(product => product.Capacity))
                .ForMember(productDto => productDto.CompleteSet, opt => opt.MapFrom(product => product.CompleteSet));
        }
    }
}
