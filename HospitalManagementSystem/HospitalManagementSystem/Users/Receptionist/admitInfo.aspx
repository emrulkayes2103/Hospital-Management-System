<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="admitInfo.aspx.cs" Inherits="HospitalManagementSystem.Users.Receptionist.admitInfo" %>
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

    </div>
    <div id="detList" class="deptList">
        <form id="form1" runat="server" class="form1">
        <fieldset>
            <legend style="margin-left:20px;font-family:Tahoma;font-size:20px; color:#808080;">Registration Form</legend>
            <table style="font-family:Tahoma;font-size:16px;color:#808080;">
                <tr>
                    <td>Date : </td>
                    <td><asp:TextBox ID="txtDate" runat="server" style="cursor:not-allowed;font-family:Tahoma;font-size:20px;color:#808080;" ReadOnly="true" CssClass="textBoxStyle"></asp:TextBox></td>
                    <td>Form Serial No. : </td>
                    <td><asp:Label ID="fromSerial" runat="server" CssClass="textBoxStyle"></asp:Label></td>
                </tr>
                <tr>
                    <td>Patient Name : </td>
                    <td colspan="4"><asp:TextBox ID="txtPatientName" runat="server" style="height:30px;width:98%;margin:5px;"></asp:TextBox></td>
                </tr>
                <tr>
                   <td>Date of Birth : </td>
                    <td>
                        <asp:TextBox ID="dobYear" runat="server" style="width:94px; height:30px;" placeholder="Year" ></asp:TextBox>
                        <asp:TextBox ID="dobMonth" runat="server" style="width:93px; height:30px;" placeholder="Month" ></asp:TextBox>
                        <asp:TextBox ID="dobDay" runat="server" style="width:92px; height:30px;" placeholder="Day" ></asp:TextBox>
                    </td>
                    <td>
                        Age : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtAge" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Gender : </td>
                    <td>
                        <asp:RadioButtonList ID="gender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                     <td>
                        Blood Group : </td>
                    <td>
                        <asp:DropDownList ID="ddlList" runat="server" style="width:308px; height:30px;margin:5px;">
                            <asp:ListItem Text="A+" Value="A+"></asp:ListItem>
                            <asp:ListItem Text="A-" Value="A-"></asp:ListItem>
                            <asp:ListItem Text="B+" Value="B+"></asp:ListItem>
                            <asp:ListItem Text="B-" Value="B-"></asp:ListItem>
                            <asp:ListItem Text="AB+" Value="AB+"></asp:ListItem>
                            <asp:ListItem Text="AB-" Value="AB-"></asp:ListItem>
                            <asp:ListItem Text="O+" Value="O+"></asp:ListItem>
                            <asp:ListItem Text="O-" Value="O-"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Phone : </td>
                    <td><asp:TextBox ID="txtPhone" runat="server" CssClass="textBoxStyle"></asp:TextBox></td>
                    <td>Emergency Number : </td>
                    <td>
                        <asp:TextBox ID="txtEmergencyNum" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Father's Name</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtFatherNane" runat="server" style="height:30px;width:98%;margin:5px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Mother's Name : </td>
                    <td><asp:TextBox ID="txtMotherName" runat="server" CssClass="textBoxStyle"></asp:TextBox></td>
                    <td>
                        Religion : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtReligion" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Nationality : </td>
                    <td>
                        <asp:TextBox ID="txtNationality" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                    </td>
                    <td>
                        Passport No. : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassportNum" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Occupation : </td>
                    <td colspan="4"><asp:TextBox ID="txtOccupation" runat="server" CssClass="textBoxStyle"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <h3>Address</h3>
                    </td>

                </tr>
                <tr>
                    <td>
                        House No. : 
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtHouseNo" runat="server" style="height:30px;width:98%;margin:5px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Village / Road No.
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtVillageOrRoadno" runat="server" style="height:30px;width:98%;margin:5px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Post Office : </td>
                    <td><asp:TextBox ID="txtPostOffice" runat="server" CssClass="textBoxStyle"></asp:TextBox></td>
                    <td>
                        Post Code : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostCode" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Thana / Upazilla</td>
                    <td colspan="4"><asp:TextBox ID="txtThana" runat="server" style="height:30px;width:98%; margin:5px;"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        District : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtDistrict" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                    </td>
                    <td>
                        Country : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtCountry" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td> Email :</td>
                   <td colspan="4"><asp:TextBox ID="txtEmail" runat="server" style="height:30px;width:98%;margin:5px;"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Button ID="registerBtn" runat="server" style="margin-left:136px;" CssClass="profileBtn" Text="Register" OnClick="registerBtn_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Label ID="errorMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                </table>
        </fieldset>
            </form>
        </div>
</asp:Content>