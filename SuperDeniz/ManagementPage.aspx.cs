using SuperDeniz.Modules;
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
    public partial class ManagementPage : System.Web.UI.Page
    {
        CoreLibrary coreLib;
        CorrectLibrary cl;
        ProductLibrary productLib;

        protected void Page_Load(object sender, EventArgs e)
        {
            coreLib = new CoreLibrary();
            cl = new CorrectLibrary();
            productLib = new ProductLibrary();

            if (IsPostBack) return;

            string actionType = Request["action"];
            clearInformationPanels();

            hideAllPanels();
            reload(actionType);
        }

        protected void hideAllPanels()
        {
            pnlProduct.Visible = false;
            pnlSearch.Visible = false;
            pnlVisitor.Visible = false;
            pnlProductView.Visible = false;
        }

        protected void reload(string _selectedKey)
        {
            try
            {
                if (_selectedKey == "product")
                {
                    pnlProduct.Visible = true;
                    populateProducts();
                }
                else if (_selectedKey == "search")
                {
                    pnlSearch.Visible = true;
                    string searchText = Request["searchText"];
                    ProductLibrary catLib = new ProductLibrary();
                    DataTable dt = catLib.getSearchedProduct(searchText);
                    rptUrunler.DataSource = dt;
                    rptUrunler.DataBind();
                    if (dt.Rows.Count == 0)
                    {
                        pnlErrorInformation.Visible = true;
                        lblErrorInformation.Text = "Arama kriterinize göre ürün bulunamadı";
                    }
                }
                else if (_selectedKey == "visitor")
                {
                    pnlVisitor.Visible = true;
                    populateVisitorData();
                }
                else if (_selectedKey == "productView")
                {
                    pnlProductView.Visible = true;
                    populateProductView();
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

        protected void populateProducts()
        {
            ProductLibrary catLib = new ProductLibrary();
            DataTable dt = catLib.getAllProducts();
            dlProducts.DataSource = dt;
            dlProducts.DataBind();
        }

        protected void populateVisitorData()
        {
            VisitorLibrary vLib = new VisitorLibrary();
            DataTable dt = vLib.showDailyVisitorCount();
            rptVisitor.DataSource = dt;
            rptVisitor.DataBind();
        }

        protected void populateProductView()
        {
            DataTable dt = productLib.getProductViewCount();
            rptProductView.DataSource = dt;
            rptProductView.DataBind();
        }

        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ProductLibrary proLib = new ProductLibrary();
                proLib.get(cl.getString(ViewState["productID"]));
                proLib.productCode = txtProductCode.Text;
                proLib.productName = txtProductName.Text;
                proLib.body = txtBody.Text;
                proLib.reflector = txtReflector.Text;
                proLib.socket = txtSocket.Text;
                proLib.paint = txtStain.Text;
                proLib.gasket = txtGasket.Text;
                proLib.glass = txtGlass.Text;
                proLib.weight = txtWeight.Text;
                proLib.size = txtSize.Text;
                proLib.deep = txtDeep.Text;
                string control = proLib.save();
                if (control != null)
                {
                    pnlErrorInformation.Visible = true;
                    lblErrorInformation.Text = control;
                }
                else
                {
                    pnlSuccessInformation.Visible = true;
                    lblSuccessInformation.Text = "Bilgiler Başarıyla Güncellendi";
                }
            }
            catch (Exception _ex)
            {
                pnlErrorInformation.Visible = true;
                lblErrorInformation.Text = _ex.ToString();
            }
        }

        protected void dlProducts_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                clearInformationPanels();
                string productID = e.CommandArgument.ToString();
                if (e.CommandName == "btnEditProduct")
                {
                    ViewState["productID"] = productID;
                    productLib.get(productID);
                    txtProductCode.Enabled = false;
                    txtProductCode.Text = productLib.productCode;
                    txtProductName.Text = productLib.productName;
                    txtBody.Text = productLib.body;
                    txtReflector.Text = productLib.reflector;
                    txtSocket.Text = productLib.socket;
                    txtStain.Text = productLib.paint;
                    txtGasket.Text = productLib.gasket;
                    txtGlass.Text = productLib.glass;
                    txtWeight.Text = productLib.weight;
                    txtSize.Text = productLib.size;
                    txtDeep.Text = productLib.deep;
                }
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

        protected void btnShowDetail_Click(object sender, EventArgs e)
        {
            try
            {
                clearInformationPanels();
                ProductDetailModule pdm = (ProductDetailModule)Page.LoadControl("Modules/ProductDetailModule.ascx");
                Page.Controls.Add(pdm);
                pdm.reload(cl.getString(ViewState["productID"]));
            }
            catch (Exception _ex)
            {
                pnlErrorInformation.Visible = true;
                lblErrorInformation.Text = _ex.ToString();
            }
        }
    }
}