using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmUsuario : Form, IObservadorIdioma
    {
        clsUsuarioBLL usuarioBLL = new clsUsuarioBLL();
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            personalizarGrilla();
            clsGestorIdioma.GetInstancia().Suscribir(this);
            ActualizarIdioma(clsGestorIdioma.GetInstancia().IdiomaActual);

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text)) 
            {
                MessageBox.Show("Ingresa un usuario");
                return;
            }
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                MessageBox.Show("Ingresa una clave");
                return;
            }                    
            clsUsuarioBE nuevo = new clsUsuarioBE();
            nuevo.NombreUsuario = txtUsuario.Text;
            nuevo.PasswordHash = txtClave.Text;

            bool resultado = usuarioBLL.Registrar(nuevo);
            if (resultado == true) 
            {
                MessageBox.Show("Usuario: " + nuevo.NombreUsuario + " creado con éxito");
                txtUsuario.Text = "";
                txtClave.Text = "";
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Erorr al generar el usuario ");
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);

            DialogResult confirm = MessageBox.Show(
                "¿Eliminás el usuario?",
                "Confirmar",
                MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                usuarioBLL.Eliminar(id);
                CargarUsuarios();
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void CargarUsuarios()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarioBLL.GetAll();
        }
        public void personalizarGrilla()
        {
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.Columns["IdUsuario"].FillWeight = 50;
            dgvUsuarios.Columns["PasswordHash"].Visible = false;
            // Estilo general
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.GridColor = Color.FromArgb(220, 220, 220);
            dgvUsuarios.BackgroundColor = Color.White;

            // Header
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 62, 80);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvUsuarios.ColumnHeadersHeight = 35;

            // Filas
            dgvUsuarios.DefaultCellStyle.BackColor = Color.White;
            dgvUsuarios.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvUsuarios.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvUsuarios.RowsDefaultCellStyle.BackColor = Color.White;
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvUsuarios.RowTemplate.Height = 30;

            // Columnas
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.Columns["PasswordHash"].Visible = false;
            dgvUsuarios.Columns["IdUsuario"].FillWeight = 30;
            dgvUsuarios.Columns["NombreUsuario"].FillWeight = 170;
        }

        private void frmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGestorIdioma.GetInstancia().Desuscribir(this);
        }
        public void ActualizarIdioma(string idioma)
        {
            if (idioma == "es")
            {
                grpUsuarios.Text = "Usuarios";
                lblNombre.Text = "Usuario";
                label2.Text = "Clave";
                btnAlta.Text = "Alta";
                btnBaja.Text = "Baja";
                this.Text = "Gestor | Usuarios";

                if (dgvUsuarios.Columns.Count > 0)
                {
                    dgvUsuarios.Columns["IdUsuario"].HeaderText = "ID";
                    dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Usuario";
                }
            }
            else if (idioma == "en")
            {
                grpUsuarios.Text = "Users";
                lblNombre.Text = "Username";
                label2.Text = "Password";
                btnAlta.Text = "Add";
                btnBaja.Text = "Remove";
                this.Text = "Manager | Users";

                if (dgvUsuarios.Columns.Count > 0)
                {
                    dgvUsuarios.Columns["IdUsuario"].HeaderText = "ID";
                    dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Username";
                }
            }
        }
    }
}
