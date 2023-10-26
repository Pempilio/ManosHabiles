using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManosHabilesProf
{
    public partial class Anuncio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cProf"] == null || Session["nombre"] == null)
            {
                Response.Redirect("login.aspx");
            }
            //CAnuncio -> Session[cAnuncio]
            String query = "select Cliente.nombre,Cliente.codigoPost,Anuncio.semanas,Anuncio.monto,Anuncio.diasDescanso, " +
                " Anuncio.edad,Anuncio.horaEntrada,Anuncio.horaSalida,Anuncio.fechaInicio,Anuncio.descripcion " +
                " from Anuncio inner join Cliente on Anuncio.cCliente=Cliente.cCliente " +
                " where Anuncio.cAnuncio = ?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("cAnuncio", Session["cAnuncio"]);
            OdbcDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                lector.Read();
                Label1.Text = lector.GetString(0);
                Label2.Text = lector.GetString(1);
                Label3.Text = lector.GetString(2);
                Label4.Text = lector.GetString(3);
                Label5.Text = lector.GetString(4);
                Label6.Text = lector.GetString(5);
                Label7.Text = lector.GetString(6);
                Label8.Text = lector.GetString(7);
                Label9.Text = lector.GetString(8);
                Label10.Text = lector.GetString(9);
                lector.Close();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //cAnuncio -> Session[cAnuncio]
            String claveC = "select Cliente.cCliente from Cliente inner join Anuncio on Cliente.cCliente=Anuncio.cCliente " +
                " where Anuncio.cAnuncio = ?";
            int cCliente;
            //cAsunto -> Siempre es 2
            //cCliente -> lo sacamos con lo de arriba
            //cProf -> Session[cProf]
            String query = "insert into Notificaciones values((select isnull(max(cNotif),0)+1 from Notificaciones),CURRENT_TIMESTAMP, " +
                " 2,?,?)";

            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando;
            comando = new OdbcCommand(claveC, conexion);
            comando.Parameters.AddWithValue("cAnuncio", Session["cAnuncio"]);
            OdbcDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                lector.Read();
                cCliente = lector.GetInt32(0);
                lector.Close();
                comando = new OdbcCommand (query, conexion);
                comando.Parameters.AddWithValue("cCliente", cCliente);
                comando.Parameters.AddWithValue("cProf", Session["cProf"]);

                try
                {
                    comando.ExecuteNonQuery();
                    Label11.Text = "Se notificó al cliente tu interes en su anuncio";
                }catch (Exception ex)
                {
                    Label11.Text = "error: " + ex.ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeProfesionista.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Buzon.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}