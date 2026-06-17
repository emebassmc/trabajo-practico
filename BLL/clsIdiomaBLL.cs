using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class clsIdiomaBLL
    {
        private clsIdiomaDAL dal = new clsIdiomaDAL();

        public List<clsIdiomaBE> GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(clsIdiomaBE idioma)
        {
            if (string.IsNullOrEmpty(idioma.Codigo) || string.IsNullOrEmpty(idioma.Nombre))
                return false;
            return dal.Insert(idioma);
        }

        public bool Delete(int idIdioma)
        {
            if (idIdioma <= 0) return false;
            return dal.Delete(idIdioma);
        }
    }
}