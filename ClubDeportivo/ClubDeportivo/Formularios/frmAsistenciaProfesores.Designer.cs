namespace ClubDeportivo.Formularios
{
    partial class frmAsistenciaProfesores
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblProfesor = new System.Windows.Forms.Label();
            this.cmbProfesor = new System.Windows.Forms.ComboBox();
            this.btnFirmar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblTitulo2 = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblTitulo3 = new System.Windows.Forms.Label();
            this.lblConsulta = new System.Windows.Forms.Label();
            this.dtpConsulta = new System.Windows.Forms.DateTimePicker();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvDelDia = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelDia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(17, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(173, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Firma de asistencia";
            // 
            // lblProfesor
            // 
            this.lblProfesor.AutoSize = true;
            this.lblProfesor.Location = new System.Drawing.Point(17, 48);
            this.lblProfesor.Name = "lblProfesor";
            this.lblProfesor.Size = new System.Drawing.Size(46, 13);
            this.lblProfesor.TabIndex = 1;
            this.lblProfesor.Text = "Profesor";
            // 
            // cmbProfesor
            // 
            this.cmbProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesor.FormattingEnabled = true;
            this.cmbProfesor.Location = new System.Drawing.Point(17, 62);
            this.cmbProfesor.Name = "cmbProfesor";
            this.cmbProfesor.Size = new System.Drawing.Size(275, 21);
            this.cmbProfesor.TabIndex = 2;
            this.cmbProfesor.SelectedIndexChanged += new System.EventHandler(this.CmbProfesor_SelectedIndexChanged);
            // 
            // btnFirmar
            // 
            this.btnFirmar.Location = new System.Drawing.Point(309, 62);
            this.btnFirmar.Name = "btnFirmar";
            this.btnFirmar.Size = new System.Drawing.Size(171, 26);
            this.btnFirmar.TabIndex = 3;
            this.btnFirmar.Text = "Firmar asistencia (hoy)";
            this.btnFirmar.UseVisualStyleBackColor = true;
            this.btnFirmar.Click += new System.EventHandler(this.BtnFirmar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(579, 62);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 26);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // lblTitulo2
            // 
            this.lblTitulo2.AutoSize = true;
            this.lblTitulo2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo2.Location = new System.Drawing.Point(17, 100);
            this.lblTitulo2.Name = "lblTitulo2";
            this.lblTitulo2.Size = new System.Drawing.Size(307, 25);
            this.lblTitulo2.TabIndex = 5;
            this.lblTitulo2.Text = "Historial del profesor seleccionado";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(17, 130);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowTemplate.Height = 25;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(643, 202);
            this.dgvHistorial.TabIndex = 6;
            this.dgvHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorial_CellContentClick);
            // 
            // lblTitulo3
            // 
            this.lblTitulo3.AutoSize = true;
            this.lblTitulo3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo3.Location = new System.Drawing.Point(17, 355);
            this.lblTitulo3.Name = "lblTitulo3";
            this.lblTitulo3.Size = new System.Drawing.Size(466, 25);
            this.lblTitulo3.TabIndex = 7;
            this.lblTitulo3.Text = "Asistencia registrada por fecha (todos los profesores)";
            // 
            // lblConsulta
            // 
            this.lblConsulta.AutoSize = true;
            this.lblConsulta.Location = new System.Drawing.Point(17, 409);
            this.lblConsulta.Name = "lblConsulta";
            this.lblConsulta.Size = new System.Drawing.Size(37, 13);
            this.lblConsulta.TabIndex = 8;
            this.lblConsulta.Text = "Fecha";
            // 
            // dtpConsulta
            // 
            this.dtpConsulta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpConsulta.Location = new System.Drawing.Point(17, 386);
            this.dtpConsulta.Name = "dtpConsulta";
            this.dtpConsulta.Size = new System.Drawing.Size(138, 20);
            this.dtpConsulta.TabIndex = 9;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(172, 386);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(86, 26);
            this.btnConsultar.TabIndex = 10;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // dgvDelDia
            // 
            this.dgvDelDia.AllowUserToAddRows = false;
            this.dgvDelDia.AllowUserToDeleteRows = false;
            this.dgvDelDia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDelDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDelDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDelDia.Location = new System.Drawing.Point(17, 427);
            this.dgvDelDia.MultiSelect = false;
            this.dgvDelDia.Name = "dgvDelDia";
            this.dgvDelDia.ReadOnly = true;
            this.dgvDelDia.RowTemplate.Height = 25;
            this.dgvDelDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDelDia.Size = new System.Drawing.Size(643, 217);
            this.dgvDelDia.TabIndex = 11;
            // 
            // frmAsistenciaProfesores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 687);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblProfesor);
            this.Controls.Add(this.cmbProfesor);
            this.Controls.Add(this.btnFirmar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo2);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.lblTitulo3);
            this.Controls.Add(this.lblConsulta);
            this.Controls.Add(this.dtpConsulta);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dgvDelDia);
            this.Name = "frmAsistenciaProfesores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistencia de Profesores";
            this.Load += new System.EventHandler(this.FrmAsistenciaProfesores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelDia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.Label lblProfesor;

        private System.Windows.Forms.ComboBox cmbProfesor;

        private System.Windows.Forms.Button btnFirmar;

        private System.Windows.Forms.Button btnSalir;

        private System.Windows.Forms.Label lblTitulo2;

        private System.Windows.Forms.DataGridView dgvHistorial;

        private System.Windows.Forms.Label lblTitulo3;

        private System.Windows.Forms.Label lblConsulta;

        private System.Windows.Forms.DateTimePicker dtpConsulta;

        private System.Windows.Forms.Button btnConsultar;

        private System.Windows.Forms.DataGridView dgvDelDia;
    }
}
