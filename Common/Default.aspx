<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Common_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>www.boromela.com</title>

    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ChangeUserType()
        {
            var strValue = "";
            var userType = document.getElementsByName("rblUserType");

            for (var j = 0; j < userType.length; j++)
            {
                if (userType[j].checked)
                {
                   strValue = userType[j].value;
                   break;
                }
            }
            
            if (strValue == "")
            {
                document.getElementById("registrationPageLink").href = "../Corporate/UserProfile_Step01.aspx";            
                document.getElementById("forgotPassword").href = "../Corporate/UserProfile_LoginInfo.aspx";
            }
            
            if(strValue == "Classified")
            {
                document.getElementById("registrationPageLink").href = "../Classifieds/UserProfile_Step01.aspx";
                document.getElementById("forgotPassword").href = "../Classifieds/UserProfile_LoginInfo.aspx";                
            }
            
            if(strValue == "Business")
            {
                document.getElementById("registrationPageLink").href = "../Corporate/UserProfile_Step01.aspx";
                document.getElementById("forgotPassword").href = "../Corporate/UserProfile_LoginInfo.aspx";                
            }            
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
<!--BEGIN: PAGE HEADER-->
<table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
    <td>
    <img src="../images/logo.gif" width="260" height="91" alt="" />
    </td>
    
    <td width="314" valign="top" align="right" style="padding-right:7px;">
    <table border="0" cellspacing="0" cellpadding="0">
        <tr>
        <td width="5">
        <img alt="" src="../images/location_left.gif" width="5" height="35" /></td>
        <td class="location1" align="center" valign="middle">            
        <asp:Label ID="lblLocation" runat="server" Width="130px" ForeColor="Red" Text="Location" Visible="False"></asp:Label>
        </td>
        <td style="width: 5px">
        <img alt="" src="../images/location_right.gif" width="5" height="35" /></td>
        </tr>
      </table>
    </td>
    </tr>
</table>
<!--END: PAGE HEADER-->
<!--BEGIN: TOP MENU-->
<table width="1000" border="0" align="center" cellpadding="0" cellspacing="0" class="top_links">
    <tr>
    <td width="5">
    <img alt="" src="../images/top_link_left.gif" width="5" height="41" /></td>
    <td>
    
    <div>
    <a href="../Default.aspx">Home</a>
    <a href="../Corporate/Default.aspx">For Seller</a>
    <a href="../Classifieds_Buyers.aspx">For Buyers</a>
    <a href="../MyBoromelaLogin.aspx">My Boromela</a>    
    <a href="../Classifieds/Default.aspx"><img alt="" src="../images/free_2.gif" width="37" height="28" border="0" class="free" />Post Classified Ad.</a>
    <a href="#">Help</a>    
    </div>
    </td>
    
    <td width="235">
    <!--input name="site_search" type="text" id="site_search" value="Search" class="top_search" /-->
    <!--input type="image" src="images/search_right.gif" width="25" height="23" style="vertical-align: middle;" /-->
    </td>
    
    <td width="5">
    <img alt="" src="../images/top_link_right.gif" width="5" height="41" /></td>
    </tr>
</table>
<!--END: TOP MENU-->
    <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
        <td height="50" class="pageTitle">Welcome to boromela.com</td>
        <td valign="top">
        <br />
        &nbsp;
        <strong style="color:Red;">I want to login as</strong>
        <br />        
        <asp:RadioButtonList ID="rblUserType" runat="server" Width="90%" RepeatDirection="Horizontal">
           <asp:ListItem Value="Business" Selected="True" Text="Business User."></asp:ListItem>
           <asp:ListItem Value="Classified" Text="Classified User"></asp:ListItem>
        </asp:RadioButtonList>        
        <br />
        </td>
        </tr>

        <tr>
        <td height="310" valign="top" style="padding-right:20px;">
        <div class="t" style="width:100%px">
           <div class="b">
              <div class="l">
                 <div class="r">
                    <div class="bl">
                       <div class="br">
                          <div class="tl">
                             <div class="tr" style="height:260px; padding:20px;">
                                 <strong>New in boromela.com ? Register here</strong> ...<br />
                                 <p>Register as a boromela.com Business/Classified User and enjoy privileges including:</p>
                                 <ul style="margin-left:10px;padding-left:10px; line-height:2">
                                 <li>Post advertisement in our business section.</li><li>Edit your advertisement.</li><li>Manage advertisement feedbacks using just your email.</li></ul>                         
                                 <br />
                                                              
                                 <a id="registrationPageLink" href="../Corporate/UserProfile_Step01.aspx">
                                 <img src="../images/btn_register.gif" alt="Register" width="141" height="30" border="0" />
                                 </a>
                                 <br />
                             </div>
                          </div>
                       </div>
                    </div>
                 </div>
              </div>
           </div>
        </div>
        </td>

        <td width="355" valign="top">
        <div class="set2_t" style="width:100%">
           <div class="set2_b">
              <div class="set2_l">
                 <div class="set2_r">
                    <div class="set2_bl">
                       <div class="set2_br">
                          <div class="set2_tl">
                             <div class="set2_tr" style=" padding:15px;">
                             <strong>Sign in to your My Boromela Control Panel.</strong>
                             <br /><br /><br /><br />
                             <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                <td colspan="2">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="300px" ShowMessageBox="True" HeaderText="Following error occurred:" Font-Size="11px"/>
                                </td>
                                </tr>
                             
                                <tr>
                                <td height="30">Login Email</td>
                                <td>
                                <asp:TextBox 
                                    ID="txtLoginEmail" 
                                    runat="server" 
                                    Width="150px" 
                                    MaxLength="100" 
                                    CssClass="textbox">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator 
                                    ID="rfvLoginEmail" 
                                    runat="server" 
                                    ErrorMessage="Login Email field is blank! Please type your Login Email." 
                                    ControlToValidate="txtLoginEmail" 
                                    SetFocusOnError="True" 
                                    Font-Bold="True">?</asp:RequiredFieldValidator>                            
                                <asp:RegularExpressionValidator 
                                    ID="revLoginEmail" 
                                    runat="server" 
                                    ErrorMessage="Invalid Email address! Please type your valid Login Email address." 
                                    ControlToValidate="txtLoginEmail" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    Font-Bold="True">?</asp:RegularExpressionValidator>
                                <br />
                                </td>
                                </tr>
                                
                                <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                </tr>
                                
                                <tr>
                                <td height="30">Password</td>
                                <td>
                                <asp:TextBox 
                                    ID="txtPassword" 
                                    runat="server" 
                                    Width="150px" 
                                    MaxLength="15" 
                                    TextMode="Password" 
                                    CssClass="textbox">
                                </asp:TextBox>                            
                                <asp:RequiredFieldValidator 
                                    ID="rfvPassword" 
                                    runat="server" 
                                    ErrorMessage="Password field is blank ! " 
                                    Font-Bold="True" 
                                    SetFocusOnError="True" ControlToValidate="txtPassword">?</asp:RequiredFieldValidator>
                                </td>
                                </tr>
                               
                                <tr>
                                <td style="height: 14px">&nbsp;</td>
                                <td style="height: 14px">
                                <a id="forgotPassword" href="../Corporate/UserProfile_LoginInfo.aspx">I forgot my password.</a>
                                </td>
                                </tr>

                                <tr>                           
                                <td colspan="2" style="height: 14px; padding-top:3px;">
                                <asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" EnableViewState="False" Width="300px" Font-Size="11px"></asp:Label>                            
                                </td>
                                </tr>                            
                             </table>
                             <br />
                             <div align="right">
                             <input type="image" src="../images/btn_login.gif" alt="Login" width="96" height="29" id="Image1" />
                             </div>
                             </div>
                          </div>
                       </div>
                    </div>
                 </div>
              </div>
           </div>
        </div>
        <br />
        </td>
        </tr>
    </table>

<table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
    <td height="56">
    <br />
    <div class="t" style="width: 100%">
    <div class="b">
    <div class="l">
    <div class="r">
    <div class="bl">
    <div class="br">
    <div class="tl">
    <div class="tr" style="height: 54px;">
    <div class="copyright">Copyright (c) boromela.com All rights reserved.</div>
    <div class="bottom_link">
    <a href="default.aspx">Home</a> | <a href="Corporate/Default.aspx">For Seller</a> | <a href="Classifieds_Buyers.aspx">For Buyers</a> |
    <a href="#"><u>My Boromela</u></a> | <a href="#">Help</a> | <a href="AboutUs.aspx">About us</a>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </td>
    </tr>
 </table>

</form>
</body>
</html>