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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class frmPacientes : Form
    {

        clsPacienteBLL bllPaciente = new clsPacienteBLL();
        bool modoEdicion = false;
        int idSeleccionado = 0;

        public frmPacientes()
        {
            InitializeComponent();
            cargarGrilla();
            bloquearCampos();
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
                bllPaciente.Delete(idSeleccionado);
                cargarGrilla();
                bloquearCampos();
                limpiarCampos();
            }
        }
        //metodos del formulario
        public void cargarGrilla()
        {
            var lista = bllPaciente.GetAll();
            dgvPacientes.DataSource = lista;
        }
        public void bloquearCampos()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDNI.Enabled = false;
            txtTelefono.Enabled = false;
            txtMail.Enabled = false;
            txtObraSocial.Enabled = false;
            dtpFechaNacimiento.Enabled = false;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        public void habilitarCampos()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDNI.Enabled = true;
            txtTelefono.Enabled = true;
            txtMail.Enabled = true;
            txtObraSocial.Enabled = true;
            dtpFechaNacimiento.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        public void limpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            txtTelefono.Text = "";
            txtMail.Text = "";
            txtObraSocial.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            idSeleccionado = 0;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (modoEdicion == false)
            {
                clsPacienteBE paciente = new clsPacienteBE();
                paciente.Nombre = txtNombre.Text;
                paciente.Apellido = txtApellido.Text;
                paciente.DNI = txtDNI.Text;
                paciente.Telefono = txtTelefono.Text;
                paciente.Email = txtMail.Text;
                paciente.ObraSocial = txtObraSocial.Text;
                paciente.FechaNacimiento = dtpFechaNacimiento.Value;
                bool resultado = bllPaciente.Insert(paciente);
                if (resultado == true)
                {
                    MessageBox.Show("Paciente guardado con exitos");
                }
                else
                {
                    MessageBox.Show("No se guardo el paciente, revisa que esta mal..");
                }
            }
            else if (modoEdicion == true)
            {
                clsPacienteBE paciente = new clsPacienteBE();
                paciente.Nombre = txtNombre.Text;
                paciente.Apellido = txtApellido.Text;
                paciente.DNI = txtDNI.Text;
                paciente.Telefono = txtTelefono.Text;
                paciente.Email = txtMail.Text;
                paciente.ObraSocial = txtObraSocial.Text;
                paciente.FechaNacimiento = dtpFechaNacimiento.Value;
                paciente.IdPersona = idSeleccionado;
                bool resultado = bllPaciente.Update(paciente);
                if (resultado == true)
                {
                    MessageBox.Show("Paciente actualizado con exitos");
                }
                else
                {
                    MessageBox.Show("No se actualizo el paciente, revisa que esta mal..");
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
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPacientes.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["IdPersona"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                txtDNI.Text = fila.Cells["DNI"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtMail.Text = fila.Cells["Email"].Value.ToString();
                txtObraSocial.Text = fila.Cells["ObraSocial"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(fila.Cells["FechaNacimiento"].Value);
                modoEdicion = true;
                habilitarCampos();
                btnEliminar.Enabled = true;
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // bloquea el caracter
            }
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {

        }
    }
}
