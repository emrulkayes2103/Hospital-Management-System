<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="dashboard.aspx.cs" Inherits="HospitalManagementSystem.Users.Accountent.dashboard" %>
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
        <h3>Dashboard</h3>
    </div>
    <div id="detList" class="deptList">
        <form id="dashBoardForm" class="dashBoardForm" runat="server">
        <asp:Button ID="adminPatient" runat="server" class="adminPatient" Text="Add Payment" OnClick="adminPatient_Click"  />
            <asp:Button ID="bloodDonor" runat="server" class="bloodDonor" Text="Payment History" OnClick="bloodDonor_Click"  />
            <asp:Button ID="profile" runat="server" class="profile" Text="Profile" OnClick="profile_Click"  />
            </form>
        </div>
</asp:Content>

