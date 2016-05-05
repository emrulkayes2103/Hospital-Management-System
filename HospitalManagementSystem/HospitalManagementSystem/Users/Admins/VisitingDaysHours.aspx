<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="VisitingDaysHours.aspx.cs" Inherits="HospitalManagementSystem.Users.Doctors.VisitingDaysHours" %>

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
        <h3>Visiting Days and hours</h3>
                <input type="button" class="sbmitBtn" style="width:auto;" name="AddDepertment" value="Doctors Visiting Time" onclick="showHide();" />
        <div id="addDept" class="addDept" style="position:relative;display:none; ">
            <table id="table1" class="table1">
                <tr>
                    <td>Doctors Name : </td>
                    <td><asp:DropDownList ID="ddlDoctorsList" style="width:308px; font-family:Tahoma; height:30px;" runat="server"></asp:DropDownList></td>
                </tr>
                 
                <tr>
                    <td>Visiting days : </td>
                    <td>
                        <asp:CheckBoxList ID="chkBoxDays" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" CellSpacing="20">
                            <asp:ListItem Text="Satarday" Value="Satarday, "></asp:ListItem>
                             <asp:ListItem Text="Sunday" Value="Sunday, "></asp:ListItem>
                            
                             <asp:ListItem Text="Monday" Value="Monday, "></asp:ListItem>
                             <asp:ListItem Text="Tuesday" Value="Tuesday, "></asp:ListItem>
                             <asp:ListItem Text="Wednesday" Value="Wednesday, "></asp:ListItem>
                             <asp:ListItem Text="Thrusday" Value="Thrusday, "></asp:ListItem>
                             <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Time : 
                    </td>
                    <td>
                      <span> Start :</span> <asp:DropDownList ID="ddlTimeStart" runat="server"></asp:DropDownList >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <span>End : </span> <asp:DropDownList ID="dddlTimeEnd" runat="server"></asp:DropDownList>
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
        </div>
        <div id="detList" class="deptList">
            <asp:GridView ID="GridView1" AllowPaging="True" PageSize="5" style="table-layout:fixed;font-family:Tahoma;height:auto;width:100%; margin-top:15px;" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"  OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="ID" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Doctor's Name">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlDoctorsList" runat="server" SelectedValue='<%# Eval("Name") %>'>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Day">
                        <EditItemTemplate>
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" SelectedValue='<%# Eval("Day") %>'>
                            </asp:CheckBoxList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Day") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Start Time">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlTimeStart" runat="server" SelectedValue='<%# Eval("StartTime") %>'>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("StartTime") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Time">
                        <EditItemTemplate>
                            <asp:DropDownList ID="dddlTimeEnd" runat="server" SelectedValue='<%# Eval("EndTime") %>'>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("EndTime") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:CommandField  ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" >
                    <ControlStyle BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Height="30px" Width="60px" CssClass="GridviewButton" />
                    </asp:CommandField>
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
