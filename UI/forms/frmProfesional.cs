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
    public partial class frmProfesional : Form
    {
        clsProfesionalBLL bllprofesional = new clsProfesionalBLL();
        bool modoEdicion = false;
        int idSeleccionado = 0;

        public frmProfesional()
        {
            InitializeComponent();
        }

        private void frmProfesional_Load(object sender, EventArgs e)
        {
            cargarCombo();
            cargarGrilla();
            bloquearCampos();
        }

        public void cargarGrilla()
        {
            var lista = bllprofesional.GetAll();
            dataGridView1.DataSource = lista;
        }
        public void bloquearCampos()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDNI.Enabled = false;
            dtpFechaNacimiento.Enabled = false;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            txtMatricula.Enabled = false;
            cmbEspecialidad.Enabled = false;
        }
        public void habilitarCampos()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDNI.Enabled = true;
            dtpFechaNacimiento.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            txtMatricula.Enabled = true;
            cmbEspecialidad.Enabled = true;
        }
        public void limpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            txtMatricula.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            idSeleccionado = 0;
        }
        public void cargarCombo()
        {
            clsEspecialidadBLL bllEsp = new clsEspecialidadBLL();
            var lista = bllEsp.GetAll();
            cmbEspecialidad.DataSource = lista;
            cmbEspecialidad.DisplayMember = "Nombre";
            cmbEspecialidad.ValueMember = "IdEspecialidad";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (modoEdicion == false)
            {
                clsProfesionalBE profesional = new clsProfesionalBE();
                //tiramos los valores de email y telefono a null ya que no aplican a esto.
                profesional.Email = null;
                profesional.Telefono = null;
                profesional.Nombre = txtNombre.Text;
                profesional.Apellido = txtApellido.Text;
                profesional.DNI = txtDNI.Text;
                profesional.Matricula = txtMatricula.Text;
                profesional.IdEspecialidad = (int)cmbEspecialidad.SelectedValue;
                profesional.FechaNacimiento = dtpFechaNacimiento.Value;

                bool resultado = bllprofesional.Insert(profesional);
                if (resultado == true)
                {
                    MessageBox.Show("Profesional guardado con exitos");
                }
                else
                {
                    MessageBox.Show("No se guardo el Profesional, revisa que esta mal..");
                }
            }
            else if (modoEdicion == true)
            {
                clsProfesionalBE profesional = new clsProfesionalBE();
                //tiramos los valores de email y telefono a null ya que no aplican a esto.
                profesional.Email = null;
                profesional.Telefono = null;
                profesional.Nombre = txtNombre.Text;
                profesional.Apellido = txtApellido.Text;
                profesional.DNI = txtDNI.Text;
                profesional.Matricula = txtMatricula.Text;
                profesional.IdEspecialidad = (int)cmbEspecialidad.SelectedValue;
                profesional.FechaNacimiento = dtpFechaNacimiento.Value;
                profesional.IdPersona = idSeleccionado;
                bool resultado = bllprofesional.Update(profesional);
                if (resultado == true)
                {
                    MessageBox.Show("Profesional actualizado con exitos");
                }
                else
                {
                    MessageBox.Show("No se guardo el Profesional, revisa que esta mal..");
                }
            }
            cargarGrilla();
            bloquearCampos();
            limpiarCampos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            modoEdicion = false;
            limpiarCampos();
            habilitarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            bloquearCampos();
            modoEdicion = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0) return;
            DialogResult confirm = MessageBox.Show("¿Está seguro que desea eliminar?",
                "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bllprofesional.Delete(idSeleccionado);
                cargarGrilla();
                bloquearCampos();
                limpiarCampos();
            }
        }
    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["IdPersona"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                txtDNI.Text = fila.Cells["DNI"].Value.ToString();
                txtMatricula.Text = fila.Cells["Matricula"].Value.ToString();
                cmbEspecialidad.SelectedIndex = Convert.ToInt32(fila.Cells["IdEspecialidad"].Value);
                dtpFechaNacimiento.Value = Convert.ToDateTime(fila.Cells["FechaNacimiento"].Value);
                modoEdicion = true;
                habilitarCampos();
                btnEliminar.Enabled = true;
            }
        }
    }
}
