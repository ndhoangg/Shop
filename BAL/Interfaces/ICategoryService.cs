using System;
using DTO.Models.Request.Category;
using DTO.Models.Request.Product;
using DTO.Models.Respone.Category;
using DTO.Models.Respone.Product;
namespace BAL.Interfaces
{
    public interface ICategoryService
	{
        CreateCategoryResponse CreateCategory(CreateCategoryRequest request);

        EditCategoryResponse EditCategory(string id ,UpdateCategoryRequest request);

        DeleteCategoryResponse DeleteCategory(string id);

    
    }
}

