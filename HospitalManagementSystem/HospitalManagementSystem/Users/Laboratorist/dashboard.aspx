<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="dashboard.aspx.cs" Inherits="HospitalManagementSystem.Users.Laboratorist.dashboard" %>

<%@ MasterType VirtualPath="~/Admin/admins.Master" %>

<asp:Content ID="contentforLeftManu" runat="server" ContentPlaceHolderID="contentForUserInfo">

    <div id="leftManuber" class="leftManuber">
        <ul>
            <li><a href="dashboard.aspx">Dashboard</a></li>
            <li><a href="bloodBank.aspx">Blood Bank</a></li>
            <li><a href="bloodDonor.aspx">Blood Donor</a></li>
            <li><a href="profile.aspx">Profile</a></li>
            
        </ul>
    </div>

</asp:Content>
<asp:Content ID="contentForCenterBody" runat="server" ContentPlaceHolderID="centerbody">
   
    <div id="depertment" class="depertment">
        <h3>Dashboard</h3>
</div>
     <div id="detList" class="deptList">
        <form id="dashBoardForm" class="dashBoardForm" runat="server">
        <asp:Button ID="adminPatient" runat="server" class="adminPatient" Text="Blood Bank" OnClick="adminPatient_Click" />
            <asp:Button ID="bloodDonor" runat="server" class="bloodDonor" Text="Blood Donor" OnClick="bloodDonor_Click" />
            <asp:Button ID="profile" runat="server" class="profile" Text="Profile" OnClick="profile_Click" />
            </form>
        </div>
</asp:Content>
