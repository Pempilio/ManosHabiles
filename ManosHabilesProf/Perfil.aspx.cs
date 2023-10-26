using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManosHabilesProf
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cProf"] == null || Session["nombre"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (TextBox1.Text == "")
            {
                //cProf -> Session[cProf]
                String query = "select nombre,apellido,correo,passwrd,codigoPost,descripcion from Profesionista where " +
                    " Profesionista.cProf = ?";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                comando.Parameters.AddWithValue("cProf", Session["cProf"]);
                OdbcDataReader lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    lector.Read();
                    TextBox1.Text = lector.GetString(0);
                    TextBox2.Text = lector.GetString(1);
                    TextBox3.Text = lector.GetString(2);
                    TextBox4.Text = lector.GetString(3);
                    TextBox6.Text = lector.GetString(4);
                    TextBox5.Text = lector.GetString(5);
                    lector.Close();
                }
                conexion.Close();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //nombre -> TextBox1
            //apellido -> TextBox2
            //correo-> TextBox3
            //passwrd -> TextBox4
            //codigoPost -> TextBox6
            //descripcion -> TextBox5
            //cProf -> Session[cProf]
            String query = "update Profesionista set nombre = ?, apellido=?,correo=?, " +
                " passwrd=?,codigoPost=?,descripcion=? where Profesionista.cProf=?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("nombre", TextBox1.Text);
            comando.Parameters.AddWithValue("apellido", TextBox2.Text);
            comando.Parameters.AddWithValue("correo", TextBox3.Text);
            comando.Parameters.AddWithValue("passwrd", TextBox4.Text);
            comando.Parameters.AddWithValue("codigoPost", TextBox6.Text);
            comando.Parameters.AddWithValue("descripcion", TextBox5.Text);
            comando.Parameters.AddWithValue("cProf", Session["cProf"]);

            try
            {
                comando.ExecuteNonQuery();
                Label1.Text = "Cambios realizados con éxito";
            }catch (Exception ex)
            {
                Label1.Text = "error: " + ex.ToString();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeProfesionista.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}