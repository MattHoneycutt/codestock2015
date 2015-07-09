using System.Data.Entity;
using System.Web;
using HeroicCRM.Web.Core;
using HeroicCRM.Web.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using StructureMap.Configuration.DSL;

namespace HeroicCRM.Web.Identity
{
	public class AspNetIdentityRegistry : Registry
	{
		public AspNetIdentityRegistry()
		{
			For<IUserStore<User>>().Use<UserStore<User>>();
			For<DbContext>().Use<AppDbContext>();
			For<IAuthenticationManager>().Use(ctx => ctx.GetInstance<HttpRequestBase>().GetOwinContext().Authentication);
		}
	}
}