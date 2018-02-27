<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="UserControl_TopMenu" %>

    <title>www.boromela.com</title>
    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />

  <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <img src="../images/logo.gif" width="260" height="91" alt="" />
                </td>
                <td width="314" valign="top">
                    <table width="314" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td style="width: 5px">
                                <img alt="" src="../images/location_left.gif" width="5" height="35" />
                            </td>
                            <td class="location" align="right" valign="middle">
                            <asp:Label ID="lblLocation" 
                                       runat="server" 
                                       Width="130px" 
                                       ForeColor="Red" 
                                       Text="Change Location :" 
                                       Visible="False">
                             </asp:Label>
                            <asp:DropDownList ID="ddlLocation" 
                                              runat="server" 
                                              Width="157px" 
                                              AutoPostBack="True" >
                                <asp:ListItem Value="18" Text="Bangladesh"></asp:ListItem>
                                <asp:ListItem Value="98" Text="India"></asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            <td width="5">
                                <img alt="" src="../images/location_right.gif" width="5" height="35" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0" class="top_links">
            <tr>
                <td width="5" valign="middle">
                    <img alt="" src="../images/top_link_left.gif" width="5" height="41" /></td>
                <td>
                    <div>
                        <a href="../Default.aspx">Home</a> 
                        <a href="../Corporate/Default.aspx">For Seller</a>
                        <a href="../Classifieds_Buyers.aspx">For Buyers</a> 
                        <a href="../MyBoromelaLogin.aspx">My Boromela</a> 
                        <a href="../Classifieds/Default.aspx">
                                <img alt="" src="../images/free_2.gif" width="37" height="28" border="0" class="free" />Post
                                Classified Ad.</a> <a href="#">Help</a>
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
        
