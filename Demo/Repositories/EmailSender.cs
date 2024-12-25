using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Demo.Repositories.Interface;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var emailSettings = _configuration.GetSection("EmailSettings");

        var host = emailSettings["Host"];
        var port = int.Parse(emailSettings["Port"]);
        var username = emailSettings["Username"];
        var appPassword = emailSettings["AppPassword"];
        var enableSsl = bool.Parse(emailSettings["EnableSsl"]);
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Your App Name", username));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = message
        };
        emailMessage.Body = bodyBuilder.ToMessageBody();
        using (var smtpClient = new SmtpClient())
        {
            try
            {
                await smtpClient.ConnectAsync(host, port, enableSsl);
                await smtpClient.AuthenticateAsync(username, appPassword);

                await smtpClient.SendAsync(emailMessage);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Không thể gửi email", ex);
            }
            finally
            {
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}
