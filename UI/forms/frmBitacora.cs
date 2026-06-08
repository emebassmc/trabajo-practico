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
    public partial class frmBitacora : Form, IObservadorIdioma
    {
        clsBitacoraBLL bllBitacora = new clsBitacoraBLL();

        public frmBitacora()
        {
            InitializeComponent();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            cargarGrilla();
            clsGestorIdioma.GetInstancia().Suscribir(this);
            ActualizarIdioma(clsGestorIdioma.GetInstancia().IdiomaActual);

        }
        private void cargarGrilla()
        {
            dataGridView1.DataSource = bllBitacora.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarGrilla();
        }
        public void ActualizarIdioma(string idioma)
        {
            if (idioma == "es")
            {
                button1.Text = "Actualizar";
                this.Text = "Bitácora";

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["Id"].HeaderText = "ID";
                    dataGridView1.Columns["Fecha"].HeaderText = "Fecha";
                    dataGridView1.Columns["UsuarioId"].HeaderText = "Usuario";
                    dataGridView1.Columns["Actividad"].HeaderText = "Actividad";
                    dataGridView1.Columns["Informacion"].HeaderText = "Información";
                }
            }
            else if (idioma == "en")
            {
                button1.Text = "Refresh";
                this.Text = "Activity Log";

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["Id"].HeaderText = "ID";
                    dataGridView1.Columns["Fecha"].HeaderText = "Date";
                    dataGridView1.Columns["UsuarioId"].HeaderText = "User";
                    dataGridView1.Columns["Actividad"].HeaderText = "Activity";
                    dataGridView1.Columns["Informacion"].HeaderText = "Information";
                }
            }
        }

        private void frmBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGestorIdioma.GetInstancia().Desuscribir(this);
        }
    }
}
