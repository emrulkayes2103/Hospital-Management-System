﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="profile.aspx.cs" Inherits="HospitalManagementSystem.Users.Admins.profile" %>

<%@ MasterType VirtualPath="~/Admin/admins.Master" %>
<asp:Content ID="contentforLeftManu" runat="server" ContentPlaceHolderID="contentForUserInfo">
    <script src="../../Admin/JS/control.js"></script>
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
     <form id="editProfileForm" class="editProfileForm" runat="server">
    <div id="depertment" class="depertment">
        <h3>Profile</h3>
        <table id="proBtnTable" class="proBtnTable">
            <tr>
                <td>
        <input type="button" class="profileBtn" name="AddDepertment" value="Change Profile Info ?" onclick="showHideEditProfileUpdate();" />
        </td>
                <td>
                    <input type="button" class="profileBtn" name="AddDepertment" value="Change password ?" onclick="showHideEditProfilepass();" />
        </td>
                    </tr>
                </table>
            <div id="addDept" class="addDept" style="position:relative; ">
                <div id="UpdatePasswordblock" class="updatePass" style="position:relative;display:none;">
            <fieldset id="Fieldset1" class="ProfileField">
                <legend style="margin-left:10%; color:#808080; font-family:Tahoma;font-size:25px;">Update Password</legend>
                        <table id="tblForm" class="tblForm">
                            <tr>
                                <td>
                                    <asp:TextBox TextMode="Password" style="height:34px;width:300px; margin:2px 4px; font-family:Tahoma;font-size:16px;" ID="txtPrePass" runat="server" placeholder="Enter your old Password"></asp:TextBox>
                                </td>
                           
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox TextMode="Password" style="height:34px;width:300px; margin:2px 4px; font-family:Tahoma;font-size:16px;" ID="txtNewPass" runat="server" placeholder="Enter your new password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox TextMode="Password" style="height:34px;width:300px; margin:2px 4px; font-family:Tahoma;font-size:16px;" ID="txtReTypeNewPass" runat="server" placeholder="Re-Enter your new password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button class="profileSubmitBtn" ID="updatePass" runat="server" Text="Save password" OnClick="updatePass_Click"  />
                                </td>
                            </tr>
                            <tr>
                    <td colspan="2"><asp:Label ID="errorMsg" runat="server"></asp:Label></td>
                </tr>
             
                        </table>
                </fieldset>
                    </div>
                <div id="updateProBlock" class="updateProBlock" style="position:relative;display:none;">
                     <fieldset id="ProfileField" class="ProfileField" >
                <legend style="margin-left:10%;color:#808080; font-family:Tahoma;font-size:25px;">Update Profile</legend>
               
                    <table id="tblForm2" class="tblForm">
                        <tr>
                            <td><asp:TextBox style="height:34px;width:300px; margin:2px 4px; font-family:Tahoma;font-size:16px;" ID="txtName" runat="server" placeholder="Enter your name"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox style="height:34px;width:300px; margin:2px 4px; cursor:not-allowed; font-family:Tahoma;font-size:16px;" ID="txtEmail" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox style="height:34px;width:300px; margin:2px 4px; font-family:Tahoma;font-size:16px;" TextMode="MultiLine" ID="txtAddress" runat="server" placeholder="Enter your Address"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox style="height:34px;width:300px; margin:2px 4px; font-family:Tahoma;font-size:16px;" ID="txtPhone" runat="server" placeholder="Enter your Phone number"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            <asp:Button class="profileSubmitBtn" ID="btnSubmit" runat="server" Text="Update Profile" OnClick="btnSubmit_Click" />
                                </td>
                        </tr>
                        <tr>
                    <td colspan="2"><asp:Label ID="errorMsgPro" runat="server"></asp:Label></td>
                </tr>
             
                    </table>
               
            </fieldset>
                </div>
            </div>
    </div>
        </form>  
</asp:Content>
