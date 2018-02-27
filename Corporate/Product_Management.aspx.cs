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

public partial class Corporate_Product_Management : System.Web.UI.Page
{
    private bool _Business_Seller = true;
    private int intProfileID = -1;
    private int intCountryID = -1;
    private int intProductID = -1;
    private int intCategoryID = -1;
    private int intSubcategoryID = -1;
    private int intSecondSubcatID = -1;
    private DataTable dtProduct = null;
    private string strProductTitle = string.Empty;

    public string GetSku
    {
        get { return lblSku.Text; }
    }
    public string GetCategory
    {
        get { return ddlCategory.SelectedItem.Text; }
    }
    public string GetSubcategory
    {
        get { return ddlSubcategory.SelectedItem.Text; }
    }
    public string GetSecondSubcategory
    {
        get { return ddl2ndSubCategory.SelectedItem.Text;}
    }
    public string GetProfileID
    {
        get { return intProfileID.ToString(); }
    }
    public string GetProductID
    {
        get { return intProductID.ToString(); }
    }
    public string GetCategoryID
    {
        get { return ddlCategory.SelectedValue; }
    }
    public string GetSubCategoryID
    {
        get { return ddlSubcategory.SelectedValue; }
    }
    public string GetSecondSubcatID
    {
        get { return ddl2ndSubCategory.SelectedValue; }
    }
   
    public int SearchResult
    {
        get 
        {
            if (dtProduct != null)
            {
                if (dtProduct.Rows.Count > 0)
                {
                    return dtProduct.Rows.Count;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }


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

    /// <summary>
    /// Loads the all Business Categories from category table.
    /// </summary>
    private void LoadRecord_Category()
    {
        try
        {
            using (BC_Corporate_ProductProfile bcProductProfile = new BC_Corporate_ProductProfile())
            {

                DataTable dtCategory = bcProductProfile.LoadRecord_Category(intCountryID);
                if (dtCategory.Rows.Count > 0)
                {
                    ddlCategory.DataSource = dtCategory;
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataTextField = "Category";
                    ddlCategory.DataBind();
                }
                else
                {
                    lblSystemMessage.Text = "No Category available";
                }

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Loads Subacategory list based on CategoryID.
    /// </summary>
    private void LoadRecord_Subcategory()
    {
        try
        {
            using (BC_Corporate_ProductProfile bcProductProfile = new BC_Corporate_ProductProfile())
            {
                ddlSubcategory.Items.Clear();
                ddlSubcategory.Items.Add(new ListItem("Select Category", "-1"));
                DataTable dtSubcategory = bcProductProfile.LoadRecord_Subcategory(intCategoryID);
                if (dtSubcategory.Rows.Count > 0)
                {
                    ddlSubcategory.DataSource = dtSubcategory;
                    ddlSubcategory.DataValueField = "SubcategoryID";
                    ddlSubcategory.DataTextField = "Subcategory";
                    ddlSubcategory.DataBind();
                }
                else
                {
                    lblSystemMessage.Text = "No Subcategory available";
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Loads SecondSubcategory List Based On SubcategoryID.
    /// </summary>
    private void LoadRecord_2ndSubcategory()
    {
        try
        {
            using (BC_Corporate_ProductProfile bcProductProfile = new BC_Corporate_ProductProfile())
            {
                ddl2ndSubCategory.Items.Clear();
                ddl2ndSubCategory.Items.Add(new ListItem("Select Second Subcategory", "-1"));

                DataTable dt2ndSubcategory = bcProductProfile.LoadRecord_2ndSubcategory(intCategoryID, intSubcategoryID);
                if (dt2ndSubcategory.Rows.Count > 0)
                {
                    ddl2ndSubCategory.DataSource = dt2ndSubcategory;
                    ddl2ndSubCategory.DataValueField = "SecondSubcatID";
                    ddl2ndSubCategory.DataTextField = "SecondSubCategory";
                    ddl2ndSubCategory.DataBind();
                }
                else
                {
                    lblSystemMessage.Text = "No Secondary sub category available";
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Gets the last SKU(Profile specific) from Product_Seller_Detail table.
    /// USP: USP_CP_Public_GetLastSKU
    /// </summary>
    /// <param name="intProfileID"></param>
    /// <returns></returns>
    private string Get_Last_ProfileSpecificSKU(int intProfileID, bool sellerType)
    {
        string strLastSku = null;
        DataTable dt = new DataTable();
        try
        {
            using (BC_Book bc_Book = new BC_Book())
            {
                dt = bc_Book.Get_Last_ProfileSpecificSKU(intProfileID, _Business_Seller);
                if (dt.Rows.Count > 0)
                {
                    strLastSku = dt.Rows[0]["SKU"].ToString();
                    strLastSku = (string.IsNullOrEmpty(strLastSku)) ? "0" : strLastSku;
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
        return strLastSku;
    }

    /// <summary>
    /// Takes last SKU as parameter and generates new SKU for current product.
    /// USP: USP_CP_Public_GetNew_SKU.
    /// </summary>
    /// <param name="strSku"></param>
    private void Generate_ProfileSpecific_UniqueSKU(string strSku)
    {
        DataTable dt = new DataTable();
        try
        {
            using (BC_Book bc_Book = new BC_Book())
            {
                dt = bc_Book.Generate_ProfileSpecific_UniqueSKU(strSku);
                if (dt.Rows.Count > 0)
                {
                    lblSku.Text = dt.Rows[0]["SKU"].ToString();
                }
                else
                {
                    lblSystemMessage.Text = "Error in SKU generation.";
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

    }


    /// <summary>
    /// Loads grvProduct with all the product title from the database, 
    /// that matches with the user provided product title. Returns true if any matches occur.
    /// </summary>
    private bool LoadList_Product()
    {
        bool blnFlag = false;
        intCategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
        intSubcategoryID = Convert.ToInt32(ddlSubcategory.SelectedValue);
        intSecondSubcatID = Convert.ToInt32(ddl2ndSubCategory.SelectedValue);
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                dtProduct = new DataTable();
                dtProduct = bcProduct.GetList_ProductTitle(intCategoryID, intSubcategoryID, intSecondSubcatID, txtTitle.Text);
                if (dtProduct.Rows.Count > 0)
                {
                    grvProduct.DataSource = dtProduct;
                    grvProduct.DataBind();
                    blnFlag = true;

                }
                else
                {
                    grvProduct.DataSource = null;
                    grvProduct.DataBind();
                    blnFlag = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
        return blnFlag;
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        hfCategoryID.Value = ddlCategory.SelectedItem.Value;
        if (Int32.TryParse(hfCategoryID.Value, out intCategoryID))
        {
            this.LoadRecord_Subcategory();
        }
    }

    protected void ddlSubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Int32.TryParse(ddlCategory.SelectedItem.Value, out intCategoryID) && 
            Int32.TryParse(ddlSubcategory.SelectedValue, out intSubcategoryID))
        {
            this.LoadRecord_2ndSubcategory();
        }
        

    }
    protected void ddl2ndSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void btnChangeCategory_Click(object sender, EventArgs e)
    {
        grvProduct.Dispose();
        grvProduct.Visible = false;

        //btnSearch.Visible = true;
        btnCheckDuplicacy.Visible = false;
        this.Enable_Search_Criteria(true);
        btnChangeCategory.Visible = false;
        btnSearch.Enabled = true;
        btnNext.Visible = false;
    }
    /// <summary>
    /// Disables three category ddl and title textbox.
    /// </summary>
    /// <param name="isEnable">if false disables the Categories.</param>
    private void Enable_Search_Criteria(bool isEnable)
    {
        ddlCategory.Enabled = isEnable;
        ddlSubcategory.Enabled = isEnable;
        ddl2ndSubCategory.Enabled = isEnable;
        btnSearch.Visible = isEnable;
        txtTitle.ReadOnly = !isEnable;
        btnChangeCategory.Visible = !isEnable;
    }
  

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        txtTemp.Text = hfProductID.Value;
        if (LoadList_Product())
        {
            grvProduct.Visible = true;
            btnChangeCategory.Visible = true;
        }
        else
        {
            string strDisplayMessage = "<span class=\"title\" style=\"font-size:12px\">";
            strDisplayMessage += "No results found in the Database for your search ";
            strDisplayMessage += "<strong style=\"color:Red\">\"" + txtTitle.Text + "\"</strong>";
            strDisplayMessage += ". However you can refine your search options to find a match or you can click Next to create your own";
            strDisplayMessage += " product detail.</span>";
            lblTitleMessage.Text = strDisplayMessage;
            btnNext.Visible = true;
        }
        Enable_Search_Criteria(false);
        
        this.Page.Header.Title += ddlCategory.SelectedItem.Text + ": "+ txtTitle.Text ;
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        this.grvProduct.Dispose();
        this.grvProduct.DataSource = null;
        this.grvProduct.Visible = false;
        this.Enable_Search_Criteria(false);
        txtTitle.ReadOnly = false;
        btnCheckDuplicacy.Visible = true;
        btnSearch.Enabled = false;
        btnSearch.Visible = false;
    }

    

    protected void grvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvProduct.PageIndex = e.NewPageIndex;
            this.LoadList_Product();
        }
        catch (Exception Exp)
        {
            Response.Write(Exp.Message.ToString());
        }
    }

    /// <summary>
    /// Returns true if Master seller's given product title already exists.
    /// </summary>
    private bool Check_IsMasterProductDuplicate()
    {
        bool blnFlag = true;
        if (Int32.TryParse(ddlCategory.SelectedValue, out intCategoryID) && Int32.TryParse(ddlSubcategory.SelectedValue, out intSubcategoryID)
            && Int32.TryParse(ddl2ndSubCategory.SelectedValue, out intSecondSubcatID))
        {
            try
            {
                using (BC_Product bcProduct = new BC_Product())
                {
                    blnFlag = bcProduct.IsMaster_ProductTitle_Dupllicate(intCategoryID, intSubcategoryID, intSecondSubcatID, txtTitle.Text);
                    
                }
            }
            catch (Exception ex)
            {
                lblSystemMessage.Text = ex.Message;
            }
        }
        return blnFlag;
    }

    /// <summary>
    /// Returns true if Tag seller already tagged this product.
    /// </summary>
    /// <returns></returns>
    private bool Is_Seller_Tagged_Once(int intProductID, int intProfileID, bool sellerType)
    {
        bool blnFlag = false;
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                blnFlag = bcProduct.Is_Seller_Tagged_Once(intProfileID, intProductID, sellerType);
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
        return blnFlag;
    }

    

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();
        this.Page.Header.Title = "www.boromela.com ";
        
        if (!Page.IsPostBack)
        {
            string strSku = this.Get_Last_ProfileSpecificSKU(intProfileID, _Business_Seller);
            this.Generate_ProfileSpecific_UniqueSKU(strSku);
            this.LoadRecord_Category();
        }
    }

    protected void grvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "SelectProduct")
        {
            string strProductID = grvProduct.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[0].ToString();
            strProductTitle = grvProduct.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[1].ToString();
            hfProductID.Value = strProductID;
            hfProductTitle.Value = strProductTitle;
            Int32.TryParse(strProductID, out intProductID);

            if (!Is_Seller_Tagged_Once(intProductID, intProfileID, _Business_Seller))
            {
                this.Enable_Search_Criteria(false);
                lblSystemMessage.Text = "";
                string strQueryString = "&mode=0&ci=" + GetCategoryID;
                strQueryString += "&sci=" + GetSubCategoryID;
                strQueryString += "&ssci=" + GetSecondSubcatID;
                strQueryString += "&pi=" + GetProductID;
                strQueryString += "&pfi=" + GetProfileID;
                strQueryString += "&sku=" + GetSku;
                //strQueryString += "&st=" + _Business_Seller.ToString();
                strQueryString += "&inserttype=tag";
                strQueryString += "&title=" + strProductTitle;

                strQueryString += "&c=" + GetCategory;
                strQueryString += "&sc=" + GetSubcategory;
                strQueryString += "&ssc=" + GetSecondSubcategory;

                Response.Redirect("ProductProfileAE.aspx?" + strQueryString);
                
            }
            else
            {
                string strDisplayMessage = "<span class=\"title\" style=\"font-size:12px\">";
                strDisplayMessage += "You already tagged this <strong style=\"color:Red\">\"" + txtTitle.Text + "\"</strong> once<br/>";
                strDisplayMessage += "Please select another Book.";
                lblTitleMessage.Text = strDisplayMessage;

                //lblTitleMessage.Text = "You already tagged this product once. Please select another product or refine your search criteria.";
                lblTitleMessage.Focus();
            }
        }
    }

    /// <summary>
    /// Checks for Duplicate ProductTitle. It is used when the user tries to 
    /// Create his own product detail.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCheckDuplicacy_Click(object sender, EventArgs e)
    {
        string strDisplayMessage = "<span class=\"title\" style=\"font-size:12px\">";
        
        if (Check_IsMasterProductDuplicate())
        {
            strDisplayMessage += "Duplicate Product title exists in the database. Please change the Product title.</span> ";
            btnNext.Visible = false;
            
        }
        else
        {
            Enable_Search_Criteria(false);
            btnNext.Visible = true;
            btnCheckDuplicacy.Visible = false;
            strDisplayMessage += "This Product title is available. Please click Next to continue.</span> ";
            
        }
        lblTitleMessage.Text = strDisplayMessage;
    }


    protected void btnNext_Click(object sender, EventArgs e)
    {
        string strQueryString = "&mode=0&ci=" + GetCategoryID;
        strQueryString += "&sci=" + GetSubCategoryID;
        strQueryString += "&ssci=" + GetSecondSubcatID;
        strQueryString += "&pi=" + GetProductID;
        strQueryString += "&pfi=" + GetProfileID;
        strQueryString += "&sku=" + GetSku;
        strQueryString += "&inserttype=master";
        strQueryString += "&title=" + Server.UrlEncode(txtTitle.Text);

        strQueryString += "&c=" + Server.UrlEncode(GetCategory);
        strQueryString += "&sc=" + Server.UrlEncode(GetSubcategory);
        strQueryString += "&ssc=" + Server.UrlEncode(GetSecondSubcategory);


        Response.Redirect("ProductProfileAE.aspx?" + strQueryString, false);
    }
}
