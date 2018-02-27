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

public partial class Common_Default : System.Web.UI.Page
{
    public string userType = string.Empty;
    private string strEncryptedUrl = string.Empty;
    public string loginURL = string.Empty;
    private string strOrderID = string.Empty;
    private bool isLoginValid = false;
    //private string strRedirect = string.Empty;

    private void IsBusinessUserLoginValid()
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
                        this.Session["BS_ID"] = eocPropertyBean.Business_UserProfile_ProfileID.ToString();
                        this.Session["COUNTRY_ID"] = eocPropertyBean.Country_CountryID.ToString();
                        strEncryptedUrl = UTLUtilities.Encrypt("Type=BS");
                        isLoginValid = true;
                        //Response.Redirect("~/Commmon/PlaceOrder.aspx");
                    }
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    private void IsClassifiedUserLoginValid()
    {
        try
        {
            using (BOC_Classifieds_UserProfile bocUserProfile = new BOC_Classifieds_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Classifieds_UserProfile_LoginEmail = txtLoginEmail.Text;
                eocPropertyBean.Classifieds_UserProfile_LoginPassword = txtPassword.Text;

                if (!bocUserProfile.IsLoginValid(eocPropertyBean))
                {
                    lblSystemMessage.Text = "Access denied! Invalid Login Email or Password.";
                }
                else
                {
                    if (!eocPropertyBean.Classifieds_UserProfile_IsActive)
                    {
                        lblSystemMessage.Text = "Your classified account is not active.";
                    }
                    else
                    {
                        this.Session["CL_ID"] = eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString();
                        this.Session["COUNTRY_ID"] = eocPropertyBean.Country_CountryID.ToString();
                        //this.Session["CLSF_PROVINCE_CODE"] = eocPropertyBean.Province_ProvinceID.ToString();

                        //strRedirect = "Type=CL";
                        strEncryptedUrl = UTLUtilities.Encrypt("Type=CL");
                        isLoginValid = true;
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
        object cartIdSession = this.Session["BalloonShop_CartID"];
        if (cartIdSession == null)
        {
            Response.Redirect("../Default.aspx", true);
        }
        else
        {
            //this.Session.Clear();

            rblUserType.Attributes.Add("onClick", "ChangeUserType();");

            this.userType = rblUserType.SelectedItem.Value;

            if (this.userType == "Classified")
            {
                this.loginURL = "../Classifieds/UserProfile_Step01.aspx";
            }

            if (this.userType == "Business")
            {
                this.loginURL = "../Corporate/UserProfile_Step01.aspx";
            }

            if (Page.IsPostBack)
            {
                if (this.userType == "Classified")
                {
                    this.IsClassifiedUserLoginValid();
                }

                if (this.userType == "Business")
                {
                    this.IsBusinessUserLoginValid();
                    
                }
            }
        }
        if (isLoginValid)
        {
            Response.Redirect("PlaceOrder.aspx?data=" + strEncryptedUrl);
        }
    }
}
