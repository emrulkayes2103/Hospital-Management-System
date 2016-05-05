<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="admin.aspx.cs" Inherits="HospitalManagementSystem.Users.Admin.admin" %>
<%@ MasterType VirtualPath="~/Admin/admins.Master" %>
<asp:Content ID="contentforLeftManu" runat="server" ContentPlaceHolderID="contentForUserInfo">
   
    <div id="leftManuber" class="leftManuber">
                        <ul>
                            <li><a href="admin.aspx">Dashboard</a></li>
                            <li><a href="addNews.aspx">Recent News</a>
                <ul>
                    <li><a href="addNews.aspx">Add News</a></li>
                     <li><a href="allNews.aspx">All News</a></li>
                </ul>
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
    <div id="dashBoard" class="dashboard">
        <h3>Dashboard</h3>
    </div>
    <div id="detList" class="deptList">
        <form id="dashBoardForm" class="dashBoardForm" runat="server">
        <asp:Button ID="adminPatient" runat="server" class="adminDashBlock" Text="Depertment" OnClick="adminPatient_Click" />
            <asp:Button ID="bloodDonor" runat="server" class="adminDashBlock" Text="Doctor" OnClick="bloodDonor_Click" />
            <asp:Button ID="profile" runat="server" class="adminDashBlock" Text="Patient" OnClick="profile_Click" />
            <asp:Button ID="Button1" runat="server" class="adminDashBlock" Text="Nurse" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" class="adminDashBlock" Text="Laboratorist" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" class="adminDashBlock" Text="Accountent" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" class="adminDashBlock" Text="Receptionist" OnClick="Button4_Click" />
            <asp:Button ID="Button11" runat="server" class="adminDashBlock" Text="Profile" OnClick="Button11_Click" />
            </form>
        </div>
</asp:Content>