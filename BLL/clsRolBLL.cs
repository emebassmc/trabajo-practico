using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
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
                    csRolGrupo padre = (csRolGrupo)mapa[r.IdRolPadre.Value];
                    padre.Agregar(mapa[r.IdRol]);
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
    }
}
