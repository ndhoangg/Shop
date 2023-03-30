using System;
namespace DTO.Models.Request.Product
{
	public class CreateProductRequest
	{
        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public string? Brand { get; set; }

        public int Stock { get; set; }

        public string? Image { get; set; }

        public double Rating { get; set; }

        public IEnumerable<string>? CategoryIds { get; set; }
    }
}

