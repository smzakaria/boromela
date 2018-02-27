<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="SellLead_General_Confirmation.aspx.cs" Inherits="Corporate_SellLead_General_Confirmation" Title="www.boromela.com - Sell Lead - Buyer List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<span class="pageTitle">Corporate - Sell Lead (General Items).</span>
<br /><br />
<span class="pageTitle" style="font-size:14px;">Buyer&nbsp;:&nbsp;<%=strBuyerName%></span>
<br /><br />
<asp:Button ID="btnSendConfirmation" runat="server" Text="Send Confirmation" Width="123px" />
<br /><br />
<asp:GridView 
    ID="grvSellLead02" 
    runat="server" 
    Width="100%" 
    AutoGenerateColumns="false" 
    CssClass="cptable" 
    GridLines="None" 
    DataKeyNames="OrderID" 
    AllowPaging="true" 
    PageSize="10" 
    Font-Size="11px" OnPageIndexChanging="grvSellLead02_PageIndexChanging">    
    <HeaderStyle Height="25px" BackColor="#EFEFE2" />
    <Columns>
        <asp:TemplateField>
            <HeaderStyle Width="2%" />
            <ItemTemplate><asp:CheckBox ID="chkSelect" runat="server" /></ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="SKU" HeaderText="SKU">
            <HeaderStyle HorizontalAlign="Left" Width="5%" />
        </asp:BoundField>
        <asp:BoundField DataField="Orders" HeaderText="Orders">
            <HeaderStyle HorizontalAlign="Left" Width="20%" />
            <ItemStyle HorizontalAlign="Left" />            
        </asp:BoundField>
        <asp:BoundField DataField="TotalOrder" HeaderText="TotalOrder">
            <HeaderStyle HorizontalAlign="Center" Width="7%" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:D}" HtmlEncode="false">
            <HeaderStyle HorizontalAlign="Center" Width="10%" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="OrderType" HeaderText="OrderType">
            <HeaderStyle HorizontalAlign="Center" Width="7%" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>         
    </Columns>
</asp:GridView>
</asp:Content>

