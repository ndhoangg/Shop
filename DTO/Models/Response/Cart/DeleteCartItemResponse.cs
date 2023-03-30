using System;
namespace DTO.Models.Response.Cart
{
	public class DeleteCartItemResponse
	{
        public string Message { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
    }
}

