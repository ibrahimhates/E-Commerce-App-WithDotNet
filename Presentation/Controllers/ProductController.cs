using Entity.Dtos.ProductDtos;
using Entity.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilter;
using Service.Abstracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/[controller]s")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService=productService;
        }

        [Authorize]
        [HttpGet("all/")]
        public async Task<IActionResult> GetAllProduct([FromQuery] ProductParams productParams)
        {
            var result = await _productService.GetAllProductsAsync(productParams, false);

            Response.Headers.Add("Pagination-Detail",
                JsonSerializer.Serialize(result.metaData));

            return Ok(result.productDtos);
        }

        [Authorize]
        [HttpGet("allByCategory/{id:int}/")]
        public async Task<IActionResult> GetAllProductByCategoryId([FromRoute(Name = "id")] int id, [FromQuery] ProductParams productParams)
        {
            var result = await _productService
                .GetAllProductByCategoryId(productParams, id, false);

            Response.Headers.Add("Pagination-Detail",
                JsonSerializer.Serialize(result.metaData));

            return Ok(result.productDtos);
        }

        [Authorize]
        [HttpGet("one/{id:int}")]
        public async Task<IActionResult> GetOneProduct([FromRoute(Name = "id")] int id)
        {
            var product = await _productService.GetOneProductByIdAsync(id, false);

            return Ok(product);
        }

        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("create/")]
        public async Task<IActionResult> CreateOneProduct([FromBody] ProductInsertionDto productInsertionDto)
        {
            var product = await _productService.CreateOneProductAsync(productInsertionDto);

            return StatusCode(201, product);
        }

        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("update/")]
        public async Task<IActionResult> UpdateOneProduct(
            [FromBody] ProductUpdateDto productUpdateDto)
        {
            await _productService.UpdateOneProductAsync(productUpdateDto, false);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id:int}/")]
        public async Task<IActionResult> DeleteOneProduct([FromRoute(Name = "id")] int id)
        {
            await _productService.DeleteOneProductAsync(id, false);

            return NoContent();
        }

    }
}
