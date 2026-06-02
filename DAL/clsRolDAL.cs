using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsRolDAL
    {
        public bool Insert(clsRolBE rol)
        {
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    string sql = @"INSERT INTO Rol(Nombre, IdRolPadre)
                    VALUES
                    (@Nombre, @IdRolPadre)
                    ";
                    SqlCommand cmd = new SqlCommand(sql,con,tran);
                    cmd.Parameters.AddWithValue("@Nombre", rol.Nombre);
                    cmd.Parameters.AddWithValue("@IdRolPadre",
                        rol.IdRolPadre.HasValue ? (object)rol.IdRolPadre.Value : DBNull.Value);
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
        public bool Delete(int id)
        {
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(@"DELETE FROM Rol WHERE IdRol = @IdRol", con, tran);
                    cmd.Parameters.AddWithValue("@IdRol", id);
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
        public List<clsRolBE> GetAll()
        {
            List<clsRolBE> listaRoles = new List<clsRolBE>();
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Rol", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaRoles.Add(Mapear(dr));
                }
                return listaRoles;
            }
        }
        private clsRolBE Mapear(SqlDataReader dr)
        {
            return new clsRolBE
            {
                IdRol = (int)dr["IdRol"],
                Nombre = dr["Nombre"].ToString(),
                IdRolPadre = dr["IdRolPadre"] == DBNull.Value
                     ? (int?)null
                     : (int)dr["IdRolPadre"]
            };
        }
    }
}
