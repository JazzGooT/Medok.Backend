using AutoMapper;
using MedokStore.Application.Categories.Command.CreateCategory;
using MedokStore.Application.Categories.Command.DeleteCategory;
using MedokStore.Application.Categories.Command.UpdateCategory;
using MedokStore.Application.Categories.Queries.GetCategoryById;
using MedokStore.Application.Categories.Queries.GetCategoryByLanguage;
using MedokStore.Application.Categories.Queries.GetCategoryByName;
using MedokStore.WebApi.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedokStore.WebApi.Controllers
{
    [Route("/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly IMapper _mapper;
        public CategoryController(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        [Route("Language")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<CategoryListByLanguageVm>> GetByLanguage([FromQuery] string Language)
        {
            var query = new GetCategoryListByLanguageQuery { Language = Language };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        [Route("Id")]
        public async Task<ActionResult<CategoryDetailsByIdVm>> GetById([FromQuery] Guid Id)
        {
            var query = new GetCategoryByIdQuery { CategoryId = Id, };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        [Route("Name")]
        public async Task<ActionResult<CategoryDetailsByNameVm>> GetByName([FromQuery] string Name)
        {
            var query = new GetCategoryByNameQuery { Name = Name, };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateCategoryDto updateCategoryDto)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);
            await Mediator.Send(command);
            return Ok("Update");
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            var command = new DeleteCategoryCommand { CatetoryId = Id };
            await Mediator.Send(command);
            return Ok("Deleted!");
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromQuery] CreateCategoryDto createCategoriesDto)
        {
            var command = _mapper.Map<CreateCategoryCommand>(createCategoriesDto);

            await Mediator.Send(command);
            return Ok("Created!");
        }
    }
}
