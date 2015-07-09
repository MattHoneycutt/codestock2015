using System.Web.Mvc;
using AutoMapper;
using HeroicCRM.Web.Identity;
using HeroicCRM.Web.Models;
using Microsoft.AspNet.Identity;

namespace HeroicCRM.Web.Controllers
{
	public class ProfileController : HeroicCRMControllerBase
	{
		private readonly ApplicationUserManager _userManager;

		public ProfileController(ApplicationUserManager userManager)
		{
			_userManager = userManager;
		}

		public ActionResult Index()
		{
			return View();
		}

		public JsonResult LoadProfile()
		{
			var model = Mapper.Map<ProfileForm>(_userManager.FindById(User.Identity.GetUserId()));

			return BetterJson(model);
		}

		public JsonResult Update(ProfileForm form)
		{
			var user = _userManager.FindById(User.Identity.GetUserId());
			user.Email = form.EmailAddress;
			user.UserName = form.FullName;
			_userManager.Update(user);

			return BetterJson(true);
		}
	}
}