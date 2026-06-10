using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class clsTurnoBE
    {     
        public int IDTurno { get; set; }
        public int IDPaciente { get; set; }
        public int IDProfesional { get; set; }
        public EstadoTurnosBE Estado { get; set; }
        public DateTime FechaHora { get; set; }
        public string Observaciones { get; set; }

    }
}
