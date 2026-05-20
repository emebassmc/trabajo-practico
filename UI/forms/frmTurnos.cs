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
    public partial class frmTurnos : Form
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

        public void limpiarCampos()
        {
            txtObservaciones.Text = "";
            cargarComboPacientes();    
            cargarComboProfesionales();
            cmbEstado.SelectedIndex = 0;
            dtpFechaTurno.Value = DateTime.Now;
            idSeleccionado = 0;
        }
    }
}

