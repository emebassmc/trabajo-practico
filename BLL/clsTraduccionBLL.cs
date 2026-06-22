using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class clsTraduccionBLL
    {
        private clsTraduccionDAL dal = new clsTraduccionDAL();

        public List<clsTraduccionBE> GetByIdioma(int idIdioma)
        {
            return dal.GetByIdioma(idIdioma);
        }

        public List<string> GetClaves()
        {
            return dal.GetClaves();
        }

        public bool Insert(clsTraduccionBE t)
        {
            if (t.IdIdioma <= 0) return false;
            if (string.IsNullOrEmpty(t.Clave) || string.IsNullOrEmpty(t.Texto)) return false;
            return dal.Insert(t);
        }

        public bool Update(clsTraduccionBE t)
        {
            if (t.IdTraduccion <= 0) return false;
            if (string.IsNullOrEmpty(t.Texto)) return false;
            return dal.Update(t);
        }

        public bool Delete(int idTraduccion)
        {
            if (idTraduccion <= 0) return false;
            return dal.Delete(idTraduccion);
        }

        public bool InsertClaveEnTodosLosIdiomas(string clave, string textoDefault)
        {
            if (string.IsNullOrEmpty(clave) || string.IsNullOrEmpty(textoDefault)) return false;
            return dal.InsertClaveEnTodosLosIdiomas(clave, textoDefault);
        }
        public int EscanearYGenerarClaves(Dictionary<string, string> claves)
        {
            if (claves == null || claves.Count == 0) return 0;
            return dal.EscanearYGenerarClaves(claves);
        }
    }
}