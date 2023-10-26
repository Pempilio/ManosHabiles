using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManosHabilesProf
{
    public partial class AltaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              if (Session["nombreA"] == null || Session["claveA"] == null)
                 Response.Redirect("LoginAdmin.aspx");
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String nombre, apellido, correo, contrasena;
            nombre = TextBox1.Text;
            apellido = TextBox2.Text;
            correo = TextBox3.Text;
            contrasena = TextBox4.Text;

            if(string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                Label1.Text = "Complete todos los campos";
                return;
            }
            String query = "insert into Administrador values((select isnull(max(cAdmin),0)+1 from Administrador),?,?,?,?)";
            OdbcConnection conexion = new ConexionBD().con;

            OdbcCommand comando = new OdbcCommand(query, conexion);
            //Configurar los parametros en el orden adecuado al comando
            comando.Parameters.AddWithValue("nombre", nombre);
            comando.Parameters.AddWithValue("apellido", apellido);
            comando.Parameters.AddWithValue("correo", correo);
            comando.Parameters.AddWithValue("passwrd", contrasena);

            try
            {
                //ExecuteNonQuery porque es un insert y no regresa
                //resultados
                comando.ExecuteNonQuery();
                Label1.Text = "Cuenta creada";
                //Limpiar controles
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
            }
            catch (Exception ex)
            {
                //Quitar esto antes de liberar a produccion
                Label1.Text = ex.ToString();
            }
            conexion.Close();
        }
    }
}