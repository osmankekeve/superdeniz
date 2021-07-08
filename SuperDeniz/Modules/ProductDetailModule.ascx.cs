using System;

namespace SuperDeniz.Modules
{
    public partial class ProductDetailModule : System.Web.UI.UserControl
    {
        CorrectLibrary cl;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cl = new CorrectLibrary();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void reload(string _productID)
        {
            ViewState["productID"] = _productID;
        }
    }
}