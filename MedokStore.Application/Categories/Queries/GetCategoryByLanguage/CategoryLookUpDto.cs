using AutoMapper;
using MedokStore.Application.Common.Mappings;
using MedokStore.Domain.Entity;

namespace MedokStore.Application.Categories.Queries.GetCategoryByLanguage
{
    public class CategoryLookUpDto : IMapWith<Category>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryLookUpDto>()
                .ForMember(categoryDto => categoryDto.CategoryId, opt => opt.MapFrom(category => category.CategoryId))
                .ForMember(categoryDto => categoryDto.Name, opt => opt.MapFrom(category => category.Name))
                .ForMember(categoryDto => categoryDto.Language, opt => opt.MapFrom(category => category.Language));
        }
    }
}
