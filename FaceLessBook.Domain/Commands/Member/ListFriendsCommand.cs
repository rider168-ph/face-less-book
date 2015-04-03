using System.Collections.Generic;
using FaceLessBook.Domain.Contracts.Commands;
using FaceLessBook.Domain.Contracts.Data;
using FaceLessBook.Domain.Models;

namespace FaceLessBook.Domain.Commands.Member
{
    public class ListFriendsCommand : CommandWithValidationBase, IListFriendsCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Implements IListFriendsCommand

        public int UserId { set; private get; }
        public IEnumerable<Friend> ListOFriends { get; private set; }
        
        #endregion

        public ListFriendsCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Implements ICommand
        /// </summary>
        public override void Execute()
        {
            ListOFriends = _unitOfWork.Friends.ListFriendsOfUser(UserId);
        }

        /// <summary>
        /// Implements ICommandWithValidation
        /// </summary>
        /// <returns>List of errors</returns>
        public override ICommandValidationResult Validate()
        {
            //TODO: convert these into Fluent API - LINQ powered rules engine
            ValidateUnitOfWork();
            ValidateUserId();

            return base.Validate();
        }

        private void ValidateUserId()
        {
          if (_unitOfWork.Users.GetById(UserId) == null)
                AddValidationError("User does not exist");
        }

        private void ValidateUnitOfWork()
        {
            if (_unitOfWork == null)
                AddValidationError("Data Unit of Work is not initialized");
        }

        //public void Dispose()
        //{
        //    var disposable = _unitOfWork as IDisposable;
        //    if (disposable != null)
        //        disposable.Dispose();
        //}
    }
}