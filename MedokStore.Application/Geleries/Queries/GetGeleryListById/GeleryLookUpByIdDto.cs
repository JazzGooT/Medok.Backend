using AutoMapper;
using MedokStore.Application.Common.Mappings;
using MedokStore.Domain.Entity;

namespace MedokStore.Application.Geleries.Queries.GetGeleryListById
{
    public class GeleryLookUpByIdDto : IMapWith<Gelery>
    {
        public Guid GeleryId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Gelery, GeleryLookUpByIdDto>()
                .ForMember(geleryDto => geleryDto.Name, opt => opt.MapFrom(gelery => gelery.Name))
                .ForMember(geleryDto => geleryDto.Image, opt => opt.MapFrom(gelery => gelery.Image));
        }
    }
}
