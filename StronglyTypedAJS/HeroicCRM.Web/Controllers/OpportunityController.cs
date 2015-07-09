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
	public class OpportunityController : HeroicCRMControllerBase
	{
		private readonly AppDbContext _context;

		public OpportunityController(AppDbContext context)
		{
			_context = context;
		}

		public ViewResult Index()
		{
			var models = _context.Opportunities.Project().To<OpportunityViewModel>().ToArray();
			return View(models);
		}

		public JsonResult Add(AddOpportunityForm form)
		{
			var customer = _context.Customers.Include(x => x.Opportunities).Single(x => x.Id == form.CustomerId);

			var opportunity = Mapper.Map<Opportunity>(form);

			customer.Opportunities.Add(opportunity);

			_context.SaveChanges();

			var model = Mapper.Map<CustomerOpportunityViewModel>(opportunity);

			return BetterJson(model);
		}
	}
}