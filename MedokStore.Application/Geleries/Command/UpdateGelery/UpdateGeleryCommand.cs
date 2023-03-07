using MediatR;
using Microsoft.AspNetCore.Http;

namespace MedokStore.Application.Geleries.Command.UpdateGelery
{
    public class UpdateGeleryCommand : IRequest
    {
        public Guid GeleryId { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
