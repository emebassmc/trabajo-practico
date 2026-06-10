using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsBitacoraBLL
    {
        public static void Registrar(clsBitacoraBE bitacora) 
        {
            clsBitacoraDAL dal = new clsBitacoraDAL();
            bitacora.Fecha = DateTime.Now;
            dal.Insert(bitacora);
        }
        public List<clsBitacoraBE> GetAll()
        {
            clsBitacoraDAL dal = new clsBitacoraDAL();
            return dal.GetAll();
        }
    }   
}


