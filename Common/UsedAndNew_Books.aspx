<%@ Page Language="C#" MasterPageFile="~/Common/MPCommon.master" AutoEventWireup="true" CodeFile="UsedAndNew_Books.aspx.cs" Inherits="Common_UsedAndNew_Books" Title="www.boromela.com Common Seller." %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table style="width: 100%;" cellpadding="0" cellspacing="0" align="center">
    <tr>
    <td style="padding-left: 10px;" width="100%" colspan="2">
        <asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" EnableViewState="False"
        Width="72%" Font-Size="11px"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="width: 115px">
        <div class="itemListImage">
        <a id="imageLink" runat="server">
        <asp:Image ID="bookImage" AlternateText="Return to detail page" runat="server" Width="115px" Height="115px" />
        </a>
        </div>
    </td>
    <td valign="top">
        
        <asp:Label ID="lblProductTitle" runat="server">
        </asp:Label>
        
        by
        <asp:Label ID="lblAuthor" runat="server">
        </asp:Label><br />
        <br />
        <a id="titleLink" runat="server" style="text-decoration:underline">
        Return to Book Detail
        </a>
        
        <hr noshade="noshade" size="1px" width="90%" style="border-top: 1px dashed #999999;"
        align="left" />
    </td>
    <td valign="top" style="width: 200px;">
    <div style="background-color: #FFFFFF; height: 150px; width: 200px;">
        <table id="cartTable" class="cartBox" cellspacing="0" cellpadding="0" border="0" width="190">
            <tbody>
            <tr>
            <td class="topLeft" width="190">
                <table cellspacing="0" cellpadding="0" border="0" align="center">
                <tbody>
                <tr>
                <td align="center" style="text-align: left;">
                    <div align="center" style="color:#000000; text-decoration:underline; margin-bottom: 25px; font-family: Verdana; font-size: 14px; font-weight: bold;">
                    Price at a glance
                    </div>
                    <div align="center" style="margin-bottom: 4px; color:#000000;">
                    List Price:
                    <asp:Label ID="lblDiscountPrice" runat="server"></asp:Label>
                    </div>
                    <div align="center" style="margin-bottom: 4px; color:#000000;">
                    New:
                    <asp:Label ID="lblNewMinPrice" runat="server"></asp:Label>
                    </div>
                    <div align="center" style="margin-bottom: 4px; color:#000000;">
                    Used:
                    <asp:Label ID="lblUsedMinPrice" runat="server"></asp:Label>
                    </div>
                </td>
                </tr>
                </tbody>
            </table>
        </td>
        <td class="topRight" width="13">
        </td>
        </tr>
        <tr>
        <td class="bottomLeft">
        </td>
        <td class="bottomRight" height="12">
        </td>
        </tr>
        </tbody>
        </table>
    </div>
    </td>
    </tr>
</table>
<div class="mixedItemContainer" style="width:800px; padding-left:10px; margin-top:20px">
    <cc1:TabContainer ID="TabContainer" runat="server" ActiveTabIndex="0" CssClass="ajax__tab_yuitabview-theme">
        <cc1:TabPanel ID="tpAllItems" runat="server" HeaderText="All">
        <ContentTemplate>
            <asp:GridView   
                ID="grvMixedBookList"
                runat="server"
                DataKeyNames="ProductSellerDetailID, ProductID"
                AutoGenerateColumns="False"
                AllowPaging="false" 
                Width="790px"
                Font-Names="Verdana"
                GridLines="None" OnRowCommand="grvMixedBookList_RowCommand">
                <AlternatingRowStyle BackColor="#F5F5F7" />
                <HeaderStyle Height="25px" BackColor="#EFEFE2" HorizontalAlign="Left"/>
                <Columns>
                <asp:TemplateField>
                <HeaderTemplate>
                <table style="width:100%; color:#000000; " cellspacing="0px" cellpadding="0px">
                    <thead>
                    <tr>
                    <th class="columnheader" style="width:18%;">
                    Price
                    </th>
                    <th class="columnheader" style="width:22%;">
                    Condition
                    </th>
                    <th class="columnheader" style="width:40%;">
                    Seller Information
                    </th>
                    <th class="columnheader" >
                    Buy this Book?
                    </th>
                    </tr>
                    </thead>
                </table>
                </HeaderTemplate>
                    <ItemTemplate>
                    <table style="width:100%; color:#000000" cellspacing="0px" cellpadding="0px">
                    <tr>
                    <td class="itemContainer" style="width:18%; height:137px; text-align:left; padding:6px 6px 6px 10px; vertical-align:top">
                        <span class="price" style="font-weight:bold; font-family:verdana">
                        <%#Eval("Price") %>&nbsp;<%#Eval("Currency") %>
                        </span>
                    </td>
                   
                    <td class="itemContainer" style="width:22%; height:137px;text-align:left; padding:6px 6px 6px 10px;vertical-align:top">
                        <span class="productCondition" style="font-size:12px; font-family:verdana">
                        <%#Eval("Condition") %>
                        </span>
                   </td>
                    
                    <td class="itemContainer" style="width:40%;height:137px;text-align:left; padding:6px 6px 6px 10px; vertical-align:top">
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Seller: </strong> 
                            <span class="sellerInfo" style="font-weight:bold;font-size:12px;font-family:verdana,arial,helvetica,sans-serif;">
                            </span><%#Eval("SellerInfo") %>
                        </div>
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Cell # </strong> 
                            <span class="sellerInfo" style="font-weight:bold;font-size:12px;font-family:verdana,arial,helvetica,sans-serif;">
                            </span><%#Eval("CellNo") %>
                        </div>
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Seller Address: </strong> 
                            <span class="sellerInfo" style="font-weight:bold;font-size:12px;font-family:verdana,arial,helvetica,sans-serif;">
                            </span><%#Eval("UserAddress") %>, 
                            <%#Eval("Province") %>, 
                            <%#Eval("State") %>, 
                            <%#Eval("Country") %>
                        </div>
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Review: </strong> 
                            <span class="sellerInfo" style="font-size:12px;font-family:verdana">
                            </span>
                            <a href="ItemDetail_Books.aspx?PageMode=1&PSID=<%#Eval("ProductSellerDetailID") %>&PID=<%#Eval("ProductID") %>&CID=1&SCID=<%#Eval("SubcategoryID") %>&SSCID=<%#Eval("SecondSubcatID")%>">
                            (<%#Eval("NoOfReview") %>)
                            </a> user commented on this book.<br />
                            <strong style="font-size:12px;font-family:verdana">
                            Posted On: </strong><%#Eval("InsertedOn") %>
                        </div>
                    </td>
                    <td class="itemContainer" style="text-align:left; vertical-align:top">
                    <asp:ImageButton
                        ID="btnAddToCart" 
                        runat="server" 
                        CommandName="AddToCart"
                        CausesValidation="false"
                        ImageUrl="~/Images/btnAddToCart.gif"
                        CommandArgument='<%# grvMixedBookList.Rows.Count.ToString() %>' />
                     </td>
                     </tr>
                     </table>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        </cc1:TabPanel>
                        
        <cc1:TabPanel ID="tpNewItems" runat="server" HeaderText="New">
        <ContentTemplate>
            <asp:GridView   
                ID="grvNewBookList"
                runat="server"
                DataKeyNames="ProductSellerDetailID,ProductID"
                AutoGenerateColumns="False"
                AllowPaging="false"  Width="790px"
                GridLines="None" OnRowCommand="grvNewBookList_RowCommand">
                
                <AlternatingRowStyle BackColor="#F5F5F7" />
                <HeaderStyle Height="25px" BackColor="#EFEFE2" HorizontalAlign="Left"/>
                <Columns>
                <asp:TemplateField>
                <HeaderTemplate>
                <table style="width:100%; color:#000000" cellspacing="0px" cellpadding="0px">
                    <thead>
                    <tr>
                    <th class="columnheader" style="width:18%;">
                    Price
                    </th>
                    <th class="columnheader" style="width:22%; ">
                    Condition
                    </th>
                    <th class="columnheader" style="width:40%; ">
                    Seller Information
                    </th>
                    <th class="columnheader">
                    Buy this Book?
                    </th>
                    </tr>
                    </thead>
                </table>
                </HeaderTemplate>
                    <ItemTemplate>
                    <table style="width:100%; color:#000000" cellspacing="0px" cellpadding="0px">
                    <tr>
                    <td class="itemContainer" style="width:18%; height:137px;text-align:left; padding:6px 6px 6px 10px; vertical-align:top">
                        <span class="price" style="font-weight:bold; font-family:verdana">
                        <%#Eval("Price") %>&nbsp;<%#Eval("Currency") %>
                        </span>
                    </td>
                    <td class="itemContainer" style="width:22%; height:137px;text-align:left; padding:6px 6px 6px 10px;vertical-align:top">
                        <span class="productCondition" style="font-size:12px; font-family:verdana">
                        <%#Eval("Condition") %>
                        </span>
                   </td>
                    
                   <td class="itemContainer" style="width:40%;height:137px;text-align:left; padding:6px 6px 6px 10px; vertical-align:top">
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Seller: </strong> 
                            <span class="sellerInfo" style="font-weight:bold;font-size:12px;font-family:verdana,arial,helvetica,sans-serif;">
                            </span><%#Eval("SellerInfo") %>
                        </div>
                        
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Cell # </strong> 
                            <span class="sellerInfo" style="font-weight:bold;font-size:12px;font-family:verdana,arial,helvetica,sans-serif;">
                            </span><%#Eval("CellNo") %>
                        </div>
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Seller Address: </strong> 
                            <span class="sellerInfo" style="font-weight:bold;font-size:12px;font-family:verdana,arial,helvetica,sans-serif;">
                            </span><%#Eval("UserAddress") %>, 
                            <%#Eval("Province") %>, 
                            <%#Eval("State") %>, 
                            <%#Eval("Country") %>
                        </div>
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Review: </strong> 
                            <span class="sellerInfo" style="font-size:12px;font-family:verdana">
                            </span>
                            <a href="ItemDetail_Books.aspx?PageMode=1&PSID=<%#Eval("ProductSellerDetailID") %>&PID=<%#Eval("ProductID") %>&CID=1&SCID=<%#Eval("SubcategoryID") %>&SSCID=<%#Eval("SecondSubcatID")%>">
                            (<%#Eval("NoOfReview") %>)
                            </a>
                            user commented on this book.<br />
                            <strong style="font-size:12px;font-family:verdana">
                            Posted On: </strong><%#Eval("InsertedOn") %>
                        </div>
                    </td>
                    <td class="itemContainer" style="text-align:left; vertical-align:top">
                    <asp:ImageButton
                        ID="btnAddToCart" 
                        runat="server" 
                        CommandName="AddToCart"
                        CausesValidation="false"
                        ImageUrl="~/Images/btnAddToCart.gif" 
                        CommandArgument='<%# grvNewBookList.Rows.Count.ToString() %>' />
                     </td>
                     </tr>
                     </table>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table style="width:100%;" cellspacing="0px" cellpadding="0px">
                    <thead >
                    <tr style="background-color:#EFEFE2;height:25px">
                    <td></td>
                    </tr>
                    </thead>
                    <tbody>
                    <tr>
                    <td style="color:Black;">
                    We are sorry that currently there are no <span class="title">New</span> item listed with this product title. However
                    you can look for this item in the <span class="title">Used</span> category.
                    </td>
                    </tr>
                    </tbody>
                    </table>
                </EmptyDataTemplate>
                <EmptyDataRowStyle BackColor="#EFEFE5" Font-Size="Larger" />
                
            </asp:GridView>
        </ContentTemplate>
        </cc1:TabPanel>
        
        
        <cc1:TabPanel ID="tpUsedItems" runat="server" HeaderText="Used">
        <ContentTemplate>
        <asp:GridView   
                ID="grvUsedBookList"
                runat="server"
                
                DataKeyNames="ProductSellerDetailID,ProductID"
                AutoGenerateColumns="False"
                AllowPaging="false"  Width="790px"
                Font-Names="Verdana"
                GridLines="None" OnRowCommand="grvUsedBookList_RowCommand">
              

                <AlternatingRowStyle BackColor="#F5F5F7" />
                <HeaderStyle Height="25px" BackColor="#EFEFE2" HorizontalAlign="Left"/>
                 
                <Columns>
                 <asp:TemplateField>
                <HeaderTemplate>
                <table style="width:100%; color:#000000" cellspacing="0px" cellpadding="0px">
                    <thead>
                    <tr>
                    <th class="columnheader" style="width:18%;">
                    Price
                    </th>
                    
                    <th class="columnheader" style="width:22%; ">
                    Condition
                    </th>
                    
                    <th class="columnheader" style="width:40%; ">
                    Seller Information
                    </th>
                    
                    <th class="columnheader">
                    Buy this Book?
                    </th>
                    </tr>
                    </thead>
                </table>
                </HeaderTemplate>
                    <ItemTemplate>
                    <table style="width:100%; color:#000000" cellspacing="0px" cellpadding="0px">
                    <tr>
                    <td class="itemContainer" style="width:18%; height:137px;text-align:left; padding:6px 6px 6px 10px; vertical-align:top">
                        <span class="price" style="font-weight:bold; font-family:verdana">
                        <%#Eval("Price") %>&nbsp;<%#Eval("Currency") %>
                        </span>
                    </td>
                   
                    
                    <td class="itemContainer" style="width:22%; height:137px;text-align:left; padding:6px 6px 6px 10px;vertical-align:top">
                        <span class="productCondition" style="font-size:12px; font-family:verdana">
                        <%#Eval("Condition") %>
                        </span>
                   </td>
                    
                    <td class="itemContainer" style="width:40%;height:137px;text-align:left; padding:6px 6px 6px 10px; vertical-align:top">
                        
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Seller: </strong> 
                            <span class="sellerInfo" style="font-weight:bold;font-size:12px;font-family:verdana,arial,helvetica,sans-serif;">
                            
                            </span><%#Eval("SellerInfo") %>
                        </div>
                        
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Cell # </strong> 
                            <span class="sellerInfo" style="font-weight:bold;font-size:12px;font-family:verdana,arial,helvetica,sans-serif;">
                            
                            </span><%#Eval("CellNo") %>
                            
                        </div>
                        
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Seller Address: </strong> 
                            <span class="sellerInfo" style="font-weight:bold;font-size:12px;font-family:verdana,arial,helvetica,sans-serif;">
                            
                            </span><%#Eval("UserAddress") %>, 
                            <%#Eval("Province") %>, 
                            <%#Eval("State") %>, 
                            <%#Eval("Country") %>
                            
                        </div>
                        
                        <div>
                            <strong style="font-size:12px;font-family:verdana">
                            Review: </strong> 
                            <span class="sellerInfo" style="font-size:12px;font-family:verdana">
                            
                            </span>
                            <a href="ItemDetail_Books.aspx?PageMode=1&PSID=<%#Eval("ProductSellerDetailID") %>&PID=<%#Eval("ProductID") %>&CID=1&SCID=<%#Eval("SubcategoryID") %>&SSCID=<%#Eval("SecondSubcatID")%>">
                           (<%#Eval("NoOfReview") %>) 
                            </a>
                            user commented on this book.<br />
                            <strong style="font-size:12px;font-family:verdana">
                            Posted On: </strong><%#Eval("InsertedOn") %>
                        </div>
                    </td>
                    <td class="itemContainer" style="text-align:left; vertical-align:top">
                    <asp:ImageButton
                        ID="btnAddToCart" 
                        runat="server" 
                        CommandName="AddToCart"
                        CausesValidation="false"
                        ImageUrl="~/Images/btnAddToCart.gif"
                        CommandArgument='<%# grvUsedBookList.Rows.Count.ToString() %>' />
                     </td>
                     </tr>
                     </table>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table style="width:100%;" cellspacing="0px" cellpadding="0px">
                    <thead >
                    <tr style="background-color:#EFEFE2;height:25px">
                    <td></td>
                    </tr>
                    </thead>
                    <tbody>
                    <tr>
                    <td style="color:Black;">
                    We are sorry that currently there are no <span class="title">Used</span> item listed with this product title. However
                    you can look for this item in the <span class="title">New</span> category.
                    </td>
                    </tr>
                    </tbody>
                    </table>
                </EmptyDataTemplate>
            
                
            </asp:GridView>
        </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    </div>
    <asp:HiddenField ID="txtAuthor" runat="server" />
    &nbsp;
    <asp:HiddenField ID="txtImagePath" runat="server" />
    <asp:HiddenField ID="txtProductTitle" runat="server" />
    <asp:HiddenField ID="txtNewMinPrice" runat="server" />
    <asp:HiddenField ID="txtUsedMinPrice" runat="server" />
    <asp:HiddenField ID="txtCurrency" runat="server" />
    <asp:HiddenField ID="txtDiscountPrice" runat="server" />
    <asp:HiddenField ID="txtPID" runat="server" />
    <asp:HiddenField ID="txtCID" runat="server" />
    <asp:HiddenField ID="txtSCID" runat="server" />
    <asp:HiddenField ID="txtSSCID" runat="server" />
</asp:Content>

