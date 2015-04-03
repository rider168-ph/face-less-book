using System.Collections.Generic;
using FaceLessBook.Domain.Models;

namespace FaceLessBook.Domain.Contracts.Commands
{
    /// <summary>
    /// Using Factory Design Pattern
    /// </summary>
    public interface IFriendCommandFactory
    {
        IListFriendsCommand CreateListFriendCommand();
        //IAddFriendCommand CreateAddFriendCommand();
        //IEditFriendCommand CreateEditFriendCommand();
        //IDeleteFriendCommand CreateDeleteFriendCommand();
    }

    public interface IListFriendsCommand : ICommandWithValidation
    {
        int UserId { set; }
        IEnumerable<Friend> ListOFriends { get; }
    }

    public interface IAddFriendCommand : ICommandWithValidation
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    public interface IEditFriendCommand : ICommandWithValidation
    {
        int Id { set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    //public interface IDeleteFriendCommand : ICommandWithValidation
    //{
    //    int Id { get; set; }
    //}
    
}
