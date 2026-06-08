using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsDigitoVerificadorDAL
    {
        public int GetDVV(string tabla)
        {
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT TOP 1 DVV FROM DigitoVerificador 
                  WHERE Tabla = @Tabla 
                  ORDER BY FechaCalculo DESC", con);
                cmd.Parameters.AddWithValue("@Tabla", tabla);
                object result = cmd.ExecuteScalar();
                return result == null ? 0 : Convert.ToInt32(result);
            }
        }

        public bool GuardarDVV(string tabla, int dvv)
        {
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO DigitoVerificador (Tabla, DVV, FechaCalculo)
                      VALUES (@Tabla, @DVV, GETDATE())", con, tran);
                    cmd.Parameters.AddWithValue("@Tabla", tabla);
                    cmd.Parameters.AddWithValue("@DVV", dvv);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }
    }
}
