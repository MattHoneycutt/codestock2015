using System.Web.Mvc;

namespace HeroicCRM.Web.Controllers
{
	public class HomeController : HeroicCRMControllerBase
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}