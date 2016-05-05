<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="addNews.aspx.cs" Inherits="HospitalManagementSystem.Users.Admins.addNews" %>

<%@ MasterType VirtualPath="~/Admin/admins.Master" %>
<asp:Content ID="contentforLeftManu" runat="server" ContentPlaceHolderID="contentForUserInfo">
    <script src="../../Admin/JS/control.js"></script>
    <div id="leftManuber" class="leftManuber">
        <ul>
            <li><a href="admin.aspx">Dashboard</a></li>
            <li><a href="addNews.aspx">Recent News</a>
                <ul>
                    <li><a href="addNews.aspx">Add News</a></li>
 <li><a href="allNews.aspx">All News</a></li>                </ul>
            </li>
            <li><a href="depertment.aspx">Depertment</a></li>
            <li><a href="doctors.aspx">Doctor</a></li>
            <li><a href="patient.aspx">Patient</a></li>
            <li><a href="nurse.aspx">Nurse</a></li>
            <li><a href="laboratorist.aspx">Laboratorist</a></li>
            <li><a href="accountant.aspx">Accountent</a></li>
            <li><a href="receptionist.aspx">Receptionist</a></li> 
            <li><a href="VisitingDaysHours.aspx">Doctor's visiting Days</a></li>

            <li><a href="PaymentHistory.aspx">Payment History</a></li>
           <li><a href="bloodBank.aspx">Blood Bank</a></li>
            <li><a href="bloodDonor.aspx">Blood Donor</a></li>
            <li><a href="#">Birth Report</a></li>
            <li><a href="#">Death Report</a></li>



            <li><a href="profile.aspx">Profile</a></li>

        </ul>
    </div>

</asp:Content>
<asp:Content ID="contentForCenterBody" runat="server" ContentPlaceHolderID="centerbody">
     <div id="depertment" class="depertment">
            <h3>Add Recent News</h3>
         <form id="form1" runat="server">
             <table id="table1" style="height:auto;width:100%; font-family:Tahoma;font-size:20px; color:#808080;">
                 <tr>
                     <td>Title :</td>
                     
                 </tr>
                 <tr>
                     <td><asp:TextBox ID="txtTitleNews" runat="server" style="height:35px; width:95%; margin:10px; font-family:Tahoma;font-size:18px;"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td>News Description : </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" style="height:150px; font-family:Tahoma;font-size:18px; width:95%; margin:10px;"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Button ID="publish" Style="margin-top: 15px; font-family:Tahoma;font-size:18px; height:40px; width:100px; margin:auto; cursor: pointer; background-color: #0f6965; color: #ffffff;" runat="server" Text="Publish" OnClick="publish_Click" />
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Label ID="lblMsg" runat="server"></asp:Label>
                     </td>
                 </tr>
             </table>
         </form>
         </div>

</asp:Content>
  
