<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSale.aspx.cs" Inherits="Shopping.Online._1_Presentation.frmSale" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div  runat="server" class="col-md-12" id="divNotProductsInKart" visible="false">
            <h1>Lo sentimos, todavía no has agregado productos a tu carrito. :(</h1>
        </div>
        <div  runat="server" class="col-md-12" id="divHasError" visible="false">
            <h1>Hubo un error al efectuar el pago, por favor, reintente. :)</h1>
        </div>
        <div  runat="server" class="col-md-12" id="divSuccess" visible="false">
            <h1>El pago se ha efectuado correctamente. ♥</h1>
        </div>
        <div class="col-md-6">
            <asp:Repeater ID="rpProductsSale" runat="server" OnItemDataBound="rpProductsSale_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-md-8 divProductsRight" >
                            <h3><%#Eval("ProductName") %></h3>
                            <div class="containerKart">
                                <div class="div-img">
                                   <a href="#"><img class="img" src='data:image/jpg;base64,<%#Eval("ProductImage")%>'></a>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <p><%#Eval("ProductDescription") %></p>
                                <strong class="price">$<%#Eval("ProductPrice") %></strong>
                                <asp:Label runat="server" ID="lblProductQuantity"></asp:Label>
                            </div>
                            <div class="col-md-12">
                                <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-default" Text="Borrar" CommandArgument='<%#Eval("ProductId")%>' onclick="btnDelete_Click"/>
                            </div>
                            <asp:Label runat="server" CssClass="text-danger"></asp:Label>
                        </div>
                    </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-6" runat="server" id="divConfirmSale">
            <div class="col-md-10 divFormLeft">
                <asp:Label runat="server" CssClass="control-label">Nombre Completo</asp:Label>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientFullName" ValidationGroup="insertClient" CssClass="text-danger" ErrorMessage=" *" />
                <asp:TextBox runat="server" ID="txtClientFullName" CssClass="form-control" ></asp:TextBox>

                <asp:Label runat="server" CssClass="control-label">Email</asp:Label>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientEmail" ValidationGroup="insertClient" CssClass="text-danger" ErrorMessage=" *" />
                <asp:TextBox runat="server" ID="txtClientEmail" CssClass="form-control" TextMode="Email" ></asp:TextBox>

                <asp:Label runat="server" CssClass="control-label">CI</asp:Label>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientCI" ValidationGroup="insertClient" CssClass="text-danger" ErrorMessage=" *" />
                <asp:TextBox runat="server" ID="txtClientCI" CssClass="form-control" TextMode="Number" ></asp:TextBox>

                <asp:Label runat="server" CssClass="control-label">Teléfono</asp:Label>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientPhoneNumber" ValidationGroup="insertClient" CssClass="text-danger" ErrorMessage=" *" />
                <asp:TextBox ID="txtClientPhoneNumber" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>

                <asp:Label runat="server" CssClass="control-label">Departamento</asp:Label>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientDepartament" ValidationGroup="insertClient" CssClass="text-danger" ErrorMessage=" *" />
                <asp:TextBox ID="txtClientDepartament" CssClass="form-control" runat="server"></asp:TextBox>

                <asp:Label runat="server" CssClass="control-label">Ciudad</asp:Label>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientCity" ValidationGroup="insertClient" CssClass="text-danger" ErrorMessage=" *" />
                <asp:TextBox ID="txtClientCity" CssClass="form-control" runat="server"></asp:TextBox>

                <asp:Label runat="server" CssClass="control-label">Dirección de Factura</asp:Label>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientAddressBill" ValidationGroup="insertClient" CssClass="text-danger" ErrorMessage=" *" />
                <asp:TextBox ID="txtClientAddressBill" CssClass="form-control" runat="server"></asp:TextBox>
                <hr />
                <div class="col-md-8">
                    <asp:Label runat="server" CssClass="control-label">¿Desea que le enviemos la compra?</asp:Label>
                </div>
                <div class="col-md-10">
                    <label class="radio-inline"><asp:RadioButton ID="rdbClientToHomeY" runat="server" GroupName="TypeShoes" Text="Si, por favor" AutoPostBack="true" OnCheckedChanged="rdbClientToHome_CheckedChanged" Checked="True" /></label>
                    <label class="radio-inline"><asp:RadioButton ID="rdbClientToHomeN" runat="server"  GroupName="TypeShoes" Text="No, yo pasaré a buscarla" AutoPostBack="true" OnCheckedChanged="rdbClientToHome_CheckedChanged" /></label>
                </div>
                <div class="col-md-8">
                    <asp:Label runat="server" CssClass="control-label">Seleccione tipo de Pago</asp:Label>
                    <asp:DropDownList ID="ddlSelectTypePayment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSelectTypePayment_SelectedIndexChanged" CssClass="form-control" ></asp:DropDownList>
                    <asp:Label runat="server" CssClass="control-label">Seleccione medio de Pago</asp:Label>
                    <asp:DropDownList ID="ddlSelectPayment" runat="server" CssClass="form-control" ></asp:DropDownList>
                    <asp:Label runat="server" CssClass="control-label">Ingrese número de pago</asp:Label>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumberFromPayment" ValidationGroup="insertClient" CssClass="text-danger" ErrorMessage=" *" />
                    <asp:TextBox ID="txtNumberFromPayment" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Button ID="btnPay" runat="server" ValidationGroup="insertClient" CssClass="btn btn-default" Text="Confirmar Compra" OnClick="btnPay_Click" />
                </div>
                <div class="col-md-8">
                    <asp:Label runat="server" ID="lblTotalAmount"></asp:Label>
                </div>
            </div>
            <asp:Label runat="server" ID="lblMensaje"></asp:Label>
        </div>
    </div>
</asp:Content>
