using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsRolBLL 
    {
        #region metodos escritura
        private clsRolDAL dal;

        public clsRolBLL()
        {
            dal = new clsRolDAL();
        }

        public List<clsRolBE> GetAll()
        {
            return dal.GetAll();
        }
        public bool Insert(clsRolBE rol)
        {
            if (string.IsNullOrEmpty(rol.Nombre)) { return false; }
            return dal.Insert(rol);
        }
        public bool Delete(int id)
        {
            if (id <= 0 ) { return false; }
            return dal.Delete(id);
        }
        public bool Update(clsRolBE rol)
        {
            if (rol.IdRol <= 0) return false;
            if (string.IsNullOrEmpty(rol.Nombre)) return false;
            return dal.Update(rol);
        }

        


        public bool AsignarARol(int IdUsuario, int IdRol)
        {
            if (IdUsuario <= 0) return false;
            if (IdRol <= 0) return false;   
            return dal.AsignarRolUsuario(IdUsuario, IdRol);
        }
        public bool QuitarRolUsuario(int IdUsuario, int IdRol)
        {
            if (IdUsuario <= 0) return false;
            if (IdRol <= 0) return false;
            return dal.QuitarRolUsuario(IdUsuario, IdRol);
        }
#endregion
        #region metodos lectura
        public List<clsRolBE> GetRolesUsuario(int IdUsuario)
        {
            if (IdUsuario <= 0) return new List<clsRolBE>();
            return dal.GetRolesPorUsuario(IdUsuario);
        }
        public clsComponenteRol BuscarEnArbol(clsComponenteRol nodo, int idBuscado)
        {
            if (nodo == null) return null;
            if (nodo.IdRol == idBuscado) return nodo;

            if (nodo is csRolGrupo)
            {
                foreach (clsComponenteRol hijo in ((csRolGrupo)nodo).Hijos)
                {
                    clsComponenteRol resultado = BuscarEnArbol(hijo, idBuscado);
                    if (resultado != null) return resultado;
                }
            }
            return null;
        }
        public clsComponenteRol GetArbol()
        {
            List<clsRolBE> todos = dal.GetAll();
            Dictionary<int, clsComponenteRol> mapa = new Dictionary<int, clsComponenteRol>();

            // PASO 1: crear un nodo por CADA rol (grupos Y simples)
            foreach (clsRolBE r in todos)
            {
                if (r.EsGrupo)
                    mapa[r.IdRol] = new csRolGrupo { IdRol = r.IdRol, Nombre = r.Nombre };
                else
                    mapa[r.IdRol] = new csRolSimple { IdRol = r.IdRol, Nombre = r.Nombre };
            }

            // PASO 2: componer la jerarquía completa via RolPermiso
            foreach (clsRolBE r in todos)
            {
                if (!(mapa[r.IdRol] is csRolGrupo)) continue;

                csRolGrupo grupoActual = (csRolGrupo)mapa[r.IdRol];
                List<clsRolBE> hijos = dal.GetPermisosPorRol(r.IdRol);

                foreach (clsRolBE hijo in hijos)
                {
                    if (mapa.ContainsKey(hijo.IdRol))
                        grupoActual.Agregar(mapa[hijo.IdRol]);
                }
            }

            // PASO 3: la raíz es Sistema
            clsComponenteRol raiz = null;
            foreach (clsRolBE r in todos)
            {
                if (r.Nombre == "Sistema")
                {
                    raiz = mapa[r.IdRol];
                    break;
                }
            }

            return raiz;
        }
        public bool TienePermiso(int IdUsuario, string permiso)
        {
            List<clsRolBE> roles = GetRolesUsuario(IdUsuario);
            clsComponenteRol arbol = GetArbol();
             
            foreach (clsRolBE rol in roles)
            {
                clsComponenteRol nodo = BuscarEnArbol(arbol,rol.IdRol);
                if (nodo != null)
                {
                    List<string> permisos = nodo.ObtenerPermisos();
                    if (permisos.Contains(permiso))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public List<clsRolBE> GetPermisosPorRol(int idRol)
        {
            return dal.GetPermisosPorRol(idRol);
        }
        public bool AsignarPermiso(int idRol, int idPermiso)
        {
            return dal.AsignarPermiso(idRol, idPermiso);
        }

        public bool QuitarPermiso(int idRol, int idPermiso)
        {
            return dal.QuitarPermiso(idRol, idPermiso);
        }

        public bool QuitarTodosLosRoles(int idUsuario)
        {

            if (idUsuario <= 0) return false;
            clsUsuarioDAL dal = new clsUsuarioDAL();
            return dal.QuitarRolesUsuario(idUsuario);               
        }
        #endregion
    }
}
