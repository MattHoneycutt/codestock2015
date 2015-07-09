using System;
using Heroic.AutoMapper;
using HeroicCRM.Web.Core;

namespace HeroicCRM.Web.Models
{
	public class OpportunityViewModel : IMapFrom<Opportunity>
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime CreateDate { get; set; }

		public int CustomerId { get; set; }

		public string CustomerName { get; set; }
	}
}