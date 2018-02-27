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

public partial class Common_PlaceOrder : System.Web.UI.Page
{
    #region Common Property

    string strBillingAddress = string.Empty;
    string strShippingAddress = string.Empty;
    string strCustomarEmail = string.Empty;
    string strCustomerName = string.Empty;

    private string strOrderID = string.Empty;
    private int intOrderID = -1;
    private int intProfileID = -1;
    private int intCountryID = -1;
    private string strUserType = string.Empty;
    private string strPaymentOption = string.Empty;
    private string strTotalAmount = string.Empty;
    private string strCurrency = string.Empty;
    private bool blnFlag = false;
    private DataTable dtBuyerInformation = null;
    DataTable dtOrderedItems;

    public string OrderID
    {
        get { return hfOrderID.Value; }
    }
    public string ProfileID
    {
        get { return hfProfileID.Value; }
    }
    public string UserType
    {
        get { return hfUserType.Value; }
    }
    public string PaymentOption
    {
        get { return hfPaymentOption.Value; }
    }
    public string TotalAmount
    {
        get { return hfTotalAmount.Value; }
    }
    public string Currency
    {
        get { return hfCurrency.Value; }
    }


    #endregion Common Property



    private void PopulateControls()
    {
        try
        {
            using (ShoppingCartAccess cart = new ShoppingCartAccess())
            {
                dtOrderedItems = new DataTable();
                dtOrderedItems = cart.LoadList_Ordered_Items(intOrderID);
                if (dtOrderedItems.Rows.Count > 0)
                {
                    hfTotalAmount.Value = dtOrderedItems.Rows[0]["TotalAmount"].ToString();
                    hfCurrency.Value = dtOrderedItems.Rows[0]["Currency"].ToString();

                    lblTotalAmount.Text = string.Empty;
                    lblTotalAmount.Text = "<span class=\"price\">";
                    lblTotalAmount.Text += dtOrderedItems.Rows[0]["TotalAmount"].ToString();
                    lblTotalAmount.Text += "</span>";

                    lblCurrency.Text = string.Empty;
                    lblCurrency.Text = "<span class=\"price\">";
                    lblCurrency.Text += dtOrderedItems.Rows[0]["Currency"].ToString();
                    lblCurrency.Text += "</span>";
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = "Error:" + ex.Message;
        }

        // if the shopping cart is empty...
        if (dtOrderedItems.Rows.Count == 0)
        {
            grvOrderedItems.Visible = false;
            lblTotalAmount.Text = "";
            lblCurrency.Text = "";
        }
        else
        {
            grvOrderedItems.DataSource = dtOrderedItems;
            grvOrderedItems.DataBind();
            grvOrderedItems.Visible = true;
        }
    }




    /// <summary>
    /// Checks the query string.
    /// </summary>
    /// <returns></returns>
    private void CheckQueryString()
    {
        if (Request.QueryString["data"] != null)
        {
            string strEncryptedUrl = Request.QueryString["data"].ToString();
            string strDecryptedUrl = UTLUtilities.Decrypt(strEncryptedUrl);
            string[] strSplitUrl = strDecryptedUrl.Split('&', '=');
            strUserType = strSplitUrl[1];
        }
        hfUserType.Value = strUserType;
        if (this.Session["PAYMENT_OPTION"] != null && this.Session["ORDER_ID"] != null)
        {
            strPaymentOption = this.Session["PAYMENT_OPTION"].ToString();
            hfPaymentOption.Value = strPaymentOption;
            strOrderID = this.Session["ORDER_ID"].ToString();
            blnFlag = Int32.TryParse(strOrderID, out intOrderID);

            hfOrderID.Value = strOrderID;
        }

        if (string.IsNullOrEmpty(strUserType) && string.IsNullOrEmpty(strPaymentOption) && blnFlag)
        {
            blnFlag = false;
        }
        else
        {
            if (strUserType == "BS" || strUserType == "CL")
            {
                blnFlag = true;
            }
            else
            {
                blnFlag = false;
            }
        }

        if (blnFlag == false)
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    private void CheckUserSession()
    {
        bool success = false;
        if (blnFlag)
        {
            if (strUserType == "BS")
            {
                if (this.Session["BS_ID"] != null )
                {
                    success = Int32.TryParse(this.Session["BS_ID"].ToString(), out intProfileID);
                }
            }
            else
            {
                if (this.Session["CL_ID"] != null)
                {
                    success = Int32.TryParse(this.Session["CL_ID"].ToString(), out intProfileID);
                }
            }
            hfProfileID.Value = intProfileID.ToString();
        }
        if (this.Session["COUNTRY_ID"] != null && success && blnFlag)
        {
            success = Int32.TryParse(this.Session["COUNTRY_ID"].ToString(), out intCountryID); ;
        }
        else
        {
            success = false;
        }
        if (!success)
        {
            Response.Redirect("~/Default.aspx");
        }
    }


    


    /// <summary>
    /// Loads Buyers information.
    /// </summary>
    /// <param name="intProfleID"></param>
    /// <param name="userType"></param>
    private void LoadRecord_Buyer_Information(int intProfileID, bool userType)
    {
        bool _BusinessUser = true;
        //bool _CL = false;

        string strBuyerInfo = string.Empty;
        dtBuyerInformation = new DataTable();
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                dtBuyerInformation = bcProduct.LoadProduct_Buyer_Information(intProfileID, userType);
                if (dtBuyerInformation.Rows.Count > 0)
                {
                    strBuyerInfo = string.Empty;

                    strBuyerInfo += "<div style=\"line-height:15px;color:#000000\">";
                    if (userType == _BusinessUser)
                    {
                        strBuyerInfo += "<strong style=\"font-size:12px;font-family:verdana\">Company Name: </strong>";
                    }
                    else
                    {
                        strBuyerInfo += "<strong style=\"font-size:12px;font-family:verdana\">Your Name: </strong>";
                    }

                    strBuyerInfo += dtBuyerInformation.Rows[0]["SellerInfo"].ToString() + "<br/>";

                    if (userType == _BusinessUser)
                    {
                        strBuyerInfo += "<strong style=\"font-size:12px;font-family:verdana\">User Name: </strong>";
                        strBuyerInfo += dtBuyerInformation.Rows[0]["UserName"].ToString() + "<br/>";
                    }


                    strBuyerInfo += "<strong style=\"font-size:12px;font-family:verdana\">Website: </strong>";
                    strBuyerInfo += dtBuyerInformation.Rows[0]["URL"].ToString() + "<br/>";

                    strBuyerInfo += "<strong style=\"font-size:12px;font-family:verdana\">Cell no: </strong>";
                    strBuyerInfo += dtBuyerInformation.Rows[0]["CellNo"].ToString() + "<br/>";

                    strBuyerInfo += "<strong style=\"font-size:12px;font-family:verdana\">Address: </strong>";
                    strBuyerInfo += dtBuyerInformation.Rows[0]["UserAddress"].ToString() + "<br/>";
                    strBuyerInfo += dtBuyerInformation.Rows[0]["Province"].ToString() + ", ";
                    strBuyerInfo += dtBuyerInformation.Rows[0]["State"].ToString() + ", ";
                    strBuyerInfo += dtBuyerInformation.Rows[0]["Country"].ToString() + ".<br/></div>";


                    strBillingAddress = dtBuyerInformation.Rows[0]["UserAddress"].ToString();
                    strBillingAddress += dtBuyerInformation.Rows[0]["Province"].ToString();
                    strBillingAddress += dtBuyerInformation.Rows[0]["State"].ToString();
                    strBillingAddress += dtBuyerInformation.Rows[0]["Country"].ToString();

                    //strShippingAddress = strBillingAddress;

                    strCustomarEmail = dtBuyerInformation.Rows[0]["LoginEmail"].ToString();
                    strCustomerName = dtBuyerInformation.Rows[0]["UserName"].ToString();

                    hfBillingAddress.Value = strBillingAddress;
                    hfShippingAddress.Value = strBillingAddress;
                    hfCustomerEmail.Value = strCustomarEmail;
                    hfCustomerName.Value = strCustomerName;

                    lblShippingAddress.Text = strBuyerInfo;
                    lblBillingAddress.Text = strBuyerInfo;

                }
                else
                {
                    string data = UTLUtilities.Encrypt("Error in processing your order. Please contact Boromela.com");
                    Response.Redirect("../Error.aspx?data=" + data, false);
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = "Error: " + ex.Message;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        bool businessUser = true;
        bool classifiedsUser = false;
        
        if (!Page.IsPostBack)
        {
            try
            {
                this.CheckQueryString();
                this.CheckUserSession();
                this.PopulateControls();
            }
            catch (FormatException fmExp)
            {
                string data = UTLUtilities.Encrypt("Url has been modified.");
                Response.Redirect("../Error.aspx?data=" + data, false);

            }
            catch (Exception ex)
            {
                lblSystemMessage.Text = "Error: " + ex.Message;

            }
            lblPaymentOption.Text = "<strong style=\"font-size:12px;font-family:verdana; color:#990000\">";
            lblPaymentOption.Text += strPaymentOption + "</strong>";
            switch (strUserType)
            {
                case "BS":
                    {
                        this.LoadRecord_Buyer_Information(intProfileID, businessUser);
                        break;
                    }
                case "CL":
                    {
                        this.LoadRecord_Buyer_Information(intProfileID, classifiedsUser);
                        break;
                    }
            }
            lblPaymentOption.Text = "<strong style=\"font-size:12px;font-family:verdana; color:#990000\">";
            lblPaymentOption.Text += strPaymentOption + "</strong>";
        }
    }

    protected void btnPlaceOrder_Click1(object sender, EventArgs e)
    {

        
       // this.LoadRecord_Buyer_Information(intProfileID, UserType);
        try
        {
            
            using (ShoppingCartAccess shoppingCart = new ShoppingCartAccess())
            {
                if (Int32.TryParse(hfOrderID.Value, out intOrderID))
                {
                    if (!shoppingCart.IsOrder_PlacedOnce(intOrderID))
                    {
                        if (shoppingCart.Verify_CustomerOrder(intOrderID,
                            hfCustomerName.Value, hfCustomerEmail.Value, hfShippingAddress.Value, hfBillingAddress.Value))
                        {
                            string strQueryString = "oi=" + hfOrderID.Value;
                            strQueryString += "&pfi=" + hfProfileID.Value;
                            strQueryString += "&ut=" + hfUserType.Value;
                            strQueryString += "&po=" + hfPaymentOption.Value;
                            //strQueryString += "&po=" + Server.UrlEncode(hfPaymentOption.Value);
                            strQueryString += "&total=" + hfTotalAmount.Value;
                            strQueryString += "&curr=" + hfCurrency.Value;

                            string strEncryptedUrl = UTLUtilities.Encrypt(strQueryString);
                            //string strDecryptedUrl =

                            Response.Redirect("OrderConfirmation.aspx?data=" + strEncryptedUrl, false);
                        }
                        else
                        {
                            lblSystemMessage.Text = "There were some errors processing your order. Please contact Boromela.";
                        }
                    }
                    else
                    {
                        string data = UTLUtilities.Encrypt("You may have already placed this order once.");
                        Response.Redirect("../Error.aspx?data=" + data, false);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = "Error: " + ex.Message;
        }
        

    }
}

