<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="getToken.aspx.cs" Inherits="HospitalManagementSystem.Users.Receptionist.getToken" %>

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
    <form id="form1" runat="server">
    <div id="depertment" class="depertment">
        <table id="table1" style="height:auto;width:90%;margin:30px;font-family:Tahoma;font-size:25px;">
            <tr>
                <td style="width: 300px">Find Token / Serial No.</td>
                <td>
                    <asp:TextBox ID="txtSerial" placeholder="Enter Patient Name to Find Serial No." runat="server" style="height:30px;width:100%; font-family:Tahoma;font-size:18px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="submitBtn" runat="server" Text="Find" style="font-family:Tahoma;font-size:20px;" class="sbmitBtn" OnClick="submitBtn_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="errorMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
     <div id="detList" class="deptList">
         <asp:GridView ID="GridView2" runat="server" style="table-layout:fixed;font-family:Tahoma;height:auto;width:100%;" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
             <AlternatingRowStyle BackColor="#CCCCCC" />
             <Columns>
                 <asp:TemplateField HeaderText="Serial No.">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("serialNo") %>'></asp:Label>
                     </ItemTemplate>
                     <ControlStyle CssClass="gridViewcolumn" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Patient Name">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("PatientName") %>'></asp:Label>
                     </ItemTemplate>
                     <ControlStyle CssClass="gridViewcolumn" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Patient Father's Name">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Eval("fathersName") %>'></asp:Label>
                     </ItemTemplate>
                     <ControlStyle CssClass="gridViewcolumn" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Phone">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Eval("phone") %>'></asp:Label>
                     </ItemTemplate>
                     <ControlStyle CssClass="gridViewcolumn" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Payment Clearence">
                     <ItemTemplate>
                         <asp:Label ID="Label5" runat="server" Text='<%# Eval("Paid") %>'></asp:Label>
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
         <asp:GridView ID="GridView1" runat="server" style="table-layout:fixed;font-family:Tahoma;height:auto;width:100%;" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
             <AlternatingRowStyle BackColor="#CCCCCC" />
             <Columns>
                 <asp:TemplateField HeaderText="Serial No.">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("serialNo") %>'></asp:Label>
                     </ItemTemplate>
                     <ControlStyle CssClass="gridViewcolumn" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Patient Name">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("PatientName") %>'></asp:Label>
                     </ItemTemplate>
                     <ControlStyle CssClass="gridViewcolumn" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Patient Father's Name">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Eval("fathersName") %>'></asp:Label>
                     </ItemTemplate>
                     <ControlStyle CssClass="gridViewcolumn" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Phone">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Eval("phone") %>'></asp:Label>
                     </ItemTemplate>
                     <ControlStyle CssClass="gridViewcolumn" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Payment Clearence">
                     <ItemTemplate>
                         <asp:Label ID="Label5" runat="server" Text='<%# Eval("Paid") %>'></asp:Label>
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