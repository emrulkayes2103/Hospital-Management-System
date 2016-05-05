<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CSS/main.Master" CodeBehind="doctorDetails.aspx.cs" Inherits="HospitalManagementSystem.Services.doctorDetails" %>

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
<asp:Content ID="contetFindDoctors" runat="server" ContentPlaceHolderID="centerBodyPlaceHolder">

    <div id="findDoctors" class="findDoctors">
        <fieldset class="fieldset">
            <legend style="font-family:Tahoma;font-size:24px; color:#00ff90; margin-left:350px;">Doctors Details</legend>
        
        <table id="tableDetails" class="tableDetails">
            <tr>
                <td style="width: 255px">
                    
                    <asp:HyperLink ID="lblName" runat="server" class="hyperLink"></asp:HyperLink>
                        
                        </td>
            </tr>
            <tr>
                <td style="width: 255px">
                    Visiting Days :
                </td>
                <td>
                    <asp:Label ID="visitingDays" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 255px">Visiting Time :</td>
                <td>
                    <asp:Label ID="lblStartTime" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEndTime" runat="server"></asp:Label>
                </td>
            </tr>
            
        </table>
            </fieldset>
    </div>
    </asp:Content>