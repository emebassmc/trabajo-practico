using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class clsGestorIdioma
    {
        private static clsGestorIdioma _instancia;
        private List<IObservadorIdioma> _suscriptores;
        private Dictionary<string, string> _traducciones;
        private clsTraduccionDAL traduccionDAL;

        public string IdiomaActual { get; private set; }

        private clsGestorIdioma()
        {
            _suscriptores = new List<IObservadorIdioma>();
            _traducciones = new Dictionary<string, string>();
            traduccionDAL = new clsTraduccionDAL();
            IdiomaActual = "es";
            CargarTraducciones("es");
        }
        public int GetTotalClaves()
        {
            return _traducciones.Count;
        }

        public static clsGestorIdioma GetInstancia()
        {
            if (_instancia == null)
                _instancia = new clsGestorIdioma();
            return _instancia;
        }

        public void Suscribir(IObservadorIdioma observador)
        {
            if (!_suscriptores.Contains(observador))
                _suscriptores.Add(observador);
        }

        public void Desuscribir(IObservadorIdioma observador)
        {
            if (_suscriptores.Contains(observador))
                _suscriptores.Remove(observador);
        }

        public void CambiarIdioma(string codigo)
        {
            IdiomaActual = codigo;
            CargarTraducciones(codigo);
            foreach (IObservadorIdioma obs in _suscriptores)
                obs.ActualizarIdioma(codigo);
        }

        // Carga todas las traducciones del idioma en el diccionario
        private void CargarTraducciones(string codigo)
        {
            _traducciones = traduccionDAL.GetDiccionarioPorCodigo(codigo);
        }

        // Devuelve el texto de una clave; si no existe, devuelve la propia clave
        public string Traducir(string clave)
        {
            if (_traducciones.ContainsKey(clave))
                return _traducciones[clave];
            return clave; // fallback: muestra la clave si falta la traducción
        }
    }
}