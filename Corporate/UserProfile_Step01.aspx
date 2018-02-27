<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate1.master" AutoEventWireup="true" CodeFile="UserProfile_Step01.aspx.cs" Inherits="Corporate_UserProfile_Step01" Title="www.boromela.com : User Registration." %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
        <td valign="top" style="padding-left:10px; padding-top:10px; padding-right:10px;">
        <div align="left" class="top_secondary_link">&nbsp;</div>
        <span style="font-size: 20px; color: #898989; font-family: verdana">New Business User Registration</span>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
             <td>&nbsp;</td>
             <td align="right">Fields marked by <span class="mandatory">*</span> are mandatory</td>
             </tr>

             <tr>
             <td>&nbsp;</td>
             <td height="20" align="right" valign="bottom"><div  class="step">Step 1 of 3</div></td>
             </tr>
             
             <tr>
             <td colspan="2" align="left" style="font-size:11px;">
             <asp:ValidationSummary 
                ID="ValidationSummary1" 
                runat="server" 
                Width="500px" 
                BackColor="#FFFFFF" 
                ForeColor="Black" 
                Font-Bold="False" 
                HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>" 
                BorderStyle="Dashed" 
                BorderWidth="1px"/>
             <asp:Label 
                ID="lblSystemMessage" 
                runat="server" 
                ForeColor="Red" 
                EnableViewState="False" 
                Width="500px" 
                Font-Size="11px">
             </asp:Label>                                        
             </td>
             </tr>
        </table>    
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style="border-top:1px solid #EFEFE2;" id="TABLE1">
            <tr>
            <td colspan="2" style="height:37px; color:#365EBF; text-decoration:underline;"><strong>Login Information </strong></td>
            </tr>
        
            <tr>
            <td width="200" style="height: 25px">Email:<span class="mandatory">*</span></td>
            <td style="height: 25px">
            <asp:TextBox 
                ID="txtEmail1" 
                runat="server" 
                Width="180px" 
                Height="15px"                        
                MaxLength="100" 
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;        
            <asp:RequiredFieldValidator 
                ID="rfvEmail1" 
                runat="server" 
                ControlToValidate="txtEmail1" 
                ErrorMessage="Email address field is blank! Please type your Email address properly." 
                SetFocusOnError="true" 
                Font-Bold="True">?</asp:RequiredFieldValidator>
            &nbsp;    
            <asp:RegularExpressionValidator 
                ID="revEmail1" 
                runat="server" 
                ControlToValidate="txtEmail1" 
                ErrorMessage="Invalid Email address! Please type your valid Email address." 
                SetFocusOnError="True"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                Font-Bold="True">?</asp:RegularExpressionValidator>       
            &nbsp;&nbsp;            
            <span class="gray11px">(this will be your Login ID.)</span>        
            </td>
            </tr>
        
            <tr>
            <td>Re-enter Email:<span class="mandatory">*</span></td>
            <td>
            <asp:TextBox 
                ID="txtEmail2" 
                runat="server"             
                Width="180px" 
                Height="15px" 
                MaxLength="100" 
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator 
                ID="rfvEmail2" 
                runat="server" 
                ControlToValidate="txtEmail2" 
                ErrorMessage="Email confirmation field is blank! Please re-type your Email address properly." 
                SetFocusOnError="true" 
                Font-Bold="True">?</asp:RequiredFieldValidator>
            &nbsp;            
            <asp:RegularExpressionValidator 
                ID="revEmail2"
                runat="server"
                ControlToValidate="txtEmail2" 
                ErrorMessage="You re-type an invalid Email address! Please type your valid Email address." 
                SetFocusOnError="true"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                Font-Bold="True">?</asp:RegularExpressionValidator>
            <br />
            <asp:CompareValidator 
                ID="cmvEmail" 
                runat="server" 
                ControlToCompare="txtEmail1"
                ControlToValidate="txtEmail2" 
                ErrorMessage="Your re-typed Email address does not match!  Please type the same Email address in both fields." 
                SetFocusOnError="True" 
                Font-Size="10px">
            </asp:CompareValidator>        
            </td>
            </tr>
        
            <tr>
            <td style="height: 25px">
            Create a boromela Password:<span class="mandatory">*</span></td>
            <td style="height: 25px">
            <asp:TextBox 
                ID="txtPassword1"
                runat="server"
                Width="180px" 
                Height="15px"
                MaxLength="15"
                TextMode="Password" 
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;        
            <asp:RequiredFieldValidator
                ID="rfvPassword1" 
                runat="server"
                ControlToValidate="txtPassword1"            
                ErrorMessage="Password field is blank! Please type your Password properly." 
                SetFocusOnError="true" 
                Font-Bold="True">?</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span class="gray11px">(5 to 15 characters long.)</span>
            <br />
            <asp:RegularExpressionValidator 
                ID="revPassword1" 
                runat="server"
                ControlToValidate="txtPassword1" 
                ErrorMessage="Your password length is incorrect ! It should be minimum 5 to maximum 15 characters long."
                Font-Size="10px" 
                ValidationExpression="^.{5,15}$" 
                SetFocusOnError="True">
            </asp:RegularExpressionValidator>        
            </td>
            </tr>
        
            <tr>
            <td>Confirm boromela Password:<span class="mandatory">*</span></td>
            <td>
            <asp:TextBox 
                ID="txtPassword2" 
                runat="server" 
                Width="180px" 
                Height="15px" 
                MaxLength="15" 
                TextMode="Password" 
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator
                ID="rfvPassword2" 
                runat="server"
                ControlToValidate="txtPassword2"            
                ErrorMessage="Password confirmation field is blank! Please re-type your Password properly." 
                SetFocusOnError="true" 
                Font-Bold="True">?</asp:RequiredFieldValidator>
            <br />    
            <asp:CompareValidator 
                ID="cmvPassword" 
                runat="server" 
                ControlToCompare="txtPassword1"
                ControlToValidate="txtPassword2"             
                ErrorMessage="Your re-typed password does not match!  Please type the same Password in both fields."
                SetFocusOnError="True" 
                Font-Size="10px">
            </asp:CompareValidator>        
            </td>
            </tr>
            
            <tr>
            <td colspan="2" style="height:37px; color:#365EBF; text-decoration:underline;"><strong>Corporate Details</strong></td>
            </tr>

            <tr>
            <td style="height:9px">Company Name:<span class="mandatory">*</span></td>
            <td style="height:9px">
            <asp:TextBox 
                ID="txtCompany" 
                runat="server"             
                Width="345px" 
                Height="15px" 
                MaxLength="250" 
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator 
                ID="rfvCompany" 
                runat="server"
                ControlToValidate="txtCompany"
                ErrorMessage="Company Name field is blank! Please type your Company Name properly." 
                SetFocusOnError="true" 
                Font-Bold="True">?</asp:RequiredFieldValidator>        
            </td>
            </tr>        

            <tr>
            <td style="height: 25px">Business Type:<span class="mandatory">*</span></td>
            <td style="height: 25px">
            <asp:DropDownList 
                ID="ddlBusinessType" 
                runat="server" 
                Width="258px" 
                AppendDataBoundItems="True">
                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator 
                ID="rfvBusinessType" 
                runat="server" 
                ControlToValidate="ddlBusinessType" 
                InitialValue="-1"
                ErrorMessage="Business Type field is not selected! Please select your Business Type properly."             
                SetFocusOnError="True" 
                Font-Bold="True">?</asp:RequiredFieldValidator>        
            </td>
            </tr>        

            <tr>
            <td valign="top" style="height: 25px">Location:<span class="mandatory">*</span></td>
            <td style="height: 25px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0>
                        <TBODY>
                            <TR>
                            <TD style="WIDTH: 10%; BORDER-BOTTOM: 0px">Country</TD>
                            <TD style="WIDTH: 90%; BORDER-BOTTOM: 0px">
                            <asp:DropDownList id="ddlCountry" runat="server" Width="226px" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                            </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator id="rfvCountry" runat="server" Font-Bold="True" SetFocusOnError="True" ErrorMessage="Country field is not selected ! Please select your Country properly." ControlToValidate="ddlCountry" InitialValue="-1">?</asp:RequiredFieldValidator> </TD></TR><TR><TD style="WIDTH: 10%; BORDER-BOTTOM: 0px">State</TD><TD style="WIDTH: 90%; BORDER-BOTTOM: 0px">
                            <asp:DropDownList id="ddlState" runat="server" Width="226px" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                            </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator id="rfvState" runat="server" Font-Bold="true" SetFocusOnError="true" ErrorMessage="State field is not selected ! Please select your state properly." ControlToValidate="ddlState" InitialValue="-1" Text="?"></asp:RequiredFieldValidator>
                            </TD>
                            </TR>
                            
                            <TR><TD style="WIDTH: 10%; BORDER-BOTTOM: 0px">Province</TD>
                            <TD style="WIDTH: 90%; BORDER-BOTTOM: 0px">
                            <asp:DropDownList id="ddlProvince" runat="server" Width="226px" AppendDataBoundItems="True">
                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator id="rfvProvince" runat="server" Font-Bold="true" SetFocusOnError="true" ErrorMessage="Province field is not selected ! Please select your province properly." ControlToValidate="ddlProvince" InitialValue="-1" Text="?"></asp:RequiredFieldValidator>
                            </TD>
                            </TR>
                        </TBODY>
                    </TABLE>
                </ContentTemplate>
            </asp:UpdatePanel>                  
            </td>
            </tr>        

            <tr>
            <td>Contact/Business Address:<span class="mandatory">*</span></td>
            <td>
            <asp:TextBox 
                ID="txtAddress" 
                runat="server"             
                Width="345px" 
                Height="60px" 
                TextMode="MultiLine" 
                MaxLength="300" 
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator 
                ID="rfvAddress" 
                runat="server" 
                ErrorMessage="Business Address field is blank! Please type your Business Address properly." 
                ControlToValidate="txtAddress" 
                Font-Bold="True">?</asp:RequiredFieldValidator>        
            </td>
            </tr>
            
            <tr>
            <td>Contact Phone:<span class="mandatory">*</span></td>
            <td>
            <asp:TextBox 
                ID="txtPhone" 
                runat="server"             
                Width="180px" 
                Height="15px" 
                MaxLength="50"
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator 
                ID="rfvPhone" 
                runat="server" 
                ControlToValidate="txtPhone"
                ErrorMessage="Phone number field is blank! Please type Phone number properly."
                SetFocusOnError="True" 
                Font-Bold="True">?</asp:RequiredFieldValidator>        
            </td>
            </tr>                        

            <tr>
            <td style="height: 25px">Web Site Address (URL):</td>
            <td style="height: 25px">
            <asp:TextBox 
                ID="txtURL" 
                runat="server"             
                Width="300px" 
                Height="15px" 
                MaxLength="100"
                CssClass="textbox">
            </asp:TextBox>        
            </td>
            </tr>                        
        
            <tr>
            <td>Billing Person:<span class="mandatory">*</span></td>
            <td>
            <asp:TextBox 
                ID="txtBillingContact" 
                runat="server"             
                Width="345px" 
                Height="15px" 
                MaxLength="200" 
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator 
                ID="rfvBillingPerson" 
                runat="server" 
                ControlToValidate="txtBillingContact"
                ErrorMessage="Billing Person field is blank! Please type Billing Person’s name properly." 
                SetFocusOnError="true" 
                Font-Bold="True">?</asp:RequiredFieldValidator>        
            </td>
            </tr>                        

            <tr>
            <td>Inventory Manager:</td>
            <td>
            <asp:TextBox 
                ID="txtInventoryManager" 
                runat="server" 
                Width="345px" 
                Height="15px" 
                MaxLength="200" 
                CssClass="textbox">
            </asp:TextBox>
            </td>
            </tr>                        
        
            <tr>
            <td>Company Profile:</td>
            <td>
            <asp:TextBox 
                ID="txtProfile" 
                runat="server"             
                Width="345px" 
                Height="150px" 
                TextMode="MultiLine" 
                MaxLength="400" 
                CssClass="textbox">
            </asp:TextBox>        
            </td>
            </tr>
        </table>
        <br />
        <span style="font-size:11px; padding-left:80px;">By clicking on "Register" below, you are agreeing to our <a href="#" style="text-decoration:underline;">Terms of Use</a> and <a href="#" style="text-decoration:underline;">Privacy Policy</a>.</span>
        <div style="padding-left:250px;">
        <br /><br />    
        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="image_btn" OnClick="btnRegister_Click" />
        </div>
        <br />
        </td>
        </tr>
    </table>
</asp:Content>

