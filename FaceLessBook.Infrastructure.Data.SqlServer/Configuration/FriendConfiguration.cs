using System.Data.Entity.ModelConfiguration;
using FaceLessBook.Domain.Models;

namespace FaceLessBook.Infrastructure.Data.SqlServer.Configuration
{
    public class FriendConfiguration : EntityTypeConfiguration<Friend>
    {
        public FriendConfiguration()
        {
            // Primary Key
            //HasKey(t => t.Id);

            // Properties
            Property(t => t.FirstName)
                .IsRequired();

            Property(t => t.LastName)
                .IsRequired();

            //no field in database
            Ignore(t => t.FullName);

            // Table & Column Mappings
            //ToTable("Friends");
            //Property(t => t.Id).HasColumnName("Id");
            //Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            //Property(t => t.UserId).HasColumnName("UserId");

        }
    }
}
