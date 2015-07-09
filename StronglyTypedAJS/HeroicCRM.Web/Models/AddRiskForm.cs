using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Heroic.AutoMapper;
using HeroicCRM.Web.Core;

namespace HeroicCRM.Web.Models
{
	public class AddRiskForm : IMapTo<Risk>
	{
		[HiddenInput]
		public int CustomerId { get; set; }

		[Required]
		public string Title { get; set; }

		[Required, DataType(DataType.MultilineText)]
		public string Description { get; set; }
	}
}