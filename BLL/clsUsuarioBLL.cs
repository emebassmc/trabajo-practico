using BE;
using DAL;

namespace BLL
{
    public class clsUsuarioBLL
    {
        clsUsuarioDAL dal = new clsUsuarioDAL();
        clsSeguridadBLL seg = new clsSeguridadBLL();

        public bool Login(string nombreUsuario, string password)
        {
        try
            { 
            if (string.IsNullOrEmpty(nombreUsuario)) return false;
            if (string.IsNullOrEmpty(password)) return false;

            clsUsuarioBE usuario = dal.GetByUsername(nombreUsuario);

            if(usuario == null) return false;

            return seg.VerificarPassword(password, usuario.PasswordHash);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return false;
            }
        }

        public bool Registrar(clsUsuarioBE usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.NombreUsuario)) return false;
                if (string.IsNullOrEmpty(usuario.PasswordHash)) return false;

                usuario.PasswordHash = seg.HashPassword(usuario.PasswordHash);
                return dal.Insert(usuario);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return false;
            }
        }
        public bool Registrar2(string nombreUsuario, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(nombreUsuario)) return false;
                if (string.IsNullOrEmpty(password)) return false;

                clsUsuarioBE usuario = new clsUsuarioBE();
                usuario.NombreUsuario = nombreUsuario;
                usuario.PasswordHash = seg.HashPassword(password);

                return dal.Insert(usuario);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return false;
            }
        }
    }
}
