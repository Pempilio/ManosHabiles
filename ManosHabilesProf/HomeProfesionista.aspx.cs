using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace ManosHabilesProf
{
    public partial class HomeProfesionista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cProf"] == null || Session["nombre"] == null)
            {
                Response.Redirect("login.aspx");
            }
            Label1.Text = "Bienvenid@ " + Session["nombre"].ToString() + '\n' + "¿A quién vamos a ayudar hoy?";

            if(CheckBoxList1.Items.Count == 0)
            {
                CheckBoxList1.Items.Add(new ListItem("Cerca de mi")); //darle la Session[codigoPostal]
            }

            if (DropDownList1.Items.Count == 0)
            {
                String query = "select cSexo,nombre from Sexo";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                OdbcDataReader lector = comando.ExecuteReader();

                DropDownList1.DataSource = lector;
                DropDownList1.DataValueField = "cSexo";
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("(No importa)", "-1"));

                lector.Close();
            }

            cargarGrindView();

        }

        protected void cargarGrindView()
        {
            //cEsp -> cliente
            //cProf -> Session[cProf]
            String queryEspe = "select cEspe from Profesionista where cProf=?";
            int claveEspe;

            String query = "select Cliente.cCliente as 'Num',Cliente.nombre as 'Nombre',Anuncio.descripcion as 'Descripción', " +
                " Cliente.codigoPost as 'CP',Anuncio.monto as 'Sueldo',Sexo.nombre as 'Sexo' from Anuncio " +
                " inner join Cliente on Cliente.cCliente=Anuncio.cCliente" +
                " inner join Sexo on Cliente.cSexo=Sexo.cSexo " +
                " where Anuncio.cEspe=? and Cliente.estatus <> 1 order by Anuncio.monto desc";

            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(queryEspe, conexion);
            comando.Parameters.AddWithValue("cProf", Session["cProf"]);
            OdbcDataReader lector = comando.ExecuteReader();
            OdbcDataReader lector2;

            if (lector.HasRows)
            {
                lector.Read();
                claveEspe = lector.GetInt32(0);
                lector.Close();
                comando = new OdbcCommand(query, conexion);
                comando.Parameters.AddWithValue("cEspe", claveEspe);
                lector2 = comando.ExecuteReader();

                if (lector2.HasRows)
                {
                    GridView1.DataSource = lector2;
                    GridView1.AutoGenerateSelectButton = true;
                    GridView1.DataBind();
                    lector2.Close();
                }
                else
                {
                    Label2.Text = "Todavía no hay anuncios de tu especialidad";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String select = "select Cliente.cCliente as 'Num',Cliente.nombre as 'Nombre',Anuncio.descripcion as 'Descripción',Cliente.codigoPost as 'CP', " +
                " Anuncio.monto as 'Sueldo',Sexo.nombre as 'Sexo' from Anuncio inner join Cliente on Cliente.cCliente=Anuncio.cCliente " +
                " inner join Sexo on Cliente.cSexo=Sexo.cSexo ";
            String where = " where Anuncio.cEspe=? ";
            String ordena = " order by Anuncio.monto desc";
            String query = "";

            //cEsp -> cliente
            //cProf -> Session[cProf]
            String queryEspe = "select cEspe from Profesionista where cProf=?";
            int claveEspe;

            OdbcConnection conexion = new ConexionBD().con;

            if (CheckBoxList1.Items[0].Selected == true)
            {
                where += " and Cliente.codigoPost=? "; //hay que darle el codigo Session[codigoPostal]
            }

            if (DropDownList1.SelectedValue != "-1")
            {
                where += " and Sexo.cSexo = ? "; //DropDownList1 valor
            }

            query = select + where + ordena;
            OdbcCommand comando = new OdbcCommand(queryEspe, conexion);
            comando.Parameters.AddWithValue("cProf", Session["cProf"]);
            OdbcDataReader lector = comando.ExecuteReader();
            OdbcDataReader lector2;

            if (lector.HasRows)
            {
                lector.Read();
                claveEspe = lector.GetInt32(0);
                lector.Close();
                comando = new OdbcCommand(query, conexion);
                comando.Parameters.AddWithValue("cEspe", claveEspe);

                //Damos parametros
                if (CheckBoxList1.Items[0].Selected == true)
                {
                    comando.Parameters.AddWithValue("codigoPost", Session["codigoPostal"]);
                }
                if(DropDownList1.SelectedValue != "-1")
                {
                    comando.Parameters.AddWithValue("cSexo", DropDownList1.SelectedValue);
                }

                try
                {
                    lector2 = comando.ExecuteReader();
                    if (lector2.HasRows)
                    {
                        GridView1.DataSource = lector2;
                        GridView1.AutoGenerateSelectButton = true;
                        GridView1.DataBind();
                        Label2.Text = "";
                    }
                    else
                    {
                        Label2.Text = "No hay anuncios con tus filtros o de tu profesión";
                    }
                    lector2.Close();
                }catch (Exception ex)
                {
                    Label2.Text = "error: " + ex.ToString();
                }

            }
            conexion.Close();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Add("cAnuncio", GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
            Response.Redirect("Anuncio.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Buzon.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}