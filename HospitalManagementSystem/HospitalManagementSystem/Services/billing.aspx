<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CSS/main.Master" CodeBehind="billing.aspx.cs" Inherits="HospitalManagementSystem.Services.billing" %>
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
<asp:Content ID="billPay" runat="server" ContentPlaceHolderID="centerBodyPlaceHolder">
    <div id="BillPay" class="BillPay">
        <h2>About Bills</h2>
        
            <ul style="list-style:disc">
                <li>Aircondition Room : 5000$ Per Night</li>
                <li>Aircondition Bed (Shared Room) : 3000$ Per NIght</li>
                <li>Non-Aircondition Room : 2500$ Per Night</li>
                <li>Non-Aircondition Bed (Shared Room) 1500$ Per Night</li>
                <li>Ambulance (24-Hours) 4000$ In California </li>
            </ul>
        
    </div>
</asp:Content>