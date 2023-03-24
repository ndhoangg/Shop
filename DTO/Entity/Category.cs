﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Entity
{
	[Table("Category")]
	public class Category
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string? Name { get; set; }

		public virtual ICollection<Product>? Products { get; set; }

	}
}

