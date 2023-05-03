using PizzaApp.Application.Services.ExternalServices;

namespace PizzaApp.Infrastracture
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string body)
        {
            return Task.FromResult(0);
        }
    }
}
