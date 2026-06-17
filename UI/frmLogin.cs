using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmLogin : Form, IObservadorIdioma
    {
        clsUsuarioBLL usuario = new clsUsuarioBLL();
        public frmLogin()
        {
            InitializeComponent();
            label3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            clsGestorIdioma.GetInstancia().Suscribir(this);
            personalizarForm();
            ActualizarIdioma(clsGestorIdioma.GetInstancia().IdiomaActual);  
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
                //this.Close();
            }
            else
            {
                label3.Text = "Usuario o contraseña incorrectos";
                label3.Visible = true;
            }
        }



        private void personalizarForm()
        {
            this.BackColor = Color.FromArgb(45, 62, 80);
            this.Text = "TurnoSync — Login";

            lblUsuario.ForeColor = Color.White;
            lblUsuario.Font = new Font("Segoe UI", 10);
            lblContraseña.ForeColor = Color.White;
            lblContraseña.Font = new Font("Segoe UI", 10);
            lblIdioma.ForeColor = Color.White;
            lblIdioma.Font = new Font("Segoe UI", 10);
            label3.ForeColor = Color.FromArgb(231, 76, 60);
            label3.Font = new Font("Segoe UI", 9);

            txtUsuario.Font = new Font("Segoe UI", 10);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;

            button1.BackColor = Color.FromArgb(52, 152, 219);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button1.Cursor = Cursors.Hand;            
        }
        public void ActualizarIdioma(string idioma)
        {
            var g = clsGestorIdioma.GetInstancia();

            lblUsuario.Text = g.Traducir("lblUsuario");
            lblContraseña.Text = g.Traducir("lblClave");
            lblIdioma.Text = g.Traducir("lblIdioma");
            button1.Text = g.Traducir("btnIngresar");
        }
        private void lblIdioma_Click(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void lblContraseña_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGestorIdioma.GetInstancia().Desuscribir(this);
        }

    }
}
