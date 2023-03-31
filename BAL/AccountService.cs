using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BAL.Interfaces;
using DAL.Interface;

using DTO.Entity;
using DTO.Models;
using DTO.Models.Request.Email;
using DTO.Models.Response.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DTO.Models.Respone.Authentication;
using DTO.Models.Request.Authentication;

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

        public async Task<SignInResponse> SignInAsync(SignInRequest model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {

                return new SignInResponse
                {
                    IsSuccess = false,
                    Message = "Wrong Email or Password"

                };
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
            return new SignInResponse
            {
                IsSuccess = true,
                Message = "SignIn SuccessFully"

            }; ;
        }

        public async Task<SignUpResponse> SignUpAsync(SignUpRequest model)
        {
            var userExist = await userManager.FindByEmailAsync(model.Email);

            if (userExist != null)
            {
                return new SignUpResponse
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
                PhoneNumber = model.PhoneNumber
            };

            if (await roleManager.RoleExistsAsync(model.Role))
            {
                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return new SignUpResponse
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

                return new SignUpResponse
                {
                    Message = $"User created & Email Sent to {user.Email} SuccessFully",
                    IsSuccess = true
                };

            }
            else
            {
                return new SignUpResponse
                {
                    Message = "Failed!",
                    IsSuccess = false
                };

            }
        }

        public async Task<ConfirmEmailRespone> ConfirmEmail(string token, string email)
        {



           // email = userManager.NormalizeEmail(email);

    

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
                else {

                    return new ConfirmEmailRespone
                    {
                        IsSuccess = false,
                        Message = "Failed"
                    };
                }
            }
            return new ConfirmEmailRespone { IsSuccess = false, Message = "This User Doesn't Exist" };
        }

        public async Task<EditProfileResponse> EditProfile(string userId, EditProfileRequest request)
        {
            if (request == null)
            {
                return new EditProfileResponse
                {
                    Message = "Request is null!",
                    IsSuccess = false,
                };
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new EditProfileResponse
                {
                    Message = "User not found!",
                    IsSuccess = false,
                };
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new EditProfileResponse
                {
                    Message = "Update profile successfully!",
                    IsSuccess = true,
                };
            }

            return new EditProfileResponse
            {
                Message = "Can't update profile!",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<DeleteUserResponse> DeleteUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new DeleteUserResponse
                {
                    Message = "User not found!",
                    IsSuccess = false,
                };
            }

            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new DeleteUserResponse
                {
                    Message = "Delete User Successfully!",
                    IsSuccess = true,
                };
            }

            return new DeleteUserResponse
            {
                Message = "Can't delete user!",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };

        }

    }
}


