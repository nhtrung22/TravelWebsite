namespace TravelWebsite.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.Common.Attributes;
using TravelWebsite.Business.Services;

[Authorize("Client", "Admin")]
public class PaymentController : BaseController
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(PaymentIntentCreateRequest paymentIntentCreateRequest)
    {
        var result = await _paymentService.Create(paymentIntentCreateRequest.Id, paymentIntentCreateRequest.Number);
        return Ok(new { clientSecret = result.ClientSecret });
    }

    public class PaymentIntentCreateRequest
    {
        public int Id { get; set; }
        public int Number { get; set; }
    }
}