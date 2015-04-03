using System.Collections.Generic;
using FaceLessBook.Domain.Contracts.Data;
using FaceLessBook.Domain.Models;
using Moq;

namespace FaceLessBook.UnitTests.Commands
{
    public abstract class With_a_command
    {
        protected Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();
        private Mock<IRepository<User>> _mockUserRepository = new Mock<IRepository<User>>();
        private Mock<IFriendRepository> _mockFriendRepository = new Mock<IFriendRepository>();

        public With_a_command()
        {
            _mockUserRepository.Setup(x => x.GetById(5)).Returns(new User {Id = 5});

            var friends = new List<Friend>
            {
                new Friend{ FirstName = "Bill", LastName = "Gates", UserId = 5},
                new Friend{ FirstName = "Bob", LastName = "Martin", UserId = 5}
            };

            _mockFriendRepository.Setup(x => x.ListFriendsOfUser(5)).Returns(friends);

            _mockUnitOfWork.SetupGet(u => u.Users).Returns(_mockUserRepository.Object);
            _mockUnitOfWork.SetupGet(f => f.Friends).Returns(_mockFriendRepository.Object);
        }
    }
}
