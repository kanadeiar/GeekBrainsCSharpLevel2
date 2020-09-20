using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    /// <summary> Источник - соединение с базой данных </summary>
    public static class DataBaseSource
    {
        /// <summary> Соединение с базой данных </summary>
        public static SqlConnection Connection { get; set; }
        static DataBaseSource()
        {
            try
            {
                AppSettingsReader ar = new AppSettingsReader();
                var connBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = (string) ar.GetValue("DataBaseSource", typeof(string)),
                    InitialCatalog = (string) ar.GetValue("InitialCatalog", typeof(string)),
                    IntegratedSecurity = true,
                    Pooling = true,
                };
                string connectionString = connBuilder.ConnectionString;
                Connection = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ошибка открытия базы данных:\n" + ex.Message);
            }
        }
    }
}