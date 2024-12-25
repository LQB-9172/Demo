using System.Net.Mail;
using System.Net;

namespace Demo.Repositories.Interface
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message);
    }

    

}
