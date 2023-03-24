using System;
using DTO.Models;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories.Interface
{
	public interface IAccountRepository
	{
		Task<IdentityResult> SignUpAsync(SignUpModel model);
		Task<string> SignInAsync(SignInModel model);
	}
}

