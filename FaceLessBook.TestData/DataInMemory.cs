using System.Collections.Generic;
using FaceLessBook.Domain.Models;

namespace FaceLessBook.TestData
{
    public static class DataInMemory
    {
        public static User User;

        public static User CreateUser()
        {
            User = new User()
            {
                Id = 1,
                UserName = "testuser",
                EmailAddress = "test@domain.com"
            };

            return User;
        }

        public static List<Friend> CreateFriends()
        {
            return new List<Friend>
                {
                    new Friend { FirstName = "Bill", LastName = "Gates", UserId = User.Id },
                    new Friend { FirstName = "Bob", LastName = "Martin", UserId = User.Id },
                    new Friend { FirstName = "Martin", LastName = "Fowler", UserId = User.Id },
                    new Friend { FirstName = "David", LastName = "Starr", UserId = User.Id },
                    new Friend { FirstName = "John", LastName = "Papa", UserId = User.Id },
                    new Friend { FirstName = "John", LastName = "Sonmez", UserId = User.Id },
                    new Friend { FirstName = "Scott", LastName = "Allen", UserId = User.Id },
                    new Friend { FirstName = "Steve", LastName = "Smith", UserId = User.Id }
                };
        }
    }
}
