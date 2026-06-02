using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsRolGrupo : clsRolComponente
    {
        private List<clsRolComponente> _hijos = new List<clsRolComponente>();
        public List<clsRolComponente> Hijos => _hijos;


        public clsRolGrupo(string nombre)
        {
            Nombre = nombre;
        }

        public void Agregar(clsRolComponente rol)
        {
            _hijos.Add(rol);
        }

        public void Quitar(clsRolComponente rol)
        {
            _hijos.Remove(rol);
        }

        public override bool TienePermiso(string accion)
        {
            foreach (var hijo in _hijos)
            {
                if (hijo.TienePermiso(accion))
                    return true;
            }
            return false;
        }
    }
}
