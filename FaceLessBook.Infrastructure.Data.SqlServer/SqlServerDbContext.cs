using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FaceLessBook.Infrastructure.Data.SqlServer.Configuration;
using FaceLessBook.Domain.Models;

namespace FaceLessBook.Infrastructure.Data.SqlServer
{
    /// <summary>
    /// Using EntityFramework Code First approach
    /// Code First is an approach where you define classes & relationships between them and let EF 
    /// do the work for creating the DB and data model. 
    /// </summary>
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext()
            : base(nameOrConnectionString: "FaceLessBookSqlServer") { }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // use singular table names
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new FriendConfiguration());
        }
    }
}
