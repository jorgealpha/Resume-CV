namespace UTN.Winform.AppAirBnB.Layers.UI.Reportes
{
    partial class frmFacturaImpresion
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.FacturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet2 = new UTN.Winform.AppAirBnB.Layers.UI.Reportes.DataSet2();
            this.tspBarraSuperior = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnExportarPDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.FacturasTableAdapter = new UTN.Winform.AppAirBnB.Layers.UI.Reportes.DataSet2TableAdapters.FacturasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FacturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet2)).BeginInit();
            this.tspBarraSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // FacturasBindingSource
            // 
            this.FacturasBindingSource.DataMember = "Facturas";
            this.FacturasBindingSource.DataSource = this.DataSet2;
            // 
            // DataSet2
            // 
            this.DataSet2.DataSetName = "DataSet2";
            this.DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tspBarraSuperior
            // 
            this.tspBarraSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnExportarPDF,
            this.toolStripBtnSalir});
            this.tspBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.tspBarraSuperior.Name = "tspBarraSuperior";
            this.tspBarraSuperior.Size = new System.Drawing.Size(716, 39);
            this.tspBarraSuperior.TabIndex = 2;
            this.tspBarraSuperior.Text = "toolStrip1";
            // 
            // toolStripBtnExportarPDF
            // 
            this.toolStripBtnExportarPDF.Image = global::UTN.Winform.AppAirBnB.Properties.Resources._32_32_de0013d277ed47ae28dc3a4ddcf20ec2_cup;
            this.toolStripBtnExportarPDF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnExportarPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnExportarPDF.Name = "toolStripBtnExportarPDF";
            this.toolStripBtnExportarPDF.Size = new System.Drawing.Size(133, 36);
            this.toolStripBtnExportarPDF.Text = "Enviar por correo";
            this.toolStripBtnExportarPDF.Click += new System.EventHandler(this.toolStripBtnExportarPDF_Click);
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
            // sttBarraInferior
            // 
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 371);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Size = new System.Drawing.Size(716, 22);
            this.sttBarraInferior.TabIndex = 3;
            this.sttBarraInferior.Text = "statusStrip1";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet22";
            reportDataSource1.Value = this.FacturasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UTN.Winform.AppAirBnB.Layers.UI.Reportes.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 39);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(716, 332);
            this.reportViewer1.TabIndex = 4;
            // 
            // FacturasTableAdapter
            // 
            this.FacturasTableAdapter.ClearBeforeFill = true;
            // 
            // frmFacturaImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 393);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.tspBarraSuperior);
            this.Name = "frmFacturaImpresion";
            this.Text = "Factura Impresion";
            this.Load += new System.EventHandler(this.frmFacturaImpresion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FacturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet2)).EndInit();
            this.tspBarraSuperior.ResumeLayout(false);
            this.tspBarraSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspBarraSuperior;
        private System.Windows.Forms.ToolStripButton toolStripBtnExportarPDF;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FacturasBindingSource;
        private DataSet2 DataSet2;
        private DataSet2TableAdapters.FacturasTableAdapter FacturasTableAdapter;
    }
}