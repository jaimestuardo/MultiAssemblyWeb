using Microsoft.AspNetCore.Mvc;
using OtherAssembly.Models;
using System.Diagnostics;

namespace OtherAssembly.Controllers
{
    [Route("[module]/[controller]")]
    public class OptionController : Controller
    {
        private readonly ILogger<OptionController> _logger;

        public OptionController(ILogger<OptionController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}