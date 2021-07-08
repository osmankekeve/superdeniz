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
    public partial class Projektorler : System.Web.UI.Page
    {
        CorrectLibrary cl;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cl = new CorrectLibrary();

                if (IsPostBack) return;
                pnlErrorInformation.Visible = false;
                populateProducts();
                clearInformationPanels();
                populateCategoryData();
            }
            catch (Exception _ex)
            {
                pnlErrorInformation.Visible = true;
                lblErrorInformation.Text = _ex.ToString();
            }
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

        protected void populateProducts()
        {
            string categoryCode = Request["uid"];
            ProductLibrary catLib = new ProductLibrary();
            DataTable dt = catLib.getProductsByCategoryID(categoryCode);
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

        protected void populateCategoryData()
        {
            CategoryLibrary catLib = new CategoryLibrary();
            string categoryCode = Request["uid"];
            catLib.get(categoryCode);
            lblCategoryName.Text = catLib.categoryName.ToUpper();
        }
    }
}