using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDeniz
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        ViewLibrary viewLib;
        CoreLibrary coreLib;
        CorrectLibrary cl;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                viewLib = new ViewLibrary();
                coreLib = new CoreLibrary();
                cl = new CorrectLibrary();

                if (IsPostBack) return;

                pnlErrorInformation.Visible = false;
                string productID = Request["pid"];
                reload(productID);
                clearInformationPanels();
            }
            catch (Exception _ex)
            {
                pnlErrorInformation.Visible = true;
                lblErrorInformation.Text = _ex.ToString();
            }
        }

        public void reload(string _productID)
        {
            ViewState["productID"] = _productID;
            populateProductDetail();
            populateDescriptions();
            populateProductImages();

        }

        protected void populateProductDetail()
        {
            string productID = cl.getString(ViewState["productID"]);
            ProductLibrary pLib = new ProductLibrary();
            pLib.get(productID);
            Session["selectedProduct"] = pLib;

            ViewLibrary vLib = new ViewLibrary();
            vLib.code = pLib.Code;
            vLib.IP = coreLib.GetVisitorIPAddress();
            vLib.insertDate = cl.getDateTimeNow();
            vLib.save();


            ProductLibrary proLib = new ProductLibrary();
            proLib.get(productID);
            lblProductCodeValue.Text = proLib.productCode;
            lblProductNameValue.Text = proLib.productName;
            lblBodyValue.Text = proLib.body;
            lblReflectorValue.Text = proLib.reflector;
            lblSocketValue.Text = proLib.socket;
            lblStainValue.Text = proLib.paint;
            lblContaValue.Text = proLib.gasket;
            lblGlassValue.Text = proLib.glass;
            lblWeightValue.Text = proLib.weight;
            lblSizeValue.Text = proLib.size;
            lblDeepValue.Text = proLib.deep;
            imgDownloadPdf.HRef = proLib.pdfPath;
            if (proLib.videoPath == "")
            {
                pnlVideo.Visible = false;
            }
            else
            {
                pnlVideo.Visible = true;
                myVideo.Src = proLib.videoPath;
                if (proLib.videoPath2 == "")
                {
                    myVideo2.Visible = false;
                }
                else
                {
                    myVideo2.Src = proLib.videoPath2;
                }
            }
            imgDownloadPdf.Visible = proLib.pdfPath != "";
        }

        protected void clearInformationPanels()
        {
            pnlErrorInformation.Visible = false;
            pnlSuccessInformation.Visible = false;
            lblErrorInformation.Text = "";
            lblSuccessInformation.Text = "";
        }

        protected void populateDescriptions()
        {
            string productID = cl.getString(ViewState["productID"]);
            UsingAreaLibrary catLib = new UsingAreaLibrary();
            ProductLibrary proLib = new ProductLibrary();
            proLib.get(productID);
            DataTable dt = catLib.getProductUsingArea(proLib.Code);
            dlDescriptions.DataSource = dt;
            dlDescriptions.DataBind();
        }

        protected void populateProductImages()
        {
            string productID = cl.getString(ViewState["productID"]);
            ProductLibrary pLib = new ProductLibrary();
            pLib.get(productID);

            ImagesLibrary imgLib = new ImagesLibrary();
            DataTable dtImages = imgLib.getProductImages(pLib.Code);

            if (dtImages.Rows[0] != null)
            {
                img1.Src = dtImages.Rows[0]["imageUrl"].ToString();
            }
            else
            {
                img1.Visible = false;
            }

            if (dtImages.Rows[1] != null)
            {
                img2.Src = dtImages.Rows[1]["imageUrl"].ToString();
            }
            else
            {
                img2.Visible = false;
            }
            if (dtImages.Rows[2] != null)
            {
                img3.Src = dtImages.Rows[2]["imageUrl"].ToString();
            }
            else
            {
                img2.Visible = false;
            }

        }

        protected void btnDownloadImage_Click(object sender, EventArgs e)
        {
            try
            {
                ProductLibrary proLib = (ProductLibrary)Session["selectedProduct"];

                string url = coreLib.getConfigKey("pathOfAttachment") + proLib.imageUrl.Replace("/", "//");
                string uri = new Uri(url).LocalPath;
                Response.Clear();
                FileStream sourceFile = new FileStream(uri.ToString(), FileMode.Open);
                long FileSize = sourceFile.Length;
                byte[] getContent = new byte[(int)FileSize];
                sourceFile.Read(getContent, 0, (int)sourceFile.Length);
                sourceFile.Close();
                string[] uzanti = proLib.imageUrl.Split('.');
                Response.ContentType = "application/" + uzanti[uzanti.Length - 1];
                Response.AddHeader("content-disposition", "attachment; filename=\"" + proLib.imageUrl + "\"");
                Response.BinaryWrite(getContent);
                Response.End();





                //    HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";
                //String Header = "Attachment; Filename=" + proLib.imageUrl.Replace("Images/","");
                //HttpContext.Current.Response.AppendHeader("Content-Disposition", Header);
                //System.IO.FileInfo Dfile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath(url));
                //HttpContext.Current.Response.WriteFile(Dfile.FullName);
                //HttpContext.Current.Response.End();
            }
            catch (Exception _ex)
            {
                pnlErrorInformation.Visible = true;
                lblErrorInformation.Text = _ex.ToString();
            }
        }

        protected void ibtnDownloadPDF_Click(object sender, ImageClickEventArgs e)
        {
            //using (WebClient client = new WebClient())
            //{
            //    client.DownloadFile(new Uri(url), @"c:\temp\image35.png");
            //    // OR 
            //    client.DownloadFileAsync(new Uri(url), @"c:\temp\image35.png");
            //}
            ProductLibrary pLib = new ProductLibrary();
            pLib.get(ViewState["productID"].ToString());


            string url = "http://localhost:1717/Documents/sd-1.pdf";
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            Bitmap bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save("Image1.png", ImageFormat.Png);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
        }
    }
}