namespace ClubDeportivo.Formularios
{
    partial class frmSueldos
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
            this.lblMes = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblAviso = new System.Windows.Forms.Label();
            this.btnLiquidar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblTitulo2 = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblTitulo3 = new System.Windows.Forms.Label();
            this.btnVerPeriodo = new System.Windows.Forms.Button();
            this.dgvPeriodo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(17, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(205, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Liquidación de sueldos";
            // 
            // lblProfesor
            // 
            this.lblProfesor.AutoSize = true;
            this.lblProfesor.Location = new System.Drawing.Point(17, 43);
            this.lblProfesor.Name = "lblProfesor";
            this.lblProfesor.Size = new System.Drawing.Size(46, 13);
            this.lblProfesor.TabIndex = 1;
            this.lblProfesor.Text = "Profesor";
            // 
            // cmbProfesor
            // 
            this.cmbProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesor.FormattingEnabled = true;
            this.cmbProfesor.Location = new System.Drawing.Point(17, 57);
            this.cmbProfesor.Name = "cmbProfesor";
            this.cmbProfesor.Size = new System.Drawing.Size(223, 21);
            this.cmbProfesor.TabIndex = 2;
            this.cmbProfesor.SelectedIndexChanged += new System.EventHandler(this.CmbProfesor_SelectedIndexChanged);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(257, 43);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(27, 13);
            this.lblMes.TabIndex = 3;
            this.lblMes.Text = "Mes";
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(257, 57);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(112, 21);
            this.cmbMes.TabIndex = 4;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(386, 43);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(26, 13);
            this.lblAnio.TabIndex = 5;
            this.lblAnio.Text = "Año";
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(386, 57);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(78, 20);
            this.txtAnio.TabIndex = 6;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(480, 43);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(52, 13);
            this.lblMonto.TabIndex = 7;
            this.lblMonto.Text = "Monto ($)";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(480, 57);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(121, 20);
            this.txtMonto.TabIndex = 8;
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblAviso.Location = new System.Drawing.Point(17, 87);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(0, 13);
            this.lblAviso.TabIndex = 9;
            // 
            // btnLiquidar
            // 
            this.btnLiquidar.Location = new System.Drawing.Point(17, 113);
            this.btnLiquidar.Name = "btnLiquidar";
            this.btnLiquidar.Size = new System.Drawing.Size(137, 26);
            this.btnLiquidar.TabIndex = 10;
            this.btnLiquidar.Text = "Liquidar sueldo";
            this.btnLiquidar.UseVisualStyleBackColor = true;
            this.btnLiquidar.Click += new System.EventHandler(this.BtnLiquidar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(622, 113);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 26);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // lblTitulo2
            // 
            this.lblTitulo2.AutoSize = true;
            this.lblTitulo2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo2.Location = new System.Drawing.Point(17, 152);
            this.lblTitulo2.Name = "lblTitulo2";
            this.lblTitulo2.Size = new System.Drawing.Size(307, 25);
            this.lblTitulo2.TabIndex = 12;
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
            this.dgvHistorial.Location = new System.Drawing.Point(17, 182);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowTemplate.Height = 25;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(686, 173);
            this.dgvHistorial.TabIndex = 13;
            // 
            // lblTitulo3
            // 
            this.lblTitulo3.AutoSize = true;
            this.lblTitulo3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo3.Location = new System.Drawing.Point(17, 416);
            this.lblTitulo3.Name = "lblTitulo3";
            this.lblTitulo3.Size = new System.Drawing.Size(381, 25);
            this.lblTitulo3.TabIndex = 14;
            this.lblTitulo3.Text = "Sueldos liquidados en el período (mes/año)";
            // 
            // btnVerPeriodo
            // 
            this.btnVerPeriodo.Location = new System.Drawing.Point(17, 442);
            this.btnVerPeriodo.Name = "btnVerPeriodo";
            this.btnVerPeriodo.Size = new System.Drawing.Size(111, 26);
            this.btnVerPeriodo.TabIndex = 15;
            this.btnVerPeriodo.Text = "Ver período";
            this.btnVerPeriodo.UseVisualStyleBackColor = true;
            this.btnVerPeriodo.Click += new System.EventHandler(this.BtnVerPeriodo_Click);
            // 
            // dgvPeriodo
            // 
            this.dgvPeriodo.AllowUserToAddRows = false;
            this.dgvPeriodo.AllowUserToDeleteRows = false;
            this.dgvPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPeriodo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeriodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodo.Location = new System.Drawing.Point(17, 481);
            this.dgvPeriodo.MultiSelect = false;
            this.dgvPeriodo.Name = "dgvPeriodo";
            this.dgvPeriodo.ReadOnly = true;
            this.dgvPeriodo.RowTemplate.Height = 25;
            this.dgvPeriodo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeriodo.Size = new System.Drawing.Size(686, 143);
            this.dgvPeriodo.TabIndex = 16;
            // 
            // frmSueldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 699);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblProfesor);
            this.Controls.Add(this.cmbProfesor);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnLiquidar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo2);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.lblTitulo3);
            this.Controls.Add(this.btnVerPeriodo);
            this.Controls.Add(this.dgvPeriodo);
            this.Name = "frmSueldos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidación de Sueldos";
            this.Load += new System.EventHandler(this.FrmSueldos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.Label lblProfesor;

        private System.Windows.Forms.ComboBox cmbProfesor;

        private System.Windows.Forms.Label lblMes;

        private System.Windows.Forms.ComboBox cmbMes;

        private System.Windows.Forms.Label lblAnio;

        private System.Windows.Forms.TextBox txtAnio;

        private System.Windows.Forms.Label lblMonto;

        private System.Windows.Forms.TextBox txtMonto;

        private System.Windows.Forms.Label lblAviso;

        private System.Windows.Forms.Button btnLiquidar;

        private System.Windows.Forms.Button btnSalir;

        private System.Windows.Forms.Label lblTitulo2;

        private System.Windows.Forms.DataGridView dgvHistorial;

        private System.Windows.Forms.Label lblTitulo3;

        private System.Windows.Forms.Button btnVerPeriodo;

        private System.Windows.Forms.DataGridView dgvPeriodo;
    }
}
