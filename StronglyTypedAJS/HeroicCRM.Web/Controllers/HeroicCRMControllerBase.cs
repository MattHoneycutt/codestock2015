using System.Web.Mvc;
using HeroicCRM.Web.ActionResults;

namespace HeroicCRM.Web.Controllers
{
	public abstract class HeroicCRMControllerBase : Controller
	{
		public BetterJsonResult<T> BetterJson<T>(T model)
		{
			return new BetterJsonResult<T>() {Data = model};
		}
	}
}