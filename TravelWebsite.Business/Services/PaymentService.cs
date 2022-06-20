using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Models;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Exceptions;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Entities;

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

        public async Task Create(decimal amount)
        {
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                _momoSettings.PartnerCode + "&accessKey=" +
                _momoSettings.AccessKey + "&requestId=" +
                requestId + "&amount=" +
                ((int)amount).ToString() + "&orderId=" +
                orderid + "&orderInfo=" +
                _momoSettings.OrderInfo + "&returnUrl=" +
                _momoSettings.ReturnUrl + "&notifyUrl=" +
                _momoSettings.Notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, _momoSettings.Secretkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", _momoSettings.PartnerCode },
                { "accessKey", _momoSettings.AccessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", _momoSettings.OrderInfo },
                { "returnUrl", _momoSettings.ReturnUrl },
                { "notifyUrl", _momoSettings.Notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(message);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync(_momoSettings.Endpoint, data);
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new AppException("Something wrong");
            }
            //string responseFromMomo = PaymentRequest.sendPaymentRequest(_momoSettings.Endpoint, message.ToString());
            return;
        }
    }
}
