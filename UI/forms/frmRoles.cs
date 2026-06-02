using BE;
using BLL;
using System;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmRoles : Form
    {
        clsRolBLL bllRol = new clsRolBLL();

        public frmRoles()
        {
            InitializeComponent();
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            cargarArbol();
            cargarComboPadre();
        }

        private void cargarArbol()
        {
            trvRoles.Nodes.Clear();
            clsRolComponente arbol = bllRol.GetArbol();
            TreeNode raiz = new TreeNode(arbol.Nombre);
            AgregarNodos(raiz, (clsRolGrupo)arbol);
            trvRoles.Nodes.Add(raiz);
            trvRoles.ExpandAll();
        }

        private void AgregarNodos(TreeNode nodo, clsRolGrupo grupo)
        {
            foreach (var hijo in grupo.Hijos)
            {
                TreeNode nuevoNodo = new TreeNode(hijo.Nombre);
                nuevoNodo.Tag = hijo;
                if (hijo is clsRolGrupo)
                    AgregarNodos(nuevoNodo, (clsRolGrupo)hijo);
                nodo.Nodes.Add(nuevoNodo);
            }
        }

        private void cargarComboPadre()
        {
            cboPadre.DataSource = bllRol.GetAll();
            cboPadre.DisplayMember = "Nombre";
            cboPadre.ValueMember = "IdRol";
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            cargarArbol();
            cargarComboPadre();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text)) return;
            clsRolBE rol = new clsRolBE();
            rol.Nombre = txtNombre.Text;
            rol.IdRolPadre = cboPadre.SelectedValue != null
                ? (int?)Convert.ToInt32(cboPadre.SelectedValue)
                : null;
            bllRol.Insert(rol);
            cargarArbol();
            cargarComboPadre();
            txtNombre.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (trvRoles.SelectedNode == null) return;
            if (trvRoles.SelectedNode.Tag == null) return;
            clsRolComponente rol = (clsRolComponente)trvRoles.SelectedNode.Tag;
            // buscar el id en la lista
            var lista = bllRol.GetAll();
            var encontrado = lista.Find(r => r.Nombre == rol.Nombre);
            if (encontrado != null)
            {
                bllRol.Delete(encontrado.IdRol);
                cargarArbol();
                cargarComboPadre();
            }
        }

        private void trvRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
                txtNombre.Text = e.Node.Text;
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void cboPadre_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}