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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPacientes frm = new frmPacientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void aBMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTurnos frm = new frmTurnos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEspecialidad frm = new frmEspecialidad();
            frm.MdiParent = this;
            frm.Show();
        }

        private void profesionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfesional frm = new frmProfesional();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacora frm = new frmBitacora();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoles frm = new frmRoles();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
