using System.Linq;
using FaceLessBook.Domain.Commands.Member;
using FaceLessBook.Domain.Contracts.Commands;
using FaceLessBook.UI.MVP.Models;
using FaceLessBook.UI.MVP.Presenters.Member.List;
using FaceLessBook.UI.MVP.Views.Member;
using Moq;
using TechTalk.SpecFlow;

namespace FaceLessBook.AcceptanceTests.MemberStories.List
{
    [Binding]
    public class ListFriendsInDescendingOrder : SqlServerDataContextBase
    {
        // Fields needed to work with the UI - MVP
        Mock<IListFriendView> _mockView; // in order for us to test the presenter we will mock the view
        private ListFriendPresenter _presenter;
        private IFriendCommandFactory _commandFactory;
        private const int _userId = 1;

        protected override void Init()
        {
            base.Init();

            _commandFactory = new FriendCommandFactory(UnitOfWork);
        }

        [Given(@"I am on the Friends screen with the listing in ascending order")]
        public void GivenIAmOnTheFriendsScreenWithTheListingInAscendingOrder()
        {
            _mockView = new Mock<IListFriendView>();

            // inject the concrete implementations
            _presenter = new ListFriendPresenter(_commandFactory, _mockView.Object, _userId);
            _presenter.Init();
        }
        
        [When(@"I press the Name column header to sort in descending order")]
        public void WhenIPressTheNameColumnHeaderToSortInDescendingOrder()
        {
            _presenter.Sort(false); //sort in descending
        }
        
        [Then(@"the result should be the list of Friends in descending order")]
        public void ThenTheResultShouldBeTheListOfFriendsInDescendingOrder()
        {
            // Verify that the "View.Show" method was called from the interface with the exact 
            // input of FriendListVM
            // the lambda expression is not really executing
            // it is being turned into an expression tree and then analyzed by Moq, not actually being executed
       
            // verify that the "View.Show" method was called from the interface with any input of FriendListVM
            // first call - from the _presenter.Init()
            // second call - from the _presenter.Sort(false)
            _mockView.Verify(v => v.Show(
                It.IsAny<FriendListVM>()), Times.Exactly(2)
            );

            // verify the sort is in ascending order from the first call in _presenter.Init()
            _mockView.Verify(v => v.Show(
                It.Is<FriendListVM>(vm => vm.Friends.ElementAt(0).FullName == "Bill Gates")), Times.Exactly(1)
            );

            // verify the sort is in descending order from the second call in _presenter.Sort(false)
            _mockView.Verify(v => v.Show(
                It.Is<FriendListVM>(vm => vm.Friends.ElementAt(0).FullName == "Steve Smith")), Times.Exactly(1)
            );
        }
    }
}
