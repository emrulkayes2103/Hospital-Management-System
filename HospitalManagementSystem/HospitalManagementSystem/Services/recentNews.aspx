<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recentNews.aspx.cs" MasterPageFile="~/CSS/main.Master" Inherits="HospitalManagementSystem.Services.recentNews" %>
<%@ MasterType VirtualPath="~/CSS/main.Master" %>
<asp:Content ID="contentForLeft" runat="server" ContentPlaceHolderID="leftBer">
    <div id="left" class="left">
                <div id="newHeader" class="newHeder">
            <h3><asp:HyperLink ID="recntNews" class="hyperLink" runat="server" NavigateUrl="~/Services/recentNews.aspx" Text="Recent News"></asp:HyperLink> </h3>
                    </div>
                <div id="Div1" class="newsBody">
                   
                       <h2>
                           <asp:Repeater ID="repeter" runat="server">
                               <ItemTemplate>
                                   <div id="news1" class="news1">
                                   <asp:HyperLink ID="txtLink"  class="hyperLink" runat="server" NavigateUrl='<%# Eval("NewsTitle","~/Services/recentNews.aspx?title={0}") %>' Text='<%# Eval("NewsTitle") %>'></asp:HyperLink>
                                 </div>
                                         </ItemTemplate>

                           </asp:Repeater>
                               </h2>
                   
                </div>
            </div>
</asp:Content>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="centerBodyPlaceHolder">
   <div id="HomeCenter" class="HomeCenter">
       <div id="title" class="title">
           <h2>
               <asp:HyperLink ID="txtTitle" class="linkStyle" runat="server"></asp:HyperLink>
           </h2>
       </div>
       <div id="newsBody" class="newsBody">
           <p>
               <asp:Label ID="txtBody" runat="server"></asp:Label>
           </p>
       </div>
   </div>
    </asp:Content>