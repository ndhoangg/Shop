using System;
using DTO.Models;
using DTO.Models.Request.Email;
using DTO.Models.Respone.Authentication;
using Microsoft.AspNetCore.Identity;

namespace BAL.Interfaces
{
	public interface IAccountService
	{
        Task<SignUpRespone> SignUpAsync(SignUpModel model);
        Task<string> SignInAsync(SignInModel model);
        Task<ConfirmEmailRespone> ConfirmEmail(string token, string email); 
    }
}

