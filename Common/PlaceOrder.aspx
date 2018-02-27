<%@ Page Language="C#" MasterPageFile="~/Common/MPCommon.master" AutoEventWireup="true" CodeFile="PlaceOrder.aspx.cs" Inherits="Common_PlaceOrder" Title="www.boromela.com Place Your Order." %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Label 
        ID="lblSystemMessage" 
        runat="server" EnableViewState="False" 
        Font-Size="11px"
        ForeColor="Red" Width="60%">
    </asp:Label>
    <strong><span style="font-size: 8pt; color: #ec2024"> </span></strong>
    <div align="right" class="top_secondary_link">
        &nbsp;</div>
    <span style="font-size: 20px; color: #898989; font-family: verdana">Review Order</span><br />
    <span class="gray11px" style="margin-top: 7px; font-weight: normal">
    <span style="color: #505050">boromela.com is absolutely </span>
    <strong style="color: #ec2024">
            FREE</strong> for posting classified Ads. It will not cost you anything.</span>
            <br /><br /><br />
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-bottom:1px solid #d5d5d5; margin-bottom:15px;">
    <tr>
    <td width="3"><img src="../images/title_bar_left.gif" width="3" height="28" alt="" /></td>
    <td width="600" style="background-image:url(../images/title_bar_bg.gif); background-repeat:repeat-x; padding-left:5px;">
    <asp:Label ID="titleLabel" runat="server" Text="Buyer's Information" />
    </td>
    <td width="3"><img src="../images/title_bar_right.gif" width="3" height="28" alt="" /></td>
    <td align="right">&nbsp;</td>
    </tr>
    </table>
    
   <div style="width:100%; height:25px; font-family:Verdana; font-size:12px; color:DarkGreen">
   Please verify all information and if everything is correct, click "Place Order" button at the bottom.
   </div>
   
   <table width="100%" border="0px" cellpadding="0px" cellspacing="0px" style="margin-bottom:20px; background-color:#F5F5F7">
        <tr>
        <th class="top_secondary_link" style="width:350px; text-align:left" >
            <span class="title top_secondary_link">Shipping Address</span>
        </th>
        
        <th class="top_secondary_link" style="width:350px; text-align:left">
            <span class="title">Billing Address</span>
        </th>
        </tr>
        
        <tr>
        <td style="width:350px;  padding:10px;text-align:left" >
            <asp:Label ID="lblShippingAddress" runat="server"></asp:Label>
        </td>
        
        <td style="width:350px; padding:10px; text-align:left">
            <asp:Label ID="lblBillingAddress" runat="server"></asp:Label>
        </td>
        </tr>
        
        
    </table>
    
    <table width="100%" border="0px" cellspacing="0px" cellpadding="0px" style="border-bottom:1px solid #d5d5d5; margin-bottom:15px;">
    <tr>
    <td width="3px"><img src="../images/title_bar_left.gif" width="3px" height="28px" alt="" /></td>
    <td width="600px" style="background-image:url(../images/title_bar_bg.gif); background-repeat:repeat-x; padding-left:5px;">
    <asp:Label ID="Label1" runat="server" Text="Items" />
    </td>
    <td width="3px"><img src="../images/title_bar_right.gif" width="3px" height="28px" alt="" /></td>
    <td align="right">&nbsp;</td>
    </tr>
    </table>
    <div style="width:100%; clear:both;">
    <asp:GridView 
        ID="grvOrderedItems" 
        runat="server" 
        CssClass="cptable"
        gridlines="None"
        DataKeyNames="CategoryID, ProductSellerDetailID" 
        Font-Names="Verdana"
        AutoGenerateColumns="False" 
        BorderWidth="0px" 
        Width="100%">
        <HeaderStyle Height="25px" BackColor="#EFEFE2" />
        <AlternatingRowStyle  BackColor="#F5F5F7" />
        <Columns>
            <asp:BoundField DataField="ProductTitle" HeaderText="Product Name" ReadOnly="True" HeaderStyle-Width="55%" SortExpression="ProductTitle" />
            <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-HorizontalAlign="Center" ReadOnly="True"  />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" ReadOnly="True" />
            <asp:BoundField DataField="Currency" HeaderText="Currency" ItemStyle-HorizontalAlign="Center" ReadOnly="True" />
            <asp:BoundField DataField="Subtotal" ItemStyle-HorizontalAlign="Center" HeaderText="Subtotal" ReadOnly="True"  />
        </Columns>
    </asp:GridView>
    </div>
    
    
    <table class="cptable" style="height:25px; width:100%;  text-align:center">
        <tr>
        <td>
        
        <span style="font-family:Verdana; font-weight:bold;">Total amount: </span>
        <asp:Label ID="lblTotalAmount" 
                   runat="server" 
                   Text="Label" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblCurrency" 
               runat="server" 
               Text="Label" ForeColor="Red"></asp:Label>
        </td>
        </tr>
        <tr>
        <td style="text-align:left">
        You choosed <asp:Label ID="lblPaymentOption" runat="server"></asp:Label> option as your payment method.
        </td>
        </tr>
     </table>
   
   <asp:HiddenField ID="hfOrderID" runat="server" />
   <asp:HiddenField ID="hfProfileID" runat="server" />
   <asp:HiddenField ID="hfUserType" runat="server" />
   <asp:HiddenField ID="hfPaymentOption" runat="server" />
    <asp:HiddenField ID="hfCurrency" runat="server" />
    <asp:HiddenField ID="hfTotalAmount" runat="server" />
    <asp:HiddenField ID="hfCustomerName" runat="server" />
    <asp:HiddenField ID="hfCustomerEmail" runat="server" />
    <asp:HiddenField ID="hfBillingAddress" runat="server" />
    <asp:HiddenField ID="hfShippingAddress" runat="server" />
    &nbsp;
    &nbsp;&nbsp;
   
   <div id="placeOrderButtonContainer" style="width:100%; height:25px;">
       &nbsp;<asp:Button ID="btnPlaceOrder" runat="server" BorderStyle="Groove" OnClick="btnPlaceOrder_Click1"
           Text="Place Order" /></div>
    
    
</asp:Content>

