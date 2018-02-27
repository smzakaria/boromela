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

public partial class Corporate_ProductProfileAE : System.Web.UI.Page
{

    /// <summary>
    /// All products properties
    /// </summary>
    #region Product Properties
    
    //copied
    //public string GetSku
    //{
    //    get { return lblSku.Text; }
    //}
    private string strSubcategory = string.Empty;
    private string strCategory = string.Empty;
    private string strSecondSubcategory = string.Empty;
    private string strProductTitle = string.Empty;
    private string strInsertType = string.Empty;
    private string strSku = string.Empty;
    private string strProfileID = string.Empty;


    public string GetSku
    {
        get { return hfSku.Value; }
    }

    public string GetProfileID
    {
        get { return hfProfileID.Value; }
    }
    public string GetCategory
    {
        get { return hfCategory.Value; }
    }
    public string GetSubcategory
    {
        get { return hfSubcategory.Value; }
    }
    public string GetSecondSubcategory
    {
        get { return hfSecondSubcategory.Value; }
    }
    //copied
    public string GetProductTitle
    {
        get { return hfProductTitle.Value; }
    }

    public string GetDescription
    {
        get { return txtDescription.Text; }
    }

    public string GetQuantity
    {
        get { return txtQuantity.Text; }
    }

    public string GetProductPrice
    {
        get { return txtProductPrice.Text; }
    }

    public string GetCurrency
    {
        get { return ddlCurrency.SelectedItem.Text; }
    }

    public string GetSalePrice
    {
        get { return txtSalePrice.Text; }
    }

    public string GetSaleFromDate
    {
        get {return txtFromDate.Text;}
    }
    public string GetSaleTodate
    {
        get { return txtToDate.Text; }
    }

    public string GetCondition
    {
        get { return ddlCondition.SelectedItem.Value; }
    }
    public string GetConditionNote
    {
        get { return txtConditionNote.Text; }
    }
    //public string GetPaymentOption
    //{
    //    get { return hfPaymentOption.Value; }
    //}
    //public string GetDeliveryArea
    //{
    //    get { return hfDeliveryArea.Value; }
    //}
    //public string GetCodCost
    //{
    //    get { return hfCodCost.Value; }
    //}
    
    public string GetCategoryID
    {
        get { return hfCategoryID.Value; }
    }
    public string GetSubcategoryID
    {
        get { return hfSubcategoryID.Value; }
    }
    public string GetSecondSubcategoryID
    {
        get { return hfSecondSubcatID.Value; }
    }
    public string CanEditMasterRecord
    {
        get { return hfCanEdit.Value; }
    }

    /// <summary>
    /// If "master" then the Product is a new entry.
    /// If "tag" then the Product is a Tagged entry.
    /// </summary>
    public string GetInsertType
    {
        get { return hfInsertType.Value ; }
    }
    public string GetProductID
    {
        get { return hfProductID.Value; }
    }
    public string GetPageMode
    {
        get { return hfPageMode.Value; }
    }
    #endregion Product Properties



    /// <summary>
    /// Contains value "1", implies that its a master seller record.
    /// </summary>
    private string strEditable = "1";
    /// <summary>
    /// Contains value "0", implies that its a tag seller record.
    /// </summary>
    private string strNotEditable = "0";
    private string strSystemMessage = null;
    private int intPageMode = -1;
    //copied
    private int intProductID = -1;
    private int intCategoryID = -1;
    private int intSubcategoryID = -1;
    private int intSecondSubcatID = -1;
    private int intProfileID = -1;
    private int intCountryID = -1;


    string strDeliveryArea = "";

    private void CheckUserSession()
    {
        if (this.Session["CORP_PROFILE_CODE"] != null && this.Session["CORP_COUNTRY_CODE"] != null)
        {
            intProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"].ToString());
            intCountryID = Convert.ToInt32(this.Session["CORP_COUNTRY_CODE"].ToString());
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    private void CheckQueryString()
    {

        bool blnFlag = false;


        hfPageMode.Value = Request.QueryString["mode"];
        hfProductID.Value = Request.QueryString["pi"];
        hfCategoryID.Value = Request.QueryString["ci"];
        hfSubcategoryID.Value = Request.QueryString["sci"];
        hfSecondSubcatID.Value = Request.QueryString["ssci"];
        hfProfileID.Value = Request.QueryString["pfi"];
        hfSku.Value = Request.QueryString["sku"];
        hfInsertType.Value = Request.QueryString["inserttype"];
        hfProductTitle.Value = Server.UrlDecode( Request.QueryString["title"]);
        hfCategory.Value = Server.UrlDecode( Request.QueryString["c"]);
        hfSubcategory.Value = Server.UrlDecode( Request.QueryString["sc"]);
        hfSecondSubcategory.Value = Server.UrlDecode( Request.QueryString["ssc"]);

        if (string.IsNullOrEmpty(hfPageMode.Value) || !UTLUtilities.IsNumeric(hfPageMode.Value))
        {
            blnFlag = false;
        }
        else
        {
            if (hfPageMode.Value == "0" || hfPageMode.Value == "1")
            {
                if (hfCategoryID.Value == "-1" || hfSubcategoryID.Value == "-1" || hfSecondSubcatID.Value == "-1")
                {
                    blnFlag = false;
                }
                else
                {
                    blnFlag = Int32.TryParse(hfCategoryID.Value, out intCategoryID);
                    blnFlag = Int32.TryParse(hfSubcategoryID.Value, out intSubcategoryID) && blnFlag;
                    blnFlag = Int32.TryParse(hfPageMode.Value, out intPageMode) && blnFlag;
                    blnFlag = Int32.TryParse(hfSecondSubcatID.Value, out intSecondSubcatID) && blnFlag;
                    blnFlag = Int32.TryParse(hfProductID.Value, out intProductID) && blnFlag;
                }
            }
            else
            {
                blnFlag = false;
            }
        }

        if (blnFlag == false)
        {
            Response.Redirect("Default.aspx");
        }
    }

    private void SetNextPageUrl(string categoryID)
    {
        if (categoryID == "1")
        {
            btnNext.PostBackUrl = "~/Corporate/ProductProfile_BookAE.aspx";
        }
        if (categoryID == "2")
        {
            btnNext.PostBackUrl = "~/Corporate/ProductProfile_MobileDetailAE.aspx";
        }
        if (categoryID == "3")
        {
            btnNext.PostBackUrl = "~/Corporate/ProductProfile_CarsMotorCyclesDetailAE.aspx";
        }
        if (categoryID == "4")
        {
            btnNext.PostBackUrl = "~/Corporate/ProductProfile_ComputerLaptopAccessoriesSoftwareDetailAE.aspx";
        }

    }

    /// <summary>
    /// Selects Dropdownlists and fills out texboxes in case of editing. 
    /// </summary>
    private void SelectRecord_ProductProfile()
    {
        bool _BusinessSeller = true;
        try
        {
            using (BOC_Corporate_ProdProf_Book bocProductProfile = new BOC_Corporate_ProdProf_Book())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Business_ProductProfile_Books_ProductID = intProductID;
                eocPropertyBean.Business_UserProfile_ProfileID = intProfileID;
                eocPropertyBean.Category_CategoryID = intCategoryID;
                eocPropertyBean.Subcategory_SubcategoryID = intSubcategoryID;
                eocPropertyBean.SecondSubcategory_SubcategoryID = intSecondSubcatID;
                eocPropertyBean.UserType = _BusinessSeller.ToString();

                if (bocProductProfile.SelectRecord_General_BookProfile(eocPropertyBean))
                {
                    intCategoryID = eocPropertyBean.Category_CategoryID;

                    txtDescription.Text = eocPropertyBean.Business_ProductProfile_Books_BookDescription;
                    txtQuantity.Text = eocPropertyBean.Business_ProductProfile_Books_Quantity.ToString();
                    ddlCurrency.SelectedValue = eocPropertyBean.Business_ProductProfile_Books_Currency;
                    txtProductPrice.Text = eocPropertyBean.Business_ProductProfile_Books_ProductPrice.ToString();
                    if (eocPropertyBean.Business_ProductProfile_Books_SalePrice > 0)
                    {
                        chkSaleOffer.Checked = true;
                        panelSaleOffer.Enabled = true;
                        panelSaleOffer.Visible = true;
                        txtSalePrice.Text = eocPropertyBean.Business_ProductProfile_Books_SalePrice.ToString();
                        txtToDate.Text = eocPropertyBean.ToDate.ToString("d");
                        txtFromDate.Text = eocPropertyBean.FromDate.ToString("d");
                    }
                    else
                    {
                        chkSaleOffer.Checked = false;
                        panelSaleOffer.Enabled = false;
                        panelSaleOffer.Visible = false;
                    }
                    ddlCondition.SelectedValue = eocPropertyBean.Condition;
                    txtConditionNote.Text = eocPropertyBean.ConditionNote;
                    
                    hfCanEdit.Value = eocPropertyBean.CanEditProduct.ToString();
                }
                else
                {
                    strSystemMessage = "<table style='width:500px; border:1px dashed #666666;'>";
                    strSystemMessage += "<tr>";
                    strSystemMessage += "<td align='center' style='width:10%;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td>";
                    strSystemMessage += "<td valign='middle' style='width:90%;font-weight:bold; text-decoration:underline'>Following error occured :</td>";
                    strSystemMessage += "</tr>";

                    strSystemMessage += "<tr>";
                    strSystemMessage += "<td colspan='2' style='width:100%; color:#000000; padding-top:7px; padding-left:10px;'>";
                    strSystemMessage += "Product Profile not found!";
                    strSystemMessage += "<br/><br/>";
                    strSystemMessage += "<strong>How did this happen? </strong>";
                    strSystemMessage += "<ul>";
                    strSystemMessage += "<li>You login session may be expired.</li>";
                    strSystemMessage += "<li>Your Ad may be deleted by boromela authority for some reason.</li>";
                    strSystemMessage += "</ul>";
                    strSystemMessage += "</td>";
                    strSystemMessage += "</tr>";
                    strSystemMessage += "</table>";

                    lblSystemMessage.Text = strSystemMessage;
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void ddlCondition_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCondition.Text = (ddlCondition.SelectedItem.Value == "-1") ? "-" : ddlCondition.SelectedItem.Text;
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        UTLUtilities.CP_ActiveModule = 3;
        lblSystemMessage.Text = "";
        ddlCurrency.Enabled = false;

        if (!Page.IsPostBack)
        {
            this.CheckUserSession();
            this.CheckQueryString();
            ddlCurrency.SelectedValue = intCountryID == 18 ? "BDT." : "USD.";
            SetNextPageUrl(GetCategoryID);
            if (intPageMode == 1 && intProductID > 0)
            {
                this.SelectRecord_ProductProfile();

            }
        }
    }
    protected void chkSaleOffer_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSaleOffer.Checked)
        {
            
            panelSaleOffer.Visible = true;
            panelSaleOffer.Enabled = true;
        }
        else
        {
            txtSalePrice.Text = "";
            txtToDate.Text = "";
            txtFromDate.Text = "";
            panelSaleOffer.Visible = false;
            panelSaleOffer.Enabled = false;
        }
    }
}








