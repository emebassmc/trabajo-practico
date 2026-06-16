using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class clsComponenteRol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public abstract bool EsGrupo { get; }
        public abstract List<string> ObtenerPermisos();
    }
}
