<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="ProductProfile_BookAE.aspx.cs" Inherits="Corporate_ProductProfile_BookAE" Title="www.boromela.com – Book." %>
<%@ PreviousPageType VirtualPath="~/Corporate/ProductProfileAE.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function IsDigit(e)
    {
        var key;
        if (window.event)
        {
            key = window.event.keyCode;
        }
        else if (e)
        {
            key = e.which;
        }
        else
        {
            return true;
        }
        if ((key > 47 && key < 58) || (key > 95 && key < 106))
        {
            return true;
        }
        if ( key==null || key==0 || key==8 || key==9 || key==13 || key==27 || key ==37 || key ==39 || key == 46 || key == 35 || key == 36)
        {
            return true;
        }

        return false;
    }        
    function isNumberKey(evt)      
    {         
        var charCode = (evt.which) ? evt.which : event.keyCode         
        if (charCode > 31 && (charCode < 48 || charCode > 57))            
            return true;         
        return false;      
    }


    </script>

<script type="text/javascript">
	function GoBack()
	{
	history.go(-1);
	
	}
</script>


<span class="pageTitle">Corporate - Add/Edit Book Information.</span>
<br /><br />
<table width="100%" border="0" cellspacing="0" cellpadding="0">
   <tr>
   <td>&nbsp;</td>
   <td align="right">Fields marked by <span class="mandatory">*</span> are mandatory</td>
   </tr>
   
   <tr>
   <td colspan="2" align="left" style="font-size:11px;">
   <asp:ValidationSummary 
        ID="ValidationSummary1" 
        runat="server" 
        Width="500px" 
        BackColor="#FFFFFF" 
        ForeColor="Black" 
        Font-Bold="False" 
        HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>" 
        BorderStyle="Dashed" 
        BorderWidth="1px" 
        Font-Size="11px"/> 
   <asp:Label 
        ID="lblSystemMessage" 
        runat="server" 
        ForeColor="Red" 
        EnableViewState="False" 
        Width="500px" 
        Font-Size="11px">
   </asp:Label>                                        
   </td>
   </tr>
</table>

<table cellspacing="0" cellpadding="0" border="0" width="600px" style="border-bottom: 1px solid rgb(213, 213, 213);">
    <tbody>
    <tr>
    <td width="3" style="height: 30px">
    <img height="28" width="3" src="../Images/title_bar_left.gif"/>
    </td>
    <td width="600px" style="background-image: url(../Images/title_bar_bg.gif); background-repeat: repeat-x; padding-left: 5px; height: 30px;">
    <strong>Product General Information</strong></td>
    <td style="width: 3px; height: 30px;">
    <img height="28" width="3" src="../Images/title_bar_right.gif"/>
    </td>
    </tr>
    </tbody>
</table>

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style=" background-color:#F8F8F8; border-top:1px solid #EFEFE2;" id="TABLE1">
   
  
   
    <tr>
    <td style="width: 210px; height: 25px">SKU:</td>
    <td style="height: 25px">
    <asp:Label ID="lblSku" runat="server"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="ProfileID" Visible="False"></asp:Label>
        <asp:TextBox ID="txtProfileID" runat="server" BorderStyle="Groove" Visible="False"
            Width="33px" Height="10px"></asp:TextBox>
        <asp:HiddenField ID="hfInsertType" runat="server" />
    </td>
    </tr>
   
    
    <tr>
    <td style="width: 210px; height: 25px">Category:</td>
    <td style="height: 25px">
    <asp:Label ID=lblCategory runat="server" />&nbsp;
        &nbsp;&nbsp;&nbsp;<asp:TextBox
        ID="txtCategoryID" runat="server" BorderStyle="Groove" Visible="False" Width="33px" Height="10px"></asp:TextBox><asp:Label
            ID="Label6" runat="server" Text="Pagemode" Visible="False"></asp:Label><asp:TextBox ID="txtPageMode"
                runat="server" BorderStyle="Groove" Height="13px" Width="33px" Visible="False"></asp:TextBox></td>
    </tr>
    
    
    <tr>
    <td style="width: 210px; height: 25px">Subcategory:</td>
    <td style="height: 25px">
    <asp:Label ID=lblSubcategory runat="server" />&nbsp;
        <asp:TextBox ID="txtSubcategoryID" runat="server" BorderStyle="Groove" Height="10px"
            Visible="False" Width="33px"></asp:TextBox></td>
    </tr>
    
    
    <tr>
    <td style="width: 210px; height: 25px">Second Subcategory:</td>
    <td style="height: 25px">
    <asp:Label ID=lblSecondSubcategory runat="server" />&nbsp;&nbsp;
        <asp:TextBox ID="txtSecondSubcatID" runat="server" BorderStyle="Groove" Height="10px" Visible="False"
            Width="33px"></asp:TextBox></td>
    </tr>
    
        
    <tr>
    <td style="width: 210px; height: 9px">Product Title:</td>
    <td style="height: 9px">
    <asp:Label ID=lblProductTitle runat="server" />&nbsp;<asp:Label ID="Label4" runat="server"
        Text="ProductID" Visible="False"></asp:Label>
        <asp:TextBox ID="txtProductID" runat="server" BorderStyle="Groove" Height="14px"
            Width="40px" Visible="False"></asp:TextBox></td>
    </tr>
    
    
    <tr>
    <td style="width: 210px; height: 25px">Description:</td>
    <td style="height: 25px">
        <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" Height="80px"
            MaxLength="500" TextMode="MultiLine" Width="350px">
    </asp:TextBox>
        &nbsp;
    </td>
    </tr>
    
    
    <tr>
    <td style="width: 210px; height: 25px">Quantity:</td>
    <td style="height: 25px">
    <asp:Label ID=lblQuantity runat="server" />&nbsp;
        <asp:Label ID="Label1" runat="server" Text="canEdit" Visible="False"></asp:Label>
        <asp:TextBox ID="txtCanEdit" runat="server" BorderStyle="Groove" Height="10px"
            Width="30px" Visible="False"></asp:TextBox></td>
    </tr>
    
     
    <tr>
    <td style="width: 210px; height: 25px">Price:</td>
    <td style="height: 25px">
    <asp:Label ID=lblProductPrice runat="server" />&nbsp;
        <asp:Label ID="lblCurrency" runat="server" Visible="False"></asp:Label></td>
    </tr>
    
    
    <tr>
    <td style="width: 210px; height: 25px">Sale/Discounted Price:</td>
    <td style="height: 25px">
    <asp:Label ID=lblSalePrice runat="server" />&nbsp;
    </td>
    </tr>
    
    
    <tr>
    <td style="width: 210px; height: 25px">Sale From Date:</td>
    <td style="height: 25px">
    <asp:Label ID=lblSaleFromDate runat="server" />&nbsp;
    </td>
    </tr>
    
    <tr>
    <td style="width: 210px; height: 25px">Sale To Date:</td>
    <td style="height: 25px">
    <asp:Label ID=lblSaleToDate runat="server" />&nbsp;
    </td>
    </tr>
    
    
     <tr>
    <td style="width: 210px; height: 25px">Condition:</td>
    <td style="height: 25px">
    <asp:Label ID=lblCondition runat="server" />&nbsp;
    
        <asp:Label ID="Label5" runat="server" Text="imagePath" Visible="False"></asp:Label><asp:TextBox ID="txtImagePath" runat="server" BorderStyle="Groove" Width="158px" Visible="False"></asp:TextBox><asp:Label ID="lblIsFileUploaded" runat="server" Text="Label"></asp:Label>
    
        <asp:Label ID="lblPaymentOptionValue" runat="server"></asp:Label></td>
    </tr>
    
    
    <tr>
    <td style="width: 210px; height: 15px">Condition Note:</td>
    <td style="height: 15px">
        <asp:TextBox ID="txtConditionNote" runat="server" CssClass="textbox" Height="70px"
            MaxLength="300" TextMode="MultiLine" Width="350px"></asp:TextBox>
        &nbsp;
    </td>
    </tr>
    <tr>
    </tr>
    
    
</table>
    
    
 <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style=" border-top:1px solid #EFEFE2; margin-top:25px" id="TABLE2"> 
    
    <tr>
    <td style="width: 210px; height:25px">
        Paper Back:<span class="mandatory">*</span></td>
    <td style="height: 25px">
        <asp:TextBox ID="txtPaperBack" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPaperBack"
            ErrorMessage="Paper back for book is empty" Font-Bold="True">?</asp:RequiredFieldValidator></td>
    
    </tr>
     <tr>
         <td style="width: 210px; height: 25px">
             Language:<span class="mandatory">*</span></td>
         <td style="height: 25px">
             <asp:TextBox ID="txtLanguage" runat="server" CssClass="textbox" MaxLength="50" Width="150px"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="txtLanguage"
                 ErrorMessage="Language field is blank." Font-Bold="True">?</asp:RequiredFieldValidator></td>
     </tr>
    
    
    <tr>
    <td  style="width: 210px; height: 25px">
        Dimension of Book:</td>
    <td style="height: 25px">
        <asp:TextBox ID="txtDimensionForBook" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
    
    </tr>
    
    
    <tr>
    <td style="width: 210px; height: 25px">
        Shipping Weight:</td>
    <td style="height: 25px">
        <asp:TextBox ID="txtShippingWeight" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
    
    </tr>
    
    <tr>
    <td style="width: 210px; height: 25px">
        Edition:<span class="mandatory">*</span></td>
    <td style="height: 25px">
        <asp:TextBox ID="txtEdition" runat="server" CssClass="textbox" MaxLength="50" Width="150px">
    </asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEdition"
            ErrorMessage="Edition is empty" Font-Bold="True">?</asp:RequiredFieldValidator></td>
    </tr>
    
    <tr>
    <td style="width: 210px; height: 25px">
        ISBN:<span class="mandatory">*</span></td>
    <td style="height: 25px">
        <asp:TextBox 
            ID="txtISBN" 
            runat="server" 
            CssClass="textbox" 
            MaxLength="30" 
            Width="150px">
    </asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator3" 
            runat="server" 
            ControlToValidate="txtISBN"
            ErrorMessage="ISBN is empty" Font-Bold="True">?</asp:RequiredFieldValidator>
    </td>
    
    </tr>
    
    
    <tr>
    <td style="width: 210px; height: 25px">
        Author:<span class="mandatory">*</span></td>
    <td style="height: 25px">
        <asp:TextBox 
            ID="txtAuthor" 
            runat="server" 
            CssClass="textbox" 
            MaxLength="300" 
            Width="150px"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator4" 
            runat="server" 
            ControlToValidate="txtAuthor"
            ErrorMessage="Author is empty" Font-Bold="True">?</asp:RequiredFieldValidator>
    </td>
    
    </tr>
    
    
    <tr>
    <td style="width: 210px; height: 25px">
        Publisher:<span class="mandatory">*</span></td>
    <td style="height: 25px">
        <asp:TextBox ID="txtPublisher" runat="server" CssClass="textbox" MaxLength="300"
            Width="150px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPublisher"
            ErrorMessage="Publisher is empty" Font-Bold="True">?</asp:RequiredFieldValidator></td>
    
    </tr>
    
    
    <tr>
    <td  style="width: 210px; height: 25px">
        <asp:Label ID="lblUpload" runat="server" Text="Upload image"></asp:Label>&nbsp
    </td>
    <td style="height: 25px">
        <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="Groove" />
        <asp:Button ID="btnUpload" runat="server" BorderStyle="Groove" Text="Upload" OnClick="btnUpload_Click" CausesValidation="False" />
        <asp:Label ID="lblImageUploadMessage" runat="server" Font-Size="11px" ForeColor="Red" Width="250px"></asp:Label>
    </td>
    </tr>
     <tr>
         <td style="width: 210px; height: 25px">
             Payment Option:<span class="mandatory">*</span></td>
         <td style="height: 25px">
             
                 <asp:DropDownList 
                    ID="ddlPaymentOption" runat="server" 
                    AppendDataBoundItems="True"
                    AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlPaymentOption_SelectedIndexChanged"
                    Width="305px">
                     <asp:ListItem Text="Pick From Store" Value="PFS"></asp:ListItem>
                     <asp:ListItem Text="Cash On Delivery" Value="COD"></asp:ListItem>
                 </asp:DropDownList></td>
     </tr>
    </table>


<asp:UpdatePanel ID="updatePanel" runat="server">
    <contenttemplate>
    <asp:Panel ID="panelDeliveryOption" runat="server" Width="815px" Visible="false"
        Enabled="false">
        <table class="cptable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td style="width: 210px">
                        Delivery Area:<span class="mandatory">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDeliveryArea" runat="server" Width="305px">
                            <asp:ListItem Selected="True">Inside of Dhaka</asp:ListItem>
                            <asp:ListItem>Outside of Dhaka</asp:ListItem>
                            <asp:ListItem Value="Out Side of Bangladesh">Out Side of Bangladesh</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 210px">
                        Cash on Delivery Cost:<span class="mandatory">*</span></td>
                    <td>
                        <asp:TextBox 
                            onkeydown="return IsDigit(event);" 
                            ID="txtCODCost" 
                            runat="server" Width="150px"
                            MaxLength="20" CssClass="textbox">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator 
                            ID="rfvCodCost" 
                            runat="server" 
                            Font-Bold="True" 
                            ErrorMessage="Cash on Delivery field is blank."
                            ControlToValidate="txtCODCost">?</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    
    </contenttemplate>
    <triggers>
    <asp:AsyncPostBackTrigger ControlID="ddlPaymentOption" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
    </triggers>
    </asp:UpdatePanel>
    
    
    
    <table class="cptable" cellpadding="0px" cellspacing="0px">
        <tr>
            <td style="width: 210px; height: 25px">
                <input id="Button1" type="button" value="Go Back" onclick="GoBack()" />
            </td>
            <td style="height: 25px">
                <asp:CheckBox 
                    ID="chkIsActive" 
                    runat="server" 
                    Text="Check this if you want to activate this product. Leave uncheck otherwise."
                    Checked="True" />
            </td>
        </tr>
    </table>

<br />
<span 
    style="font-size:11px; padding-left:150px;">Our <a href="#" style="text-decoration:underline;">Terms of Use</a> and <a href="#" style="text-decoration:underline;">Privacy Policy</a>.</span>
    <br /><br />

<div style="padding-left:200px;">
    &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="image_btn" OnClick="btnSubmit_Click" />
</div>
<br />


</asp:Content>

