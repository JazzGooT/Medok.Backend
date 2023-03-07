using MediatR;

namespace MedokStore.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDetailsByIdVm>
    {
        public Guid CategoryId { get; set; }
    }
}
