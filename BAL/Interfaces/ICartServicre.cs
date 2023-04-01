using System;
using DTO.Models.Request.Cart;
using DTO.Models.Request.Product;
using DTO.Models.Respone.Product;
using DTO.Models.Response;
using DTO.Models.Response.Cart;

namespace BAL.Interfaces
{
    public interface ICartService
	{
        Task<AddCartItemResponse> AddCartItem(string userId, AddCartItemRequest request);
        UpdateCartItemResponse UpdateCartItem(string cartItemId,UpdateCartItemRequest cardItem);
        DeleteCartItemResponse DeleteCartItem(string cardItemId);
        Task<GetCartDetailByUserResponse> GetCartDetailByUser(string userId);
    }
}

