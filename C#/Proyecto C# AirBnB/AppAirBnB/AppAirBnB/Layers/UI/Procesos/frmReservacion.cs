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
using UTN.Winform.AppAirBnB.Layers.Entities.DTO;
using UTN.Winform.AppAirBnB.Layers.Interface;
using UTN.Winform.AppAirBnB.Layers.UI.Filtros;

namespace UTN.Winform.AppAirBnB.Layers.UI.Procesos
{
    public partial class frmReservacion : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private Huesped _Huesped = null;
        private Reservacion _Reservacion = null;
        private object cmbTarjeta;

        public frmReservacion()
        {
            InitializeComponent();
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            IBLLReservacion _BLLReservacion = new BLLReservacion();

            try
            {

                _Huesped = null;
                this.txtHuespedId.Text = "";
                this.txtNumeroReservacion.Text = "";          
                this.mskCantidad.Text = "";
                this.mskNUMHabitacion.Text = "";
                this.mskCantidad.Text = "";
                this.dtpCheckIN.Value = DateTime.Now;
                this.dtpCheckOut.Value = DateTime.Now;
                txtNumeroReservacion.Focus();

                this.txtHuespedId.Enabled = true;
                this.txtNumeroReservacion.Enabled = true;
                this.mskCantidad.Enabled = true;
                this.mskNUMHabitacion.Enabled = true;
                this.btnBuscarHuesped.Enabled = true;
                this.btnBuscarProducto.Enabled = true;


                // Mostar Numero de factura
                this.txtNumeroReservacion.Text = _BLLReservacion.GetNextNumeroReserva().ToString();
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

        private void CargarDatos()
        {

            IBLLReservacion _BLLReserva = new BLLReservacion();


            // Configuracion del DataGridView para que se vea bien la imagen.
            dgvDetalleReserva.AutoGenerateColumns = true;


            


            // Cargar el DataGridView
            this.dgvDetalleReserva.DataSource = _BLLReserva.GetAllReservacion();

        }

        private void frmReservacion_Load(object sender, EventArgs e)
        {

            this.txtHuespedId.Enabled = false;
            this.txtNumeroReservacion.Enabled = false;
            this.mskCantidad.Enabled = false;
            this.mskNUMHabitacion.Enabled = false;
            this.btnBuscarHuesped.Enabled = false;
            this.btnBuscarProducto.Enabled = false;
            
            this.mskCantidad.Text = "";
            this.dtpCheckIN.Value = DateTime.Now;
            this.dtpCheckOut.Value = DateTime.Now;

            IBLLReservacion _BLLReservacion = new BLLReservacion();
            try
            {
                // Mostar Numero de factura
                this.txtNumeroReservacion.Text = _BLLReservacion.GetCurrentNumeroReserva().ToString();

                CargarDatos();

                
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

        private void toolStripBtnReservar_Click(object sender, EventArgs e)
        {
            

            try
            {
                Reservacion oReservacion = null;

                IBLLReservacion _IBLLReservacion = new BLLReservacion();

                IBLLHabitacion _BLLHabitacion = new BLLHabitacion();

                IBLLHuesped _BLLHuesped = new BLLHuesped();

                if (this.txtHuespedId == null)
                {

                    MessageBox.Show(" Es un dato requerido !", "Atención");
                    return;
                }

                

                oReservacion = new Reservacion();

                oReservacion.ID = double.Parse(this.txtNumeroReservacion.Text);

                oReservacion._Huesped = _BLLHuesped.GetHuespedById( double.Parse(this.txtHuespedId.Text.ToString()));

                oReservacion._Habitacion = _BLLHabitacion.GetHabitacionById(double.Parse(this.mskNUMHabitacion.Text.ToString()));


                foreach (var item in _IBLLReservacion.GetAllReservacion())
                {



                    if (item.CheckIN.DayOfYear <= this.dtpCheckIN.Value.DayOfYear && item.CheckOUT.DayOfWeek > this.dtpCheckOut.Value.DayOfWeek &&


                        item.CheckIN.Month == this.dtpCheckIN.Value.Month  
                        
                        &&  item._Habitacion.NUM == _BLLHabitacion.GetHabitacionById(double.Parse(this.mskNUMHabitacion.Text.ToString())).NUM)
                    {

                            MessageBox.Show(" La Habitacion se encuantra Ocupada !", "Atención");
                            return;

                        
                    }
                    //else
                    //{

                    //    if (item.CheckIN.Day < this.dtpCheckIN.Value.Day &&

                    //    item.CheckIN.Month == this.dtpCheckIN.Value.Month)
                    //    {
                    //        MessageBox.Show(" La Habitacion se encuantra Ocupada !", "Atención");
                    //        return;
                    //    }

                    //}


                    if (item.CheckOUT.DayOfYear == this.dtpCheckOut.Value.DayOfYear && item.CheckOUT.Month == this.dtpCheckOut.Value.Month &&

                        item._Habitacion.NUM == _BLLHabitacion.GetHabitacionById(double.Parse(this.mskNUMHabitacion.Text.ToString())).NUM)
                    {
                        MessageBox.Show(" La Habitacion se encuantra Ocupada !", "Atención");
                        return;
                    }
                    //else
                    //{

                    //    if (item.CheckOUT.Day > this.dtpCheckOut.Value.Day

                    //    && item.CheckOUT.Month == this.dtpCheckOut.Value.Month)
                    //    {
                    //        MessageBox.Show(" La Habitacion se encuantra Ocupada !", "Atención");
                    //        return;
                    //    }

                    //}



                }




                if (this.dtpCheckIN.Value.DayOfYear < DateTime.Now.DayOfYear || this.dtpCheckIN.Value.Month < DateTime.Now.Month)
                {
                    MessageBox.Show(" No puede reservar fechas anteriores a la actual !", "Atención");
                    return;
                }


                if (this.dtpCheckOut.Value.DayOfYear < DateTime.Now.DayOfYear || this.dtpCheckOut.Value.Month < DateTime.Now.Month 
                    
                    || this.dtpCheckOut.Value.DayOfYear < this.dtpCheckIN.Value.DayOfYear || this.dtpCheckOut.Value.Month < dtpCheckIN.Value.Month)
                {
                    MessageBox.Show(" No puede reservar fechas anteriores a la actual !", "Atención");
                    return;
                }


                oReservacion.CheckIN = (DateTime)this.dtpCheckIN.Value;

                oReservacion.CheckOUT = (DateTime)this.dtpCheckOut.Value;

                oReservacion.CantDias = double.Parse(this.mskCantidad.Text);

                oReservacion.Subtotal = double.Parse(this.mskCantidad.Text) * _BLLHabitacion.GetHabitacionById(double.Parse(this.mskNUMHabitacion.Text.ToString())).Precio;

                txtSub.Text = oReservacion.Subtotal.ToString();

                _IBLLReservacion.SaveReserva(oReservacion);

                if (oReservacion != null)
                    this.CargarDatos();

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

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IBLLReservacion _IBLLReservacion = new BLLReservacion();

            try
            {


                if (this.dgvDetalleReserva.SelectedRows.Count > 0)
                {
                    

                    Reservacion oReservacion = this.dgvDetalleReserva.SelectedRows[0].DataBoundItem as Reservacion;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro de Reservacion :  {oReservacion.ID} ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _IBLLReservacion.DeleteReserva(oReservacion.ID);
                        this.CargarDatos();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el registro !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                // Log error
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnBuscarHuesped_Click(object sender, EventArgs e)
        {
            frmFiltroHuesped ofrmFiltroHuesped = new frmFiltroHuesped();
            Huesped oHuesped = null;
            try
            {
                ofrmFiltroHuesped.ShowDialog();

                if (ofrmFiltroHuesped.DialogResult == DialogResult.OK)
                {
                    oHuesped = ofrmFiltroHuesped._Huesped;
                    this.txtHuespedId.Text = oHuesped.ID.ToString();

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
                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmFiltroHabi ofrmFiltroHabi = new frmFiltroHabi();
            HabitacionDTO oHabitacion = null;
            try
            {
                ofrmFiltroHabi.ShowDialog();

                if (ofrmFiltroHabi.DialogResult == DialogResult.OK)
                {
                    oHabitacion = ofrmFiltroHabi.FHabitacion;
                    this.mskNUMHabitacion.Text = oHabitacion.NUM.ToString();

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
                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            
                this.mskCantidad.Text = (this.dtpCheckOut.Value.DayOfYear - this.dtpCheckIN.Value.DayOfYear).ToString();
            

        }
    }
}
