using System;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models.Request.Authentication
{
	public class SignInRequest
	{
		[Required]
		public string Email { get; set; } = null!;

		[Required]
		public string Password { get; set; } = null!;
	}
}

