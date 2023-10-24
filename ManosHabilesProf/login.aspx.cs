using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManosHabilesProf
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Correo -> TextBox1
            //Passwrd -> TextBox2
            String query = "select cProf,nombre from Profesionista where correo=? and passwrd=?";
            String nombre;
            int clave;

            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("correo", TextBox1.Text);
            comando.Parameters.AddWithValue("passwrd", TextBox2.Text);
            OdbcDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                lector.Read();
                clave = lector.GetInt32(0);
                nombre = lector.GetString(1);

                Session.Timeout = 10;
                Session.Add("cProf", clave);
                Session.Add("nombre", nombre);

                Response.Redirect("HomeProfesionista.aspx");
            }
        }
    }
}