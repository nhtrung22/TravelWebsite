using Stripe;

namespace TravelWebsite.Business.Services
{
    public interface IPaymentService
    {
        Task<PaymentIntent> Create(int id);
    }
}