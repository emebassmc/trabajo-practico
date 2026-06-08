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
using UI.forms;

namespace UI
{
    public partial class frmPrincipal : Form , IObservadorIdioma
    {
        clsRolBLL rolBll = new clsRolBLL();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (!rolBll.TienePermiso(clsSesionActual.GetInstancia().IdUsuario, "GestionPacientes"))
            {
                MessageBox.Show("Sin permisos.");
                return;
            }
            frmPacientes frm = new frmPacientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void aBMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rolBll.TienePermiso(clsSesionActual.GetInstancia().IdUsuario, "GestionTurnos"))
            {
                MessageBox.Show("Sin permisos.");
                return;
            }
            frmTurnos frm = new frmTurnos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rolBll.TienePermiso(clsSesionActual.GetInstancia().IdUsuario, "GestionEspecialidades"))
            {
                MessageBox.Show("Sin permisos.");
                return;
            }
            frmEspecialidad frm = new frmEspecialidad();
            frm.MdiParent = this;
            frm.Show();
        }

        private void profesionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rolBll.TienePermiso(clsSesionActual.GetInstancia().IdUsuario, "GestionProfesionales"))
            {
                MessageBox.Show("Sin permisos.");
                return;
            }
            frmProfesional frm = new frmProfesional();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rolBll.TienePermiso(clsSesionActual.GetInstancia().IdUsuario, "GestionBitacora"))
            {
                MessageBox.Show("Sin permisos.");
                return;
            }
            frmBitacora frm = new frmBitacora();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rolBll.TienePermiso(clsSesionActual.GetInstancia().IdUsuario, "GestionRoles"))
            {
                MessageBox.Show("Sin permisos.");
                return;
            }
            Form1 frm = new Form1 ();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            clsGestorIdioma.GetInstancia().Suscribir(this);
            ActualizarIdioma(clsGestorIdioma.GetInstancia().IdiomaActual);
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rolBll.TienePermiso(clsSesionActual.GetInstancia().IdUsuario, "GestionUsuarios"))
            {
                MessageBox.Show("Sin permisos.");
                return;
            }
            frmUsuario frm = new frmUsuario();
            frm.MdiParent = this;
            frm.Show();
        }
        public void ActualizarIdioma(string idioma)
        {
            if (idioma == "es")
            {
                inicioToolStripMenuItem.Text = "Gestiones";
                informesToolStripMenuItem.Text = "Informes";
                salirToolStripMenuItem.Text = "Salir";
                pacientesToolStripMenuItem.Text = "Pacientes";
                especialidadesToolStripMenuItem.Text = "Especialidades";
                profesionalesToolStripMenuItem.Text = "Profesionales";
                aBMToolStripMenuItem.Text = "Turnos";
                rolesToolStripMenuItem.Text = "Roles";
                usuariosToolStripMenuItem.Text = "Usuarios";
                bitacoraToolStripMenuItem.Text = "Bitácora";
                consultasToolStripMenuItem.Text = "Consultas";
            }
            else if (idioma == "en")
            {
                inicioToolStripMenuItem.Text = "Management";
                informesToolStripMenuItem.Text = "Reports";
                salirToolStripMenuItem.Text = "Exit";
                pacientesToolStripMenuItem.Text = "Patients";
                especialidadesToolStripMenuItem.Text = "Specialties";
                profesionalesToolStripMenuItem.Text = "Professionals";
                aBMToolStripMenuItem.Text = "Appointments";
                rolesToolStripMenuItem.Text = "Roles";
                usuariosToolStripMenuItem.Text = "Users";
                bitacoraToolStripMenuItem.Text = "Activity Log";
                consultasToolStripMenuItem.Text = "Queries";
            }
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGestorIdioma.GetInstancia().Desuscribir(this);
        }
    }
     
}
