using System;
using FaceLessBook.Domain.Contracts.Commands;

namespace FaceLessBook.Domain.Commands.Member
{
    public class AddFriendCommand : IAddFriendCommand
    {
        public ICommandValidationResult Validate()
        {
            throw new NotImplementedException();
        }

        public void ExecuteIfValid()
        {
            throw new NotImplementedException();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}