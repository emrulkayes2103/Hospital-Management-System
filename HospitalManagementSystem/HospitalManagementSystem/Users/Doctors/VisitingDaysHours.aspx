<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="VisitingDaysHours.aspx.cs" Inherits="HospitalManagementSystem.Users.Doctors.VisitingDaysHours1" %>
<%@ MasterType VirtualPath="~/Admin/admins.Master" %>

<asp:Content ID="contentforLeftManu" runat="server" ContentPlaceHolderID="contentForUserInfo">
    <script src="../../Admin/JS/control.js"></script>
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
        <h3>Doctors Visiting Days & Hours</h3>
            </div>
        <div id="detList" class="deptList">
            <asp:GridView ID="GridView1" AllowPaging="True" PageSize="5" style="table-layout:fixed;font-family:Tahoma;height:auto;width:100%; margin-top:15px;" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" >
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="ID" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Doctor's Name">
                        
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Day">
                       
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Day") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Start Time">
                      
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("StartTime") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Time">
                        
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("EndTime") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
  </div>
        
        </form>
</asp:Content>
