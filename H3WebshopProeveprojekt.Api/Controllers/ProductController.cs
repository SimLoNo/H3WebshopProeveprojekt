using H3WebshopProeveprojekt.Api.Database.Entities;
using H3WebshopProeveprojekt.Api.DTO;
using H3WebshopProeveprojekt.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                List<ProductResponse> productResponse = await _productService.GetAllProducts();
                if (productResponse == null)
                {
                    return Problem("The value was null, this was unexpected.");
                }
                if (productResponse.Count == 0)
                {
                    return NoContent();
                }
                return Ok(productResponse);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            try
            {
                ProductResponse product = await _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);

            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)] //Should be 201Created, need to figure out how to implement that.
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertProduct([FromBody] ProductRequest product)
        {
            try
            {
                ProductResponse productResponse = await _productService.InsertProduct(product);
                if (productResponse == null)
                {
                    return NoContent();
                }
                return Ok(productResponse);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Should be 201Created, need to figure out how to implement that.
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromBody] ProductRequest product)
        {
            try
            {
                ProductResponse productResponse = await _productService.UpdateProduct(productId, product);
                if (productResponse == null)
                {
                    return NoContent();
                }
                return Ok(productResponse);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Should be 201Created, need to figure out how to implement that.
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            try
            {
                ProductResponse productResponse = await _productService.DeleteProduct(productId);
                if (productResponse == null)
                {
                    return NotFound();
                }
                return Ok(productResponse);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
