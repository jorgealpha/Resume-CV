namespace UTN.Winform.AppAirBnB.Layers.UI.Procesos
{
    partial class frmReservacion
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
            this.tspBarraSuperior = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnReservar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.mskNUMHabitacion = new System.Windows.Forms.MaskedTextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.mskCantidad = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlpAgrupamiento = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHuespedId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCheckIN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.txtNumeroReservacion = new System.Windows.Forms.TextBox();
            this.btnBuscarHuesped = new System.Windows.Forms.Button();
            this.dgvDetalleReserva = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSub = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tspBarraSuperior.SuspendLayout();
            this.sttBarraInferior.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tlpAgrupamiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleReserva)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspBarraSuperior
            // 
            this.tspBarraSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNuevo,
            this.toolStripBtnReservar,
            this.toolStripButton1,
            this.toolStripBtnSalir});
            this.tspBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.tspBarraSuperior.Name = "tspBarraSuperior";
            this.tspBarraSuperior.Size = new System.Drawing.Size(1131, 55);
            this.tspBarraSuperior.TabIndex = 2;
            this.tspBarraSuperior.Text = "toolStrip1";
            // 
            // toolStripBtnNuevo
            // 
            this.toolStripBtnNuevo.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_5fcb865b3ad895719c10c7bfe5771fa4_pen;
            this.toolStripBtnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNuevo.Name = "toolStripBtnNuevo";
            this.toolStripBtnNuevo.Size = new System.Drawing.Size(94, 52);
            this.toolStripBtnNuevo.Text = "Nuevo";
            this.toolStripBtnNuevo.Click += new System.EventHandler(this.toolStripBtnNuevo_Click);
            // 
            // toolStripBtnReservar
            // 
            this.toolStripBtnReservar.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_6d18f14292ffd3debaca5d368aec541f_building;
            this.toolStripBtnReservar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnReservar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnReservar.Name = "toolStripBtnReservar";
            this.toolStripBtnReservar.Size = new System.Drawing.Size(103, 52);
            this.toolStripBtnReservar.Text = "Reservar";
            this.toolStripBtnReservar.Click += new System.EventHandler(this.toolStripBtnReservar_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_2105a9c63eeaa7a280f82fb9c0ce8123_bulb;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(105, 52);
            this.toolStripButton1.Text = "Cancelar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripBtnSalir
            // 
            this.toolStripBtnSalir.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_10696bc060189f66efd1c9d2397cac66_bullseye;
            this.toolStripBtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalir.Name = "toolStripBtnSalir";
            this.toolStripBtnSalir.Size = new System.Drawing.Size(81, 52);
            this.toolStripBtnSalir.Text = "Salir";
            this.toolStripBtnSalir.Click += new System.EventHandler(this.toolStripBtnSalir_Click);
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 453);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Size = new System.Drawing.Size(1131, 22);
            this.sttBarraInferior.TabIndex = 3;
            this.sttBarraInferior.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.9822F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.0178F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel3.Controls.Add(this.mskNUMHabitacion, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBuscarProducto, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblCantidad, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.mskCantidad, 1, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(16, 274);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(493, 99);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // mskNUMHabitacion
            // 
            this.mskNUMHabitacion.Location = new System.Drawing.Point(131, 3);
            this.mskNUMHabitacion.Mask = "99999999999";
            this.mskNUMHabitacion.Name = "mskNUMHabitacion";
            this.mskNUMHabitacion.Size = new System.Drawing.Size(193, 20);
            this.mskNUMHabitacion.TabIndex = 4;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Location = new System.Drawing.Point(339, 29);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(110, 67);
            this.btnBuscarProducto.TabIndex = 1;
            this.btnBuscarProducto.Text = "Buscar Habitacion";
            this.btnBuscarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Numero Habitación";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(3, 26);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(30, 13);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Días";
            // 
            // mskCantidad
            // 
            this.mskCantidad.Location = new System.Drawing.Point(131, 29);
            this.mskCantidad.Mask = "999999999999";
            this.mskCantidad.Name = "mskCantidad";
            this.mskCantidad.Size = new System.Drawing.Size(193, 20);
            this.mskCantidad.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tlpAgrupamiento);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(0, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 398);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reservación";
            // 
            // tlpAgrupamiento
            // 
            this.tlpAgrupamiento.BackColor = System.Drawing.SystemColors.Control;
            this.tlpAgrupamiento.ColumnCount = 3;
            this.tlpAgrupamiento.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tlpAgrupamiento.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tlpAgrupamiento.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 306F));
            this.tlpAgrupamiento.Controls.Add(this.label11, 0, 0);
            this.tlpAgrupamiento.Controls.Add(this.label3, 0, 3);
            this.tlpAgrupamiento.Controls.Add(this.txtHuespedId, 1, 3);
            this.tlpAgrupamiento.Controls.Add(this.label1, 0, 4);
            this.tlpAgrupamiento.Controls.Add(this.dtpCheckIN, 1, 4);
            this.tlpAgrupamiento.Controls.Add(this.label2, 0, 5);
            this.tlpAgrupamiento.Controls.Add(this.dtpCheckOut, 1, 5);
            this.tlpAgrupamiento.Controls.Add(this.txtNumeroReservacion, 1, 0);
            this.tlpAgrupamiento.Controls.Add(this.btnBuscarHuesped, 2, 3);
            this.tlpAgrupamiento.Location = new System.Drawing.Point(16, 29);
            this.tlpAgrupamiento.Name = "tlpAgrupamiento";
            this.tlpAgrupamiento.RowCount = 6;
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAgrupamiento.Size = new System.Drawing.Size(493, 175);
            this.tlpAgrupamiento.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "No. Reservación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Huesped";
            // 
            // txtHuespedId
            // 
            this.txtHuespedId.Location = new System.Drawing.Point(132, 29);
            this.txtHuespedId.Name = "txtHuespedId";
            this.txtHuespedId.Size = new System.Drawing.Size(200, 20);
            this.txtHuespedId.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Check IN";
            // 
            // dtpCheckIN
            // 
            this.dtpCheckIN.Location = new System.Drawing.Point(132, 55);
            this.dtpCheckIN.Name = "dtpCheckIN";
            this.dtpCheckIN.Size = new System.Drawing.Size(200, 20);
            this.dtpCheckIN.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Check OUT";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Location = new System.Drawing.Point(132, 91);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(200, 20);
            this.dtpCheckOut.TabIndex = 19;
            this.dtpCheckOut.ValueChanged += new System.EventHandler(this.dtpCheckOut_ValueChanged);
            // 
            // txtNumeroReservacion
            // 
            this.txtNumeroReservacion.Location = new System.Drawing.Point(132, 3);
            this.txtNumeroReservacion.Name = "txtNumeroReservacion";
            this.txtNumeroReservacion.Size = new System.Drawing.Size(200, 20);
            this.txtNumeroReservacion.TabIndex = 20;
            // 
            // btnBuscarHuesped
            // 
            this.btnBuscarHuesped.Location = new System.Drawing.Point(340, 29);
            this.btnBuscarHuesped.Name = "btnBuscarHuesped";
            this.tlpAgrupamiento.SetRowSpan(this.btnBuscarHuesped, 2);
            this.btnBuscarHuesped.Size = new System.Drawing.Size(110, 56);
            this.btnBuscarHuesped.TabIndex = 9;
            this.btnBuscarHuesped.Text = "Buscar Huesped";
            this.btnBuscarHuesped.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarHuesped.UseVisualStyleBackColor = true;
            this.btnBuscarHuesped.Click += new System.EventHandler(this.btnBuscarHuesped_Click);
            // 
            // dgvDetalleReserva
            // 
            this.dgvDetalleReserva.AllowUserToAddRows = false;
            this.dgvDetalleReserva.AllowUserToDeleteRows = false;
            this.dgvDetalleReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleReserva.Location = new System.Drawing.Point(541, 76);
            this.dgvDetalleReserva.Name = "dgvDetalleReserva";
            this.dgvDetalleReserva.ReadOnly = true;
            this.dgvDetalleReserva.Size = new System.Drawing.Size(578, 325);
            this.dgvDetalleReserva.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSub);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(527, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(555, 397);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descripción";
            // 
            // txtSub
            // 
            this.txtSub.Location = new System.Drawing.Point(426, 355);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(123, 20);
            this.txtSub.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Subtotal :";
            // 
            // frmReservacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 475);
            this.Controls.Add(this.dgvDetalleReserva);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.tspBarraSuperior);
            this.Name = "frmReservacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reservación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReservacion_Load);
            this.tspBarraSuperior.ResumeLayout(false);
            this.tspBarraSuperior.PerformLayout();
            this.sttBarraInferior.ResumeLayout(false);
            this.sttBarraInferior.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tlpAgrupamiento.ResumeLayout(false);
            this.tlpAgrupamiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleReserva)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspBarraSuperior;
        private System.Windows.Forms.ToolStripButton toolStripBtnNuevo;
        private System.Windows.Forms.ToolStripButton toolStripBtnReservar;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tlpAgrupamiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHuespedId;
        private System.Windows.Forms.Button btnBuscarHuesped;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvDetalleReserva;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox mskCantidad;
        private System.Windows.Forms.MaskedTextBox mskNUMHabitacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCheckIN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.TextBox txtNumeroReservacion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txtSub;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}