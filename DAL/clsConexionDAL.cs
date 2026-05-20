using System.Data.SqlClient;

namespace DAL
{
    public class clsConexionDAL
    {
        private static string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TurnoSync;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
