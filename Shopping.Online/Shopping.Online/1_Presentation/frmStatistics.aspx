<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmStatistics.aspx.cs" Inherits="Shopping.Online._1_Presentation.frmStatistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-12" >
            <div class="col-md-3" style="border-left:solid black; height: 216px">
                <div class="col-md-1.5">
                    <asp:Button ID="btnProductsSoldIn" validationgroup="insertGroup" runat="server" Text="Vendidos en: " CssClass="btn btn-default" style="width: 236px;" OnClick="btnProductsSoldIn_Click" />
                </div>
                <div class="col-md-1.5">
                    <asp:Button ID="btnProductsNotSoldIn" validationgroup="insertGroup" runat="server" Text="No vendidos en: " CssClass="btn btn-default" style="width: 236px;" OnClick="btnProductsNotSoldIn_Click" />
                </div>
            </div>
            <div class="col-md-3" style="border-left:solid black;">
                <asp:Label runat="server" style="margin-left: 100px;">Desde</asp:Label>
                <asp:Calendar ID="calendarFrom" runat="server"></asp:Calendar>
            </div>
            <div class="col-md-3" style="border-right:solid black;">
                <asp:Label runat="server" style="margin-left: 100px;">Hasta</asp:Label>
                <asp:Calendar ID="calendarTo" runat="server"></asp:Calendar>
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="col-md-6" style="border:1px solid black;">
            <asp:Label runat="server" ID="lblMessageGv" CssClass="control-label"/>
            <div class="col-md-6">
				<asp:GridView ID="gvGenericProducts" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="gvGenericProducts_SelectedIndexChanged" >
					<AlternatingRowStyle BackColor="#CCCCCC" />
					<Columns>
                        <asp:BoundField DataField="ProductId"   HeaderText="Id    " SortExpression="ProductId" />
						<asp:BoundField DataField="ProductCode" HeaderText="Codigo" SortExpression="ProductCode" />
						<asp:BoundField DataField="ProductName" HeaderText="Nombre" SortExpression="ProductName" />
                        <asp:BoundField DataField="ProductPrice" HeaderText="Precio" SortExpression="ProductPrice" />
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
        <div class="col-md-6" style="border:1px solid black;">
            <div class="col-md-6">
				<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="gvGenericProducts_SelectedIndexChanged" >
					<AlternatingRowStyle BackColor="#CCCCCC" />
					<Columns>
                        <asp:BoundField DataField="SaleId"   HeaderText="----Id----" SortExpression="ProductId" />
						<asp:BoundField DataField="SaleAmount" HeaderText="Monto en UYU" SortExpression="ProductCode" />
						<asp:BoundField DataField="SaleDate" HeaderText="Fecha de venta" SortExpression="ProductName" />
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
            <div class="col-md-6">
				<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="gvGenericProducts_SelectedIndexChanged" >
					<AlternatingRowStyle BackColor="#CCCCCC" />
					<Columns>
                        <asp:BoundField DataField="ProductId"   HeaderText="Id    " SortExpression="ProductId" />
						<asp:BoundField DataField="ProductCode" HeaderText="Codigo" SortExpression="ProductCode" />
						<asp:BoundField DataField="ProductName" HeaderText="Nombre" SortExpression="ProductName" />
                        <asp:BoundField DataField="ProductPrice" HeaderText="Precio" SortExpression="ProductPrice" />
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
    </div>
</asp:Content>
