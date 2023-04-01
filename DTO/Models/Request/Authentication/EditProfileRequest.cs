using System;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models.Request.Authentication
{
	public class EditProfileRequest
	{
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;
    }
}

