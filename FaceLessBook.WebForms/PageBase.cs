using System.Web.UI;
using FaceLessBook.Domain.Contracts.Commands;
using FaceLessBook.Domain.Contracts.Logger;
using FaceLessBook.Domain.Contracts.Services;
using Ninject;

namespace FaceLessBook.WebForms
{
    /// <summary>
    /// Concrete implementations will be injected during runtime
    /// </summary>
    public class PageBase : Page
    {
        [Inject]
        public IEMailSender EMailSender { get; set; }

        [Inject]
        public ILogger Logger { get; set; }

        [Inject]
        public IFriendCommandFactory FriendCommandFactory { get; set; }
    }

}
 