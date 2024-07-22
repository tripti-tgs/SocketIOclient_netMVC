using Microsoft.AspNetCore.Mvc;

namespace SocketMVC.Controllers
{
    public class TestPage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
