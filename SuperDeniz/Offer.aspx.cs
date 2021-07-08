using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDeniz
{
    public partial class Offer : System.Web.UI.Page
    {
        CorrectLibrary cl;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cl = new CorrectLibrary();

                if (IsPostBack) return;
                clearInformationPanels();
            }
            catch (Exception _ex)
            {
                pnlErrorInformation.Visible = true;
                lblErrorInformation.Text = _ex.ToString();
            }
        }

        protected void clearInformationPanels()
        {
            pnlErrorInformation.Visible = false;
            pnlSuccessInformation.Visible = false;
            lblErrorInformation.Text = "";
            lblSuccessInformation.Text = "";
        }
    }
}