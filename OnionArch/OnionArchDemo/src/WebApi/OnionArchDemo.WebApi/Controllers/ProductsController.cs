using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchDemo.Application.Features.Commands;
using OnionArchDemo.Application.Features.Queries;

namespace OnionArchDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await mediator.Send(new GetAllProductQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var id = await mediator.Send(command);
            return Ok(id);
        }
    }
}
