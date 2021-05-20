using Microsoft.AspNetCore.Mvc;
using SupermarketPrices.Api.Infrastructure.Queries;
using SupermarketPrices.Domain.Commands;
using SupermarketPrices.Domain.Handlers;
using System.Threading.Tasks;

namespace SupermarketPrices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupermarketProductController : ControllerBase
    {
        private readonly SupermarketProductHandler handler;
        private readonly ISupermarketProductQuery supermarketProductQuery;

        public SupermarketProductController(SupermarketProductHandler supermarketHandler, ISupermarketProductQuery query)
        {
            handler = supermarketHandler;
            supermarketProductQuery = query;
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody] RegistrySupermarketProductCommand command
        )
        {
            var result = await handler.Handle(command);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [Route("{supermarketId:int}/{productId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetSupermarketWithProduct(int supermarketId, int productId)
        {
            return Ok(await supermarketProductQuery.GetProductWIthPrice(supermarketId, productId));
        }

        [Route("{supermarketId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetSupermarketWithProducts(int supermarketId)
        {
            return Ok(await supermarketProductQuery.GetProductWIthPrice(supermarketId));
        }


        [Route("")]
        [HttpPut]
        public async Task<ActionResult> Update(
         [FromBody] UpdateProductPriceCommand command
     )
        {
            var result = await handler.Handle(command);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
