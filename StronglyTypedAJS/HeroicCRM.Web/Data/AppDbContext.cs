using System.Data.Entity;
using HeroicCRM.Web.Core;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HeroicCRM.Web.Data
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public IDbSet<Customer> Customers { get; set; }

		public IDbSet<Opportunity> Opportunities { get; set; }

		public IDbSet<Risk> Risks { get; set; }
	}
}