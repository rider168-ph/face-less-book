using System.Data.Entity.Migrations;
using FaceLessBook.Domain.Models;

namespace FaceLessBook.TestData.SqlServer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.Data.SqlServer.SqlServerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Infrastructure.Data.SqlServer.SqlServerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //var user = new User()
            //{
            //    Id = 1,
            //    UserName = "testUser",
            //    EmailAddress = "test@domain.com",
            //    FirstName = "Fidel",
            //    LastName = "Hobayan"
            //};

            //context.Users.AddOrUpdate(user);
        }
    }
}
