<%@ Page Language="C#" MasterPageFile="~/Common/MPCommon.master" AutoEventWireup="true" CodeFile="OrderConfirmation.aspx.cs" Inherits="Common_OrderConfirmation" Title="www.boromela.com Order Confirmation." %>

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
    <span style="font-size: 20px; color: #898989; font-family: verdana"> Order Confirmation</span><br />
    <span class="gray11px" style="margin-top: 7px; font-weight: normal">
    <span style="color: #505050">boromela.com is absolutely </span>
    <strong style="color: #ec2024">FREE</strong> for posting classified Ads. It will not cost you anything.</span>
            
    <table cellpadding="0px" cellspacing="0px" style=" color:#000000; width:100%; margin:15px 0px 15px 0px;" >
        <thead>
        <tr>
        <th class="top_secondary_link pagetitle" style="text-align:center;">&nbsp</th>
        </tr>
        </thead>
        <tbody style="background-color:#F5F5F7">
        <tr>
        <td style="padding:5px 0px 0px 0px">
        <strong style="font-family:Verdana; font-size:12px"> Selected Payment Method: </strong> <asp:Label ID="lblPaymentOption" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td style="padding:5px 0px 5px 0px">
        <strong style="font-family:Verdana; font-size:12px"> Order No: </strong> <asp:Label ID="lblOrderNo" runat="server"></asp:Label>
        </td>
        </tr>
        </tbody>
    </table>
    <div  style="width:780px; padding:5px; height:100px; font-family:Verdana; font-size:12px; color:DarkGreen">
       <asp:Label ID="lblBuyer" runat="server" Text="Label"></asp:Label><br />
       
            Thank you for your order at BoroMela.com.
            This is a confirmation of your order. You will also receive an email confirmation
            shortly. Your order will be processed soon. 
            We will notify you as soon as we ship your product. 
       <br />
       Thanks again.
        <br />
       <br />
       NB:  Please check your Inbox and Bulk/Spam folder. If you do not 
            receive the mail please feel free to contact Boromela.com. 
       <strong style="font-family:Verdana;color:Red;font-size:12px">BoroMela</strong> on behalf of Seller(s).
       <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
   </div>
   <br />
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-bottom:1px solid #d5d5d5; margin-bottom:15px;">
    <tr>
    <td style="width:3px"><img src="../images/title_bar_left.gif" width="3" height="28" alt="" /></td>
    <td style="background-image:url(../images/title_bar_bg.gif); background-repeat:repeat-x; padding-left:5px; width:600px">
    <asp:Label ID="titleLabel" runat="server" Text="Buyer's Information" />
    </td>
    <td style="width:3px"><img src="../images/title_bar_right.gif" width="3" height="28" alt="" /></td>
    <td align="right">&nbsp;</td>
    </tr>
    </table>
   
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
   
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-bottom:1px solid #d5d5d5; margin-bottom:15px;">
    <tr>
    <td style="width:3px"><img src="../images/title_bar_left.gif" width="3" height="28" alt="" /></td>
    <td style="width:600px; background-image:url(../images/title_bar_bg.gif); background-repeat:repeat-x; padding-left:5px;">
    <asp:Label ID="Label1" runat="server" Text="Items" />
    </td>
    <td style="width:3px"><img src="../images/title_bar_right.gif" width="3" height="28" alt="" /></td>
    <td align="right">&nbsp;</td>
    </tr>
    </table>
    <div style="width:100%; clear:both;">
    <asp:GridView 
        ID="grvOrderedItems" 
        runat="server" 
        gridlines="None"
        DataKeyNames="CategoryID, ProductSellerDetailID" 
        Font-Names="Verdana"
        AutoGenerateColumns="False" 
        BorderWidth="0px" 
        Width="100%">
        <HeaderStyle Height="25px" BackColor="#EFEFE2" />
        <AlternatingRowStyle  BackColor="#F5F5F7" />
        <Columns>
        <asp:TemplateField>
        <HeaderTemplate>
        <table class="cptable" style="width:100%;" cellspacing="0px" cellpadding="0px" border="0px">
            <thead>
            <tr style="text-align:left">
            <th class="columnheader" style="width:200px; ">
            Product Name
            </th>
            
            <th class="columnheader" style="width:80px;">
            Price
            </th>
            
            <th class="columnheader" style="width:80px;">
            Currency
            </th>
            
            <th class="columnheader" style="width:80px; ">
            Quantity
            </th>
            
            <th class="columnheader" style="width:90px;">
            Subtotal
            </th>
            
            <th class="columnheader" style="font-weight:bold;">
            Seller
            </th>
            </tr>
            
            </thead>
        </table>
        
    
        </HeaderTemplate>
        <ItemTemplate>
            <table style="width:100%; color:#000000; border-bottom:1px solid #EFEFE2" cellspacing="0px" border="0px" cellpadding="0px">
                <tr style="vertical-align:top;">
                <td class="columnheader" style="width:200px;">
                <%#Eval("ProductTitle") %>
                </td>
                
                <td class="columnheader" style="width:80px;">
                <div><%#Eval("Price") %></div>
                </td>
                
                <td class="columnheader" style="width:80px;">
                <%# Eval("Currency")%>
                </td>
                
                <td class="columnheader" style="width:80px;">
                <%# Eval("Quantity")%>
                </td>
                
                
                <td class="columnheader" style="width:90px;">
                <%#Eval("Subtotal") %>
                </td>
               
                
                <td class="columnheader" style="font-weight:normal; line-height:17px; ">
                    <strong style="font-size:12px;font-family:verdana">Company/User Name: </strong> <%# Eval("SellerInfo")%><br />
                    <strong style="font-size:12px;font-family:verdana">Seller Name: </strong><%# Eval("UserName")%><br /> 
                    <strong style="font-size:12px;font-family:verdana">Website Url: </strong>
                    <a href='http://<%# Eval("URL")%>'  >
                    <%# Eval("URL")%>
                    </a>
                    <br />  
                    
                    <strong style="font-size:12px;font-family:verdana">Cell No: </strong><%# Eval("CellNo")%><br />  
                    <strong style="font-size:12px;font-family:verdana">User Address: </strong><%# Eval("UserAddress")%><br />
                    <%# Eval("State")%>,
                    <%# Eval("Province")%>, 
                    <%# Eval("Country")%>.
                </td>
                
                </tr>
            </table>
            
        </ItemTemplate>
        </asp:TemplateField>
            
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
        
     </table>               
    
   
  
   
   <div id="placeOrderButtonContainer" style="width:100%; height:25px;">
       <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>&nbsp;</div>
   
</asp:Content>

