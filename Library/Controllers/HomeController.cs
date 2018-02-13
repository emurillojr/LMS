using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller // inherit from Controller base class
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
