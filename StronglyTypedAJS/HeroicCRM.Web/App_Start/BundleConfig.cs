using System.Web.Optimization;

namespace HeroicCRM.Web
{
	public static class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/css/all.css")
				.Include("~/font-awesome/css/font-awesome.css")
				.Include("~/css/bootstrap.css")
				.Include("~/css/sb-admin.css")
				.Include("~/css/layout.css")
				.Include("~/css/ui-grid.css")
				);

			bundles.Add(new ScriptBundle("~/js/all.js")
				.Include("~/js/jquery.js")
				.Include("~/js/bootstrap.js")
				.Include("~/js/angular.js")
				.Include("~/js/angular-animate.js")
				.Include("~/js/ui-bootstrap.js")
				.Include("~/js/ui-grid.js")
				.Include("~/js/app/app.js")
				.IncludeDirectory("~/js/app/", "*.js", true)
				);
		}
	}
}