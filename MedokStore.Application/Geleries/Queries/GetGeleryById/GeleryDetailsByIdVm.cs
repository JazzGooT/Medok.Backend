using AutoMapper;
using MedokStore.Application.Common.Mappings;
using MedokStore.Domain.Entity;

namespace MedokStore.Application.Geleries.Queries.GetGeleryById
{
    public class GeleryDetailsByIdVm : IMapWith<Gelery>
    {
        public Guid GeleryId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Gelery, GeleryDetailsByIdVm>()
                .ForMember(geleryVm => geleryVm.Name, opt => opt.MapFrom(gelery => gelery.Name))
                .ForMember(geleryVm => geleryVm.Image, opt => opt.MapFrom(gelery => gelery.Image))
                .ForMember(geleryVm => geleryVm.GeleryId, opt => opt.MapFrom(gelery => gelery.GeleryId));
        }
    }
}
