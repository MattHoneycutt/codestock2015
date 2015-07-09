using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HeroicCRM.Web.Core;
using HeroicCRM.Web.Data;
using HeroicCRM.Web.Models;

namespace HeroicCRM.Web.Controllers
{
	public class CustomerController : HeroicCRMControllerBase
	{
		private readonly AppDbContext _context;

		public CustomerController(AppDbContext context)
		{
			_context = context;
		}

		public ActionResult Index()
		{
			return View();
		}

		public JsonResult All()
		{
			var customerModels = _context.Customers
				.OrderByDescending(x => x.CreateDate)
				.Project().To<CustomerViewModel>();

			return BetterJson(customerModels.ToArray());
		}

		public JsonResult Add(AddCustomerForm form)
		{
			var customer = Mapper.Map<Customer>(form);
			_context.Customers.Add(customer);
			_context.SaveChanges();

			var model = Mapper.Map<CustomerViewModel>(customer);
			return BetterJson(model);
		}

		public JsonResult Update(EditCustomerForm form)
		{
			var target = _context.Customers.Find(form.Id);

			Mapper.Map(form, target);

			_context.SaveChanges();

			var updatedCustomer = _context.Customers.Project().To<CustomerViewModel>().Single(x => x.Id == form.Id);

			return BetterJson(updatedCustomer);
		}
	}
}