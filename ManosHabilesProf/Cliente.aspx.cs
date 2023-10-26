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
            String query = "select Profesionista.nombre as Nombre,Profesionista.apellido as Apellido, Profesionista.correo as Correo, " +
                " Sexo.nombre as 'Sexo', Profesionista.anosExp as 'Años de experiencia', datediff(year, Profesionista.fechaNaci, " +
                " getdate()) as 'Edad', Especialidad.nombre as 'Especialidad' from Profesionista inner join Sexo on Profesionista.cSexo = Sexo.cSexo " +
                " inner join Especialidad on Profesionista.cEspe = Especialidad.cEspe " +
                " where Profesionista.estatus = 1 order by Especialidad.nombre desc ";

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

            string query = "SELECT Profesionista.nombre as Nombre, Profesionista.apellido as Apellido, " +
                "Profesionista.correo as Correo, Sexo.nombre as 'Sexo', " +
                "Profesionista.anosExp as 'Años de experiencia', DATEDIFF(year, Profesionista.fechaNaci, GETDATE()) as 'Edad', " +
                "Especialidad.nombre as 'Especialidad' " +
                "FROM Profesionista " +
                "INNER JOIN Sexo ON Profesionista.sexo = Sexo.sexo " +
                "INNER JOIN Especialidad ON Profesionista.cEspe = Especialidad.cEspe " +
                "WHERE Profesionista.estatus = 1";

            if (!string.IsNullOrEmpty(especialidad))
            {
                query += " AND Profesionista.cEspe = " + especialidad;
            }

            if (!string.IsNullOrEmpty(sexo) && sexo != "0")
            {
                query += " AND Profesionista.sexo = " + sexo;
            }

            query += " ORDER BY Especialidad.nombre DESC";


            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            OdbcDataReader lector = comando.ExecuteReader();


            GridView1.DataSource = lector;
            GridView1.DataBind();
        }
    }
}