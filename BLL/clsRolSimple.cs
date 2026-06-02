using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsRolSimple : clsRolComponente
    {
        private List<string> _permisos = new List<string>();

        public clsRolSimple(string nombre)
        {
            Nombre = nombre;
        }

        public void AgregarPermiso(string permiso)
        {
            _permisos.Add(permiso);
        }

        public override bool TienePermiso(string accion)
        {
            return _permisos.Contains(accion);
        }

    }
}
