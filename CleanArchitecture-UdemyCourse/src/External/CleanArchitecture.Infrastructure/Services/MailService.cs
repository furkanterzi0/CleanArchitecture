using CleanArchitecture.Application.Services;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Net.Mail;

namespace CleanArchitecture.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["MailSettings:From"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            //using var smtp = new MailKit.Net.Smtp.SmtpClient();
            //await smtp.ConnectAsync(_configuration["MailSettings:SmtpServer"], int.Parse(_configuration["MailSettings:Port"]), true);
            //await smtp.AuthenticateAsync(_configuration["MailSettings:Username"], _configuration["MailSettings:Password"]);
            //await smtp.SendAsync(email);
            //await smtp.DisconnectAsync(true);
        }
    }
}
