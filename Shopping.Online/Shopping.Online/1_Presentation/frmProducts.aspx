<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmProducts.aspx.cs" Inherits="Shopping.Online._1_Presentation.frmProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-12">
            <asp:Repeater ID="rpProducts" runat="server" OnItemDataBound="rpProducts_ItemDataBound">
                <ItemTemplate>
                    <div class="col-md-4" style="background-color: lightblue;border-radius: 35px;margin-right: 4px; margin-top: 4px;">
                        <h3><%#Eval("ProductName") %></h3>
                        <div class="container2">
                            <div class="div-img">
                                <a href="#"><img class="img" src='data:image/jpg;base64,<%#Eval("ProductImage")%>'></a>
                            </div>
                        </div>
                        <div class="col-md-12 productDescription">
                            <p><%#Eval("ProductDescription") %></p>
                            <strong class="price" >$<%#Eval("ProductPrice") %></strong>
                        </div>
                            <div class="col-md-6">
                                <asp:Label runat="server" CssClass="control-label">Talle</asp:Label>
                                <asp:DropDownList ID="ddlProductSizeGeneric" runat="server" AutoPostBack="true" CssClass="form-control" ></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlProductSizeGeneric" validationgroup="insertGroup" InitialValue="-Talle-" CssClass="text-danger" ErrorMessage="Por favor, seleccione un talle" />
                                <asp:Label runat="server" style="float: left;">Cantidad</asp:Label>
                                <asp:TextBox runat="server" ID="txtProductQuantity" CssClass="form-control quantity" Text="0" TextMode="Number"></asp:TextBox>
                                <br />
                                <asp:Button runat="server" ID="btnComprar" CssClass="btn btn-default" Text="Comprar" CommandName="Buy" CommandArgument='<%#Eval("ProductId") + "," + Eval("ProductPrice") %>' onclick="btnBuy_Click" />
                            </div>
                            <asp:Label runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        <asp:Label runat="server" ID="lblMensaje"></asp:Label>
        </div>
    </div>
</asp:Content>
