<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="dashBoard.aspx.cs" Inherits="HospitalManagementSystem.Users.Receptionist.dashBoard" %>
<%@ MasterType VirtualPath="~/Admin/admins.Master" %>
<asp:Content ID="contentforLeftManu" runat="server" ContentPlaceHolderID="contentForUserInfo">

    <div id="leftManuber" class="leftManuber">
        <ul>
            <li><a href="dashBoard.aspx">Dashboard</a></li>
            <li><a href="admitInfo.aspx">Admit Patient</a></li>
            <li><a href="getToken.aspx">Token</a></li>
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
        <asp:Button ID="adminPatient" runat="server" class="adminPatient" Text="Admit Patient" OnClick="adminPatient_Click" />
            <asp:Button ID="profile" runat="server" class="profile" Text="Profile" OnClick="profile_Click" />
            </form>
        </div>
</asp:Content>
