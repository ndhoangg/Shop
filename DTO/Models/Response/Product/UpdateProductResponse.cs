using System;
namespace DTO.Models.Respone.Product
{
	public class UpdateProductResponse
	{
        public string Message { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
    }
}

