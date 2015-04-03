using FaceLessBook.Domain.Contracts.Commands;
using FaceLessBook.Domain.Contracts.Data;

namespace FaceLessBook.Domain.Commands.Member
{
    public class FriendCommandFactory : IFriendCommandFactory
    {
        private readonly IUnitOfWork _unitOfWork;

        public FriendCommandFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IListFriendsCommand CreateListFriendCommand()
        {
            return new ListFriendsCommand(_unitOfWork);
        }

        //public IAddFriendCommand CreateAddFriendCommand()
        //{
        //    return new AddFriendCommand();
        //}

        //public IEditFriendCommand CreateEditFriendCommand()
        //{
        //    return new EditFriendCommand();
        //}
    }
}
