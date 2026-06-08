using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class Form1 : Form
    {
        clsRolBLL bll =new clsRolBLL();
        clsUsuarioBLL usuarioBLL =new clsUsuarioBLL();
        clsRolBE rol;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text)) return;

                DialogResult resp = MessageBox.Show(
                    "¿Es un grupo?",
                    "Tipo de rol",
                    MessageBoxButtons.YesNo);

                clsRolBE rol = new clsRolBE();
                rol.Nombre = txtNombre.Text;
                rol.EsGrupo = (resp == DialogResult.Yes);
                rol.IdRolPadre = null;

                bll.Insert(rol);
                txtNombre.Text = "";
                cargarGrupos();
                CargarArbol();
                CargarTodosLosRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminarGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstGrupos.SelectedItem == null)
                {
                    MessageBox.Show("Seleccioná un grupo primero.");
                    return;
                }
                else
                {
                    rol = lstGrupos.SelectedItem as clsRolBE;
                    bll.Delete(rol.IdRol);
                    cargarGrupos();
                    CargarArbol();
                    CargarTodosLosRoles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);   
            }
        }

        private void btnGuardarAsignacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstGrupos.SelectedItem == null) return;
                clsRolBE grupo = lstGrupos.SelectedItem as clsRolBE;
                foreach (object item in chkLstRoles.CheckedItems)
                {
                    clsRolBE rol = (clsRolBE)item;
                    rol.IdRolPadre = grupo.IdRol;
                    bll.Update(rol);
                }
                cargarGrupos();
                CargarArbol();
                CargarTodosLosRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void cargarGrupos()
        {
            List<clsRolBE> todos = bll.GetAll(); // ← faltaba esta línea
            lstGrupos.DataSource = null;
            lstGrupos.DataSource = todos.Where(r => r.EsGrupo).ToList(); // ← solo una vez
            lstGrupos.DisplayMember = "Nombre";
            lstGrupos.ValueMember = "IdRol";
        }
        private void CargarArbol()
        {
            trvRoles.Nodes.Clear();
            IComponenteRol raiz = bll.GetArbol();
            if (raiz == null) return;

            TreeNode nodoRaiz = new TreeNode(raiz.Nombre);
            nodoRaiz.Tag = raiz;

            if (raiz is csRolGrupo)
                AgregarNodos(nodoRaiz, (csRolGrupo)raiz);

            trvRoles.Nodes.Add(nodoRaiz);
            trvRoles.ExpandAll();
            trvRoles.Refresh();
        }

        private void AgregarNodos(TreeNode nodo, csRolGrupo grupo)
        {
            foreach (IComponenteRol hijo in grupo.Hijos)
            {
                TreeNode nuevoNodo = new TreeNode(hijo.Nombre);
                nuevoNodo.Tag = hijo;

                if (hijo is csRolGrupo)
                    AgregarNodos(nuevoNodo, (csRolGrupo)hijo);

                nodo.Nodes.Add(nuevoNodo);
            }
        }
        private void CargarTodosLosRoles()
        {
            chkLstRoles.Items.Clear();
            chkLstRoles.DisplayMember = "Nombre";
            List<clsRolBE> lista = bll.GetAll();
            foreach (clsRolBE rol in lista)
            {
                chkLstRoles.Items.Add(rol);
            }
        }
        private void CargarUsuarios()
        {
            lstUsuarios.DataSource = null;
            lstUsuarios.DataSource = usuarioBLL.GetAll();
            lstUsuarios.DisplayMember = "NombreUsuario";
            lstUsuarios.ValueMember = "IdUsuario";
        }

        // Este marca los checkboxes según lo que ya tiene asignado el usuario
        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedItem == null) return;
            clsUsuarioBE usuario = lstUsuarios.SelectedItem as clsUsuarioBE;
            List<clsRolBE> rolesAsignados = bll.GetRolesUsuario(usuario.IdUsuario);
            for (int i = 0; i < chkLstRolesUsuario.Items.Count; i++)
            {
                clsRolBE rol = chkLstRolesUsuario.Items[i] as clsRolBE;
                bool estaAsignado = rolesAsignados.Any(r => r.IdRol == rol.IdRol);
                chkLstRolesUsuario.SetItemChecked(i, estaAsignado);
            }
        }

        // Este guarda los cambios cuando apretás el botón
        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedItem == null) return;
            clsUsuarioBE usuario = lstUsuarios.SelectedItem as clsUsuarioBE;
            for (int i = 0; i < chkLstRolesUsuario.Items.Count; i++)
            {
                clsRolBE rol = chkLstRolesUsuario.Items[i] as clsRolBE;
                if (chkLstRolesUsuario.GetItemChecked(i))
                    bll.AsignarARol(usuario.IdUsuario, rol.IdRol);
                else
                    bll.QuitarRolUsuario(usuario.IdUsuario, rol.IdRol);
            }
        }
        private void CargarRolesParaUsuario()
        {
            chkLstRolesUsuario.Items.Clear();
            chkLstRolesUsuario.DisplayMember = "Nombre";
            List<clsRolBE> lista = bll.GetAll();
            foreach (clsRolBE rol in lista)
            {
                chkLstRolesUsuario.Items.Add(rol);
            }
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            cargarGrupos();
            CargarArbol();
            CargarTodosLosRoles();
            CargarRolesParaUsuario();
            CargarUsuarios();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chkLstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem == null) return;
            clsRolBE grupo = lstGrupos.SelectedItem as clsRolBE;
            List<clsRolBE> todos = bll.GetAll();

            for (int i = 0; i < chkLstRoles.Items.Count; i++)
            {
                clsRolBE rol = chkLstRoles.Items[i] as clsRolBE;
                bool esHijo = rol.IdRolPadre.HasValue && rol.IdRolPadre.Value == grupo.IdRol;
                chkLstRoles.SetItemChecked(i, esHijo);
            }
        }
    }
}

