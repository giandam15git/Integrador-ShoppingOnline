<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSale.aspx.cs" Inherits="Shopping.Online._1_Presentation.frmSale" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-3 fixed" runat="server" id="divConfirmSale">
            <asp:Label runat="server" ID="lblTotalAmount"></asp:Label>
            <div class="col-md-12">
                <asp:Label runat="server" CssClass="control-label">Nombre Completo</asp:Label>
                <asp:TextBox runat="server" ID="txtClientFullName" CssClass="col-md-10 form-control" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientFullName" ValidationGroup="ingresoGrupo" CssClass="col-md-2 text-danger" ErrorMessage=" *" />

                <asp:Label runat="server" CssClass="control-label">Email</asp:Label>
                <asp:TextBox runat="server" ID="txtClientEmail" CssClass="col-md-10 form-control" TextMode="Email" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientEmail" ValidationGroup="ingresoGrupo" CssClass="col-md-2 text-danger" ErrorMessage=" *" />

                <asp:Label runat="server" CssClass="control-label">CI</asp:Label>
                <asp:TextBox runat="server" ID="txtClientCI" CssClass="col-md-10 form-control" TextMode="Number" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientCI" ValidationGroup="ingresoGrupo" CssClass="col-md-2 text-danger" ErrorMessage=" *" />

                <asp:Label runat="server" CssClass="control-label">Teléfono</asp:Label>
                <asp:TextBox ID="txtClientPhoneNumber" CssClass="col-md-10 form-control" TextMode="Number" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientPhoneNumber" ValidationGroup="ingresoGrupo" CssClass="col-md-2 text-danger" ErrorMessage=" *" />

                <asp:Label runat="server" CssClass="control-label">Departamento</asp:Label>
                <asp:TextBox ID="txtClientDepartament" CssClass="col-md-10 form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientDepartament" ValidationGroup="ingresoGrupo" CssClass="col-md-2 text-danger" ErrorMessage=" *" />

                <asp:Label runat="server" CssClass="control-label">Ciudad</asp:Label>
                <asp:TextBox ID="txtClientCity" CssClass="col-md-10 form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientCity" ValidationGroup="ingresoGrupo" CssClass="col-md-2 text-danger" ErrorMessage=" *" />

                <asp:Label runat="server" CssClass="control-label">Dirección de Factura</asp:Label>
                <asp:TextBox ID="txtClientAddressBill" CssClass="col-md-10 form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientAddressBill" ValidationGroup="ingresoGrupo" CssClass="col-md-2 text-danger" ErrorMessage=" *" />
                <hr />
                <asp:Label runat="server" CssClass="control-label">¿Desea que le enviemos la compra?</asp:Label>
                <label class="radio-inline"><asp:RadioButton ID="rdbClientToHomeY" runat="server" GroupName="TypeShoes" Text="Si, por favor" AutoPostBack="true" OnCheckedChanged="rdbClientToHome_CheckedChanged" Checked="True" /></label>
                <label class="radio-inline"><asp:RadioButton ID="rdbClientToHomeN" runat="server"  GroupName="TypeShoes" Text="No, yo pasaré a buscarla" AutoPostBack="true" OnCheckedChanged="rdbClientToHome_CheckedChanged" /></label>

                <asp:Label runat="server" CssClass="col-md-2 control-label">Seleccione tipo de Pago</asp:Label>
                <div class="col-md-12">
                    <asp:DropDownList ID="ddlSelectTypePayment" runat="server" AutoPostBack="true" CssClass="form-control" ></asp:DropDownList>
                </div>

                <asp:Label runat="server" CssClass="col-md-2 control-label">Seleccione medio de Pago</asp:Label>
                <div class="col-md-12">
                    <asp:DropDownList ID="ddlSelectPayment" runat="server" AutoPostBack="true" CssClass="form-control" ></asp:DropDownList>
                </div>

                <asp:Label runat="server" ID="lblTypePayment" CssClass="control-label">Ingrese número de pago</asp:Label>
                <asp:TextBox ID="txtNumberFromPayment" CssClass="col-md-10 form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumberFromPayment" ValidationGroup="ingresoGrupo" CssClass="col-md-2 text-danger" ErrorMessage=" *" />

                <asp:Button ID="btnPay" runat="server" CssClass="col-md-12 btn btn-default" Text="Confirmar Compra" />
            </div>
            <asp:Label runat="server" ID="lblMensaje"></asp:Label>
        </div>
        <div class="col-md-6">
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
                                <strong class="price">$<%#Eval("ProductPrice") %></strong><div class="col-md-6">
                                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-default" Text="Borrar" CommandArgument='<%#Eval("ProductId")%>' onclick="btnDelete_Click"/>
                                </div>
                                <asp:Label runat="server" CssClass="text-danger"></asp:Label>
                            </div>
                        </div>
                    </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
