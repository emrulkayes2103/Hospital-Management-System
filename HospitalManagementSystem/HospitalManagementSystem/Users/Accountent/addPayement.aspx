<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="addPayement.aspx.cs" Inherits="HospitalManagementSystem.Users.Accountent.addPayement" %>
<%@ MasterType VirtualPath="~/Admin/admins.Master" %>
<asp:Content ID="contentforLeftManu" runat="server" ContentPlaceHolderID="contentForUserInfo">

    <div id="leftManuber" class="leftManuber">
        <ul>
            <li><a href="dashboard.aspx">Dashboard</a></li>
            <li><a href="addPayement.aspx">Add Payment</a></li>
            <li><a href="paymentHistory.aspx">Payment History</a></li>
            <li><a href="profile.aspx">Profile</a></li>
        </ul>
    </div>

</asp:Content>
<asp:Content ID="contentForCenterBody" runat="server" ContentPlaceHolderID="centerbody">
    <div id="depertment" class="depertment">
        <h3>Add Payment</h3>

    </div>
    <div id="detList" class="deptList">
        <form id="form1" runat="server">
            <table id="table1" style="height:auto;width:90%;margin:10%; font-family:Tahoma;font-size:22px;">
                <tr>
                    <td>
                        Date :
                    </td>
                    <td>
                        <asp:Label ID="lblDate" runat="server" style="height:30px;width:80%; font-family:Tahoma;font-size:17px;"></asp:Label>
                    </td>
                </tr>
               <tr>
                   <td>Serial No. :</td>
                   <td><asp:TextBox ID="txtSerial" runat="server" style="height:30px;width:80%; font-family:Tahoma;font-size:17px;"></asp:TextBox></td>
               </tr>
                <tr>
                  <td>
                      Payable Ammount:
                  </td>
                    <td>
                        <asp:TextBox ID="txtPaybleAmmount" runat="server" style="height:30px;width:80%; font-family:Tahoma;font-size:17px;"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                   <td>
                       Paid Ammount :
                   </td>
                   <td>
                       <asp:TextBox ID="txtPaidammount" runat="server" style="height:30px;width:80%; font-family:Tahoma;font-size:17px;"></asp:TextBox>
                   </td>
               </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" Text="Add Payment" runat="server" style="margin-left:135px; margin-top:15px; height:30px; cursor:pointer; background-color:#0f6965; color:#ffffff;" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                 <tr>
                    <td colspan="2"><asp:Label ID="errorMsg" runat="server"></asp:Label></td>
                </tr>
                </table>
            
        </form>
        </div>
</asp:Content>
