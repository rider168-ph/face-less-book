using FaceLessBook.Domain.Commands.Member;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FaceLessBook.UnitTests.Commands.Member.ListFriends
{
    /// <summary>
    /// This Unit Test is intended only for the Command logic.
    /// Dependencies such as UnitOfWork and Repositories are all mocks only.
    /// This is to isolate the test to particular class.
    /// </summary>
    [TestClass]
    public class When_executing_a_ListFriendsCommand : With_a_command
    {
        private ListFriendsCommand _command;

        [TestMethod]
        public void And_it_is_a_valid_command_should_validate_to_true()
        {
            // Arrange
            _command = new ListFriendsCommand(_mockUnitOfWork.Object);
            _command.UserId = 5;
            
            // Act
            _command.Execute();

            // Assert
            Assert.IsTrue(_command.Validate().IsValid, "ListFriendsCommand is not valid");
        }

        [TestMethod]
        public void And_it_has_a_null_UnitOfWork_should_return_invalid()
        {
            // Arrange
            _command = new ListFriendsCommand(null);
            _command.UserId = 5;

            // Act
            _command.Execute();

            var validationResult = _command.Validate();

            // Assert
            Assert.IsFalse(validationResult.IsValid, "ListFriendsCommand is valid");
        }
    }
}
