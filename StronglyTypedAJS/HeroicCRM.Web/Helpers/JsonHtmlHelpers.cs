using System.Web;
using System.Web.Mvc;
using HeroicCRM.Web.Utilities;

namespace HeroicCRM.Web.Helpers
{
	public static class JsonHtmlHelpers
	{
		public static IHtmlString JsonFor<T>(this HtmlHelper helper, T obj)
		{
			return helper.Raw(obj.ToJson());
		}
	}
}