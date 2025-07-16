using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDDDApp.Application.dto;
using MyDDDApp.Application.Services;

namespace MyDDDApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto dto)
        {
            await productService.AddAsync(dto);
            return Ok();
        }


    }
}
