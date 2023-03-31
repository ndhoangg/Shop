using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using BAL.Interfaces;
using DTO.Entity;
using DTO.Models;
using DTO.Models.Request.Authentication;
using DTO.Models.Request.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;
        public AccountsController(IAccountService accountService,IEmailService emailService)
        {
            _accountService = accountService;
            _emailService = emailService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpRequest request) {


            var result = await _accountService.SignUpAsync(request);

            if (result.IsSuccess) {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("SignIn")]
        public async Task <IActionResult> SignIn(SignInRequest request) {
            var result = await _accountService.SignInAsync(request);

            if (result.IsSuccess) {
                return Ok(result); 
            }

            return BadRequest(result);
        }

        [HttpPut("EditProfile/{userId}")]
        public async Task<IActionResult> EditProfileAsync(string userId, EditProfileRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.EditProfile(userId, request);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid!");
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var result = await _accountService.DeleteUser(userId);
            if(result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }
        //[HttpGet("Test")]
        //public IActionResult Test()
        //{
        //    var message = new Message(new string[] { "atroboy1103@gmail.com" }, "test", "Do some thibg");

        //    _emailService.SendEmail(message);

        //    return StatusCode(StatusCodes.Status200OK

        //        );

        //    //string url = _emailService.GetConfirmationLink(token, user.Email, "ConfirmEmail");
        //    //var message = new Message(new string[] { user.Email! }, "Confirmation Email Link", url!);
        //    //_emailService.SendEmail(message);

        //    //}
            
        //}

        [HttpGet("ConfirmEmail")]
        public async Task <IActionResult> ConfirmEmail(string token, string email) {
            var result = await _accountService.ConfirmEmail(token,email);

            if (result.IsSuccess) {
                return Ok(result);
            }

            return BadRequest(result);

        }

    }
}
