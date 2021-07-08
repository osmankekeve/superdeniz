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
    public partial class index : System.Web.UI.Page
    {
        LookUpsLibrary lul;
        ProductLibrary proLib;
        CorrectLibrary cl;
        CoreLibrary coreLib;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lul = new LookUpsLibrary();
                proLib = new ProductLibrary();
                cl = new CorrectLibrary();
                coreLib = new CoreLibrary();

                if (IsPostBack) return;

                pnlErrorInformation.Visible = false;
                populateProductDetail();
                clearInformationPanels();
                string IP = coreLib.GetVisitorIPAddress();
            }
            catch (Exception _ex)
            {
                pnlErrorInformation.Visible = true;
                lblErrorInformation.Text = _ex.ToString();
            }
        }

        protected void populateProductDetail()
        {
            ProductLibrary catLib = new ProductLibrary();
            DataTable dt = catLib.getIndexPageProducts();
            rptUrunler.DataSource = dt;
            rptUrunler.DataBind();

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected void rptUrunler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                clearInformationPanels();
                Hashtable htBasket = (Hashtable)Session["basket"];
                string id = e.CommandArgument.ToString();
                switch (e.CommandName)
                {
                    case "btnAddBasket":
                        {
                            cl.addToHashTable(htBasket, id, id);
                            Session["basket"] = htBasket;
                            lblSuccessInformation.Text = "Ürün başarıyla sepete eklendi";
                            pnlSuccessInformation.Visible = true;
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }
            }
            catch (Exception _ex)
            {
                pnlErrorInformation.Visible = true;
                lblErrorInformation.Text = _ex.ToString();
            }
        }

        protected void rptUrunler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (!MyData.isSessionActive)
                {
                    Button btnAddBasket = e.Item.FindControl("btnAddBasket") as Button;
                    btnAddBasket.Visible = false;
                }
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