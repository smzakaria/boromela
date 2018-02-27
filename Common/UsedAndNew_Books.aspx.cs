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

public partial class Common_UsedAndNew_Books : System.Web.UI.Page
{
    
#region Common Property
    private string strProductSellerDetailID = string.Empty;
    private string strProductID = string.Empty;
    private DataTable dtMixedBookList = null;
    private DataTable dtNewBookList = null;
    private DataTable dtUsedBookList = null;
    private int intPageMode = -1;
    private int intCountryID = -1;
    private int intProductID = -1;
    private int intCategoryID = 1;
    private int intSubcategoryID = -1;
    private int intSecondSubcatID = -1;

    private string strProductTitle = string.Empty;
    private string strAuthor = string.Empty;
    private string strPageMode = string.Empty;
    private string strPID = string.Empty;
    private string strCID = string.Empty;
    private string strSCID = string.Empty;
    private string strSSCID = string.Empty;
    private string selectedLocation = string.Empty;


#endregion Common Property

    private void CheckUserSession()
    {
        if (Session["SELECTED_LOCATION"] != null)
        {
            this.selectedLocation = Session["SELECTED_LOCATION"].ToString();
            intCountryID = Convert.ToInt32(selectedLocation);
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }

    /// <summary>
    /// Checks the query string.
    /// </summary>
    /// <returns></returns>
    private void CheckQueryString()
    {
        bool blnFlag = false;

        strPageMode = Request.QueryString["PageMode"];
        strPID = Request.QueryString["PID"];
        strCID = Request.QueryString["CID"];
        strSCID = Request.QueryString["SCID"];
        strSSCID = Request.QueryString["SSCID"];

        if (string.IsNullOrEmpty(strPID) || string.IsNullOrEmpty(strCID) || string.IsNullOrEmpty(strSCID) || string.IsNullOrEmpty(strSSCID) || string.IsNullOrEmpty(strPageMode))
        {
            blnFlag = false;
        }
        else
        {
            if (Int32.TryParse(strPID, out intProductID) && Int32.TryParse(strCID, out intCategoryID) && 
                Int32.TryParse(strSCID, out intSubcategoryID) && Int32.TryParse(strSSCID, out intSecondSubcatID) && Int32.TryParse(strPageMode, out intPageMode))
            {
                blnFlag = true;
            }
            else
            {
                blnFlag = false;
            }
        }

        if (blnFlag == true)
        {
            imageLink.HRef = "~/Common/ItemDetail_Books.aspx?PageMode=0&PID=" + strPID;
            imageLink.HRef += "&CID=" + strCID + "&SCID=" + strSCID + "&SSCID=" + strSSCID;

            titleLink.HRef = "~/Common/ItemDetail_Books.aspx?PageMode=0&PID=" + strPID;
            titleLink.HRef += "&CID=" + strCID + "&SCID=" + strSCID + "&SSCID=" + strSSCID;
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }


    /// <summary>
    /// Loads Book Name, Author Highest and Lowest Price.
    /// </summary>
    private void LoadRecord_BookHeader()
    {
        DataTable dtBookHeader = new DataTable();
        bool success = false;
        try
        {
            using (BC_Book book = new BC_Book())
            {
                dtBookHeader = book.LoadRecord_BookHeader(intProductID, intCountryID, intCategoryID, intSubcategoryID, intSecondSubcatID);
                if (dtBookHeader.Rows.Count > 0)
                {
                    txtAuthor.Value = dtBookHeader.Rows[0]["Author"].ToString();
                    txtProductTitle.Value = dtBookHeader.Rows[0]["ProductTitle"].ToString();
                    txtNewMinPrice.Value = dtBookHeader.Rows[0]["NewMinPrice"].ToString();
                    txtUsedMinPrice.Value = dtBookHeader.Rows[0]["UsedMinPrice"].ToString();
                    txtCurrency.Value = dtBookHeader.Rows[0]["Currency"].ToString();
                    txtImagePath.Value = dtBookHeader.Rows[0]["ProductImage"].ToString();
                    txtDiscountPrice.Value = dtBookHeader.Rows[0]["DiscountPrice"].ToString();
                    success = true;
                }
                else 
                {
                    lblSystemMessage.Text = "Book title not found.";
                }

            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = "Error: " + ex.Message ;
        }
        if (success)
        {
            
            lblProductTitle.Text = "<div class=\"productTitle\"><span class=\"title\">";
            lblProductTitle.Text += txtProductTitle.Value + "</span><br/>";
            
            lblAuthor.Text = txtAuthor.Value + " (Author)</div>";

            lblNewMinPrice.Text = "<span class=\"price\">" + txtNewMinPrice.Value;
            lblNewMinPrice.Text += " " + txtCurrency.Value + "</span>";
            
            lblUsedMinPrice.Text = "<span class=\"price\">" + txtUsedMinPrice.Value;
            lblUsedMinPrice.Text += " " + txtCurrency.Value + "</span>";

            lblDiscountPrice.Text = "<span class=\"price\">";
            lblDiscountPrice.Text += txtDiscountPrice.Value + " " + txtCurrency.Value + "</span>";

            bookImage.ImageUrl = txtImagePath.Value;

        }
    }

    /// <summary>
    /// Loads all Book list(New&Used) for a specific ProductID.
    /// 
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    private void Load_BookList_MixedSeller(int intProductID, int intCountryID, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        //string strDiscountPrice = null;
        dtMixedBookList = new DataTable();
        AjaxControlToolkit.TabPanel tp = (AjaxControlToolkit.TabPanel)TabContainer.FindControl("tpAllItems");

        try
        {
            using (BC_Book bcBook = new BC_Book())
            {
                dtMixedBookList = bcBook.Load_BookList_MixedSeller(intProductID, intCountryID, intCategoryID, intSubcategoryID, intSecondSubcatID);
                if (dtMixedBookList.Rows.Count > 0)
                {
                    this.grvMixedBookList.DataSource = dtMixedBookList;
                    this.grvMixedBookList.DataBind();
                    tp.HeaderText = "<span style=\"font-family:verdana; font-weight:bold;font-size:14px\">All </span>("; 
                    tp.HeaderText += dtMixedBookList.Rows.Count + " from " + dtMixedBookList.Rows[0]["Price"].ToString();
                    tp.HeaderText += " " + dtMixedBookList.Rows[0]["Currency"].ToString() + ")";
                }
                else
                {
                    tp.HeaderText = "<span style=\"font-family:verdana; font-weight:bold;font-size:14px\">All </span>(0 item)";
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

    }

    /// <summary>
    /// Loads all New Book list for a specific ProductID.
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    private void Load_BookList_NewSeller(int intProductID, int intCountryID, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        dtNewBookList = new DataTable();
        AjaxControlToolkit.TabPanel tp = (AjaxControlToolkit.TabPanel)TabContainer.FindControl("tpNewItems");
        try
        {
            using (BC_Book bcBook = new BC_Book())
            {
                dtNewBookList = bcBook.Load_BookList_NewSeller(intProductID, intCountryID, intCategoryID, intSubcategoryID, intSecondSubcatID);
                if (dtNewBookList.Rows.Count > 0)
                {
                    this.grvNewBookList.DataSource = dtNewBookList;
                    this.grvNewBookList.DataBind();

                    tp.HeaderText = "<span style=\"font-family:verdana; font-weight:bold;font-size:14px\">New </span>(";
                    tp.HeaderText += dtNewBookList.Rows.Count + " from " + dtNewBookList.Rows[0]["Price"].ToString();
                    tp.HeaderText += " " + dtNewBookList.Rows[0]["Currency"].ToString() + ")";
                }
                else
                {
                    this.grvNewBookList.DataSource = null;
                    this.grvNewBookList.DataBind();
                    tp.HeaderText = "<span style=\"font-family:verdana; font-weight:bold;font-size:14px\">New </span>(0 item)";
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

    }

    /// <summary>
    /// Loads all Used Book list for a specific ProductID.
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    private void Load_BookList_UsedSeller(int intProductID, int intCountryID, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        dtUsedBookList = new DataTable();
        AjaxControlToolkit.TabPanel tp = (AjaxControlToolkit.TabPanel)TabContainer.FindControl("tpUsedItems");
        try
        {
            using (BC_Book bcBook = new BC_Book())
            {
                dtUsedBookList = bcBook.Load_BookList_UsedSeller(intProductID, intCountryID, intCategoryID, intSubcategoryID, intSecondSubcatID);
                if (dtUsedBookList.Rows.Count > 0)
                {
                    this.grvUsedBookList.DataSource = dtUsedBookList;
                    this.grvUsedBookList.DataBind();

                    tp.HeaderText = "<span style=\"font-family:verdana; font-weight:bold;font-size:14px\">Used </span>("; 
                    tp.HeaderText += dtUsedBookList.Rows.Count + " from " + dtUsedBookList.Rows[0]["Price"].ToString();
                    tp.HeaderText += " " + dtUsedBookList.Rows[0]["Currency"].ToString() + ")";
                }
                else
                {
                    this.grvUsedBookList.DataSource = null;
                    this.grvUsedBookList.DataBind();

                    tp.HeaderText = "<span style=\"font-family:verdana; font-weight:bold;font-size:14px\">Used </span>(0 item)";
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
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
                bool isAddedToCart = cart.ShoppingCart_AddItem(strProductSellerDetailID, intProductID, intCategoryID);
                if (isAddedToCart)
                {
                    strHtml = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%; margin-left:150px; background-color:#FFA500;\">";
                    strHtml += "<tr>";
                    strHtml += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    strHtml += "<span class=\"title\" style=\"font-size:14px;\">\"";
                    strHtml += txtProductTitle.Value + "\"</span> has been added to your cart.";
                    strHtml += "</td>";
                    strHtml += "</tr>";
                    strHtml += "</table>";
                    lblSystemMessage.Text = strHtml;
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        lblSystemMessage.Text = "";
        this.CheckUserSession();
        this.CheckQueryString();
        if (!Page.IsPostBack)
        {
            switch(intPageMode)
            {
                case 0:
                    {

                        TabContainer.ActiveTabIndex = 0;
                        break;
                    }
                case 1:
                    {
                        TabContainer.ActiveTabIndex = 1;
                        break;
                    }
                case 2:
                    {
                        TabContainer.ActiveTabIndex = 2;
                        break;
                    }
                default:
                    {
                        TabContainer.ActiveTabIndex = 0;
                        break;
                    }
                    
            }
            this.Load_BookList_MixedSeller(intProductID, intCountryID, intCategoryID, intSubcategoryID, intSecondSubcatID);
            this.Load_BookList_NewSeller(intProductID, intCountryID, intCategoryID, intSubcategoryID, intSecondSubcatID);
            this.Load_BookList_UsedSeller(intProductID, intCountryID, intCategoryID, intSubcategoryID, intSecondSubcatID);
            this.LoadRecord_BookHeader();
        }
    }

    protected void grvMixedBookList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        strProductSellerDetailID = grvMixedBookList.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[0].ToString();
        strProductID = grvMixedBookList.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[1].ToString();
        Int32.TryParse(strProductID, out intProductID);
        string cmdName = e.CommandName;
        if (cmdName == "AddToCart")
        {
            this.AddToCart(strProductSellerDetailID, intProductID, intCategoryID);
        }
    }

    protected void btnAddToCart_Click(object sender, EventArgs args)
    {
        //strProductSellerDetailID = 
        //this.AddToCart(
    }
    protected void grvNewBookList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        strProductSellerDetailID = grvNewBookList.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[0].ToString();
        strProductID = grvNewBookList.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[1].ToString();
        Int32.TryParse(strProductID, out intProductID);
        string cmdName = e.CommandName;
        if (cmdName == "AddToCart")
        {
            this.AddToCart(strProductSellerDetailID, intProductID, intCategoryID);
        }
    }
    protected void grvUsedBookList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        strProductSellerDetailID = grvUsedBookList.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[0].ToString();
        strProductID = grvUsedBookList.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[1].ToString();
        Int32.TryParse(strProductID, out intProductID);
        string cmdName = e.CommandName;
        if (cmdName == "AddToCart")
        {
            this.AddToCart(strProductSellerDetailID, intProductID, intCategoryID);
            
        }
    }
}


