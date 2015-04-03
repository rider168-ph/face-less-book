using System;
using System.Linq;
using FaceLessBook.Infrastructure.Data.SqlServer;
using FaceLessBook.Infrastructure.Data.SqlServer.Helpers;
using FaceLessBook.Infrastructure.Data.SqlServer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FaceLessBook.TestData.SqlServer
{
    [TestClass]
    public class EfSqlServerCodeFirstTests
    {
        /// <summary>
        /// This should be located on the developer's local machine to keep it isolated
        /// </summary>
        [TestMethod]
        public void DatabaseInitialization()
        {
            //this will read from app.config connection string 'FaceLessBookSqlServer'
            //this is the default behaviour for both the staging and production
            using (var context = new SqlServerDbContext())
            {
                //context.Database.Connection.ConnectionString = "Data Source=.;Initial Catalog=FaceLessBook_Test;Integrated Security=True;MultipleActiveResultSets=True";
                var initializer = new EfCodeFirstDbInitializer();
                initializer.Reseed(context);
                Assert.IsTrue(context.Users.Any(), "DevTest: No User data");
                Assert.IsTrue(context.Friends.Any(), "DevTest: No Friends data");
            }
        }

        [TestMethod]
        public void ConnectToSqlServerDb()
        {
            using (var context = new SqlServerDbContext())
            {
                Assert.IsTrue(context.Users.Any(), "DevTest: No User data");
                Assert.IsTrue(context.Friends.Any(), "DevTest: No Friends data");
            }
        }

        [TestMethod]
        public void UnitOfWorkShouldReturn_UserAndFriends()
        {
            var repositoryFactories = new RepositoryFactories();
            var repositoryProvider = new RepositoryProvider(repositoryFactories)
            {
                DbContext = new SqlServerDbContext()
            };

            var unitOfWork = new SqlServerUnitOfWork(repositoryProvider);

            var user = unitOfWork.Users.GetById(1);

            Assert.IsNotNull(user, "SQL Server DevTest: User is null");
            Assert.IsTrue(user.UserName == "testuser", "SQL Server DevTest: UserName is not testuser");

            var friends = unitOfWork.Friends.ListFriendsOfUser(1).ToList();

            Assert.IsNotNull(friends, "SQL Server DevTest: Friends is null");

            foreach (var friend in friends)
            {
                Console.WriteLine("{0}", friend.FullName);
            }
        }
    }
}

