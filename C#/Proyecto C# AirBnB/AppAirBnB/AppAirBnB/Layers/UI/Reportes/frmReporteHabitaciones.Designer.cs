namespace UTN.Winform.AppAirBnB.Layers.UI.Reportes
{
    partial class frmReporteHabitaciones
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet2 = new UTN.Winform.AppAirBnB.Layers.UI.Reportes.DataSet2();
            this.HabitacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HabitacionTableAdapter = new UTN.Winform.AppAirBnB.Layers.UI.Reportes.DataSet2TableAdapters.HabitacionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HabitacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSHabita";
            reportDataSource1.Value = this.HabitacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UTN.Winform.AppAirBnB.Layers.UI.Reportes.ReporteHabitacion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(827, 441);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet2
            // 
            this.DataSet2.DataSetName = "DataSet2";
            this.DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HabitacionBindingSource
            // 
            this.HabitacionBindingSource.DataMember = "Habitacion";
            this.HabitacionBindingSource.DataSource = this.DataSet2;
            // 
            // HabitacionTableAdapter
            // 
            this.HabitacionTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 441);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteHabitaciones";
            this.Text = "Reporte Habitaciones";
            this.Load += new System.EventHandler(this.frmReporteHabitaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HabitacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource HabitacionBindingSource;
        private DataSet2 DataSet2;
        private DataSet2TableAdapters.HabitacionTableAdapter HabitacionTableAdapter;
    }
}