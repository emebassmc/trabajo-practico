using BE;
using DAL;
using System;
using System.Collections.Generic;
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
        public IComponenteRol GetArbol()
        {
            List<clsRolBE> todos = dal.GetAll();
            Dictionary<int, IComponenteRol> mapa= new Dictionary<int, IComponenteRol>();
            foreach (clsRolBE r in todos)
            {
                if (r.EsGrupo)
                    mapa[r.IdRol] = new csRolGrupo { IdRol = r.IdRol, Nombre = r.Nombre };
                else
                    mapa[r.IdRol] = new csRolSimple { IdRol = r.IdRol, Nombre = r.Nombre };
            }
            IComponenteRol raiz = null;
            foreach (clsRolBE r in todos)
            {
                if (r.IdRolPadre == null)
                {
                    raiz = mapa[r.IdRol];
                }
                else
                {
                    if (mapa.ContainsKey(r.IdRolPadre.Value) && mapa[r.IdRolPadre.Value] is csRolGrupo)
                    {
                        csRolGrupo padre = (csRolGrupo)mapa[r.IdRolPadre.Value];
                        padre.Agregar(mapa[r.IdRol]);
                    }
                }
            }
            return raiz;
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
        public List<clsRolBE> GetRolesUsuario(int IdUsuario)
        {
            if (IdUsuario <= 0) return new List<clsRolBE>();
            return dal.GetRolesPorUsuario(IdUsuario);
        }
        private IComponenteRol BuscarEnArbol(IComponenteRol nodo, int idBuscado)
        {
            if (nodo == null) return null;
            if (nodo.IdRol == idBuscado) return nodo;

            if (nodo is csRolGrupo)
            {
                foreach (IComponenteRol hijo in ((csRolGrupo)nodo).Hijos)
                {
                    IComponenteRol resultado = BuscarEnArbol(hijo, idBuscado);
                    if (resultado != null) return resultado;
                }
            }
            return null;
        }
        public bool TienePermiso(int IdUsuario, string permiso)
        {
            List<clsRolBE> roles = GetRolesUsuario(IdUsuario);
            IComponenteRol arbol = GetArbol();
             
            foreach (clsRolBE rol in roles)
            {
                IComponenteRol nodo = BuscarEnArbol(arbol,rol.IdRol);
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
    }
}
