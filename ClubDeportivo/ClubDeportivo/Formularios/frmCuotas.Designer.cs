namespace ClubDeportivo.Formularios
{
    partial class frmCuotas
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
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblDatosSocio = new System.Windows.Forms.Label();
            this.lblEstadoActual = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.lblCuotasTarjeta = new System.Windows.Forms.Label();
            this.cmbCuotasTarjeta = new System.Windows.Forms.ComboBox();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.lblTitulo2 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(17, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(218, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cobro de cuota mensual";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(17, 43);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(93, 13);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "N° de socio o DNI";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(17, 57);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(189, 20);
            this.txtBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(214, 57);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(77, 26);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscarSocio_Click);
            // 
            // lblDatosSocio
            // 
            this.lblDatosSocio.AutoSize = true;
            this.lblDatosSocio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDatosSocio.Location = new System.Drawing.Point(17, 107);
            this.lblDatosSocio.Name = "lblDatosSocio";
            this.lblDatosSocio.Size = new System.Drawing.Size(0, 19);
            this.lblDatosSocio.TabIndex = 4;
            // 
            // lblEstadoActual
            // 
            this.lblEstadoActual.AutoSize = true;
            this.lblEstadoActual.ForeColor = System.Drawing.Color.DarkRed;
            this.lblEstadoActual.Location = new System.Drawing.Point(17, 126);
            this.lblEstadoActual.Name = "lblEstadoActual";
            this.lblEstadoActual.Size = new System.Drawing.Size(0, 13);
            this.lblEstadoActual.TabIndex = 5;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(17, 130);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(94, 13);
            this.lblMonto.TabIndex = 6;
            this.lblMonto.Text = "Monto a cobrar ($)";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(17, 144);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(129, 20);
            this.txtMonto.TabIndex = 7;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Location = new System.Drawing.Point(163, 130);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(78, 13);
            this.lblFormaPago.TabIndex = 8;
            this.lblFormaPago.Text = "Forma de pago";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta"});
            this.cmbFormaPago.Location = new System.Drawing.Point(163, 144);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(129, 21);
            this.cmbFormaPago.TabIndex = 9;
            this.cmbFormaPago.SelectedIndexChanged += new System.EventHandler(this.CmbFormaPago_SelectedIndexChanged);
            // 
            // lblCuotasTarjeta
            // 
            this.lblCuotasTarjeta.AutoSize = true;
            this.lblCuotasTarjeta.Location = new System.Drawing.Point(309, 130);
            this.lblCuotasTarjeta.Name = "lblCuotasTarjeta";
            this.lblCuotasTarjeta.Size = new System.Drawing.Size(110, 13);
            this.lblCuotasTarjeta.TabIndex = 10;
            this.lblCuotasTarjeta.Text = "Promoción con tarjeta";
            // 
            // cmbCuotasTarjeta
            // 
            this.cmbCuotasTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuotasTarjeta.FormattingEnabled = true;
            this.cmbCuotasTarjeta.Items.AddRange(new object[] {
            "1 pago",
            "3 cuotas",
            "6 cuotas"});
            this.cmbCuotasTarjeta.Location = new System.Drawing.Point(309, 144);
            this.cmbCuotasTarjeta.Name = "cmbCuotasTarjeta";
            this.cmbCuotasTarjeta.Size = new System.Drawing.Size(155, 21);
            this.cmbCuotasTarjeta.TabIndex = 11;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Location = new System.Drawing.Point(17, 177);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(137, 26);
            this.btnCobrar.TabIndex = 12;
            this.btnCobrar.Text = "Cobrar cuota";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.BtnCobrar_Click);
            // 
            // lblTitulo2
            // 
            this.lblTitulo2.AutoSize = true;
            this.lblTitulo2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo2.Location = new System.Drawing.Point(17, 227);
            this.lblTitulo2.Name = "lblTitulo2";
            this.lblTitulo2.Size = new System.Drawing.Size(251, 25);
            this.lblTitulo2.TabIndex = 14;
            this.lblTitulo2.Text = "Historial de cuotas del socio";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(17, 257);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(707, 208);
            this.dgv.TabIndex = 15;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(643, 177);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 26);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // frmCuotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 520);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblDatosSocio);
            this.Controls.Add(this.lblEstadoActual);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.cmbFormaPago);
            this.Controls.Add(this.lblCuotasTarjeta);
            this.Controls.Add(this.cmbCuotasTarjeta);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo2);
            this.Controls.Add(this.dgv);
            this.Name = "frmCuotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobro de Cuotas";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.Label lblBuscar;

        private System.Windows.Forms.TextBox txtBuscar;

        private System.Windows.Forms.Button btnBuscar;

        private System.Windows.Forms.Label lblDatosSocio;

        private System.Windows.Forms.Label lblEstadoActual;

        private System.Windows.Forms.Label lblMonto;

        private System.Windows.Forms.TextBox txtMonto;

        private System.Windows.Forms.Label lblFormaPago;

        private System.Windows.Forms.ComboBox cmbFormaPago;

        private System.Windows.Forms.Label lblCuotasTarjeta;

        private System.Windows.Forms.ComboBox cmbCuotasTarjeta;

        private System.Windows.Forms.Button btnCobrar;

        private System.Windows.Forms.Label lblTitulo2;

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnSalir;
    }
}
