using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler
{
    class SqlConfig
    {


        // SQL Server
        //static string Server_Name = "localhost";
        //static string User_ID = "zatcaprog";
        //static string User_Cred = "code@Zatca";
        ////static string Sys_DB = "ZATCAFORGOLD";
        //static string Sys_DB = "zatcadb";



        //public static SqlConnection ServerConn;
        ////public static string ConnectionString = "Server=SERVERTECH\\SQLEXPRESS;Initial Catalog=" + Sys_DB + "; Persist Security Info=True;User Id=" + User_ID + " ; Password=" + User_Cred + "";
        //public static string ConnectionString = $"Server=DESKTOP-6LI8L87\\SQLEXPRESS;Initial Catalog={Sys_DB}; Persist Security Info=True;User Id={User_ID};Password={User_Cred};Connect Timeout=30;Max Pool Size=5000";
        static string User_ID = "zatcaprog";
        static string User_Cred = "Zatca@code"; 
        static string Sys_DB = "Production_zatcadb1";



        public static SqlConnection ServerConn;
        // public static string ConnectionString = "Server=zatca-vm;Initial Catalog=" + Sys_DB + "; Persist Security Info=True;User Id=" + User_ID + ";Password=" + User_Cred + "";
        public static string ConnectionString = "Server=ESG\\SQLEXPRESS;Initial Catalog=" + Sys_DB + "; Persist Security Info=True;User Id=" + User_ID + ";Password=" + User_Cred + "";

        //ESG\SQLEXPRESS
        //SqlConfig Connection = new SqlConfig();
        //SqlConfig.ConnectToSqlServer(SqlConfig.ConnectionString);

        public static void ConnectToServer(string SQLConnect)
        {

            try
            {
                ServerConn = new SqlConnection(SQLConnect);
                ServerConn.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error connecting to SQL Server: {e.Message}");
               // MessageBox.Show($"Error connecting to SQL Server: {e.Message}");
            }
        }

        public void OpenConection(ref string ConString)
        {

            //ServerConn = new SqlConnection(ConString);
            ServerConn = new SqlConnection(ConString);
            ServerConn.Open();
        }


        public void CloseConnection()
        {
            ServerConn.Close();
        }

        /*
        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, ServerConn);
            cmd.ExecuteNonQuery();
        }


        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, ServerConn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        */

        public object ShowDataInGridView(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }

        //sql server
        public static object GetFieldValue(string connectionString, string tableName, int recordId, string fieldName)
        {
            try
            {
                // Create a new SqlConnection object using the provided connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a new SqlCommand object to retrieve the specified field from the specified record
                    SqlCommand command = new SqlCommand($"SELECT {fieldName} FROM {tableName} WHERE Id = @recordId", connection);

                    // Add the recordId parameter to the command
                    command.Parameters.AddWithValue("@recordId", recordId);

                    // Execute the command and retrieve the result
                    object result = command.ExecuteScalar();

                    // Return the result
                    return result;
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"An error occurred: {ex.Message}");

                // Return null to indicate an error occurred
                return null;
            }
        }
        //Mysql
        public static object Get_FieldValue(string connectionString, string tableName, int recordId, string fieldName)
        {
            try
            {
                // Create a new SqlConnection object using the provided connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a new SqlCommand object to retrieve the specified field from the specified record
                    SqlCommand command = new SqlCommand($"SELECT {fieldName} FROM {tableName} WHERE Id = @recordId", connection);

                    // Add the recordId parameter to the command
                    command.Parameters.AddWithValue("@recordId", recordId);

                    // Execute the command and retrieve the result
                    object result = command.ExecuteScalar();

                    // Return the result
                    return result;
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"An error occurred: {ex.Message}");

                // Return null to indicate an error occurred
                return null;
            }
        }

        static void InsertDataIntoTable()
        {
            // Define the connection string to the SQL Server database
            string connectionString = "Data Source=MyServer;Initial Catalog=MyDatabase;Integrated Security=True";

            // Define the SQL query to insert data into the table
            string query = "INSERT INTO MyTable (Column1, Column2, Column3) VALUES (@Value1, @Value2, @Value3)";

            try
            {
                // Create a new SqlConnection object using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a new SqlCommand object using the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the parameter values to the command
                        command.Parameters.AddWithValue("@Value1", "Data1");
                        command.Parameters.AddWithValue("@Value2", "Data2");
                        command.Parameters.AddWithValue("@Value3", "Data3");

                        // Execute the command
                        command.ExecuteNonQuery();

                        // Log the success
                        Console.WriteLine("Data inserted successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void UpdateDataInSqlServerTable(string connectionString, string tableName, string columnName, string columnValue, string idColumnName, int id)
        {
            /*
            This function updates data in a SQL Server table.

            Parameters:
            connectionString (string): The connection string to the SQL Server database
            tableName (string): The name of the table to update
            columnName (string): The name of the column to update
            columnValue (string): The new value for the column
            idColumnName (string): The name of the column containing the ID of the row to update
            id (int): The ID of the row to update

            Returns:
            None
            */

            try
            {
                // Create a new SqlConnection object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand object with the UPDATE statement
                    using (SqlCommand command = new SqlCommand($"UPDATE {tableName} SET {columnName} = @columnValue WHERE {idColumnName} = @id", connection))
                    {
                        // Add the parameters to the SqlCommand object
                        command.Parameters.AddWithValue("@columnValue", columnValue);
                        command.Parameters.AddWithValue("@id", id);

                        // Execute the command
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                // Log the error
                Console.WriteLine($"Error updating data in SQL Server table: {e.Message}");
            }
        }
        public void DeleteRecordFromTable()
        {
            // Connection string to the SQL Server database
            string connectionString = "Data Source=SERVER_NAME;Initial Catalog=DATABASE_NAME;User ID=USERNAME;Password=PASSWORD";

            // SQL query to delete data from a table
            string query = "DELETE FROM table_name WHERE condition";

            try
            {
                // Create a new SqlConnection object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a new SqlCommand object
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Log the number of rows affected
                        Console.WriteLine($"{rowsAffected} rows deleted.");
                    }
                }
            }
            catch (Exception e)
            {
                // Log the error
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        public void InsertRecord(string SQLData)
        {
            try
            {
                // Set up the connection string
                string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;";

                // Set up the SQL query
                string query = SQLData;

                // Create a new SqlConnection object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a new SqlCommand object
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                // Log the error
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        private static void CreateCommand(string queryString,
            string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
