using Stripe;

namespace TravelWebsite.Business.Services
{
    public interface IPaymentService
    {
        PaymentIntent Create();
    }
}