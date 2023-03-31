using System;
using DTO.Models.Request.Product;
using DTO.Models.Respone.Product;
namespace BAL.Interfaces
{
    public interface IProductService
	{
        CreateProductResponse CreateProduct(CreateProductRequest request);

        UpdateProductResponse UpdateProduct(string id ,UpdateProductRequest request);

        DeleteProductResponse DeleteProduct(string id);

        GetProductByIdResponse GetProductById(string id);
    }
}

