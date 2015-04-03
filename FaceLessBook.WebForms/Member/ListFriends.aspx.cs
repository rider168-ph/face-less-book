using System;
using System.Linq;
using FaceLessBook.UI.MVP.Models;
using FaceLessBook.UI.MVP.Presenters.Member.List;
using FaceLessBook.UI.MVP.Views.Member;

namespace FaceLessBook.WebForms.Member
{
    public partial class ListFriends : PageBase, IListFriendView
    {
        private ListFriendPresenter _presenter;

        protected FriendListVM ViewModel { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = 0;
            int.TryParse(Request["sid"], out userId);

            _presenter = new ListFriendPresenter(FriendCommandFactory, this, userId);
            _presenter.Init();
        }

        public void ShowError(string error)
        {
            lblError.Text = error;
        }

        public void Show(FriendListVM viewModel)
        {
            ViewModel = viewModel;

            //bind ViewModel to the View's controls
            sortedHiddenField.Value = ViewModel.IsSortAscending.ToString();

            friendsRepeater.DataSource = ViewModel.Friends;
            friendsRepeater.DataBind();
        }

        protected void Sort_Click(object sender, EventArgs eventArgs)
        {
            _presenter.Sort(bool.Parse(sortedHiddenField.Value));
        }
    }
}