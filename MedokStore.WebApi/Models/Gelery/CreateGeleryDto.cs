using AutoMapper;
using MedokStore.Application.Common.Mappings;
using MedokStore.Application.Geleries.Command.CreateGelery;

namespace MedokStore.WebApi.Models.Gelery
{
    public class CreateGeleryDto : IMapWith<CreateGeleryCommand>
    {
        public Guid ProductId { get; set; }
        public ICollection<IFormFile> Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGeleryDto, CreateGeleryCommand>()
                .ForMember(geleryDto => geleryDto.ProductId, opt => opt.MapFrom(gelery => gelery.ProductId))
                .ForMember(geleryDto => geleryDto.Image, opt => opt.MapFrom(gelery => gelery.Image));
        }
    }
}
