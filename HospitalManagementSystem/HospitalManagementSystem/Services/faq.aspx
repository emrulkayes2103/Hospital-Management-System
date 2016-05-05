<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CSS/main.Master" CodeBehind="faq.aspx.cs" Inherits="HospitalManagementSystem.Services.faq" %>
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
<asp:Content ID="faqContent" runat="server" ContentPlaceHolderID="centerBodyPlaceHolder">
    <div id="faq" class="faq">
        <h3>
            Frequently Asked Question's
        </h3>
    </div>
</asp:Content>