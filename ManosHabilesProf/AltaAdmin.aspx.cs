using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ManosHabilesProf
{
    public partial class AltaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              if (Session["nombreA"] == null || Session["claveA"] == null)
                 Response.Redirect("LoginAdmin.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
 
            String query = "insert into Administrador values (?,?,?,?,?)";
            //Query para calcular la llave primaria
            //Este query no necesita parametros
            String queryCAdmin = "select max(cAdmin) from Administrador";
            int llavePrimaria;

            //Declarar e instanciar la conexion
            //De forma abreviada, ver login para forma completa
            OdbcConnection conexion = new ConexionBD().con;

            //Crear el comando de la llave primaria
            OdbcCommand comando = new OdbcCommand(queryCAdmin, conexion);
            OdbcDataReader lector = comando.ExecuteReader();
            lector.Read();
            try
            {
                llavePrimaria = lector.GetInt32(0) + 1;
            }
            catch (Exception ex)
            {
                Label1.Text = "Hay un problema, llamar al equipo de soporte tecnico";
                llavePrimaria = -1;
            }
            //Crear el comando de la llave primaria

            //Crear el usuario nuevo con los parametros del usuario
            //y la llave primaria
            comando = new OdbcCommand(query, conexion);
            //Configurar los parametros en el orden adecuado al comando
            comando.Parameters.AddWithValue("cAdmin", llavePrimaria);
            comando.Parameters.AddWithValue("nombre", TextBox1.Text);
            comando.Parameters.AddWithValue("apellido", TextBox2.Text);
            comando.Parameters.AddWithValue("correo", TextBox2.Text);
            comando.Parameters.AddWithValue("passwrd", TextBox3.Text);
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
            }
            catch (Exception ex)
            {
                //Quitar esto antes de liberar a produccion
                Label1.Text = ex.ToString();
            }
            conexion.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }
    }
}