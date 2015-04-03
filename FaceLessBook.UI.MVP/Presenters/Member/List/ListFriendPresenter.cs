using System.Collections.Generic;
using System.Linq;
using FaceLessBook.Domain.Contracts.Commands;
using FaceLessBook.Domain.Models;
using FaceLessBook.UI.MVP.Models;
using FaceLessBook.UI.MVP.Views.Member;

namespace FaceLessBook.UI.MVP.Presenters.Member.List
{
    public class ListFriendPresenter : IPresenter
    {
        //These fields will get the values from the injected parameters in constructor.
        //Mapping of the abstract and concrete types will be from Dependency Injection container.
        private readonly IFriendCommandFactory _commandFactory;
        private readonly IListFriendView _view;
        private readonly int _userId;

        public ListFriendPresenter(IFriendCommandFactory commandFactory, 
                                   IListFriendView view, 
                                   int userId)
        {
            _commandFactory = commandFactory;
            _view = view;
            _userId = userId;
        }

        public void Init()
        {
            var vm = GetViewModel();
            _view.Show(vm);
        }

        public void Sort(bool isAscending)
        {
            var vm = GetViewModel();

            vm.Friends = isAscending
                ? vm.Friends.OrderBy(f => f.FirstName).ThenBy(l => l.LastName).ToList()
                : vm.Friends.OrderByDescending(f => f.FirstName).ThenBy(l => l.LastName).ToList();
                
            vm.IsSortAscending = !isAscending;

            _view.Show(vm);
        }

        /// <summary>
        /// Assemble the ViewModel
        /// </summary>
        /// <returns></returns>
        private FriendListVM GetViewModel()
        {
            return new FriendListVM
            {
                ViewTitle = "List of Friends",
                IsSortAscending = true,
                Friends = ListFriends() //get the List of Friends from the Command Factory
            };
        }

        private IEnumerable<Friend> ListFriends()
        {
            var command = _commandFactory.CreateListFriendCommand();
            command.UserId = _userId;

            if (!command.Validate().IsValid)
            {
                _view.ShowError(command.Validate().GetAsMessage());
                return null;
            }

            command.Execute();

            return command.ListOFriends;
        }
    }
}
