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

public partial class Common_ShoppingCart : System.Web.UI.Page
{
    DataTable dtCartItems;
    private int intProductID = -1;
    private string strProductID = string.Empty;
    private string strCategoryID = string.Empty;
    private int intProductSellerDetailID = -1;
    private string strProductSellerDetailID = string.Empty;


    private void PopulateControls()
    {
        //this.Title = ShopConfiguration.SiteName + " : Shopping Cart";
        // get the items in the shopping cart
        
        try
        {
            using (ShoppingCartAccess cart = new ShoppingCartAccess())
            {
                dtCartItems = new DataTable();
                dtCartItems = cart.LoadList_ShoppingCartItems();
                DataTable dtAmount = cart.ShoppingCart_GetTotalAmount();
                if (dtAmount.Rows.Count > 0)
                {
                    lblTotalAmount.Text = "<span class=\"price\">" + dtAmount.Rows[0]["TotalAmount"].ToString() + "</span>";

                    lblCurrency.Text = "<span class=\"price\">" + dtAmount.Rows[0]["Currency"].ToString() + "</span>";
                }
            }

        }
        catch(Exception ex)
        {
            lblSystemMessage.Text = "Error: " + ex.Message;
        }
        // if the shopping cart is empty...
        if (dtCartItems.Rows.Count == 0)
        {
            titleLabel.Text = "<span class=\"pagetitle\">Your shopping cart is empty!</span>";
            grid.Visible = false;
            btnUpdate.Enabled = false;
            btnCheckOut.Enabled = false;
            lblTotalAmount.Text = "";
            lblCurrency.Text = "";
            //lblTotalAmount.Text = String.Format("{0:c}", 0);
        }
        else 
        {
            grid.DataSource = dtCartItems;
            grid.DataBind();
            titleLabel.Text = "<span class=\"pagetitle\">These are the products in your shopping cart:</span>";
            grid.Visible = true;
            btnUpdate.Enabled = true;
            btnCheckOut.Enabled = true;
        }
     
    }

  

    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowIndex = e.RowIndex;
        
        strProductID = grid.DataKeys[rowIndex]["ProductID"].ToString();
        strProductSellerDetailID = grid.DataKeys[rowIndex]["ProductSellerDetailID"].ToString();



        if (Int32.TryParse(strProductID, out intProductID) && Int32.TryParse(strProductSellerDetailID, out intProductSellerDetailID))
        {
            try
            {
                using(ShoppingCartAccess cart = new ShoppingCartAccess())
                {
                    bool success = cart.ShoppingCart_RemoveItem(intProductID, intProductSellerDetailID);
                    lblStatus.Text = success ? "<br />Product successfully removed!<br />" : "<br />There was an error removing the product!<br />";
                }
            }
            catch (Exception ex)
            {
                lblSystemMessage.Text = "Error:" + ex.Message;
            }
        }
        
        PopulateControls();
    }
   

    // Redirects to the previously visited catalog page
    // (an alternate to the functionality implemented here is to
    // Request.UrlReferrer, although that way you have no control over
    // what pages you forward your visitor back to)
   
    protected void btnContinueShopping_Click(object sender, EventArgs e)
    {
        // redirect to the last visited catalog page, or to the
        // main page of the catalog
        object page;
        if ((page = Session["LastVisitedCatalogPage"]) != null)
            Response.Redirect(page.ToString());
        else
            Response.Redirect(Request.ApplicationPath);
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        string strTotalAmount = string.Empty;
        string strOrderID = string.Empty;
        bool success = false;
        try
        {
            using (ShoppingCartAccess shoppingCart = new ShoppingCartAccess())
            {
                DataTable dtTotalAmount = shoppingCart.ShoppingCart_GetTotalAmount();
                strOrderID = shoppingCart.ShoppingCart_CreateOrder(rbtnPaymentOption.SelectedValue);
                if (dtTotalAmount.Rows.Count > 0)
                {
                    strTotalAmount = dtTotalAmount.Rows[0]["TotalAmount"].ToString();
                    success = true;
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = "Error: " + ex.Message;
        }
        if (success)
        {
            this.Session["PAYMENT_OPTION"] = rbtnPaymentOption.SelectedItem.Text;
            this.Session["ORDER_ID"] = strOrderID;
            Response.Redirect("Default.aspx");
        }
        else 
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        int rowsCount = grid.Rows.Count;
        GridViewRow gridRow;
        TextBox quantityTextBox;

        int quantity;
        bool success = true;
        for (int i = 0; i < rowsCount; i++)
        {
            gridRow = grid.Rows[i];
            strProductID = grid.DataKeys[i]["ProductID"].ToString();
            strProductSellerDetailID = grid.DataKeys[i]["ProductSellerDetailID"].ToString();
            quantityTextBox = (TextBox)gridRow.FindControl("txtQuantity");

            if (Int32.TryParse(quantityTextBox.Text, out quantity) && Int32.TryParse(strProductID, out intProductID) && Int32.TryParse(strProductSellerDetailID, out intProductSellerDetailID))
            {
                try
                {
                    using (ShoppingCartAccess cart = new ShoppingCartAccess())
                    {
                        success = success && cart.ShoppingCart_UpdateItem(intProductID, intProductSellerDetailID, quantity);

                    }
                }
                catch (Exception ex)
                {
                    success = false;
                    lblSystemMessage.Text = "Error:" + ex.Message;
                }
            }
            else
            {
                success = false;
            }
            lblStatus.Text = success ?
                        "<br />Your shopping cart was successfully updated!<br />" :
                        "<br />Some quantity updates failed! Please verify your cart!<br />";
        }
        // Repopulate the control
        PopulateControls();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.PopulateControls();
        }
    }
}
