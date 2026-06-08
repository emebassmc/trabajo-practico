using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsGestorIdioma
    {

        private List<IObservadorIdioma> _suscriptores;
        private static clsGestorIdioma _instancia;

        public string IdiomaActual { get; set;}

        private clsGestorIdioma()
        {
            _suscriptores = new List<IObservadorIdioma>();
            IdiomaActual = "es";
        }
        public static clsGestorIdioma GetInstancia()
        {
            if (_instancia == null)
                _instancia = new clsGestorIdioma();
            return _instancia;
        }

        public void Suscribir(IObservadorIdioma obs)
        {
            _suscriptores.Add(obs);
        }

        public void Desuscribir(IObservadorIdioma obs)
        {
            _suscriptores.Remove(obs);
        }

        public void CambiarIdioma(string idioma)
        {
            IdiomaActual = idioma;
            foreach (IObservadorIdioma obs in _suscriptores)
                obs.ActualizarIdioma(idioma);
        }

    }
}
