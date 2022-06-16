using CqrsMediatr_ASPNetCore_API.Commands;
using CqrsMediatr_ASPNetCore_API.Models;
using CqrsMediatr_ASPNetCore_API.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatr_ASPNetCore_API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender) => _sender = sender;

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}",Name ="GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            var productToReturn = await _sender.Send(new AddProductCommand(product));

            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody]Product product)
        {
            var productToReturn = await _sender.Send(new UpdateProductCommand(product));
            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpGet]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _sender.Send(new DeleteProductCommand(id));
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
