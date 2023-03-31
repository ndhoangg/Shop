using System;
namespace DTO.Models.Response.Authentication
{
	public class SignInResponse
	{
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}

