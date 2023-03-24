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
        public Guid Id { get; set; }

		public DateTime OrderDate { get; set; }

		public string? Status { get; set; }

        public double TotalMoney { get; set; }

        public virtual User? User { get; set; }

		public virtual ICollection<OrderDetail>? OrderDetails { get; set; }

		

	}
}

