using System;
namespace DTO.Models.Respone.Authentication
{
	public class SignUpResponse
	{
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}

