using AutoMapper;
using MedokStore.Application.Common.Mappings;
using MedokStore.Application.Geleries.Command.UpdateGelery;

namespace MedokStore.WebApi.Models.Gelery
{
    public class UpdateGeleryDto : IMapWith<UpdateGeleryCommand>
    {
        public Guid GeleryId { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGeleryDto, UpdateGeleryCommand>()
                .ForMember(geleryDto => geleryDto.GeleryId, opt => opt.MapFrom(gelery => gelery.GeleryId))
                .ForMember(geleryDto => geleryDto.Name, opt => opt.MapFrom(gelery => gelery.Image))
                .ForMember(geleryDto => geleryDto.Image, opt => opt.MapFrom(gelery => gelery.Image));
        }
    }
}
