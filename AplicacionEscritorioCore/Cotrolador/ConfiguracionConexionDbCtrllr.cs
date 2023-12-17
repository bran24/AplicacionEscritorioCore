using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionEscritorioCore.Modelo;
using ORM;

namespace AplicacionEscritorioCore.Cotrolador
{
    public class ConfiguracionConexionDbCtrllr
    {
        private ConfiguracionConexionDbModel configDbData;
        public ConfiguracionConexionDbCtrllr()
        {
            
        }

        public bool verificarConexion(String host, String dbase, String user, String pass)
        {
            //Trace.WriteLine( Common.GetConexionDB() );
            configDbData = new ConfiguracionConexionDbModel(host, dbase, user, pass);
            return configDbData.verificarConexionDb();
        }

        public bool guardarConexion(String host, String dbase, String user, String pass)
        {
            configDbData = new ConfiguracionConexionDbModel(host, dbase, user, pass);
            configDbData.guardarConexionDb();
            return true;
        }



    }
}
