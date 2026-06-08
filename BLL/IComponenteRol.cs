using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IComponenteRol
    {
        int IdRol { get; }
        string Nombre { get; }
        bool EsGrupo { get; }
        public List<string> ObtenerPermisos();
    }
}
