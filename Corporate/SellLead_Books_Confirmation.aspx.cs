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

public partial class Corporate_SellLead_Books_Confirmation : System.Web.UI.Page
{
    private int intProfileID = -1;
    private int intCountryID = -1;

    private string strFromDate = string.Empty;
    private string strToDate = string.Empty;
    private string strCustomerEmail = string.Empty;
    public string strBuyerName = string.Empty;

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

    private void GetSellLead_OrderDetail()
    {
        if (this.Session["SELL_LEAD_FROMDATE"] != null || this.Session["SELL_LEAD_TODATE"] != null || string.IsNullOrEmpty(Request.QueryString["Email"]) == false)
        {
            strFromDate = this.Session["SELL_LEAD_FROMDATE"].ToString();
            strToDate = this.Session["SELL_LEAD_TODATE"].ToString();
            strCustomerEmail = Request.QueryString["Email"];

            using (BOC_Corporate_ProdProf_Book bocProductProfile = new BOC_Corporate_ProdProf_Book())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_ProfileID = intProfileID;
                eocPropertyBean.Business_OrderDetail_Books_CustomerEmail = strCustomerEmail;
                eocPropertyBean.FromDate = Convert.ToDateTime(strFromDate);
                eocPropertyBean.ToDate = Convert.ToDateTime(strToDate);

                grvSellLead02.DataSource = bocProductProfile.SellLead_OrderDetail(eocPropertyBean);
                grvSellLead02.DataBind();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        strBuyerName = Request.QueryString["Buyer"];

        this.CheckUserSession();
        this.GetSellLead_OrderDetail();
               
    }
    protected void grvSellLead02_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvSellLead02.PageIndex = e.NewPageIndex;
            this.GetSellLead_OrderDetail();
        }
        catch (Exception Exp)
        {
            Response.Write(Exp.Message.ToString());
        }
    }
}
