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

        public PaymentIntent Create()
        {
            var paymentIntents = new PaymentIntentService();
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                Amount = 1400,
                Currency = "usd",
            });

            return paymentIntent;
        }
    }
}
