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

public partial class UserControl_ClassifiedSearchModule : System.Web.UI.UserControl
{
    private int intCountryID = 18;
    private string strCategoryID;
    private int intNumberOfNegotiableItems;

    public int NumberOfNegotiableItems
    {
        get { return intNumberOfNegotiableItems; }
        set { intNumberOfNegotiableItems = value; }
    }

    public string CategoryID
    {
        get { return strCategoryID; }
        set { strCategoryID = value; }
    }

    private DataTable dtClassified = null;
    
    
    ///// <summary>
    ///// Loads only Classified Category
    ///// </summary>
    //private void LoadRecord_ClassifiedCategory()
    //{
    //    try
    //    {
    //        using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
    //        {
    //            EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
    //            eocPropertyBean.Country_CountryID = intCountryID;
    //            ddlCategory.Items.Clear();
    //            ddlCategory.Items.Add(new ListItem("All Category", "-1"));
    //            DataTable dtCategory = bocProductProfile.LoadRecord_ClassifiedCategory(eocPropertyBean);
    //            if (dtCategory.Rows.Count > 0)
    //            {
    //                ddlCategory.DataSource = dtCategory;
    //                ddlCategory.DataValueField = "CategoryID";
    //                ddlCategory.DataTextField = "Category";
    //                ddlCategory.DataBind();
    //            }
    //            else
    //            {
    //                lblSystemMessage.Text = "No category found.";
    //            }
    //        }
    //    }
    //    catch (Exception Exp)
    //    {
    //        lblSystemMessage.Text = Exp.Message.ToString();
    //    }
    //}




    /// <summary>
    /// Loads Number of Negotiable Classified Items.
    /// </summary>
    private void LoadNumberOf_NegotiableItems()
    {
        try
        {
            using (BC_Classifieds_Item bcClassifiedItems = new BC_Classifieds_Item())
            {
                dtClassified = bcClassifiedItems.LoadNumberOf_NegotiableItems(Convert.ToInt32(CategoryID));
                if (dtClassified.Rows.Count > 0)
                {
                    repNegotiable.DataSource = dtClassified;
                    repNegotiable.DataBind();
                }
                else
                {
                    NumberOfNegotiableItems = 0;
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

    }




    /// <summary>
    /// Loads all Classified Category with Number of items posted in that Category.
    /// USP: USP_Classified_LeftMenu_LoadAllCategory_WithNoOf_Items
    /// </summary>
    private void LoadList_ClassifiedCategory_WithNoOf_Items()
    {
        try
        {
            using (BC_Classifieds_Item bcClassifiedItems = new BC_Classifieds_Item())
            {
                dtClassified = bcClassifiedItems.LoadList_ClassifiedCategory_WithNoOf_Items("bangladesh");
                if (dtClassified.Rows.Count > 0)
                {
                    grvCategory.DataSource = dtClassified;
                    grvCategory.DataBind();
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

    }


    /// <summary>
    /// Loads all Province with Number of Posted Classified items Posted For Specific Classified Category.
    /// </summary>
    private void LoadList_CL_Items_ByProvince(int intCategoryID)
    {
        try
        {
            using (BC_Classifieds_Item bcClassifiedItems = new BC_Classifieds_Item())
            {
                dtClassified = bcClassifiedItems.LoadList_CL_Items_ByProvince(intCategoryID);
                if (dtClassified.Rows.Count > 0)
                {
                    dlst.DataSource = dtClassified;
                    dlst.DataBind();
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    

    /// <summary>
    /// Loads all Province with Number of Posted Classified items Posted For All Classified Category.
    /// </summary>
    private void LoadList_CL_Items_AllProvince(string strCountry)
    {
        try
        {
            using (BC_Classifieds_Item bcClassifiedItems = new BC_Classifieds_Item())
            {
                dtClassified = bcClassifiedItems.LoadList_CL_Items_AllProvince(strCountry);
                if (dtClassified.Rows.Count > 0)
                {
                    dlst.DataSource = dtClassified;
                    dlst.DataBind();
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

        if (Request.QueryString["CID"] != null)
        {
            CategoryID = Request.QueryString["CID"].ToString();
            //dlst.Caption = "<div style=\"height:20px;padding-top:7px;margin:3px 0px 3px 0px;font-size:12px;\"><span class=\"price\">";
            //dlst.Caption += ddlCategory.SelectedItem.Text + "</span></div>";
            if (!Page.IsPostBack)
            {
                //this.LoadRecord_ClassifiedCategory();
                //if (ddlCategory.SelectedValue == "-1")
                //{
                    //this.LoadList_CL_Items_AllProvince("Bangladesh");
                //}
                //else
                //{ 
                this.LoadNumberOf_NegotiableItems();
                    this.LoadList_CL_Items_ByProvince(Convert.ToInt32(Request.QueryString["CID"]));
                    this.LoadList_ClassifiedCategory_WithNoOf_Items();
                //}
            }
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }
    protected void dlst_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //HyperLink link = (HyperLink)e.Item.FindControl("lnkLocation");
        //if (link != null)
        //{
        //    link.NavigateUrl = "Item.aspx?PageMode=1" + DataBinder.Eval(dlst.Items[e.Item.ItemIndex], "Province");

        //}
    }
    protected void dlst_ItemCreated(object sender, DataListItemEventArgs e)
    {

    }
    //protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlCategory.SelectedValue == "-1")
    //    {
    //        LoadList_CL_Items_AllProvince("Bangladesh");
    //    }
    //    else
    //    {
    //        LoadList_CL_Items_ByProvince(Convert.ToInt32(ddlCategory.SelectedValue));
    //    }
    //}
}
