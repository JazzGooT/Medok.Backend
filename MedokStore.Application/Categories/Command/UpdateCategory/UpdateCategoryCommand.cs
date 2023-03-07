using MediatR;

namespace MedokStore.Application.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
    }
}
