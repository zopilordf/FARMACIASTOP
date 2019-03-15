using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _RolesUsuario : System.Web.UI.Page
{
    string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["FARMACIASTOPConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {

        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataRow dr;
        SqlConnection myConnection1 = new SqlConnection(conexion);
        myConnection1.Open();
        String myString = @"SELECT idroles, idusuario FROM FTOP00102 WHERE idroles='" + ddlRoles.SelectedValue + "' AND idusuario ='" + ddlUsuario.SelectedValue + "'";
        SqlCommand myCmd = new SqlCommand(myString, myConnection1);
        da = new SqlDataAdapter(myCmd);
        da.Fill(dt);
        if (dt.Rows.Count <= 0)
        {
            SqlConnection myConnection = new SqlConnection(conexion);
            string sql = "INSERT INTO FTOP00102 (idroles, idusuario, fechacreacion) VALUES (@idroles, @idusuario, @fechacreacion)";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            cmd.Parameters.AddWithValue("@idroles", SqlDbType.VarChar).Value = ddlRoles.SelectedValue;
            cmd.Parameters.AddWithValue("@idusuario", SqlDbType.VarChar).Value = ddlUsuario.SelectedValue;
            cmd.Parameters.AddWithValue("@fechacreacion", DateTime.Now);
            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
            lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Roles - Usuario ha sido creado exitosamente.</div>";
            ddlRoles.SelectedIndex = 0;
            ddlUsuario.SelectedIndex = 0;
        }
        else
        {
            dr = dt.Rows[0];
            SqlConnection myConnection = new SqlConnection(conexion);
            string sql = "UPDATE FTOP00102 SET idroles=@idroles, idusuario=@idusuario, fechacreacion=@fechacreacion WHERE idroles='" + ddlRoles.SelectedValue + "' AND idusuario ='" + ddlUsuario.SelectedValue + "'";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            cmd.Parameters.AddWithValue("@idroles", SqlDbType.VarChar).Value = ddlRoles.SelectedValue;
            cmd.Parameters.AddWithValue("@idusuario", SqlDbType.VarChar).Value = ddlUsuario.SelectedValue;
            cmd.Parameters.AddWithValue("@fechacreacion", DateTime.Now);
            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
            lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Roles - Usuario ha sido modificado exitosamente.</div>";
        }
        //myCmd.ExecuteScalar();
        myConnection1.Close();
        GridView1.DataBind();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        ddlRoles.SelectedIndex = 0;
        ddlUsuario.SelectedIndex = 0;
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataRow dr;
        SqlConnection myConnection1 = new SqlConnection(conexion);
        myConnection1.Open();
        String myString = @"SELECT idroles, idusuario FROM FTOP00102 WHERE idroles='" + ddlRoles.SelectedValue + "' AND idusuario ='" + ddlUsuario.SelectedValue + "'";
        SqlCommand myCmd = new SqlCommand(myString, myConnection1);
        da = new SqlDataAdapter(myCmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            dr = dt.Rows[0];
            SqlConnection myConnection = new SqlConnection(conexion);
            string sql = "DELETE FROM FTOP00102 WHERE idroles='" + ddlRoles.SelectedValue + "' AND idusuario ='" + ddlUsuario.SelectedValue + "'";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
            lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Roles - Usuario ha sido eliminado exitosamente.</div>";
            GridView1.DataBind();
            ddlRoles.SelectedIndex = 0;
            ddlUsuario.SelectedIndex = 0;
        }
        else
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>No ha seleccionado Roles - Usuario.</div>";
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
                ddlRoles.SelectedValue = dr[0].ToString();
                ddlUsuario.SelectedValue = dr[1].ToString();
                ddlRoles.SelectedItem.Text = dr[2].ToString();
                ddlUsuario.SelectedItem.Text = dr[3].ToString();
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