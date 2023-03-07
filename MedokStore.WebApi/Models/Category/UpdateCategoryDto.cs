using AutoMapper;
using MedokStore.Application.Categories.Command.UpdateCategory;
using MedokStore.Application.Common.Mappings;

namespace MedokStore.WebApi.Models.Category
{
    public class UpdateCategoryDto : IMapWith<UpdateCategoryCommand>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCategoryDto, UpdateCategoryCommand>()
                .ForMember(categoryDto => categoryDto.CategoryId, opt => opt.MapFrom(category => category.CategoryId))
                .ForMember(categoryDto => categoryDto.Name, opt => opt.MapFrom(category => category.Name))
                .ForMember(categoryDto => categoryDto.Language, opt => opt.MapFrom(category => category.Language));
        }
    }
}
