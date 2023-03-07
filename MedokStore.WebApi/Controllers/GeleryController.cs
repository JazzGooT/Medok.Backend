using AutoMapper;
using MedokStore.Application.Geleries.Command.CreateGelery;
using MedokStore.Application.Geleries.Command.DeleteGelery;
using MedokStore.Application.Geleries.Command.UpdateGelery;
using MedokStore.Application.Geleries.Queries.GetGeleryById;
using MedokStore.Application.Geleries.Queries.GetGeleryListById;
using MedokStore.Application.Geleries.Queries.GetGeleryListByName;
using MedokStore.WebApi.Models.Gelery;
using Microsoft.AspNetCore.Mvc;

namespace MedokStore.WebApi.Controllers
{
    [Route("/[controller]")]
    public class GeleryController : BaseController
    {
        private readonly IMapper _mapper;
        public GeleryController(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        [Route("Id")]
        public async Task<ActionResult<GeleryListByIdVm>> GetById([FromQuery] Guid Id)
        {
            var query = new GetGeleryListByIdQuery { ProductId = Id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        [Route("ImageList")]
        public async Task<ActionResult<GeleryListByNameVm>> GetImageList([FromQuery] string Name)
        {
            var query = new GetGeleryListByNameQuery { ProductName = Name };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        [Route("Image")]
        public async Task<IActionResult> GetImage([FromQuery] Guid Id)
        {
            var query = new GetGeleryByIdQuery { GeleryId = Id };
            var result = await Mediator.Send(query);
            return File(result.Image, "image/png");
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateGeleryDto updateProductDto)
        {
            var command = _mapper.Map<UpdateGeleryCommand>(updateProductDto);
            var result = await Mediator.Send(command);
            return Ok("Update!");
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            var query = new DeleteGeleryCommand { GeleryId = Id };
            await Mediator.Send(query);
            return Ok("Deleted!");
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromQuery] CreateGeleryDto createGeleryDto)
        {
            var command = _mapper.Map<CreateGeleryCommand>(createGeleryDto);
            await Mediator.Send(command);
            return Ok("Created!");
        }
    }
}
