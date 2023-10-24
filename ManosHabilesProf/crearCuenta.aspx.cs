using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ManosHabilesProf
{
    public partial class crearCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(DropDownList1.Items.Count == 0)
            {
                String query = "select cEspe,nombre from Especialidad";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                OdbcDataReader lector = comando.ExecuteReader();

                DropDownList1.DataSource = lector;
                DropDownList1.DataValueField = "cEspe";
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();

                lector.Close();
            }
            if(RadioButtonList1.Items.Count == 0)
            {
                String query = "select cSexo,nombre from Sexo";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                OdbcDataReader lector = comando.ExecuteReader();

                RadioButtonList1.DataSource = lector;
                RadioButtonList1.DataValueField = "cSexo";
                RadioButtonList1.DataTextField = "nombre";
                RadioButtonList1.DataBind();

                lector.Close();
            }
            Button2.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //correo -> TextBox3
            String queryComprueba = "select cProf from Profesionista where correo=?";
            /*
             * Nombre -> TextBox1
             * Apellido -> TextBox2
             * Codigo postal -> TextBox5
             * Correo -> TextBox3
             * Contraseña -> TextBox4
             * Fecha -> TextBox7
             * Años exp -> TextBox6
             * Desc -> TextBox8
             * Ban -> Siempre cero
             * Especialidad -> DropDown1
             * Sexo -> RadioButtonList1
             */
            String queryAlta = "insert into Profesionista values((select Isnull(max(cProf),0)+1 from Profesionista),?,?,?,?,?,?,?,?,0,?,?)";

            //Conexión y demás
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando;

            //Comprobamos que no exista
            comando = new OdbcCommand(queryComprueba, conexion);
            comando.Parameters.AddWithValue("correo", TextBox3.Text);
            OdbcDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                Label1.Text = "Correo ya se registró";
            }
            else 
            { 
                comando = new OdbcCommand(queryAlta, conexion);
                comando.Parameters.AddWithValue("nombre", TextBox1.Text);
                comando.Parameters.AddWithValue("apellido", TextBox2.Text);
                comando.Parameters.AddWithValue("codigoPost", TextBox5.Text);
                comando.Parameters.AddWithValue("correo", TextBox3.Text);
                comando.Parameters.AddWithValue("passwrd", TextBox4.Text);
                comando.Parameters.AddWithValue("fechaNaci", TextBox7.Text);
                comando.Parameters.AddWithValue("anosExp", TextBox6.Text);
                comando.Parameters.AddWithValue("descripcion", TextBox8.Text);
                comando.Parameters.AddWithValue("cEspe", DropDownList1.SelectedValue);
                comando.Parameters.AddWithValue("cSexo", RadioButtonList1.SelectedValue);

                try
                {
                    comando.ExecuteNonQuery();
                    Label1.Text = "Su cuenta se ha registado con exito";
                    Button1.Visible = false;
                    Button2.Visible = true;
                }
                catch (Exception ex)
                {
                    Label1.Text = "error: " + ex.ToString();
                }

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}