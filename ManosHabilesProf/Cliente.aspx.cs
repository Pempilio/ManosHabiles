using ManosHabilesProf;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManosHabilesProf
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cCliente"] == null || Session["nombre"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (DropDownList1.Items.Count == 0)
            {
                String query = "select cEspe,nombre from Especialidad";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                OdbcDataReader lector = comando.ExecuteReader();
                DropDownList1.DataSource = lector;
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataValueField = "cEspe";
                DropDownList1.DataBind();
                conexion.Close();
            }
            if (DropDownList3.Items.Count == 0)
            {
                String query = "select cEdad,Rango from Edades";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                OdbcDataReader lector = comando.ExecuteReader();
                DropDownList3.DataSource = lector;
                DropDownList3.DataTextField = "Rango";
                DropDownList3.DataValueField = "cEdad";
                DropDownList3.DataBind();
                conexion.Close();
            }

            CargarGridView();
        }

        protected void CargarGridView()
        {
            String query = "select Profesionista.nombre as Nombre, Profesionista.apellido as Apellido, " +
                " Profesionista.correo as Correo, Sexo.nombre as 'Sexo', Profesionista.anosExp as 'Años de experiencia', " +
                " datediff(year, Profesionista.fechaNaci, getdate()) as 'Edad', Especialidad.nombre as 'Especialidad' " +
                " from Profesionista inner join Sexo on Profesionista.cSexo = Sexo.cSexo " +
                " inner join Especialidad on Profesionista.cEspe = Especialidad.cEspe " +
                " where Profesionista.estatus = 0 order by Especialidad.nombre desc";

            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            OdbcDataReader lector = comando.ExecuteReader();

            //Cargar los datos al gridview
            GridView1.DataSource = lector;
            GridView1.AutoGenerateSelectButton = true;
            GridView1.DataBind();
        }

        protected void btn1(object sender, EventArgs e)
        {
            Response.Redirect("nuevoAnuncio.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Obtén los valores seleccionados de los DropDownList
            string especialidad = DropDownList1.SelectedValue;
            string sexo = DropDownList2.SelectedValue;
            String edad = DropDownList3.SelectedValue;

            string query = "SELECT Profesionista.nombre as Nombre, Profesionista.apellido as Apellido, " +
                "Profesionista.correo as Correo, Sexo.nombre as 'Sexo', " +
                "Profesionista.anosExp as 'Años de experiencia', DATEDIFF(year, Profesionista.fechaNaci, GETDATE()) as 'Edad', " +
                "Especialidad.nombre as 'Especialidad' " +
                "FROM Profesionista " +
                "INNER JOIN Sexo ON Profesionista.cSexo = Sexo.cSexo " +
                "INNER JOIN Especialidad ON Profesionista.cEspe = Especialidad.cEspe " +
                "WHERE Profesionista.estatus = 0";

            if (!string.IsNullOrEmpty(especialidad))
            {
                query += " AND Profesionista.cEspe = " + especialidad;
            }

            if (!string.IsNullOrEmpty(sexo) && sexo != "0")
            {
                query += " AND Profesionista.sexo = " + sexo;


            }

            if (!string.IsNullOrEmpty(edad))
            {
                String resp = "";
                switch (Int32.Parse(edad))
                {
                    case 18:
                        resp = " AND Edad between 18 and 22";
                        break;
                    case 23:
                        resp = " AND Edad between 23 and 27";
                        break;
                    case 28:
                        resp = " AND Edad between 28 and 32";
                        break;
                    case 33:
                        resp = " AND Edad between 33 and 37";
                        break;
                    case 38:
                        resp = " AND Edad between 38 and 42";
                        break;
                    case 43:
                        resp = " AND Edad between 43 and 47";
                        break;
                    case 48:
                        resp = " AND Edad between 48 and 52";
                        break;
                    case 53:
                        resp = " AND Edad between 53 and 57";
                        break;
                    case 58:
                        resp = " AND Edad between 58 and 62";
                        break;
                    case 63:
                        resp = " AND Edad between 63 and 65";
                        break;
                }
                query += resp;
            }


            query += " ORDER BY Especialidad.nombre DESC";

            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            OdbcDataReader lector = comando.ExecuteReader();


            GridView1.DataSource = lector;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("misAnuncios.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}