<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="ProductProfile_ImageUploader.aspx.cs" Inherits="Corporate_ProductProfile_ImageUploader" Title="www.boromela.com - Image Uploader." %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style="border-top:1px solid #EFEFE2;">    
    <tr>
    <td style="height: 12px">
        Select Product Image:</td>
    <td style="height: 12px">
    <asp:FileUpload 
        ID="FileUpload1" 
        runat="server" 
        CssClass="textbox" 
        Width="500px" />
    &nbsp;&nbsp;    
    <asp:Button ID="btnUpload" runat="server" BorderStyle="Groove" Text="Upload" Width="85px" OnClick="btnUpload_Click" />&nbsp;
    </td>
    </tr>    
</table>
</asp:Content>

