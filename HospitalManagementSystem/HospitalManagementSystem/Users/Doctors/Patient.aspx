<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="Patient.aspx.cs" Inherits="HospitalManagementSystem.Users.Doctors.Patient" %>

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
        <h3>Patient</h3>
        <input type="button" class="sbmitBtn" name="AddDepertment" value="Add Patient" onclick="showHide();" />
        <div id="addDept" class="addDept" style="position:relative;display:none; ">
            
            <table id="table1" class="table1">
                <tr>
                    <td>Name : </td>
                    <td>
            <asp:TextBox ID="txtPatientName" runat="server" style="width:300px; height:30px;" ></asp:TextBox>
                        </td>
                    </tr>
                <tr>
                    <td>
                        Email : 
                    </td>
                    <td>
                        <asp:TextBox ID="email" runat="server" style="width:300px; height:30px;" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address : 
                    </td>
                    <td>
                        <asp:TextBox ID="address" runat="server" style="width:300px; height:30px;" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Phone :
                    </td>
                    <td>
                        <asp:TextBox ID="phn" runat="server" style="width:300px; height:30px;" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Age : </td>
                    <td>
                        <asp:TextBox ID="age" runat="server" style="width:300px; height:30px;" ></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>Date of Birth : </td>
                    <td>
                        <asp:TextBox ID="dobYear" runat="server" style="width:94px; height:30px;" placeholder="Year" ></asp:TextBox>
                        <asp:TextBox ID="dobMonth" runat="server" style="width:93px; height:30px;" placeholder="Month" ></asp:TextBox>
                        <asp:TextBox ID="dobDay" runat="server" style="width:92px; height:30px;" placeholder="Day" ></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Blood Group : </td>
                    <td>
                        <asp:DropDownList ID="ddlList" runat="server" style="width:308px; height:30px;">
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
                    <td>
                        Sex : 
                    </td>
                    <td>
                        <asp:RadioButtonList ID="radioBtn" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="submit" runat="server" Text="Submit" style="margin-left:135px; margin-top:15px; height:30px; cursor:pointer; background-color:#0f6965; color:#ffffff;" OnClick="submit_Click" /></td>
                </tr>
                <tr>
                <td colspan="2">
                        <asp:Label ID="errorMsg" runat="server"></asp:Label>
                    </td>
                    </tr>
                </table>
                
        </div>
        <div id="detList" class="deptList">
             <asp:GridView ID="GridView1" AllowPaging="True" PageSize="5" style="table-layout:fixed;font-family:Tahoma;height:auto;width:100%; margin-top:15px;" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
                 <AlternatingRowStyle BackColor="#CCCCCC" />
                 <Columns>
                     <asp:TemplateField HeaderText="ID" Visible="False">
                         <ItemTemplate>
                             <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                         </ItemTemplate>
                         <ControlStyle CssClass="gridViewcolumn" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Name">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtName" style="height:30px;width:90%; margin:4px;" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                         </ItemTemplate>
                         <ControlStyle CssClass="gridViewcolumn" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Email">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtEmail" style="height:30px;width:90%; margin:4px;" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="txtEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                         </ItemTemplate>
                         <ControlStyle CssClass="gridViewcolumn" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Address">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtAdd" style="height:30px;width:90%; margin:4px;" runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="txtAdd" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                         </ItemTemplate>
                         <ControlStyle CssClass="gridViewcolumn" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Phone">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtPhn" style="height:30px;width:90%; margin:4px;" runat="server" Text='<%# Eval("Phone") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="txtPhn" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                         </ItemTemplate>
                         <ControlStyle CssClass="gridViewcolumn" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Age">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtAge" style="height:30px;width:90%; margin:4px;" runat="server" Text='<%# Eval("Age") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="txtAge" runat="server" Text='<%# Eval("Age") %>'></asp:Label>
                         </ItemTemplate>
                         <ControlStyle CssClass="gridViewcolumn" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Date of Birth">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtDob" style="height:30px;width:90%; margin:4px;" placeholder="Year-Month-Day" runat="server" Text='<%# Eval("DOB") %>'></asp:TextBox>
                            
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="txtDob"  runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                         </ItemTemplate>
                         <ControlStyle CssClass="gridViewcolumn" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Blood Group">
                         <EditItemTemplate>
                             <asp:DropDownList ID="DropDownList1" style="height:30px;width:20px; margin:4px; font-family:Tahoma;font-size:18px;" runat="server" SelectedValue='<%# Eval("bloodGroup") %>'>
                                 <asp:ListItem Text="A+" Value="A+"></asp:ListItem>
                            <asp:ListItem Text="A-" Value="A-"></asp:ListItem>
                            <asp:ListItem Text="B+" Value="B+"></asp:ListItem>
                            <asp:ListItem Text="B-" Value="B-"></asp:ListItem>
                            <asp:ListItem Text="AB+" Value="AB+"></asp:ListItem>
                            <asp:ListItem Text="AB-" Value="AB-"></asp:ListItem>
                            <asp:ListItem Text="O+" Value="O+"></asp:ListItem>
                            <asp:ListItem Text="O-" Value="O-"></asp:ListItem>
                             </asp:DropDownList>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="DropDownList1" runat="server" Text='<%# Eval("bloodGroup") %>'></asp:Label>
                         </ItemTemplate>
                         <ControlStyle CssClass="gridViewcolumn" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Sex">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtSex" runat="server" Text='<%# Eval("Sex") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="txtSex" runat="server" Text='<%# Eval("Sex") %>'></asp:Label>
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
        
    </div>
        </form>
</asp:Content>
