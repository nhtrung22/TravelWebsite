using Microsoft.AspNetCore.Mvc;
using TravelWebsite.API.Controllers;
using TravelWebsite.Business.Common.Attributes;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Services;

namespace TravelWebsite.API.Controller
{
    [Authorize("Admin")]
    public class AdminController : BaseController
    {
        [HttpGet("Statistics")]
        public void Get()
        {
            //todo
        }
    }
}
