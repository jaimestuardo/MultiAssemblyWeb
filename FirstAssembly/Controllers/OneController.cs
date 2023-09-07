using Microsoft.AspNetCore.Mvc;

namespace FirstAssembly.Controllers
{
    [Route("[module]/[controller]")]
    public class OneController : Controller
    {
        private readonly ILogger<OneController> _logger;

        public OneController(ILogger<OneController> logger)
        {
            _logger = logger;
        }

        [HttpGet("ActionInFirst")]
        public IActionResult ActionInFirst()
        {
            return View();
        }
    }
}