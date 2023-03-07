using AutoMapper;
using MedokStore.Application.Categories.Command.CreateCategory;
using MedokStore.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace MedokStore.WebApi.Models.Category
{
    public class CreateCategoryDto : IMapWith<CreateCategoryCommand>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Language { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryDto, CreateCategoryCommand>()
                .ForMember(categoryDto => categoryDto.Name, opt => opt.MapFrom(category => category.Name))
                .ForMember(categoryDto => categoryDto.Language, opt => opt.MapFrom(category => category.Language));
        }
    }
}
