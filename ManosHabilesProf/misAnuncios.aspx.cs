using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ManosHabilesProf
{
    public partial class misAnuncios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cCliente"] == null || Session["nombre"] == null)
            {
                Response.Redirect("login.aspx");
            }
            CargarGridView();
        }
        
        protected void CargarGridView()
        {
            //String query = "select cAnuncio, Especialidad.nombre, concat(horaEntrada, '') as 'Hora entrada', concat(horaSalida, '') as 'Hora salida', fechaInicio, monto, descripcion " +
              //  " from Anuncio inner join Especialidad on Anuncio.cEspe = Especialidad.cEspe where cCliente =  ?";
            String query = "select cAnuncio, Especialidad.nombre, substring(concat(horaEntrada, ''), 0, 9) as 'Hora entrada', substring(concat(horaSalida, ''), 0, 9) as 'Hora salida', fechaInicio, monto, descripcion " +
                " from Anuncio inner join Especialidad on Anuncio.cEspe = Especialidad.cEspe where cCliente =  ?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("cCliente", Session["cCliente"].ToString());
            OdbcDataReader lector = comando.ExecuteReader();
            //Cargar los datos al gridview
            GridView1.DataSource = lector;
            GridView1.AutoGenerateSelectButton = true;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String query = "delete Anuncio where cAnuncio = ?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("cAnuncio", Session["cAnuncio"]);
            try
            {
                comando.ExecuteNonQuery();
                Label1.Text = "";
                Label2.Text = "";
                Response.Redirect("misAnuncios.aspx");
            }
            catch (Exception ex)
            {
                Label2.Text = "Error" + ex.ToString();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Add("cAnuncio", GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
            Label1.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[7].Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}
