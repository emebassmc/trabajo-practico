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
            var g = clsGestorIdioma.GetInstancia();

            button1.Text = g.Traducir("btnRefrescar");
            this.Text = g.Traducir("titleBitacora");

            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Id"].HeaderText = g.Traducir("colID");
                dataGridView1.Columns["Fecha"].HeaderText = g.Traducir("colFecha");
                dataGridView1.Columns["UsuarioId"].HeaderText = g.Traducir("colUsuario");
                dataGridView1.Columns["Actividad"].HeaderText = g.Traducir("colActividad");
                dataGridView1.Columns["Informacion"].HeaderText = g.Traducir("colInformacion");
            }
        }

        private void frmBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGestorIdioma.GetInstancia().Desuscribir(this);
        }
    }
}
