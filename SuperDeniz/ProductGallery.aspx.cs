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
    public partial class ProductGallery : System.Web.UI.Page
    {
        CorrectLibrary cl;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cl = new CorrectLibrary();

                if (IsPostBack) return;
                clearInformationPanels();
                populateProducts();
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

        protected void populateProducts()
        {
            ProductLibrary catLib = new ProductLibrary();
            DataTable dt = catLib.getProductsByCategoryID("");
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
    }
}