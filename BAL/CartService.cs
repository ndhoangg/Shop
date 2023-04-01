using System;
using BAL.Interfaces;
using DAL.Interface;
using DTO.Entity;
using DTO.Models.Request.Cart;
using DTO.Models.Request.Product;
using DTO.Models.Respone.Product;
using DTO.Models.Response;
using DTO.Models.Response.Cart;
using Microsoft.AspNetCore.Identity;

namespace BAL
{
	public class CartService : ICartService
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public CartService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<AddCartItemResponse> AddCartItem(string userId, AddCartItemRequest request)
        {
            // var userCart = 

            if (request == null)
            {
                return new AddCartItemResponse
                {
                    Message = "Add to cart request is null!",
                    IsSuccess = false
                };
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new AddCartItemResponse
                {
                    Message = "User not found!",
                    IsSuccess = false
                };
            }

            var product = _unitOfWork.ProductRepository.GetId(Guid.Parse(request.ProductId));
            if (product == null)
            {
                return new AddCartItemResponse
                {
                    Message = "Product not found!",
                    IsSuccess = false
                };
            }

            try
            {
                _unitOfWork.CartItemRepository.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    Quantity = request.Quantity,
                    UserId = user.Id
                });
                _unitOfWork.SaveChanges();
                return new AddCartItemResponse
                {
                    Message = "Add cart item successfully!",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new AddCartItemResponse
                {
                    Message = "Can't add cart item!",
                    IsSuccess = false,
                    Error = ex.Message
                };
            }

        }

        public UpdateCartItemResponse UpdateCartItem(string cartItemId,UpdateCartItemRequest request)
        {

            if (request == null)
            {
                return new UpdateCartItemResponse
                {
                    Message = "Update cart request is null!",
                    IsSuccess = false
                };
            }

            var cartItem = _unitOfWork.CartItemRepository.GetId(Guid.Parse(cartItemId));
            if (cartItem == null)
            {
                return new UpdateCartItemResponse
                {
                    Message = "Cart item not found!",
                    IsSuccess = false
                };
            }

            try
            {
                cartItem.Quantity = request.Quantity;
                _unitOfWork.CartItemRepository.Update(cartItem);
                _unitOfWork.SaveChanges();
                return new UpdateCartItemResponse
                {
                    Message = "Update cart item successfully!",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new UpdateCartItemResponse
                {
                    Message = "Can't update cart item!",
                    IsSuccess = false,
                    Error = ex.Message
                };
            }
        }

        public DeleteCartItemResponse DeleteCartItem(string cartItemId)
        {
            var cartItem = _unitOfWork.CartItemRepository.GetId(Guid.Parse(cartItemId));
            if (cartItem == null)
            {
                return new DeleteCartItemResponse
                {
                    Message = "Cart item not found!",
                    IsSuccess = false
                };
            }

            try
            {
                _unitOfWork.CartItemRepository.Remove(cartItem);
                _unitOfWork.SaveChanges();
                return new DeleteCartItemResponse
                {
                    Message = "Remove cart item successfully!",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new DeleteCartItemResponse
                {
                    Message = "Can't remove cart item!",
                    IsSuccess = false,
                    Error = ex.Message
                };
            }
        }

        public async Task<GetCartDetailByUserResponse> GetCartDetailByUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new GetCartDetailByUserResponse
                {
                    Message = "User not found!",
                    NumberOfItems = 0
                };
            }

            var cartItems = user.CartItems;
           
            if (cartItems == null)
            {
                return new GetCartDetailByUserResponse
                {
                    Message = "No item!",
                    NumberOfItems = 0
                };
            }

            return new GetCartDetailByUserResponse
            {
                Message = "Success",
                NumberOfItems = cartItems.Count(),
                CartItems = cartItems.Select(item => new CartItemByUserResponse
                {
                    CartItemId = item.CartItemId.ToString(),
                    ProductId = item.ProductId.ToString(),
                    ProductName = item.Product.Name,
                    Price = (double)item.Product.Price,
                    Quantity = item.Quantity
                })
            };
        }

    }
}

