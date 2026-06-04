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

        public string IdiomaActual { get; set;}

        private clsGestorIdioma()
        {
            _suscriptores = new List<IObservadorIdioma>();
            IdiomaActual = "es";
        }


    }
}

/*
 clase clsGestorIdioma


    // GetInstancia (Singleton)
    método estático GetInstancia()
        si _instancia es null
            _instancia = new clsGestorIdioma()
        devolver _instancia

    // Suscribirse para recibir notificaciones
    método Suscribir(obs: IObservadorIdioma)
        _suscriptores.Add(obs)

    // Desuscribirse (cuando el form se cierra)
    método Desuscribir(obs: IObservadorIdioma)
        _suscriptores.Remove(obs)

    // Cambiar idioma y notificar a todos
    método CambiarIdioma(nuevoIdioma: string)
        IdiomaActual = nuevoIdioma
        para cada obs en _suscriptores
            obs.ActualizarIdioma(nuevoIdioma)
 */