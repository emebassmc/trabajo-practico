namespace UI.forms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnActualizarAsignacion = new System.Windows.Forms.Button();
            this.btnEliminarGrupo = new System.Windows.Forms.Button();
            this.btnCrearGrupo = new System.Windows.Forms.Button();
            this.chkLstRoles = new System.Windows.Forms.CheckedListBox();
            this.trvRoles = new System.Windows.Forms.TreeView();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGuardarUsuario = new System.Windows.Forms.Button();
            this.chkLstRolesUsuario = new System.Windows.Forms.CheckedListBox();
            this.lstUsuarios = new System.Windows.Forms.ListBox();
            this.lblGrupos = new System.Windows.Forms.Label();
            this.lblPermisos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1101, 550);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblPermisos);
            this.tabPage1.Controls.Add(this.lblGrupos);
            this.tabPage1.Controls.Add(this.txtNombre);
            this.tabPage1.Controls.Add(this.btnActualizarAsignacion);
            this.tabPage1.Controls.Add(this.btnEliminarGrupo);
            this.tabPage1.Controls.Add(this.btnCrearGrupo);
            this.tabPage1.Controls.Add(this.chkLstRoles);
            this.tabPage1.Controls.Add(this.trvRoles);
            this.tabPage1.Controls.Add(this.lstGrupos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1093, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grupos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(590, 487);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 13;
            // 
            // btnActualizarAsignacion
            // 
            this.btnActualizarAsignacion.Location = new System.Drawing.Point(509, 485);
            this.btnActualizarAsignacion.Name = "btnActualizarAsignacion";
            this.btnActualizarAsignacion.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarAsignacion.TabIndex = 12;
            this.btnActualizarAsignacion.Text = "Actualizar";
            this.btnActualizarAsignacion.UseVisualStyleBackColor = true;
            this.btnActualizarAsignacion.Click += new System.EventHandler(this.btnGuardarAsignacion_Click);
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.Location = new System.Drawing.Point(428, 485);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarGrupo.TabIndex = 11;
            this.btnEliminarGrupo.Text = "Eliminar";
            this.btnEliminarGrupo.UseVisualStyleBackColor = true;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.Location = new System.Drawing.Point(347, 485);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(75, 23);
            this.btnCrearGrupo.TabIndex = 10;
            this.btnCrearGrupo.Text = "Crear";
            this.btnCrearGrupo.UseVisualStyleBackColor = true;
            this.btnCrearGrupo.Click += new System.EventHandler(this.btnCrearGrupo_Click);
            // 
            // chkLstRoles
            // 
            this.chkLstRoles.FormattingEnabled = true;
            this.chkLstRoles.Location = new System.Drawing.Point(732, 41);
            this.chkLstRoles.Name = "chkLstRoles";
            this.chkLstRoles.Size = new System.Drawing.Size(334, 469);
            this.chkLstRoles.TabIndex = 9;
            this.chkLstRoles.SelectedIndexChanged += new System.EventHandler(this.chkLstRoles_SelectedIndexChanged);
            // 
            // trvRoles
            // 
            this.trvRoles.Location = new System.Drawing.Point(326, 6);
            this.trvRoles.Name = "trvRoles";
            this.trvRoles.Size = new System.Drawing.Size(400, 473);
            this.trvRoles.TabIndex = 8;
            // 
            // lstGrupos
            // 
            this.lstGrupos.FormattingEnabled = true;
            this.lstGrupos.Location = new System.Drawing.Point(4, 38);
            this.lstGrupos.Name = "lstGrupos";
            this.lstGrupos.Size = new System.Drawing.Size(316, 472);
            this.lstGrupos.TabIndex = 7;
            this.lstGrupos.SelectedIndexChanged += new System.EventHandler(this.lstGrupos_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnGuardarUsuario);
            this.tabPage2.Controls.Add(this.chkLstRolesUsuario);
            this.tabPage2.Controls.Add(this.lstUsuarios);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1093, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Usuarios";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnGuardarUsuario
            // 
            this.btnGuardarUsuario.Location = new System.Drawing.Point(511, 9);
            this.btnGuardarUsuario.Name = "btnGuardarUsuario";
            this.btnGuardarUsuario.Size = new System.Drawing.Size(90, 35);
            this.btnGuardarUsuario.TabIndex = 2;
            this.btnGuardarUsuario.Text = "Guardar";
            this.btnGuardarUsuario.UseVisualStyleBackColor = true;
            this.btnGuardarUsuario.Click += new System.EventHandler(this.btnGuardarUsuario_Click);
            // 
            // chkLstRolesUsuario
            // 
            this.chkLstRolesUsuario.FormattingEnabled = true;
            this.chkLstRolesUsuario.Location = new System.Drawing.Point(607, 33);
            this.chkLstRolesUsuario.Name = "chkLstRolesUsuario";
            this.chkLstRolesUsuario.Size = new System.Drawing.Size(478, 484);
            this.chkLstRolesUsuario.TabIndex = 1;
            // 
            // lstUsuarios
            // 
            this.lstUsuarios.FormattingEnabled = true;
            this.lstUsuarios.Location = new System.Drawing.Point(8, 29);
            this.lstUsuarios.Name = "lstUsuarios";
            this.lstUsuarios.Size = new System.Drawing.Size(499, 485);
            this.lstUsuarios.TabIndex = 0;
            this.lstUsuarios.SelectedIndexChanged += new System.EventHandler(this.lstUsuarios_SelectedIndexChanged);
            // 
            // lblGrupos
            // 
            this.lblGrupos.AutoSize = true;
            this.lblGrupos.Location = new System.Drawing.Point(6, 22);
            this.lblGrupos.Name = "lblGrupos";
            this.lblGrupos.Size = new System.Drawing.Size(41, 13);
            this.lblGrupos.TabIndex = 14;
            this.lblGrupos.Text = "Grupos";
            // 
            // lblPermisos
            // 
            this.lblPermisos.AutoSize = true;
            this.lblPermisos.Location = new System.Drawing.Point(732, 21);
            this.lblPermisos.Name = "lblPermisos";
            this.lblPermisos.Size = new System.Drawing.Size(49, 13);
            this.lblPermisos.TabIndex = 15;
            this.lblPermisos.Text = "Permisos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuarios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(607, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Roles asignado al usuario:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 550);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "TurnoSync | ABM Roles";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnActualizarAsignacion;
        private System.Windows.Forms.Button btnEliminarGrupo;
        private System.Windows.Forms.Button btnCrearGrupo;
        private System.Windows.Forms.CheckedListBox chkLstRoles;
        private System.Windows.Forms.TreeView trvRoles;
        private System.Windows.Forms.ListBox lstGrupos;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnGuardarUsuario;
        private System.Windows.Forms.CheckedListBox chkLstRolesUsuario;
        private System.Windows.Forms.ListBox lstUsuarios;
        private System.Windows.Forms.Label lblPermisos;
        private System.Windows.Forms.Label lblGrupos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}