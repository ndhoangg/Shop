using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Entity
{
	[Table("Category")]
	public class Category
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; }

		[Required]
		[MaxLength(255)]
		public string? Name { get; set; }

		public virtual IEnumerable<Product>? Products { get; set; }

	}
}

