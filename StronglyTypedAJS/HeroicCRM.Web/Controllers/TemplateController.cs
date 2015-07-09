using System.Web.Mvc;

namespace HeroicCRM.Web.Controllers
{
	public class TemplateController : HeroicCRMControllerBase
	{
		public PartialViewResult Render(string feature, string name)
		{
			return PartialView(string.Format("~/js/app/{0}/templates/{1}", feature, name));
		}
	}
}