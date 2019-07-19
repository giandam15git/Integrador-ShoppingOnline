<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shopping.Online._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txtMailWelcome" runat="server"></asp:TextBox>
    <a runat="server" onclick="linkGetClient_Click" href="~/1_Presentation/frmProducts">Empezar a comprar</a>
</asp:Content>
