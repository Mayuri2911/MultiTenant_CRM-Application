using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MultiTenantCRM.API.Controllers
{

    [ApiController]
    [Area("PublicArea")]
    [Route("api/[area]/[controller]")]
    public class PublicController : ControllerBase
    {
        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hello from public area!");
        }
    }
}
