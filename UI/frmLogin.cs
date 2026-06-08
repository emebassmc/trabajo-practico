using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmLogin : Form
    {
        clsUsuarioBLL usuario = new clsUsuarioBLL();
        public frmLogin()
        {
            InitializeComponent();
            label3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                label3.Text = "Complete todos los campos";
                label3.Visible = true;
                return;
            }

            bool resultado = usuario.Login(txtUsuario.Text, txtPassword.Text);
            if (resultado)
            {
                clsUsuarioBE u = usuario.GetByUsername(txtUsuario.Text);
                clsSesionActual.GetInstancia().IdUsuario = u.IdUsuario;
                clsSesionActual.GetInstancia().NombreUsuario = txtUsuario.Text;
                frmPrincipal principal = new frmPrincipal();
                principal.Show();
            }
            else
            {
                label3.Text = "Usuario o contraseña incorrectos";
                label3.Visible = true;
            }
        }
    }
}
