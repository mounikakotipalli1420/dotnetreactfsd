using Microsoft.AspNetCore.Mvc;

namespace FeedBackAppA.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
