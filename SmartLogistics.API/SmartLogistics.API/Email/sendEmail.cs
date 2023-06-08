using System.Net.Mail;
using System.Text;

namespace SmartLogistics.API.Email
{
    public  class sendEmail
    {
        public async Task SendEmailToClientAsync()
        {
            string to = "markusstaub1@gmail.com"; // To address
            string from = "smartLogisticsZBWSenden@yahoo.com"; // From address

            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send an email using Asp.Net & C#";
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525); // Mailtrap SMTP

            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("smart logistics", "SmartLogisticsDelivery");

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
