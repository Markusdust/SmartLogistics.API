using System.Net.Mail;
using System.Text;

namespace SmartLogistics.API.Email
{
    public  class sendEmail
    {
        public async Task SendEmailToClientAsync()
        {
            string to = "markusstaub1@gmail.com"; // To address
            string from = "Smartlogisticsch@gmail.com"; // From address

            MailMessage message = new MailMessage(from, to);

            string mailbody = "Test email: Ihr Paket wird in kürze ankommen";
            message.Subject = "ZBW Schule AüP Projekt";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); // Gmail SMTP

            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("Smartlogisticsch@gmail.com", "tbirwdmyrxfutvls");

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                await client.SendMailAsync(message);
                await Console.Out.WriteLineAsync("Email was send to " + to+".");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("Email konnte and" + to +" nicht versendet werden." + "r\n" + ex);
            } 
        }


    }
}
