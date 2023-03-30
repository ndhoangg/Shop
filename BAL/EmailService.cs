using System;
using BAL.Interfaces;
using DTO.Models.Request.Email;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using MimeKit;

namespace BAL
{
    public class EmailService : IEmailService
    {
        
        private readonly EmailConfiguration _emailConfig;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IUrlHelper _urlHelper;
        public EmailService(EmailConfiguration emailConfig, IActionContextAccessor actionContextAccessor, IUrlHelperFactory urlHelperFactory) {
            _emailConfig = emailConfig;
            _actionContextAccessor = actionContextAccessor;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext!);

        }

        

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                client.Send(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

        public string GetConfirmationLink(string token, string email , string path)
        {
            var confirmationLink = _urlHelper.Action(
           nameof(path),
           "Accounts",
           new { token, email },
           _actionContextAccessor.ActionContext!.HttpContext.Request.Scheme);

            return confirmationLink!;
        }
    }
    
}

