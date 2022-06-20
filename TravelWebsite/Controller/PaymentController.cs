namespace TravelWebsite.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.Common.Attributes;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Services;

[Authorize("Client")]
public class PaymentController : BaseController
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    [AllowAnonymous]
    public ActionResult Create()
    {
        _paymentService.Create();
        return Ok();
    }
}