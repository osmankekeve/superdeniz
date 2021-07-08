using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDeniz
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        CoreLibrary coreLib;
        CorrectLibrary cl;

        protected void Page_Load(object sender, EventArgs e)
        {
            coreLib = new CoreLibrary();
            cl = new CorrectLibrary();
            if (IsPostBack)
            {
                return;
            }

            clearInformationPanels();

            if (coreLib.getConfigKey("isUseDeveloper") == "true")
            {
                UserLibrary uLib = new UserLibrary();
                string mailAddress = coreLib.getConfigKey("developerMailAddress");
                string password = coreLib.getConfigKey("developerPassword");
                if (uLib.isCustomerExistInSystem(mailAddress, password))
                {
                    uLib.getByMailAddress(mailAddress);
                    MyData.isSessionActive = true;
                    MyData.user.userCode = uLib.userCode;
                    MyData.user.userType = uLib.userType;
                    MyData.user.userName = uLib.userName;
                    MyData.user.mailAddress = uLib.mailAddress;
                    lblErrorInformation.Text = "Developer girişiniz başarıyla gerçekleşti";
                }
                else
                {
                    pnlErrorInformation.Visible = true;
                    lblErrorInformation.Text = "Developer girişiniz gerçekleşmedi";
                }
            }


            if (Session["basket"] == null)
            {
                Hashtable htBasket = new Hashtable();
                Session["basket"] = htBasket;
            }
            populateCategoies();
            //populateSimilarProducts();
            saveVisitor();
        }

        protected void btnShowBasket_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Basket.aspx");
            }
            catch (Exception)
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.TrimStart().TrimEnd();
                if (searchText == "")
                {

                }
                else
                {
                    Response.Redirect("ManagementPage.aspx?action=search&searchText=" + searchText + "");
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnSearchHeader_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchHeader.Text.TrimStart().TrimEnd();
                if (searchText == "")
                {

                }
                else
                {
                    Response.Redirect("ManagementPage.aspx?action=search&searchText=" + searchText + "");
                }
            }
            catch (Exception)
            {

            }
        }

        protected void populateCategoies()
        {
            CategoryLibrary catLib = new CategoryLibrary();
            DataTable dt = catLib.getCategories();
            rpCategory.DataSource = dt;
            rpCategory.DataBind();
        }

        protected void populateSimilarProducts()
        {
            ProductLibrary catLib = new ProductLibrary();
            DataTable dt = catLib.getIndexPageProducts();
            rptUrunler.DataSource = dt;
            rptUrunler.DataBind();
        }

        protected void clearInformationPanels()
        {
            pnlErrorInformation.Visible = false;
            pnlSuccessInformation.Visible = false;
            lblErrorInformation.Text = "";
            lblSuccessInformation.Text = "";
        }

        protected void saveVisitor()
        {
            VisitorLibrary vl = new VisitorLibrary();
            vl.visitorIP = coreLib.GetVisitorIPAddress();
            vl.insertDate = cl.getDateTimeNow();
            vl.save();
        }
    }
}