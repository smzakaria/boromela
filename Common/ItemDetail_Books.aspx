<%@ Page Language="C#" MasterPageFile="~/Common/MPCommonListing.master" AutoEventWireup="true" CodeFile="ItemDetail_Books.aspx.cs" Inherits="Common_ItemDetail_Books" Title="www.boromela.com Book Detail." %>

<%@ Register Src="../UserControl/BookList_LeftMenu.ascx" TagName="BookList_LeftMenu"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" border="0px" align="center" cellpadding="0px" cellspacing="0px">
    <tr>
    <td style="padding-left:10px;">
    <asp:Label 
        ID="lblSystemMessage" 
        runat="server" 
        ForeColor="Red" 
        EnableViewState="False" 
        Width="60%" 
        Font-Size="11px"></asp:Label>
    </td>
    </tr>
    <tr>
    <td valign="top" style="padding-top: 10px; padding-right: 0px">
    <asp:FormView 
        ID="fvBookDetail" 
        runat="server" DataKeyNames="ProductSellerDetailID, ProductID, DiscountPrice, DisCountStartDate, DisCountEndDate, Currency"
        AllowPaging="false" 
        Font-Size="11px" OnItemCreated="fvBookDetail_ItemCreated">
        <ItemTemplate>
        
            <div class="itemDetailTopContainer">
                <div class="imageDetailContainer">
                    <asp:Image ID="image" 
                               runat="server" 
                               ImageUrl='<%#(string)Eval("ProductImage")%>'
                               AlternateText='<%#(string)Eval("ProductTitle")%>' 
                               Width="240px" 
                               Height="240px" />
                </div>
                <div class="headerDetailContainer">
                    <div class="miscLine">
                        <span class="title"><%#Eval("ProductTitle") %></span>
                     
                        by 
                        <a style="text-decoration:underline" href="ItemList_Books.aspx?PageMode=1&CID=1&SCID=<%#this.SubcategoryID%>&Author=<%#Eval("Author")%>&Location=<%=this.Location %>">
                        <%#Eval("Author") %>
                        </a>(Author)
                     </div>
                        <div class="miscLine" style="font-weight: normal">
                            (<%#Eval("NoOfReviews") %>) Customer Reviews 
                        </div>
                        <div class="miscLine">
                            <hr noshade="noshade" size="1px" />
                        </div>
                        <div class="miscLine">
                            <a href="UsedAndNew_Books.aspx?PageMode=1&PID=<%#Eval("ProductID") %>&CID=1&SCID=<%# this.SubcategoryID%>&SSCID=<%# this.SecondSubcatID %>&type=new">
                                <%#Eval("New") %>
                                New items </a>
                                <span style="font-weight: normal">& </span>
                                <a href="UsedAndNew_Books.aspx?PageMode=2&PID=<%#Eval("ProductID") %>&CID=1&SCID=<%# this.SubcategoryID%>&SSCID=<%#this.SecondSubcatID%>&type=used">
                                <%#Eval("Old") %>
                                Used items<br /> 
                                </a>
                        
                        
                        <strong style="color:#990000; font-size:13px;">
                        Price: <%#Eval("Price") %> <%#Eval("Currency") %>
                        </strong>
                        
                        
                        <asp:Label ID="lblSaleOffer" runat="server">
                        </asp:Label>
                        </div>
                    </div>
                    
                </div>
                <hr noshade="noshade" size="1px" />
                
                <div class="detailFooterContainer">
                    <div class="pageTitle colortitle" style="padding-bottom: 5px;">
                        Product Detail
                    </div>
                    <div class="leftFooterContainer" style="width:380px; float:left;padding:10px; margin-bottom:10px;">
                        
                        <div class="miscLine">
                            <strong>PaperBack: </strong><%#Eval("PaperBackForBook") %>
                           
                        </div>
                        <div class="miscLine">
                            <strong>Publisher: </strong><%#Eval("Publisher") %>
                            
                        </div>
                        <div class="miscLine">
                            <strong>Language: </strong><%#Eval("Language") %>
                        </div>
                        <div class="miscLine">
                            <strong>ISBN: </strong><%#Eval("ISBN") %>
                       
                        </div>
                        <div class="miscLine">
                            <strong>Product Dimension: </strong><%#Eval("DimensionForBook") %>
                            
                        </div>
                        <div class="miscLine">
                            <strong>Shipping Weight: </strong><%#Eval("ShippingWeight") %>
                            
                        </div>
                        
                        <div class="miscLine">
                            <strong>Delivery Option: </strong><%#Eval("PaymentOption") %>
                            
                        </div>
                        
                        <div class="miscLine">
                            <strong>Condition: </strong><%#Eval("Condition") %>
                            
                        </div>
                        
                        <div class="miscLine">
                            <strong>Delivery Area: </strong><%#Eval("DeliveryArea") %>
                            
                        </div>
                        
                         <div class="miscLine">
                            <strong>Cash On Delivery Cost: </strong><%#Eval("CodCost") %>
                            
                        </div>
                        
                        <div class="miscLine">
                            <strong>Average Customer Review: </strong>
                        </div>
                        
                    </div>
                    
                    <div class="rightFooterContainer" style="width:190px; float:left;  height:150px; ">
                    <div class="cartContainer">
                       
                    <table id="cartTable" class="cartBox" cellspacing="0px" cellpadding="0" border="0px" width="190px">
                        <tbody>
                        <tr>
                        <td class="topLeft" width="190px">
                        <table cellspacing="0px" cellpadding="0px" border="0px" align="center">
                            <tbody>
                            <tr>
                            <td align="center" style="text-align: center;">
                            <div id="qtyDdlDiv" align="center" style="margin-bottom: 4px;color:Black;">
                            Available Quantity: 
                            <asp:Label ID="lblAvailableQuantity" runat="server" Text='<%#Eval("BalanceQuantity") %>'>
                            </asp:Label>
                            <br />
                            <br />
                            </div>
                            <span id="addToCartSpan">
                            <asp:ImageButton
                            ID="btnAddToCart" 
                            runat="server" ImageUrl="~/Images/btnAddToCart.gif"
                            OnClick="btnAddToCart_Click" />
                            </span>
                            <br />
                            <br />

                            </td>
                            </tr>
                            </tbody>
                        </table>
                        </td>
                        <td class="topRight" width="13"> </td>
                        </tr>
                        <tr>
                        <td class="bottomLeft"> </td>
                        <td class="bottomRight" height="12"> </td>
                        </tr>
                        </tbody>
                    </table>
                          
                    </div>
                    </div>
                    
                </div>
                 <hr noshade="noshade" size="1px" />
                 
                <div class="pageTitle colortitle" style="clear:both">Condition Note</div>  
                    <div class="productDescription" style="padding:10px" >
                        <p class="formatParagraph">
                        <%#Eval("ConditionNote") %>
                        </p>
                    </div> 
                                   
                <div class="pageTitle colortitle" style="clear:both">Product Description</div>  
                    <div class="productDescription" style="padding:10px" >
                        <p class="formatParagraph">
                        <%#Eval("ProductDesc") %>
                        </p>
                </div>
                
                
            </td>
            </tr>

            </table>  
              </ItemTemplate>
              </asp:FormView>
                
                
                
                <div class="itemDetailComments">
                    <hr style="width: 100%;" noshade="noshade" size="1px" />
                    <span class="pageTitle"><u>Post a comment</u></span>
                    <br />
                    <br />
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div style="background-color: #F5F5F5; padding-top: 5px; padding-bottom: 5px; width: 270px;">
                                <ul>
                                    <li><strong>
                                        <%# DataBinder.Eval(Container.DataItem, "CriticsName")%>
                                    </strong>&nbsp - says, on <span style="color: Red;">
                                        <%# DataBinder.Eval(Container.DataItem, "Posted")%>
                                    </span>
                                        <br />
                                        <br />
                                        <%# DataBinder.Eval(Container.DataItem, "Review")%>
                                    </li>
                                </ul>
                            </div>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
                    <br />
                    Your Name:
                    <asp:Label ID="lblCriticsName" runat="server" EnableViewState="False" ForeColor="Red"
                        Width="215px">
                    </asp:Label>
                    <br />
                    <asp:TextBox ID="txtCriticsName" CssClass="textbox" runat="server" Width="270px">
                    </asp:TextBox>
                    <br />
                    <br />
                    Your Comments:
                    <asp:Label ID="lblComments" runat="server" EnableViewState="False" ForeColor="Red"
                        Width="215px">
                    </asp:Label>
                    <br />
                    <asp:TextBox ID="txtComments" CssClass="textbox" runat="server" Height="176px" TextMode="MultiLine"
                        Width="270px">
                    </asp:TextBox>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnPost" runat="server" Text="Post" Width="87px" BorderStyle="Groove"
                        CausesValidation="False" OnClick="btnPost_Click" />&nbsp;
                    <asp:HiddenField ID="hfProductTitle" runat="server" />
                </div>
        

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <uc1:BookList_LeftMenu ID="BookList_LeftMenu1" runat="server" />
</asp:Content>

