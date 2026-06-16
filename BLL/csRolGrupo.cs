using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL
{
    public class csRolGrupo : clsComponenteRol
    {
        #region metodos de escritura
        // IdRol y Nombre se heredan de clsComponenteRol

        public override bool EsGrupo => true;

        private List<clsComponenteRol> _hijos;
        public List<clsComponenteRol> Hijos => _hijos;

        public csRolGrupo()
        {
            _hijos = new List<clsComponenteRol>();
        }

        public void Agregar(clsComponenteRol componente)
        {
            _hijos.Add(componente);
        }

        public void Quitar(clsComponenteRol componente)
        {
            _hijos.Remove(componente);
        }
        #endregion

        #region metodos lectura
        public override List<string> ObtenerPermisos()
        {
            List<string> lista = new List<string>();
            foreach (clsComponenteRol hijo in _hijos)
            {
                lista.AddRange(hijo.ObtenerPermisos());
            }
            return lista;
        }
        #endregion
    }
}