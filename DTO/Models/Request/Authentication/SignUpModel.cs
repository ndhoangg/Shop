using System;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models
{
	public class SignUpModel
	{
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        //[Required]
        //public string Address { get; set; } = null!;

        //[Required]
        //public string Phone { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!;

    }
}

