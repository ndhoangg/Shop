using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace DTO.Entity
{
	[Table("User")]
	public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        //public string Address { get; set; } = null!;
        //public string Phone { get; set; } = null!;

        public virtual IEnumerable<CartItem>? CartItems { get; set; } 
        public virtual IEnumerable<Order> Orders { get; set; } = null!;
    }
}

