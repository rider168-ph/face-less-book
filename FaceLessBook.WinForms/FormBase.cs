using System.Windows.Forms;
using FaceLessBook.Domain.Contracts.Commands;
using FaceLessBook.Domain.Contracts.Logger;
using FaceLessBook.Domain.Contracts.Services;
//using Microsoft.Practices.Unity;
using Ninject;

namespace FaceLessBook.WinForms
{
    public class FormBase : Form
    {

        //[Dependency]
        //public IEMailSender EMailSender { get; set; }

        //[Dependency]
        //public ILogger Logging { get; set; }

        //[Dependency]
        //public IFriendCommandFactory FriendCommandFactory { get; set; }

        [Inject]
        public IEMailSender EMailSender { get; set; }

        [Inject]
        public ILogger Logger { get; set; }

        [Inject]
        public IFriendCommandFactory FriendCommandFactory { get; set; }

        
    }
}
