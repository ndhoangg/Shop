using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Entity
{
	[Table("CartItem")]
	public class CartItem
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartItemId { get; set; }

		public int Quantity { get; set; }

		public Guid ProductId { get; set; }

		public string UserId { get; set; } = null!;

		public virtual Product Product { get; set; } = null!;

		public virtual User User { get; set; } = null!;

	}
}

