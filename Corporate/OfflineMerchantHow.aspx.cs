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

public partial class Corporate_OfflineMerchantHow : System.Web.UI.Page
{
    /// <summary>
    /// Description      : Check Business User login authentication.
    /// Stored Procedure : USP_CP_UsrPro_GetLoginInfo
    /// Associate Control: Executes in btnLogin_Click event.
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
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Session.Clear();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        this.IsLoginValid();
    }
}
