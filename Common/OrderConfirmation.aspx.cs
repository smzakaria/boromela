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

public partial class Common_OrderConfirmation : System.Web.UI.Page
{
    private int intOrderID;
    private int intProfileID;
    private bool userType = false;
    private DataTable dtOrderedItems = null;
    private DataTable dtBuyerInformation = null;
    private bool success = false;
    private bool _BusinessUser = true;
    string strBuyerInfo = string.Empty;
    string strBuyerName = string.Empty;
    string strOrderID = string.Empty;
    string strProfileID = string.Empty;
    string strPaymentOption = string.Empty;
    string strTotalAmount = string.Empty;
    string strCurrency = string.Empty;
    bool blnFlag = false;


    /// <summary>
    /// Formats Shipping and Billing address of the buyer for display.
    /// Returns the Html string.
    /// </summary>
    /// <returns></returns>
    public string GetShipping_BillingAddress()
    {
        string strShippingAndBillingAddress = string.Empty;

        strShippingAndBillingAddress = "<table width=\"100%\" border=\"0px\" cellspacing=\"0px\" cellpadding=\"0px\" style=\"border-bottom:";
        strShippingAndBillingAddress += "1px solid #d5d5d5; margin-bottom:15px;\">";
        strShippingAndBillingAddress += "<tr>";
        strShippingAndBillingAddress += "<td width=\"3px\"><img src=\"http://www.boromela.com/images/title_bar_left.gif\" width=\"3px\"";
        strShippingAndBillingAddress += "height=\"28px\" alt=\"\" /></td>";

        strShippingAndBillingAddress += "<td width=\"600px\" style=\"background-image:url(http://www.boromela.com/images/title_bar_bg.gif);";
        strShippingAndBillingAddress += "background-repeat:repeat-x; padding-left:5px;\">";
        strShippingAndBillingAddress += "Buyer's Information";
        strShippingAndBillingAddress += "</td>";
        strShippingAndBillingAddress += "<td width=\"3px\"><img src=\"http://www.boromela.com/images/title_bar_right.gif\" width=\"3px\" ";
        strShippingAndBillingAddress += "height=\"28px\" alt=\"\" /></td>";
        strShippingAndBillingAddress += "<td align=\"right\">&nbsp;</td>";
        strShippingAndBillingAddress += "</tr>";
        strShippingAndBillingAddress += "</table>";

        strShippingAndBillingAddress += "<table id=\"AddressHeader\" width=\"100%\" border=\"0px\" cellpadding=\"0px\"";
        strShippingAndBillingAddress += "cellspacing=\"0px\" style=\"margin:0px 0px 20px 0px;background-color:#F5F5F7\">";
        strShippingAndBillingAddress += "<tr style=\"line-height:25px;\">";
        strShippingAndBillingAddress += "<th style=\"width:350px;background-color:#EFEFE2;text-align:left;\" >";
        strShippingAndBillingAddress += "<span>Shipping Address</span>";
        strShippingAndBillingAddress += "</th>";
        strShippingAndBillingAddress += "<th style=\"width:350px;background-color:#EFEFE2;text-align:left\">";
        strShippingAndBillingAddress += "<span>";
        strShippingAndBillingAddress += "Billing Address";
        strShippingAndBillingAddress += "</span>";
        strShippingAndBillingAddress += "</th>";
        strShippingAndBillingAddress += "</tr>";
        strShippingAndBillingAddress += "<tr>";
        strShippingAndBillingAddress += "<td style=\"width:350px;  padding:10px;text-align:left\" >";
        strShippingAndBillingAddress += strBuyerInfo;
        strShippingAndBillingAddress += "</td>";
        strShippingAndBillingAddress += "<td style=\"width:350px; padding:10px; text-align:left\">";
        strShippingAndBillingAddress += strBuyerInfo;
        strShippingAndBillingAddress += "</td>";
        strShippingAndBillingAddress += "</tr>";
        strShippingAndBillingAddress += "</table>";
        return strShippingAndBillingAddress;
 
    }


    /// <summary>
    /// Formats OrderID and PaymentOption for display as Html.
    /// Returns the Html string.
    /// </summary>
    /// <returns></returns>
    public string GetOrderID_PaymentOption()
    {
        string strOrderHeader = string.Empty;

        strOrderHeader = "<table width=\"100%\" border=\"0px\" cellspacing=\"0px\" cellpadding=\"0px\" style=\"border-bottom:";
        strOrderHeader += "1px solid #d5d5d5; margin:20px 0px 0px 0px;\">";
        strOrderHeader += "<tr>";
        strOrderHeader += "<td width=\"3px\"><img src=\"http://www.boromela.com/images/title_bar_left.gif\" width=\"3px\"";
        strOrderHeader += "height=\"28px\" alt=\"\" /></td>";

        strOrderHeader += "<td width=\"600px\" style=\"background-image:url(http://www.boromela.com/images/title_bar_bg.gif);";
        strOrderHeader += "background-repeat:repeat-x; padding-left:5px;\">";
        strOrderHeader += "Order Information";
        strOrderHeader += "</td>";
        strOrderHeader += "<td width=\"3px\"><img src=\"http://www.boromela.com/images/title_bar_right.gif\" width=\"3px\" ";
        strOrderHeader += "height=\"28px\" alt=\"\" /></td>";
        strOrderHeader += "<td align=\"right\">&nbsp;</td>";
        strOrderHeader += "</tr>";
        strOrderHeader += "</table>";


        strOrderHeader += "<table cellpadding=\"0px\" cellspacing=\"0px\" style=\"color:#000000; width:100%; margin:0px 0px 15px 0px;\" >";
        strOrderHeader += "<thead>";
        strOrderHeader += "<tr>";
        strOrderHeader += "<th style=\"text-align:center;\">&nbsp</th>";
        strOrderHeader += "</tr>";
        strOrderHeader += "</thead>";
        strOrderHeader += "<tbody style=\"background-color:#F5F5F7\">";
        strOrderHeader += "<tr>";
        strOrderHeader += "<td style=\"padding:5px 0px 0px 0px\">";
        strOrderHeader += "<strong style=\"font-family:Verdana; font-size:12px\"> Selected Payment Method: </strong>";
        strOrderHeader += lblPaymentOption.Text; ;
        strOrderHeader += "</td>";
        strOrderHeader += "</tr>";
        strOrderHeader += "<tr>";
        strOrderHeader += "<td style=\"padding:5px 0px 5px 0px\">";
        strOrderHeader += "<strong style=\"font-family:Verdana; font-size:12px\"> Order No: </strong>";
        strOrderHeader += lblOrderNo.Text;
        strOrderHeader += "</td>";
        strOrderHeader += "</tr>";
        strOrderHeader += "</tbody>";
        strOrderHeader += "</table>";
        return strOrderHeader;
    }

    /// <summary>
    /// Formats the Order Detail table Header.
    /// Returns the Html as string.
    /// </summary>
    /// <returns></returns>
    public string GetOrderDetail_Header()
    {
        string strOrderDetailHeader = string.Empty;
        strOrderDetailHeader = "<table width=\"100%\" border=\"0px\" cellspacing=\"0px\" cellpadding=\"0px\" style=\"border-bottom:";
        strOrderDetailHeader += "1px solid #d5d5d5; margin-bottom:15px;\">";
        strOrderDetailHeader += "<tr>";
        strOrderDetailHeader += "<td width=\"3px\"><img src=\"http://www.boromela.com/images/title_bar_left.gif\" width=\"3px\"";
        strOrderDetailHeader += "height=\"28px\" alt=\"\" /></td>";

        strOrderDetailHeader += "<td width=\"600px\" style=\"background-image:url(http://www.boromela.com/images/title_bar_bg.gif);"; 
        strOrderDetailHeader += "background-repeat:repeat-x; padding-left:5px;\">";
        strOrderDetailHeader += "Ordered Items";
        strOrderDetailHeader += "</td>";
        strOrderDetailHeader += "<td width=\"3px\"><img src=\"http://www.boromela.com/images/title_bar_right.gif\" width=\"3px\" ";
        strOrderDetailHeader += "height=\"28px\" alt=\"\" /></td>";
        strOrderDetailHeader += "<td align=\"right\">&nbsp;</td>";
        strOrderDetailHeader += "</tr>";
        strOrderDetailHeader += "</table>";

        strOrderDetailHeader += "<table id=\"OrderListHeader\"  style=\"width:100%;margin-top:0px;color:black;";
        strOrderDetailHeader += "background-color:#EFEFE2\"  cellspacing=\"0px\" cellpadding=\"0px\" border=\"0px\">";
        strOrderDetailHeader += "<thead>";
        strOrderDetailHeader += "<tr style=\"text-align:left;line-height:25px\">";
        strOrderDetailHeader += "<th style=\"width:200px; \">Product Name</th>";
        strOrderDetailHeader += "<th style=\"width:80px;\">Price</th>";
        strOrderDetailHeader += "<th style=\"width:80px;\">Currency</th>";
        strOrderDetailHeader += "<th style=\"width:80px; \">Quantity</th>";
        strOrderDetailHeader += "<th style=\"width:90px;\">Subtotal</th>";
        strOrderDetailHeader += "<th style=\"font-weight:bold;\">Seller</th>";
        strOrderDetailHeader += "</tr>";
        strOrderDetailHeader += "</thead>";
        strOrderDetailHeader += "</table>";
        return strOrderDetailHeader;
    }

    private string MailLogoHeader()
    {
        string strHtml = string.Empty;
        strHtml = "<table width=\"800px\" border=1px solid #C3C1C1 align=\"center\" cellpadding=\"5px\" cellspacing=\"0px\">";
        strHtml += "<tr><td>";
        //strHtml += "<a color=\"white\" href=\"http://www.boromela.com\">";
        strHtml += "<img src=\"http://www.boromela.com/images/logo.gif\" width=\"260px\" height=\"91\" alt=\"\" />";
        //strHtml += "</a>";
        strHtml += "</td></tr><tr><td style=\"background-color:#3B5998;border:none;font-weight:bold; color: white\">";
        strHtml += "Boromela Sales Team.</td></tr><tr><td>";
        return strHtml;
    }

    public void SendSeller_ConfirmationMail(int intItemIndex)
    {
        string mailMessage = string.Empty;
        string mailFrom = "sales@boromela.com";
        string mailTo = dtOrderedItems.Rows[intItemIndex]["LoginEmail"].ToString();
        string mailSubject = "Order No: "+ strOrderID;
        mailMessage = MailLogoHeader();
        mailMessage += "<div style=\"color:#000000; line-height:18px\">Dear <strong>Mr./Mrs " + dtOrderedItems.Rows[intItemIndex]["UserName"].ToString() + "</strong>,<br/>";
        mailMessage += "One of our registered user <strong style=\"font-family:Verdana;font-size:12px\">Mr. ";
        mailMessage += strBuyerName + "</strong> has bought ";
        mailMessage += "<strong style=\"font-family:Verdana;font-size:12px\">";
        mailMessage +=  dtOrderedItems.Rows[intItemIndex]["Quantity"].ToString() + "</strong> pcs of ";
        mailMessage += "<strong style=\"font-family:Verdana;font-size:12px\">" + dtOrderedItems.Rows[intItemIndex]["Producttitle"].ToString();
        mailMessage += "</strong>.<br/>";
        mailMessage += "Buyer's shipping address and other order related information has been given below.<br/>";
        mailMessage += "Please take necessary steps to supply the order or you can also contact the buyer.<br/>Thanks<br/>";
        mailMessage += "<strong style=\"font-family:verdana;color:red;Verdana;font-size:12px\">BoroMela </strong> on behalf of Buyer.</div>";

        mailMessage += GetOrderID_PaymentOption();
        mailMessage += GetShipping_BillingAddress();

        mailMessage += GetOrderDetail_Header();
        mailMessage += "<table id=\"OrderList\" style=\"width:100%; color:#000000; \"";
        mailMessage += "cellspacing=\"0px\"  cellpadding=\"0px\">";

        mailMessage += "<tr style=\"vertical-align:top;\">";
        mailMessage += "<td  style=\"width:190px; padding:5px\">" + dtOrderedItems.Rows[intItemIndex]["ProductTitle"].ToString() + "</td>";
        mailMessage += "<td  style=\"width:70px; padding:5px\">" + dtOrderedItems.Rows[intItemIndex]["Price"].ToString() + "</td>";
        mailMessage += "<td  style=\"width:70px; padding:5px\">" + dtOrderedItems.Rows[intItemIndex]["Currency"].ToString() + "</td>";
        mailMessage += "<td  style=\"width:70px; padding:5px\">" + dtOrderedItems.Rows[intItemIndex]["Quantity"].ToString() + "</td>";
        mailMessage += "<td  style=\"width:80px; padding:5px\">" + dtOrderedItems.Rows[intItemIndex]["Subtotal"].ToString() + "</td>";


        mailMessage += "<td class=\"columnheader\" style=\"font-weight:normal; padding:5px; line-height:18px;\">";
        mailMessage += "<strong style=\"font-size:12px;font-family:verdana\">Company/User Name: </strong>" + dtOrderedItems.Rows[intItemIndex]["SellerInfo"].ToString() + "</br>";
        mailMessage += "<strong style=\"font-size:12px;font-family:verdana\">Seller Name: </strong>" + dtOrderedItems.Rows[intItemIndex]["UserName"].ToString() + "<br /> ";
        mailMessage += "<strong style=\"font-size:12px;font-family:verdana\">Website Url: </strong>" + dtOrderedItems.Rows[intItemIndex]["URL"].ToString() + "<br />";

        mailMessage += "<strong style=\"font-size:12px;font-family:verdana\">Cell No: </strong>" + dtOrderedItems.Rows[intItemIndex]["CellNo"].ToString() + "<br/>";
        mailMessage += "<strong style=\"font-size:12px;font-family:verdana\">User Address: </strong>" + dtOrderedItems.Rows[intItemIndex]["UserAddress"].ToString() + "<br />";
        mailMessage += dtOrderedItems.Rows[intItemIndex]["State"].ToString() + ", " + dtOrderedItems.Rows[intItemIndex]["Province"].ToString() + ", ";
        mailMessage += dtOrderedItems.Rows[intItemIndex]["Country"].ToString();

        mailMessage += "</td></tr>";
        //mailMessage += "<tr><td colspan=\"6\" style=\"text-align:center;line-height:25px\">";
        //mailMessage += "<span style=\"color:#990000;font-weight:bold;font-family:verdana;\">";
        //mailMessage += "Total Amount: " + strTotalAmount + " " + strCurrency + "</span>";
        //mailMessage += "</td></tr>";
        mailMessage += "</table></div>";
        mailMessage += "<div align=\"center\" style=\"color:red; margin-top:15px; font-weight:bold\">This is an auto generated mail. Please do not reply.</div>";

        mailMessage += "</td></tr></table>";
        MailMaster.SendMail(mailTo, mailFrom, mailSubject, mailMessage);
        //Label3.Text = mailMessage;
    }



    /// <summary>
    /// Sends buyer a confirmation mail, with all the ordered Product and Seller information.
    /// </summary>
    public void SendBuyer_ConfirmationMail()
    {
        string mailMessage = string.Empty;
        string mailFrom = "support@boromela.com";
        string mailTo = dtBuyerInformation.Rows[0]["LoginEmail"].ToString();
        string mailSubject = "Your Ordered Product Details";

        mailMessage = MailLogoHeader();
        mailMessage += "<div style=\"color:#000000; line-height:18px\">Dear <strong>Mr./Mrs. " + strBuyerName + "</strong>,<br/>Thank you for your order at BoroMela.com. This is a confirmation of your order.";
        mailMessage += "We will notify you as ";
        mailMessage += "soon as we ship your product.<br/> Thanks again.<br/>";
        mailMessage += "<strong style=\"font-family:Verdana;color:red; font-size:12px\">BoroMela </strong> on behalf of Seller(s)";

        mailMessage += GetOrderID_PaymentOption();

        mailMessage += GetShipping_BillingAddress();

        mailMessage += GetOrderDetail_Header();


        if (dtOrderedItems.Rows.Count > 0)
        {
            
            mailMessage += "<table id=\"OrderList\" style=\"width:100%; color:#000000; border:0px solid #EFEFE2\"";
            mailMessage += "cellspacing=\"0px\"  cellpadding=\"0px\">";
            for (int index = 0; index < dtOrderedItems.Rows.Count; index++)
            {
                string strBackgroundColor = "";
                if (index % 2 == 1)
                {
                    strBackgroundColor = "#F5F5F7";
                }
                else
                {
                    strBackgroundColor = "white";
                }
                mailMessage += "<tr style=\"vertical-align:top; background-color:" + strBackgroundColor + "\">";
                mailMessage += "<td  style=\"width:190px;padding:5px\">" + dtOrderedItems.Rows[index]["ProductTitle"].ToString() + "</td>";
                mailMessage += "<td  style=\"width:70px;padding:5px\">" + dtOrderedItems.Rows[index]["Price"].ToString() + "</td>";
                mailMessage += "<td  style=\"width:70px;padding:5px\">" + dtOrderedItems.Rows[index]["Currency"].ToString() + "</td>";
                mailMessage += "<td  style=\"width:70px;padding:5px\">" + dtOrderedItems.Rows[index]["Quantity"].ToString() + "</td>";
                mailMessage += "<td  style=\"width:80px;padding:5px\">" + dtOrderedItems.Rows[index]["Subtotal"].ToString() + "</td>";


                mailMessage += "<td class=\"columnheader\" style=\"font-weight:normal;padding:5px; line-height:17px;\">";
                mailMessage += "<strong style=\"font-size:12px;font-family:verdana\">Company/User Name: </strong>" + dtOrderedItems.Rows[index]["SellerInfo"].ToString() + "<br/>";
                mailMessage += "<strong style=\"font-size:12px;font-family:verdana\">Seller Name: </strong>" + dtOrderedItems.Rows[index]["UserName"].ToString() + "<br /> ";
                mailMessage += "<strong style=\"font-size:12px;font-family:verdana\">Website Url: </strong>" + dtOrderedItems.Rows[index]["URL"].ToString() + "<br />";

                mailMessage += "<strong style=\"font-size:12px;font-family:verdana\">Cell No: </strong>" + dtOrderedItems.Rows[index]["CellNo"].ToString() + "<br/>";
                mailMessage += "<strong style=\"font-size:12px;font-family:verdana\">User Address: </strong>" + dtOrderedItems.Rows[index]["UserAddress"].ToString() + "<br />";
                mailMessage += dtOrderedItems.Rows[index]["State"].ToString() + ", " + dtOrderedItems.Rows[index]["Province"].ToString() + ", ";
                mailMessage += dtOrderedItems.Rows[index]["Country"].ToString();

            }
            mailMessage += "</td></tr>";
            mailMessage += "<tr><td colspan=\"6\" style=\"text-align:center;line-height:25px\">";
            mailMessage += "<span style=\"color:#990000;font-weight:bold;font-family:verdana;\">";
            mailMessage += "Total Amount: " + strTotalAmount + " " + strCurrency + "</span>";
            mailMessage += "</td></tr>";
            mailMessage += "</table></div>";
            mailMessage += "<div align=\"center\" style=\"color:red; margin-top:15px; font-weight:bold\">This is an auto generated mail. Please do not reply.</div>";
        }
        mailMessage += "</td></tr></table>";
        //Label3.Text = mailMessage;
        MailMaster.SendMail(mailTo, mailFrom, mailSubject, mailMessage);

    }


    /// <summary>
    /// Loads Buyer's Ordered item's with related Seller's information.
    /// </summary>
    private void PopulateControls()
    {
        try
        {
            using (BC_Product bcProduct= new BC_Product())
            {
                dtOrderedItems = new DataTable();
                dtOrderedItems = bcProduct.LoadList_Product_Seller_Information(intOrderID);
                if(dtOrderedItems.Rows.Count > 0)
                {
                    lblTotalAmount.Text = string.Empty;
                    lblTotalAmount.Text = "<span class=\"price\">";
                    lblTotalAmount.Text += dtOrderedItems.Rows[0]["TotalAmount"].ToString();
                    lblTotalAmount.Text += "</span>";
                    lblCurrency.Text = string.Empty;
                    lblCurrency.Text = "<span class=\"price\">";
                    lblCurrency.Text += dtOrderedItems.Rows[0]["Currency"].ToString();
                    lblCurrency.Text += "</span>";
                    success = true;
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
    /// Loads Buyers information.
    /// </summary>
    /// <param name="intProfleID"></param>
    /// <param name="userType"></param>
    private void LoadRecord_Buyer_Information(int intProfileID, bool userType)
    {
        
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                dtBuyerInformation = bcProduct.LoadProduct_Buyer_Information(intProfileID, userType);
                if (dtBuyerInformation.Rows.Count > 0)
                {
                    strBuyerInfo = string.Empty;
                    strBuyerName = dtBuyerInformation.Rows[0]["UserName"].ToString();

                    strBuyerInfo += "Dear " + dtBuyerInformation.Rows[0]["UserName"].ToString() + "," ;
                    lblBuyer.Text = strBuyerInfo;

                    strBuyerInfo = string.Empty;

                    strBuyerInfo += "<div style=\"line-height:18px;color:#000000\">";
                    if (userType == _BusinessUser)
                    {
                        strBuyerInfo += "<strong style=\"font-size:12px;font-family:verdana\">Company Name: </strong>";
                    }
                    else
                    {
                        strBuyerInfo += "<strong style=\"font-size:12px;font-family:verdana\">Name: </strong>";
                    }

                    strBuyerInfo += dtBuyerInformation.Rows[0]["SellerInfo"].ToString() + "<br/>";

                    if (userType == _BusinessUser)
                    {
                        strBuyerInfo += "<strong style=\"font-size:12px;font-family:verdana\">Name: </strong>";
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

                    lblShippingAddress.Text = strBuyerInfo;
                    lblBillingAddress.Text = strBuyerInfo;


                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = "Error: " + ex.Message;
        }
    }


    private void CheckQueryString()
    {
        try 
        {
            if (Request.QueryString["data"] != null)
            {
                string strEncryptedUrl = Request.QueryString["data"].ToString();
                string strDecryptedUrl = UTLUtilities.Decrypt(strEncryptedUrl);
                string[] strSplitUrl = strDecryptedUrl.Split('&', '=');
                strOrderID = strSplitUrl[1];
                strProfileID = strSplitUrl[3];
                userType = strSplitUrl[5] == "BS" ? true : false; ;
                strPaymentOption = strSplitUrl[7];
                //strPaymentOption = Server.UrlDecode(strSplitUrl[7]);
                strTotalAmount = strSplitUrl[9];
                strCurrency = strSplitUrl[11];
            }
            //strOrderID = Request.QueryString["oi"];
            //strProfileID = Request.QueryString["pfi"];
            //strPaymentOption = Server.UrlDecode(Request.QueryString["po"]);
            //strTotalAmount = Request.QueryString["total"];
            //strCurrency = Request.QueryString["curr"];
            //userType = Request.QueryString["ut"].ToString() == "BS" ? true : false;
            if (!string.IsNullOrEmpty(strOrderID) || !UTLUtilities.IsNumeric(strOrderID))
            {
                blnFlag = true;
            }
            else
            {
                blnFlag = false;
            }
        }
        catch(Exception ex)
        {
            lblSystemMessage.Text = "Error: " + ex.Message;
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {
                this.CheckQueryString();
                if (blnFlag)
                {
                    if (Int32.TryParse(strOrderID, out intOrderID) && Int32.TryParse(strProfileID, out intProfileID))
                    {
                        this.PopulateControls();
                        if (success)
                        {
                            this.LoadRecord_Buyer_Information(intProfileID, userType);
                            lblPaymentOption.Text = "<strong style=\"font-size:12px;font-family:verdana; color:#990000\">";
                            lblPaymentOption.Text += strPaymentOption + "</strong>";

                            lblOrderNo.Text = "<strong style=\"font-size:12px;font-family:verdana; color:#990000\">";
                            lblOrderNo.Text += strOrderID + "</strong>";
                            if (dtOrderedItems.Rows.Count > 0)
                            {
                                this.SendBuyer_ConfirmationMail();
                                for (int index = 0; index < dtOrderedItems.Rows.Count; index++)
                                {
                                    this.SendSeller_ConfirmationMail(index);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = "Error: Processing your Order." + ex.Message;
        }
    }
}

