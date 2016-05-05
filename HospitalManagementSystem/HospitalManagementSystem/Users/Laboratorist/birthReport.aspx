<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="birthReport.aspx.cs" Inherits="HospitalManagementSystem.Users.Laboratorist.birthReport" %>
<%@ MasterType VirtualPath="~/Admin/admins.Master" %>

<asp:Content ID="contentforLeftManu" runat="server" ContentPlaceHolderID="contentForUserInfo">

    <div id="leftManuber" class="leftManuber">
        <ul>
           <li><a href="bloodBank.aspx">Blood Bank</a></li>
            <li><a href="bloodDonor.aspx">Blood Donor</a></li>
            <li><a href="birthReport.aspx">Birth Report</a></li>
            <li><a href="dethReport.aspx">Death Report</a></li>
            <li><a href="profile.aspx">Profile</a></li>
            
        </ul>
    </div>

</asp:Content>
<asp:Content ID="contentForCenterBody" runat="server" ContentPlaceHolderID="centerbody">
    <div id="depertment" class="depertment">
        <h3>Birth Report</h3>

    </div>
</asp:Content>

