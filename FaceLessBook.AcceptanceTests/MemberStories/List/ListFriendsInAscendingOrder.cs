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
    public class ListFriendsInAscendingOrder : SqlServerDataContextBase
    {
        // Fields needed to work with the UI - MVP
        Mock<IListFriendView> _mockView; // in order for us to test the presenter we will mock the view
        private ListFriendPresenter _presenter; 
        private IFriendCommandFactory _commandFactory;
        private int _userId = 1;

        protected override void Init()
        {
            base.Init();

            _commandFactory = new FriendCommandFactory(UnitOfWork);
        }

        [Given(@"I am on the Friends screen with the listing in descending order")]
        public void GivenIAmOnTheFriendsScreenWithTheListingInDescendingOrder()
        {
            _mockView = new Mock<IListFriendView>();

            // inject the concrete implementations
            _presenter = new ListFriendPresenter(_commandFactory, _mockView.Object, _userId);
            _presenter.Init(); // default sort order is ascending

            _presenter.Sort(false); // so, sort it in descending order
        }
        
        [When(@"I press the Name column header to sort in ascending order")]
        public void WhenIPressTheNameColumnHeaderToSortInAscendingOrder()
        {
            _presenter.Sort(true);
        }
        
        [Then(@"the result should be the list of Friends in ascending order")]
        public void ThenTheResultShouldBeTheListOfFriendsInAscendingOrder()
        {
            // Verify that the "View.Show" method was called from the interface with the exact 
            // input of FriendListVM
            // the lambda expression is not really executing
            // it is being turned into an expression tree and then analyzed by Moq, not actually being executed

            // verify that the "View.Show" method was called from the interface with any input of FriendListVM
            // first call - from the _presenter.Init() - default ascending order
            // second call - from the _presenter.Sort(false) - descending order
            // third call - from the _presenter.Sort(true) - ascending order
            _mockView.Verify(v => v.Show(
                It.IsAny<FriendListVM>()), Times.Exactly(3)
            );

            // verify the expected result, "Bill Gates" has been on the top list twice based on the prev verification
            // with 2 ascending sort order
            _mockView.Verify(v => v.Show(
                It.Is<FriendListVM>(vm => vm.Friends.ElementAt(0).FullName == "Bill Gates")), Times.Exactly(2)
            );
        }
    }
}
