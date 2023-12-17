using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace AplicacionEscritorioCore.Helpers
{
    public static class Cammon
    {

        public static String GetConexionDB()
        {
            System.Configuration.ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = @"Recursos\App.config";
            Configuration configFile = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var settings = configFile.ConnectionStrings.ConnectionStrings;
            string configuracion = "";
            configuracion = settings["DbConnectionBodega"].ConnectionString;
            return configuracion;

        }

        public static void SetConexionDB(string host, String dbase, String user, String pass)
        {
            System.Configuration.ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = @"Resources\App.config";
            Configuration configFile = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var settings = configFile.ConnectionStrings.ConnectionStrings;
      
            settings["DbConnectionBodega"].ConnectionString = $"Server={host};Database={dbase};User Id={user};Password={pass};";
                    Console.WriteLine($"\tActualizando entorno de base de datos: Produccion ");
        
            configFile.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
            ConnectionStringsSection section = configFile.GetSection("connectionStrings") as ConnectionStringsSection;
            section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            configFile.Save();
            OrmContext.connection = settings["sgtConnectionPrueba"].ConnectionString;
        }




    }
}
