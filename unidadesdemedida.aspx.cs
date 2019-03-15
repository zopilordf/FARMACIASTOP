using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _UnidadesDeMedida : System.Web.UI.Page
{
    string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["FARMACIASTOPConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (tbUnidaddemedida.Text == "")
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>Debe ingresar Unidad de Medida.</div>";
        }
        else
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            DataRow dr;
            SqlConnection myConnection1 = new SqlConnection(conexion);
            myConnection1.Open();
            String myString = @"SELECT idunidaddemedida FROM FTOP10106 WHERE idunidaddemedida='" + tbIdunidaddemedida.Text + "'";
            SqlCommand myCmd = new SqlCommand(myString, myConnection1);
            da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                SqlConnection myConnection = new SqlConnection(conexion);
                string sql = "INSERT INTO FTOP10106 (unidaddemedida, fechacreacion) VALUES (@unidaddemedida, @fechacreacion)";
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                cmd.Parameters.AddWithValue("@unidaddemedida", SqlDbType.VarChar).Value = tbUnidaddemedida.Text;
                cmd.Parameters.AddWithValue("@fechacreacion", DateTime.Now);
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();
                lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Unidad de Medida ha sido creado exitosamente.</div>";
                tbIdunidaddemedida.Text = "";
                tbUnidaddemedida.Text = "";
            }
            else
            {
                dr = dt.Rows[0];
                SqlConnection myConnection = new SqlConnection(conexion);
                string sql = "UPDATE FTOP10106 SET unidaddemedida=@unidaddemedida, fechacreacion=@fechacreacion WHERE idunidaddemedida='" + tbIdunidaddemedida.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                cmd.Parameters.AddWithValue("@idunidaddemedida", SqlDbType.VarChar).Value = tbIdunidaddemedida.Text;
                cmd.Parameters.AddWithValue("@unidaddemedida", SqlDbType.VarChar).Value = tbUnidaddemedida.Text;
                cmd.Parameters.AddWithValue("@fechacreacion", DateTime.Now);
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();
                lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Unidad de Medida ha sido modificado exitosamente.</div>";
            }
            //myCmd.ExecuteScalar();
            myConnection1.Close();
            GridView1.DataBind();
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        tbIdunidaddemedida.Text = "";
        tbUnidaddemedida.Text = "";
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataRow dr;
        SqlConnection myConnection1 = new SqlConnection(conexion);
        myConnection1.Open();
        String myString = @"SELECT idunidaddemedida FROM FTOP10106 WHERE idunidaddemedida='" + tbIdunidaddemedida.Text + "'";
        SqlCommand myCmd = new SqlCommand(myString, myConnection1);
        da = new SqlDataAdapter(myCmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            dr = dt.Rows[0];
            SqlConnection myConnection = new SqlConnection(conexion);
            string sql = "DELETE FROM FTOP10106 WHERE idunidaddemedida='" + tbIdunidaddemedida.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
            lblMensaje.Text = @"<div class='alert alert-success alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-check'></i> Exito!</h4>Unidad de Medida ha sido eliminado exitosamente.</div>";
            GridView1.DataBind();
            tbIdunidaddemedida.Text = "";
            tbUnidaddemedida.Text = "";
        }
        else
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>No ha seleccionado Unidad de Medida.</div>";
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
                tbIdunidaddemedida.Text = dr[0].ToString();
                tbUnidaddemedida.Text = dr[1].ToString();
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