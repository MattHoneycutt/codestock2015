using Heroic.AutoMapper;
using HeroicCRM.Web.Core;

namespace HeroicCRM.Web.Models
{
	public class CustomerRiskViewModel : IMapFrom<Risk>
	{
		public string Title { get; set; }

		public string Description { get; set; }
	}
}