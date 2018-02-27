<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true"
    CodeFile="ProductProfileAE.aspx.cs" Inherits="Corporate_ProductProfileAE" Title="www.boromela.com – General Product." %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
    function IsDigit(e)
    {
        var key;
        if (window.event)
        {
            key = window.event.keyCode;
        }
        else if (e)
        {
            key = e.which;
        }
        else
        {
            return true;
        }
        if ((key > 47 && key < 58) || (key > 95 && key < 106))
        {
            return true;
        }
        if ( key==null || key==0 || key==8 || key==9 || key==13 || key==27 || key ==37 || key ==39 || key == 46 || key == 35 || key == 36)
        {
            return true;
        }

        return false;
    }        
    function isNumberKey(evt)      
    {         
        var charCode = (evt.which) ? evt.which : event.keyCode         
        if (charCode > 31 && (charCode < 48 || charCode > 57))            
            return true;         
        return false;      
    }


    </script>

    <span class="pageTitle">Corporate - Add/Edit Product Information.</span>
    <br />
    <br />
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                Fields marked by <span class="mandatory">*</span> are mandatory</td>
        </tr>
    </table>
    <div>
        <div class="inputForm" style="float: left; vertical-align: top; width: 100%;">
            <table id="TABLE1" border="0" cellpadding="0" cellspacing="0" class="cptable" style="border-top: #efefe2 1px solid"
                width="100%">
                <tr>
                    <td align="left" colspan="2" style="font-size: 11px">
                        &nbsp;&nbsp;
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" BackColor="#FFFFFF"
                            BorderStyle="Dashed" BorderWidth="1px" Font-Bold="False" Font-Size="11px" ForeColor="Black"
                            HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>"
                            Width="500px" />
                        <asp:Label ID="lblSystemMessage" runat="server" EnableViewState="False" Font-Size="11px"
                            ForeColor="Red" Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 25px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; height: 25px">
                        Quantity:<span class="mandatory">*</span>
                    </td>
                    <td style="height: 25px">
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="textbox" MaxLength="10" onkeydown="return IsDigit(event);"
                            Width="300px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvQuantity" runat="server"
                                ControlToValidate="txtQuantity" ErrorMessage="Quantity field is blank" Font-Bold="True">?</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 200px; height: 25px">
                        Currency:
                    </td>
                    <td style="height: 25px">
                        <asp:DropDownList ID="ddlCurrency" runat="server" Width="305px">
                            <asp:ListItem Text="BDT." Value="BDT."></asp:ListItem>
                            <asp:ListItem Text="USD." Value="USD."></asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 200px; height: 25px">
                        Price:<span class="mandatory">*</span>
                    </td>
                    <td style="height: 25px">
                        <asp:TextBox ID="txtProductPrice" runat="server" CssClass="textbox" MaxLength="10"
                            onkeydown="return IsDigit(event);" Width="300px">
                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvProductPrice" runat="server" ControlToValidate="txtProductPrice"
                            ErrorMessage="Product Price field is blank !" Font-Bold="True" SetFocusOnError="True">?</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 200px; height: 25px">
                        Description:
                    </td>
                    <td style="height: 25px">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" Height="80px"
                            MaxLength="500" TextMode="MultiLine" Width="300px">
                        </asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 200px; height: 33px">
                        Condition:
                    </td>
                    <td style="height: 33px">
                        <asp:DropDownList 
                            ID="ddlCondition" 
                            runat="server" 
                            OnSelectedIndexChanged="ddlCondition_SelectedIndexChanged"
                            Width="305px">
                            <asp:ListItem Text="New" Value="New"></asp:ListItem>
                            <asp:ListItem Text="Used" Value="Used"></asp:ListItem>
                            <asp:ListItem Text="Refurbished" Value="Refurbished"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtCondition" runat="server" BorderStyle="Groove" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; height: 33px">
                        Condition Note:
                    </td>
                    <td style="height: 33px">
                        <asp:TextBox ID="txtConditionNote" runat="server" CssClass="textbox" Height="70px"
                            MaxLength="300" TextMode="MultiLine" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; height: 33px">
                        Sale Offer:</td>
                    <td style="height: 33px">
                        <asp:CheckBox ID="chkSaleOffer" runat="server" AutoPostBack="True" OnCheckedChanged="chkSaleOffer_CheckedChanged"
                            Text="Check this option if you have any sale offer for this product. Leave uncheck otherwise." /></td>
                </tr>
            </table>
            <asp:UpdatePanel ID="updatePanel" runat="server">
            <ContentTemplate>
            <asp:Panel ID="panelSaleOffer" runat="server" Width="815px" Visible="false" Enabled="false">
                <table class="cptable" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td style="width: 200px; height: 25px">
                                Sale / Discounted Price:<span class="mandatory">*</span>
                            </td>
                            <td style="height: 25px">
                                <asp:TextBox onkeydown="return IsDigit(event);" ID="txtSalePrice" runat="server"
                                    Width="300px" MaxLength="10" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" runat="server" Font-Bold="True" ErrorMessage="Sale price field is blank."
                                        ControlToValidate="txtSalePrice">?</asp:RequiredFieldValidator><span style="color: #505050"
                                            class="gray11px"></span></td>
                        </tr>
                        <tr>
                            <td style="width: 200px">
                                Sale Starting Date:<span class="mandatory">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" Width="100px" CssClass="textbox"></asp:TextBox><asp:ImageButton
                                    ID="ibtnFromDate" runat="server" ImageUrl="~/Images/calendar.gif" CausesValidation="False">
                                </asp:ImageButton><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    Font-Bold="True" ErrorMessage="Sale start date field is blank." ControlToValidate="txtFromDate">?</asp:RequiredFieldValidator>Choose
                                from calender.<Ajax:CalendarExtender ID="ceFromDate" runat="server" TargetControlID="txtFromDate"
                                    PopupButtonID="ibtnFromDate">
                                </Ajax:CalendarExtender>
                                <span class="gray11px"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px">
                                Sale End Date:<span class="mandatory">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" Width="100px" CssClass="textbox"></asp:TextBox><asp:ImageButton
                                    ID="ibtnToDate" runat="server" ImageUrl="~/Images/calendar.gif" CausesValidation="False">
                                </asp:ImageButton><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    Font-Bold="True" ErrorMessage="Sale end date field is blank." ControlToValidate="txtToDate">?</asp:RequiredFieldValidator>Choose
                                from calender.<Ajax:CalendarExtender ID="ceToDate" runat="server" TargetControlID="txtToDate"
                                    PopupButtonID="ibtnToDate">
                                </Ajax:CalendarExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="chkSaleOffer" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
            </asp:UpdatePanel>

            <table width="100%" class="cptable" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td style="width: 200px; height: 25px">
                        &nbsp;
                        <asp:HiddenField ID="hfSku" runat="server" />
                        <asp:HiddenField ID="hfProfileID" runat="server" />
                        <asp:HiddenField ID="hfPageMode" runat="server" />
                        <asp:HiddenField ID="hfCategoryID" runat="server" />
                        <asp:HiddenField ID="hfSubcategoryID" runat="server" />
                        <asp:HiddenField ID="hfSecondSubcatID" runat="server" />
                        <asp:HiddenField ID="hfProductID" runat="server" />
                        <asp:HiddenField ID="hfInsertType" runat="server" />
                        <asp:HiddenField ID="hfProductTitle" runat="server" />
                        <asp:HiddenField ID="hfCategory" runat="server" />
                        <asp:HiddenField ID="hfSubcategory" runat="server" />
                        <asp:HiddenField ID="hfSecondSubcategory" runat="server" />
                        <asp:HiddenField ID="hfCanEdit" runat="server" />
                        &nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
                    <td style="height: 25px">
                        <asp:Button ID="btnNext" runat="server" BorderStyle="Groove" Text="Next" />
                    </td>
                </tr>
            </table>
            
            
            
           
        </div>
    </div>
</asp:Content>
