<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmGenericABM.aspx.cs" Inherits="Shopping.Online._1_Presentation.frmGenericABM" %>
<asp:Content ID="ContentProductId" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" id="divTitleProduct">
        <h1>Gestión de productos</h1>
    </div>
    <div runat="server" id="divTitleFamily">
        <h1>Gestión de Familias</h1>
    </div>
    <div runat="server" id="divTitleDepartament">
        <h1>Gestión de Departamentos</h1>
    </div>
    <div class="form-group" runat="server" id="divGenericId">  
        <div class="form-group" >
            <br />
            <br />
            <asp:Label runat="server" CssClass="col-md-2 control-label">Número de Identificación</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtGenericId" TextMode="Number" CssClass="form-control"/>
            </div>
        </div>
    </div>
    <!--- Se crea un producto --->
    <div class="form-group" runat="server" id="divProductCode">  
        <div class="form-group" >
            <br />
            <br />
            <asp:Label runat="server" CssClass="col-md-2 control-label">Código</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtProductCode" TextMode="Number" CssClass="form-control"/>
                <asp:requiredfieldvalidator controltovalidate="txtProductCode" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, ingrese el código del producto" runat="Server"></asp:requiredfieldvalidator>
            </div>
        </div>
    </div>
    <div class="form-group" runat="server" id="divGenericName">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Nombre</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtGenericName" CssClass="form-control"/>
            <asp:requiredfieldvalidator controltovalidate="txtGenericName" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, ingrese el nombre del producto" runat="Server"></asp:requiredfieldvalidator>
        </div>
    </div>
    <div class="form-group" runat="server" id="divProductDescription">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Descripción</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtProductDescription" CssClass="form-control"/>
            <asp:requiredfieldvalidator controltovalidate="txtProductDescription" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, ingrese una descripción del producto" runat="Server"></asp:requiredfieldvalidator>
        </div>
    </div>
    <div class="form-group" runat="server" id="divProductGenre">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Género</asp:Label>
        <div class="col-md-10">
            <asp:DropDownList ID="ddlProductGenre" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlProductGenre_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlProductGenre" validationgroup="insertGroup" InitialValue="-Genero-" CssClass="text-danger" ErrorMessage="Por favor, seleccione un género" />
        </div>
    </div>
    <div class="form-group" runat="server" id="divProductColor">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Color</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtProductColor" TextMode="Color" CssClass="form-control"/>
            <asp:requiredfieldvalidator controltovalidate="txtProductColor" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, seleccione un color" runat="Server"></asp:requiredfieldvalidator>
        </div>
    </div>
    <div class="form-group" runat="server" id="divGenericShoes">
        <asp:Label runat="server" CssClass="col-md-2 control-label">¿Es un tipo de calzado?</asp:Label>
        <div class="col-md-10">
            <label class="radio-inline"><asp:RadioButton ID="rdbTypeShoesY" runat="server" GroupName="TypeShoes" Text="Si" AutoPostBack="true" OnCheckedChanged="rdbTypeShoes_CheckedChanged" /></label>
            <label class="radio-inline"><asp:RadioButton ID="rdbTypeShoesN" runat="server" Checked="True" GroupName="TypeShoes" Text="No" AutoPostBack="true" OnCheckedChanged="rdbTypeShoes_CheckedChanged"  /></label>
        </div>
    </div>
    <!--- Se selecciona un departamento --->
    
    <div class="form-group" runat="server" id="divGenericSelectedDepartament">
        <h4>Seleccione un Departamento</h4>
        <asp:Label runat="server" CssClass="col-md-2 control-label">Departamento</asp:Label>
        <div class="col-md-10">
            <asp:DropDownList ID="ddlGenericDepartament" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlGenericDepartament_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlGenericDepartament" validationgroup="insertGroup" InitialValue="-Departamento-" CssClass="text-danger" ErrorMessage="Por favor, seleccione un Departamento." />
        </div>
    </div>
    <hr />
     <!--- Se selecciona un familia para departamento seleccionado --->
    
    <div class="form-group" runat="server" id="divGenericSelectedFamiliy">
        <h4>Seleccione una Familia</h4>
        <asp:Label runat="server" CssClass="col-md-2 control-label">Familia</asp:Label>
        <div class="col-md-10">
            <asp:DropDownList ID="ddlProductDepartamentFamily" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlProductDepartamentFamily_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlProductDepartamentFamily" validationgroup="insertGroup" InitialValue="-Familia-" CssClass="text-danger" ErrorMessage="Por favor, seleccione un familia." />
        </div>
    </div>
    <div class="form-group" runat="server" id="divProductSize">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Talle</asp:Label>
        <div class="col-md-10">
            <asp:DropDownList ID="ddlProductSize" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlProductSize_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlProductSize" validationgroup="insertGroup" InitialValue="-Talle-" CssClass="text-danger" ErrorMessage="Por favor, seleccione un talle" />
        </div>
    </div>
    <div class="form-group" runat="server" id="divProductSizeStock">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Stock</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" AutoPostBack="true" ID="txtProductSizeStock" TextMode="Number" CssClass="form-control" ToolTip="Ingrese un stock para cada talle." OnTextChanged="txtProductSizeStock_TextChanged"/>
            <asp:requiredfieldvalidator controltovalidate="txtProductSizeStock" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, ingrese stock" runat="Server"></asp:requiredfieldvalidator>
        </div>
    </div>
    <div class="form-group" runat="server" id="divProductImage">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Imagen</asp:Label>
        <div class="col-md-10">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:RequiredFieldValidator runat="server" CssClass="text-danger" validationgroup="insertGroup" ControlToValidate="FileUpload1" ErrorMessage="Por favor, ingrese una imagen"></asp:RequiredFieldValidator>
        </div>
        <br />
    </div>
    <hr />
    <div class="form-group"  runat="server" id="divProductPrice">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Precio en UYU</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtProductPrice" TextMode="Number" CssClass="form-control" ToolTip="Ingrese un stock para cada talle."/>
            <asp:requiredfieldvalidator controltovalidate="txtProductPrice" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, ingrese el precio" runat="Server"></asp:requiredfieldvalidator>
        </div>
    </div>
    <hr />
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button ID="btnGenericInsert" validationgroup="insertGroup" runat="server" CssClass="btn btn-default" OnClick="btnGenericInsert_Click" />
            <asp:Button ID="btnGenericUpdate" validationgroup="insertGroup" runat="server" CssClass="btn btn-default" OnClick="btnGenericUpdate_Click" />
            <asp:Button ID="btnGenericDelete" validationgroup="insertGroup" runat="server" CssClass="btn btn-default" OnClick="btnGenericDelete_Click" />
            <br />
        </div>
     </div>
    <br />
    <div class="form-group"  runat="server" id="divLabelMessage">
        <asp:Label runat="server" ID="lblMessageProduct" CssClass="col-md-2 control-label"></asp:Label>
    </div>

</asp:Content>
