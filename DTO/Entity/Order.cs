using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Entity
{
	[Table("Order")]
	public class Order
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }

		public DateTime OrderDate { get; set; }

		public string Address { get; set; } = null!;

		public string? Status { get; set; }

        public double TotalMoney { get; set; }

		public string UserId { get; set; } = null!;

		public virtual User User { get; set; } = null!;

		public virtual IEnumerable<OrderDetail>? OrderDetails { get; set; }

		

	}
}

