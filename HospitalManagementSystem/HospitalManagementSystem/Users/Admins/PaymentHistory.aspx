﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="PaymentHistory.aspx.cs" Inherits="HospitalManagementSystem.Users.Admins.PaymentHistory" %>

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
    <form id="form1" runat="server">
    <div id="depertment" class="depertment">
        <h3>Payment History</h3>
      
    </div>
    <div id="detList" class="deptList">
    
        <asp:GridView ID="GridView1" AllowPaging="true" PageIndex="15" runat="server" style="table-layout:fixed;font-family:Tahoma;height:auto;width:100%;" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="GridView1_PageIndexChanging">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderText="Serial No.">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("seialNo") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle CssClass="gridViewcolumn" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Patient Name">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle CssClass="gridViewcolumn" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Patient Father's Name">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("FathersName") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle CssClass="gridViewcolumn" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Payable Ammount">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("PayableAmmount") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle CssClass="gridViewcolumn" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Paid Ammount">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("PaidAmmount") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle CssClass="gridViewcolumn" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total due">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("due") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle CssClass="gridViewcolumn" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle CssClass="gridViewcolumn" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        </div>
    </form>
</asp:Content>

