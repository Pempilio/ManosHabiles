using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManosHabiles
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //revisamos si hay una sesion abierta y si no mandamos al login
            if (Session["nombreA"] == null || Session["claveA"] == null)
                Response.Redirect("loginAdmin.aspx");
                    
        }
    }
}