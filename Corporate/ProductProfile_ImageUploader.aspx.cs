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

public partial class Corporate_ProductProfile_ImageUploader : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string productID = string.Empty;
        string imagePath = string.Empty;
        string itemType = string.Empty;
        int intActionResult = 0;

        productID = Request.QueryString["PID"];
        itemType = Request.QueryString["ItemType"];

        if (!string.IsNullOrEmpty(productID) && !string.IsNullOrEmpty(itemType))
        {
            if (UTLUtilities.IsNumeric(productID))
            {
                //GENERAL ITEMS:
                if (itemType == "GenItem")
                {
                    imagePath = @"ImageHolder\GeneralItems\" + productID + ".jpg";

                    if (FileUpload1.HasFile)
                    {
                        FileUpload1.SaveAs(Server.MapPath(@"..\ImageHolder\GeneralItems\") + productID + ".jpg");
                    }

                    using (BOC_Corporate_ProdProf_GeneralItems bocProductProfile1 = new BOC_Corporate_ProdProf_GeneralItems())
                    {
                        EOC_PropertyBean eocPropertyBean1 = new EOC_PropertyBean();
                        eocPropertyBean1.Business_ProductProfile_GeneralItems_ProductID = Convert.ToInt32(productID);
                        eocPropertyBean1.Business_ProductProfile_GeneralItems_ProductImage = imagePath;

                        intActionResult = bocProductProfile1.UpdateRecord_ProductImage(eocPropertyBean1);

                        if (intActionResult > 0)
                        {
                            Response.Redirect("ProductProfile_General.aspx");
                        }
                    }
                }

                //BOOKS:
                if (itemType == "Book")
                {
                    imagePath = @"ImageHolder\Books\" + productID + ".jpg";

                    if (FileUpload1.HasFile)
                    {
                        FileUpload1.SaveAs(Server.MapPath(@"..\ImageHolder\Books\") + productID + ".jpg");
                    }

                    using (BOC_Corporate_ProdProf_Book bocProductProfile2 = new BOC_Corporate_ProdProf_Book())
                    {
                        EOC_PropertyBean eocPropertyBean2 = new EOC_PropertyBean();
                        eocPropertyBean2.Business_ProductProfile_Books_ProductID = Convert.ToInt32(productID);
                        eocPropertyBean2.Business_ProductProfile_Books_ProductImage = imagePath;

                        intActionResult = bocProductProfile2.UpdateRecord_ProductImage(eocPropertyBean2);

                        if (intActionResult > 0)
                        {
                            Response.Redirect("ProductProfile_Books.aspx");
                        }
                    }
                }
            }
        }
    }
}
