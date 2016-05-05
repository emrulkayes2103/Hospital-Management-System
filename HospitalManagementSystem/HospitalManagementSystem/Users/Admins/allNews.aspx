<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allNews.aspx.cs" MasterPageFile="~/Admin/admins.Master" Inherits="HospitalManagementSystem.Users.Admins.allNews" %>

<%@ MasterType VirtualPath="~/Admin/admins.Master" %>

<asp:Content ID="contentforLeftManu" runat="server" ContentPlaceHolderID="contentForUserInfo">
   
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
                             <li><a href="profile.aspx">Profile</a></li>    
                        </ul>
                    </div>
    
</asp:Content>
<asp:Content ID="contentForCenterBody" runat="server" ContentPlaceHolderID="centerbody">
    <form id="form1" runat="server">
    <div id="depertment" class="depertment">
        <h3>All News</h3>
        </div>
     <div id="detList" class="deptList">
         <asp:GridView ID="GridView1" AllowPaging="True" PageSize="5" style="table-layout:fixed;font-family:Tahoma;height:auto;width:100%; margin-top:15px;" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDeleting="GridView1_RowDeleting">
             <AlternatingRowStyle BackColor="#CCCCCC" />
             <Columns>
                 <asp:TemplateField HeaderText="ID" Visible="False">
                     <ItemTemplate>
                         <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                     </ItemTemplate>
                     <ControlStyle CssClass="DescripttionColumnInGridview" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Title">
                     <EditItemTemplate>
                         <asp:TextBox ID="txtNewsTitle" runat="server" Text='<%# Eval("NewsTitle") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("NewsTitle") %>'></asp:Label>
                     </ItemTemplate>
                     <ControlStyle CssClass="DescripttionColumnInGridview" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Description" Visible="false">
                  
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Eval("NewsDetails") %>'></asp:Label>
                     </ItemTemplate>
                     <ControlStyle CssClass="DescripttionColumnInGridview" />
                  
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
             <SortedAscendingHeaderStyle BackColor="#808080" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#383838" />
         </asp:GridView>
         </div>
    </form>
</asp:Content>