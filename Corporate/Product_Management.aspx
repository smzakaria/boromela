<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="Product_Management.aspx.cs" Inherits="Corporate_Product_Management"
    Title="www.boromela.com" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="updatePanel" runat="server">
<ContentTemplate>

    <div style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px;
        width: 815px; padding-top: 0px">
        <table style="border-bottom: #efefe2 1px solid; color: #000000" class="cptable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td style="font-size: 11px" align="left" colspan="2">
                        <asp:ValidationSummary 
                            ID="ValidationSummary1" 
                            runat="server" 
                            ValidationGroup="Title"
                            Font-Size="11px" BorderWidth="1px" 
                            BorderStyle="Dashed" 
                            HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>"
                            Font-Bold="False" 
                            ForeColor="Black" BackColor="#FFFFFF" Width="500px"></asp:ValidationSummary>
                        
                        <asp:Label 
                            ID="lblSystemMessage" 
                            runat="server" Font-Size="11px" ForeColor="Red"
                            Width="500px" EnableViewState="False">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <span class="pageTitle">List Single Items for Sale </span>
                        <p>
                            Boromela.com Product Management.<br />
                            Sell on the same product detail pages where other merchants sell their items!
                        </p>
                        <p style="padding-left: 5px; line-height: 25px">
                            <span style="color: #cc6600" class="title">1)Search.</span> Find the item in our
                            catalog of products.<br />
                            <span style="color: #cc6600" class="title">2)List.</span> Tell us the condition,
                            price, quantity and other condition of the items you want to sell.<br />
                            <span style="color: #cc6600" class="title">3)Or.</span> You can create your own
                            product details. Just by searching for duplicacy.<br />
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="right">
                        Fields marked by <span class="mandatory">*</span> are mandatory
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; height: 25px">
                        SKU (Stock Keeping Unit):
                    </td>
                    <td style="height: 25px">
                        <asp:Label ID="lblSku" runat="server">&nbsp
                        </asp:Label>
                        <asp:TextBox ID="txtTemp" runat="server" BorderStyle="Groove" Width="40px" Visible="False">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 200px; height: 25px">
                        Category:<span class="mandatory">*</span>
                    </td>
                    <td style="vertical-align: top; height: 25px">
                        <asp:DropDownList ID="ddlCategory" runat="server" Width="350px" DataTextField="Category"
                            DataValueField="CategoryID" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
                            AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Text="Select Category" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ValidationGroup="Title"
                            Font-Bold="True" SetFocusOnError="True" InitialValue="-1" ErrorMessage="Select Category"
                            ControlToValidate="ddlCategory">?</asp:RequiredFieldValidator>
                        <asp:LinkButton ID="btnChangeCategory" OnClick="btnChangeCategory_Click" runat="server"
                            Font-Size="12px" Visible="False" Font-Underline="true" 
                            Font-Names="verdana,arial,helvetica,sans-serif">Refine Search</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 200px; height: 25px">
                        Subcategory:<span class="mandatory">*</span>
                    </td>
                    <td style="vertical-align: top; height: 25px">
                        <asp:DropDownList ID="ddlSubcategory" runat="server" Width="350px" DataTextField="Subcategory"
                            DataValueField="SubcategoryID" OnSelectedIndexChanged="ddlSubcategory_SelectedIndexChanged"
                            AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Text="Select Subcategory" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSubcategory" runat="server" ValidationGroup="Title"
                            Font-Bold="True" SetFocusOnError="True" InitialValue="-1" ErrorMessage="Select Subcategory"
                            ControlToValidate="ddlSubcategory">?</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 200px; height: 25px">
                        Secondary Subcategory: <span class="mandatory">*</span>
                    </td>
                    <td style="vertical-align: top; height: 25px">
                        <asp:DropDownList ID="ddl2ndSubCategory" runat="server" Width="350px" DataTextField="SecondSubcategory"
                            DataValueField="SecBookSubcategoryID" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Text="Select Second Subcategory" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSecondSucategory" runat="server" ValidationGroup="Title"
                            Font-Bold="True" SetFocusOnError="True" InitialValue="-1" ErrorMessage="Select Second subcategory"
                            ControlToValidate="ddl2ndSubCategory">?</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 200px; height: 25px">
                        <asp:Label ID="lblModel" runat="server" Text="Model:">
                        </asp:Label>&nbsp;&nbsp;
                    </td>
                    <td style="vertical-align: top; height: 25px">
                        <asp:DropDownList ID="ddlModel" runat="server" Width="350px" DataTextField="Model"
                            DataValueField="ModelID" AppendDataBoundItems="True" AutoPostBack="True" Enabled="False">
                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hfCategoryID" runat="server" Visible="False"></asp:HiddenField>
                        <asp:HiddenField ID="hfProductID" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hfSubcategoryID" runat="server" Visible="False"></asp:HiddenField>
                        <asp:HiddenField ID="hfSecondSubcatID" runat="server" Visible="False"></asp:HiddenField>
                        <asp:HiddenField ID="hfProfileID" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hfProductTitle" runat="server"></asp:HiddenField>
                        &nbsp; &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 200px; height: 25px">
                        &nbsp;
                    </td>
                    <td style="vertical-align: top; height: 25px">
                        <asp:Label ID="lblTitleMessage" runat="server" Font-Size="11px" ForeColor="DarkGreen"
                            Width="100%" EnableViewState="False"></asp:Label></td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 230px; height: 25px">
                        Product Title:<span class="mandatory">*</span>
                    </td>
                    <td style="vertical-align: top; height: 25px">
                        <asp:TextBox ID="txtTitle" runat="server" Width="350px" MaxLength="250" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ValidationGroup="Title"
                            Font-Bold="True" ErrorMessage="Product Title field is blank !" ControlToValidate="txtTitle">?</asp:RequiredFieldValidator>
                        <asp:LinkButton ID="btnCheckDuplicacy" OnClick="btnCheckDuplicacy_Click" runat="server"
                            Font-Size="12px" Visible="False" Font-Underline="true" Font-Names="verdana,arial,helvetica,sans-serif">Check For Duplicacy
                        </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 200px; height: 25px">
                        &nbsp;</td>
                    <td style="vertical-align: top; height: 25px">
                        <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" ValidationGroup="Title"
                            BorderStyle="Groove" Text="Search"></asp:Button>&nbsp;
                        <asp:Button ID="btnRejectTitle" runat="server" BorderStyle="Groove" Visible="False"
                            Text="Reject" CausesValidation="False"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; height: 25px" colspan="2">
                    </td>
                </tr>
            </tbody>
        </table>
        <asp:GridView 
            ID="grvProduct" 
            runat="server" 
            Font-Size="11px" Width="100%" Font-Names="Verdana"
            OnRowCommand="grvProduct_RowCommand" AutoGenerateColumns="False" 
            RowStyle-BackColor="#FFFFFF"
            DataKeyNames="ProductID, ProductTitle" GridLines="None" 
            AllowPaging="True" PageSize="10"
            OnPageIndexChanging="grvProduct_PageIndexChanging" PagerSettings-Position="TopAndBottom">
            <HeaderStyle Height="25px" BackColor="#FFFFFF" />
            <AlternatingRowStyle BackColor="#F5F5F7" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%; background-color: #FFFFFF;" cellspacing="0px" cellpadding="0px"
                            border="0px">
                            <tr>
                                <td style="height: 25px; text-align: left; font-size: 13px; width: 600px; padding-left: 10px;
                                    font-weight: normal;">
                                    <%= ddlCategory.SelectedItem.Text %>
                                    : <span class="title">"<%=txtTitle.Text %>"</span>
                                </td>
                                <td style="padding-right: 10px; text-align: right">
                                    <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" />
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%;" cellspacing="0px" cellpadding="0px" border="0px">
                            <tr style="text-align: left; background-color: #EFEFE2;">
                                <td style="width: 100%; height: 25px; padding-left: 10px">
                                    Displaying 1-<%=this.SearchResult > 10 ? 10 : this.SearchResult %>
                                    of
                                    <%=this.SearchResult %>
                                    Results. You can either select any one item from the list or you can create your
                                    own item page.
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 100%; color: #CCCCCC;" cellspacing="0px" border="0px" cellpadding="0px">
                            <tr style="vertical-align: top; height: 115px">
                                <td class="columnheader" style="width: 100px; padding: 10px 0px 10px 10px">
                                    <asp:Image ID="productImage" runat="server" ImageUrl='<%#Eval("ProductImage") %>'
                                        Width="95px" Height="95px" />
                                </td>
                                <td style="width: 570px; text-align: left; color: Black; padding: 10px 0px 10px 15px">
                                    <div>
                                        <span class="title">
                                            <%#Eval("ProductTitle")%>
                                        </span>
                                    </div>
                                    by <strong>
                                        <%# Eval("Author")%>
                                    </strong>
                                </td>
                                <td class="columnheader" style="padding: 10px 10px 0px 0px; vertical-align: middle;
                                    text-align: left; vertical-align:top">
                                    <asp:ImageButton ID="btnSelectProduct" CommandArgument='<%#grvProduct.Rows.Count.ToString() %>'
                                        CommandName="SelectProduct" runat="server" ImageUrl="~/Images/btn_sell_here.gif" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table style="width: 100%; color: Black;" cellspacing="0px" cellpadding="0px" border="0px">
                    <tr style="text-align: left">
                        <td class="columnheader" style="width: 200px;">
                        </td>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
        <div style="width: 100%; text-align: right">
            &nbsp;<asp:Button ID="btnNext" runat="server" BorderStyle="Groove" Visible="False"
                Text="Next" OnClick="btnNext_Click"></asp:Button>
        </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
