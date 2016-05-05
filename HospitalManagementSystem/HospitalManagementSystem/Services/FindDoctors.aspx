<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CSS/main.Master" CodeBehind="FindDoctors.aspx.cs" Inherits="HospitalManagementSystem.Services.FindDoctors" %>
<%@ MasterType VirtualPath="~/CSS/main.Master" %>

<asp:Content ID="leftManuforEmergency" runat="server" ContentPlaceHolderID="leftBer">
    <div id="leftManuber" class="leftManuber">
        <ul>
            <li><a href="emrgency.aspx">Emergency</a></li>
            <li><a href="FindDoctors.aspx">Find doctor's</a></li>
            <li><a href="billing.aspx">Billing</a></li>
            <li><a href="faq.aspx">FAQ</a></li>
        </ul>
    </div>
   
</asp:Content>
<asp:Content ID="contetFindDoctors" runat="server" ContentPlaceHolderID="centerBodyPlaceHolder">
          <div id="findDoctors" class="findDoctors">
              <h2>
                  Find Doctors
              </h2>
            <table style="font-family:'Adobe Arabic';font-size:30px;">
                <tr>
                    <td>Name :  <asp:TextBox ID="txtFindDoctor" runat="server" style="height:20px; border:1px solid black; width:350px;border-radius:3px; font-size:16px;" placeholder="Enter Your Finding doctor's name"></asp:TextBox></td>
                <td>
                    Designation : <asp:TextBox ID="docDesignation" runat="server" style="height:20px; border:1px solid black; width:350px;border-radius:3px; font-size:16px;" placeholder="Enter Your doctor's designation"></asp:TextBox>
                </td>
                </tr>
                <tr>
                    <td>Department : <asp:DropDownList ID="ddlDeptofDocs" runat="server" style="height:25px;width:350px;border:1px solid black;border-radius:3px;font-size:16px;">
                        
                          </asp:DropDownList>

                    </td>
                    <td>
                        <asp:Button ID="btnfindDoc"  runat="server" Text="Find Doctors" style="height:30px;width:130px;border:1px solid black; border-radius:3px; margin-top:35px; font-family:'Adobe Arabic';font-size:25px;" class="buttonSubmit" OnClick="btnfindDoc_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="err" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
          </div>
    <div id="allDoctors" class="allDoctors">
       <h2><asp:Label ID="errorMsg" runat="server"></asp:Label></h2>
        <asp:GridView ID="GridView1" AllowPaging="true" PageIndex="10" style="table-layout:fixed;font-family:Tahoma;height:auto;width:100%; margin-top:15px; font-weight: 700;" runat="server" BackColor="White" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:HyperLink ID="Label1" runat="server" NavigateUrl='<%# Eval("Name", "~/Services/doctorDetails.aspx?title={0}") %>' Text='<%# Eval("Name") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <ControlStyle BorderStyle="None" CssClass="foundDoctorsCellHeigthWidth" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Depertment">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Depertment") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle BorderStyle="None" CssClass="foundDoctorsCellHeigthWidth" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
</asp:Content>