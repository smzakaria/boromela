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

public partial class UserControl_BookList_LeftMenu : System.Web.UI.UserControl
{
    private int intCountryID = -1;
    private string selectedLocation = null;
    private int intCategoryID = -1;
    protected int intSubcategoryID = -1;
    private bool enableControl = true;

    public string SelectedLocation
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

    // <summary>
    /// Description      : Loads Lists of Top 10 Authors.
    /// Stored Procedure : USP_Common_BookProduct_Load_Top10Author
    /// Associate Control: Executes in Page_Load event.
    /// </summary>
    private void LoadList_Top10_Author()
    {
        DataTable dtAuthor = null;
        intCountryID = Convert.ToInt32(selectedLocation);
        try
        {
            using (BC_Author objbcAuthor = new BC_Author())
            {
                dtAuthor = objbcAuthor.LoadList_Top10_Author(intCountryID, intSubcategoryID);
                if (dtAuthor.Rows.Count > 0)
                {
                    grvTopAuthor.DataSource = dtAuthor;
                    grvTopAuthor.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.Message);
        }
    }


    // <summary>
    /// Description      : Loads Lists of all Authors. 
    /// Stored Procedure : USP_Common_BookProduct_Load_AllAuthor
    /// Associate Control: Executes in Page_Load event.
    /// </summary>
    private void LoadList_All_Author()
    {
        DataTable dtAuthor = null;
        try
        {
            using (BC_Author objbcAuthor = new BC_Author())
            {
                dtAuthor = objbcAuthor.LoadList_All_Author(intCountryID, intSubcategoryID);
                if (dtAuthor.Rows.Count > 0)
                {
                    grvAllAuthor.DataSource = dtAuthor;
                    grvAllAuthor.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.Message);
        }
    }
    // <summary>
    /// Description      : Loads Lists of Top 10 SecondSubcategory of book.
    ///                    CountryID will be used to select Country specific record 
    /// Stored Procedure : USP_Common_BookProduct_Load_Top10SecondSubcategory
    /// Associate Control: Executes in Page_Load event.
    /// </summary>
    private void LoadRecord_Top10_SecondSubcategory()
    {
        DataTable dtSecondSubcategory = null;

        try
        {
            using (BC_SecondSubcategory objcSecondSubcategory = new BC_SecondSubcategory())
            {
                dtSecondSubcategory = objcSecondSubcategory.LoadList_BookProduct_Top10SecondSubcategory(intCountryID, intCategoryID, intSubcategoryID);
                if (dtSecondSubcategory.Rows.Count > 0)
                {
                    grvTopSecondSubcategory.DataSource = dtSecondSubcategory;
                    grvTopSecondSubcategory.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.Message);
        }
    }

    // <summary>
    /// Description      : Loads Lists of Top 10 SecondSubcategory of book.
    ///                    CountryID will be used to select Country specific record 
    /// Stored Procedure : USP_Common_BookProduct_Load_AllSecondSubcategory
    /// Associate Control: Executes in Page_Load event.
    /// </summary>
    private void LoadRecord_All_SecondSubcategory()
    {
        DataTable dtSecondSubcategory = null;

        try
        {
            using (BC_SecondSubcategory objcSecondSubcategory = new BC_SecondSubcategory())
            {
                dtSecondSubcategory = objcSecondSubcategory.LoadList_BookProduct_AllSecondSubcategory(intCountryID, intSubcategoryID);
                if (dtSecondSubcategory.Rows.Count > 0)
                {
                    grvAllSecondSubcategory.DataSource = dtSecondSubcategory;
                    grvAllSecondSubcategory.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.Message);
        }
    }

   

    // <summary>
    /// Description      : Loads Top 10 Publisher list from Latest_Posted_BookProduct_View.
    /// Stored Procedure : USP_Common_BookProduct_Load_AllPublisher
    /// Associate Control: Executes in Page_Load event.
    /// </summary>
    private void LoadList_Top10_Publisher()
    {
        DataTable dtSecondSubcategory = null;

        try
        {
            using (BC_Publisher objcPublisher = new BC_Publisher())
            {
                dtSecondSubcategory = objcPublisher.LoadList_Top10_Publisher(intCountryID, intSubcategoryID);
                if (dtSecondSubcategory.Rows.Count > 0)
                {
                    grvTopPublisher.DataSource = dtSecondSubcategory;
                    grvTopPublisher.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.Message);
        }
    }

    // <summary>
    /// Description      : Loads All Publisher list from Latest_Posted_BookProduct_View.
    /// Stored Procedure : USP_Common_BookProduct_Load_AllPublisher
    /// Associate Control: Executes in Page_Load event.
    /// </summary>
    private void LoadList_All_Publisher()
    {

        using (BC_Publisher objbcPublisher = new BC_Publisher())
        {
            DataTable dtPublisher = null;
            try
            {
                dtPublisher = objbcPublisher.LoadList_All_Publisher(intCountryID, intSubcategoryID);
                if (dtPublisher.Rows.Count > 0)
                {
                    grvAllPublisher.DataSource = dtPublisher;
                    grvAllPublisher.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }


   

    protected void Page_Load(object sender, EventArgs e)
    {
        string strCategoryID = "";
        string strSubcategoryID = "";
        bool success = true;

        //TODO: This if-else can be removed. Because this Page_Load event fire only after Main pages Page_load events fires.
        if (Session["SELECTED_LOCATION"] != null)
        {
            this.selectedLocation = Session["SELECTED_LOCATION"].ToString();
            intCountryID = Convert.ToInt32(selectedLocation);
        }
     
        if (enableControl)
        {
            try
            {

                if (Request.QueryString["data"] != null)
                {
                    string strEncryptedUrl = Request.QueryString["data"].ToString();
                    string strDecryptedUrl = UTLUtilities.Decrypt(strEncryptedUrl);
                    string[] strSplitUrl = strDecryptedUrl.Split('&', '=');
                    strCategoryID = strSplitUrl[7];
                    strSubcategoryID = strSplitUrl[9];
                }
                else
                {
                    strCategoryID = Request.QueryString["CID"];
                    strSubcategoryID = Request.QueryString["SCID"];
                }
                intSubcategoryID = Convert.ToInt32(strSubcategoryID);
                intCategoryID = Convert.ToInt32(strCategoryID);
            }
            catch (Exception exp)
            {
                success = false;
            }
            if (!Page.IsPostBack && success)
            {
                this.LoadList_All_Author();
                this.LoadList_All_Publisher();
                this.LoadList_Top10_Author();
                this.LoadList_Top10_Publisher();
                this.LoadRecord_All_SecondSubcategory();
                this.LoadRecord_Top10_SecondSubcategory();
            }
        }
    }

    // we don't want to display the cart summary in the shopping cart page
    protected void Page_Init(object sender, EventArgs e)
    {
        string page = Request.AppRelativeCurrentExecutionFilePath;
        if ((String.Compare(page, "~/Common/ShoppingCart.aspx", true) == 0) || (String.Compare(page, "~/Common/PlaceOrder.aspx", true) == 0) || (String.Compare(page, "~/Common/OrderConfirmation.aspx", true) == 0))
        {
            this.Visible = false;
            enableControl = false;
        }
        else
        {
            this.Visible = true;
        }
    }
}
