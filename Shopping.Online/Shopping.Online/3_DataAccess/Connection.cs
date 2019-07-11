using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Shopping.Online._3_DataAccess
{
    public class Connection
    {
        //public static string connectionString = "data source = (local); initial catalog = Personas; user id = sa; password = 123";
        //public static string connectionString = "Server=(local);Database=Personas;User Id=sa;Password=123";
        //public static string connectionString = "Data Source=(local); integrated security=true; initial catalog=Personas";

        public static string connectionString = @"Data Source=COL-GIANFRANCOD; Initial Catalog=ShoppingOnline;Integrated Security=True";
        public static SqlConnection connection;

        public Connection() { }

        //Funcion para abrir canal de conexión con la base de datos
        public static bool Connect()
        {
            bool connected = false;
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                connected = true;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                connected = false;
            }
            return connected;
        }

        //Utilizado para seleccionar elementos de la Base de Datos, retorna un DataSet, en las clase persistentes se pasa a List o DataTable
        public DataSet ExecuteWithResultSQL(string sqlQuery)
        {
            DataSet lResult = null;
            SqlCommand lSqlCommand = null;
            try
            {
                lSqlCommand = new SqlCommand();
                lSqlCommand.CommandText = sqlQuery;
                lSqlCommand.CommandType = CommandType.Text;

                SqlDataAdapter lAdapter = new SqlDataAdapter(lSqlCommand);
                lResult = new DataSet();

                Connect();
                lSqlCommand.Connection = connection;

                lAdapter.Fill(lResult);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if ((lSqlCommand != null))
                {
                    lSqlCommand.Dispose();
                    lSqlCommand = null;
                }
                if ((connection != null))
                {
                    connection.Close();
                    connection = null;
                }
            }
            return lResult;
        }

        //Utilizado para modificar la Base de Datos, ExecuteNonQuery() retorna la cantidad de filas afectadas, en este caso no lo capturamos
        public void ExecuteQuerySQL(string sqlQuery)
        {
            SqlCommand lSqlCommand = null;
            try
            {
                lSqlCommand = new SqlCommand();
                lSqlCommand.CommandText = sqlQuery;
                lSqlCommand.CommandType = CommandType.Text;

                Connect();
                lSqlCommand.Connection = connection;
                lSqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if ((lSqlCommand != null))
                {
                    lSqlCommand.Dispose();
                    lSqlCommand = null;
                }
                if ((connection != null))
                {
                    connection.Close();
                    connection = null;
                }
            }
        }

        public void ExecuteTransaction(string sqlQuery)
        {
            Connect();
            SqlTransaction ObjTran = connection.BeginTransaction();
            try
            {
                //Ejecucion de comandos
                //Se ejecuta el Commit de la transaccion
                ObjTran.Commit();
            }
            catch (Exception)
            {
                // La transacción ha fallado
                ObjTran.Rollback();
            }
            connection.Close();
        }
    }
}