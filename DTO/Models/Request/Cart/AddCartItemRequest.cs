using System;
namespace DTO.Models.Request.Cart
{
	public class AddCartItemRequest
	{
        public string ProductId { get; set; } = null!;
        public int Quantity { get; set; }
    }
}

