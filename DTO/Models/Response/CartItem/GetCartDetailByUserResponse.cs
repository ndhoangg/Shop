using System;
namespace DTO.Models.Response
{
	    public class GetCartDetailByUserResponse
	    {
            public string Message { get; set; } = null!;
            public int NumberOfItems { get; set; }
            public bool IsSuccess { get; set; }
            public IEnumerable<CartItemByUserResponse>? CartItems { get; set; }
        }

        public class CartItemByUserResponse
        {

            public string CartItemId { get; set; } = null!;
            public string ProductId { get; set; } = null!;
            public string ProductName { get; set; } = null!;
            public double Price { get; set; }
            public int Quantity { get; set; }

            
        }
}

