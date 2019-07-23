<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmWelcome.aspx.cs" Inherits="Shopping.Online._1_Presentation.frmWelcome" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-12" >
            <div class="col-md-5" ></div>
            <div class="col-md-2 divMailWelcome" >
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailWelcome" ValidationGroup="insertClient" CssClass="text-danger" ErrorMessage="Por favor ingrese un email válido" />
                <asp:TextBox ID="txtEmailWelcome" TextMode="Email" CssClass="txtMailWelcome" runat="server"></asp:TextBox>
                <asp:LinkButton ID="linkGoToShop" runat="server" ValidationGroup="insertClient" OnClick="linkGoToShop_Click" >Empezar a comprar</asp:LinkButton>
            </div>
            <div class="col-md-5" ></div>
        </div>
    </div>
</asp:Content>