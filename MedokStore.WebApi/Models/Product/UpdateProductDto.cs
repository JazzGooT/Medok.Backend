using AutoMapper;
using MedokStore.Application.Common.Mappings;
using MedokStore.Application.Products.Cammand.UpdateProduct;

namespace MedokStore.WebApi.Models.Product
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Compound { get; set; }
        public string Capacity { get; set; }
        public string CompleteSet { get; set; }
        public IFormFile Image { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
                .ForMember(productVm => productVm.ProductId, opt => opt.MapFrom(product => product.ProductId))
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
