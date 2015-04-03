using System.Web;

namespace FaceLessBook.UI.MVP.Views
{
    public abstract class ViewBase : IView
    {
        /// <summary>
        /// All the Views should have this method
        /// </summary>
        /// <param name="error"></param>
        public abstract void ShowError(string error);

        /// <summary>
        /// The default implementation is for the Web
        /// In case for WinForm just pass-in the name of the Form and override the implementation
        /// </summary>
        /// <param name="url"></param>
        public virtual void Redirect(string url)
        {
            HttpContext.Current.Response.Redirect(url, true);
        }
    }
}
