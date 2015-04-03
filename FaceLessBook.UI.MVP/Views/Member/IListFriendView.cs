using FaceLessBook.UI.MVP.Models;

namespace FaceLessBook.UI.MVP.Views.Member
{
    /// <summary>
    /// Pass-in the ViewModel needed by the View
    /// </summary>
    public interface IListFriendView : IView
    {
        void Show(FriendListVM viewModel);
    }
}
