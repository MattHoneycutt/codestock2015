using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace HeroicCRM.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var authenticationOptions = new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Authorization/Login"),
			};

			app.UseCookieAuthentication(authenticationOptions);
		}
	}
}