using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Entity
{
	[Table("OrderDetail")]
	public class OrderDetail
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderDetailId { get; set; }

		public double price { get; set; }

		public int Quantity { get; set; }

		public double Total { get; set; }

		public virtual Order? Order { get; set; }

		public virtual Product? Product { get; set; }

	}
}

