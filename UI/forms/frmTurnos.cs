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
using BE;

namespace UI
{
    public partial class frmTurnos : Form, IObservadorIdioma
    {
        clsTurnosBLL bllTurnos = new clsTurnosBLL();
        clsPacienteBLL bllPaciente = new clsPacienteBLL();
        clsProfesionalBLL bllProfesional = new clsProfesionalBLL();
        bool modoEdicion = false;
        int idSeleccionado = 0;
        public frmTurnos()
        {
            InitializeComponent();
        }

        private void frmTurnos_Load(object sender, EventArgs e)
        {
            cargarComboEstado();
            cargarComboPacientes();
            cargarComboProfesionales();
            cargarGrilla();
            bloquearCampos();
            personalizarGrilla();
            clsGestorIdioma.GetInstancia().Suscribir(this);
            ActualizarIdioma(clsGestorIdioma.GetInstancia().IdiomaActual);
        }



        private void cmbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbmProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaTurno_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtObservaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            modoEdicion = false;
            limpiarCampos();
            habilitarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (modoEdicion == false)
            {
                clsTurnoBE turno = new clsTurnoBE();
                turno.IDPaciente = (int)cmbPaciente.SelectedValue;
                turno.IDProfesional = (int)cbmProfesional.SelectedValue;
                turno.FechaHora = dtpFechaTurno.Value;
                turno.Estado = EstadoTurnosBE.Pendiente;
                turno.Observaciones = txtObservaciones.Text;
                bool resultado = bllTurnos.Insert(turno);
                if (resultado == true)
                {
                    MessageBox.Show("Turno guardado con exitos");
                }
                else
                {
                    MessageBox.Show("Error al guardar el turno, revise los datos ingresados");
                }
            }
            cargarGrilla();
            bloquearCampos();
            limpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0) return;
            DialogResult confirm = MessageBox.Show("¿Está seguro que desea eliminar?",
                "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bllTurnos.Cancelar(idSeleccionado);
                cargarGrilla();
                bloquearCampos();
                limpiarCampos();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Seleccioná un turno primero");
                return;
            }
            bool resultado = bllTurnos.Confirmar(idSeleccionado);
            if (resultado)
                MessageBox.Show("Turno confirmado");
            else
                MessageBox.Show("No se pudo confirmar el turno");

            cargarGrilla();
            bloquearCampos();
            limpiarCampos();
        }

        private void btnCancelarForm_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            bloquearCampos();
            modoEdicion = false;
        }

        private void dgvTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvTurnos.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["IdTurno"].Value);
                cmbPaciente.SelectedValue = Convert.ToInt32(fila.Cells["IdPaciente"].Value);
                cbmProfesional.SelectedValue = Convert.ToInt32(fila.Cells["IdProfesional"].Value);
                dtpFechaTurno.Value = Convert.ToDateTime(fila.Cells["FechaHora"].Value);
                txtObservaciones.Text = fila.Cells["Observaciones"].Value.ToString();
                modoEdicion = true;
                habilitarCampos();
            }
        }

        //metodos para el formulario, carga de grilla, combos,etc.
        public void cargarComboEstado()
        {
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Confirmado");
            cmbEstado.Items.Add("Cancelado");
            cmbEstado.SelectedIndex = 0;
        }
        public void cargarComboPacientes()
        {
            cmbPaciente.DataSource = bllPaciente.GetAll();
            cmbPaciente.DisplayMember = "Nombre";
            cmbPaciente.ValueMember = "IdPersona";
        }
        public void cargarComboProfesionales()
        {
            cbmProfesional.DataSource = bllProfesional.GetAll();
            cbmProfesional.DisplayMember = "Nombre";
            cbmProfesional.ValueMember = "IdPersona";

        }
        public void cargarGrilla()
        {
            dgvTurnos.DataSource = bllTurnos.GetAll();
        }
        public void bloquearCampos()
        {
            cmbPaciente.Enabled = false;
            cbmProfesional.Enabled = false;
            cmbEstado.Enabled = false;
            dtpFechaTurno.Enabled = false;
            txtObservaciones.Enabled = false;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnConfirmar.Enabled = false;
        }
        public void habilitarCampos()
        {
            cmbPaciente.Enabled = true;
            cbmProfesional.Enabled = true;
            cmbEstado.Enabled = true;
            dtpFechaTurno.Enabled = true;
            txtObservaciones.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnConfirmar.Enabled = true;
        }
        public void personalizarGrilla()
        {
            // Estilo general
            dgvTurnos.EnableHeadersVisualStyles = false;
            dgvTurnos.BorderStyle = BorderStyle.None;
            dgvTurnos.GridColor = Color.FromArgb(220, 220, 220);
            dgvTurnos.BackgroundColor = Color.White;

            // Header
            dgvTurnos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 62, 80);
            dgvTurnos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTurnos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvTurnos.ColumnHeadersHeight = 35;

            // Filas
            dgvTurnos.DefaultCellStyle.BackColor = Color.White;
            dgvTurnos.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvTurnos.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvTurnos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvTurnos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTurnos.RowsDefaultCellStyle.BackColor = Color.White;
            dgvTurnos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvTurnos.RowTemplate.Height = 30;

            // Columnas
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void limpiarCampos()
        {
            txtObservaciones.Text = "";
            cargarComboPacientes();    
            cargarComboProfesionales();
            cmbEstado.SelectedIndex = 0;
            dtpFechaTurno.Value = DateTime.Now;
            idSeleccionado = 0;
        }

        private void frmTurnos_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGestorIdioma.GetInstancia().Desuscribir(this);
        }
        public void ActualizarIdioma(string idioma)
        {
            if (idioma == "es")
            {
                Turnos.Text = "Turnos";
                label1.Text = "Paciente";
                lblNombreProfesional.Text = "Profesional";
                label7.Text = "Fecha de turno";
                label2.Text = "Observaciones";
                btnNuevo.Text = "Nuevo";
                btnGuardar.Text = "Guardar";
                btnConfirmar.Text = "Confirmar";
                btnCancelar.Text = "Cancelar";
                btnCancelarForm.Text = "Cancelar Form";
                this.Text = "Turnos";

                if (dgvTurnos.Columns.Count > 0)
                {
                    dgvTurnos.Columns["IDTurno"].HeaderText = "ID";
                    dgvTurnos.Columns["IDPaciente"].HeaderText = "Paciente";
                    dgvTurnos.Columns["IDProfesional"].HeaderText = "Profesional";
                    dgvTurnos.Columns["FechaHora"].HeaderText = "Fecha y Hora";
                    dgvTurnos.Columns["Estado"].HeaderText = "Estado";
                    dgvTurnos.Columns["Observaciones"].HeaderText = "Observaciones";
                }
            }
            else if (idioma == "en")
            {
                Turnos.Text = "Appointments";
                label1.Text = "Patient";
                lblNombreProfesional.Text = "Professional";
                label7.Text = "Appointment Date";
                label2.Text = "Notes";
                btnNuevo.Text = "New";
                btnGuardar.Text = "Save";
                btnConfirmar.Text = "Confirm";
                btnCancelar.Text = "Cancel";
                btnCancelarForm.Text = "Cancel Form";
                this.Text = "Appointments";

                if (dgvTurnos.Columns.Count > 0)
                {
                    dgvTurnos.Columns["IDTurno"].HeaderText = "ID";
                    dgvTurnos.Columns["IDPaciente"].HeaderText = "Patient";
                    dgvTurnos.Columns["IDProfesional"].HeaderText = "Professional";
                    dgvTurnos.Columns["FechaHora"].HeaderText = "Date & Time";
                    dgvTurnos.Columns["Estado"].HeaderText = "Status";
                    dgvTurnos.Columns["Observaciones"].HeaderText = "Notes";
                }
            }
        }
    }
}

