using System;
namespace DTO.Models.Response
{
	public class AddCartItemResponse
	{
        public string Message { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
    }
}

