using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool integridadOk = BLL.clsDigitoVerificador.VerificarIntegridad();
            if (!integridadOk)
            {
                MessageBox.Show(
                    "Se detectaron inconsistencias en la base de datos.\nContacte al administrador.",
                    "Error de Integridad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return; // no abre el login
            }
            Application.Run(new frmLogin());
        }
    }
}
