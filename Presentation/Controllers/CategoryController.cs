using Entity.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilter;
using Service.Abstracts;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/[controller]s")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }

        [HttpGet("all/")]
        public async Task<ActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync(false);
            
            return Ok(categories);
        }

        [HttpGet("one/{id:int}/")]
        public async Task<IActionResult> GetOneCategoryById([FromRoute(Name = "id")]int id)
        {
            var category = await _categoryService.GetOneCategoryByIdAsync(id,false);

            return Ok(category);
        }

        [HttpGet("oneDetail/{id:int}/")]
        public async Task<IActionResult> GetOneCategoryByIdWithProduct([FromRoute(Name = "id")]int id)
        {
            var category = await _categoryService.GetOneCategoryByIdWithProductAsync(id,false);

            return Ok(category);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("create/")]
        public async Task<IActionResult> CreateOneCategory([FromBody]CategoryDto categoryDto)
        {
            var category = await _categoryService.CreateOneCategoryAsync(categoryDto);

            return StatusCode(201,category);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("update/")]
        public async Task<IActionResult> UpdateOneCategory([FromBody]CategoryDto categoryDto)
        {
            await _categoryService.UpdateOneCategoryAsync(categoryDto,false);

            return NoContent();
        }

        [HttpDelete("delete/{id:int}")] 
        public async Task<IActionResult> DeleteOneCategory([FromRoute(Name = "id")]int id)
        {
            await _categoryService.DeleteOneCategoryAsync(id,false); 
            
            return NoContent();
        }

    }
}
