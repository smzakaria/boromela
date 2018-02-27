<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="ControlPanel.aspx.cs" Inherits="Corporate_ControlPanel" Title="www.boromela.com – Corporate Control Panel." %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<span class="pageTitle">Business – Posted Ads.</span><br />
<span class="gray11px" style="font-weight:normal; margin-top:7px;">boromela.com is absolutely <strong style="color:#EC2024;">FREE</strong> for posting classified Ads. It will not cost you anything.</span>
<br /><br />
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-bottom:1px solid #d5d5d5;">
    <tr>
    <td width="3"><img src="../images/title_bar_left.gif" width="3" height="28" alt="" /></td>
    <td width="600" style="background-image:url(../images/title_bar_bg.gif); background-repeat:repeat-x; padding-left:5px;"><a href="Product_Management.aspx">Post a New Ad.</a></td>
    <td width="3"><img src="../images/title_bar_right.gif" width="3" height="28" alt="" /></td>
    <td align="right">&nbsp;</td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
    <td colspan="2" align="left" style="font-size:11px;">
        &nbsp;<asp:Label 
        ID="lblSystemMessage" 
        runat="server" 
        ForeColor="Red" 
        EnableViewState="False" 
        Width="500px" 
        Font-Size="11px">
    </asp:Label>                                        
    </td>
    </tr>
    <tr>
    <td valign="top">
    <asp:GridView 
        ID="grvProductProfile" 
        runat="server" 
        Width="100%" 
        AutoGenerateColumns="false" 
        DataKeyNames="ProductID" 
        CssClass="cptable" 
        GridLines="None" 
        AllowPaging="true" 
        PageSize="10" OnPageIndexChanging="grvProductProfile_PageIndexChanging">    
        <HeaderStyle Height="25px" BackColor="#EFEFE2" />
        <Columns>
            <asp:BoundField DataField="ProductTitle" HeaderText="Product Title" HeaderStyle-Width="55%" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="SKU" />
            <asp:BoundField DataField="Category"/>
            <asp:BoundField DataField="Subcategory" />
            <asp:BoundField DataField="SecondSubcategory"/>
            <asp:HyperLinkField HeaderText="&#160;" Text="Edit" DataNavigateUrlFields="ProductID, CategoryID, SubcategoryID, SecondSubcatID, ProductTitle, Category, Subcategory, SecondSubcategory,ProfileID, SKU" DataNavigateUrlFormatString="ProductProfileAE.aspx?mode=1&pi={0}&ci={1}&sci={2}&ssci={3}&title={4}&c={5}&sc={6}&ssc={7}&pfi={8}&sku={9}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
        </Columns>
    </asp:GridView>    
    </td>
    </tr>
</table>
<br />
<br />

<table width="100%" border="0px" cellspacing="0px" cellpadding="0px" style="border-bottom:1px solid #d5d5d5;">
     
    <tr>
    <td width="3px"><img src="../images/title_bar_left.gif" width="3px" height="28px" alt="" /></td>
    <td width="600px" style="background-image:url(../images/title_bar_bg.gif); background-repeat:repeat-x; padding-left:5px;">
    <span style="color: #004b91">Corporate Product Order.</span>
    </td>
    <td width="3px"><img src="../images/title_bar_right.gif" width="3px" height="28px" alt="" /></td>
    <td align="right">&nbsp;</td>
    </tr>
    </table>
    
    
    <table width="100%" border="0px" cellspacing="0px" cellpadding="0px">
    <tr>
    <td colspan="2" align="left" style="font-size:11px;">
        <asp:Label 
        ID="lblCorporateOrderMessage" 
        runat="server" 
        ForeColor="Red" 
        EnableViewState="False" 
        Width="500px" 
        Font-Size="11px">
    </asp:Label>                                        
    </td>
    </tr>
    <tr>
    <td valign="top">
    <asp:GridView 
        ID="grvCorporateOrderList" 
        runat="server" 
        Width="100%" 
        AutoGenerateColumns="false" 
        DataKeyNames="OrderID, CategoryID" 
        CssClass="cptable" 
        GridLines="None" 
        AllowPaging="true" 
        
        PageSize="5" OnPageIndexChanging="grvCorporateOrderList_PageIndexChanging" OnRowDataBound="grvCorporateOrderList_RowDataBound">    
        <HeaderStyle Height="25px" BackColor="#EFEFE2" />
        <AlternatingRowStyle BackColor="#F5F5F7" />
        <Columns>
            <asp:TemplateField HeaderText="Product Title">
            <ItemTemplate>
            <div style="padding:5px;">
            <%--<asp:hyperlink id="lnkTitle" runat="server">--%>
            <%#Eval("ProductTitle") %>
            <%--</asp:HyperLink>--%>
            </div>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="left"/>
            <asp:BoundField DataField="Currency" HeaderText="Currency" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="CreationDate" HeaderText="Order Date" DataFormatString="{0:MMM dd, yyyy}" ItemStyle-Width="15%"  HeaderStyle-HorizontalAlign="Left"/>
            <%--<asp:BoundField DataField="PaymentOption" HeaderText="Payment Option" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="left"/>--%>
            
            <asp:TemplateField HeaderText="PaymentOption" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left">  
            <ItemTemplate>
            <%#this.GetPaymentMethod(Eval("PaymentOption") )%>
            </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    
    
    </td>
    </tr>
    </table>
<div align="right">&nbsp;</div>
<br />
</asp:Content>

