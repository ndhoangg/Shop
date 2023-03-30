using System;
using DTO.Models.Request.Email;
using Microsoft.AspNetCore.Mvc;

namespace BAL.Interfaces
{
	public interface IEmailService
	{
        void SendEmail(Message message);
        string GetConfirmationLink(string token, string email, string path);
    }
}

