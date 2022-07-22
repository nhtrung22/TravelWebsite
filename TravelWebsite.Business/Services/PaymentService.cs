using AutoMapper;
using Microsoft.Extensions.Options;
using Stripe;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Models;
using TravelWebsite.DataAccess.EF;
namespace TravelWebsite.Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly ITravelDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMailService _mailService;
        private readonly MomoSettings _momoSettings;
        private readonly IHttpClientFactory _clientFactory;

        public PaymentService(IMapper mapper, ITravelDbContext context, ICurrentUserService currentUserService, IMailService mailService, IOptions<MomoSettings> momoSettings, IHttpClientFactory clientFactory)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
            _mailService = mailService;
            _momoSettings = momoSettings.Value;
            _clientFactory = clientFactory;
        }

        public async Task<PaymentIntent> Create(int id, int number)
        {
            var paymentMethodService = new PaymentMethodService();
            var paymentMethod = paymentMethodService.Create(new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = "4242424242424242",
                    ExpMonth = 12,
                    ExpYear = 2034,
                    Cvc = "567",
                },
            });
            var paymentIntents = new PaymentIntentService();
            var item = await _context.Properties.FindAsync(id);
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                Amount = Convert.ToInt64(item.Price) * number,
                Currency = "usd",
                PaymentMethod = paymentMethod.Id,
                //AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                //{
                //    Enabled = true,
                //},
                PaymentMethodTypes = new List<string> { "card", },
            });

            return paymentIntent;
        }
    }
}
