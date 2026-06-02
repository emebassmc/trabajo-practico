using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class clsRolComponente
    {
        public string Nombre { get; set; }
        public abstract bool TienePermiso(string accion);
    }
}
