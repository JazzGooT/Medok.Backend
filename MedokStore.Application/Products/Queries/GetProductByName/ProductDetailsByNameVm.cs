using AutoMapper;
using MedokStore.Application.Common.Mappings;
using MedokStore.Domain.Entity;

namespace MedokStore.Application.Products.Queries.GetProductByName
{
    public class ProductDetailsByNameVm : IMapWith<Product>
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
            profile.CreateMap<Product, ProductDetailsByNameVm>()
                .ForMember(productVm => productVm.Name, opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.Price, opt => opt.MapFrom(product => product.Price))
                .ForMember(productVm => productVm.Image, opt => opt.MapFrom(product => product.Image))
                .ForMember(productVm => productVm.Description, opt => opt.MapFrom(product => product.Description))
                .ForMember(productVm => productVm.Compound, opt => opt.MapFrom(product => product.Compound))
                .ForMember(productVm => productVm.Capacity, opt => opt.MapFrom(product => product.Capacity))
                .ForMember(productVm => productVm.CompleteSet, opt => opt.MapFrom(product => product.CompleteSet));
        }
    }
}
