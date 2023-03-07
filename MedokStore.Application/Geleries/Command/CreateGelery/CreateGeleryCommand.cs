using MediatR;
using Microsoft.AspNetCore.Http;

namespace MedokStore.Application.Geleries.Command.CreateGelery
{
    public class CreateGeleryCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public ICollection<IFormFile> Image { get; set; }
    }
}
