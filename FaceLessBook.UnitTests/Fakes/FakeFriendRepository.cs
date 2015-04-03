using System.Collections.Generic;
using System.Linq;
using FaceLessBook.Domain.Contracts.Data;
using FaceLessBook.Domain.Models;
using FaceLessBook.TestData;

namespace FaceLessBook.UnitTests.Fakes
{
    public class FakeFriendRepository : FakeRepository<Friend>, IFriendRepository
    {
        public IEnumerable<Friend> ListFriendsOfUser(int userId)
        {
            var friends = DataInMemory.CreateFriends();

            foreach (var friend in friends)
            {
                _set.Add(friend);
            }

            return _set.Where(w => w.UserId == userId);
        }
    }
}
