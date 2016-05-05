<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="accountant.aspx.cs" Inherits="HospitalManagementSystem.Users.Admins.accountant" %>

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
    <form id="addDeptForm" runat="server">
        <div id="depertment" class="depertment">
            <h3>Accountant</h3>
            <input type="button" class="sbmitBtn" name="AddDepertment" value="Add Accountant" onclick="showHide();" />
            <div id="addDept" class="addDept" style="position: relative; display: none;">

                <table id="table1" class="table1">
                    <tr>
                        <td>Name : </td>
                        <td>
                            <asp:TextBox ID="txtAccountantName" runat="server" Style="width: 300px; height: 30px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Email : 
                        </td>
                        <td>
                            <asp:TextBox ID="email" runat="server" Style="width: 300px; height: 30px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    <td>
                        Password : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtPass" TextMode="Password" runat="server" style="width:300px; height:30px;" ></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Re-Type Password : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtRepass" TextMode="Password" runat="server" style="width:300px; height:30px;" ></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                        <td>Address : 
                        </td>
                        <td>
                            <asp:TextBox ID="address" TextMode="MultiLine" runat="server" Style="width: 300px; height: 30px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Phone :
                        </td>
                        <td>
                            <asp:TextBox ID="phn" runat="server" Style="width: 300px; height: 30px;"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Sex : 
                        </td>
                        <td>
                            <asp:RadioButtonList ID="radioBtn" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="submit" runat="server" Text="Submit" Style="margin-left: 135px; margin-top: 15px; height: 30px; cursor: pointer; background-color: #0f6965; color: #ffffff;" OnClick="submit_Click" /></td>
                    </tr>
                     <tr>
                    <td colspan="2">
                        <asp:Label ID="errorMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                </table>

            </div>
            <div id="detList" class="deptList">
                
                <asp:GridView ID="GridView1" AllowPaging="True" PageSize="5" style="table-layout:fixed;font-family:Tahoma;height:auto;width:100%; margin-top:15px;" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Email" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                                <asp:TextBox ID="txtDocName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtDocName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle CssClass="gridViewcolumn" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle CssClass="gridViewcolumn" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtAdd" TextMode="MultiLine" runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtAdd" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle CssClass="gridViewcolumn" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
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
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True">
                        <ControlStyle BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Height="30px" Width="60px" CssClass="GridviewButton" />
                        </asp:CommandField>
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
        </div>
    </form>
</asp:Content>
