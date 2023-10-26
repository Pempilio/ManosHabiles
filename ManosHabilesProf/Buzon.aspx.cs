using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManosHabilesProf
{
    public partial class Buzon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cProf"] == null || Session["nombre"] == null)
            {
                Response.Redirect("login.aspx");
            }
            //cProf -> Session[cProf]
            String claveEsp = "select Profesionista.cEspe from Profesionista where Profesionista.cProf = ?";
            int cEspe;

            //cProf -> Session[cProf]
            //cAsunto -> Siempre en 1
            //cEspe -> Lo obtenemos de arriba
            String query = "select Cliente.nombre as 'Remitente',Asunto.nombre as 'Asunto',Anuncio.descripcion as 'Para este trabajo' " +
                " ,Anuncio.cAnuncio as 'Num' from Notificaciones inner join Asunto on Asunto.cAsunto=Notificaciones.cAsunto " +
                " inner join Cliente on Cliente.cCliente=Notificaciones.cCliente " +
                " inner join Anuncio on Anuncio.cCliente=Cliente.cCliente " +
                " where Notificaciones.cProf = ? and Asunto.cAsunto = 1 and Anuncio.cEspe = ? and Cliente.estatus <> 1";

            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando;
            comando = new OdbcCommand(claveEsp, conexion);
            comando.Parameters.AddWithValue("cProf", Session["cProf"]);
            OdbcDataReader lector = comando.ExecuteReader();
            OdbcDataReader lector2;

            if (lector.HasRows)
            {
                lector.Read();
                cEspe = lector.GetInt32(0);
                lector.Close();
                comando = new OdbcCommand(query, conexion);
                comando.Parameters.AddWithValue("cProf", Session["cProf"]);
                comando.Parameters.AddWithValue("cEspe", cEspe);
                try
                {
                    lector2 = comando.ExecuteReader();
                    if (lector2.HasRows)
                    {
                        GridView1.DataSource = lector2;
                        GridView1.AutoGenerateSelectButton = true;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = "Buzón vacio";
                    }
                }catch (Exception ex)
                {
                    Label1.Text = "error: " + ex.ToString();
                }
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Add("cAnuncio", GridView1.Rows[GridView1.SelectedIndex].Cells[4].Text);
            Response.Redirect("Anuncio.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeProfesionista.aspx");
        }
    }
}