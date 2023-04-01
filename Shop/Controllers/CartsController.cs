using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL;
using BAL.Interfaces;
using DTO.Models.Request.Cart;
using DTO.Models.Request.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {

        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCartItem(string userId,AddCartItemRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _cartService.AddCartItem(userId,request);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            return BadRequest("Some properties are not valid!");
        }

        [HttpPut("Update/{itemId}")]
        public IActionResult UpdateCartItem(string itemId, [FromBody] UpdateCartItemRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = _cartService.UpdateCartItem(itemId, request);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            return BadRequest("Some properties are not valid!");
        }

        [HttpDelete("Delete/{itemId}")]
        public IActionResult DeleteCartItem(string itemId)
        {
            var response = _cartService.DeleteCartItem(itemId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetByUser/{userId}")]
        public async Task<IActionResult> GetCartItemByUser(string userId)
        {
            var response = await _cartService.GetCartDetailByUser(userId);
            return Ok(response);
        }
    }



}

