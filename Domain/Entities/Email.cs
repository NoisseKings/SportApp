using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        private static MailMessage getMailMessage(Email email)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.Body = email.Body;
            mail.Subject = email.Subject;
            mail.From = new MailAddress("aleksandartornjanski72@gmail.com");
            mail.To.Add(email.To);
            return mail;
        }

        public bool SendSmtpMail(Email data)
        {
            try
            {
                MailMessage message = getMailMessage(data);
                var credentials = new NetworkCredential("aleksandartornjanski72@gmail.com", "nba2k100");
                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.office365.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                client.Send(message);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
