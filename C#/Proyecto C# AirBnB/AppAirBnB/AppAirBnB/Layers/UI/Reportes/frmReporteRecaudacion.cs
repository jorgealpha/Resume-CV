using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTN.Winform.AppAirBnB.Layers.UI.Reportes
{
    public partial class frmReporteRecaudacion : Form
    {
        public DateTime Fecha { get; set; }

        public frmReporteRecaudacion()
        {
            InitializeComponent();
        }

        private void frmReporteRecaudacion_Load(object sender, EventArgs e)
        {
            

            this.reportViewer1.RefreshReport();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {

            Fecha = this.dateTimePicker1.Value.Date;

            // TODO: This line of code loads data into the 'DataSet2.Reservacion' table. You can move, or remove it, as needed.
            this.ReservacionTableAdapter.Fill(this.DataSet2.Reservacion,Fecha);

            this.reportViewer1.RefreshReport();

        }
    }
}
