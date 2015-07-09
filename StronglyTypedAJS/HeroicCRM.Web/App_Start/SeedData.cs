using System;
using System.Collections.Generic;
using System.Linq;
using HeroicCRM.Web.Core;
using HeroicCRM.Web.Data;
using HeroicCRM.Web.Identity;
using HeroicCRM.Web.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HeroicCRM.Web
{
	public static class SeedData
	{
		public static void Init()
		{
			using (var context = new AppDbContext())
			{
				if (!context.Users.Any())
				{
					var manager = new ApplicationUserManager(new UserStore<User>(context));
					manager.Create(new User
					{
						Email = "matt.honeycutt@me.com",
						UserName = "Matt Honeycutt",
					}, "Password1");

					manager.Create(new User
					{
						Email = "john.doe@me.com",
						UserName = "John Doe",
					}, "Password1");

					manager.Create(new User
					{
						Email = "jane.doe@me.com",
						UserName = "Jane Doe",
					}, "Password1");
				}

				if (!context.Customers.Any())
				{
					AddNewCustomers(context);

					AddExistingCustomers(context);

					AddTerminatedCustomers(context);

					context.SaveChanges();
				}
			}
		}

		private static void AddTerminatedCustomers(AppDbContext context)
		{
			context.Customers.Add(new Customer
			{
				Name = "Arlo Seymour",
				HomeEmail = "Arlo@home.com",
				WorkEmail = "Arlo@work.com",
				WorkAddress = "123 Arlo Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Seymour Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-90),
				TerminationDate = DateTime.Today.ToStartOfMonth().AddDays(5),
			});

			context.Customers.Add(new Customer
			{
				Name = "Porter Jakeman",
				HomeEmail = "Porter@home.com",
				WorkEmail = "Porter@work.com",
				WorkAddress = "123 Porter Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Jakeman Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-75),
				TerminationDate = DateTime.Today.ToStartOfMonth().AddDays(10),
			});

			context.Customers.Add(new Customer
			{
				Name = "Edwyn Perry",
				HomeEmail = "Edwyn@home.com",
				WorkEmail = "Edwyn@work.com",
				WorkAddress = "123 Edwyn Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Perry Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-45),
				TerminationDate = DateTime.Today.ToStartOfMonth().AddDays(15),
			});
		}

		private static void AddExistingCustomers(AppDbContext context)
		{
			context.Customers.Add(new Customer
			{
				Name = "Gosse Greene",
				HomeEmail = "Gosse@home.com",
				WorkEmail = "Gosse@work.com",
				WorkAddress = "123 Gosse Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Greene Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-20),
				Risks = new List<Risk>()
				{
					new Risk{Title = "Considering vendor switch", Description = "His contract is expiring next month, and he's evaluating other vendors.  He likes the services we provide, but feels he is paying too much."}
				}
			});

			context.Customers.Add(new Customer
			{
				Name = "Warwick Rye",
				HomeEmail = "Warwick@home.com",
				WorkEmail = "Warwick@work.com",
				WorkAddress = "123 Warwick Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Rye Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-15),
				Opportunities = new List<Opportunity>
				{
					new Opportunity{Title = "Expanding business", Description = "Warwick's business is booming.  He's considering acquiring a competitor.  If that happens, he'll need a *lot* of custom development to integrate the two systems."}
				}
			});

			context.Customers.Add(new Customer
			{
				Name = "Odell Dennel",
				HomeEmail = "Odell@home.com",
				WorkEmail = "Odell@work.com",
				WorkAddress = "123 Odell Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Dennel Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-10),
				Risks = new List<Risk>
				{
					new Risk{Title = "Customer may not pay", Description = "Odell is not pleased with the solution we developed.  He has threatened to stop all future payments, including outstanding invoices for work that has already been performed."}
				}
			});
		}

		private static void AddNewCustomers(AppDbContext context)
		{
			context.Customers.Add(new Customer
			{
				Name = "John Doe",
				HomeEmail = "john@home.com",
				WorkEmail = "john@work.com",
				WorkAddress = "123 Main Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Second Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth()
			});

			context.Customers.Add(new Customer
			{
				Name = "Roy Irvine",
				HomeEmail = "roy@home.com",
				WorkEmail = "roy@work.com",
				WorkAddress = "123 Roy Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Irvine Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(5),
			});

			context.Customers.Add(new Customer
			{
				Name = "Vere Rowland",
				HomeEmail = "vere@home.com",
				WorkEmail = "vere@work.com",
				WorkAddress = "123 Vere Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Roland Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(10),
			});

			context.Customers.Add(new Customer
			{
				Name = "Zack Beasley",
				HomeEmail = "zack@home.com",
				WorkEmail = "zack@work.com",
				WorkAddress = "123 Zack Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Beasley Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(15),
				Opportunities = new List<Opportunity>
				{
					new Opportunity{Title = "Interested in on-site support", Description = "Zack likes the solution we developed for his business.  He's interested in our on-site support services, too."}
				}
			});
		}
	}
}