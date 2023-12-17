using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using AplicacionEscritorioCore.Helpers;

namespace AplicacionEscritorioCore.Modelo
{
    public class ConfiguracionConexionDbModel
    {

        public string host { get; set; }
        public string dbase { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
     

        public ConfiguracionConexionDbModel(string host, string dbase, string usuario, string password)
        {
            this.host = host;

            this.dbase = dbase;
            this.usuario = usuario;
            this.password = password;
            
        }

        public ConfiguracionConexionDbModel()
        {
            
        }


        public bool verificarConexionDbDefecto()
        {
           
            using (var db = new OrmContext())
            {
                bool con = db.Database.CanConnect();
                return con;



            }

        }

        public bool verificarConexionDb()
        {
            String connection = OrmContext.connection;

            OrmContext.connection = $"Server={host};Database={dbase};User Id={usuario};Password={password};";

            using(var db = new OrmContext())
            {
                bool con = db.Database.CanConnect();
                OrmContext.connection = connection;
                return con;



            }

        }

        public bool guardarConexionDb()
        {
            if (!this.verificarConexionDb()) return false;
            Cammon.SetConexionDB(host, dbase, usuario, password);
            OrmContext.connection = $"Server={host};Database={dbase};User Id={usuario};Password={password};";
            return true;
        }








    }
}
