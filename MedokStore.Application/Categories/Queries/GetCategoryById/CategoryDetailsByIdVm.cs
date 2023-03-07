using AutoMapper;
using MedokStore.Application.Common.Mappings;
using MedokStore.Domain.Entity;

namespace MedokStore.Application.Categories.Queries.GetCategoryById
{
    public class CategoryDetailsByIdVm : IMapWith<Category>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDetailsByIdVm>()
                .ForMember(categoriesVm => categoriesVm.Name, opt => opt.MapFrom(categoriesVm => categoriesVm.Name))
                .ForMember(categoriesVm => categoriesVm.Language, opt => opt.MapFrom(categories => categories.Language))
                .ForMember(categoriesVm => categoriesVm.CategoryId, opt => opt.MapFrom(categories => categories.CategoryId));
        }
    }
}
