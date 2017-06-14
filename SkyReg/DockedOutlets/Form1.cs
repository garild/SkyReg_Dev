using ComponentFactory.Krypton.Toolkit;
using DataLayer;
using DataLayer.Result.Repository;
using DataLayer.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DockedOutlets
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            SkyRegUser.GlobalPathFile = Environment.GetFolderPath((Environment.SpecialFolder.LocalApplicationData)) + @"\SkyReg";
            SkyRegUser.DatabaseConfigFile = string.Format("{0}\\DatabaseConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.UserConfigFile = string.Format("{0}\\UserConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.LocalMachineName = Environment.MachineName;
            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            SkyRegUser.AppVer = $"wersja {curVersion}";

            InitializeComponent();
            LoadSettings();
            //Get the original connection string with the full payload  
            //var entityCnxStringBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["DLModelContainer"].ConnectionString);

            ////Swap out the provider specific connection string  
            //entityCnxStringBuilder.ProviderConnectionString = DatabaseConfig.ConnectionString;
            //ConfigurationManager.ConnectionStrings.Add(new ConnectionStringSettings() { ConnectionString = entityCnxStringBuilder.ConnectionString});
            ////Return the payload with the change in connection string.   
            CreateConnectionString(DatabaseConfig.ConnectionString);
            TEST();
        }

        public void CreateConnectionString(string ConnectionString)
        {
            try
            {
                //Integrated security will be off if either UserID or Password is supplied
               
                //Create the connection string using the connection builder
                
                var entityCnxStringBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["DLModelContainer"].ConnectionString);

                //Swap out the provider specific connection string  
                entityCnxStringBuilder.ProviderConnectionString = ConnectionString;
                //Open the app.config for modification
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //Retreive connection string setting
                var connectionString = config.ConnectionStrings.ConnectionStrings["ConnectionStringName"];
                if (connectionString == null)
                {
                    //Create connection string if it doesn't exist
                    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings
                    {
                        Name = "DLModel",
                        ConnectionString = entityCnxStringBuilder.ConnectionString,
                        ProviderName = "System.Data.SqlClient" //Depends on the provider, this is for SQL Server
                    });
                }
                else
                {
                    //Only modify the connection string if it does exist
                    connectionString.ConnectionString = entityCnxStringBuilder.ConnectionString;
                }

                //Save changes in the app.config
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception)
            {
                //TODO: Handle exception
            }
        }

        private void TEST()
        {
            using (DLModelRepository<Flight> _contextOperator = new DLModelRepository<Flight>())
            {
                var flishts = _contextOperator.GetAll();
            }
        }

        private void LoadSettings()
        {
            if (File.Exists(SkyRegUser.DatabaseConfigFile))
            {
                using (TextReader tr = new StreamReader(SkyRegUser.DatabaseConfigFile))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(SkyRegUser.DatabaseConfigFile);
                    XmlSerializer deserializer;

                    //odczyt ustawień z nowej wersji pliku
                    var ConfigSettings = new DatabaseAccess();
                    deserializer = new XmlSerializer(ConfigSettings.GetType());
                    ConfigSettings = ((DatabaseAccess)deserializer.Deserialize(tr));
                    tr.Close();
                    ConfigSettings.Password = ConfigSettings.Password.DecryptString();
                    ConfigSettings.User = ConfigSettings.User.DecryptString();
                    new DatabaseConfig(ConfigSettings);
                    SkyRegUser.IsDbExists = true;
                }

            }
        }
    }
}
