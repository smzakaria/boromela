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

public partial class Corporate_Default : System.Web.UI.Page
{
    /// <summary>
    /// Description      : Check Business User login authentication.
    /// Stored Procedure : USP_CP_UsrPro_GetLoginInfo
    /// Associate Control: Executes in Page_Load event.
    /// </summary>
    private void IsLoginValid()
    {
        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_LoginEmail = txtLoginEmail.Text;
                eocPropertyBean.Business_UserProfile_LoginPassword = txtPassword.Text;

                if (!bocUserProfile.IsLoginValid(eocPropertyBean))
                {
                    lblSystemMessage.Text = "Access denied! Invalid Login Email or Password.";
                }
                else
                {
                    if (!eocPropertyBean.Business_UserProfile_IsActive)
                    {
                        lblSystemMessage.Text = "Your corporate account is not active.";
                    }
                    else
                    {
                        this.Session["CORP_PROFILE_CODE"] = eocPropertyBean.Business_UserProfile_ProfileID.ToString();
                        this.Session["CORP_COUNTRY_CODE"] = eocPropertyBean.Country_CountryID.ToString();

                        

                        Response.Redirect("ControlPanel.aspx");
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
    /// Description      : Saves sellers suggestion in table Seller_Landing_Suggestion
    /// Stored Procedure : USP_Admin_InsertSellersLandingPageSuggestion
    /// Associate Control: None
    /// </summary>
    private void AddRecord_SellerComments()
    {
        using (BC_LandingPageComments bc_LandingPageComments = new BC_LandingPageComments())
        {
            int intActionResult = 0;
            try
            {
                intActionResult = bc_LandingPageComments.SaveRecord_LandingPageComments(txtName.Text, txtCompany.Text, txtEmail.Text, txtPhone.Text, txtSubject.Text, txtComments.Text);
                if (intActionResult > 0)
                {
                    lblSystemMessageComments.Text = "Thank you for your suggestion.";
                }
            }
            catch (Exception ex)
            {
                lblSystemMessageComments.Text = "Error: " + ex.Message;
            }
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Session.Clear();

        //if (Page.IsPostBack)
        //{
        //    this.IsLoginValid();
        //}
    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtEmail.Text))
        {
            lblSystemMessageComments.Text = "Please enter name and email address.";
        }
        else if (string.IsNullOrEmpty(txtName.Text))
        {
            lblSystemMessageComments.Text = "Please enter name.";
        }
        else if (string.IsNullOrEmpty(txtEmail.Text))
        {
            lblSystemMessageComments.Text = "Please enter email address.";
        }
        else
        {
            this.AddRecord_SellerComments();
        }
    }
    protected void ImgbtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        this.IsLoginValid();
    }
}
