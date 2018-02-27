<%@ Page Language="C#" MasterPageFile="~/Common/MPCommon.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Common_ShoppingCart" Title="www.boromela.com Shopping Cart." %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Label 
        ID="lblSystemMessage" 
        runat="server" 
        ForeColor="Red" 
        EnableViewState="False"
        Width="60%" Font-Size="11px">
    </asp:Label>
    <div class="top_secondary_link" align="right">&nbsp;</div>
    <span class="pageTitle" style="clear:both">Shopping Cart</span><br />
    <span class="gray11px" style="font-weight:normal; margin-top:7px;">boromela.com is absolutely <strong style="color:#EC2024;">FREE</strong> for posting classified Ads. It will not cost you anything.</span>
    <div style="text-align:center">
    
    </div>
    <asp:Label ID="lblStatus" CssClass="AdminPageText" ForeColor="Red" runat="server" />
    <br />
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-bottom:1px solid #d5d5d5; margin-bottom:15px;">
    <tr>
    <td width="3"><img src="../images/title_bar_left.gif" width="3" height="28" alt="" /></td>
    <td width="600" style="background-image:url(../images/title_bar_bg.gif); background-repeat:repeat-x; padding-left:5px;">
    <asp:Label ID="titleLabel" runat="server" Text="Your Shopping Cart" />
    </td>
    <td width="3"><img src="../images/title_bar_right.gif" width="3" height="28" alt="" /></td>
    <td align="right">&nbsp;</td>
    </tr>
    </table>
    <asp:GridView 
        
        ID="grid" 
        runat="server" 
        CssClass="cptable"
        gridlines="None"
        DataKeyNames="ProductID, ProductSellerDetailID" 
        Font-Names="Verdana"
        AutoGenerateColumns="False" 
        BorderWidth="0px" 
        Width="100%" OnRowDeleting="grid_RowDeleting">
        <HeaderStyle Height="25px" BackColor="#EFEFE2" />
        <AlternatingRowStyle  BackColor="#F5F5F7" />
        <Columns>
            <asp:BoundField DataField="ProductTitle" HeaderText="Product Name" ReadOnly="True" HeaderStyle-Width="55%"  SortExpression="ProductTitle" />
            <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-HorizontalAlign="Center" ReadOnly="True" SortExpression="Price" />
            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <asp:TextBox 
                        ID="txtQuantity" 
                        runat="server" 
                        BorderStyle="groove"
                        CssClass="textbox" 
                        Width="24px" MaxLength="2" Text='<%#Eval("Quantity")%>' />
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:BoundField DataField="Subtotal" ItemStyle-HorizontalAlign="Center" HeaderText="Subtotal" ReadOnly="True" SortExpression="Subtotal" />
             <asp:BoundField DataField="Currency" ItemStyle-HorizontalAlign="Center" HeaderText="Currency" ReadOnly="True" SortExpression="Currency" />
            <asp:TemplateField ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="~/Images/btnDelete.gif" CommandName="Delete"/>
                </ItemTemplate>
            </asp:TemplateField>
            
            
        </Columns>
        
    </asp:GridView>
    <table width="100%" class="cptable">
        <tr>
        <td style="text-align:right; height: 25px; padding-right:130px" colspan="2">
            <span style="font-family:Verdana; font-weight:bold;">Total amount: </span>
            <asp:Label ID="lblTotalAmount" runat="server" Text="Label" CssClass="ProductPrice" />
            <asp:Label ID="lblCurrency" runat="server" Text="Label" CssClass="ProductPrice" />
        </td>
        <td  align="right" style="height: 25px; padding-right:12px; width: 15px; ">
        <asp:ImageButton 
            ID="btnUpdate" 
            runat="server" 
            AlternateText="Update Quantities" ImageUrl="~/Images/btnUpdate.gif" OnClick="btnUpdate_Click" 
             />
        </td>
        </tr>
        <tr>
        <td style="height: 25px; text-align: left">
        <asp:ImageButton ID="btnContinueShopping" 
                runat="server" 
                AlternateText="Continue Shopping"
                ImageUrl="~/Images/btnContinueShopping.gif"
                OnClick="btnContinueShopping_Click" /></td>
        <td align="right" style="height: 25px" width="25%">&nbsp</td>
        <td align="right" style="width: 25%; height: 25px; padding-right:12px">
        <asp:ImageButton ID="btnCheckOut" 
                         runat="server" 
                         ImageUrl="~/Images/btnCheckout.gif"
                         AlternateText="Proceed To Checkout"
                         OnClick="btnCheckOut_Click" />
        </td>
        </tr>
    </table>
    <br />
    &nbsp;<div style="margin-top:10px;">
        <asp:RadioButtonList ID="rbtnPaymentOption" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Text="Pick From Store" Value="PFS"></asp:ListItem>
            <asp:ListItem Text="Cash On Delivery" Value="COD"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
</asp:Content>

