using MediatR;

namespace MedokStore.Application.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid CatetoryId { get; set; }
    }
}
