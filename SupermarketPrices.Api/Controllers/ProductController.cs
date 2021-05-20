using Microsoft.AspNetCore.Mvc;
using SupermarketPrices.Api.Infrastructure.Queries;
using SupermarketPrices.Domain.Commands;
using SupermarketPrices.Domain.Entities;
using SupermarketPrices.Domain.Handlers;
using SupermarketPrices.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketPrices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductQuery productQuery;
        private readonly ProductHandler handler;

        public ProductController(ProductHandler productHandler, IProductQuery query)
        {
            handler = productHandler;
            productQuery = query;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productQuery.GetAllProductsAsync());
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody] CreateProductCommand command
        )
        {
            var result = await handler.Handle(command);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [Route("delete/{productId:int}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int productId, [FromServices] ProductHandler handler)
        {
            var result = await handler.Handle(new DeleteProductCommand(productId));
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }


        [Route("")]
        [HttpPut]
        public async Task<ActionResult> Update(
           [FromBody] UpdateProductCommand command
       )
        {
            var result = await handler.Handle(command);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }


        [Route("/{productId:int}/prices")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductPrices(int productId)
        {
            return Ok(await productQuery.GetAllProductsPriceAsync(productId));
        }

        [Route("/{productId:int}/prices/{priceFrom:int}/{priceTo:int}")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductPricesBetween(int productId, int priceFrom, int priceTo)
        {
            return Ok(await productQuery.GetAllProductsByPriceAsync(productId, priceFrom, priceTo));
        }

        [Route("/name/{name}")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductByName(string name)
        {
            return Ok(await productQuery.GetProductsByNameAsync(name));
        }
    }
}
