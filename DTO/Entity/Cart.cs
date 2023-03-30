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
        public Guid CardId { get; set; }

		public int Quantity { get; set; }

        public virtual IEnumerable<Product>? Products { get; set; }

		public virtual User? User { get; set; }

	}
}

