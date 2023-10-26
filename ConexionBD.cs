using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Paso 1. String de conexion el webconfig - ya lo hicimos
//Paso 2. Importar la biblioteca de ODBC
using System.Data.Odbc;

namespace ManosHabiles
{
    public class ConexionBD
    {
        //Paso 3. Declarar el objeto conexion con sus
        //get y set
        public OdbcConnection con { get; set; }

        //Paso 4. Programar el constructor para abrir
        //la conexion con la informacion del web.config
        public ConexionBD()
        {
            //Constructor
            //Paso 5. Delcarar un objeto de configuracion para
            //poder acceder al web.config
            System.Configuration.Configuration webConfig;

            //Paso 6. Ligar el objecto de configuracion al web.config
            //El web.config está en el directorio del proyecto
          
            webConfig = System.Web.Configuration
                .WebConfigurationManager
                .OpenWebConfiguration("/ManosHabiles");

            //Paso 7. Declaramos el objeto string de conexion
            //para guardar la configuracion del web.config
            System.Configuration.ConnectionStringSettings stringDeConexion;

            //Paso 8. Extraer el string de conexion del objeto de
            //configuracion
            stringDeConexion = webConfig.ConnectionStrings
                .ConnectionStrings["ManosHabiles"]; //el nombre viene en el
                                                 //web.config

            //Paso 9. Crear la conexion con el string de conexion
            con = new OdbcConnection(stringDeConexion.ToString());

            //Paso 10. Abrir la conexion
            con.Open();
        }
    }
}