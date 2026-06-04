using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class csRolSimple : IComponenteRol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public bool EsGrupo => false; 
        List<string> IComponenteRol.ObtenerPermisos()
        {
            List<string> list = new List<string>();
            list.Add(Nombre);
            return list;
        }
    }
}
