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

public partial class Corporate_UserProfile_Step01 : System.Web.UI.Page
{
    /// <summary>
    /// Description      : Load country list from the table Country.
    /// Stored Procedure : USP_CP_UsrPro_LoadCountry
    /// Associate Control: ddlCountry [Drop Down List]
    /// </summary>
    private void LoadRecord_Country()
    {
        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                ddlCountry.DataSource = bocUserProfile.LoadRecord_Country();
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataTextField = "Country";
                ddlCountry.DataBind();
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();            
        }
    }

    /// <summary>
    /// Description      : Load country wise state list from the table State.
    /// Stored Procedure : USP_CP_UsrPro_LoadState
    /// Associate Control: ddlState [Drop Down List]
    /// </summary>
    /// <param name="CountryID">string</param>
    private void LoadRecord_State(string CountryID)
    {
        try
        {
            if (!string.IsNullOrEmpty(CountryID) && CountryID != "-1")
            {
                using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                    eocPropertyBean.Country_CountryID = Convert.ToInt32(CountryID);

                    DataTable dtState = bocUserProfile.LoadRecord_State(eocPropertyBean);
                    
                    ddlState.Items.Clear();
                    ddlState.Items.Add(new ListItem("Select", "-1"));

                    if (dtState.Rows.Count > 0)
                    {
                        ddlState.DataSource = dtState;
                        ddlState.DataValueField = "StateID";
                        ddlState.DataTextField = "StateName";
                        ddlState.DataBind();
                    }
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Description      : Load state wise province list.
    /// Stored Procedure : USP_CP_UsrPro_LoadProvince
    /// Associate Control: ddlProvince [Drop Down List]
    /// </summary>
    /// <param name="StateID">String</param>
    private void LoadRecord_Province(string StateID)
    {
        try
        {
            if (!string.IsNullOrEmpty(StateID) && StateID != "-1")
            {
                using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                    eocPropertyBean.State_StateID = Convert.ToInt32(StateID);

                    DataTable dtPovince = bocUserProfile.LoadRecord_Province(eocPropertyBean);
                    
                    ddlProvince.Items.Clear();
                    ddlProvince.Items.Add(new ListItem("Select", "-1"));

                    if (dtPovince.Rows.Count > 0)
                    {
                        ddlProvince.DataSource = dtPovince;
                        ddlProvince.DataValueField = "ProvinceID";
                        ddlProvince.DataTextField = "Province";
                        ddlProvince.DataBind();
                    }
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Description      : Load business category list from the table BusinessCategory.
    /// Stored Procedure : USP_CP_UsrPro_LoadBusinessCategory
    /// Associate Control: ddlBusinessType [Drop Down List]
    /// </summary>
    private void LoadRecord_BusinessCategory()
    {
        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                ddlBusinessType.DataSource = bocUserProfile.LoadRecord_BusinessCategoey();
                ddlBusinessType.DataValueField = "BusinessID";
                ddlBusinessType.DataTextField = "BusinessCategory";
                ddlBusinessType.DataBind();
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Description      : Insert new record in the table Business_UserProfile.
    /// Stored Procedure : USP_CP_UsrPro_BeforeInsert_IsLoginEmailDuplicate
    ///                    USP_CP_UsrPro_BeforeInsert_IsCompanyNameDuplicate
    ///                    USP_CP_UsrPro_InserRecord
    /// Associate Control: btnRegister [Button]
    /// </summary>
    /// <returns>Integer</returns>
    private int AddRecord_UserProfile()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.BusinessCategory_BusinessID = Convert.ToInt32(ddlBusinessType.SelectedItem.Value);
                eocPropertyBean.Business_UserProfile_LoginEmail = txtEmail1.Text;
                eocPropertyBean.Business_UserProfile_LoginPassword = txtPassword1.Text;
                eocPropertyBean.Business_UserProfile_CompanyName = txtCompany.Text;
                eocPropertyBean.Business_UserProfile_BusinessAddress = txtAddress.Text;                
                eocPropertyBean.Province_ProvinceID = Convert.ToInt32(ddlProvince.SelectedItem.Value);
                eocPropertyBean.Business_UserProfile_ContactPhone = txtPhone.Text;
                eocPropertyBean.Business_UserProfile_CompanyURL = txtURL.Text;
                eocPropertyBean.Business_UserProfile_BillingPerson = txtBillingContact.Text;
                eocPropertyBean.Business_UserProfile_WebInventoryManager = txtInventoryManager.Text;
                eocPropertyBean.Business_UserProfile_CompanyProfile = txtProfile.Text;
                eocPropertyBean.Business_UserProfile_CompanyLogo = @"Corporate_Logos/default.png";
                //eocPropertyBean.UserType = "1";
                eocPropertyBean.UpdatedOn = DateTime.Now;

                intActionResult = bocUserProfile.AddRecord_UserProfile(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadRecord_Country();
            this.LoadRecord_BusinessCategory();
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int intActionResult = 0;
        string strSystemMessage = string.Empty;

        intActionResult = this.AddRecord_UserProfile();

        //Case 01 : Successfully insertion of record:
        if (intActionResult > 0)
        {
            this.Session["CORP_PROFILE_EMAIL"] = txtEmail1.Text;
            Response.Redirect("UserProfile_Step02.aspx");
        }

        //Case 02 : Record insertion unsuccessful for duplicate login email address:
        if (intActionResult == -1)
        {
            strSystemMessage = "<table style='width:500px; border:1px dashed #666666;'>";
            strSystemMessage += "<tr>";
            strSystemMessage += "<td align='center' style='width:10%;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td>";
            strSystemMessage += "<td valign='middle' style='width:90%;font-weight:bold; text-decoration:underline'>Following error occured :</td>";
            strSystemMessage += "</tr>";
            strSystemMessage += "<tr>";
            strSystemMessage += "<td colspan='2' style='width:100%;color:#000000;padding-top:7px; padding-left:10px;'>";
            strSystemMessage += "This email address already used in another corporate profile.";
            strSystemMessage += "<br/><br/>";
            strSystemMessage += "<strong>How did this happen? </strong>";
            strSystemMessage += "<ul>";
            strSystemMessage += "<li>You may have already registered with www.boromela.com earlier but forgot about it.</li>";
            strSystemMessage += "<li>If you share your email address with someone else, they may have signed up for a boromela corporate account with this address.</li>";
            strSystemMessage += "</ul>";
            strSystemMessage += "</td>";
            strSystemMessage += "</tr>";
            strSystemMessage += "</table>";

            lblSystemMessage.Text = strSystemMessage.ToString();
        }

        //Case 03 : Record insertion unsuccessful for duplicate company name:
        if (intActionResult == -2)
        {
            strSystemMessage = "<table style='width:500px; border:1px dashed #666666;'>";
            strSystemMessage += "<tr>";
            strSystemMessage += "<td align='center' style='width:10%;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td>";
            strSystemMessage += "<td valign='middle' style='width:90%;font-weight:bold; text-decoration:underline'>Following error occured :</td>";
            strSystemMessage += "</tr>";
            strSystemMessage += "<tr>";
            strSystemMessage += "<td colspan='2' style='width:100%;color:#000000;padding-top:7px; padding-left:10px;'>";
            strSystemMessage += "This company name already exists in another corporate profile.";
            strSystemMessage += "<br/><br/>";
            strSystemMessage += "<strong>How did this happen? </strong>";
            strSystemMessage += "<ul>";
            strSystemMessage += "<li>You may have already registered with www.boromela.com earlier but forgot about it.</li>";
            strSystemMessage += "<li>Some one else use this corporate name and signed up for a boromela.com corporate account.</li>";
            strSystemMessage += "</ul>";
            strSystemMessage += "</td>";
            strSystemMessage += "</tr>";
            strSystemMessage += "</table>";

            lblSystemMessage.Text = strSystemMessage.ToString();
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlState.Items.Clear();
        ddlState.Items.Add(new ListItem("Select", "-1"));

        ddlProvince.Items.Clear();
        ddlProvince.Items.Add(new ListItem("Select", "-1"));
        
        this.LoadRecord_State(ddlCountry.SelectedItem.Value);
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadRecord_Province(ddlState.SelectedItem.Value);
    }
}
