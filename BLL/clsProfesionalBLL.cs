using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsProfesionalBLL
    {
        public bool Insert(clsProfesionalBE profesional)
        {
            try
            {
                if (string.IsNullOrEmpty(profesional.Matricula)) return false;
                if (profesional.IdEspecialidad <= 0) return false;
                if (string.IsNullOrEmpty(profesional.Nombre)) return false;
                if (string.IsNullOrEmpty(profesional.Apellido)) return false;
                if (string.IsNullOrEmpty(profesional.DNI)) return false;
                if (profesional.DNI.Length != 8) return false;

                clsProfesionalDAL dal = new clsProfesionalDAL();
                bool resultado = dal.Insert(profesional);

                clsBitacoraBE b = new clsBitacoraBE();
                b.UsuarioId = clsSesionActual.GetInstancia().IdUsuario;
                b.Actividad = "Insert Profesional";
                b.Informacion = resultado ? "OK - Id: " + profesional.IdPersona : "ERROR";
                clsBitacoraBLL.Registrar(b);
                return resultado;
            }
            catch (Exception ex)
            {
                string v = ex.ToString();
                return false;
            }
        }
        public bool Update(clsProfesionalBE profesional)
        {
            try
            {
                if (profesional.IdPersona <= 0) return false;
                if (string.IsNullOrEmpty(profesional.Matricula)) return false;
                if (profesional.IdEspecialidad <= 0) return false;
                if (string.IsNullOrEmpty(profesional.Nombre)) return false;
                if (string.IsNullOrEmpty(profesional.Apellido)) return false;
                if (string.IsNullOrEmpty(profesional.DNI)) return false;
                if (profesional.DNI.Length != 8) return false;

                clsProfesionalDAL dal = new clsProfesionalDAL();
                clsProfesionalBE anterior = dal.GetByID(profesional.IdPersona);

                bool resultado = dal.Update(profesional);

                clsBitacoraBE b = new clsBitacoraBE();
                b.UsuarioId = clsSesionActual.GetInstancia().IdUsuario;
                b.Actividad = "Update Profesional";
                b.Informacion = resultado ?
           "OK - ANTES: ID:" + anterior.IdPersona + " " + anterior.Nombre + " " + anterior.Apellido + " DNI:" + anterior.DNI + " Mat:" + anterior.Matricula +
           " | DESPUÉS: ID:" + profesional.IdPersona + " " + profesional.Nombre + " " + profesional.Apellido + " DNI:" + profesional.DNI + " Mat:" + profesional.Matricula
           : "ERROR";
                clsBitacoraBLL.Registrar(b);
                return resultado;
            }
            catch (Exception ex)
            {

                string v = ex.ToString();
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {

                if (id <= 0) return false;
                clsProfesionalDAL dal = new clsProfesionalDAL();
                bool resultado = dal.Delete(id);

                clsBitacoraBE b = new clsBitacoraBE();
                b.UsuarioId = clsSesionActual.GetInstancia().IdUsuario;
                b.Actividad = "Delete Profesional";
                b.Informacion = resultado ? "OK - Id: " + id: "ERROR";
                clsBitacoraBLL.Registrar(b);
                return resultado;
            }
            catch (Exception ex)
            {
                string v = ex.ToString();
                return false;
            }
        }
        #region METODOS DE LECTURA
        public clsProfesionalBE GetById(int id)
        {
            try
            {
                if (id <= 0) return null;
                clsProfesionalDAL dal = new clsProfesionalDAL();
                return dal.GetByID(id);
            }
            catch (Exception ex)
            {
                string v = ex.ToString();
                return null;
            }
        }
        public List<clsProfesionalBE> GetAll()
        {
            try
            {
                clsProfesionalDAL dal = new clsProfesionalDAL();
                return dal.GetAll();
            }
            catch (Exception ex)
            {

                string v = ex.ToString();
                return null;
            }
        }
        public clsProfesionalBE GetByDni(string dni)
        {
            try
            {
                if (string.IsNullOrEmpty(dni)) return null;
                clsProfesionalDAL dal = new clsProfesionalDAL();
                return dal.GetByDNI(dni);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                return null;
            }
        }
        #endregion
    }
}