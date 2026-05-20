using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;

namespace DAL
{
    public class clsUsuarioDAL
    {
        public bool Insert(clsUsuarioBE usuario)
        {
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    string sql = "INSERT INTO Usuario(NombreUsuario, PasswordHash) VALUES (@NombreUsuario,@PasswordHash)";
                    SqlCommand cmd = new SqlCommand(sql, con, tran);
                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@PasswordHash", usuario.PasswordHash);

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
        public clsUsuarioBE GetByUsername(string NombreUsuario)
        {
            clsUsuarioBE Usuario = null;    

            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario",con);
                    cmd.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Usuario = Mapear(dr);
                }
            }
            return Usuario;
        }
        private clsUsuarioBE Mapear(SqlDataReader dr)
        {
            return new clsUsuarioBE
            {
                IdUsuario = (int)dr["IdUsuario"],
                NombreUsuario = dr["NombreUsuario"].ToString(),
                PasswordHash = dr["PasswordHash"].ToString()
            };
        }
    }
}
