using System;
using System.Collections.Generic;

namespace HeroicCRM.Web.Core
{
	public class Customer
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string WorkEmail { get; set; }

		public string HomeEmail { get; set; }

		public string WorkPhone { get; set; }

		public string HomePhone { get; set; }

		public string HomeAddress { get; set; }

		public string WorkAddress { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime? TerminationDate { get; set; }

		public IList<Opportunity> Opportunities { get; set; }

		public IList<Risk> Risks { get; set; }

		public Customer()
		{
			CreateDate = DateTime.Today;
		}
	}
}