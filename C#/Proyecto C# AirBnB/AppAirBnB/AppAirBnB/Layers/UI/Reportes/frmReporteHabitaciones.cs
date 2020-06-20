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
    public partial class frmReporteHabitaciones : Form
    {
        public frmReporteHabitaciones()
        {
            InitializeComponent();
        }

        private void frmReporteHabitaciones_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.Habitacion' table. You can move, or remove it, as needed.
            this.HabitacionTableAdapter.Fill(this.DataSet2.Habitacion);

            this.reportViewer1.RefreshReport();
        }
    }
}
