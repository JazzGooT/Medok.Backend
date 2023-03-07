using MediatR;

namespace MedokStore.Application.Categories.Queries.GetCategoryByName
{
    public class GetCategoryByNameQuery : IRequest<CategoryDetailsByNameVm>
    {
        public string Name { get; set; }
    }
}
