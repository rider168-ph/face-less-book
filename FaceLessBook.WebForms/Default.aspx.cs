using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FaceLessBook.Domain.Contracts.Services;
using Ninject;

namespace FaceLessBook.WebForms
{
    public partial class Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EMailSender.Send("test@test.com", "Hello Ninject!", "I have been injected...");
        }

        protected void lnkListFriends_Click(object sender, EventArgs e)
        {
            Response.Redirect("/member/ListFriends.aspx?sid=1");
        }
    }
}