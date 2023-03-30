using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BAL.Interfaces;
using DAL.Interface;

using DTO.Entity;
using DTO.Models;
using DTO.Models.Request.Email;
using DTO.Models.Respone.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BAL
{
	public class AccountService : IAccountService
	{
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IEmailService emailService;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration,IEmailService emailService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
            this.emailService = emailService;

        }

        public async Task<string> SignInAsync(SignInModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {

                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };


            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256Signature)

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<SignUpRespone> SignUpAsync(SignUpModel model)
        {
            var userExist = await userManager.FindByEmailAsync(model.Email);

            if (userExist != null)
            {
                return new SignUpRespone
                {
                    Message = "User already exist!",
                    IsSuccess = false
                };
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };

            if (await roleManager.RoleExistsAsync(model.Role))
            {
                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return new SignUpRespone
                    {
                        Message = "User Failed to Create",
                        IsSuccess = false
                    };
                }

                await userManager.AddToRoleAsync(user, model.Role);
                
               
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                string url = $"https://localhost:56323/api/Accounts/ConfirmEmail?token={token}&email={user.Email}";
                var message = new Message(new string[] { user.Email! }, "Confirmation Email Link", url);
                emailService.SendEmail(message);

                return new SignUpRespone
                {
                    Message = $"User created & Email Sent to {user.Email} SuccessFully",
                    IsSuccess = true
                };

            }
            else
            {
                return new SignUpRespone
                {
                    Message = "Failed!",
                    IsSuccess = false
                };

            }
        }

        public async Task<ConfirmEmailRespone> ConfirmEmail(string token, string email)
        {

            email = email.ToUpper();
      
            var user = await userManager.FindByEmailAsync(email);
            
            if(user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return new ConfirmEmailRespone
                    {
                        IsSuccess = true,
                        Message = "Email Verified Successfully!"
                    };

                }
            }
            return new ConfirmEmailRespone { IsSuccess = false, Message = "This User Doesn't Exist" };
        }
    }
}


