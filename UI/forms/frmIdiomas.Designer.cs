namespace UI.forms
{
    partial class frmIdiomas
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
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tabIdiomas = new System.Windows.Forms.TabPage();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lstIdiomas = new System.Windows.Forms.ListBox();
            this.tabTraducciones = new System.Windows.Forms.TabPage();
            this.btnEscanearForms = new System.Windows.Forms.Button();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.lblTexto = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.btnEliminarClave = new System.Windows.Forms.Button();
            this.btnGuardarTraduccion = new System.Windows.Forms.Button();
            this.btnAgregarClave = new System.Windows.Forms.Button();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.dgvTraducciones = new System.Windows.Forms.DataGridView();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabMenu.SuspendLayout();
            this.tabIdiomas.SuspendLayout();
            this.tabTraducciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.tabIdiomas);
            this.tabMenu.Controls.Add(this.tabTraducciones);
            this.tabMenu.Location = new System.Drawing.Point(12, 12);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(687, 464);
            this.tabMenu.TabIndex = 0;
            // 
            // tabIdiomas
            // 
            this.tabIdiomas.Controls.Add(this.btnEliminar);
            this.tabIdiomas.Controls.Add(this.btnEditar);
            this.tabIdiomas.Controls.Add(this.btnAgregar);
            this.tabIdiomas.Controls.Add(this.lblNombre);
            this.tabIdiomas.Controls.Add(this.lblCodigo);
            this.tabIdiomas.Controls.Add(this.txtNombre);
            this.tabIdiomas.Controls.Add(this.txtCodigo);
            this.tabIdiomas.Controls.Add(this.lstIdiomas);
            this.tabIdiomas.Location = new System.Drawing.Point(4, 22);
            this.tabIdiomas.Name = "tabIdiomas";
            this.tabIdiomas.Padding = new System.Windows.Forms.Padding(3);
            this.tabIdiomas.Size = new System.Drawing.Size(679, 438);
            this.tabIdiomas.TabIndex = 0;
            this.tabIdiomas.Text = "Idiomas";
            this.tabIdiomas.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(226, 88);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(88, 26);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Baja";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(132, 88);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(88, 26);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "Modificion";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(38, 88);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(88, 26);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Alta";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(35, 52);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(35, 26);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 11;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(85, 49);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(85, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 9;
            // 
            // lstIdiomas
            // 
            this.lstIdiomas.FormattingEnabled = true;
            this.lstIdiomas.Location = new System.Drawing.Point(349, 26);
            this.lstIdiomas.Name = "lstIdiomas";
            this.lstIdiomas.Size = new System.Drawing.Size(289, 381);
            this.lstIdiomas.TabIndex = 8;
            this.lstIdiomas.Click += new System.EventHandler(this.lstIdiomas_SelectedIndexChanged);
            // 
            // tabTraducciones
            // 
            this.tabTraducciones.Controls.Add(this.button1);
            this.tabTraducciones.Controls.Add(this.btnEscanearForms);
            this.tabTraducciones.Controls.Add(this.lblSeleccionarIdioma);
            this.tabTraducciones.Controls.Add(this.lblTexto);
            this.tabTraducciones.Controls.Add(this.lblClave);
            this.tabTraducciones.Controls.Add(this.btnEliminarClave);
            this.tabTraducciones.Controls.Add(this.btnGuardarTraduccion);
            this.tabTraducciones.Controls.Add(this.btnAgregarClave);
            this.tabTraducciones.Controls.Add(this.txtTexto);
            this.tabTraducciones.Controls.Add(this.txtClave);
            this.tabTraducciones.Controls.Add(this.dgvTraducciones);
            this.tabTraducciones.Controls.Add(this.cmbIdioma);
            this.tabTraducciones.Location = new System.Drawing.Point(4, 22);
            this.tabTraducciones.Name = "tabTraducciones";
            this.tabTraducciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabTraducciones.Size = new System.Drawing.Size(679, 438);
            this.tabTraducciones.TabIndex = 1;
            this.tabTraducciones.Text = "Traducciones";
            this.tabTraducciones.UseVisualStyleBackColor = true;
            // 
            // btnEscanearForms
            // 
            this.btnEscanearForms.Location = new System.Drawing.Point(598, 6);
            this.btnEscanearForms.Name = "btnEscanearForms";
            this.btnEscanearForms.Size = new System.Drawing.Size(75, 23);
            this.btnEscanearForms.TabIndex = 17;
            this.btnEscanearForms.Text = "Escanear";
            this.btnEscanearForms.UseVisualStyleBackColor = true;
            this.btnEscanearForms.Click += new System.EventHandler(this.btnEscanearForms_Click);
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(7, 13);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(99, 13);
            this.lblSeleccionarIdioma.TabIndex = 9;
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Location = new System.Drawing.Point(7, 70);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(34, 13);
            this.lblTexto.TabIndex = 8;
            this.lblTexto.Text = "Texto";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(7, 42);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(26, 13);
            this.lblClave.TabIndex = 7;
            this.lblClave.Text = "Tag";
            // 
            // btnEliminarClave
            // 
            this.btnEliminarClave.Location = new System.Drawing.Point(171, 93);
            this.btnEliminarClave.Name = "btnEliminarClave";
            this.btnEliminarClave.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarClave.TabIndex = 6;
            this.btnEliminarClave.Text = "Eliminar";
            this.btnEliminarClave.UseVisualStyleBackColor = true;
            this.btnEliminarClave.Click += new System.EventHandler(this.btnEliminarClave_Click);
            // 
            // btnGuardarTraduccion
            // 
            this.btnGuardarTraduccion.Location = new System.Drawing.Point(90, 93);
            this.btnGuardarTraduccion.Name = "btnGuardarTraduccion";
            this.btnGuardarTraduccion.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarTraduccion.TabIndex = 5;
            this.btnGuardarTraduccion.Text = "Guardar";
            this.btnGuardarTraduccion.UseVisualStyleBackColor = true;
            this.btnGuardarTraduccion.Click += new System.EventHandler(this.btnGuardarTraduccion_Click);
            // 
            // btnAgregarClave
            // 
            this.btnAgregarClave.Location = new System.Drawing.Point(9, 93);
            this.btnAgregarClave.Name = "btnAgregarClave";
            this.btnAgregarClave.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarClave.TabIndex = 4;
            this.btnAgregarClave.Text = "Agregar";
            this.btnAgregarClave.UseVisualStyleBackColor = true;
            this.btnAgregarClave.Click += new System.EventHandler(this.btnAgregarClave_Click);
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(47, 67);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(100, 20);
            this.txtTexto.TabIndex = 3;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(39, 39);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(100, 20);
            this.txtClave.TabIndex = 2;
            // 
            // dgvTraducciones
            // 
            this.dgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraducciones.Location = new System.Drawing.Point(9, 133);
            this.dgvTraducciones.Name = "dgvTraducciones";
            this.dgvTraducciones.Size = new System.Drawing.Size(664, 299);
            this.dgvTraducciones.TabIndex = 1;
            this.dgvTraducciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraducciones_CellContentClick);
            // 
            // cmbIdioma
            // 
            this.cmbIdioma.FormattingEnabled = true;
            this.cmbIdioma.Location = new System.Drawing.Point(112, 10);
            this.cmbIdioma.Name = "cmbIdioma";
            this.cmbIdioma.Size = new System.Drawing.Size(100, 21);
            this.cmbIdioma.TabIndex = 0;
            this.cmbIdioma.SelectedIndexChanged += new System.EventHandler(this.cmbIdioma_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Exportar Idiomas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 479);
            this.Controls.Add(this.tabMenu);
            this.Name = "frmIdiomas";
            this.Text = "frmIdiomas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmIdiomas_FormClosed);
            this.Load += new System.EventHandler(this.frmIdiomas_Shown);
            this.Shown += new System.EventHandler(this.frmIdiomas_Shown);
            this.tabMenu.ResumeLayout(false);
            this.tabIdiomas.ResumeLayout(false);
            this.tabIdiomas.PerformLayout();
            this.tabTraducciones.ResumeLayout(false);
            this.tabTraducciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage tabIdiomas;
        private System.Windows.Forms.TabPage tabTraducciones;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ListBox lstIdiomas;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Button btnEliminarClave;
        private System.Windows.Forms.Button btnGuardarTraduccion;
        private System.Windows.Forms.Button btnAgregarClave;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.DataGridView dgvTraducciones;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
        private System.Windows.Forms.Button btnEscanearForms;
        private System.Windows.Forms.Button button1;
    }
}