<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="rolesusuario.aspx.cs" Inherits="_RolesUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="box box-info">
                <div class="box-header">
                    <h3 class="box-title">Roles - Usuario</h3>
                </div>
                <div class="box-body">
                    <!-- Nombre -->
                    <div class="form-group">
                        <label>Roles</label>
                        <asp:DropDownList ID="ddlRoles" runat="server" class="form-control" DataSourceID="SqlDataSource2" DataTextField="nombre" DataValueField="idrol"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FARMACIASTOPConnectionString %>" SelectCommand="SELECT [idrol], [nombre] FROM [FTOP00101]"></asp:SqlDataSource>
                    </div>
                    <!-- Usuario -->
                    <div class="form-group">
                        <label>Usuario</label>
                        <asp:DropDownList ID="ddlUsuario" runat="server" class="form-control" DataSourceID="SqlDataSource3" DataTextField="nombre" DataValueField="idusuario"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:FARMACIASTOPConnectionString %>" SelectCommand="SELECT [idusuario], [nombre] FROM [FTOP00100]"></asp:SqlDataSource>
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
                            <asp:BoundField DataField="nombrerol" HeaderText="Rol" SortExpression="nombrerol" InsertVisible="False" ReadOnly="True" />
                            <asp:BoundField DataField="nombreusuario" HeaderText="Usuario" SortExpression="nombreusuario" />
                            <asp:BoundField DataField="fechacreacion" DataFormatString="{0:yyyy/MM/dd}" HeaderText="FechaCreacion" SortExpression="fechacreacion" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FARMACIASTOPConnectionString %>" SelectCommand="select FTOP00101.nombre as nombrerol, FTOP00100.nombre as nombreusuario, FTOP00102.fechacreacion from FTOP00102, FTOP00100, FTOP00101 where FTOP00102.idroles = FTOP00101.idrol AND FTOP00102.idusuario = FTOP00100.idusuario"></asp:SqlDataSource>

                    <!-- /.row -->
                </div>
                <asp:Label ID="lblMensaje" runat="server" class="form-control"></asp:Label>
            </div>
            <!-- /.box -->
        </section>
    </div>
</asp:Content>

