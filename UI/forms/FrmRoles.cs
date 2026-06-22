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
        clsRolBLL bll = new clsRolBLL();
        clsUsuarioBLL usuarioBLL = new clsUsuarioBLL();
        clsRolBE rol;
        private bool _actualizandoChecks = false;
        bool puedeCrear, puedeEliminar, puedeAsignar;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text)) return;

                clsRolBE rol = new clsRolBE();
                rol.Nombre = txtNombre.Text;
                rol.EsGrupo = true;
                clsRolBE sistema = bll.GetAll().Find(r => r.Nombre == "Sistema");
                if (sistema == null)
                {
                    MessageBox.Show("No se encontró el rol Sistema en la base de datos.");
                    return;
                }
                rol.IdRolPadre = sistema.IdRol;

                bll.Insert(rol);

                clsRolBE creado = bll.GetAll()
                    .Where(r => r.Nombre == rol.Nombre && r.EsGrupo == rol.EsGrupo)
                    .OrderByDescending(r => r.IdRol)
                    .FirstOrDefault();
                if (creado != null)
                    bll.AsignarPermiso(sistema.IdRol, creado.IdRol);

                txtNombre.Text = "";
                cargarGrupos();
                CargarArbolPermisos();
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
                    CargarArbolPermisos();
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

                foreach (TreeNode raiz in trvPermisos.Nodes)
                    foreach (TreeNode hijo in raiz.Nodes)
                        GuardarChecksRecursivo(hijo, grupo.IdRol);

                cargarGrupos();
                CargarArbolPermisos();
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

 
        private void CargarArbolPermisos()
        {
            trvPermisos.Nodes.Clear();
            clsComponenteRol raiz = bll.GetArbol();
            if (raiz == null) return;

            TreeNode nodoRaiz = new TreeNode(raiz.Nombre);
            nodoRaiz.Tag = raiz.IdRol;
            if (raiz is csRolGrupo)
                AgregarNodosPermiso(nodoRaiz, (csRolGrupo)raiz, new HashSet<int> { raiz.IdRol });

            trvPermisos.Nodes.Add(nodoRaiz);
            trvPermisos.ExpandAll();
            CargarRolesParaUsuario();
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

            _actualizandoChecks = true;
            foreach (TreeNode raiz in trvRolesUsuario.Nodes)
                MarcarAsignados(raiz, rolesAsignados);
            _actualizandoChecks = false;
        }

        // Este guarda los cambios cuando apretás el botón
        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedItem == null) return;
            clsUsuarioBE usuario = lstUsuarios.SelectedItem as clsUsuarioBE;

            foreach (TreeNode raiz in trvRolesUsuario.Nodes)
                foreach (TreeNode hijo in raiz.Nodes)
                    GuardarRolUsuarioRecursivo(hijo, usuario.IdUsuario);

            CargarUsuarios();
        }
        private void GuardarRolUsuarioRecursivo(TreeNode nodo, int idUsuario)
        {
            int idRol = (int)nodo.Tag;
            clsRolBE rolNodo = bll.GetAll().Find(r => r.IdRol == idRol);

            if (rolNodo != null && rolNodo.EsGrupo)
            {
                if (nodo.Checked)
                    bll.AsignarARol(idUsuario, idRol);
                else
                    bll.QuitarRolUsuario(idUsuario, idRol);
            }

            foreach (TreeNode hijo in nodo.Nodes)
                GuardarRolUsuarioRecursivo(hijo, idUsuario);
        }
        private void CargarRolesParaUsuario()
        {
            trvRolesUsuario.Nodes.Clear();
            clsComponenteRol raiz = bll.GetArbol();
            if (raiz == null) return;

            TreeNode nodoRaiz = new TreeNode(raiz.Nombre);
            nodoRaiz.Tag = raiz.IdRol;
            if (raiz is csRolGrupo)
                AgregarNodosPermiso(nodoRaiz, (csRolGrupo)raiz, new HashSet<int> { raiz.IdRol });

            trvRolesUsuario.Nodes.Add(nodoRaiz);
            trvRolesUsuario.ExpandAll();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            int idUsuario = clsSesionActual.GetInstancia().IdUsuario;
            puedeCrear = bll.TienePermiso(idUsuario, "Roles.Crear");
            puedeEliminar = bll.TienePermiso(idUsuario, "Roles.Eliminar");
            puedeAsignar = bll.TienePermiso(idUsuario, "Roles.Asignar");

            btnCrearGrupo.Enabled = puedeCrear;
            btnEliminarGrupo.Enabled = puedeEliminar;
            btnActualizarAsignacion.Enabled = puedeAsignar;  // asignar permisos a grupos
            btnGuardarUsuario.Enabled = puedeAsignar;     // asignar roles a usuarios

            cargarGrupos();
            CargarArbolPermisos();           
            CargarUsuarios();
            clsGestorIdioma.GetInstancia().Suscribir(this);
            ActualizarIdioma(clsGestorIdioma.GetInstancia().IdiomaActual);
        }
        private void trvPermisos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (_actualizandoChecks) return;
            _actualizandoChecks = true;
            MarcarHijos(e.Node, e.Node.Checked);
            _actualizandoChecks = false;
        }

        private void MarcarHijos(TreeNode nodo, bool valor)
        {
            foreach (TreeNode hijo in nodo.Nodes)
            {
                hijo.Checked = valor;
                MarcarHijos(hijo, valor);
            }
        }
        private void lstGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem == null) return;
            clsRolBE grupo = lstGrupos.SelectedItem as clsRolBE;

            List<clsRolBE> permisosAsignados = bll.GetPermisosPorRol(grupo.IdRol);

            _actualizandoChecks = true;
            foreach (TreeNode raiz in trvPermisos.Nodes)
                MarcarAsignados(raiz, permisosAsignados);
            _actualizandoChecks = false;
        }

        private void MarcarAsignados(TreeNode nodo, List<clsRolBE> asignados)
        {
            int idNodo = (int)nodo.Tag;
            nodo.Checked = asignados.Any(p => p.IdRol == idNodo);
            foreach (TreeNode hijo in nodo.Nodes)
                MarcarAsignados(hijo, asignados);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGestorIdioma.GetInstancia().Desuscribir(this);

        }
        public void ActualizarIdioma(string idioma)
        {
            var g = clsGestorIdioma.GetInstancia();

            tabPage1.Text = g.Traducir("tabGrupos");
            tabPage2.Text = g.Traducir("tabUsuarios");
            btnCrearGrupo.Text = g.Traducir("btnCrear");
            btnEliminarGrupo.Text = g.Traducir("btnEliminar");
            btnActualizarAsignacion.Text = g.Traducir("btnActualizar");
            btnGuardarUsuario.Text = g.Traducir("btnGuardar");
            this.Text = g.Traducir("titleRoles");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AgregarNodosPermiso(TreeNode nodo, csRolGrupo grupo, HashSet<int> ramaActual)
        {
            foreach (clsComponenteRol hijo in grupo.Hijos)
            {
                if (ramaActual.Contains(hijo.IdRol)) continue;

                TreeNode nuevoNodo = new TreeNode(hijo.Nombre);
                nuevoNodo.Tag = hijo.IdRol;

                if (hijo is csRolGrupo)
                {
                    HashSet<int> nuevaRama = new HashSet<int>(ramaActual);
                    nuevaRama.Add(hijo.IdRol);
                    AgregarNodosPermiso(nuevoNodo, (csRolGrupo)hijo, nuevaRama);
                }

                nodo.Nodes.Add(nuevoNodo);
            }
        }
        private void GuardarChecksRecursivo(TreeNode nodo, int idGrupo)
        {
            int idPermiso = (int)nodo.Tag;
            if (idPermiso != idGrupo && nodo.Checked)
                bll.AsignarPermiso(idGrupo, idPermiso);
            foreach (TreeNode hijo in nodo.Nodes)
                GuardarChecksRecursivo(hijo, idGrupo);
        }
    }
}

