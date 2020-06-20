using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.AppAirBnB.Layers.BLL;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Interface;
using UTN.Winform.AppAirBnB.Layers.UI.Filtros;
using UTN.Winform.AppAirBnB.Layers.UI.Reportes;
using UTN.Winform.AppAirBnB.Util;

namespace UTN.Winform.AppAirBnB.Layers.UI.Procesos
{
    public partial class frmFacturacion : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        private Reservacion _Reservacion = null;
        private EncFactura _FacturaEncabezado = null;

        private double cont = 0;

        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void txtClienteId_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CargarDatos()
        {

            IBLLEncFactura _BLLFactura = new BLLEncFactura();


            // Configuracion del DataGridView para que se vea bien la imagen.
            dgvDetalleFactura.AutoGenerateColumns = false;


            this.txtNumeroFactura.Text = _BLLFactura.GetNextNumeroFactura().ToString();

            this.cmbEstado.SelectedIndex = 0;


        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            IBLLReservacion _BLLReservacion = new BLLReservacion();

            try
            {
                // Mostar Numero de factura
                CargarTarjeta();

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

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {


            IBLLEncFactura _BLLFactura = new BLLEncFactura();

            this.txtNumeroFactura.Text = _BLLFactura.GetNextNumeroFactura().ToString();

            this.txtNumeroTarjeta.Text = "";
            this.txtNumHabitacion.Text = "";
            this.txtNUMDetalle.Text = "1";
            this.txtImpuesto.Text = "";
            this.txtIdHuesped.Text = "";
            this.txtCantDias.Text = "";
            this.txtPrecio.Text = "";
            this.txtSubtotal.Text = "";
            this.txtTotal.Text = "";
            this.cmbEstado.SelectedIndex = 0;
            this.cmbTarjeta.SelectedIndex = 0;
            this.Subtotal.Text = "";
            this.mskIDReserva.Text = "";
            this.dgvDetalleFactura.Rows.Clear() ;
            this.dgvDetalleFactura.Refresh();

        }

        private void toolStripBtnFacturar_Click(object sender, EventArgs e)
        {
            IBLLEncFactura _BLLFactura = new BLLEncFactura();
            IBLLTarjeta _BLLTarjeta = new BLLTarjeta();
            IBLLHuesped _BLLHuesped = new BLLHuesped();
            IBLLHabitacion _BLLHabitacion = new BLLHabitacion();

            IBLLImpuesto _BLLImpuesto = new BLLImpuesto();

            DetFactura oFacturaDetalle = new DetFactura();

            this.cmbEstado.SelectedIndex = 1;

            IBLLReservacion _BLLReservacion = new BLLReservacion();
            

            Tarjeta oTarjeta = new Tarjeta();
            string rutaImagen = @"c:\temp\qr.png";
            double numeroFactura = 0d;
            try
            {
                _FacturaEncabezado = new EncFactura()
                {
                    IDFactura = Double.Parse(this.txtNumeroFactura.Text),
                    _Tarjeta = cmbTarjeta.SelectedItem as Tarjeta,//_BLLTarjeta.GetTarjetaById(Double.Parse(this.txtNumeroTarjeta.Text)),
                    Fecha = DateTime.Now.Date,
                    EstadoFact = this.cmbEstado.SelectedIndex.ToString(),
                    
                };

                oFacturaDetalle._EncFactura = _BLLFactura.GetFactura(Double.Parse(this.txtNumeroFactura.Text));
                oFacturaDetalle._Reservacion = _BLLReservacion.GetReserva(Double.Parse(this.mskIDReserva.Text.ToString()));



                oFacturaDetalle.Precio = Double.Parse(this.txtPrecio.Text.ToString());

                // Calcular el Impuesto
                IBLLImpuesto _BLLImpuestotest = new BLLImpuesto();
                oFacturaDetalle._Impuesto = _BLLImpuestotest.GetImpuesto();
                // Enumerar la secuencia
                oFacturaDetalle.Numero = _FacturaEncabezado._ListaFacturaDetalle.Count == 0 ?
                                                 1 : _FacturaEncabezado._ListaFacturaDetalle.Max(p => p.Numero) + 1;

                ;
                // Agregar
                _FacturaEncabezado.AddDetalle(oFacturaDetalle);
                

                if (_FacturaEncabezado == null)
                {
                    MessageBox.Show("No hay datos por facturar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_FacturaEncabezado._ListaFacturaDetalle.Count == 0)
                {
                    MessageBox.Show("No hay items en la factura ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                

                this.txtSubtotal.Text = _FacturaEncabezado.GetSubTotal().ToString();
                this.txtImpuesto.Text = _FacturaEncabezado.GetImpuesto().ToString();
                this.txtTotal.Text = (_FacturaEncabezado.GetSubTotal() + (_FacturaEncabezado.GetImpuesto())).ToString();

                _FacturaEncabezado = _BLLFactura.SaveFactura(_FacturaEncabezado);

                numeroFactura = _BLLFactura.GetCurrentNumeroFactura();

                EstadoHabitaciones();

                if (_FacturaEncabezado == null)
                    MessageBox.Show("Error al crear factura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    //toolStripBtnNuevo_Click(null, null);


                // Si existe borrelo
                if (File.Exists(rutaImagen))
                    File.Delete(rutaImagen);


                // Crear imagen quickresponse
                Image quickResponseImage = QuickResponse.QuickResponseGenerador(numeroFactura.ToString(), 53);



                // Salvarla en c:\temp para luego ser leida
                quickResponseImage.Save(rutaImagen, ImageFormat.Png);

                frmFacturaImpresion ofrmFacturaImpresion = new frmFacturaImpresion((int)numeroFactura,_BLLHuesped.GetHuespedById(Double.Parse(this.txtIdHuesped.Text)).Nombre);


                ofrmFacturaImpresion.ShowDialog();


                this.txtNumeroTarjeta.Text = "";
                this.txtNumHabitacion.Text = "";
                this.txtNUMDetalle.Text = "1";
                this.txtImpuesto.Text = "";
                this.txtIdHuesped.Text = "";
                this.txtCantDias.Text = "";
                this.txtPrecio.Text = "";
                this.txtSubtotal.Text = "";
                this.txtTotal.Text = "";
                this.cmbEstado.SelectedIndex = 0;
                this.cmbTarjeta.SelectedIndex = 0;
                this.Subtotal.Text = "";
                this.mskIDReserva.Text = "";
                this.dgvDetalleFactura.Rows.Clear();
                this.dgvDetalleFactura.Refresh();


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


        private void EstadoHabitaciones()
        {
            IBLLHabitacion _BLLHabitacion = new BLLHabitacion();

            Habitacion oHabitacion = null;

            oHabitacion = new Habitacion();


            oHabitacion.NUM = double.Parse(this.txtNumHabitacion.Text);

            oHabitacion.Descripcion = _BLLHabitacion.GetHabitacionById(double.Parse(this.txtNumHabitacion.Text)).Descripcion;

            oHabitacion.Foto = _BLLHabitacion.GetHabitacionById(double.Parse(this.txtNumHabitacion.Text)).Foto;

            oHabitacion.Precio = _BLLHabitacion.GetHabitacionById(double.Parse(this.txtNumHabitacion.Text)).Precio;


            if (_BLLHabitacion.GetHabitacionById(double.Parse(this.txtNumHabitacion.Text)).Estado == 2 )
            {
                oHabitacion.Estado = 1;
            }

            





            oHabitacion = _BLLHabitacion.SaveHabitacion(oHabitacion);

            //_BLLHabitacion.SaveHabitacion(oHabitacion);


        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargarTarjeta()
        {
            IBLLTarjeta _BLLTarjeta = new BLLTarjeta();
            foreach (var oTarjeta in _BLLTarjeta.GetAllTarjeta())
            {
                this.cmbTarjeta.Items.Add(oTarjeta);
               
            }
            cmbTarjeta.SelectedIndex = 0;

            IBLLEncFactura _BLLFactura = new BLLEncFactura();
            //cmbEstado.SelectedIndex = 0;
            this.cmbEstado.Items.Add("Pendiente");
            this.cmbEstado.Items.Add("Cancelado");

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //IBLLImpuesto _BLLImpuesto = new BLLImpuesto();
            DetFactura oFacturaDetalle = new DetFactura();

            IBLLEncFactura _BLLFactura = new BLLEncFactura();

            IBLLReservacion _BLLReservacion = new BLLReservacion();

            IBLLTarjeta _BLLTarjeta = new BLLTarjeta();

            _FacturaEncabezado = new EncFactura();

            

            try
            {
                erpError.Clear();

                _FacturaEncabezado = new EncFactura()
                {
                    IDFactura = _BLLFactura.GetCurrentNumeroFactura(),
                    _Tarjeta = _BLLTarjeta.GetTarjetaById(Double.Parse(this.txtNumeroTarjeta.Text)),
                    Fecha = DateTime.Now.Date,
                    EstadoFact = this.cmbEstado.SelectedIndex.ToString()
                };

                if (_FacturaEncabezado == null)
                {
                    MessageBox.Show("Debe agregar los datos del encabezado de la factura para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar que el Producto ya no se haya agregado
                if (_FacturaEncabezado._ListaFacturaDetalle.Count > 0)
                {
                    // Si ya se agrego no permitir agregarlo nuevamente
                    if (_FacturaEncabezado._ListaFacturaDetalle.FindAll(p => p._Reservacion.ID == double.Parse(this.mskIDReserva.Text)).Count > 0)
                    {
                        MessageBox.Show("La Reservacion ya fue agregado previamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                oFacturaDetalle._EncFactura = _BLLFactura.GetFactura(Double.Parse(this.txtNumeroFactura.Text));
                oFacturaDetalle._Reservacion = _BLLReservacion.GetReserva(Double.Parse(this.mskIDReserva.Text.ToString()));

                

                oFacturaDetalle.Precio = Double.Parse(this.txtPrecio.Text.ToString());

                // Calcular el Impuesto
                IBLLImpuesto _BLLImpuestotest = new BLLImpuesto();
                oFacturaDetalle._Impuesto = _BLLImpuestotest.GetImpuesto();//((double)_BLLImpuesto.GetImpuesto().Porcentaje / 100D) * oFacturaDetalle.Precio * 1;
                // Enumerar la secuencia
                oFacturaDetalle.Numero = _FacturaEncabezado._ListaFacturaDetalle.Count == 0 ?
                                                 1 : _FacturaEncabezado._ListaFacturaDetalle.Max(p => p.Numero) +1;

                
                // Agregar
                _FacturaEncabezado.AddDetalle(oFacturaDetalle);

                if (oFacturaDetalle._Reservacion.CheckOUT.Day < this.dtpOut.Value.Day)
                {
                    MessageBox.Show(

                        "  Ha sobrepasado la fecha para realizar su Check Out , por lo que se realizara un cobro equivalente a $50 adicional. Disculpe. "

                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

                this.txtNUMDetalle.Text = (cont++ +1) .ToString();

                string[] lineaFactura = { _BLLFactura.GetCurrentNumeroFactura().ToString(),
                                        (cont).ToString(),
                                         oFacturaDetalle.Precio.ToString(),
                                         oFacturaDetalle._Reservacion.ID.ToString(),
                                         this.txtNumeroTarjeta.Text,
                                         DateTime.Now.Date.ToString(),
                                         this.cmbEstado.SelectedItem.ToString()

                                         };

                this.dgvDetalleFactura.Rows.Add(lineaFactura);

                

                
                
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

        private void txtIdHuesped_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarReserva_Click(object sender, EventArgs e)
        {
            frmFiltroReserva ofrmFiltroReserva = new frmFiltroReserva();
            Reservacion oReserva = null;
            try
            {
                ofrmFiltroReserva.ShowDialog();

                if (ofrmFiltroReserva.DialogResult == DialogResult.OK)
                {
                    oReserva = ofrmFiltroReserva._Reservacion ;
                    mskIDReserva.Text = oReserva.ID.ToString();
                    this.txtIdHuesped.Text = oReserva._Huesped.ID.ToString();
                    this.txtNumHabitacion.Text = oReserva._Habitacion.NUM.ToString();
                    this.txtPrecio.Text = oReserva._Habitacion.Precio.ToString();
                    this.dtpIn.Value = oReserva.CheckIN;
                    this.dtpOut.Value = oReserva.CheckOUT;
                    this.txtCantDias.Text = oReserva.CantDias.ToString();
                    this.Subtotal.Text = oReserva.Subtotal.ToString();
                    
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
    }
}
