using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Clientes : System.Web.UI.Page
{
    string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["FARMACIASTOPConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (tbNombre.Text == "")
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>Debe ingresar Nombre.</div>";
        }
        else if (tbNit.Text == "")
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>Debe ingresar NIT.</div>";
        }
        else if (tbDireccion.Text == "")
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>Debe ingresar Direccion.</div>";
        }
        else
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            DataRow dr;
            SqlConnection myConnection1 = new SqlConnection(conexion);
            myConnection1.Open();
            String myString = @"SELECT idcliente FROM FTOP10100 WHERE idcliente='" + tbIdcliente.Text + "'";
            SqlCommand myCmd = new SqlCommand(myString, myConnection1);
            da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                SqlConnection myConnection = new SqlConnection(conexion);
                string sql = "INSERT INTO FTOP10100 (nombre, nit, direccion, telefono, email, fechacreacion, usuariocreacion) VALUES (@nombre, @nit, @direccion, @telefono, @email, @fechacreacion, @usuariocreacion)";
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = tbNombre.Text;
                cmd.Parameters.AddWithValue("@nit", SqlDbType.VarChar).Value = tbNit.Text;
                cmd.Parameters.AddWithValue("@direccion", SqlDbType.VarChar).Value = tbDireccion.Text;
                cmd.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = tbTelefono.Text;
                cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = tbEmail.Text;
                cmd.Parameters.AddWithValue("@fechacreacion", DateTime.Now);
                cmd.Parameters.AddWithValue("@usuariocreacion", Session["Usuario"].ToString());
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();
                lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Cliente ha sido creado exitosamente.</div>";
                tbIdcliente.Text = "";
                tbNombre.Text = "";
                tbNit.Text = "";
                tbDireccion.Text = "";
                tbTelefono.Text = "";
                tbEmail.Text = "";
            }
            else
            {
                dr = dt.Rows[0];
                SqlConnection myConnection = new SqlConnection(conexion);
                string sql = "UPDATE FTOP10100 SET nombre=@nombre, nit=@nit, direccion=@direccion, telefono=@telefono, email=@email, fechacreacion=@fechacreacion, usuariocreacion=@usuariocreacion WHERE idcliente='" + tbIdcliente.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = tbNombre.Text;
                cmd.Parameters.AddWithValue("@nit", SqlDbType.VarChar).Value = tbNit.Text;
                cmd.Parameters.AddWithValue("@direccion", SqlDbType.VarChar).Value = tbDireccion.Text;
                cmd.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = tbTelefono.Text;
                cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = tbEmail.Text;
                cmd.Parameters.AddWithValue("@fechacreacion", DateTime.Now);
                cmd.Parameters.AddWithValue("@usuariocreacion", Session["Usuario"].ToString());
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();
                lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Cliente ha sido modificado exitosamente.</div>";
            }
            //myCmd.ExecuteScalar();
            myConnection1.Close();
            GridView1.DataBind();
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        tbIdcliente.Text = "";
        tbNombre.Text = "";
        tbNit.Text = "";
        tbDireccion.Text = "";
        tbTelefono.Text = "";
        tbEmail.Text = "";
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataRow dr;
        SqlConnection myConnection1 = new SqlConnection(conexion);
        myConnection1.Open();
        String myString = @"SELECT idcliente FROM FTOP10100 WHERE idcliente='" + tbIdcliente.Text + "'";
        SqlCommand myCmd = new SqlCommand(myString, myConnection1);
        da = new SqlDataAdapter(myCmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            dr = dt.Rows[0];
            SqlConnection myConnection = new SqlConnection(conexion);
            string sql = "DELETE FROM FTOP10100 WHERE idcliente='" + tbIdcliente.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
            lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Cliente ha sido eliminado exitosamente.</div>";
            GridView1.DataBind();
            tbIdcliente.Text = "";
            tbNombre.Text = "";
            tbNit.Text = "";
            tbDireccion.Text = "";
            tbTelefono.Text = "";
            tbEmail.Text = "";
        }
        else
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>No ha seleccionado Cliente.</div>";
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
            String myString = SqlDataSource1.SelectCommand.ToString();
            SqlCommand myCmd = new SqlCommand(myString, myConnection1);
            da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[currentRowIndex];
                tbIdcliente.Text = dr[0].ToString();
                tbNombre.Text = dr[1].ToString();
                tbNit.Text = dr[2].ToString();
                tbDireccion.Text = dr[3].ToString();
                tbTelefono.Text = dr[4].ToString();
                tbEmail.Text = dr[5].ToString();
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
}