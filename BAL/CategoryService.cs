using System;
using BAL.Interfaces;
using DAL.Interface;
using DTO.Entity;
using DTO.Models.Request.Category;
using DTO.Models.Request.Product;
using DTO.Models.Respone.Category;
using DTO.Models.Respone.Product;

namespace BAL
{
	public class CategoryService : ICategoryService
	{
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateCategoryResponse CreateCategory(CreateCategoryRequest request)
        {
            if (request == null)
            {
                return new CreateCategoryResponse
                {
                    Message = "Add category request is null!",
                    IsSuccess = false,
                };
            }

            try
            {
                Category category = new Category
                {
                    Name = request.Name,
                };
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.SaveChanges();
                return new CreateCategoryResponse
                {
                    Message = "Create category successfully!",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new CreateCategoryResponse
                {
                    Message = "Can't create category!",
                    IsSuccess = false,
                    Error = ex.Message
                };
            }
        }

        public DeleteCategoryResponse DeleteCategory(string categoryId)
        {
            var category = _unitOfWork.CategoryRepository.GetId(Guid.Parse(categoryId));
            if (category == null)
            {
                return new DeleteCategoryResponse
                {
                    Message = "Category not found!",
                    IsSuccess = false,
                };
            }

            try
            {
                _unitOfWork.CategoryRepository.Remove(category);
                _unitOfWork.SaveChanges();
                return new DeleteCategoryResponse
                {
                    Message = "Delete category successfully!",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new DeleteCategoryResponse
                {
                    Message = "Can't delete category!",
                    IsSuccess = false,
                    Error = ex.Message
                };
            }
        }

        public EditCategoryResponse EditCategory(string categoryId, UpdateCategoryRequest request)
        {
            if (request == null)
            {
                return new EditCategoryResponse
                {
                    Message = "Update category request is null!",
                    IsSuccess = false
                };
            }

            var category = _unitOfWork.CategoryRepository.GetId(Guid.Parse(categoryId));
            if (category == null)
            {
                return new EditCategoryResponse
                {
                    Message = "Category not found!",
                    IsSuccess = false
                };
            }

            try
            {
                category.Name = request.Name;
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.SaveChanges();
                return new EditCategoryResponse
                {
                    Message = "Update category successfully!",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new EditCategoryResponse
                {
                    Message = "Can't update category!",
                    IsSuccess = false,
                    Error = ex.Message
                };
            }
        }



    }
}

