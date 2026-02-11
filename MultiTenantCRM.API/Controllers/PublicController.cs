using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MultiTenantCRM.API.Controllers
{
    [Area("PublicArea")]
    [DisplayName("Public Controller")]
    [Route("api / [area]/[controlller]")]
    public class PublicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
