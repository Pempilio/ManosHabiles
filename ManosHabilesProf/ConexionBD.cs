using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using System.Drawing;

namespace ManosHabilesProf
{
    public class ConexionBD
    {
        public OdbcConnection con { get; set; }

        public ConexionBD() 
        {
            //Constructor
            //Paso 5. Delcarar un objeto de configuracion para
            //poder acceder al web.config
            System.Configuration.Configuration webConfig;

            //Paso 6. Ligar el objecto de configuracion al web.config
            //El web.config está en el directorio del proyecto
            //CafeDAI
            webConfig = System.Web.Configuration
                .WebConfigurationManager
                .OpenWebConfiguration("/ManosHabilesProf");

            //Paso 7. Declaramos el objeto string de conexion
            //para guardar la configuracion del web.config
            System.Configuration.ConnectionStringSettings stringDeConexion;

            //Paso 8. Extraer el string de conexion del objeto de
            //configuracion
            stringDeConexion = webConfig.ConnectionStrings
                .ConnectionStrings["BDManosHabiles"]; //el nombre viene en el
                                                 //web.config

            //Paso 9. Crear la conexion con el string de conexion
            con = new OdbcConnection(stringDeConexion.ToString());

            //Paso 10. Abrir la conexion
            con.Open();
        }
    }
}