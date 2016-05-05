<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="bloodBank.aspx.cs" Inherits="HospitalManagementSystem.Users.Doctors.bloodBank" %>

<%@ MasterType VirtualPath="~/Admin/admins.Master" %>

<asp:Content ID="contentforLeftManu" runat="server" ContentPlaceHolderID="contentForUserInfo">

    <div id="leftManuber" class="leftManuber">
        <ul>
            <li><a href="dashboard.aspx">Dashboard</a></li>
            <li><a href="Patient.aspx">Patient</a></li>
            <li><a href="VisitingDaysHours.aspx">Visiting Days & hours</a></li>
            <li><a href="bloodBank.aspx">Blood Bank</a></li>
            <li><a href="bloodDonor.aspx">Blood Donor</a></li>
            <li><a href="profile.aspx">Profile</a></li>
        </ul>
    </div>

</asp:Content>
<asp:Content ID="contentForCenterBody" runat="server" ContentPlaceHolderID="centerbody">
    <form id="addDeptForm" runat="server">
    <div id="depertment" class="depertment">
        <h3>Blood Bank History</h3>
        </div>
        <div id="detList" class="deptList">
            <asp:GridView ID="GridView1" style="table-layout:fixed;font-family:Tahoma;height:auto;width:100%; margin-top:15px;" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                 <AlternatingRowStyle BackColor="#CCCCCC" />
                 <Columns>
                     <asp:TemplateField HeaderText="ID" Visible="False">
                         <ItemTemplate>
                             <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Blood Group">
                         <ItemTemplate>
                             <asp:Label ID="lblBgroup" style="text-align:center;" runat="server" Text='<%# Eval("BloodGroup") %>'></asp:Label>
                         </ItemTemplate>
                         <ControlStyle CssClass="gridViewcolumn" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Quantity (Bags)">
                        
                         <ItemTemplate>
                             <asp:Label ID="txtQuantity" style="text-align:center;" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
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
