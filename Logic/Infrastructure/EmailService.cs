using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Infrastructure
{
    public class EmailService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await ConfigSendGridAsync(message);
        }

        private static async Task ConfigSendGridAsync(IdentityMessage message)
        {
            var credentials = new NetworkCredential(
                "buslines123@gmail.com",
                "BusLines123!"
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
                    From = new MailAddress("buslines123@gmail.com", "BusLines"),
                    Body = message.Body,
                    BodyEncoding = Encoding.UTF8,
                    Subject = message.Subject,
                    To = { message.Destination },
                    IsBodyHtml = true
                };

                var client = new SmtpClient("smtp.gmail.com")
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

        public static void SendEmail(string subject, string messageBody, string emailAddress, string username)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("buslines123@gmail.com");
                mail.To.Add(emailAddress);
                mail.Subject = subject;
                mail.Body = "<h3>" + messageBody + "</h3>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("buslines123@gmail.com", "BusLines123!");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
                        



        // var fromAddress = new MailAddress("buslines123@gmail.com", "Bus Lines");
        // var toAddress = new MailAddress(emailAddress, username);
        // const string fromPassword = "BusLines123!";

        // var smtp = new SmtpClient
        // {
        //     Host = "smtp.gmail.com",
        //     Port = 587,
        //     EnableSsl = true,
        //     DeliveryMethod = SmtpDeliveryMethod.Network,
        //     Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
        //     UseDefaultCredentials = false,
        //     Timeout = 20000
        // };
        // using (var message = new MailMessage(fromAddress, toAddress)
        // {
        //     Subject = subject,
        //     Body = messageBody
        // })
        // {
        //     smtp.Send(message);
        // }
        }
    }
}
