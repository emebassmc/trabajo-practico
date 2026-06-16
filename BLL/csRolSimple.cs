using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class csRolSimple : clsComponenteRol
    {
        public override bool EsGrupo
        {
            get { return false; }
        }

        public override List<string> ObtenerPermisos()
        {
            List<string> lista = new List<string>();
            lista.Add(Nombre);
            return lista;
        }
    }
}
