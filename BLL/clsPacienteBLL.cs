using BE;
using DAL;
using System.Diagnostics.CodeAnalysis;

namespace BLL
{
    public class clsPacienteBLL
    {
        public bool Insert(clsPacienteBE paciente)
        {
            try
            {
                if (string.IsNullOrEmpty(paciente.Nombre)) return false;
                if (string.IsNullOrEmpty(paciente.Apellido)) return false;
                if (string.IsNullOrEmpty(paciente.DNI)) return false;
                if (paciente.DNI.Length != 8) return false;

                clsPacienteDAL dal = new clsPacienteDAL();
                bool resultado = dal.Insert(paciente);

                clsBitacoraBE b = new clsBitacoraBE();
                b.UsuarioId = clsSesionActual.GetInstancia().IdUsuario;
                b.Actividad = "Insert Paciente";
                b.Informacion = resultado ? "OK - DNI: " + paciente.DNI : "ERROR";
                clsBitacoraBLL.Registrar(b);

                return resultado;
            }
            catch (Exception ex)
            {
                string v = ex.ToString();
                return false;
            }
        }
        public bool Update(clsPacienteBE pacienteUpdate)
        {
            try
            {
                if (pacienteUpdate.IdPersona <= 0) return false;
                if (string.IsNullOrEmpty(pacienteUpdate.Nombre)) return false;
                if (string.IsNullOrEmpty(pacienteUpdate.Apellido)) return false;
                if (string.IsNullOrEmpty(pacienteUpdate.DNI) || (pacienteUpdate.DNI.Length != 8)) return false;
                clsPacienteDAL dal = new clsPacienteDAL();
                bool resultado = dal.Update(pacienteUpdate);

                clsBitacoraBE b = new clsBitacoraBE();
                b.UsuarioId = clsSesionActual.GetInstancia().IdUsuario;
                b.Actividad = "Update Paciente";
                b.Informacion = resultado ? "OK - DNI: " + pacienteUpdate.DNI : "ERROR";
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
                clsPacienteDAL dal = new clsPacienteDAL();
                bool resultado = dal.Delete(id);

                clsBitacoraBE b = new clsBitacoraBE();
                b.UsuarioId = clsSesionActual.GetInstancia().IdUsuario;
                b.Actividad = "Delete Paciente";
                b.Informacion = resultado ? "OK - Id: " + id : "ERROR";
                clsBitacoraBLL.Registrar(b);

                return resultado;
            }
            catch (Exception ex)
            {
                string v = ex.ToString();
                return false;
            }
        }

        #region metodos de lectura

        public clsPacienteBE GetById(int id)
        {
            try
            {
                if (id <= 0) return null;
                clsPacienteDAL dal = new clsPacienteDAL();
                return dal.GetByID(id);
            }
            catch (Exception ex)
            {
                string v = ex.ToString();
                return null;
            }
        }
        public List<clsPacienteBE> GetAll()
        {
            try
            {
                clsPacienteDAL dal = new clsPacienteDAL();
                return dal.GetAll();
            }
            catch (Exception ex)
            {

                string v = ex.ToString();
                return null;
            }
        }
        public clsPacienteBE GetByDni(string dni)
        {
            try
            {
                if (string.IsNullOrEmpty(dni)) return null;
                clsPacienteDAL dal = new clsPacienteDAL();
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
