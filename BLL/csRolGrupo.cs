using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class csRolGrupo : IComponenteRol
    {
        public int IdRol {  get; set; }
        public string Nombre {  get; set; }
        public bool EsGrupo => true;
        private List<IComponenteRol> _hijos;
        public List<IComponenteRol> Hijos => _hijos;


        public csRolGrupo()
        {
            _hijos = new List<IComponenteRol>();
        }

        public void Agregar(IComponenteRol componente)
        {
            _hijos.Add(componente);
        }
        public  void Quitar(IComponenteRol componente)
        {
            _hijos.Remove(componente);
        }

        public List<string> ObtenerPermisos()
        {
            List<string> lista = new List<string>();

            foreach (IComponenteRol hijo in _hijos)
            {
                lista.AddRange(hijo.ObtenerPermisos());
            }
            return lista;
        }
       
    }
}
