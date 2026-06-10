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
    public partial class Form1 : Form, IObservadorIdioma
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
                clsRolBE sistema = bll.GetAll().Find(r => r.Nombre == "Sistema");
                if (sistema == null)
                {
                    MessageBox.Show("No se encontró el rol Sistema en la base de datos.");
                    return;
                }
                rol.IdRolPadre = sistema.IdRol;

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

                rol = lstGrupos.SelectedItem as clsRolBE;

                if (rol.Nombre == "Sistema" || rol.Nombre == "Administrador" ||
                    rol.Nombre == "Recepcionista" || rol.Nombre == "Medico")
                {
                    MessageBox.Show("No podés eliminar un rol del sistema.");
                    return;
                }

                List<clsRolBE> hijos = bll.GetAll().FindAll(r => r.IdRolPadre == rol.IdRol);
                string msgHijos = hijos.Count > 0
                    ? "\nEste rol tiene " + hijos.Count + " permisos hijos que quedarán sin padre:\n" +
                      string.Join(", ", hijos.Select(h => h.Nombre))
                    : "";

                DialogResult confirm = MessageBox.Show(
                    "¿Eliminás el rol '" + rol.Nombre + "'?" + msgHijos,
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
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
                if (lstGrupos.SelectedItem == null)
                {
                    MessageBox.Show("Seleccioná un grupo primero.");
                    return;
                }

                clsRolBE grupo = lstGrupos.SelectedItem as clsRolBE;

                if (grupo.Nombre == "Sistema")
                {
                    MessageBox.Show("No podés asignar permisos directamente a Sistema.");
                    return;
                }

                // Recorrer TODOS los items del checklist
                for (int i = 0; i < chkLstRoles.Items.Count; i++)
                {
                    clsRolBE permiso = chkLstRoles.Items[i] as clsRolBE;
                    if (chkLstRoles.GetItemChecked(i))
                        bll.AsignarPermiso(grupo.IdRol, permiso.IdRol);
                    else
                        bll.QuitarPermiso(grupo.IdRol, permiso.IdRol);
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
            List<clsRolBE> todos = bll.GetAll();
            lstGrupos.DataSource = null;
            lstGrupos.DataSource = todos.Where(r => r.EsGrupo && r.Nombre != "Sistema").ToList();
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
            List<clsRolBE> lista = bll.GetAll().Where(r => !r.EsGrupo).ToList(); 
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
            clsGestorIdioma.GetInstancia().Suscribir(this);
            ActualizarIdioma(clsGestorIdioma.GetInstancia().IdiomaActual);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trvRoles.Enabled = false;            
        }

        private void chkLstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem == null) return;
            clsRolBE grupo = lstGrupos.SelectedItem as clsRolBE;

            List<clsRolBE> permisosAsignados = bll.GetPermisosPorRol(grupo.IdRol);

            for (int i = 0; i < chkLstRoles.Items.Count; i++)
            {
                clsRolBE rol = chkLstRoles.Items[i] as clsRolBE;
                bool estaAsignado = permisosAsignados.Any(p => p.IdRol == rol.IdRol);
                chkLstRoles.SetItemChecked(i, estaAsignado);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGestorIdioma.GetInstancia().Desuscribir(this);

        }
        public void ActualizarIdioma(string idioma)
        {
            if (idioma == "es")
            {
                tabPage1.Text = "Grupos";
                tabPage2.Text = "Usuarios";
                btnCrearGrupo.Text = "Crear";
                btnEliminarGrupo.Text = "Eliminar";
                btnActualizarAsignacion.Text = "Actualizar";
                btnGuardarUsuario.Text = "Guardar";
                this.Text = "Roles";
            }
            else if (idioma == "en")
            {
                tabPage1.Text = "Groups";
                tabPage2.Text = "Users";
                btnCrearGrupo.Text = "Create";
                btnEliminarGrupo.Text = "Delete";
                btnActualizarAsignacion.Text = "Update";
                btnGuardarUsuario.Text = "Save";
                this.Text = "Roles";
            }
        }
    }
}

