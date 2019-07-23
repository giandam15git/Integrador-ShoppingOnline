<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmGenericABM.aspx.cs" Inherits="Shopping.Online._1_Presentation.frmGenericABM" %>
<asp:Content ID="ContentProductId" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
		<div class="col-md-6">
			<div runat="server" id="divTitleProduct">
				<h1>Gestión de productos</h1>
			</div>
			<div runat="server" id="divTitleFamily">
				<h1>Gestión de Familias</h1>
			</div>
			<div runat="server" id="divTitleDepartament">
				<h1>Gestión de Departamentos</h1>
			</div>

			<div runat="server" id="divGenericId">  
				<asp:Label runat="server" CssClass="control-label">Número de Identificación</asp:Label>
                <asp:requiredfieldvalidator controltovalidate="txtGenericId" CssClass="text-danger" validationgroup="deleteGroup" errormessage="Por favor, seleccione un producto" runat="Server"/>
				<asp:TextBox runat="server" ReadOnly="true" ID="txtGenericId" TextMode="Number" CssClass="form-control"/>
			</div>
			<!--- Se crea un producto --->
			<div runat="server" id="divProductCode"> 
				<asp:Label runat="server" CssClass="control-label">Código</asp:Label>
				<asp:requiredfieldvalidator controltovalidate="txtProductCode" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, ingrese el código del producto" runat="Server"/>
				<asp:TextBox runat="server" ID="txtProductCode" MaxLength="10" CssClass="form-control"/>
			</div>
			<div  runat="server" id="divGenericName">
				<asp:Label runat="server" CssClass="control-label">Nombre</asp:Label>
				<asp:TextBox runat="server" ID="txtGenericName" MaxLength="20" CssClass="form-control"/>
				<asp:requiredfieldvalidator controltovalidate="txtGenericName" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, ingrese el nombre." runat="Server"/>
			</div>
			<div  runat="server" id="divProductDescription">
				<asp:Label runat="server" CssClass="control-label">Descripción</asp:Label>

				<asp:TextBox runat="server" ID="txtProductDescription" MaxLength="60" CssClass="form-control"/>
				<asp:requiredfieldvalidator controltovalidate="txtProductDescription" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, ingrese una descripción del producto" runat="Server"/>

			</div>
			<div  runat="server" id="divProductGenre">
				<asp:Label runat="server" CssClass="control-label">Género</asp:Label>
				<asp:DropDownList ID="ddlProductGenre" runat="server" AutoPostBack="false" CssClass="form-control" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="ddlProductGenre" validationgroup="insertGroup" InitialValue="-Genero-" CssClass="text-danger" ErrorMessage="Por favor, seleccione un género" />
			</div>
			<div  runat="server" id="divProductColor">
				<asp:Label runat="server" CssClass="control-label">Color</asp:Label>

				<asp:TextBox runat="server" ID="txtProductColor" TextMode="Color" CssClass="form-control"/>
				<asp:requiredfieldvalidator controltovalidate="txtProductColor" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, seleccione un color" runat="Server"/>

			</div>
			<div  runat="server" id="divGenericShoes">
				<asp:Label runat="server" CssClass="control-label">¿Es un tipo de calzado?</asp:Label>

				<label class="radio-inline">
					<asp:RadioButton ID="rdbTypeShoesY" runat="server" GroupName="TypeShoes" Text="Si" AutoPostBack="true" OnCheckedChanged="rdbTypeShoes_CheckedChanged" />
				</label>
				<label class="radio-inline">
					<asp:RadioButton ID="rdbTypeShoesN" runat="server" Checked="True" GroupName="TypeShoes" Text="No" AutoPostBack="true" OnCheckedChanged="rdbTypeShoes_CheckedChanged"  />
				</label>

			</div>
			<!--- Se selecciona un departamento --->

			<div  runat="server" id="divGenericSelectedDepartament">
				<h4>Seleccione un Departamento</h4>
				<asp:Label runat="server" CssClass="control-label">Departamento</asp:Label>
				<asp:DropDownList ID="ddlGenericDepartament" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlGenericDepartament_SelectedIndexChanged"/>
				<asp:RequiredFieldValidator runat="server" ControlToValidate="ddlGenericDepartament" validationgroup="insertGroup" InitialValue="-Departamento-" CssClass="text-danger" ErrorMessage="Por favor, seleccione un Departamento." />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlGenericDepartament" validationgroup="insertGroup" InitialValue="" CssClass="text-danger" ErrorMessage="Por favor, seleccione o ingrese un departamento." />
			<hr />
            </div>
			
			<!--- Se selecciona un familia para departamento seleccionado --->

			<div  runat="server" id="divGenericSelectedFamiliy">
				<h4>Seleccione una Familia</h4>
				<asp:Label runat="server" CssClass="control-label">Familia</asp:Label>

				<asp:DropDownList ID="ddlProductDepartamentFamily" runat="server" AutoPostBack="false" CssClass="form-control" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="ddlProductDepartamentFamily" validationgroup="insertGroup" InitialValue="-Familia-" CssClass="text-danger" ErrorMessage="Por favor, seleccione un familia." />

			</div>
			<div  runat="server" id="divProductSize">
				<asp:Label runat="server" CssClass="control-label">Talle</asp:Label>
				<asp:DropDownList ID="ddlProductSize" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlProductSize_SelectedIndexChanged"/>
				<asp:RequiredFieldValidator runat="server" ControlToValidate="ddlProductSize" validationgroup="insertGroup" InitialValue="-Talle-" CssClass="text-danger" ErrorMessage="Por favor, seleccione un talle" />

			</div>
			<div  runat="server" id="divProductSizeStock">
				<asp:Label runat="server" CssClass="control-label">Stock</asp:Label>

				<asp:TextBox runat="server" AutoPostBack="true" ID="txtProductSizeStock" MaxLength="5" TextMode="Number" CssClass="form-control" ToolTip="Ingrese un stock para cada talle." OnTextChanged="txtProductSizeStock_TextChanged"/>
				<asp:requiredfieldvalidator controltovalidate="txtProductSizeStock" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, ingrese stock" runat="Server"/>

			</div>
			<div  runat="server" id="divProductImage">
				<asp:Label runat="server" CssClass="control-label">Imagen</asp:Label>

				<asp:FileUpload ID="FileUpload1" runat="server" />
				<asp:RequiredFieldValidator runat="server" CssClass="text-danger" validationgroup="insertGroup" ControlToValidate="FileUpload1" ErrorMessage="Por favor, ingrese una imagen"/>

            <hr />
			</div>
			
			<div   runat="server" id="divProductPrice">
				<asp:Label runat="server" CssClass="control-label">Precio en UYU</asp:Label>

				<asp:TextBox runat="server" ID="txtProductPrice" MaxLength="17" TextMode="Number" CssClass="form-control" ToolTip="Ingrese un stock para cada talle."/>
				<asp:requiredfieldvalidator controltovalidate="txtProductPrice" CssClass="text-danger" validationgroup="insertGroup" errormessage="Por favor, ingrese el precio" runat="Server"/>
             <hr />
			</div>
			
			<div >
				<div class="col-md-10">
					<asp:Button ID="btnGenericInsert" validationgroup="insertGroup" runat="server" CssClass="btn btn-default" OnClick="btnGenericInsert_Click"  />
					<asp:Button ID="btnGenericUpdate" validationgroup="insertGroup" runat="server" CssClass="btn btn-default" OnClick="btnGenericUpdate_Click" />
					<asp:Button ID="btnGenericDelete" validationgroup="deleteGroup" runat="server" CssClass="btn btn-default" Text="Borrar" OnClick="btnGenericDelete_Click" Width="101px" />
                    <asp:Button ID="btnGenericReset" runat="server" CssClass="btn btn-default" Text="Limpiar" OnClick="btnGenericReset_Click" Width="101px" />
				</div>
			</div>
			<div  runat="server" id="divLabelMessage">
				<asp:Label runat="server" ID="lblMessageProduct" CssClass="control-label"/>
			</div>
		</div>
		<div class="col-md-6">
			<div class="form-group">
				<div class="col-md-offset-2 col-md-6" style="margin-top: 27px">
					<asp:GridView ID="gvGeneric" runat="server" OnDataBound="gvGeneric_DataBound" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="gvGeneric_SelectedIndexChanged">
						<AlternatingRowStyle BackColor="#CCCCCC" />
						<Columns>
                            <asp:BoundField DataField="FamilyId"  HeaderText="Id    " SortExpression="FamilyId" />
                            <asp:BoundField DataField="FamilyName" HeaderText="Nombre" SortExpression="FamilyName" />

                            <asp:BoundField DataField="DepartamentId"   HeaderText="Id    " SortExpression="DepartamentId" />
                            <asp:BoundField DataField="DepartamentName" HeaderText="Nombre" SortExpression="DepartamentName" />

							<asp:BoundField DataField="ProductId"   HeaderText="Id    " SortExpression="ProductId" />
							<asp:BoundField DataField="ProductCode" HeaderText="Codigo" SortExpression="ProductCode" />
							<asp:BoundField DataField="ProductName" HeaderText="Nombre" SortExpression="ProductName" />
							<asp:BoundField DataField="DepartamentName" HeaderText="Departamento" SortExpression="DepartamentName" />
							<asp:BoundField DataField="FamilyName" HeaderText="Familia" SortExpression="FamilyName" />
							<asp:ButtonField CommandName="Select" Text="Seleccionar" />
						</Columns>
						<FooterStyle Width="30px" BackColor="#CCCCCC" />
						<HeaderStyle Width="30px" BackColor="Black" Font-Bold="True" ForeColor="White" />
						<PagerStyle Width="30px" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
						<SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
						<SortedAscendingCellStyle BackColor="#F1F1F1" />
						<SortedAscendingHeaderStyle BackColor="#808080" />
						<SortedDescendingCellStyle BackColor="#CAC9C9" />
						<SortedDescendingHeaderStyle BackColor="#383838" />
					</asp:GridView>
				</div>
			</div>
			<div class="form-group"  runat="server" id="divMessageGv">
				<asp:Label runat="server" ID="lblMessageGv" CssClass="control-label"/>
			</div>
		</div>
	</div>
</asp:Content>
	