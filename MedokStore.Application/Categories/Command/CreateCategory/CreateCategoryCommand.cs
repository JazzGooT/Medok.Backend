using MediatR;

namespace MedokStore.Application.Categories.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }
        public string Language { get; set; }
    }
}
