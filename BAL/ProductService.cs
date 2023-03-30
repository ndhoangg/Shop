using System;
using BAL.Interfaces;
using DAL.Interface;
using DTO.Entity;
using DTO.Models.Request.Product;
using DTO.Models.Respone.Product;

namespace BAL
{
	public class ProductService : IProductService
	{
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateProductResponse CreateProduct(CreateProductRequest request)
        {
            if (request == null)
            {
                return new CreateProductResponse
                {
                    Message = "Create product request is null!",
                    IsSuccess = false
                };
            }

            try
            {
                var product = new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Discount = request.Discount,
                    Brand = request.Brand,
                    StockQuantity = request.StockQuantity,
                    Image = request.Image,
                    Rating = request.Rating,
                    Categories = request.CategoryIds.Select(cid => _unitOfWork.CategoryRepository.GetId(Guid.Parse(cid))).ToList(),
                };
                _unitOfWork.ProductRepository.AddAsync(product);
                _unitOfWork.SaveChanges();
                return new CreateProductResponse
                {
                    Message = "Create product successfully!",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new CreateProductResponse
                {
                    Message = "Can't create product!",
                    IsSuccess = false,
                    Error = ex.Message
                };
            }

        }

    }
}

