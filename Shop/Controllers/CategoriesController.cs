using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interfaces;
using DTO.Models.Request.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Add")]
        public IActionResult AddCategory([FromBody] CreateCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = _categoryService.CreateCategory(request);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            return BadRequest("Some properties are not valid!");
        }

        [HttpPut("Update/{categoryId}")]
        public IActionResult UpdateCategory(string categoryId, [FromBody] UpdateCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = _categoryService.EditCategory(categoryId, request);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            return BadRequest("Some properties are not valid!");
        }

        [HttpDelete("Delete/{categoryId}")]
        public IActionResult DeleteCategory(string categoryId)
        {
            var response = _categoryService.DeleteCategory(categoryId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

       

    }
}
