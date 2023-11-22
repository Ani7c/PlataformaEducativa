using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EM.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
