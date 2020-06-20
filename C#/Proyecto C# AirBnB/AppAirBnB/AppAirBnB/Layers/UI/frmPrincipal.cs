using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.AppAirBnB.Layers.BLL;
using UTN.Winform.AppAirBnB.Layers.Interface;
using UTN.Winform.AppAirBnB.Layers.UI.Mantenimientos;
using UTN.Winform.AppAirBnB.Layers.UI.Procesos;
using UTN.Winform.AppAirBnB.Layers.UI.Reportes;
using UTN.Winform.AppAirBnB.Layers.UI.Seguridad;
using UTN.Winform.AppAirBnB.Properties;
using UTN.Winform.AppAirBnB.Util;

namespace UTN.Winform.AppAirBnB.Layers.UI
{
    public partial class frmPrincipal : Form
    {
        private static readonly ILog _MyLogControlEventos =
          log4net.LogManager.GetLogger("MyControlEventos");

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            IBLLSysUserRolDTO _BLLUser = new BLLSysUserRolDTO();
            try
            {
                this.Text = Application.ProductName + " Versión:  " + Application.ProductVersion;
                Utilitarios.CultureInfo();
                toolStripStatusLblMensaje.Text = "Usuario Conectado: " + Settings.Default.User;

                foreach (var item in _BLLUser.GetSysUserByFilter(Settings.Default.User))
                {

                    if (item.IdRol == 1)
                    {
                        MessageBox.Show("Usuario Administrador");
                    }
                    if (item.IdRol == 2)
                    {
                        MessageBox.Show("Usuario para uso de procesos");
                        this.toolStripMenuItemMantenimientos.Enabled = false;
                        this.administracionToolStripMenuItem.Enabled = false;
                        this.reportesToolStripMenuItemReportes.Enabled = false;
                    }
                    if (item.IdRol == 3)
                    {
                        MessageBox.Show("Usuario para uso de reportes");
                        this.toolStripMenuItemMantenimientos.Enabled = false;
                        this.administracionToolStripMenuItem.Enabled = false;
                        this.reportesToolStripMenuItemReportes.Enabled = true;
                        this.toolStripMenuItemProcesos.Enabled = false;
                    }


                }





                if (!Directory.Exists(@"C:\temp"))
                    Directory.CreateDirectory(@"C:\temp");


                _MyLogControlEventos.InfoFormat("Conectado a Form Principal");
                // Seguridad();

            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);
                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void huespedesToolStripMenuItemHuesped_Click(object sender, EventArgs e)
        {
            frmMantenimientoHuesped frmHuesped = new frmMantenimientoHuesped();
            frmHuesped.MdiParent = this;
            frmHuesped.Show();
        }

        private void productosToolStripMenuItemProductos_Click(object sender, EventArgs e)
        {
            frmMantenimientoHabitacion frmHabitacion = new frmMantenimientoHabitacion();
            frmHabitacion.MdiParent = this;
            frmHabitacion.Show();

        }

        private void reservarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReservacion _frmReservacion = new frmReservacion();
            _frmReservacion.MdiParent = this;
            _frmReservacion.Show();
        }

        private void facturarToolStripMenuItemFacturar_Click(object sender, EventArgs e)
        {
            frmFacturacion _frmFacturacion = new frmFacturacion();

            _frmFacturacion.MdiParent = this;

            _frmFacturacion.Show();
        }

        private void usuariosToolStripMenuItemUsuarios_Click(object sender, EventArgs e)
        {
            frmSeguridad ofrmSeguridad;
            try
            {
                ofrmSeguridad = new frmSeguridad();
                ofrmSeguridad.MdiParent = this;
                ofrmSeguridad.Show();
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {


            frmAcercaDe ofrmAcercade;
            try
            {
                ofrmAcercade = new frmAcercaDe();
                ofrmAcercade.MdiParent = this;
                ofrmAcercade.Show();
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


        }

        private void RecaudacionToolStripMenuItemRecaudacion_Click(object sender, EventArgs e)
        {
            frmReporteRecaudacion _frmReporte;
            try
            {
                _frmReporte = new frmReporteRecaudacion();
                _frmReporte.MdiParent = this;
                _frmReporte.Show();
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void HabitacionToolStripMenuItemHabitacion_Click(object sender, EventArgs e)
        {
            frmReporteHabitaciones _frmReporte;
            try
            {
                _frmReporte = new frmReporteHabitaciones();
                _frmReporte.MdiParent = this;
                _frmReporte.Show();
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
    }
}
