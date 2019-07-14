<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSale.aspx.cs" Inherits="Shopping.Online._1_Presentation.frmSale" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-2 fixed">
            <asp:Label runat="server" ID="lblTotalAmount"></asp:Label>
            <div class="col-md-12">
                <asp:Button ID="btnPay" runat="server" CssClass="col-md-12 btn btn-default" Text="Confirmar Compra" />
            </div>
        </div>
        <div class="col-md-10">
            <asp:Repeater ID="rpProductsSale" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 largo">
                            <h3><%#Eval("ProductName") %></h3>
                            <div class="container2">
                                <div class="div-img">
                                   <a href="#"><img class="img" src='data:image/jpg;base64,<%#Eval("ProductImage")%>'></a>
                                </div>
                            </div>
                            <div class="product-desc">
                                <p><%#Eval("ProductDescription") %></p>
                                <strong class="price">$<%#Eval("ProductPrice") %></strong>
                                <div class="col-md-6">
                                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-default" Text="Borrar" CommandArgument='<%#Eval("LineId")%>' onclick="btnDelete_Click"/>
                                </div>
                                <asp:Label runat="server" CssClass="text-danger"></asp:Label>
                            </div>
                        </div>
                    </ItemTemplate>
            </asp:Repeater>
                <asp:Label runat="server" ID="lblMensaje"></asp:Label>
            </div>
    </div>
</asp:Content>
