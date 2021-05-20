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
    public class SupermarketController : ControllerBase
    {

        private readonly SupermarketHandler handler;

        public SupermarketController(SupermarketHandler supermarketHandler)
        {
            handler = supermarketHandler;
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Supermarket>> GetAll([FromServices] ISupermarketRepository repository)
        {
            return await repository.GetAll();
        }


        [Route("")]
        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody] CreateSupermarketCommand command
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