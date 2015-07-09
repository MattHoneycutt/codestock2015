using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using HeroicCRM.Web.Data;
using HeroicCRM.Web.Models;
using HeroicCRM.Web.Utilities;

namespace HeroicCRM.Web.Controllers
{
	public class ReportController : HeroicCRMControllerBase
	{
		private readonly AppDbContext _context;

		public ReportController(AppDbContext context)
		{
			_context = context;
		}

		public ActionResult Index()
		{
			return View();
		}

		public JsonResult NewCustomers()
		{
			var startOfMonth = DateTime.Today.ToStartOfMonth();
			var endOfMonth = DateTime.Today.ToEndOfMonth();

			var customers = _context.Customers.Where(x => x.CreateDate >= startOfMonth && x.CreateDate <= endOfMonth)
				.Project().To<NewCustomerReportViewModel>().ToArray();

			return BetterJson(customers);
		}

		public JsonResult LostCustomers()
		{
			var startOfMonth = DateTime.Today.ToStartOfMonth();
			var endOfMonth = DateTime.Today.ToEndOfMonth();

			var customers = _context.Customers.Where(x => x.TerminationDate >= startOfMonth && x.TerminationDate <= endOfMonth)
				.Project().To<LostCustomerReportViewModel>().ToArray();

			return BetterJson(customers);
		}
	}
}