using System;
using DTO.Models;
using DTO.Models.Request.Authentication;
using DTO.Models.Request.Email;
using DTO.Models.Respone.Authentication;
using DTO.Models.Response.Authentication;
using Microsoft.AspNetCore.Identity;

namespace BAL.Interfaces
{
	public interface IAccountService
	{
        Task<SignUpResponse> SignUpAsync(SignUpRequest request);
        Task<SignInResponse> SignInAsync(SignInRequest request);
        Task<ConfirmEmailRespone> ConfirmEmail(string token, string email);
        Task<EditProfileResponse> EditProfile(string userId, EditProfileRequest request);
        Task<DeleteUserResponse> DeleteUser(string userId);

    }
}

