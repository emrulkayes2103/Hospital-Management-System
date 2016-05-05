<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CSS/main.Master" CodeBehind="emrgency.aspx.cs" Inherits="HospitalManagementSystem.Services.emrgency" %>
<%@ MasterType VirtualPath="~/CSS/main.Master" %>

<asp:Content ID="leftManuforEmergency" runat="server" ContentPlaceHolderID="leftBer">
    <div id="leftManuber" class="leftManuber">
        <ul>
            <li><a href="emrgency.aspx">Emergency</a></li>
            <li><a href="FindDoctors.aspx">Find doctor's</a></li>
            <li><a href="billing.aspx">Billing</a></li>
            <li><a href="faq.aspx">FAQ</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="contentForServive" runat="server" ContentPlaceHolderID="centerBodyPlaceHolder">
    <div id="mainBodyServices" class="mainBodyServices">
    <h2 style="text-align:center">
        Services
    </h2>
    <p style="padding-left:30px; font-size:30px;">
        Our all services is for every 24 Hours.
 </p>
        <ul style="list-style-type:disc">
            <li>Emergency Numbers : +8801687840808 , +8804587511</li>
            <li>Email : admin@admin.com</li>
        </ul>
   
    </div>
</asp:Content>