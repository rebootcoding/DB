using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DataBase
    {

        private SqlConnectionStringBuilder connectionStringBuilder
        {
            get
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = "WINAPHS2OH2TH8K\\SQLEXPRESS";
                builder.InitialCatalog = "AcademyNet";
                builder.IntegratedSecurity = true;
                return builder;
            }
        }

        private SqlConnection GetConnection()
        {
                return new SqlConnection(connectionStringBuilder.ConnectionString);
        }

        public DataTable GetTables()
        {
            using (var conn = GetConnection())
            {
                var command = new SqlCommand();
                command.CommandText = "SELECT* " + "FROM INFORMATION_SCHEMA.TABLES t " + "WHERE t.TABLE_TYPE = 'Base Table'";
                command.Connection = conn;

                try
                {
                    conn.Open();
                    var reader = command.ExecuteReader();
                    var dt = new DataTable(); // oggetto che contiene dati, anche DataRow, e altri, il Framework mette a disposizione queste classi
                    dt.Load(reader); // al posto di utilizzare un while
                    reader.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public DataTable GetAllItems(string tableName)
        {
            using (var connection =  GetConnection())
            {
                var command = new SqlCommand();
                command.CommandText = $"SELECT * FROM {tableName}";
                command.Connection = connection;
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
