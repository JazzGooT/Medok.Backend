using AutoMapper;
using MedokStore.Application.Geleries.Queries.GetGeleryListById;
using MedokStore.Application.Products.Cammand.CreateProduct;
using MedokStore.Application.Products.Cammand.DeleteProduct;
using MedokStore.Application.Products.Cammand.UpdateProduct;
using MedokStore.Application.Products.Queries.GetProductByName;
using MedokStore.Application.Products.Queries.GetProductList;
using MedokStore.Application.Products.Queries.GetProductListById;
using MedokStore.WebApi.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace MedokStore.WebApi.Controllers
{
    [Route("/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        [Route("Id")]
        public async Task<ActionResult<ProductDetailsByIdVm>> GetById([FromQuery] Guid Id)
        {
            var query = new GetProductByIdQuery { ProductId = Id, };
            var vm = await Mediator.Send(query);
            var geleryQuery = new GetGeleryListByIdQuery { ProductId = Id };
            var geleryVm = await Mediator.Send(geleryQuery);
            var result = new GetProductDto
            {
                Product = vm,
                GeleryList = geleryVm

            };
            return Ok(result);
        }
        [HttpGet]
        [Route("Category")]
        public async Task<ActionResult<ProductListVm>> AllProduct([FromQuery] string Name)
        {
            var query = new GetProductListQuery { CategoryName = Name };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        [Route("Details")]
        public async Task<ActionResult<ProductDetailsByNameVm>> GetProduct([FromQuery] string Name)
        {
            var query = new GetProductByNameQuery { Name = Name };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        [Route("Image")]
        public async Task<IActionResult> GetImage([FromQuery] string Name)
        {
            var query = new GetProductByNameQuery { Name = Name };
            var result = await Mediator.Send(query);
            return File(result.Image, "image/png");
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateProductDto updateProductDto)
        {
            var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
            var result = await Mediator.Send(command);
            return Ok("Update!");
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            var query = new DeleteProductCommand { ProductId = Id };
            await Mediator.Send(query);
            return Ok("Deleted!");
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromQuery] CreateProductDto createProductDto)
        {
            var command = _mapper.Map<CreateProductCommand>(createProductDto);
            await Mediator.Send(command);
            return Ok("Created!");
        }
    }
}
