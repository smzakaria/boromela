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

public partial class Common_ItemList_Books : System.Web.UI.Page
{
    #region Common Property

    DataTable dtBookList = null;

    int intPageMode = -1;
    int intCategoryID = -1;
    int intSubcategoryID = -1;



    private string strHtml = string.Empty;
    private string strCID = string.Empty;
    private string strSCID = string.Empty;
    private string strSSCID = string.Empty;

    private string selectedLocation = string.Empty;
    private string category = string.Empty;
    private string subcategory = string.Empty;
    private string author = string.Empty;
    private string strPublisher = string.Empty;
    private string strSecondSubcategory = string.Empty;

    private string location = string.Empty;
    private string customMessage = string.Empty;
    private string strPageMode = string.Empty;


    private int intCountryID = -1;
    private int intSecondSubcatID = -1;

    public string SecondSubcatID
    {
        get { return strSSCID; }
        set { strSSCID = value; }
    }


    public int CountryID
    {
        get { return intCountryID; }
        set { intCountryID = value; }
    }


    public string Author
    {
        get { return author; }
        set { author = value; }
    }


    public string CategoryID
    {
        get { return this.strCID; }
        set { this.strCID = value; }
    }

    public string Category
    {
        get { return this.category; }
        set { this.category = value; }
    }

    public string SubcategoryID
    {
        get { return this.strSCID; }
        set { this.strSCID = value; }
    }

    public string Subcategory
    {
        get
        {
            string strSubcategory = string.Empty;
            switch (intSubcategoryID)
            {
                case 2:
                    {
                        strSubcategory = "General Books";
                        break;
                    }
                case 1:
                    {
                        strSubcategory = "Text Books";
                        break;
                    }
            }
            return strSubcategory;
        }
    }

    public string Location
    {
        get { return this.location; }
        set { this.location = value; }
    }

    public string CustomMessage
    {
        get { return this.customMessage; }
        set { this.customMessage = value; }
    }
    #endregion Common Property


  

    /// <summary>
    /// Loads Latest posted Book list by Auhtor name.
    /// USP: USP_Common_ItemListBook_ShowLatestPostedBookList_ByAuthor
    /// </summary>
    /// <param name="author"></param>
    /// <param name="country"></param>
    /// <returns></returns>
    private void LoadList_LatestPosted_BookProduct_ByAuthor(string author, int country, int intSubcategory)
    {
        dtBookList = new DataTable();
        try
        {
            using (BC_Author bcAuthor = new BC_Author())
            {
                dtBookList = bcAuthor.LoadList_LatestPosted_BookProduct_ByAuthor(author, country, intSubcategoryID);
                if (dtBookList.Rows.Count > 0)
                {
                    grvItemList.DataSource = dtBookList;
                    grvItemList.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Loads all Latest posted Book by Subcategory.
    /// Uses Country to load Country specific list.
    /// USP: USP_Common_ItemListBook_ShowLatestPostedBookList
    /// </summary>
    private void LoadList_LatestPosted_BookProduct_BySubCategory(int intCountryID, int intSubcategoryID)
    {
        dtBookList = new DataTable();
        try
        {
            using (BC_Book bcBook = new BC_Book())
            {
                dtBookList = bcBook.LoadList_BookProduct_ByCategory(intCountryID, intSubcategoryID);
                if (dtBookList.Rows.Count > 0)
                {
                    grvItemList.DataSource = dtBookList;
                    grvItemList.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

    }

    /// <summary>
    /// Loads Latest posted Booklist in the Middle page gridview by SecondSubcatID.
    /// USP: USP_Common_ItemListBook_ShowLatestPostedBookList_BySecondSubcategory
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <param name="intSubcategoryID"></param>
    private void LoadList_LatestPosted_BookProduct_BySecondSubcategory(int intCountryID, int intSecondSubcatID)
    {
        dtBookList = new DataTable();
        try
        {
            using (BC_SecondSubcategory bcSecondSubcategory = new BC_SecondSubcategory())
            {
                dtBookList = bcSecondSubcategory.LoadList_BookProduct_BySecondSubcategory(intCountryID, intSecondSubcatID);
                if (dtBookList.Rows.Count > 0)
                {
                    grvItemList.DataSource = dtBookList;
                    grvItemList.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

    }


    /// <summary>
    /// Loads Latest posted Booklist in the Middle page gridview by Publisher name.
    /// USP: USP_Common_ItemListBook_ShowLatestPostedBookList_ByPublisher.sql
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <param name="intSecondSubcatID"></param>
    private void LoadList_LatestPosted_BookProduct_ByPublisher(int intCountryID, int intSubcategoryID, string publisher)
    {
        dtBookList = new DataTable();
        try
        {
            using (BC_Publisher bcPublisher = new BC_Publisher())
            {
                dtBookList = bcPublisher.LoadList_LatestPosted_BookProduct_ByPublisher(intCountryID, intSubcategoryID, publisher);
                if (dtBookList.Rows.Count > 0)
                {
                    grvItemList.DataSource = dtBookList;
                    grvItemList.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

    }


    private void CheckUserSession()
    {
        if (Session["SELECTED_LOCATION"] != null)
        {
            this.selectedLocation = Session["SELECTED_LOCATION"].ToString();
//            ddlLocation.SelectedValue = this.selectedLocation;
            intCountryID = Convert.ToInt32(selectedLocation);
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }

    /// <summary>
    /// Checks the query string and returns the pagemode.
    /// </summary>
    /// <returns></returns>
    private string CheckQueryString()
    {
        bool blnFlag = false;



        strPageMode = Request.QueryString["PageMode"];
        strCID = Request.QueryString["CID"];
        strSCID = Request.QueryString["SCID"];
        author = Request.QueryString["Author"];
        strSSCID = Request.QueryString["SSCID"];
        strPublisher = Request.QueryString["Publisher"];
        location = Request.QueryString["Location"];
        //string strSSCID = Request.QueryString["SSCID"];

        //TODO:
        //here we need to check the validation of Author and Publisher .
        if (string.IsNullOrEmpty(strPageMode) || string.IsNullOrEmpty(strCID) || string.IsNullOrEmpty(strSCID))
        {
            blnFlag = false;
        }
        else
        {
            if (strPageMode == "0" || strPageMode == "1" || strPageMode == "2" || strPageMode == "3")
            {

                if (strCID == "-1" || strSCID == "-1")
                {
                    blnFlag = false;
                }
                else if (UTLUtilities.IsNumeric(strCID) && UTLUtilities.IsNumeric(strSCID))
                {
                    blnFlag = true;
                }
                else
                {
                    blnFlag = false;
                }
            }
            else
            {
                blnFlag = false;
            }
        }

        if (blnFlag == true)
        {
            intPageMode = Convert.ToInt32(Request.QueryString["PageMode"]);
            intCategoryID = Convert.ToInt32(strCID);
            intSubcategoryID = Convert.ToInt32(strSCID);
            intSecondSubcatID = Convert.ToInt32(strSSCID);

        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
        return strPageMode;
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
        this.CheckUserSession();
        strPageMode = this.CheckQueryString();
        if (!Page.IsPostBack)
        {

            if (strPageMode == "1")
            {
                this.LoadList_LatestPosted_BookProduct_ByAuthor(author, intCountryID, intSubcategoryID);
            }
            else if (strPageMode == "0")
            {
                this.LoadList_LatestPosted_BookProduct_BySubCategory(intCountryID, intSubcategoryID);
            }
            else if (strPageMode == "2")
            {
                this.LoadList_LatestPosted_BookProduct_BySecondSubcategory(intCountryID, intSecondSubcatID);

            }
            else
            {
                this.LoadList_LatestPosted_BookProduct_ByPublisher(intCountryID, intSubcategoryID, strPublisher);
            }
            if (dtBookList.Rows.Count > 0)
            {
                strSSCID = dtBookList.Rows[0]["SecondSubcatID"].ToString();
            }


            if (!string.IsNullOrEmpty(this.CustomMessage))
            {
                if (this.CustomMessage == "1")
                {
                    this.strHtml = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%; background-color:#3F8A01;\">";
                    this.strHtml += "<tr>";
                    this.strHtml += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    this.strHtml += "Your have placed your order successfully.";
                    this.strHtml += "</td>";
                    this.strHtml += "</tr>";
                    this.strHtml += "</table>";

                    lblSystemMessage.Text = this.strHtml;
                }

                if (this.CustomMessage == "0")
                {
                    this.strHtml = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%; background-color:#E62D29;\">";
                    this.strHtml += "<tr>";
                    this.strHtml += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    this.strHtml += "System cannot process Your order ! Please try after sometime.";
                    this.strHtml += "</td>";
                    this.strHtml += "</tr>";
                    this.strHtml += "</table>";

                    lblSystemMessage.Text = this.strHtml;
                }
            }
        }
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["SELECTED_LOCATION"] = ddlLocation.SelectedItem.Value;
        Response.Redirect("../Default.aspx");
    }

    protected void grvItemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            this.strCID = Request.QueryString["CID"];
            this.strSCID = Request.QueryString["SCID"];
            this.Location = Request.QueryString["Location"];


            grvItemList.PageIndex = e.NewPageIndex;
            this.LoadList_LatestPosted_BookProduct_BySubCategory(intCountryID, intSubcategoryID);
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }
}
