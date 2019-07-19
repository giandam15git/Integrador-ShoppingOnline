<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmWelcome.aspx.cs" Inherits="Shopping.Online._1_Presentation.frmWelcome" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txtMailWelcome" runat="server"></asp:TextBox>
    <asp:LinkButton ID="linkGoToShop" runat="server" OnClick="linkGoToShop_Click" >Empezar a comprar</asp:LinkButton>
</asp:Content>