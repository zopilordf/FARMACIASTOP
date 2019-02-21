using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _FormasDePago : System.Web.UI.Page
{
    string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["FARMACIASTOPConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (tbFormasdepago.Text == "")
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>Debe ingresar Formas de Pago.</div>";
        }
        else
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            DataRow dr;
            SqlConnection myConnection1 = new SqlConnection(conexion);
            myConnection1.Open();
            String myString = @"SELECT idFormasdepago FROM FTOP10101 WHERE idFormasdepago='" + tbIdformasdepago.Text + "'";
            SqlCommand myCmd = new SqlCommand(myString, myConnection1);
            da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                SqlConnection myConnection = new SqlConnection(conexion);
                string sql = "INSERT INTO FTOP10101 (Formasdepago, fechacreacion) VALUES (@Formasdepago, @fechacreacion)";
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                cmd.Parameters.AddWithValue("@Formasdepago", SqlDbType.VarChar).Value = tbFormasdepago.Text;
                cmd.Parameters.AddWithValue("@fechacreacion", DateTime.Now);
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();
                lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Formas de Pago ha sido creado exitosamente.</div>";
                tbIdformasdepago.Text = "";
                tbFormasdepago.Text = "";
            }
            else
            {
                dr = dt.Rows[0];
                SqlConnection myConnection = new SqlConnection(conexion);
                string sql = "UPDATE FTOP10101 SET Formasdepago=@Formasdepago, fechacreacion=@fechacreacion WHERE idFormasdepago='" + tbIdformasdepago.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                cmd.Parameters.AddWithValue("@idFormasdepago", SqlDbType.VarChar).Value = tbIdformasdepago.Text;
                cmd.Parameters.AddWithValue("@Formasdepago", SqlDbType.VarChar).Value = tbFormasdepago.Text;
                cmd.Parameters.AddWithValue("@fechacreacion", DateTime.Now);
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();
                lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Formas de Pago ha sido modificado exitosamente.</div>";
            }
            //myCmd.ExecuteScalar();
            myConnection1.Close();
            GridView1.DataBind();
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        tbIdformasdepago.Text = "";
        tbFormasdepago.Text = "";
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataRow dr;
        SqlConnection myConnection1 = new SqlConnection(conexion);
        myConnection1.Open();
        String myString = @"SELECT idFormasdepago FROM FTOP10101 WHERE idFormasdepago='" + tbIdformasdepago.Text + "'";
        SqlCommand myCmd = new SqlCommand(myString, myConnection1);
        da = new SqlDataAdapter(myCmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            dr = dt.Rows[0];
            SqlConnection myConnection = new SqlConnection(conexion);
            string sql = "DELETE FROM FTOP10101 WHERE idFormasdepago='" + tbIdformasdepago.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
            lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Formas de Pago ha sido eliminado exitosamente.</div>";
            GridView1.DataBind();
            tbIdformasdepago.Text = "";
            tbFormasdepago.Text = "";
        }
        else
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>No ha seleccionado Formas de Pago.</div>";
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
            String myString = @"SELECT idFormasdepago, Formasdepago, fechacreacion FROM FTOP10101";
            SqlCommand myCmd = new SqlCommand(myString, myConnection1);
            da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[currentRowIndex];
                tbIdformasdepago.Text = dr[0].ToString();
                tbFormasdepago.Text = dr[1].ToString();
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