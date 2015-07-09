using System.Threading.Tasks;
using System.Web.Mvc;
using HeroicCRM.Web.Identity;
using HeroicCRM.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Web.Mvc;

namespace HeroicCRM.Web.Controllers
{
	[AllowAnonymous]
	public class AuthenticationController : HeroicCRMControllerBase
	{
		private readonly ApplicationUserManager _userManager;
		private readonly IAuthenticationManager _authManager;

		public AuthenticationController(ApplicationUserManager userManager, IAuthenticationManager authManager)
		{
			_userManager = userManager;
			_authManager = authManager;
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Login(LoginForm form)
		{
			var user = await _userManager.FindByEmailAsync(form.EmailAddress);

			if (user == null || ! (await _userManager.CheckPasswordAsync(user, form.Password)))
			{
				Response.StatusCode = 400;
				return Json("The username or password is invalid.");
			}


			var identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

			_authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

			return Json(true);
		}

		public ActionResult Logout()
		{
			_authManager.SignOut();

			return this.RedirectToAction<HomeController>(c => c.Index());
		}
	}
}