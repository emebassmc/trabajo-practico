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

namespace UI
{
    public partial class frmEspecialidad : Form, IObservadorIdioma
    {
        clsEspecialidadBLL bllEspecialidad = new clsEspecialidadBLL();
        bool modoEdicion = false;
        int idSeleccionado = 0;

        public frmEspecialidad()
        {
            InitializeComponent();
        }

        private void frmEspecialidad_Load(object sender, EventArgs e)
        {
            cargarGrilla();
            bloquearCampos();
            clsGestorIdioma.GetInstancia().Suscribir(this);
            ActualizarIdioma(clsGestorIdioma.GetInstancia().IdiomaActual);
        }



        public void cargarGrilla()
        {
            dataGridView1.DataSource = bllEspecialidad.GetAll();
        }
        public void bloquearCampos()
        {
            txtNombre.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;    
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
        }
        public void habilitarCampos()
        {
            txtNombre.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
        }
        public void limpiarCampos()
        {
            txtNombre.Text = "";
            idSeleccionado = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            modoEdicion = false;
            limpiarCampos();
            habilitarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsEspecialidadBE especialidadBE = new clsEspecialidadBE();
            if (modoEdicion == false)
            {
                especialidadBE.Nombre = txtNombre.Text;
                bool resultado = bllEspecialidad.Insert(especialidadBE);
                if (resultado == true)
                {
                    MessageBox.Show("Especialidad guardada con exitos");
                }
                else
                {
                    MessageBox.Show("No se guardo la especialidad, revisa que esta mal..");
                }
            }
            else if (modoEdicion == true)
            {
                especialidadBE.IdEspecialidad = idSeleccionado;  
                especialidadBE.Nombre = txtNombre.Text;
                bool resultado = bllEspecialidad.Update(especialidadBE);
                if (resultado == true)
                {
                    MessageBox.Show("Especialidad guardada con exitos");
                }
                else
                {
                    MessageBox.Show("No se guardo la especialidad, revisa que esta mal..");
                }
            }
            cargarGrilla();
            bloquearCampos();
            limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0) return;
            DialogResult confirm = MessageBox.Show("¿Está seguro que desea eliminar?",
                "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bllEspecialidad.Delete(idSeleccionado);
                cargarGrilla();
                bloquearCampos();
                limpiarCampos();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["IdEspecialidad"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                modoEdicion = true;
                habilitarCampos();
                btnEliminar.Enabled = true;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            bloquearCampos();
            modoEdicion = false;
        }

        private void frmEspecialidad_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGestorIdioma.GetInstancia().Desuscribir(this);
        }
        public void ActualizarIdioma(string idioma)
        {
            if (idioma == "es")
            {
                groupBox1.Text = "Especialidades";
                lblNombre.Text = "Nombre";
                btnNuevo.Text = "Nuevo";
                btnGuardar.Text = "Guardar";
                btnEliminar.Text = "Eliminar";
                btnCancelar.Text = "Cancelar";
                this.Text = "ABM-Especialidad";
            }
            else if (idioma == "en")
            {
                groupBox1.Text = "Specialties";
                lblNombre.Text = "Name";
                btnNuevo.Text = "New";
                btnGuardar.Text = "Save";
                btnEliminar.Text = "Delete";
                btnCancelar.Text = "Cancel";
                this.Text = "Specialties";
            }
        }
    }
}
