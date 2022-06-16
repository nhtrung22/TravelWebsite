using TravelWebsite.Business.Models;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
