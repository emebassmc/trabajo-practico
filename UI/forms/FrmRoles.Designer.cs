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
            this.btnGuardarAsignacion = new System.Windows.Forms.Button();
            this.btnEliminarGrupo = new System.Windows.Forms.Button();
            this.btnCrearGrupo = new System.Windows.Forms.Button();
            this.chkLstRoles = new System.Windows.Forms.CheckedListBox();
            this.trvRoles = new System.Windows.Forms.TreeView();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGuardarUsuario = new System.Windows.Forms.Button();
            this.chkLstRolesUsuario = new System.Windows.Forms.CheckedListBox();
            this.lstUsuarios = new System.Windows.Forms.ListBox();
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
            this.tabPage1.Controls.Add(this.txtNombre);
            this.tabPage1.Controls.Add(this.btnGuardarAsignacion);
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
            // btnGuardarAsignacion
            // 
            this.btnGuardarAsignacion.Location = new System.Drawing.Point(509, 485);
            this.btnGuardarAsignacion.Name = "btnGuardarAsignacion";
            this.btnGuardarAsignacion.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarAsignacion.TabIndex = 12;
            this.btnGuardarAsignacion.Text = "Guardar";
            this.btnGuardarAsignacion.UseVisualStyleBackColor = true;
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.Location = new System.Drawing.Point(428, 485);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarGrupo.TabIndex = 11;
            this.btnEliminarGrupo.Text = "Eliminar";
            this.btnEliminarGrupo.UseVisualStyleBackColor = true;
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.Location = new System.Drawing.Point(347, 485);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(75, 23);
            this.btnCrearGrupo.TabIndex = 10;
            this.btnCrearGrupo.Text = "Crear";
            this.btnCrearGrupo.UseVisualStyleBackColor = true;
            // 
            // chkLstRoles
            // 
            this.chkLstRoles.FormattingEnabled = true;
            this.chkLstRoles.Location = new System.Drawing.Point(732, 11);
            this.chkLstRoles.Name = "chkLstRoles";
            this.chkLstRoles.Size = new System.Drawing.Size(334, 499);
            this.chkLstRoles.TabIndex = 9;
            // 
            // trvRoles
            // 
            this.trvRoles.CheckBoxes = true;
            this.trvRoles.Location = new System.Drawing.Point(326, 12);
            this.trvRoles.Name = "trvRoles";
            this.trvRoles.Size = new System.Drawing.Size(400, 467);
            this.trvRoles.TabIndex = 8;
            // 
            // lstGrupos
            // 
            this.lstGrupos.FormattingEnabled = true;
            this.lstGrupos.Location = new System.Drawing.Point(4, 12);
            this.lstGrupos.Name = "lstGrupos";
            this.lstGrupos.Size = new System.Drawing.Size(316, 498);
            this.lstGrupos.TabIndex = 7;
            // 
            // tabPage2
            // 
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
            this.chkLstRolesUsuario.Location = new System.Drawing.Point(607, 3);
            this.chkLstRolesUsuario.Name = "chkLstRolesUsuario";
            this.chkLstRolesUsuario.Size = new System.Drawing.Size(478, 514);
            this.chkLstRolesUsuario.TabIndex = 1;
            // 
            // lstUsuarios
            // 
            this.lstUsuarios.FormattingEnabled = true;
            this.lstUsuarios.Location = new System.Drawing.Point(8, 3);
            this.lstUsuarios.Name = "lstUsuarios";
            this.lstUsuarios.Size = new System.Drawing.Size(499, 511);
            this.lstUsuarios.TabIndex = 0;
            this.lstUsuarios.SelectedIndexChanged += new System.EventHandler(this.lstUsuarios_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 550);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "frmRoles";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardarAsignacion;
        private System.Windows.Forms.Button btnEliminarGrupo;
        private System.Windows.Forms.Button btnCrearGrupo;
        private System.Windows.Forms.CheckedListBox chkLstRoles;
        private System.Windows.Forms.TreeView trvRoles;
        private System.Windows.Forms.ListBox lstGrupos;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnGuardarUsuario;
        private System.Windows.Forms.CheckedListBox chkLstRolesUsuario;
        private System.Windows.Forms.ListBox lstUsuarios;
    }
}