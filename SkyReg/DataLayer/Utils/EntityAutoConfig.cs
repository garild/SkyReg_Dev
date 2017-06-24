using System;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;

namespace DataLayer.Utils
{
    public sealed class EntityConnectionString
    {
        public static void Configuration(string connectionString)
        {
            try
            {
                var entityCnxStringBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["DLModelContainer"].ConnectionString);

                entityCnxStringBuilder.ProviderConnectionString = connectionString;

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var connection = config.ConnectionStrings.ConnectionStrings["EFConnectinString"];
                if (connection == null)
                {
                    //Create connection string if it doesn't exist
                    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings
                    {
                        Name = "SkyRegConnection",
                        ConnectionString = entityCnxStringBuilder.ConnectionString,
                        ProviderName = "System.Data.SqlClient"
                    });
                }
                else
                {

                    connection.ConnectionString = entityCnxStringBuilder.ConnectionString;
                }

                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception)
            {
                //TODO: Handle exception
            }
        }

      
      
    }
}
