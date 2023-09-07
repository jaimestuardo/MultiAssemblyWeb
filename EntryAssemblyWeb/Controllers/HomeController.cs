using Microsoft.AspNetCore.Mvc;

namespace EntryAssemblyWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}