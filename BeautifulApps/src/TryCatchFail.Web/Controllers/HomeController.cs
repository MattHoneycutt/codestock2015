using Microsoft.AspNet.Mvc;

namespace TryCatchFail.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
