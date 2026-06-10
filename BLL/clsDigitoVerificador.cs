using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsDigitoVerificador
    {
        public static int CalcularDVH(clsPacienteBE paciente)
        {
            int suma = 0;
            List<string> valores = new List<string>
            {
                paciente.IdPersona.ToString(),
                paciente.Nombre ?? "",
                paciente.Apellido ?? "",
                paciente.DNI ?? "",
                paciente.Telefono ?? "",
                paciente.Email ?? "",
                paciente.FechaNacimiento.ToString("yyyyMMdd"),
                paciente.ObraSocial ?? ""
            };
            int posAtributo = 1;
            foreach (string valor in valores)
            {
                int posCaracter = 1;
                foreach (char c in valor)
                {
                    suma += (int)c * posCaracter * posAtributo;
                    posCaracter++;
                }
                posAtributo++;
            }
            return suma % 97;
        }
        
        public static int CalcularDVV(List<clsPacienteBE> lista)
        {
            int suma = 0;
            foreach (clsPacienteBE paciente in lista)
            {
                suma += paciente.DVH;
            }
            return suma % 97;
        }
        public static bool VerificarIntegridad()
        {
            clsPacienteDAL dal = new clsPacienteDAL();
            List<clsPacienteBE> lista = dal.GetAll();
            // Verificamos el Digito Verificador Horizontal de cada paciente
            foreach (clsPacienteBE paciente in lista)
            {
                int dvhCalculado = CalcularDVH(paciente);
                if (dvhCalculado != paciente.DVH)
                    return false;
            }
            // Verificamos si el Digito Verificador Vertical tiene integridad
            clsDigitoVerificadorDAL dvDal = new clsDigitoVerificadorDAL();
            int dvvGuardado = dvDal.GetDVV("Paciente");
            int dvvCalculado = CalcularDVV(lista);

            if (dvvCalculado != dvvGuardado)
                return false;

            return true;
        }
        public static void RecalcularTodos()
        {
            clsPacienteDAL dal = new clsPacienteDAL();
            List<clsPacienteBE> lista = dal.GetAll();

            foreach (clsPacienteBE p in lista)
            {
                p.DVH = CalcularDVH(p);
                dal.Update(p);
            }

            int dvv = CalcularDVV(dal.GetAll());
            new clsDigitoVerificadorDAL().GuardarDVV("Paciente", dvv);
        }

    }
}
