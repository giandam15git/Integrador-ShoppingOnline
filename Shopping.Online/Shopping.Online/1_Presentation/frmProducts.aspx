﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmProducts.aspx.cs" Inherits="Shopping.Online._1_Presentation.frmProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
            <div class="col-md-10">
                <asp:Repeater ID="rpProducts" runat="server" OnItemDataBound="rpProducts_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-md-4 largo">
                            <h3><%#Eval("ProductName") %></h3>
                            <div class="container2">
                            </div>
                            <div class="product-desc">
                                <p><%#Eval("ProductDescription") %></p>
                                <strong class="price">$<%#Eval("ProductPrice") %></strong>
                                <div class="col-md-12">
                                    <div class="form-group" runat="server" id="divProductSize">
                                        <asp:Label runat="server" CssClass="col-md-2 control-label">Talle</asp:Label>
                                        <div class="col-md-12">
                                            <asp:DropDownList ID="ddlProductSizeGeneric" runat="server" AutoPostBack="true" CssClass="form-control" ></asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlProductSizeGeneric" validationgroup="insertGroup" InitialValue="-Talle-" CssClass="text-danger" ErrorMessage="Por favor, seleccione un talle" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtProductQuantity" CssClass="form-control quantity" TextMode="Number"></asp:TextBox>
                                    </div>
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
