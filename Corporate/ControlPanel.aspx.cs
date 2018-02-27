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

public partial class Corporate_ControlPanel : System.Web.UI.Page
{
    private int intProfileID = -1;
    private int intCountryID = -1;
    private bool _BusinessUser = true;

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

    private void LoadList_PostedProduct()
    {
        try 
        {
            using(BC_Product bc = new BC_Product())
            {
                DataTable dt = new DataTable();
                dt = bc.GetList_BS_PostedProduct(intProfileID, _BusinessUser);
                if (dt.Rows.Count > 0)
                {
                    grvProductProfile.DataSource = dt;
                    grvProductProfile.DataBind();
                }
                else
                {
                    lblSystemMessage.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
                    lblSystemMessage.Text += "<tr>";
                    lblSystemMessage.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    lblSystemMessage.Text += "<span class=\"title\" style=\"font-size:14px;\">";
                    lblSystemMessage.Text += "</span> You have not posted any Corporate Ads yet.";
                    lblSystemMessage.Text += "</td>";
                    lblSystemMessage.Text += "</tr>";
                    lblSystemMessage.Text += "</table>";
                    //lblSystemMessage.Text = "No previously posted ad found.";
                }

            }
        }
        catch(Exception ex)
        {
            lblSystemMessage.Text = ex.Message.ToString();
        }
    }


    /// <summary>
    /// Loads all  Corporate Product Order detail that this specific user has placed.
    /// </summary>
    /// <param name="intProfileID"></param>
    /// <param name="userType"></param>
    private void LoadList_PlacedOrder_Corporate_Product()
    {
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {

                DataTable dt = bcProduct.LoadList_PlacedOrder_CorporateProduct(intProfileID, _BusinessUser);

                if (dt.Rows.Count > 0)
                {
                    grvCorporateOrderList.DataSource = dt;
                    grvCorporateOrderList.DataBind();
                }
                else
                {
                    lblCorporateOrderMessage.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
                    lblCorporateOrderMessage.Text += "<tr>";
                    lblCorporateOrderMessage.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    lblCorporateOrderMessage.Text += "<span class=\"title\" style=\"font-size:14px;\">";
                    lblCorporateOrderMessage.Text += "</span> You have not placed any Corporate Product order yet.";
                    lblCorporateOrderMessage.Text += "</td>";
                    lblCorporateOrderMessage.Text += "</tr>";
                    lblCorporateOrderMessage.Text += "</table>";
                    //lblCorporateOrderMessage.Text = "You have not placed any Corporate Product order yet.";
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = "Error: " + Exp.Message;
        }
    }

    /// <summary>
    /// Returns the Full PaymentOption Name.
    /// </summary>
    /// <param name="objPaymentMethod"></param>
    /// <returns></returns>
    public string GetPaymentMethod(object objPaymentMethod)
    {
        string strPaymentOption = (string)objPaymentMethod;
        if (strPaymentOption == "PFS")
        {
            return "Pick From Store.";
        }
        else
        {
            return "Cash On Delivery.";
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();

        UTLUtilities.CP_ActiveModule = 1;
        if (!Page.IsPostBack)
        {
            this.LoadList_PostedProduct();
            this.LoadList_PlacedOrder_Corporate_Product();
        }
    }
    protected void grvProductProfile_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvProductProfile.PageIndex = e.NewPageIndex;
            this.LoadList_PostedProduct();
        }
        catch (Exception Exp)
        {
            Response.Write(Exp.Message.ToString());
        }
    }
    protected void grvProductProfile_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[1].Visible = false;
        //e.Row.Cells[2].Visible = false;
        //e.Row.Cells[3].Visible = false;
        //e.Row.Cells[4].Visible = false;
    }

    protected void grvCorporateOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvCorporateOrderList.PageIndex = e.NewPageIndex;
            this.LoadList_PlacedOrder_Corporate_Product();
        }
        catch (Exception Exp)
        {
            lblCorporateOrderMessage.Text = "Error: " + Exp.Message;
        }
    }

    protected void grvCorporateOrderList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //HyperLink link = (HyperLink)e.Row.FindControl("lnkTitle");

            //link.Target = "_blank";
            //link.NavigateUrl = "../Common/ItemDetail_Books.aspx?data=VP6Nn3l/k9q2inF53TZw5PHUSIMcZ7QyS22x+1EUCVH7DyrTazU7obaCB9/GS186bg8B51AYynEAhSWdzg21aiQgGFO1b2Fo";
            //string url = "../Common/ItemDetail_Books.aspx?data=VP6Nn3l/k9q2inF53TZw5PHUSIMcZ7QyS22x+1EUCVH7DyrTazU7obaCB9/GS186bg8B51AYynEAhSWdzg21aiQgGFO1b2Fo";
            //string fullUrl = "window.open('" + url + "', '_blank', 'height=500,width=700,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
            //link.Attributes.Add("OnClick", fullUrl);
            //string s = DataBinder.Eval(grvCorporateOrderList, grvCorporateOrderList.Rows[e.Row.RowIndex].Cells[1]);
        }


        //string url = "MyNewPage.aspx?ID=1&cat=test";
        //string fullUrl = "window.open('" + url + "', '_blank', 'height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";


    }
}
