using System;
using FaceLessBook.Domain.Contracts.Commands;

namespace FaceLessBook.Domain.Commands.Member
{
    public class EditFriendCommand : IEditFriendCommand
    {
        public ICommandValidationResult Validate()
        {
            throw new NotImplementedException();
        }

        public void ExecuteIfValid()
        {
            throw new NotImplementedException();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}