using BE;
using DAL;

namespace BLL
{
    public class clsTurnosBLL
    {
        #region metodos de escritura
        public bool Insert(clsTurnoBE turno)
        {
            try
            {
                if (turno.IDPaciente <= 0) return false;
                if (turno.IDProfesional <= 0) return false;
                if (turno.FechaHora <= DateTime.Now) return false;
                if(EstaDisponbile(turno.IDProfesional, turno.FechaHora) == false) return false;

                clsTurnosDAL dal = new clsTurnosDAL();
                bool resultado = dal.Insert(turno);
                clsBitacoraBE b = new clsBitacoraBE();
                b.UsuarioId = clsSesionActual.GetInstancia().IdUsuario;
                b.Actividad = "Insert Turno";
                b.Informacion = resultado ? "OK - Id: " + turno.IDTurno : "ERROR";
                clsBitacoraBLL.Registrar(b);
                return resultado;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return false;
            }              
        }
        public bool Cancelar(int id)
        {
            try
            {
                if(id <= 0 ) return false;
                clsTurnosDAL dal = new clsTurnosDAL();
                clsTurnoBE  turno = dal.GetById(id);
                if (turno == null) return false;
                if (turno.Estado == EstadoTurnosBE.Cancelado) return false;
                turno.Estado = EstadoTurnosBE.Cancelado;
                bool resultado = dal.Update(turno);
                clsBitacoraBE b = new clsBitacoraBE();
                b.UsuarioId = clsSesionActual.GetInstancia().IdUsuario;
                b.Actividad = "Cancelar Turno";
                b.Informacion = resultado ? "OK - Id: " + turno.IDTurno : "ERROR";
                clsBitacoraBLL.Registrar(b);
                return resultado;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return false;
            }
        }
        public bool Confirmar(int id)
        {
            try
            {
                if (id <= 0) return false;
                clsTurnosDAL dal = new clsTurnosDAL();
                clsTurnoBE turno = dal.GetById(id);
                if (turno == null) return false;
                if (turno.Estado == EstadoTurnosBE.Confirmado) return false;
                turno.Estado = EstadoTurnosBE.Confirmado;
                bool resultado = dal.Update(turno);
                clsBitacoraBE b = new clsBitacoraBE();
                b.UsuarioId = clsSesionActual.GetInstancia().IdUsuario;
                b.Actividad = "Confirmar Turno";
                b.Informacion = resultado ? "OK - Id: " + turno.IDTurno : "ERROR";
                clsBitacoraBLL.Registrar(b);
                return resultado;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return false;
            }
        }
        #endregion


        public clsTurnoBE GetByID(int id)
        {
            try
            {
                if (id <= 0) return null;
                clsTurnosDAL dal = new clsTurnosDAL();
                return dal.GetById(id);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return null;
            }
        }

        public List<clsTurnoBE> GetAll()
        {
            try
            {
                clsTurnosDAL dal = new clsTurnosDAL();
                return dal.GetAll();
            }
            catch (Exception ex)
            {

                string v = ex.ToString();
                return null;
            }
        }
        public List<clsTurnoBE> GetByPaciente(int idPaciente)
        {
            try
            {
                if (idPaciente <= 0) return null;
                clsTurnosDAL dal = new clsTurnosDAL();
                return dal.GetByPaciente(idPaciente);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return null;
            }
        }
        

        private bool EstaDisponbile(int IdProfesional, DateTime fechaHora)
        {
            clsTurnosDAL dal = new clsTurnosDAL();
            List<clsTurnoBE> listaTurnos = dal.GetByProfesional(IdProfesional);
            foreach (clsTurnoBE x in listaTurnos)
            {
                if (x.FechaHora == fechaHora) return false;
            }
            return true;
        }
    }
}

/*

GetByPaciente(int idPaciente): List<clsTurnoBE>
  - idPaciente > 0
  - llamar dal.GetByPaciente()

EstaDisponible(int idProfesional, DateTime fechaHora): bool  ← privado
  - traer todos los turnos del profesional
  - verificar que ninguno tenga la misma FechaHora
  - devolver true si está libre
*/