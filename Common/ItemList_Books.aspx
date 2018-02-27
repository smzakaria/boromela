<%@ Page Language="C#" MasterPageFile="~/Common/MPCommonListing.master" AutoEventWireup="true" CodeFile="ItemList_Books.aspx.cs" Inherits="Common_ItemList_Books" Title="www.boromela.com Book Listing." %>

<%@ Register Src="../UserControl/BookList_LeftMenu.ascx" TagName="BookList_LeftMenu"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
    <td >
        <asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" EnableViewState="False" Width="100%" Font-Size="11px">
        </asp:Label>
    </td>
    </tr>
    
    <tr>
    <td valign="top" style="width:620px; padding-right:0px">
    <!--Category Name-->
    <span class="pageTitle">Books for sale</span>
    <br /><br />
    Shown below are <strong style="color:Red;"><%=this.Subcategory%></strong> for sale in <strong style="color:#004B91;"><%=this.Location%></strong>
    <br /><br />
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-bottom:1px solid #d5d5d5;">
        <tr>
        <td width="3"><img src="../images/title_bar_left.gif" alt="" width="3" height="28" /></td>
        <td width="600" style="background-image:url(../images/title_bar_bg.gif); background-repeat:repeat-x; padding-left:5px;"><%=this.Subcategory%></td>
        <td width="3"><img src="../images/title_bar_right.gif" alt="" width="3" height="28" /></td>
        
        </tr>
    </table>
    <!--Headers-->
     
    <div id="itemListContainer" runat="server" style="width:100%; margin-top:0px ">
    <asp:GridView 
        ID="grvItemList" 
        runat="server" 
        Width="100%" 
        AutoGenerateColumns="false" 
        DataKeyNames="ProductID" 
        GridLines="None" 
        AllowPaging="true" 
        PageSize="10" 
        Font-Size="11px" OnPageIndexChanging="grvItemList_PageIndexChanging">
        <EmptyDataTemplate>
           
        </EmptyDataTemplate>
        
        <AlternatingRowStyle BackColor="#F5F5F7" />
        
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div style="height:160px; margin-bottom:5px;">
	                 <div class="itemListImage" >
	                    <a href="ItemDetail_Books.aspx?PageMode=0&PID=<%#Eval("ProductID") %>&CID=1&SCID=<%#Eval("SubcategoryID") %>&SSCID=<%#Eval("SecondSubcatID")%>&Location=<%=this.Location %>">
	                     <asp:Image 
	                        ID="image" 
	                        runat="server" 
	                        ImageUrl='<%#(string)Eval("ProductImage")%>'
	                        AlternateText='<%#(string)Eval("ProductTitle")%>'
	                        Width="115px" 
	                        Height="115px"/>   
	                    </a>
	                 </div>
	                 <div class="itemListDescription" >
	                    <div class="productTitle">
	                    <span class="title">
	                     <%#Eval("ProductTitle") %></span> by 
    	                 
    	                 <a style="text-decoration:underline; line-break:strict" href="ItemList_Books.aspx?PageMode=1&CID=1&SCID=<%#this.SubcategoryID%>&Author=<%#Eval("Author")%>&Location=<%=this.Location %>">
	                     <%#Eval("Author") %>
	                     </a>
	                    </div>
                    <div class="miscLine">
	                     <a style="color:#004B91; " href="UsedAndNew_Books.aspx?PageMode=0&PID=<%#Eval("ProductID") %>&CID=1&SCID=<%# this.SubcategoryID%>&SSCID=<%# Eval("SecondSubcatID") %>">
	                     <%#Eval("NoOfSeller") %> Used and New</a>
	                 </div>
	                 
	                 <div class="miscLine">
	                    Highest price: <strong style="color:#990000;"><%# Eval("MaxPrice") %> <%#Eval("Currency") %></strong>&nbsp&
	                    Lowest price:<strong style="color:#990000;"><%# Eval("MinPrice")%> <%#Eval("Currency") %></strong>
	                 </div>
	                 
	                 
	                 
	                 <div class="miscLine">
	                    <a href="ItemDetail_Books.aspx?PageMode=0&PID=<%#Eval("ProductID") %>&CID=1&SCID=<%#Eval("SubcategoryID") %>&SSCID=<%#Eval("SecondSubcatID")%>">
	                    (<%#Eval ("Reviews")%>) 
	                    </a>users commented on this book.
	                 </div>
	             
	                 </div>
	                 </div>
           
                </ItemTemplate>
                
            </asp:TemplateField>
        </Columns>            
       <PagerSettings Position="TopAndBottom"  />
       
    </asp:GridView>
    </div>        
    </td>

    
    </tr>
    
</table> 
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <uc1:BookList_LeftMenu ID="BookList_LeftMenu1" runat="server" />
</asp:Content>

