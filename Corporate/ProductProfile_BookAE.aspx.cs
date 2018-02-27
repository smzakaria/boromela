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
using System.IO;

public partial class Corporate_ProductProfile_BookAE : System.Web.UI.Page
{

    //private bool canEditProduct = false;
    //private bool isTitleRejected = false;
    private int intProductID = -1;
    private int intProfileID = -1;
    private int intCountryID = -1;
    private int intPageMode = -1;
    

    private string businessSeller = "1";
    private int intCategoryID = -1;
    private int intSubcategoryID = -1;
    private int intSecondSubcatID = -1;
    private string strMasterInsert = "1";
    private string strTagInsert = "0";
    private bool selected = true;
    private bool unSelected = false;


    //private bool enable = true;
    //private bool disable = false;
    //private bool canEdit = false;


    private string imagePath = string.Empty;

    private void CheckUserSession()
    {

        if (this.Session["CORP_PROFILE_CODE"] != null && this.Session["CORP_COUNTRY_CODE"] != null)
        {
            intProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"].ToString());
            intCountryID = Convert.ToInt32(this.Session["CORP_COUNTRY_CODE"].ToString());
        }
        else
        {
            Response.Redirect("Default.aspx", false);
        }
    }

    /// <summary>
    /// Inserts a new row for Book both in Product_Master and Product_Seller_Detail table.
    /// </summary>
    /// <returns></returns>
    private int Add_MasterRecord_BookProduct()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_ProdProf_Book bocProductProfile = new BOC_Corporate_ProdProf_Book())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_ProfileID = Convert.ToInt32(txtProfileID.Text);
                eocPropertyBean.Category_CategoryID = Convert.ToInt32(txtCategoryID.Text);
                eocPropertyBean.Subcategory_SubcategoryID = Convert.ToInt32(txtSubcategoryID.Text);
                eocPropertyBean.SecondSubcategory_SubcategoryID = Convert.ToInt32(txtSecondSubcatID.Text);

                eocPropertyBean.Business_ProductProfile_Books_BookTitle = lblProductTitle.Text;
                eocPropertyBean.Business_ProductProfile_Books_SKU = lblSku.Text;
                eocPropertyBean.Business_ProductProfile_Books_BookDescription = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Books_Quantity = Convert.ToInt32(lblQuantity.Text);

                eocPropertyBean.Business_ProductProfile_Books_Currency = lblCurrency.Text;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(lblProductPrice.Text);

                if (lblSalePrice.Text != "")
                {
                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = Convert.ToDouble(lblSalePrice.Text);
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = Convert.ToDateTime(lblSaleFromDate.Text);
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = Convert.ToDateTime(lblSaleToDate.Text);
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;
                }

                eocPropertyBean.Business_Product_Profile_Books_Condition = lblCondition.Text;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;
                eocPropertyBean.Business_ProductProfile_Books_PaymentOption = ddlPaymentOption.SelectedValue;
                eocPropertyBean.Business_ProductProfile_Books_DeliveryArea = ddlDeliveryArea.SelectedItem.Text;

                if (ddlPaymentOption.SelectedValue == "COD")
                {
                    eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost = Convert.ToDouble(txtCODCost.Text);
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost = 0.00;

                }


                eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = txtPaperBack.Text;
                eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguage.Text;
                eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDimensionForBook.Text;
                eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShippingWeight.Text;
                eocPropertyBean.Business_ProductProfile_Books_Edition = txtEdition.Text;
                eocPropertyBean.Business_ProductProfile_Books_ISBN = txtISBN.Text;
                eocPropertyBean.Business_ProductProfile_Books_Author = txtAuthor.Text;
                eocPropertyBean.Business_ProductProfile_Books_Publisher = txtPublisher.Text;

                if (string.IsNullOrEmpty(txtImagePath.Text))
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"../Corporate_ProductImage/default.png";
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = txtImagePath.Text;
                }

                eocPropertyBean.UserType = businessSeller;

                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkIsActive.Checked;

                intActionResult = bocProductProfile.Insert_MasterRecord_BookProduct(eocPropertyBean);

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
        return intActionResult;
    }

    /// <summary>
    /// Inserts a new row for Book in Product_Seller_Detail table.
    /// </summary>
    private int Add_DetailRecord_BookProduct()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_ProdProf_Book bocProductProfile = new BOC_Corporate_ProdProf_Book())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_ProfileID = Convert.ToInt32(txtProfileID.Text);
                eocPropertyBean.Business_ProductProfile_Books_ProductID = Convert.ToInt32(txtProductID.Text);

                eocPropertyBean.Business_ProductProfile_Books_SKU = lblSku.Text;
                eocPropertyBean.Business_ProductProfile_Books_BookDescription = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Books_Quantity = Convert.ToInt32(lblQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = lblCurrency.Text;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(lblProductPrice.Text);

                if (lblSalePrice.Text != "")
                {
                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = Convert.ToDouble(lblSalePrice.Text);
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = Convert.ToDateTime(lblSaleFromDate.Text);
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = Convert.ToDateTime(lblSaleToDate.Text);
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;
                }

                eocPropertyBean.Business_Product_Profile_Books_Condition = lblCondition.Text;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                eocPropertyBean.Business_ProductProfile_Books_PaymentOption = ddlPaymentOption.SelectedValue;
                eocPropertyBean.Business_ProductProfile_Books_DeliveryArea = ddlDeliveryArea.SelectedItem.Text;

                if (ddlPaymentOption.SelectedValue == "COD")
                {
                    eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost = Convert.ToDouble(txtCODCost.Text);
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost = 0.00;
                }


                eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = txtPaperBack.Text;
                eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguage.Text;
                eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDimensionForBook.Text;
                eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShippingWeight.Text;


                eocPropertyBean.UserType = businessSeller;

                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkIsActive.Checked;

                intActionResult = bocProductProfile.Insert_DetailRecord_BookProduct(eocPropertyBean);
                if (intActionResult > 0)
                {
                    Response.Redirect("ControlPanel.aspx", false);
                }
                else
                {
                    lblSystemMessage.Text = "Error occured while saving record.";
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
        return intActionResult;
    }


    /// <summary>
    /// Selects PaperBackForBook,DimensionForBook, ShippingWeight,ISBN, Author,Publisher,
    ///	Edition and CanEditProduct from Product_Master_Book table.
    /// For Tag users. Will be used in case of Editing a book.
    /// USP: USP_CP_Select_Specific_BookRecord
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <param name="productID"></param>
    /// <param name="profileID"></param>
    private void Select_BookRecord(int categoryID, int subcategoryID, int secondSubcatID, int productID, int profileID)
    {
        DataTable dt = new DataTable();
        string strIsActive = null;
        bool _BusinessSeller = true;
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                dt = bcProduct.Select_BookRecord(categoryID, subcategoryID, secondSubcatID, profileID, productID, _BusinessSeller);
                if (dt.Rows.Count > 0)
                {
                    txtPaperBack.Text = dt.Rows[0]["PaperBackForBook"].ToString();
                    txtLanguage.Text = dt.Rows[0]["Language"].ToString();
                    txtDimensionForBook.Text = dt.Rows[0]["DimensionForBook"].ToString();
                    txtShippingWeight.Text = dt.Rows[0]["ShippingWeight"].ToString();
                    txtISBN.Text = dt.Rows[0]["ISBN"].ToString();
                    txtAuthor.Text = dt.Rows[0]["Author"].ToString();
                    txtPublisher.Text = dt.Rows[0]["Publisher"].ToString();
                    txtEdition.Text = dt.Rows[0]["Edition"].ToString();
                    txtCanEdit.Text = dt.Rows[0]["CanEditProduct"].ToString();
                    strIsActive = dt.Rows[0]["IsActive"].ToString();
                    chkIsActive.Checked = (strIsActive == "True") ? selected : unSelected;
                    ddlPaymentOption.SelectedValue = dt.Rows[0]["PaymentOption"].ToString();
                    txtImagePath.Text = dt.Rows[0]["ProductImage"].ToString();
                    //if (dt.Rows[0]["ProductImage"].ToString() == "../Corporate_ProductImage/default.png")
                    //{
                    //    lblIsFileUploaded.Text = "true";
                    //}
                    //else
                    //{
                    //    lblIsFileUploaded.Text = "false";
                    //}

                    if (ddlPaymentOption.SelectedValue == "COD")
                    {
                        panelDeliveryOption.Visible = true;
                        panelDeliveryOption.Enabled = true;
                        txtCODCost.Text = dt.Rows[0]["CodCost"].ToString();
                        ddlDeliveryArea.SelectedItem.Text = dt.Rows[0]["DeliveryArea"].ToString();
                    }
                    else
                    {
                        panelDeliveryOption.Visible = false;
                        panelDeliveryOption.Enabled = false;
                    }

                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

    }

    /// <summary>
    /// Selects ISBN, Author, Publisher name from Product_Master_Book table.
    /// For Tag users. Will be used in case of Adding a book.
    /// USP: USP_CP_Get_MasterBookRecord
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <param name="profileID"></param>
    /// <param name="productID"></param>
    private void Select_MasterBookRecord(int categoryID, int subcategoryID, int secondSubcatID, int profileID, int productID)
    {
        DataTable dt = new DataTable();
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                dt = bcProduct.SelectSpecific_MasterBookRecord(categoryID, subcategoryID, secondSubcatID, productID);
                if (dt.Rows.Count > 0)
                {
                    txtISBN.Text = dt.Rows[0]["ISBN"].ToString();
                    txtAuthor.Text = dt.Rows[0]["Author"].ToString();
                    txtPublisher.Text = dt.Rows[0]["Publisher"].ToString();
                    txtEdition.Text = dt.Rows[0]["Edition"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// check = 'True', disables the Master Entry field
    /// </summary>
    /// <param name="check"></param>
    private void Block_MasterField(bool check)
    {
        //txtPaperBack.ReadOnly = check;
        txtISBN.ReadOnly = check;
        txtAuthor.ReadOnly = check;
        txtEdition.ReadOnly = check;
        txtPublisher.ReadOnly = check;
        FileUpload1.Visible = !check;
        btnUpload.Visible = !check;
        lblUpload.Visible = !check;
      
        if (txtCanEdit.Text == txtProfileID.Text)
        {
            txtISBN.ReadOnly = !check;
            txtAuthor.ReadOnly = !check;
            FileUpload1.Visible = check;
            btnUpload.Visible = check;
            lblUpload.Visible = check;
        }
    }

    private void GetPreviousPage_Property()
    {
        if (Page.PreviousPage != null && Page.PreviousPage.IsValid)
        {

            if (Page.PreviousPage.IsCrossPagePostBack)
            {
                #region Retrieving Previous Page Value
                
                lblSku.Text = PreviousPage.GetSku;
                txtPageMode.Text = PreviousPage.GetPageMode;
                txtProductID.Text = (string.IsNullOrEmpty(PreviousPage.GetProductID)) ? "-" : PreviousPage.GetProductID;
                txtProfileID.Text = PreviousPage.GetProfileID;
                txtCategoryID.Text = PreviousPage.GetCategoryID;
                txtSubcategoryID.Text = PreviousPage.GetSubcategoryID;
                txtSecondSubcatID.Text = PreviousPage.GetSecondSubcategoryID;
                hfInsertType.Value = PreviousPage.GetInsertType;

                lblProductTitle.Text = PreviousPage.GetProductTitle;
                lblCategory.Text = PreviousPage.GetCategory;
                lblSubcategory.Text = PreviousPage.GetSubcategory;
                lblSecondSubcategory.Text = PreviousPage.GetSecondSubcategory;

                txtDescription.Text = (string.IsNullOrEmpty(PreviousPage.GetDescription)) ? "-" : PreviousPage.GetDescription;

                lblQuantity.Text = PreviousPage.GetQuantity;


                lblProductPrice.Text = PreviousPage.GetProductPrice;
                lblSalePrice.Text = PreviousPage.GetSalePrice;
                lblCurrency.Text = PreviousPage.GetCurrency;
                lblSaleFromDate.Text = PreviousPage.GetSaleFromDate;
                lblSaleToDate.Text = PreviousPage.GetSaleTodate;
                lblCondition.Text = PreviousPage.GetCondition;
                txtConditionNote.Text = string.IsNullOrEmpty(PreviousPage.GetConditionNote) ? "-" : PreviousPage.GetConditionNote;
                txtCanEdit.Text = PreviousPage.CanEditMasterRecord;
                
                #endregion End of Retrieving Previous Page Value

                intProductID = Convert.ToInt32(txtProductID.Text);
                intPageMode = Convert.ToInt32(txtPageMode.Text);
                intProfileID = Convert.ToInt32(txtProfileID.Text);
                intCategoryID = Convert.ToInt32(txtCategoryID.Text);
                intSubcategoryID = Convert.ToInt32(txtSubcategoryID.Text);
                intSecondSubcatID = Convert.ToInt32(txtSecondSubcatID.Text);


                SetReadOnlyProperty(txtDescription, true);
                SetReadOnlyProperty(txtConditionNote, true);

                
            }
        }
    }

    
    /// <summary>
    /// Updates Book Record of the Master Seller.
    /// </summary>
    /// <returns></returns>
    private int Update_MasterSeller_BookRecord()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_ProdProf_Book bocProductProfile = new BOC_Corporate_ProdProf_Book())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_ProfileID = Convert.ToInt32(txtProfileID.Text);
                eocPropertyBean.Business_ProductProfile_Books_ProductID = Convert.ToInt32(txtProductID.Text);
                eocPropertyBean.Category_CategoryID = Convert.ToInt32(txtCategoryID.Text);
                eocPropertyBean.Subcategory_SubcategoryID = Convert.ToInt32(txtSubcategoryID.Text);
                eocPropertyBean.SecondSubcategory_SubcategoryID = Convert.ToInt32(txtSecondSubcatID.Text);

                eocPropertyBean.Business_ProductProfile_Books_BookDescription = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Books_Quantity = Convert.ToInt32(lblQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = lblCurrency.Text;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(lblProductPrice.Text);

                if (lblSalePrice.Text != "")
                {
                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = Convert.ToDouble(lblSalePrice.Text);
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = Convert.ToDateTime(lblSaleFromDate.Text);
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = Convert.ToDateTime(lblSaleToDate.Text);
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;
                }

                eocPropertyBean.Business_Product_Profile_Books_Condition = lblCondition.Text;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;
                eocPropertyBean.Business_ProductProfile_Books_PaymentOption = ddlPaymentOption.SelectedValue;
                if (ddlPaymentOption.SelectedValue == "COD")
                {
                    eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost = Convert.ToDouble(txtCODCost.Text);
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost = 0.00;
                }

                if (string.IsNullOrEmpty(txtImagePath.Text))
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"../Corporate_ProductImage/default.png";
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = txtImagePath.Text;
                }

                eocPropertyBean.Business_ProductProfile_Books_DeliveryArea = ddlDeliveryArea.SelectedItem.Text;

                eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = txtPaperBack.Text;
                eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguage.Text;
                eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDimensionForBook.Text;
                eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShippingWeight.Text;
                eocPropertyBean.Business_ProductProfile_Books_ISBN = txtISBN.Text;

                eocPropertyBean.Business_ProductProfile_Books_Author = txtAuthor.Text;
                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkIsActive.Checked;
                eocPropertyBean.UserType = "1";

                intActionResult = bocProductProfile.Update_MasterSeller_BookProduct(eocPropertyBean);

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }

    /// <summary>
    /// Updates Book Record of the tag seller.
    /// </summary>
    /// <returns></returns>
    private int Update_TagSeller_BookRecord()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_ProdProf_Book bocProductProfile = new BOC_Corporate_ProdProf_Book())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Business_UserProfile_ProfileID = Convert.ToInt32(txtProfileID.Text);
                eocPropertyBean.Business_ProductProfile_Books_ProductID = Convert.ToInt32(txtProductID.Text);

                eocPropertyBean.Business_ProductProfile_Books_BookDescription = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Books_Quantity = Convert.ToInt32(lblQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = lblCurrency.Text;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(lblProductPrice.Text);

                if (lblSalePrice.Text != "")
                {
                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = Convert.ToDouble(lblSalePrice.Text);
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = Convert.ToDateTime(lblSaleFromDate.Text);
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = Convert.ToDateTime(lblSaleToDate.Text);
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;
                }

                eocPropertyBean.Business_Product_Profile_Books_Condition = lblCondition.Text;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;
                eocPropertyBean.Business_ProductProfile_Books_PaymentOption = ddlPaymentOption.SelectedValue;
                eocPropertyBean.Business_ProductProfile_Books_DeliveryArea = ddlDeliveryArea.SelectedItem.Text;
                if (ddlPaymentOption.SelectedValue == "COD")
                {
                    eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost = Convert.ToDouble(txtCODCost.Text);
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost = 0.00;
                }
                


                eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = txtPaperBack.Text;
                eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguage.Text;
                eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDimensionForBook.Text;
                eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShippingWeight.Text;


                eocPropertyBean.UserType = businessSeller;

                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkIsActive.Checked;

                intActionResult = bocProductProfile.Update_TagSeller_BookRecord(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;

    }




    protected void btnUpload_Click(object sender, EventArgs e)
    {
        btnUpload.Enabled = false;
        intCategoryID = Convert.ToInt32(txtCategoryID.Text);
        if (intCategoryID == 1)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string strFileName = DateTime.Now.ToString("hh.mm.ss");
                    strFileName += "_" + DateTime.Today.Day.ToString();
                    strFileName += "." + DateTime.Today.Month.ToString();
                    strFileName += "." + DateTime.Now.Year.ToString();

                    string fileName = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath(@"../Prdcts/books/" + txtProfileID.Text + "_BS_" + strFileName + "_" + fileName));
                    imagePath = @"../Prdcts/books/" + txtProfileID.Text + "_BS_" + strFileName + "_" + fileName;
                    lblImageUploadMessage.Text = "Image uploaded.";
                    txtImagePath.Text = imagePath;

                }
                catch (Exception ex)
                {

                    lblSystemMessage.Text = "Error occured while uploading the image." + ex.Message;
                }
            }
            else
            {
                lblImageUploadMessage.Text = "Please browse an image.";
            }
        }
        btnUpload.Enabled = true;
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        intProductID = Convert.ToInt32(txtProductID.Text);
        intPageMode = Convert.ToInt32(txtPageMode.Text);

        int intActionResult = -1;
        if (intPageMode == 0)
        {
            if (intPageMode == 0 && hfInsertType.Value == "master")
            {
                intActionResult = this.Add_MasterRecord_BookProduct();

            }
            if (intPageMode == 0 && hfInsertType.Value == "tag")
            {
                intActionResult = this.Add_DetailRecord_BookProduct();
            }
            if (intActionResult > 0)
            {
                Response.Redirect("ControlPanel.aspx", false);
            }
            else
            {
                lblSystemMessage.Text = "Error occured while saving record.";
            }
        }
        if (intPageMode == 1 && intProductID > 0)
        {
            if (txtCanEdit.Text== intProfileID.ToString())
            {
                intActionResult = this.Update_MasterSeller_BookRecord();
            }
            else
            {
                intActionResult = this.Update_TagSeller_BookRecord();
            }
            if (intActionResult > 0)
            {
                Response.Redirect("ControlPanel.aspx", false);
            }
            else
            {
                lblSystemMessage.Text = "Error occured while saving record.";
            }
        }



    }

    /// <summary>
    /// Activates/Deactivates payment option
    /// </summary>
    /// <param name="isActive">If true makes the payment option visible and enable, and vice versa.</param>
    //private void Activate_PaymentOption(bool isActive)
    //{
    //    lblDeliveryArea.Visible = isActive;
    //    ddlDeliveryArea.Visible = isActive;
    //    lblCodCost.Visible = isActive;
    //    txtCODCost.Visible = isActive;

    //    rfvCodCost.Enabled = isActive;
    //    rfvCodCost.Visible = isActive;
    //    //hfDeliveryArea.Value = isActive ? ddlDeliveryArea.SelectedItem.Text : "";
    //    //hfCodCost.Value = isActive ? txtCODCost.Text : "";

    //}

    protected void ddlPaymentOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaymentOption.SelectedItem.Value == "COD")
        {
            panelDeliveryOption.Enabled = true;
            panelDeliveryOption.Visible = true;
        }
        else
        {
            panelDeliveryOption.Enabled = false;
            panelDeliveryOption.Visible = false;
        }
    }

    /// <summary>
    /// Enables or disables buttons.
    /// </summary>
    /// <param name="btn"></param>
    /// <param name="isEnable"></param>
    private void SetReadOnlyProperty(TextBox txtBox, bool isEnable)
    {
        txtBox.ReadOnly = isEnable;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();
        if (!Page.IsPostBack)
        {
            panelDeliveryOption.Enabled = false;
            panelDeliveryOption.Visible = false;
        }
        try
        {
            this.GetPreviousPage_Property();
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = "Error: " + ex.Message;
        }

        if (intPageMode == 0)
        {
            switch (hfInsertType.Value)
            {
                case "master":
                    {
                        this.Block_MasterField(false);
                        break;
                    }
                case "tag":
                    {
                        this.Select_MasterBookRecord(intCategoryID, intSubcategoryID, intSecondSubcatID, intProfileID, intProductID);
                        this.Block_MasterField(true);
                        break;
                    }
            }
        }
        if (intPageMode == 1 && intProductID > 0)
        {
            this.Select_BookRecord(intCategoryID, intSubcategoryID, intSecondSubcatID, intProfileID, intProductID);
            this.Block_MasterField(true);
        }

    }
 
}
