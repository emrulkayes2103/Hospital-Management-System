<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/admins.Master" CodeBehind="nurse.aspx.cs" Inherits="HospitalManagementSystem.Users.Admins.nurse" %>
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
        <h3>Nurse</h3>
        <input type="button" class="sbmitBtn" name="AddDepertment" value="Add Nurse" onclick="showHide();" />
        <div id="addDept" class="addDept" style="position:relative;display:none; ">
            
            <table id="table1" class="table1">
                <tr>
                    <td>Name : </td>
                    <td>
            <asp:TextBox ID="txtNurseName" runat="server" style="width:300px; height:30px;" ></asp:TextBox>
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
                        <asp:TextBox ID="address" TextMode="MultiLine" runat="server" style="width:300px; height:30px;" ></asp:TextBox>
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
            <asp:GridView ID="GridView1" AllowPaging="True" PageSize="5" style="table-layout:fixed;font-family:Tahoma;height:auto;width:100%; margin-top:15px;" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnPageIndexChanging="GridView1_PageIndexChanging">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                   <asp:TemplateField HeaderText="ID" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" style="height:34px;width:95%; margin:2px 4px; font-family:Tahoma;font-size:20px;" runat="server" Text='<%# Eval("Name") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        
                        <ControlStyle CssClass="gridViewcolumn" />
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="txtEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" style="height:34px;width:95%; margin:2px 4px; font-family:Tahoma;font-size:20px;" runat="server" Text='<%# Eval("Email") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAdd" style="height:34px;width:95%; margin:2px 4px; font-family:Tahoma;font-size:20px;" TextMode="MultiLine" runat="server" Text='<%# Eval("Address") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>

                            <asp:Label ID="txtAdd" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPhone" style="height:34px;width:95%; margin:2px 4px; font-family:Tahoma;font-size:20px;" runat="server" Text='<%# Eval("Phone") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="txtPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="gridViewcolumn" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sex">

                       <EditItemTemplate>
                            <asp:TextBox ID="Sex" style="height:34px;width:95%; margin:2px 4px; font-family:Tahoma;font-size:20px;" runat="server" Text='<%# Eval("Sex") %>' ></asp:TextBox>
                        </EditItemTemplate>

                        <ItemTemplate>
                            <asp:Label ID="sex" runat="server" Text='<%# Eval("Sex") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" >
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