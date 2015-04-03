using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FaceLessBook.Domain.Contracts.Data;
using FaceLessBook.Domain.Models;

namespace FaceLessBook.Infrastructure.Data.SqlServer.Repositories
{
    public class FriendRepository : EfRepository<Friend>, IFriendRepository
    {
        public FriendRepository(DbContext context) : base(context)
        {
        }


        public IEnumerable<Friend> ListFriendsOfUser(int userId)
        {
            return DatabaseSet.Where(w => w.UserId == userId).ToList();
        }

        //public void Create(Friend newFriend)
        //{
        //    _context.Friends.Add(newFriend);
        //    _context.SaveChanges();
        //}

        //public void Delete(int friendId)
        //{
        //    var friendToDelete = _context.Friends.FirstOrDefault(f => f.Id == friendId);
        //    _context.Friends.Remove(friendToDelete);
        //    _context.SaveChanges();
        //}

        
    }
}
