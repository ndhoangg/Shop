using System;
namespace DTO.Models.Respone.Category
{
	public class DeleteCategoryResponse
	{
        public string Message { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
    }
}

