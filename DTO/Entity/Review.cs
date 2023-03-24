using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Entity
{
	[Table("Review")]
	public class Review
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string? Content { get; set; }

		public virtual User? User { get; set; }

		public virtual Product? Product { get; set; }

	}
}

