

using Microsoft.AspNetCore.Mvc;
using OrderApp.Models.Products;
using OrderApp.Services.Contracts;
using System.Net;

namespace OrderApp.Api.Controllers
{
    [Route($"/{ApiConstants.BaseUri}/{ApiConstants.ProductsUri}")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("", Name = nameof(ProductsController.GetProducts))]
        [ProducesResponseType(typeof(IEnumerable<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetProducts()
        {
            var clients = await _productsService.GetAlls();
            return Ok(clients);
        }

        [HttpGet(ApiConstants.ProductIdParam, Name = nameof(ProductsController.GetProduct))]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProduct([FromRoute] int productId)
        {
            var customer = await _productsService.Get(productId);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPut(ApiConstants.ProductIdParam, Name = nameof(ProductsController.PutProduuct))]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> PutProduuct([FromRoute] int productId, [FromBody] UpdateProductRequest customerRequest)
        {
            await _productsService.Update(productId, customerRequest);
            return Ok();
        }

        [HttpPost("", Name = nameof(ProductsController.PostProduct))]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> PostProduct([FromBody] CreateProductRequest customer)
        {
            var id = await _productsService.Create(customer);
            return this.CreatedAtAction(nameof(ProductsController.GetProduct), new { productId = id }, id);
        }

        [HttpDelete(ApiConstants.ProductIdParam, Name = nameof(ProductsController.DeleteProduct))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteProduct([FromRoute] int productId)
        {
            await _productsService.Delete(productId);

            return NoContent();
        }
    }
}
