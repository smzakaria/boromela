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

public partial class Corporate_SellLead_General : System.Web.UI.Page
{
    private string strFromDate = string.Empty;
    private string strToDate = string.Empty;

    private int intProfileID = -1;
    private int intCountryID = -1;

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

    private void GetSellLead_BuyerList()
    {
        this.strFromDate = ddlStartMonth1.SelectedItem.Value + "/" + ddlStartDay1.SelectedItem.Value + "/" + ddlStartYear1.SelectedItem.Value;
        this.strToDate = ddlEndMonth1.SelectedItem.Value + "/" + ddlEndDay1.SelectedItem.Value + "/" + ddlEndYear1.SelectedItem.Value;

        using (BOC_Corporate_ProdProf_GeneralItems bocProductProfile = new BOC_Corporate_ProdProf_GeneralItems())
        {
            EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

            eocPropertyBean.Business_UserProfile_ProfileID = intProfileID;
            eocPropertyBean.FromDate = Convert.ToDateTime(strFromDate);
            eocPropertyBean.ToDate = Convert.ToDateTime(strToDate);

            grvSellLead01.DataSource = bocProductProfile.SellLead_Set01_BuyerList_General(eocPropertyBean);
            grvSellLead01.DataBind();
        }

        Session["SELL_LEAD_FROMDATE"] = strFromDate;
        Session["SELL_LEAD_TODATE"] = strToDate;
    }
    private void GetSellLead_ProductList()
    {
        this.strFromDate = ddlStartMonth1.SelectedItem.Value + "/" + ddlStartDay1.SelectedItem.Value + "/" + ddlStartYear1.SelectedItem.Value;
        this.strToDate = ddlEndMonth1.SelectedItem.Value + "/" + ddlEndDay1.SelectedItem.Value + "/" + ddlEndYear1.SelectedItem.Value;

        using (BOC_Corporate_ProdProf_GeneralItems bocProductProfile = new BOC_Corporate_ProdProf_GeneralItems())
        {
            EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

            eocPropertyBean.Business_UserProfile_ProfileID = intProfileID;
            eocPropertyBean.FromDate = Convert.ToDateTime(strFromDate);
            eocPropertyBean.ToDate = Convert.ToDateTime(strToDate);

            grvSellLead02.DataSource = bocProductProfile.SellLead_Set02_ProductList_General(eocPropertyBean);
            grvSellLead02.DataBind();
        }

        Session["SELL_LEAD_FROMDATE"] = strFromDate;
        Session["SELL_LEAD_TODATE"] = strToDate;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();

        UTLUtilities.BuildDateControl(ddlStartDay1, ddlStartMonth1, ddlStartYear1);
        UTLUtilities.BuildDateControl(ddlEndDay1, ddlEndMonth1, ddlEndYear1);

        UTLUtilities.CP_ActiveModule = 4;
    }

    protected void btnSellLead1_Click(object sender, EventArgs e)
    {
        this.GetSellLead_BuyerList();
        this.GetSellLead_ProductList();        
    }
    protected void grvSellLead01_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvSellLead01.PageIndex = e.NewPageIndex;
            this.GetSellLead_BuyerList();
        }
        catch (Exception Exp)
        {
            Response.Write(Exp.Message.ToString());
        }
    }
}
