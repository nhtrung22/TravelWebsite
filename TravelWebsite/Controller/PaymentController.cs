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
    public IActionResult Create()
    {
        var result = _paymentService.Create();
        return Ok(new { clientSecret = result.ClientSecret });
    }
}