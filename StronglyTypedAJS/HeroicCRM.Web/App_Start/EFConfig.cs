using System.Data.Entity;
using HeroicCRM.Web.Data;

namespace HeroicCRM.Web
{
	public static class EFConfig
	{
		public static void Initialize()
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppDbContext>());
		}		 
	}
}