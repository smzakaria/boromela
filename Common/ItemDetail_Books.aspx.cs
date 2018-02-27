using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Common_ItemDetail_Books : System.Web.UI.Page
{
    private DataTable dtBookRecord ;
    private string strProductSellerDetailID = string.Empty;
    private string strPageMode = string.Empty;
    private string strPID = string.Empty;
    private string strCID = string.Empty;
    private string strSCID = string.Empty;
    private string strSSCID = string.Empty;
    private string selectedLocation = string.Empty;
    private bool success = false;

    //private bool sellerType = false;
    private int intCountryID = -1;
    private int intProductID = -1;
    private int intProfileID = -1;
    private int intCategoryID = -1;
    private int intSubcategoryID = -1;
    private int intSecondSubcatID = -1;
    private int intPageMode = -1;
    private int intProductSellerDetailID = -1;
  

    public int SubcategoryID
    {
        get { return intSubcategoryID; }
    }
    public int SecondSubcatID
    {
        get { return intSecondSubcatID; }
    }
    public string Location
    {
        get
        {
            string strLocation = string.Empty;
            switch (selectedLocation)
            {
                case "18":
                    {
                        strLocation = "Bangladesh";
                        break;
                    }
                case "96":
                    {
                        strLocation = "India";
                        break;
                    }
            }
            return strLocation;
        }
    }


    /// <summary>
    /// Checks the query string.
    /// </summary>
    /// <returns></returns>
    private void CheckQueryString()
    {
        bool blnFlag = false;

        if (Request.QueryString["data"] != null)
        {
            string strEncryptedUrl = Request.QueryString["data"].ToString();
            string strDecryptedUrl = UTLUtilities.Decrypt(strEncryptedUrl);
            string[] strSplitUrl = strDecryptedUrl.Split('&', '=');
            //strUserType = strSplitUrl[1];

            strPageMode = strSplitUrl[1];
            strProductSellerDetailID = strSplitUrl[3];
            strPID = strSplitUrl[5];
            strCID = strSplitUrl[7];
            strSCID = strSplitUrl[9];
            strSSCID = strSplitUrl[11];
        }
        else
        {
            strPageMode = Request.QueryString["PageMode"];
            strPID = Request.QueryString["PID"];
            strCID = Request.QueryString["CID"];
            strSCID = Request.QueryString["SCID"];
            strSSCID = Request.QueryString["SSCID"];
            strProductSellerDetailID = Request.QueryString["PSID"];
        }


        if (Int32.TryParse(strPID, out intProductID) && Int32.TryParse(strCID, out intCategoryID) && Int32.TryParse(strSCID, out
            intSubcategoryID) && Int32.TryParse(strSSCID, out intSecondSubcatID) && Int32.TryParse(strPageMode, out intPageMode))
        {
            if (intPageMode == 0)
            {
                blnFlag = true;
            }
            if (intPageMode == 1)
            {
                if (Int32.TryParse(strProductSellerDetailID, out intProductSellerDetailID))
                {
                    blnFlag = true;
                }
                else
                {
                    blnFlag = false;
                }
            }
        }
        else
        {
            if (!blnFlag)
            {
                Response.Redirect("../Default.aspx");
            }
        }
    }

    private void CheckUserSession()
    {
        if (Session["SELECTED_LOCATION"] != null)
        {
            this.selectedLocation = Session["SELECTED_LOCATION"].ToString();
            //ddlLocation.SelectedValue = this.selectedLocation;
            intCountryID = Convert.ToInt32(selectedLocation);
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }


    /// <summary>
    /// Loads Only one Book record based on ProductSellerDetailID.
    /// </summary>
    /// <param name="intProductSellerDetailID"></param>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    private void LoadRecord_SpecificBook(int intProductSellerDetailID, int intProductID, int intCountryID, 
        int intCategoryID, int intSubcategoryID)
    {
        dtBookRecord = new DataTable();

        try
        {
            using (BC_Book bcBook = new BC_Book())
            {
                dtBookRecord = bcBook.LoadRecord_SpecificBook(intProductSellerDetailID, intProductID, 
                    intCountryID, intCategoryID, intSubcategoryID, intSecondSubcatID);
                if (dtBookRecord.Rows.Count > 0)
                {
                    success = true;
                    hfProductTitle.Value = dtBookRecord.Rows[0]["ProductTitle"].ToString();
                    fvBookDetail.DataSource = dtBookRecord;
                    fvBookDetail.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
        
    }

    /// <summary>
    /// Loads Lowest Priced Book detail record.
    /// Uses ProductID, CountryID, CategoryID, SubcategoryID and Minimum Price to load List.
    /// USP: USP_Common_ItemDetailBook_LoadBook_LowestPriced
    /// </summary>
    private void LoadBook_LowestPriced(int intProductID, int intCountryID, int intCategoryID, int intSubcategoryID)
    {
        //string strDiscountPrice = null;
        dtBookRecord = new DataTable();

        try
        {
            using (BC_Book bcBook = new BC_Book())
            {
                dtBookRecord = bcBook.LoadBook_LowestPriced(intProductID, intCountryID, intCategoryID, intSubcategoryID, intSecondSubcatID);
                if (dtBookRecord.Rows.Count > 0)
                {
                    success = true;
                    string str = dtBookRecord.Rows[0]["ProductImage"].ToString();
                    hfProductTitle.Value = dtBookRecord.Rows[0]["ProductTitle"].ToString();
                    fvBookDetail.DataSource = dtBookRecord;
                    fvBookDetail.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

    }


  
    /// <summary>
    /// Adds comments on book in ProductReview_Books table.
    /// USP: Previous: USP_CP_ProdReview_Books_InsertRecord
    /// USP: New: USP_Common_ItemDetail_InsertReview
    /// </summary>
    /// <param name="intProductSellerDetailID"></param>
    /// <param name="intProductID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="strCriticsName"></param>
    /// <param name="strReview"></param>
    /// <returns></returns>
    private int AddRecord_ProductReview(int intProductSellerDetailID, int intProductID, int intCategoryID, string strCriticsName, string strReview)
    {
        int intActionStatus = 0;

        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                intActionStatus = bcProduct.Insert_ProductReview(intProductSellerDetailID, intProductID, intCategoryID, strCriticsName, strReview);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionStatus;
    }


    /// <summary>
    /// Loads Product Review.
    /// USP: USP_Common_ItemDetail_LoadList_ProductReview
    /// </summary>
    /// <param name="intProfileID"></param>
    /// <param name="intProductID"></param>
    /// <param name="intCateogryID"></param>
    private void LoadRecord_ProductReview(int intProductSellerDetailID, int intProductID, int intCateogryID)
    {

        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {

                DataTable dtReview = bcProduct.LoadList_ProductReview(intProductSellerDetailID, intProductID, intCategoryID);
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                if (dtReview.Rows.Count > 0)
                {
                    Repeater1.DataSource = dtReview;
                    Repeater1.DataBind();
                }
            }

        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Formats the Price with two digit after decimal.
    /// </summary>
    /// <param name="objPrice"></param>
    /// <returns></returns>
    protected string Format_Double_Value(object objPrice)
    {
        double objDoublePrice = Convert.ToDouble(objPrice);
        string formatedPrice = objDoublePrice.ToString("#0.00");
        return formatedPrice;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        bool isCorrectUrl = true;
        this.CheckUserSession();
        try
        {
            this.CheckQueryString();
        }
        catch (FormatException frmExp)
        {
            lblSystemMessage.Text = "Error: Url has been modified. " + frmExp.Message;
            isCorrectUrl = false;
        }
        catch (Exception exp)
        {
            lblSystemMessage.Text = "Error: " + exp.Message;
            isCorrectUrl = false;
        }
        if (!Page.IsPostBack && isCorrectUrl)
        {
            switch (intPageMode)
            {
                case 0:
                    {
                        this.LoadBook_LowestPriced(intProductID, intCountryID, intCategoryID, intSubcategoryID);
                        break;
                    }
                case 1:
                    {
                        this.LoadRecord_SpecificBook(intProductSellerDetailID, intProductID, intCountryID, intCategoryID, intSubcategoryID);
                        break;
                    }
            }
            if (success)
            {
                Int32.TryParse(fvBookDetail.DataKey["ProductSellerDetailID"].ToString(), out intProductSellerDetailID);

                this.LoadRecord_ProductReview(intProductSellerDetailID, intProductID, intCategoryID);
            }
     
        }
    }
    //protected void fvBookDetail_PageIndexChanging(object sender, FormViewPageEventArgs e)
    //{
    //    try
    //    {
    //        //strPID = Request.QueryString["PID"];
    //        //strCID = Request.QueryString["CID"];
    //        //strSCID = Request.QueryString["SCID"];
    //        this.CheckQueryString();
    //        this.selectedLocation = Session["SELECTED_LOCATION"].ToString();
    //        intCountryID = Convert.ToInt32(selectedLocation);
    //        fvBookDetail.PageIndex = e.NewPageIndex;
          
    //        this.LoadList_Book(intProductID, intCountryID, intCategoryID, intSubcategoryID);

    //        Int32.TryParse(fvBookDetail.DataKey["ProductSellerDetailID"].ToString(), out intProductSellerDetailID);
    //        Int32.TryParse(fvBookDetail.DataKey["ProductID"].ToString(), out intProductID);

    //        this.LoadRecord_ProductReview(intProductSellerDetailID, intProductID, intCategoryID);

    //    }
    //    catch (Exception Exp)
    //    {
    //        lblSystemMessage.Text = Exp.Message.ToString();
    //    }
    //}

    /// <summary>
    /// Posts comments on a specific Book product.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPost_Click(object sender, EventArgs e)
    {

        Int32.TryParse(fvBookDetail.DataKey["ProductSellerDetailID"].ToString(), out intProductSellerDetailID);
        Int32.TryParse(fvBookDetail.DataKey["ProductID"].ToString(), out intProductID);
        //Int32.TryParse(fvBookDetail.DataKey["CategoryID"].ToString(), out intCategoryID);
        bool blnFlag = false;

        if (string.IsNullOrEmpty(txtCriticsName.Text) || string.IsNullOrEmpty(txtComments.Text))
        {
            blnFlag = false;

            if (string.IsNullOrEmpty(txtCriticsName.Text))
            {
                lblCriticsName.Text = "Name is required!";
            }

            if (string.IsNullOrEmpty(txtComments.Text))
            {
                lblComments.Text = "Comments is required!";
            }
        }
        else
        {
            blnFlag = true;
        }

        if (blnFlag == true)
        {
            int i = this.AddRecord_ProductReview(intProductSellerDetailID, intProductID, intCategoryID, txtCriticsName.Text, txtComments.Text);
            this.LoadBook_LowestPriced(intProductID, intCountryID, intCategoryID, intSubcategoryID);
            this.LoadRecord_ProductReview(intProductSellerDetailID, intProductID, intCategoryID);

            txtCriticsName.Text = "";
            txtComments.Text = "";
        }
    }
 

    /// <summary>
    /// Adds an item in the Shopping Cart.
    /// </summary>
    /// <param name="strProductSellerDetailID"></param>
    /// <param name="intProductID"></param>
    private void AddToCart(string strProductSellerDetailID, int intProductID, int intCategoryID)
    {
        string strHtml = string.Empty;
        try
        {
            using (ShoppingCartAccess cart = new ShoppingCartAccess())
            {
                bool isAddedToCart =  cart.ShoppingCart_AddItem(strProductSellerDetailID, intProductID, intCategoryID);
                if (isAddedToCart)
                {

                    strHtml = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%;margin-left:150px; background-color:#FFA500;\">";
                    strHtml += "<tr>";
                    strHtml += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    strHtml += "<span class=\"title\" style=\"font-size:14px;\">\"";
                    strHtml += hfProductTitle.Value + "\"</span> has been added to your cart.";
                    strHtml += "</td>";
                    strHtml += "</tr>";
                    strHtml += "</table>";
                    lblSystemMessage.Text = strHtml;
                    //lblSystemMessage.Text = "<span class=\"title\" style=\"font-size:13px;color:red\">\"";
                    //lblSystemMessage.Text +=  hfProductTitle.Value + "\"</span> has been added to your cart.";
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    protected void btnAddToCart_Click(object sender, EventArgs args)
    {
        strProductSellerDetailID = fvBookDetail.DataKey["ProductSellerDetailID"].ToString();
        this.AddToCart(strProductSellerDetailID, intProductID, intCategoryID);
        

    }
  
    
    protected void fvBookDetail_ItemCreated(object sender, EventArgs e)
    {
        Double DiscountPrice = -1;
        string str = fvBookDetail.DataKey["ProductSellerDetailID"].ToString();

        string strDiscountPrice = fvBookDetail.DataKey["DiscountPrice"].ToString();
        string strDisCountStartDate = fvBookDetail.DataKey["DisCountStartDate"].ToString();
        string strDisCountEndDate = fvBookDetail.DataKey["DisCountEndDate"].ToString();
        string strCurrency = fvBookDetail.DataKey["Currency"].ToString();
        bool success = Double.TryParse(strDiscountPrice, out DiscountPrice);


        if (fvBookDetail.CurrentMode == FormViewMode.ReadOnly && success && DiscountPrice > 0)
        {
            Label lblSaleOffer = (Label)fvBookDetail.Row.FindControl("lblSaleOffer");
            lblSaleOffer.Text = "<div style=\"line-height:20px\">";
            lblSaleOffer.Text += "<span style=\"font-family:Verdana; font-size:14px; font-weight:bold; color:red\">On Sale: ";
            lblSaleOffer.Text += strDiscountPrice + " " + strCurrency + "</span><br/>";
            lblSaleOffer.Text += "<strong>Offer valids from ";
            lblSaleOffer.Text +=  strDisCountStartDate + " to " + strDisCountEndDate + "</strong></div>";
        }
    }
}
