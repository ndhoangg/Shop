using System;
namespace DTO.Models.Respone.Product
{
    public class GetProductByIdResponse
    {
        public string? Message { get; set; } 
        public ProductDetailResponse? Product { get; set; }
    }

    public class ProductDetailResponse
    {
        public string? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public double Discount { get; set; }
        public string? Brand { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public double Rating { get; set; }
        public IEnumerable<string>? CategoryIds { get; set; }
    }

}

    

