namespace UTN.Winform.AppAirBnB.Layers.UI
{
    partial class frmPrincipal
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
            this.mspMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemMantenimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.huespedesToolStripMenuItemHuesped = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItemProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.facturarToolStripMenuItemFacturar = new System.Windows.Forms.ToolStripMenuItem();
            this.reservarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItemReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.HabitacionToolStripMenuItemHabitacion = new System.Windows.Forms.ToolStripMenuItem();
            this.RecaudacionToolStripMenuItemRecaudacion = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItemUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.mspMenuPrincipal.SuspendLayout();
            this.sttBarraInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspMenuPrincipal
            // 
            this.mspMenuPrincipal.BackgroundImage = global::UTN.Winform.AppAirBnB.Properties.Resources.airbnb_logo_white_image_green_background_93709650;
            this.mspMenuPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mspMenuPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.mspMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMantenimientos,
            this.toolStripMenuItemProcesos,
            this.reportesToolStripMenuItemReportes,
            this.administracionToolStripMenuItem,
            this.toolStripMenuItemAcercaDe,
            this.toolStripMenuItem1});
            this.mspMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mspMenuPrincipal.Name = "mspMenuPrincipal";
            this.mspMenuPrincipal.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mspMenuPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mspMenuPrincipal.Size = new System.Drawing.Size(113, 480);
            this.mspMenuPrincipal.TabIndex = 3;
            this.mspMenuPrincipal.Text = "menuStrip1";
            // 
            // toolStripMenuItemMantenimientos
            // 
            this.toolStripMenuItemMantenimientos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.huespedesToolStripMenuItemHuesped,
            this.productosToolStripMenuItemProductos});
            this.toolStripMenuItemMantenimientos.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_2be631e7356ce10da373b8efd54fd80f_users;
            this.toolStripMenuItemMantenimientos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemMantenimientos.Name = "toolStripMenuItemMantenimientos";
            this.toolStripMenuItemMantenimientos.Size = new System.Drawing.Size(98, 67);
            this.toolStripMenuItemMantenimientos.Text = "Mantenimientos";
            this.toolStripMenuItemMantenimientos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // huespedesToolStripMenuItemHuesped
            // 
            this.huespedesToolStripMenuItemHuesped.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_062b562d65e87001955143c9ecc082d5_user;
            this.huespedesToolStripMenuItemHuesped.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.huespedesToolStripMenuItemHuesped.Name = "huespedesToolStripMenuItemHuesped";
            this.huespedesToolStripMenuItemHuesped.Size = new System.Drawing.Size(175, 54);
            this.huespedesToolStripMenuItemHuesped.Text = "Huespedes";
            this.huespedesToolStripMenuItemHuesped.Click += new System.EventHandler(this.huespedesToolStripMenuItemHuesped_Click);
            // 
            // productosToolStripMenuItemProductos
            // 
            this.productosToolStripMenuItemProductos.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_6d18f14292ffd3debaca5d368aec541f_building;
            this.productosToolStripMenuItemProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.productosToolStripMenuItemProductos.Name = "productosToolStripMenuItemProductos";
            this.productosToolStripMenuItemProductos.Size = new System.Drawing.Size(175, 54);
            this.productosToolStripMenuItemProductos.Text = "Habitaciones";
            this.productosToolStripMenuItemProductos.Click += new System.EventHandler(this.productosToolStripMenuItemProductos_Click);
            // 
            // toolStripMenuItemProcesos
            // 
            this.toolStripMenuItemProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturarToolStripMenuItemFacturar,
            this.reservarToolStripMenuItem});
            this.toolStripMenuItemProcesos.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_2105a9c63eeaa7a280f82fb9c0ce8123_bulb;
            this.toolStripMenuItemProcesos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemProcesos.Name = "toolStripMenuItemProcesos";
            this.toolStripMenuItemProcesos.Size = new System.Drawing.Size(98, 67);
            this.toolStripMenuItemProcesos.Text = "Procesos";
            this.toolStripMenuItemProcesos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // facturarToolStripMenuItemFacturar
            // 
            this.facturarToolStripMenuItemFacturar.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_5fcb865b3ad895719c10c7bfe5771fa4_pen;
            this.facturarToolStripMenuItemFacturar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.facturarToolStripMenuItemFacturar.Name = "facturarToolStripMenuItemFacturar";
            this.facturarToolStripMenuItemFacturar.Size = new System.Drawing.Size(150, 54);
            this.facturarToolStripMenuItemFacturar.Text = "Facturar";
            this.facturarToolStripMenuItemFacturar.Click += new System.EventHandler(this.facturarToolStripMenuItemFacturar_Click);
            // 
            // reservarToolStripMenuItem
            // 
            this.reservarToolStripMenuItem.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_6d18f14292ffd3debaca5d368aec541f_building;
            this.reservarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reservarToolStripMenuItem.Name = "reservarToolStripMenuItem";
            this.reservarToolStripMenuItem.Size = new System.Drawing.Size(150, 54);
            this.reservarToolStripMenuItem.Text = "Reservar";
            this.reservarToolStripMenuItem.Click += new System.EventHandler(this.reservarToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItemReportes
            // 
            this.reportesToolStripMenuItemReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HabitacionToolStripMenuItemHabitacion,
            this.RecaudacionToolStripMenuItemRecaudacion});
            this.reportesToolStripMenuItemReportes.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_b0c2ec075d62ad91d845ac99590a3e1d_presentation;
            this.reportesToolStripMenuItemReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportesToolStripMenuItemReportes.Name = "reportesToolStripMenuItemReportes";
            this.reportesToolStripMenuItemReportes.Size = new System.Drawing.Size(98, 67);
            this.reportesToolStripMenuItemReportes.Text = "Reportes";
            this.reportesToolStripMenuItemReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // HabitacionToolStripMenuItemHabitacion
            // 
            this.HabitacionToolStripMenuItemHabitacion.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_6d18f14292ffd3debaca5d368aec541f_building;
            this.HabitacionToolStripMenuItemHabitacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HabitacionToolStripMenuItemHabitacion.Name = "HabitacionToolStripMenuItemHabitacion";
            this.HabitacionToolStripMenuItemHabitacion.Size = new System.Drawing.Size(229, 54);
            this.HabitacionToolStripMenuItemHabitacion.Text = "Habitaciones";
            this.HabitacionToolStripMenuItemHabitacion.Click += new System.EventHandler(this.HabitacionToolStripMenuItemHabitacion_Click);
            // 
            // RecaudacionToolStripMenuItemRecaudacion
            // 
            this.RecaudacionToolStripMenuItemRecaudacion.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_5fcb865b3ad895719c10c7bfe5771fa4_pen;
            this.RecaudacionToolStripMenuItemRecaudacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RecaudacionToolStripMenuItemRecaudacion.Name = "RecaudacionToolStripMenuItemRecaudacion";
            this.RecaudacionToolStripMenuItemRecaudacion.Size = new System.Drawing.Size(229, 54);
            this.RecaudacionToolStripMenuItemRecaudacion.Text = "Recaudacion por Fecha";
            this.RecaudacionToolStripMenuItemRecaudacion.Click += new System.EventHandler(this.RecaudacionToolStripMenuItemRecaudacion_Click);
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItemUsuarios});
            this.administracionToolStripMenuItem.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_7db7675b221877d6daa87d9361ba3d58_briefcase;
            this.administracionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(98, 67);
            this.administracionToolStripMenuItem.Text = "Administración";
            this.administracionToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // usuariosToolStripMenuItemUsuarios
            // 
            this.usuariosToolStripMenuItemUsuarios.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_f217a070ae265c06a3473771c368ac82_card;
            this.usuariosToolStripMenuItemUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usuariosToolStripMenuItemUsuarios.Name = "usuariosToolStripMenuItemUsuarios";
            this.usuariosToolStripMenuItemUsuarios.Size = new System.Drawing.Size(151, 54);
            this.usuariosToolStripMenuItemUsuarios.Text = "Usuarios";
            this.usuariosToolStripMenuItemUsuarios.Click += new System.EventHandler(this.usuariosToolStripMenuItemUsuarios_Click);
            // 
            // toolStripMenuItemAcercaDe
            // 
            this.toolStripMenuItemAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemAcercaDe.Name = "toolStripMenuItemAcercaDe";
            this.toolStripMenuItemAcercaDe.Size = new System.Drawing.Size(98, 4);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._48_48_10696bc060189f66efd1c9d2397cac66_bullseye;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(98, 67);
            this.toolStripMenuItem1.Text = " Acerca de";
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLblMensaje});
            this.sttBarraInferior.Location = new System.Drawing.Point(113, 458);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Padding = new System.Windows.Forms.Padding(2, 0, 16, 0);
            this.sttBarraInferior.Size = new System.Drawing.Size(978, 22);
            this.sttBarraInferior.TabIndex = 4;
            // 
            // toolStripStatusLblMensaje
            // 
            this.toolStripStatusLblMensaje.Name = "toolStripStatusLblMensaje";
            this.toolStripStatusLblMensaje.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLblMensaje.Text = "-";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::UTN.Winform.AppAirBnB.Properties.Resources.SbeKd2H;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1091, 480);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.mspMenuPrincipal);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.mspMenuPrincipal.ResumeLayout(false);
            this.mspMenuPrincipal.PerformLayout();
            this.sttBarraInferior.ResumeLayout(false);
            this.sttBarraInferior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMantenimientos;
        private System.Windows.Forms.ToolStripMenuItem huespedesToolStripMenuItemHuesped;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItemProductos;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProcesos;
        private System.Windows.Forms.ToolStripMenuItem facturarToolStripMenuItemFacturar;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItemReportes;
        private System.Windows.Forms.ToolStripMenuItem HabitacionToolStripMenuItemHabitacion;
        private System.Windows.Forms.ToolStripMenuItem RecaudacionToolStripMenuItemRecaudacion;
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItemUsuarios;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAcercaDe;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblMensaje;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reservarToolStripMenuItem;
    }
}