using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManosHabiles
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "select cAdmin,nombre from Administrador "
             + " where correo = ? "
             + " and passwrd = ?";
            String nombreAdmin;//es un valor que regresa el select
            int claveAdmin;//es un valor que regresa el select

            OdbcConnection conexion;
            ConexionBD objetoConexionBD = new ConexionBD();
            //Asignar la conexion de ConexionBD a conexion
            //La conexion llega abierta de ConexionBD
            conexion = objetoConexionBD.con;

            //El objeto comando requiere una conexion abierta y
            //una instruccion de sql para operar
            OdbcCommand comando = new OdbcCommand(query, conexion);

            //Configurar los parametros del comando
            //Deben de estar en el mismo orden de los ?s en
            //el query
            comando.Parameters.AddWithValue("correo", TextBox1.Text);
            comando.Parameters.AddWithValue("passwrd", TextBox2.Text);

            //Ejecutamos el comando y lo guardamos en un lector
            //Usamos ExecuteReader porque es un select y regresa
            //una tabla
            OdbcDataReader lector = comando.ExecuteReader();

            //Navegar el lector para obtener la clave del cliente y
            //el nombre del cliente
            if (lector.HasRows)//Regresa si el lector tiene renglones
            {
                lector.Read(); //Avanza al primer renglon del lector
                               //el lector siempre inicia en -1
                claveAdmin = lector.GetInt32(0);//0 es el numero
                                                  //de la columna que regreso el select
                nombreAdmin = lector.GetString(1);//1 es el numero
                                                    //de la columna que regreso el select

                //Timeout de la sesion, se cierra automáticamente
                //es en minutos
                Session.Timeout = 10;
                //Guardar el nombre y la clave del cliente en
                //variables de sesión
                Session.Add("nombreA", nombreAdmin);
                Session.Add("claveA", claveAdmin);

                //Redireccionar a la pagina cafeteria
                Response.Redirect("MenuAdmin.aspx");
            }
            else
            {
                Label1.Text = "Correo o contraseña equivocados";
                //Cerrar la sesion
                Session.Clear();   //Borra todas las viriables de sesion
                                   //y NO cierra la sesion
                Session.Abandon(); //Borra todas las variables de sesion
                                   //y cierra la sesion, es más seguro usar abandon
                                   //que close

            }
            conexion.Close();
        }
    }
}