using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["FARMACIASTOPConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (tbUsuario.Text == "")
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>Debe ingresar Nombre.</div>";
        }
        else if (tbContrasena.Text == "")
        {
            lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>Debe ingresar Contraseña.</div>";
        }
        else
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            DataRow dr;
            SqlConnection myConnection1 = new SqlConnection(conexion);
            myConnection1.Open();
            String myString = @"SELECT nombre, contraseña FROM FTOP00100 WHERE nombre='" + tbUsuario.Text + "' AND contraseña = '" + tbContrasena.Text + "'";
            SqlCommand myCmd = new SqlCommand(myString, myConnection1);
            da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Usuario"] = tbUsuario.Text;    
                Response.Redirect("index.aspx");
            }
            else
            {
                lblMensaje.Text = @"<div class='alert alert-warning alert-dismissible'>
                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                <h4><i class='icon fa fa-warning'></i> Advertencia!</h4>No ha encontrado este usuario.</div>";
            }
            //myCmd.ExecuteScalar();
            myConnection1.Close();
        }
    }
}