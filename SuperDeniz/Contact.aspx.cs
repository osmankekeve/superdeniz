using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDeniz
{
    public partial class Contact : System.Web.UI.Page
    {
        CorrectLibrary cl;
        CoreLibrary coreLib;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cl = new CorrectLibrary();
                coreLib = new CoreLibrary();

                if (IsPostBack) return;
                clearInformationPanels();

                populateContactInformations();
            }
            catch (Exception _ex)
            {
                pnlErrorInformation.Visible = true;
                lblErrorInformation.Text = _ex.ToString();
            }
        }

        protected void populateContactInformations()
        {
            string companyCode = coreLib.getConfigKey("companyCode");
            CompanyLibrary compLib = new CompanyLibrary();
            compLib.get(companyCode);
            lblAddressValue.Text = compLib.companyAddress;
            lblPhone1Value.Text = compLib.companyPhone1;
            lblFaxValue.Text = compLib.companyFax;
            lblMailAddressValue.Text = compLib.companyMailAddress;
            lblWhatsUppNumberValue.Text = compLib.whatsAppNumber;
            lblTelegramNumberValue.Text = compLib.whatsAppNumber;
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