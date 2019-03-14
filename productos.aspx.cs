using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Productos : System.Web.UI.Page
{
    string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["FARMACIASTOPConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (tbProducto.Text == "")
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>Debe ingresar Nombre Producto.</div>";
        }
        else
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            DataRow dr;
            SqlConnection myConnection1 = new SqlConnection(conexion);
            myConnection1.Open();
            String myString = @"SELECT idproducto FROM FTOP10102 WHERE idproducto='" + tbIdproducto.Text + "'";
            SqlCommand myCmd = new SqlCommand(myString, myConnection1);
            da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                SqlConnection myConnection = new SqlConnection(conexion);
                string sql = "INSERT INTO FTOP10102 (nombre, descripcion, imagen, idtipoproducto, idlaboratorio, idestado, idunidaddemedida, medida, preciocompra, precioventa, fechacreacion, usuariocreacion) VALUES (@nombre, @descripcion, @imagen, @idtipoproducto, @idlaboratorio, @idestado, @idunidaddemedida, @medida, @preciocompra, @precioventa, @fechacreacion, @usuariocreacion)";
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = tbProducto.Text;
                cmd.Parameters.AddWithValue("@descripcion", SqlDbType.VarChar).Value = tbDescripcion.Text;
                cmd.Parameters.AddWithValue("@imagen", SqlDbType.VarChar).Value = fuImagen.FileName;
                cmd.Parameters.AddWithValue("@idtipoproducto", SqlDbType.VarChar).Value = ddlTipoProducto.SelectedValue;
                cmd.Parameters.AddWithValue("@idlaboratorio", SqlDbType.VarChar).Value = ddlLaboratorio.SelectedValue;
                cmd.Parameters.AddWithValue("@idestado", SqlDbType.VarChar).Value = ddlEstado.SelectedValue;
                cmd.Parameters.AddWithValue("@idunidaddemedida", SqlDbType.VarChar).Value = ddlUnidaddemedida.SelectedValue;
                cmd.Parameters.AddWithValue("@medida", SqlDbType.VarChar).Value = tbMedida.Text;
                cmd.Parameters.AddWithValue("@preciocompra", SqlDbType.Float).Value = tbPrecioCompra.Text;
                cmd.Parameters.AddWithValue("@precioventa", SqlDbType.Float).Value = tbPrecioVenta.Text;
                cmd.Parameters.AddWithValue("@fechacreacion", DateTime.Now);
                cmd.Parameters.AddWithValue("@usuariocreacion", Session["Usuario"].ToString());
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();
                lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Producto ha sido creado exitosamente.</div>";
                tbIdproducto.Text = "";
                tbProducto.Text = "";
                tbDescripcion.Text = "";
                ddlTipoProducto.SelectedIndex = 0;
                ddlLaboratorio.SelectedIndex = 0;
                ddlEstado.SelectedIndex = 0;
                ddlUnidaddemedida.SelectedIndex = 0;
                tbMedida.Text = "";
                tbPrecioCompra.Text = "";
                tbPrecioVenta.Text = "";
            }
            else
            {
                dr = dt.Rows[0];
                SqlConnection myConnection = new SqlConnection(conexion);
                string sql = "UPDATE FTOP10102 SET nombre=@nombre, descripcion=@descripcion, imagen=@imagen, idtipoproducto=@idtipoproducto, idlaboratorio=@idlaboratorio, idestado=@idestado, idunidaddemedida=@idunidaddemedida, medida=@medida, preciocompra=@preciocompra, precioventa=@precioventa, fechacreacion=@fechacreacion, usuariocreacion=@usuariocreacion WHERE idproducto='" + tbIdproducto.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = tbProducto.Text;
                cmd.Parameters.AddWithValue("@descripcion", SqlDbType.VarChar).Value = tbDescripcion.Text;
                cmd.Parameters.AddWithValue("@imagen", SqlDbType.VarChar).Value = fuImagen.FileName;
                cmd.Parameters.AddWithValue("@idtipoproducto", SqlDbType.VarChar).Value = ddlTipoProducto.SelectedValue;
                cmd.Parameters.AddWithValue("@idlaboratorio", SqlDbType.VarChar).Value = ddlLaboratorio.SelectedValue;
                cmd.Parameters.AddWithValue("@idestado", SqlDbType.VarChar).Value = ddlEstado.SelectedValue;
                cmd.Parameters.AddWithValue("@idunidaddemedida", SqlDbType.VarChar).Value = ddlUnidaddemedida.SelectedValue;
                cmd.Parameters.AddWithValue("@medida", SqlDbType.VarChar).Value = tbMedida.Text;
                cmd.Parameters.AddWithValue("@preciocompra", SqlDbType.Float).Value = tbPrecioCompra.Text;
                cmd.Parameters.AddWithValue("@precioventa", SqlDbType.Float).Value = tbPrecioVenta.Text;
                cmd.Parameters.AddWithValue("@fechacreacion", DateTime.Now);
                cmd.Parameters.AddWithValue("@usuariocreacion", Session["Usuario"].ToString());
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();
                lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Producto ha sido modificado exitosamente.</div>";
            }
            //myCmd.ExecuteScalar();
            myConnection1.Close();
            //GridView1.DataBind();
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        tbIdproducto.Text = "";
        tbProducto.Text = "";
        tbDescripcion.Text = "";
        ddlTipoProducto.SelectedIndex = 0;
        ddlLaboratorio.SelectedIndex = 0;
        ddlEstado.SelectedIndex = 0;
        ddlUnidaddemedida.SelectedIndex = 0;
        tbMedida.Text = "";
        tbPrecioCompra.Text = "";
        tbPrecioVenta.Text = "";
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataRow dr;
        SqlConnection myConnection1 = new SqlConnection(conexion);
        myConnection1.Open();
        String myString = @"SELECT idproducto FROM FTOP10102 WHERE idproducto='" + tbIdproducto.Text + "'";
        SqlCommand myCmd = new SqlCommand(myString, myConnection1);
        da = new SqlDataAdapter(myCmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            dr = dt.Rows[0];
            SqlConnection myConnection = new SqlConnection(conexion);
            string sql = "DELETE FROM FTOP10102 WHERE idproducto='" + tbIdproducto.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
            lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Producto ha sido eliminado exitosamente.</div>";
            GridView1.DataBind();
            tbIdproducto.Text = "";
            tbProducto.Text = "";
            tbDescripcion.Text = "";
            ddlTipoProducto.SelectedIndex = 0;
            ddlLaboratorio.SelectedIndex = 0;
            ddlEstado.SelectedIndex = 0;
            ddlUnidaddemedida.SelectedIndex = 0;
            tbMedida.Text = "";
            tbPrecioCompra.Text = "";
            tbPrecioVenta.Text = "";
        }
        else
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>No ha seleccionado Producto.</div>";
        }
        //myCmd.ExecuteScalar();
        myConnection1.Close();
        
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            SqlDataAdapter da;
            DataRow dr;
            DataTable dt = new DataTable();
            SqlConnection myConnection1 = new SqlConnection(conexion);
            myConnection1.Open();
            String myString = @"SELECT idproducto, nombre, FTOP10102.descripcion, imagen,
                                        FTOP10103.idtiposproducto, FTOP10103.tiposproducto,
                                        FTOP10104.idlaboratorio, FTOP10104.laboratorio,
                                        FTOP10105.idestado, FTOP10105.estado, 
                                        FTOP10106.idunidaddemedida, FTOP10106.unidaddemedida, 
                                        medida, preciocompra, precioventa, 
                                        FTOP10102.fechacreacion, FTOP10102.usuariocreacion 
                                FROM FTOP10102, FTOP10106, FTOP10105, FTOP10103, FTOP10104 
                                WHERE FTOP10102.idunidaddemedida = FTOP10106.idunidaddemedida AND 
                                        FTOP10102.idestado = FTOP10105.idestado AND
                                        FTOP10103.idtiposproducto = FTOP10102.idtipoproducto AND
                                        FTOP10104.idlaboratorio = FTOP10102.idlaboratorio";
            SqlCommand myCmd = new SqlCommand(myString, myConnection1);
            da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[currentRowIndex];
                tbIdproducto.Text = dr[0].ToString();
                tbProducto.Text = dr[1].ToString();
                tbDescripcion.Text = dr[2].ToString();
                //fuImagen = dr[3].ToString();
                ddlTipoProducto.SelectedValue = dr[4].ToString();
                ddlTipoProducto.SelectedItem.Text = dr[5].ToString();
                ddlLaboratorio.SelectedValue = dr[6].ToString();
                ddlLaboratorio.SelectedItem.Text = dr[7].ToString();
                ddlEstado.SelectedValue = dr[8].ToString();
                ddlEstado.SelectedItem.Text = dr[9].ToString();
                ddlUnidaddemedida.SelectedValue = dr[10].ToString();
                ddlUnidaddemedida.SelectedItem.Text = dr[11].ToString();
                tbMedida.Text = dr[12].ToString();
                tbPrecioCompra.Text = dr[13].ToString();
                tbPrecioVenta.Text = dr[14].ToString();
            }
            else
            {
            }
            myConnection1.Close();
        }
        catch (Exception exec)
        {
            lblMensaje.Text = @"<div class='alert alert-danger alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Error!</h4>" + exec.ToString() + "</div>";
        }
    }
    protected void btnBusqueda_Click(object sender, EventArgs e)
    {
        SqlDataSource1.SelectCommand = @"SELECT idproducto, nombre, descripcion, FTOP10105.estado, FTOP10106.unidaddemedida, medida, FTOP10102.fechacreacion, FTOP10102.usuariocreacion 
                                            FROM FTOP10102, FTOP10106, FTOP10105 
                                            WHERE FTOP10102.idunidaddemedida = FTOP10106.idunidaddemedida AND FTOP10102.idestado = FTOP10105.idestado 
                                                    AND (FTOP10102.nombre like '%" + tbBusqueda.Text + "%' OR FTOP10102.descripcion like '%" + tbBusqueda.Text + "%')";
        GridView1.DataBind();
    }
}