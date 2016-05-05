<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CSS/main.Master" CodeBehind="Home.aspx.cs" Inherits="HospitalManagementSystem.Home" %>



<asp:Content ID="contentForLeft" runat="server" ContentPlaceHolderID="leftBer">
    <div id="left" class="left">
        <div id="newHeader" class="newHeder">
            <h3><asp:HyperLink ID="recntNews" class="hyperLink" runat="server" NavigateUrl="~/Services/recentNews.aspx" Text="Recent News"></asp:HyperLink> </h3>
        </div>
        <div id="newsBody" class="newsBody">

            <h2>
                <asp:Repeater ID="repeter" runat="server">
                    <ItemTemplate>
                        <div id="news1" class="news1">
                            <asp:HyperLink ID="txtLink" class="hyperLink"
                                runat="server" NavigateUrl='<%# Eval("NewsTitle","~/Services/recentNews.aspx?title={0}") %>' Text='<%# Eval("NewsTitle") %>'></asp:HyperLink>
                        </div>
                    </ItemTemplate>

                </asp:Repeater>
            </h2>

        </div>
    </div>
</asp:Content>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="centerBodyPlaceHolder">

    <div id="HomeCenter" class="HomeCenter">
        <h2 style="font-family:Tahoma;color:#808080;">Grovier Hospital Limited</h2>

        <p style="font-family:Tahoma;font-size:16px; word-break:normal;word-spacing:normal;">
            Grovier Hospitals Limited, a concern of Square Group is a 320-bed tertiary care hospital. 
           The hospital is an affiliate partner of Methodist Healthcare, Memphis, Tennessee, USA, SingHealth, Singapore, Bangkok Hospital Medical Centre, Thailand and Christian Medical College, Vellore, India.
            A lot of physicians have joined from CMC-Vellore, India. Bangladeshi Physicians with impeccable
            reputation are also part of the medical team. Huge emphasis has been made on quality nursing services, 
           as we have trained over a hundred nurses for over a year. We have nurse educators from Australia, UK, India and the Philippines.
            Nurses and technicians have already received training from CMC-Vellore which continues to be an on- going process.
            <br />
            <br />

        </p>
    </div>

</asp:Content>
