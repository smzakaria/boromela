<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="SellLead_General.aspx.cs" Inherits="Corporate_SellLead_General" Title="www.boromela.com – Sell Lead." %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<span class="pageTitle">Corporate - Sell Lead (General Items).</span>
<br /><br /><br />
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style="border-top:1px solid #EFEFE2;" id="TABLE1">
    <tr>
    <td width="120" style="height: 25px">Select Date From</td>
    <td style="height: 25px">
    <asp:DropDownList id="ddlStartDay1" runat="server" Width="50px"></asp:DropDownList>        
    <asp:DropDownList id="ddlStartMonth1" runat="server" Width="50px"></asp:DropDownList>                
    <asp:DropDownList id="ddlStartYear1" runat="server" Width="60px"></asp:DropDownList>
    To: 
    <asp:DropDownList id="ddlEndDay1" runat="server" Width="50px"></asp:DropDownList>        
    <asp:DropDownList id="ddlEndMonth1" runat="server" Width="50px"></asp:DropDownList>                
    <asp:DropDownList id="ddlEndYear1" runat="server" Width="60px"></asp:DropDownList>    
    <asp:Button ID="btnSellLead1" runat="server" Text="Show Sell Lead" BorderStyle="Groove" OnClick="btnSellLead1_Click" />
    </td>
    </tr>    
</table>
<%if(grvSellLead01.Rows.Count >0){ %>
    <br />
    <strong>Total Pending Orders (Buyer wise):</strong>
    <br /><br />
<%} %>
<asp:GridView 
    ID="grvSellLead01" 
    runat="server" 
    Width="100%" 
    AutoGenerateColumns="false" 
    CssClass="cptable" 
    GridLines="None" 
    DataKeyNames="CustomerEmail" 
    AllowPaging="true" 
    PageSize="10" 
    Font-Size="11px" OnPageIndexChanging="grvSellLead01_PageIndexChanging">    
    <HeaderStyle Height="25px" BackColor="#EFEFE2" />
    <Columns>
        <asp:BoundField DataField="CustomerName" HeaderText="Buyers Name">
            <HeaderStyle HorizontalAlign="Left" Width="20%" />
        </asp:BoundField>
        <asp:BoundField DataField="TotalOrder" HeaderText="Total Order">
            <HeaderStyle HorizontalAlign="Center" Width="10%" />
            <ItemStyle HorizontalAlign="Center" />            
        </asp:BoundField>
        <asp:BoundField DataField="PFS" HeaderText="PFS">
            <HeaderStyle HorizontalAlign="Center" Width="7%" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="COD" HeaderText="COD">
            <HeaderStyle HorizontalAlign="Center" Width="7%" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>        
        <asp:HyperLinkField 
            HeaderText="View Orders" 
            Text="View" 
            DataNavigateUrlFields="CustomerEmail, CustomerName" 
            DataNavigateUrlFormatString="SellLead_General_Confirmation.aspx?Email={0}&Buyer={1}"
            HeaderStyle-HorizontalAlign="Left" 
            ItemStyle-HorizontalAlign="Left" 
            ItemStyle-Width="64%" />                
    </Columns>
</asp:GridView>
<%if(grvSellLead02.Rows.Count >0){ %>
    <br /><br />
    <strong>Total Pending Orders (Cumulative view):</strong>
    <br /><br />
<%} %>
<asp:GridView 
    ID="grvSellLead02"
    runat="server" 
    Width="100%" 
    AutoGenerateColumns="false" 
    CssClass="cptable" 
    GridLines="None"
    DataKeyNames="ProductID"
    AllowPaging="true"
    PageSize="10"
    Font-Size="11px">    
    <HeaderStyle Height="25px" BackColor="#EFEFE2" />
    <Columns>
        <asp:BoundField DataField="SKU" HeaderText="SKU">
            <HeaderStyle HorizontalAlign="Left" Width="15%" />
        </asp:BoundField>
        <asp:BoundField DataField="ProductTitle" HeaderText="Product Title">
            <HeaderStyle HorizontalAlign="left" Width="30%" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField> 
        <asp:HyperLinkField 
            HeaderText="Total Sell Order" 
            DataTextField="TotalSellOrder" 
            DataNavigateUrlFields="" 
            DataNavigateUrlFormatString=""
            HeaderStyle-HorizontalAlign="Center" 
            ItemStyle-HorizontalAlign="Center" 
            ItemStyle-Width="10%" />                        
        <asp:HyperLinkField 
            HeaderText="COD" 
            DataTextField="COD" 
            DataNavigateUrlFields="" 
            DataNavigateUrlFormatString=""
            HeaderStyle-HorizontalAlign="Center" 
            ItemStyle-HorizontalAlign="Center" 
            ItemStyle-Width="10%" />                        
        <asp:HyperLinkField 
            HeaderText="PFS" 
            DataTextField="PFS" 
            DataNavigateUrlFields="" 
            DataNavigateUrlFormatString=""
            HeaderStyle-HorizontalAlign="Center" 
            ItemStyle-HorizontalAlign="Center" 
            ItemStyle-Width="10%" />                        
        <asp:HyperLinkField 
            HeaderText="Pending" 
            DataTextField="Pending" 
            DataNavigateUrlFields="" 
            DataNavigateUrlFormatString=""
            HeaderStyle-HorizontalAlign="Left" 
            ItemStyle-HorizontalAlign="Left" 
            ItemStyle-Width="25%" />                        
    </Columns>
</asp:GridView>
</asp:Content>

