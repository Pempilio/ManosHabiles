using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManosHabilesProf
{
    public partial class WebForm2 : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombreA"] == null ||
                Session["claveA"] == null)
            {//Las variables de sesion no existen,
             //Por lo tanto redireccionamos al usuario al login
                Response.Redirect("loginAdmin.aspx");
            }
        }



        protected void Button3_Click(object sender, EventArgs e)
        {

            Session.Clear(); //Si el admin hace log out hay que vaciar las variables de session para que no haya problemas
            Session.Abandon();
            Response.Redirect("LoginAdmin.aspx"); // redirigimos al Administrador al login para que no use más la funcionalidad 
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Banear.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaAdmin.aspx");
        }
    }
}