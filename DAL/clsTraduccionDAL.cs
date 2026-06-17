using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class clsTraduccionDAL
    {
        // Devuelve un diccionario Clave -> Texto para un idioma (por codigo: "es", "en")
        public Dictionary<string, string> GetDiccionarioPorCodigo(string codigo)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

                using (SqlConnection con = clsConexionDAL.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT t.Clave, t.Texto 
                  FROM Traduccion t 
                  JOIN Idioma i ON t.IdIdioma = i.IdIdioma 
                  WHERE i.Codigo = @Codigo", con);
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string clave = dr["Clave"].ToString();
                        if (!dic.ContainsKey(clave))
                            dic.Add(clave, dr["Texto"].ToString());
                    }
                }            
            return dic;
        }

        // Todas las traducciones de un idioma (por IdIdioma) para el ABM
        public List<clsTraduccionBE> GetByIdioma(int idIdioma)
        {
            List<clsTraduccionBE> lista = new List<clsTraduccionBE>();
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Traduccion WHERE IdIdioma = @IdIdioma ORDER BY Clave", con);
                cmd.Parameters.AddWithValue("@IdIdioma", idIdioma);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    lista.Add(Mapear(dr));
            }
            return lista;
        }

        // Todas las claves distintas que existen en el sistema
        public List<string> GetClaves()
        {
            List<string> claves = new List<string>();
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT DISTINCT Clave FROM Traduccion ORDER BY Clave", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    claves.Add(dr["Clave"].ToString());
            }
            return claves;
        }

        public bool Insert(clsTraduccionBE t)
        {
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Traduccion (IdIdioma, Clave, Texto) VALUES (@IdIdioma, @Clave, @Texto)", con, tran);
                    cmd.Parameters.AddWithValue("@IdIdioma", t.IdIdioma);
                    cmd.Parameters.AddWithValue("@Clave", t.Clave);
                    cmd.Parameters.AddWithValue("@Texto", t.Texto);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    return true;
                }
                catch { tran.Rollback(); return false; }
            }
        }

        public bool Update(clsTraduccionBE t)
        {
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Traduccion SET Texto = @Texto WHERE IdTraduccion = @IdTraduccion", con, tran);
                    cmd.Parameters.AddWithValue("@Texto", t.Texto);
                    cmd.Parameters.AddWithValue("@IdTraduccion", t.IdTraduccion);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    return true;
                }
                catch { tran.Rollback(); return false; }
            }
        }

        public bool Delete(int idTraduccion)
        {
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Traduccion WHERE IdTraduccion = @IdTraduccion", con, tran);
                    cmd.Parameters.AddWithValue("@IdTraduccion", idTraduccion);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    return true;
                }
                catch { tran.Rollback(); return false; }
            }
        }

        // Inserta una clave nueva para TODOS los idiomas (alta de tag)
        public bool InsertClaveEnTodosLosIdiomas(string clave, string textoDefault)
        {
            using (SqlConnection con = clsConexionDAL.GetConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Traduccion (IdIdioma, Clave, Texto)
                          SELECT IdIdioma, @Clave, @Texto FROM Idioma", con, tran);
                    cmd.Parameters.AddWithValue("@Clave", clave);
                    cmd.Parameters.AddWithValue("@Texto", textoDefault);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    return true;
                }
                catch { tran.Rollback(); return false; }
            }
        }

        private clsTraduccionBE Mapear(SqlDataReader dr)
        {
            return new clsTraduccionBE
            {
                IdTraduccion = (int)dr["IdTraduccion"],
                IdIdioma = (int)dr["IdIdioma"],
                Clave = dr["Clave"].ToString(),
                Texto = dr["Texto"].ToString()
            };
        }
    }
}