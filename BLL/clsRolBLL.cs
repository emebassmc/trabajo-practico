using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class clsRolBLL
    {
        clsRolDAL dal = new clsRolDAL();

        public bool Insert(clsRolBE rol)
        {
            try
            {
                if (string.IsNullOrEmpty(rol.Nombre)) return false;
                bool resultado = dal.Insert(rol);
                clsBitacoraBE b = new clsBitacoraBE();
                b.UsuarioId = clsSesionActual.GetInstancia().IdUsuario;
                b.Actividad = "Insert Rol";
                b.Informacion = resultado ? "OK - IDRol: " + rol.Nombre: "ERROR";
                clsBitacoraBLL.Registrar(b);
                return dal.Insert(rol);
            }
            catch (Exception ex) { string v = ex.ToString(); return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                if (id <= 0) return false;
                bool resultado = dal.Delete(id);
                clsBitacoraBE b = new clsBitacoraBE();
                b.UsuarioId = clsSesionActual.GetInstancia().IdUsuario;
                b.Actividad = "Delete Rol";
                b.Informacion = resultado ? "OK - ID: " + id: "ERROR";
                clsBitacoraBLL.Registrar(b);
                return dal.Delete(id);
            }
            catch (Exception ex) { string v = ex.ToString(); return false; }
        }

        public List<clsRolBE> GetAll()
        {
            try { return dal.GetAll(); }
            catch (Exception ex) { string v = ex.ToString(); return null; }
        }

        public clsRolComponente GetArbol()
        {
            try
            {
                var lista = dal.GetAll();
                clsRolGrupo raiz = new clsRolGrupo("Sistema");

                Dictionary<int, clsRolGrupo> grupos = new Dictionary<int, clsRolGrupo>();
                foreach (var rol in lista)
                    grupos[rol.IdRol] = new clsRolGrupo(rol.Nombre);

                foreach (var rol in lista)
                {
                    if (rol.IdRolPadre == null)
                        raiz.Agregar(grupos[rol.IdRol]);
                    else
                        grupos[rol.IdRolPadre.Value].Agregar(grupos[rol.IdRol]);
                }

                return raiz;
            }
            catch (Exception ex) { string v = ex.ToString(); return null; }
        }
    }
}