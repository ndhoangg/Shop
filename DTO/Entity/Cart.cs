using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Entity
{
	[Table("Cart")]
	public class Cart
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

		public int Quantity { get; set; }

		public virtual Product? Product { get; set; }

		public virtual User? User { get; set; }

	}
}

