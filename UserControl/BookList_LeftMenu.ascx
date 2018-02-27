<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BookList_LeftMenu.ascx.cs" Inherits="UserControl_BookList_LeftMenu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />

<div class="leftContent" style="width:165px; padding:0px; margin:0px;border:1px solid #C9E1F4">
    
    <div class="header" style="margin:0px" >
    Authors
    </div>
    
    <div class="top10ContentList" >
    
    <asp:GridView 
    ID="grvTopAuthor" 
    runat="server" 
    Width="155px" 
    AutoGenerateColumns="false" 
    DataKeyNames="Author" 
    GridLines="None" 
    AllowPaging="false" 
    Font-Size="8px" >
        <Columns>
        <asp:TemplateField>
            <ItemTemplate>
            <table width="155px" border="0" cellspacing="0" cellpadding="0">                    
            <tr>
            <td>
                <strong  style="font-size:11px; font-family:Verdana; font-weight:normal;">
                <a href="ItemList_Books.aspx?PageMode=1&CID=1&SCID=<%#this.intSubcategoryID%>&Author=<%#Eval("Author")%>&Location=<%=this.SelectedLocation %>">
                <%#Eval("Author")%>
                </a>
            </strong>
            <br />
            </td>
            </tr>            
            </table>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>            
    <PagerSettings Position="TopAndBottom" />
    </asp:GridView>
         
         <!--Gridview for top 10 author list--> 
    </div>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </ajaxToolkit:ToolkitScriptManager>
    
    <asp:Panel ID="AuthorPanel" Width="155px" runat="server" Height="30px">
    <div class="header" style="cursor:pointer; margin:0px; text-decoration:underline">
    See full Author's list
    </div>
    </asp:Panel>
    
    <asp:Panel ID="AuthorListPanel" runat="server" CssClass="collapsePanel" >
    <asp:GridView 
        ID="grvAllAuthor" 
        runat="server" 
        Width="155px" 
        AutoGenerateColumns="false" 
        DataKeyNames="Author" 
        GridLines="None" 
        AllowPaging="false" 
        
        Font-Size="8px" >
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
            <table width="155px" border="0" cellspacing="0" cellpadding="0">                    
            <tr>
            <td>
            <strong  style="font-size:11px; font-family:Verdana; font-weight:normal; padding-left:5px;">
            <a href="ItemList_Books.aspx?PageMode=1&CID=1&SCID=<%#this.intSubcategoryID%>&Author=<%#Eval("Author")%>&Location=<%=this.SelectedLocation %>">
            <%#Eval("Author")%>
            </a>
            </strong>
            <br />
            </td>
            </tr>            
            </table>
           </ItemTemplate>
        </asp:TemplateField>
    </Columns>            
</asp:GridView>
     
     <!--Gridview for Full author list-->         
     </asp:Panel>
     <ajaxToolkit:CollapsiblePanelExtender 
        ID="cpeAuthor" 
        runat="server"  
        TargetControlID="AuthorListPanel"
        ExpandControlID="AuthorPanel"
        CollapseControlID="AuthorPanel" 
        Collapsed="True"
        SuppressPostBack="true"
        SkinID="CollapsiblePanelDemo" />
    
    <div class="header">
    Category
    </div>
    
    <div class="top10ContentList">
    
    <asp:GridView 
    ID="grvTopSecondSubcategory" 
    runat="server" 
    Width="155px" 
    AutoGenerateColumns="false" 
    DataKeyNames="SecondSubcategory" 
    GridLines="None" 
    AllowPaging="false" 
    Font-Size="8px" >
        <Columns>
        <asp:TemplateField>
            <ItemTemplate>
            <table width="155px" border="0" cellspacing="0" cellpadding="0">                    
            <tr>
            <td>
                <strong  style="font-size:11px; font-family:Verdana; font-weight:normal;">
                <a href="ItemList_Books.aspx?PageMode=2&CID=1&SCID=<%#this.intSubcategoryID%>&SSCID=<%#Eval("SecondSubcatID")%>&Location=<%=this.SelectedLocation %>">
                <%#Eval("SecondSubcategory")%>
                </a>
            </strong>
            <br />
            </td>
            </tr>            
            </table>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>            
    </asp:GridView>
    
    
         <!--Gridview for top 10 Category list--> 
    </div>
    
        
    <asp:Panel ID="CategoryPanel" runat="server" Height="30px" Width="155px">
    <div class="header" style="cursor:pointer; margin:0px;text-decoration:underline">
    See full Category list
    </div>
    </asp:Panel>
    
    
     <asp:Panel ID="CategoryListPanel" runat="server" CssClass="collapsePanel" width="155px">
     
     
     <asp:GridView 
    ID="grvAllSecondSubcategory" 
    runat="server" 
    Width="155px" 
    AutoGenerateColumns="false" 
    DataKeyNames="SecondSubcategory" 
    GridLines="None" 
    AllowPaging="false" 
    Font-Size="8px" >
        <Columns>
        <asp:TemplateField>
            <ItemTemplate>
            <table width="155px" border="0" cellspacing="0" cellpadding="0">                    
            <tr>
            <td>
                <strong  style="font-size:11px; font-family:Verdana; font-weight:normal; padding-left:5px;">
                 <a href="ItemList_Books.aspx?PageMode=2&CID=1&SCID=<%#this.intSubcategoryID%>&SSCID=<%#Eval("SecondSubcatID")%>&Location=<%=this.SelectedLocation %>">
                <%#Eval("SecondSubcategory")%>
                </a>
            </strong>
            <br />
            </td>
            </tr>            
            </table>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>            
    </asp:GridView>
     <!--Gridview for Full Category list-->         
     </asp:Panel>
     
     <ajaxToolkit:CollapsiblePanelExtender 
        ID="cpeSecSubcategory" 
        runat="server" 
        TargetControlID="CategoryListPanel"
        ExpandControlID="CategoryPanel"
        CollapseControlID="CategoryPanel" 
        Collapsed="True"
        
        SuppressPostBack="true"
        SkinID="CollapsiblePanelDemo" />
        
    <div class="header">
    Publisher
    </div>
    
    <div class="top10ContentList">
    <asp:GridView 
    ID="grvTopPublisher" 
    runat="server" 
    Width="155px" 
    AutoGenerateColumns="false" 
    DataKeyNames="Publisher" 
    GridLines="None" 
    AllowPaging="false" 
    
    Font-Size="8px" >
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
            <table width="155px" border="0" cellspacing="0" cellpadding="0">                    
                <tr>
                <td>
                <strong  style="font-size:11px; font-family:Verdana; font-weight:normal;">
                <a href="ItemList_Books.aspx?PageMode=3&CID=1&SCID=<%#this.intSubcategoryID%>&Publisher=<%#Eval("Publisher")%>&Location=<%=this.SelectedLocation %>">
                <%#Eval("Publisher")%>
                </a>
                </strong>
                <br />
                </td>
                </tr>            
            </table>
           </ItemTemplate>
        </asp:TemplateField>
    </Columns>            
    <PagerSettings Position="TopAndBottom" />
    </asp:GridView>
    
         <!--Gridview for top 10 Publisher list--> 
    </div>
    
        
    <asp:Panel ID="PublisherPanel" runat="server" Height="30px" Width="155px">
    <div class="header" style="cursor:pointer; margin:0px; text-decoration:underline">
    See full Publisher list
    </div>
    </asp:Panel>
    
    
    <asp:Panel ID="PublisherListPanel" runat="server" CssClass="collapsePanel" width="155px">
     
    <asp:GridView 
    ID="grvAllPublisher" 
    runat="server" 
    Width="155px" 
    AutoGenerateColumns="false" 
    DataKeyNames="Publisher" 
    GridLines="None" 
    AllowPaging="false" >
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
            <table width="155px" border="0" cellspacing="0" cellpadding="0">                    
                <tr>
                <td>
                <strong  style="font-size:11px; font-family:Verdana; font-weight:normal; padding-left:5px;">
                <a href="ItemList_Books.aspx?PageMode=3&CID=1&SCID=<%#this.intSubcategoryID%>&Publisher=<%#Eval("Publisher")%>&Location=<%=this.SelectedLocation %>">
                <%#Eval("Publisher")%>
                </a>
                </strong>
                <br />
                </td>
                </tr>            
            </table>
           </ItemTemplate>
        </asp:TemplateField>
    </Columns>            
    
    </asp:GridView>
     
    <!--Gridview for Full Publisher list-->         
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender 
        ID="cpePublisher" 
        runat="server"
        TargetControlID="PublisherListPanel"
        ExpandControlID="PublisherPanel"
        CollapseControlID="PublisherPanel" 
        Collapsed="True"
      
        SuppressPostBack="true"
        SkinID="CollapsiblePanelDemo" />
        
    
    <div class="header">Information</div>
    <div style="width:150px; padding-left:5px; margin:0px; padding-top:10px; line-height:16px; font-size:11px">
    <a href="#">Shipping Information</a><br />
    <a href="#">Order Tracking</a><br />
    <a href="#">Privacy and security</a><br />
    </div>
    
    </div>
