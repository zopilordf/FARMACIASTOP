<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="productos.aspx.cs" Inherits="_Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="box box-info">
                <div class="box-header">
                    <h3 class="box-title">Productos</h3>
                </div>
                <div class="box-body">
                    <!-- ID -->
                    <div class="form-group">
                        <label>Id</label>
                        <asp:Label ID="tbIdproducto" runat="server" class="form-control bg-gray"></asp:Label>
                    </div>
                    <!-- Nombre -->
                    <div class="form-group">
                        <label>Producto</label>
                        <asp:TextBox ID="tbProducto" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <!-- Descripcion -->
                    <div class="form-group">
                        <label>Descripcion</label>
                        <asp:TextBox ID="tbDescripcion" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <!-- Imagen -->
                    <div class="form-group">
                        <label>Imagen</label>
                        <asp:FileUpload ID="fuImagen" runat="server" class="form-control" />
                    </div>
                    <!-- Tipo Producto -->
                    <div class="form-group">
                        <label>Tipo Producto</label>
                        <asp:DropDownList ID="ddlTipoProducto" runat="server" class="form-control" DataSourceID="SqlDataSource2" DataTextField="tiposproducto" DataValueField="idtiposproducto"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FARMACIASTOPConnectionString %>" SelectCommand="SELECT [idtiposproducto], [tiposproducto] FROM [FTOP10103]"></asp:SqlDataSource>
                    </div>
                    <!-- Laboratorio -->
                    <div class="form-group">
                        <label>Laboratorio</label>
                        <asp:DropDownList ID="ddlLaboratorio" runat="server" class="form-control" DataSourceID="SqlDataSource3" DataTextField="laboratorio" DataValueField="idlaboratorio"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:FARMACIASTOPConnectionString %>" SelectCommand="SELECT [idlaboratorio], [laboratorio] FROM [FTOP10104]"></asp:SqlDataSource>
                    </div>
                    <!-- Estado -->
                    <div class="form-group">
                        <label>Estado</label>
                        <asp:DropDownList ID="ddlEstado" runat="server" class="form-control" DataSourceID="SqlDataSource4" DataTextField="estado" DataValueField="idestado"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:FARMACIASTOPConnectionString %>" SelectCommand="SELECT [idestado], [estado] FROM [FTOP10105]"></asp:SqlDataSource>
                    </div>
                    <!-- Unidad de Medida -->
                    <div class="form-group">
                        <label>Unidad de Medida</label>
                        <asp:DropDownList ID="ddlUnidaddemedida" runat="server" class="form-control" DataSourceID="SqlDataSource5" DataTextField="unidaddemedida" DataValueField="idunidaddemedida"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:FARMACIASTOPConnectionString %>" SelectCommand="SELECT [idunidaddemedida], [unidaddemedida] FROM [FTOP10106]"></asp:SqlDataSource>
                    </div>
                    <!-- Medida -->
                    <div class="form-group">
                        <label>Medida</label>
                        <asp:TextBox ID="tbMedida" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <!-- Precio Compra -->
                    <div class="form-group">
                        <label>Precio Compra</label>
                        <asp:TextBox ID="tbPrecioCompra" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <!-- Precio Venta -->
                    <div class="form-group">
                        <label>Precio Venta</label>
                        <asp:TextBox ID="tbPrecioVenta" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <!-- /.form group -->
                    <div class="box-footer">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="btn btn-primary" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btnCancelar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnEliminar_Click" />
                    </div>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->
            <!-- TABLE -->
            <div class="box box-default">
                <div class="box-header with-border">
                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridView1_RowCommand">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="idproducto" HeaderText="ID" SortExpression="idproducto" InsertVisible="False" ReadOnly="True" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                            <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                            <asp:BoundField DataField="unidaddemedida" HeaderText="Unidad de Medida" SortExpression="unidaddemedida" />
                            <asp:BoundField DataField="medida" HeaderText="medida" SortExpression="Medida" />
                            <asp:BoundField DataField="fechacreacion" DataFormatString="{0:yyyy/MM/dd}" HeaderText="FechaCreacion" SortExpression="fechacreacion" />
                            <asp:BoundField DataField="usuariocreacion" HeaderText="UsuarioCreacion" SortExpression="usuariocreacion" />
                            <asp:ButtonField ButtonType="Button" Text="Editar" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FARMACIASTOPConnectionString %>" SelectCommand="SELECT idproducto, nombre, FTOP10105.estado, FTOP10106.unidaddemedida, medida, FTOP10102.fechacreacion, FTOP10102.usuariocreacion FROM FTOP10102, FTOP10106, FTOP10105 WHERE FTOP10102.idunidaddemedida = FTOP10106.idunidaddemedida AND FTOP10102.idestado = FTOP10105.idestado"></asp:SqlDataSource>

                    <!-- /.row -->
                </div>
                <asp:Label ID="lblMensaje" runat="server" class="form-control"></asp:Label>
            </div>
            <!-- /.box -->
        </section>
    </div>
</asp:Content>

