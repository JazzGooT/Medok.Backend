using MediatR;

namespace MedokStore.Application.Categories.Queries.GetCategoryByLanguage
{
    public class GetCategoryListByLanguageQuery : IRequest<CategoryListByLanguageVm>
    {
        public string Language { get; set; }
    }
}
