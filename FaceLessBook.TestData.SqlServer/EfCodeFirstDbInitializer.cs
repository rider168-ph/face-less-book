using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using FaceLessBook.Infrastructure.Data.SqlServer;

namespace FaceLessBook.TestData.SqlServer
{
    public class EfCodeFirstDbInitializer :
        //CreateDatabaseIfNotExists<FaceLessBookDbContext>      // when model is stable
        DropCreateDatabaseIfModelChanges<SqlServerDbContext> // when iterating
    //DropCreateDatabaseAlways<FaceLessBookDbContext>
    {
        private const string TestUsername = "testuser";

        public void Reseed(SqlServerDbContext context)
        {
            Seed(context);
        }

        protected override void Seed(SqlServerDbContext context)
        {
            try
            {
                DataInMemory.CreateUser();

                var user = context.Users.FirstOrDefault(u => u.UserName == DataInMemory.User.UserName);
                if (user == null)
                {
                   context.Users.Add(DataInMemory.User);
                }
                context.SaveChanges();

                // remove test user's friends
                foreach (var friend in context.Friends.Where(f => f.UserId == DataInMemory.User.Id))
                {
                    context.Friends.Remove(friend);
                }
                context.SaveChanges();

                // add friends
                var friends = DataInMemory.CreateFriends();

                friends.ForEach(f => context.Friends.Add(f));
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.Error.WriteLine(ex.ToString());
                foreach (var errors in ex.EntityValidationErrors)
                {
                    foreach (var error in errors.ValidationErrors)
                    {
                        Console.Error.WriteLine("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }

            base.Seed(context);
        }
    }
}
