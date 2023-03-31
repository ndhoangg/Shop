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
                    Brand = request.Brand,
                    Stock = request.Stock,
                    Image = request.Image,
                    Rating = request.Rating,
                    Categories = request.CategoryIds!.Select(cid => _unitOfWork.CategoryRepository.GetId(Guid.Parse(cid))).ToList(),
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

        public UpdateProductResponse UpdateProduct(string productId, UpdateProductRequest request)
        {
            if (request == null)
            {
                return new UpdateProductResponse
                {
                    Message = "Update product request is null!",
                    IsSuccess = false
                };
            }

            var product = _unitOfWork.ProductRepository.GetId(Guid.Parse(productId));
            if (product == null)
            {
                return new UpdateProductResponse
                {
                    Message = "Product not found!",
                    IsSuccess = false
                };
            }

            try
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Brand = request.Brand;
                product.Stock = request.Stock;
                product.Image = request.Image;
                product.Rating = request.Rating;
                //product.Categories = request.CategoryIds.Select(cid => _unitOfWork.CategoryRepository.GetId(Guid.Parse(cid)));
                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.SaveChanges();
                return new UpdateProductResponse
                {
                    Message = "Update product successfully!",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new UpdateProductResponse
                {
                    Message = "Can't update product!",
                    IsSuccess = false,
                    Error = ex.Message
                };
            }
        }

        public DeleteProductResponse DeleteProduct(string productId)
        {
            var product = _unitOfWork.ProductRepository.GetId(Guid.Parse(productId));
            if (product == null)
            {
                return new DeleteProductResponse
                {
                    Message = "Product not found!",
                    IsSuccess = false
                };
            }

            try
            {
                _unitOfWork.ProductRepository.Remove(product);
                _unitOfWork.SaveChanges();
                return new DeleteProductResponse
                {
                    Message = "Delete product successfully!",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new DeleteProductResponse
                {
                    Message = "Can't delete product!",
                    IsSuccess = false,
                    Error = ex.Message
                };
            }
        }

        public GetProductByIdResponse GetProductById(string productId)
        {
            var product = _unitOfWork.ProductRepository.GetId(Guid.Parse(productId));
            if (product == null)
            {
                return new GetProductByIdResponse
                {
                    Message = "Product not found!"
                };
            }

            return new GetProductByIdResponse
            {   Message = "Success",
                Product = new ProductDetailResponse
                {
                    ProductId = productId,
                    Name = product.Name,
                    Image = product.Image,
                    Description = product.Description,
                    Price = product.Price,
                    Brand = product.Brand,
                    Stock = product.Stock,
                    Rating = product.Rating,
                    //CategoryIds = _unitOfWork.CategoryRepository.GetListCategoriesByProduct(product).Select(category => category.CategoryId.ToString())
                    CategoryIds = product.Categories != null ? product.Categories.Select(category => category.CategoryId.ToString()) : null

                }
            };
        }



    }
}

