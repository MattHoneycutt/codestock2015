using System.Data.Entity.Migrations;
using HeroicCRM.Web.Data;

namespace HeroicCRM.Web.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDbContext context)
        {
            
        }
    }
}
