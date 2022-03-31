using H3WebshopProeveprojekt.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using H3WebshopProeveprojekt.Api.DTO;
using Microsoft.AspNetCore.Authorization;

namespace H3WebshopProeveprojekt.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                List<CategoryResponse> categoryResponse = await _categoryService.GetAllCategories();
                if (categoryResponse == null)
                {
                    return Problem("The reply was null, this was unexpected");
                }
                if (categoryResponse.Count == 0)
                {
                    return NoContent();
                }
                return Ok(categoryResponse);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            try
            {
                CategoryResponse categoryResponse = await _categoryService.GetCategoryById(id);
                if (categoryResponse != null)
                {
                   return Ok(categoryResponse);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertNewCategory([FromBody] CategoryRequest category)
        {
            try
            {
                CategoryResponse categoryResponse = await _categoryService.InsertNewCategory(category);
                if (categoryResponse != null)
                {
                    return Ok(categoryResponse);
                }
                return NotFound();

            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryRequest category)
        {
            try
            {
                CategoryResponse categoryResponse = await _categoryService.UpdateCategory(id, category);
                if (categoryResponse != null)
                {
                    return Ok(categoryResponse);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            try
            {
                CategoryResponse categoryResponse = await _categoryService.DeleteCategory(id);
                if (categoryResponse != null)
                {
                    return Ok(categoryResponse);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
