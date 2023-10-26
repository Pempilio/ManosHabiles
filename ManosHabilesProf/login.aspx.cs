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
            String query = "select cProf,nombre,codigoPost,estatus from Profesionista where correo=? and passwrd=?";
            String queryCliente = "select cCliente,nombre,codigoPost,estatus from Cliente where correo=? and passwrd=?";
            String nombre;
            int clave, CP, estatus;

            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando;
            comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("correo", TextBox1.Text);
            comando.Parameters.AddWithValue("passwrd", TextBox2.Text);
            OdbcDataReader lector = comando.ExecuteReader();
            OdbcDataReader lector2;

            if (lector.HasRows)
            {
                lector.Read();
                clave = lector.GetInt32(0);
                nombre = lector.GetString(1);
                CP = lector.GetInt32(2);
                estatus = lector.GetInt32(3);

                if (estatus == 0)
                {
                    Session.Timeout = 10;
                    Session.Add("cProf", clave);
                    Session.Add("nombre", nombre);
                    Session.Add("codigoPostal", CP);
                    Response.Redirect("HomeProfesionista.aspx");
                }
                else
                {
                    Label1.Text = "Lo sentimos usted no puede usar su cuenta por motivos de ban";
                }
            }
            else
            {
                lector.Close();
                comando = new OdbcCommand(queryCliente, conexion);
                comando.Parameters.AddWithValue("correo", TextBox1.Text);
                comando.Parameters.AddWithValue("passwrd", TextBox2.Text);
                lector2 = comando.ExecuteReader();

                if (lector2.HasRows)
                {
                    lector2.Read();
                    clave = lector2.GetInt32(0);
                    nombre = lector2.GetString(1);
                    CP = lector2.GetInt32(2);
                    estatus = lector2.GetInt32(3);
                    if (estatus == 0)
                    {
                        Session.Timeout = 30;
                        Session.Add("cCliente", clave);
                        Session.Add("nombre", nombre);
                        Session.Add("codigoPostal", CP);
                        Response.Redirect("Cliente.aspx");
                    }
                    else
                    {
                        Label1.Text = "Lo sentimos usted no puede usar su cuenta por motivos de ban";
                    }
                }
                else
                {
                    Label1.Text = "Correo o contraseña incorrectos";
                    Session.Clear();
                    Session.Abandon();
                }
            }
            lector.Close();
        }
    }
}