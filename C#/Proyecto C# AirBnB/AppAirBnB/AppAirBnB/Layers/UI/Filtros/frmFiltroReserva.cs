using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.AppAirBnB.Layers.BLL;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Interface;

namespace UTN.Winform.AppAirBnB.Layers.UI.Filtros
{
    public partial class frmFiltroReserva : Form
    {
        private static readonly ILog _MyLogControlEventos =
         log4net.LogManager.GetLogger("MyControlEventos");

        internal Reservacion _Reservacion { get;  set; } = null;

        public frmFiltroReserva()
        {
            InitializeComponent();
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            this.txtFiltro.Clear();
            this.dgvDatos.DataSource = null;
            txtFiltro.Focus();
        }

        private void toolStripBtnBuscar_Click(object sender, EventArgs e)
        {
            IBLLReservacion _BLLReserva = new BLLReservacion();
            double filtro = 0;
            try
            {
                //filtro = Double.Parse(this.txtFiltro.Text);
                
                this.dgvDatos.AutoGenerateColumns = false;
                this.dgvDatos.DataSource = _BLLReserva.GetAllReservacion();

            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDatos.RowCount > 0 && dgvDatos.SelectedRows.Count > 0)
                {
                    if (dgvDatos.CurrentCell.Selected)
                    {
                        _Reservacion = dgvDatos.SelectedRows[0].DataBoundItem as Reservacion;
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmFiltroReserva_Load(object sender, EventArgs e)
        {

        }
    }
}
