using System;
using FaceLessBook.UI.MVP.Models;
using FaceLessBook.UI.MVP.Presenters.Member.List;
using FaceLessBook.UI.MVP.Views.Member;

namespace FaceLessBook.WinForms
{
    
    public partial class MainForm : FormBase, IListFriendView
    {
        private ListFriendPresenter _presenter;

        protected FriendListVM ViewModel { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        public void ShowError(string error)
        {
            lblError.Text = error;
        }

        public void Show(FriendListVM viewModel)
        {
            ViewModel = viewModel;

            titleLabel.Text = viewModel.ViewTitle;
            sortButton.Tag = viewModel.IsSortAscending;

            friendsListBox.DataSource = ViewModel.Friends;
            friendsListBox.DisplayMember = "FullName";
            friendsListBox.ValueMember = "Id";
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            _presenter.Sort((bool)sortButton.Tag);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int userId = 1;
            _presenter = new ListFriendPresenter(FriendCommandFactory, this, userId);
            _presenter.Init();
        }
    }
}
