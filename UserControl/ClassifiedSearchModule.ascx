<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClassifiedSearchModule.ascx.cs" Inherits="UserControl_ClassifiedSearchModule" %>

<table width="175px" cellpadding="0px" cellspacing="0px" style="border:1px solid #C9E1F4; ">
    <tr>
    <td align="center">
    <asp:Label ID="lblSystemMessage" runat="server" ForeColor="red" Font-Size="11px" EnableViewState="False" >
    </asp:Label>
    </td>
    </tr>
    
    
    <tr >
    <td>
    <asp:GridView 
        ID="grvCategory"
        runat="server" Width="173px"
        AllowPaging="false" 
        GridLines="none"
        AutoGenerateColumns="false" HeaderStyle-Height="20px">
    <HeaderStyle  BackColor="#EFEFE2"/>
    
    
    <Columns>
    <asp:TemplateField>
    <HeaderTemplate>
    <span class="price" style="font-size:14px; font-weight:bold;" >
    All Categories
    </span>
    </HeaderTemplate>
    <ItemTemplate>
    <div style="padding:5px 0px 0px 5px">
        <a href="ItemList_Classifieds.aspx?&PageMode=0&CID=<%#Eval("CategoryID") %>&Location=<%#Eval("Country") %>">
        <%#Eval("Category") %>(<%#Eval("NoOfItems") %>)
        </a>
    </div>
    </ItemTemplate>
    </asp:TemplateField>
    
    </Columns>
    
    </asp:GridView>
    
    </td>
    </tr>
    <tr>
    <td style="height:25px; font-weight:bold; padding-left:5px">
    
    <asp:Repeater ID="repNegotiable" runat="server">
    <ItemTemplate>
    <a href="ItemList_Classifieds.aspx?PageMode=2&CID=<%=this.CategoryID %>">
    Negotiable(<%#DataBinder.Eval(Container.DataItem, "Negotiable") %>)
    </a>
    
    </ItemTemplate>
    </asp:Repeater>
    
    </td>
    </tr>
    
    <tr style="padding:10px 0px 10px 0px;">
    <td >
    <asp:DataList 
        ID="dlst" 
        runat="server"  DataMember="ProviceID"  
        ItemStyle-HorizontalAlign="justify"
         Font-Names="Verdana" 
        Font-Size="12px" HeaderStyle-Height="20px"
        RepeatLayout="table" CaptionAlign="Top">
        <HeaderStyle BackColor="#EFEFE2" HorizontalAlign="center" Width="171px"/>
        
        <HeaderTemplate> 
        <span class="price" style="font-size:14px; " >
        Locations
        </span>
        </HeaderTemplate>
            
            <ItemTemplate> 
            <div style="padding:5px 0px 0px 5px">
            <a  href="ItemList_Classifieds.aspx?PageMode=1&ProvKey=<%#Eval("ProvinceID") %>&CID=<%=this.CategoryID %>">
                <%#Eval("Province") %>(<%#Eval("NumberOfClassifiedProduct")%>)
            </a>
            </div>
        
            </ItemTemplate>
        <ItemStyle Width="150px" HorizontalAlign="Justify" />
    </asp:DataList>
    
    </td>
    </tr>
    </table>