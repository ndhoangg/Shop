using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interfaces;
using DTO.Models.Request.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) {
            _productService = productService;
        }

        [HttpPost("Add")]
        public IActionResult AddProduct([FromBody] CreateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = _productService.CreateProduct(request);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            return BadRequest("Some properties are not valid!");
        }

        [HttpPut("Update/{productId}")]
        public IActionResult UpdateProduct(string productId, [FromBody] UpdateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = _productService.UpdateProduct(productId, request);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            return BadRequest("Some properties are not valid!");
        }

        [HttpDelete("Delete/{productId}")]
        public IActionResult DeleteProduct(string productId)
        {
            var response = _productService.DeleteProduct(productId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("GetProductDetail/{productId}")]
        public IActionResult GetProductDetail(string productId)
        {
            var response = _productService.GetProductById(productId);
            return Ok(response);
        }

      
    }


}

