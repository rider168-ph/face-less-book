using System.Data.Entity.ModelConfiguration;
using FaceLessBook.Domain.Models;

namespace FaceLessBook.Infrastructure.Data.SqlServer.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            // Primary Key
            //HasKey(t => t.UserId);

            // Properties
            //Property(t => t.UserName)
            //    .IsRequired()
            //    .HasMaxLength(50);

            // Table & Column Mappings
            //this.ToTable("Users");
            //this.Property(t => t.ApplicationId).HasColumnName("ApplicationId");
            //this.Property(t => t.UserId).HasColumnName("UserId");
            //this.Property(t => t.UserName).HasColumnName("UserName");
            //this.Property(t => t.LoweredUserName).HasColumnName("LoweredUserName");
            //this.Property(t => t.MobileAlias).HasColumnName("MobileAlias");
            //this.Property(t => t.IsAnonymous).HasColumnName("IsAnonymous");
            //this.Property(t => t.LastActivityDate).HasColumnName("LastActivityDate");

            // Relationships
            
        }
    }
}
