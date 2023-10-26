using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManosHabiles
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        OdbcConnection conexion = new ConexionBD().con;
        protected void Page_Load(object sender, EventArgs e)
        {

            //revisar si si hay una session abiernta

              if (Session["nombreA"] == null || Session["claveA"] == null)
                 Response.Redirect("LoginAdmin.aspx");





            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.Items.Add(new ListItem("baneo", "-1"));
                DropDownList1.Items.Add(new ListItem("sí", "1"));
                DropDownList1.Items.Add(new ListItem("no", "0"));



                
                

               
            }
            if (DropDownList2.Items.Count == 0)
            {
                DropDownList2.Items.Add(new ListItem("Tipo de Usuario", "-1"));
                DropDownList2.Items.Add(new ListItem("Profesionista", "1"));
                DropDownList2.Items.Add(new ListItem("Cliente", "0"));


              

               
            }
            if (DropDownList3.Items.Count == 0)
            {

                String queryM = "select cMotivo,nombre from Motivo";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(queryM, conexion);
                OdbcDataReader lector = comando.ExecuteReader();

                DropDownList3.DataSource = lector;
                DropDownList3.DataValueField = "cMotivo";
                DropDownList3.DataTextField = "nombre";
                DropDownList3.DataBind();
                conexion.Close();
                lector.Close();

                DropDownList3.Items.Add(new ListItem("no importa", "0"));
                ListItem defaultItem = new ListItem("motivo", "-1"); // El valor "-1" podría indicar que no es una opción seleccionable real
                DropDownList3.Items.Insert(0, defaultItem);


            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ban")
            {
                
                //  int rowIndex = Convert.ToInt32(e.CommandArgument);  // Obtén el índice de la fila donde se hizo clic
                // Obtener el cCliente del cliente correspondiente a la fila seleccionada
                int rowIndex = Convert.ToInt32(e.CommandArgument);  // Obtén el índice de la fila donde se hizo clic
                int cCliente = Convert.ToInt32(GridView1.DataKeys[rowIndex].Value);  // Obtén la clave del usuario de la fila
              //  Label1.Text = cCliente.ToString();
                // Llamar al método para actualizar la base de datos
                ActualizarBaneo(cCliente, 1);
                // Aquí puedes agregar el código que quieras ejecutar cuando se haga clic en el botón "Banear"
                CargarDatos();
            }
        }

        private void ActualizarBaneo(int cCliente, int nuevoBaneo)
        {
            // Definir la cadena de conexión y la consulta SQL
            string query = "UPDATE Cliente SET baneo = ? WHERE cCliente = ?";


            OdbcCommand comando = new OdbcCommand(query, conexion);

            // Definir los parámetros del comando
            comando.Parameters.Add("nuevoBaneo", nuevoBaneo);
            comando.Parameters.Add("cCliente", cCliente);

            // Abrir la conexión
            

            // Ejecutar el comando
            comando.ExecuteNonQuery();

            // Cerrar la conexión
            conexion.Close();
        }

        private void CargarDatos()
        {
            String query = "SELECT DISTINCT Cliente.cCliente,Cliente.nombre ,Cliente.apellido, Cliente.codigoPost, Cliente.correo, Cliente.passwrd, Cliente.fechaNaci, Cliente.descripcion, Reporte.folio, Reporte.descripcion AS descripcionReporte, Motivo.nombre AS nombreMotivo, Cliente.baneo FROM Cliente JOIN genera ON Cliente.cCliente = genera.cCliente JOIN Reporte ON genera.folio = Reporte.folio JOIN Motivo ON Reporte.cMotivo = Motivo.cMotivo;";


            OdbcCommand comando = new OdbcCommand(query, conexion);

            // Abrir la conexión
            conexion.Open();

            OdbcDataReader lector = comando.ExecuteReader();
            GridView1.DataSource = lector;
            GridView1.DataBind();

            // Cerrar el lector y la conexión
            lector.Close();
            conexion.Close();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            if (DropDownList1.SelectedValue == "-1" || DropDownList2.SelectedValue == "-1" || DropDownList3.SelectedValue == "-1")
            {
                // Mostrar un error si alguna elección es "-1"
                // Puede ser una etiqueta de error o un mensaje emergente
                Label1.Text = "Por favor, seleccione opciones válidas.";
                return;
            }

            if (DropDownList2.SelectedValue == "0")
            {

                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("SELECT DISTINCT Cliente.cCliente, Cliente.nombre, Cliente.apellido, Cliente.codigoPost, Cliente.correo, Cliente.fechaNaci, Cliente.descripcion, Reporte.folio, Reporte.descripcion AS descripcionReporte, Motivo.nombre AS nombreMotivo, Sexo.nombre AS NombreSexo, Cliente.baneo FROM Cliente JOIN genera ON Cliente.cCliente = genera.cCliente JOIN Reporte ON genera.folio = Reporte.folio JOIN Motivo ON Reporte.cMotivo = Motivo.cMotivo JOIN Sexo ON Cliente.cSexo = Sexo.cSexo WHERE Cliente.baneo = ?");
                OdbcCommand comando = new OdbcCommand();
                comando.Connection = conexion;

                int valorBaneo = Convert.ToInt32(DropDownList1.SelectedValue);
                comando.Parameters.AddWithValue("paramBaneo", valorBaneo);

                // Si ambas TextBox tienen un valor, se filtra por fecha del reporte
                if (!string.IsNullOrWhiteSpace(TextBox1.Text) && !string.IsNullOrWhiteSpace(TextBox2.Text))
                {
                    queryBuilder.Append(" AND CAST(Reporte.fecha AS DATE) BETWEEN ? AND ?");
                    DateTime fechaInicio = DateTime.Parse(TextBox1.Text).Date;
                    DateTime fechaFin = DateTime.Parse(TextBox2.Text).Date;
                    comando.Parameters.AddWithValue("fechaInicio", fechaInicio);
                    comando.Parameters.AddWithValue("fechaFin", fechaFin);
                }

                // Si el DropDownList3 tiene un valor diferente de 0, se filtra por motivo
                if (DropDownList3.SelectedValue != "0")
                {
                    queryBuilder.Append(" AND Reporte.cMotivo = ?");
                    comando.Parameters.AddWithValue("paramMotivo", DropDownList3.SelectedValue);
                }

                comando.CommandText = queryBuilder.ToString();


                OdbcDataReader lector = comando.ExecuteReader();
                GridView1.DataSource = lector;
                GridView1.DataBind();

                // Cerrar el lector y la conexión
                lector.Close();
                conexion.Close();

            }
            else
            {
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("SELECT DISTINCT Profesionista.cProf, Profesionista.nombre, Profesionista.apellido, Profesionista.codigoPost, Profesionista.correo, Profesionista.fechaNaci, Profesionista.anosExp, Profesionista.descripcion, Profesionista.estatus, Sexo.nombre AS NombreSexo , Reporte.folio, Reporte.descripcion AS descripcionReporte, Motivo.nombre AS nombreMotivo FROM Profesionista JOIN genera ON Profesionista.cProf = genera.cProf JOIN Reporte ON genera.folio = Reporte.folio JOIN Motivo ON Reporte.cMotivo = Motivo.cMotivo JOIN Sexo ON Profesionista.cSexo = Sexo.cSexo  WHERE Profesionista.estatus = ?");

                OdbcCommand comando = new OdbcCommand();
                comando.Connection = conexion;

                int valorBaneo = Convert.ToInt32(DropDownList1.SelectedValue);
                comando.Parameters.AddWithValue("paramBaneo", valorBaneo);

                // Si ambas TextBox tienen un valor, se filtra por fecha del reporte
                if (!string.IsNullOrWhiteSpace(TextBox1.Text) && !string.IsNullOrWhiteSpace(TextBox2.Text))
                {
                    queryBuilder.Append(" AND CAST(Reporte.fecha AS DATE) BETWEEN ? AND ?");
                    DateTime fechaInicio = DateTime.Parse(TextBox1.Text).Date;
                    DateTime fechaFin = DateTime.Parse(TextBox2.Text).Date;
                    comando.Parameters.AddWithValue("fechaInicio", fechaInicio);
                    comando.Parameters.AddWithValue("fechaFin", fechaFin);
                }

                // Si el DropDownList3 tiene un valor diferente de 0, se filtra por motivo
                if (DropDownList3.SelectedValue != "0")
                {
                    queryBuilder.Append(" AND Reporte.cMotivo = ?");
                    comando.Parameters.AddWithValue("paramMotivo", DropDownList3.SelectedValue);
                }

                comando.CommandText = queryBuilder.ToString();


                OdbcDataReader lector = comando.ExecuteReader();
                GridView1.DataSource = lector;
                GridView1.DataBind();

                // Cerrar el lector y la conexión
                lector.Close();
                conexion.Close();

            } 

        }
    }
}
