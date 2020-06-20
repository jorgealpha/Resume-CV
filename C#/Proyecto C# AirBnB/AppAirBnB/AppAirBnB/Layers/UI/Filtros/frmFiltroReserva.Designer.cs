namespace UTN.Winform.AppAirBnB.Layers.UI.Filtros
{
    partial class frmFiltroReserva
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
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDHuesped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckOUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.tspBarraSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // tspBarraSuperior
            // 
            this.tspBarraSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNuevo,
            this.toolStripBtnBuscar,
            this.toolStripBtnSalir});
            this.tspBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.tspBarraSuperior.Name = "tspBarraSuperior";
            this.tspBarraSuperior.Size = new System.Drawing.Size(795, 39);
            this.tspBarraSuperior.TabIndex = 6;
            this.tspBarraSuperior.Text = "toolStrip1";
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 445);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Size = new System.Drawing.Size(795, 22);
            this.sttBarraInferior.TabIndex = 9;
            this.sttBarraInferior.Text = "statusStrip1";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(12, 50);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(771, 20);
            this.txtFiltro.TabIndex = 10;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IDHuesped,
            this.NUMHabitacion,
            this.CheckIN,
            this.CheckOUT,
            this.CantDias,
            this.Subtotal});
            this.dgvDatos.Location = new System.Drawing.Point(12, 100);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(771, 309);
            this.dgvDatos.TabIndex = 11;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // IDHuesped
            // 
            this.IDHuesped.DataPropertyName = "_Huesped";
            this.IDHuesped.HeaderText = "IDHuesped";
            this.IDHuesped.Name = "IDHuesped";
            // 
            // NUMHabitacion
            // 
            this.NUMHabitacion.DataPropertyName = "_Habitacion";
            this.NUMHabitacion.HeaderText = "NUMHabitacion";
            this.NUMHabitacion.Name = "NUMHabitacion";
            // 
            // CheckIN
            // 
            this.CheckIN.DataPropertyName = "CheckIN";
            this.CheckIN.HeaderText = "CheckIN";
            this.CheckIN.Name = "CheckIN";
            // 
            // CheckOUT
            // 
            this.CheckOUT.DataPropertyName = "CheckOUT";
            this.CheckOUT.HeaderText = "CheckOUT";
            this.CheckOUT.Name = "CheckOUT";
            // 
            // CantDias
            // 
            this.CantDias.DataPropertyName = "CantDias";
            this.CantDias.HeaderText = "CantDias";
            this.CantDias.Name = "CantDias";
            // 
            // Subtotal
            // 
            this.Subtotal.DataPropertyName = "Subtotal";
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            // 
            // toolStripBtnNuevo
            // 
            this.toolStripBtnNuevo.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._32_32_53df9782d9bacf85cae56004eace1272_puzzle;
            this.toolStripBtnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNuevo.Name = "toolStripBtnNuevo";
            this.toolStripBtnNuevo.Size = new System.Drawing.Size(78, 36);
            this.toolStripBtnNuevo.Text = "Nuevo";
            this.toolStripBtnNuevo.Click += new System.EventHandler(this.toolStripBtnNuevo_Click);
            // 
            // toolStripBtnBuscar
            // 
            this.toolStripBtnBuscar.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._32_32_8144eb3f858e81ffdf6a058c1bdfe13b_calendar;
            this.toolStripBtnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnBuscar.Name = "toolStripBtnBuscar";
            this.toolStripBtnBuscar.Size = new System.Drawing.Size(78, 36);
            this.toolStripBtnBuscar.Text = "Buscar";
            this.toolStripBtnBuscar.Click += new System.EventHandler(this.toolStripBtnBuscar_Click);
            // 
            // toolStripBtnSalir
            // 
            this.toolStripBtnSalir.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._32_32_d412235b792cccfd81e6038865109033_printer;
            this.toolStripBtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalir.Name = "toolStripBtnSalir";
            this.toolStripBtnSalir.Size = new System.Drawing.Size(65, 36);
            this.toolStripBtnSalir.Text = "Salir";
            this.toolStripBtnSalir.Click += new System.EventHandler(this.toolStripBtnSalir_Click);
            // 
            // frmFiltroReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 467);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.tspBarraSuperior);
            this.Name = "frmFiltroReserva";
            this.Text = "Filtro Reservacion";
            this.Load += new System.EventHandler(this.frmFiltroReserva_Load);
            this.tspBarraSuperior.ResumeLayout(false);
            this.tspBarraSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspBarraSuperior;
        private System.Windows.Forms.ToolStripButton toolStripBtnNuevo;
        private System.Windows.Forms.ToolStripButton toolStripBtnBuscar;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHuesped;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckOUT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantDias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
    }
}