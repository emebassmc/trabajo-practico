using BE;
using DAL;
using System.Net;

namespace BLL
{
    public class clsEspecialidadBLL
    {

        public bool Insert(clsEspecialidadBE especialidad)
        {
            try
            {
                if (string.IsNullOrEmpty(especialidad.Nombre)) return false;
                clsEspecialidadDAL dal = new clsEspecialidadDAL();
                return dal.Insert(especialidad);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }
        public bool Update(clsEspecialidadBE especialidad)
        {
            try
            {
                if ((especialidad.IdEspecialidad <= 0)) return false;
                if (string.IsNullOrEmpty(especialidad.Nombre)) return false;

                clsEspecialidadDAL dal = new clsEspecialidadDAL();                
                return dal.Update(especialidad);
                
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }

            
        }
        public bool Delete(int id)
        {
            try
            {
                if ((id <= 0)) return false;

                clsEspecialidadDAL dal = new clsEspecialidadDAL();

                return dal.Delete(id);

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }

        public List<clsEspecialidadBE> GetAll()
        {
            try
            {
                clsEspecialidadDAL dal = new clsEspecialidadDAL();
                return dal.GetAll();
            }
            catch (Exception ex)
            {

                string v = ex.ToString();
                return null;
            }
        }
        public clsEspecialidadBE GetById(int id) 
        {
            try
            {
                if (id <= 0) return null;
                clsEspecialidadDAL dal = new clsEspecialidadDAL();
                return dal.GetByID(id);
            }
            catch (Exception ex)
            {
                string v = ex.ToString();
                return null;
            }
        }

    }
}
