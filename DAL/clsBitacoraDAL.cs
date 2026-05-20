using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;

namespace DAL
{
    /*
    Insert(int usuarioId, string actividad, string informacion): bool
    GetAll(): List<clsBitacoraBE>
    */
    public class clsBitacoraDAL
    {
        public bool Insert(clsBitacoraBE bitacora)
        {
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    string sql = @"INSERT INTO Bitacora 
                                   (UsuarioId,Actividad,Informacion)
                                   VALUES 
                                   (@UsuarioID,@Actividad,@Informacion)";

                    SqlCommand cmd = new SqlCommand(sql, con, tran);
                    cmd.Parameters.AddWithValue("@UsuarioId", bitacora.UsuarioId);
                    cmd.Parameters.AddWithValue("@Actividad", bitacora.Actividad);
                    cmd.Parameters.AddWithValue("@Informacion", bitacora.Informacion);
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
        public List<clsBitacoraBE> GetAll()
        {
            List<clsBitacoraBE> lista = new List<clsBitacoraBE>();
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Bitacora", con);
                SqlDataReader dr = cmd.ExecuteReader(); // ← falta esto
                while (dr.Read())
                {
                    lista.Add(Mapear(dr));
                }
            }
            return lista;
        }


        #region Mapper
        private clsBitacoraBE Mapear(SqlDataReader dr)
        {
            return new clsBitacoraBE
            {
                Id = (int)dr["Id"],
                Fecha = (DateTime)dr["Fecha"],
                UsuarioId = dr["UsuarioId"] == DBNull.Value ? 0 : (int)dr["UsuarioId"],
                Actividad = dr["Actividad"].ToString(),
                Informacion = dr["Informacion"] == DBNull.Value ? "" : dr["Informacion"].ToString()
            };
        }
        #endregion
    }
}
