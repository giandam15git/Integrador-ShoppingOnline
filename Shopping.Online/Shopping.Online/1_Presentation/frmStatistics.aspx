<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmStatistics.aspx.cs" Inherits="Shopping.Online._1_Presentation.frmStatistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" lang="javascript">

    function openPrintBill() {
        var popup = window.open('', 'winReport', 'width=500,height=500,left=50,top=100,­menubar=0,toolbar=0,status=0,scrollbars=1,resizable=0,titlebar=0');
        
        popup.document.write('<html><body><table><input type="button" value="Imprimir" onclick="javascript:window.print()" />');

        popup.document.write(document.all.divContentBills.innerHTML);

        popup.document.write('</table></body></html>');

        }

    function openPrintProducts() {
        var popup = window.open('', 'winReport', 'width=500,height=500,left=50,top=100,­menubar=0,toolbar=0,status=0,scrollbars=1,resizable=0,titlebar=0');

        popup.document.write('<html><body><table><input type="button" value="Imprimir" onclick="javascript:window.print()" />');

        popup.document.write(document.all.divContentProducts.innerHTML);

        popup.document.write('</table></body></html>');

    }

    </script> 
    <div class="container">
        <div class="col-md-12" >
            <div class="col-md-3 divBtnStatistics">
                <div class="col-md-2">
                    <asp:Button ID="btnPrintProductsSoldInOrNot" validationgroup="insertGroup" runat="server" Text="Imprimir" CssClass="btn btn-default" style="width: 210px; margin-top: 15px;" OnClick="btnPrint_Click" />
                    <asp:Button ID="btnProductsSoldIn" validationgroup="insertGroup" runat="server" Text="Vendidos en: " CssClass="btn btn-default" style="width: 210px; margin-top: 60px;" OnClick="btnProductsSoldIn_Click" />
                    <asp:Button ID="btnProductsNotSoldIn" validationgroup="insertGroup" runat="server" Text="No vendidos en: " CssClass="btn btn-default" style="width: 210px; margin-top: 30px;" OnClick="btnProductsNotSoldIn_Click" />
                </div>
            </div>
            <div class="col-md-3 divCalendar">
                <asp:Label runat="server" style="margin-left: 100px;">Desde</asp:Label>
                <asp:Calendar ID="calendarFrom" runat="server" CssClass="calendar"></asp:Calendar>
            </div>
            <div class="col-md-3 divCalendar">
                <asp:Label runat="server" style="margin-left: 100px;">Hasta</asp:Label>
                <asp:Calendar ID="calendarTo" runat="server" CssClass="calendar"></asp:Calendar>
            </div>
            <div class="col-md-3 divBtnStatistics">
                <asp:Button ID="btnPrintBillSelected" validationgroup="insertGroup" runat="server" Text="Imprimir factura seleccionada" OnClick="btnPrintBillSelected_Click" CssClass="btn btn-default" style="width: 236px; margin-top: 16px;"/>
                <div class="lblTotalAmount">
                    <strong>Total en UYU: $ </strong>
                    <asp:Label runat="server" ID="lblTotalAmountSales" Text="0"></asp:Label>
                </div>
                <asp:Button ID="btnSalesInDb" validationgroup="insertGroup" runat="server" Text="Mostrar ventas en rango elegido" CssClass="btn btn-default" style="width: 236px; margin-top: -111px;" OnClick="btnSalesInDb_Click"/>
            </div>
        </div>
        <!-- Comienza Grid de Productos-->
        <div class="col-md-6 gvSalesTop" id="divContentProducts">
            <asp:Label runat="server" ID="lblMessageGv" CssClass="control-label"/>
			<asp:GridView ID="gvGenericProducts" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" >
				<AlternatingRowStyle BackColor="#CCCCCC" />
				<Columns>
                    <asp:BoundField DataField="ProductId"   HeaderText="Id" SortExpression="ProductId" />
					<asp:BoundField DataField="ProductCode" HeaderText="Codigo" SortExpression="ProductCode" />
					<asp:BoundField DataField="ProductName" HeaderText="Nombre" SortExpression="ProductName" />
                    <asp:BoundField DataField="ProductPrice" HeaderText="Precio" SortExpression="ProductPrice" />
					<asp:BoundField DataField="DepartamentName" HeaderText="Departamento" SortExpression="DepartamentName" />
					<asp:BoundField DataField="FamilyName" HeaderText="Familia" SortExpression="FamilyName" />
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
        <!-- Fin Grid de Productos-->

        <!-- Comienzan los Grid de Ventas-->
        <div class="col-md-6" id="divContentBills" >
            <div class="gvSalesTop">
                <asp:Label runat="server" ID="lblMessageSales" CssClass="control-label divSalesTop"/>
				<asp:GridView ID="gvSales" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="gvSales_SelectedIndexChanged" >
					<AlternatingRowStyle BackColor="#CCCCCC" />
					<Columns>
                        <asp:BoundField DataField="SaleId"   HeaderText="Id" SortExpression="ProductId" />
						<asp:BoundField DataField="SaleAmount" HeaderText="Monto en UYU" SortExpression="ProductCode" />
						<asp:BoundField DataField="SaleDate" HeaderText="Fecha de venta" SortExpression="ProductName" />
                        <asp:ButtonField CommandName="Select" Text="Detalle" />
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
            <div class="gvLineSalesBotton">
                <asp:Label runat="server" ID="lblMessageLineSales" CssClass="control-label divSalesTop"/>
				<asp:GridView ID="gvLineSales" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" >
					<AlternatingRowStyle BackColor="#CCCCCC" />
					<Columns>
                        <asp:BoundField DataField="LineSaleId"   HeaderText="Id" SortExpression="LineSaleId" />
						<asp:BoundField DataField="ProductCode" HeaderText="Codigo" SortExpression="ProductCode" />
						<asp:BoundField DataField="ProductName" HeaderText="Nombre" SortExpression="ProductName" />
                        <asp:BoundField DataField="ProductDescription" HeaderText="Descripción" SortExpression="ProductDescription" />
						<asp:BoundField DataField="LineSaleProductQuantity" HeaderText="Cantidad" SortExpression="LineSaleProductQuantity" />
                        <asp:BoundField DataField="ProductPrice" HeaderText="Precio en UYU" SortExpression="ProductPrice" />
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
        <!-- Terminan los Grid de Ventas-->
    </div>
</asp:Content>
