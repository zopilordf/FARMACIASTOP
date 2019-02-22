using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (Session["Usuario"] != null)
        {
            lblNombreUsuario.Text = Session["Usuario"].ToString();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["Usuario"] = "";
        Response.Redirect("login.aspx");
    }
}
