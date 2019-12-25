using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusLines.Utilities
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await ConfigSendGridAsync(message);
        }

        private static async Task ConfigSendGridAsync(IdentityMessage message)
        {
            var credentials = new NetworkCredential(
                "Adres email nadawcy",
                "Hasło konta"
            );

            // Wyślij email
            await SendEmailAsync(credentials, message);
        }

        private static async Task SendEmailAsync(NetworkCredential credentials, IdentityMessage message)
        {
            try
            {
                var mail = new MailMessage
                {
                    From = new MailAddress("Adres email nadawcy", Constants.AppName),
                    Body = message.Body,
                    BodyEncoding = Encoding.UTF8,
                    Subject = message.Subject,
                    To = { message.Destination },
                    IsBodyHtml = true
                };

                var client = new SmtpClient("Serwer pocztowy")
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                    EnableSsl = false,
                    Credentials = credentials
                };

                client.Send(mail);
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}
