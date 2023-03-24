using System;
using DAL.Repositories.Interface;
using DTO.Entity;
using DTO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;

        public AccountRepository(UserManager<User> userManager,SignInManager<User> signInManager,IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;

        }

        public Task<string> SignInAsync(SignInModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };
            return await userManager.CreateAsync(user, model.Password);
        }
    }
}

