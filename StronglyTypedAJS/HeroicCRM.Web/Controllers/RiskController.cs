using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HeroicCRM.Web.Core;
using HeroicCRM.Web.Data;
using HeroicCRM.Web.Models;

namespace HeroicCRM.Web.Controllers
{
	public class RiskController : HeroicCRMControllerBase
	{
		private readonly AppDbContext _context;

		public RiskController(AppDbContext context)
		{
			_context = context;
		}

		public ViewResult Index()
		{
			var models = _context.Risks.Project().To<RiskViewModel>().ToArray();
			return View(models);
		}

		public JsonResult Add(AddRiskForm form)
		{
			var customer = _context.Customers.Include(x => x.Risks).Single(x => x.Id == form.CustomerId);

			var risk = Mapper.Map<Risk>(form);

			customer.Risks.Add(risk);

			_context.SaveChanges();

			var model = Mapper.Map<CustomerRiskViewModel>(risk);

			return BetterJson(model);
		}
	}
}