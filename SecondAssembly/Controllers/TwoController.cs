using Microsoft.AspNetCore.Mvc;

namespace SecondAssembly.Controllers
{
    [Route("[module]/[controller]")]
    public class TwoController : Controller
    {
        [HttpGet("ActionInSecond")]
        public IActionResult ActionInSecond()
        {
            return View();
        }
    }
}