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
    public partial class frmPacientes : Form, IObservadorIdioma
    {

        clsPacienteBLL bllPaciente = new clsPacienteBLL();
        clsRolBLL bllRol = new clsRolBLL();
        bool puedeAgregar, puedeModificar, puedeEliminar;
        bool modoEdicion = false;
        int idSeleccionado = 0;

        public frmPacientes()
        {
            InitializeComponent();
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
            string mensaje = clsGestorIdioma.GetInstancia().IdiomaActual == "es"
                ? "¿Está seguro que desea eliminar?"
                : "Are you sure you want to delete?";

            string titulo = clsGestorIdioma.GetInstancia().IdiomaActual == "es"
                ? "Confirmar"
                : "Confirm";
            DialogResult confirm = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo);
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
            btnNuevo.Enabled = puedeAgregar;
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
                btnGuardar.Enabled = puedeModificar;
                btnEliminar.Enabled = puedeEliminar;
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
            int idUsuario = clsSesionActual.GetInstancia().IdUsuario;
            puedeAgregar = bllRol.TienePermiso(idUsuario, "Pacientes.Agregar");
            puedeModificar = bllRol.TienePermiso(idUsuario, "Pacientes.Modificar");
            puedeEliminar = bllRol.TienePermiso(idUsuario, "Pacientes.Eliminar");

            cargarGrilla();
            bloquearCampos();
            PersonalizarForm();
            clsGestorIdioma.GetInstancia().Suscribir(this);
            ActualizarIdioma(clsGestorIdioma.GetInstancia().IdiomaActual);
        }

        private void frmPacientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGestorIdioma.GetInstancia().Desuscribir(this);
        }
        public void ActualizarIdioma(string idioma)
        {
            if (idioma == "es")
            {
                groupBox1.Text = "Datos del Paciente";
                lblNombre.Text = "Nombre";
                lblApellido.Text = "Apellido";
                lblDNI.Text = "DNI";
                lblTelefono.Text = "Teléfono";
                lblEmail.Text = "Email";
                lblObraSocial.Text = "Obra Social";
                label7.Text = "Fecha de nacimiento";
                btnGuardar.Text = "Guardar";
                btnNuevo.Text = "Nuevo";
                btnEliminar.Text = "Eliminar";
                btnCancelar.Text = "Cancelar";
                this.Text = "Pacientes";

                if (dgvPacientes.Columns.Count > 0)
                {
                    dgvPacientes.Columns["IdPersona"].HeaderText = "ID";
                    dgvPacientes.Columns["Nombre"].HeaderText = "Nombre";
                    dgvPacientes.Columns["Apellido"].HeaderText = "Apellido";
                    dgvPacientes.Columns["DNI"].HeaderText = "DNI";
                    dgvPacientes.Columns["Telefono"].HeaderText = "Teléfono";
                    dgvPacientes.Columns["Email"].HeaderText = "Email";
                    dgvPacientes.Columns["FechaNacimiento"].HeaderText = "Fecha Nac.";
                    dgvPacientes.Columns["ObraSocial"].HeaderText = "Obra Social";
                }
            }
            else if (idioma == "en")
            {
                groupBox1.Text = "Patient Data";
                lblNombre.Text = "First Name";
                lblApellido.Text = "Last Name";
                lblDNI.Text = "ID Number";
                lblTelefono.Text = "Phone";
                lblEmail.Text = "Email";
                lblObraSocial.Text = "Health Insurance";
                label7.Text = "Date of Birth";
                btnGuardar.Text = "Save";
                btnNuevo.Text = "New";
                btnEliminar.Text = "Delete";
                btnCancelar.Text = "Cancel";
                this.Text = "Patients";

                if (dgvPacientes.Columns.Count > 0)
                {
                    dgvPacientes.Columns["IdPersona"].HeaderText = "ID";
                    dgvPacientes.Columns["Nombre"].HeaderText = "First Name";
                    dgvPacientes.Columns["Apellido"].HeaderText = "Last Name";
                    dgvPacientes.Columns["DNI"].HeaderText = "ID Number";
                    dgvPacientes.Columns["Telefono"].HeaderText = "Phone";
                    dgvPacientes.Columns["Email"].HeaderText = "Email";
                    dgvPacientes.Columns["FechaNacimiento"].HeaderText = "Birth Date";
                    dgvPacientes.Columns["ObraSocial"].HeaderText = "Health Insurance";
                }
            }
        }
        private void PersonalizarForm()
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            foreach (Control c in this.Controls)
                PersonalizarFormRecursivo(c);
        }

        private void PersonalizarFormRecursivo(Control control)
        {
            if (control is System.Windows.Forms.Button btn)
            {
                btn.BackColor = Color.FromArgb(45, 62, 80);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }
            if (control is GroupBox gb)
            {
                gb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                gb.ForeColor = Color.FromArgb(45, 62, 80);
            }
            if (control is Label lbl)
            {
                lbl.Font = new Font("Segoe UI", 9);
                lbl.ForeColor = Color.FromArgb(50, 50, 50);
            }
            if (control is System.Windows.Forms.TextBox txt)
            {
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 9);
            }
            foreach (Control child in control.Controls)
                PersonalizarFormRecursivo(child);
        }
    }
}
