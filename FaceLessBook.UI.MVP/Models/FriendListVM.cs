using System.Collections.Generic;
using FaceLessBook.Domain.Models;

namespace FaceLessBook.UI.MVP.Models
{
    public class FriendListVM : IViewModel
    {
        public string ViewTitle { get; set; }

        public bool IsSortAscending { get; set; }

        public IEnumerable<Friend> Friends { get; set; }
    }
}
