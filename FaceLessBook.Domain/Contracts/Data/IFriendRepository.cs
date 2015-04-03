using System.Collections.Generic;
using FaceLessBook.Domain.Models;

namespace FaceLessBook.Domain.Contracts.Data
{
    public interface IFriendRepository
    {
        IEnumerable<Friend> ListFriendsOfUser(int userId);
    }
}
