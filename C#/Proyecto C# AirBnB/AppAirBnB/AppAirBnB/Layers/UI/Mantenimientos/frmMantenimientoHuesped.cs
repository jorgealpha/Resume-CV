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

namespace UTN.Winform.AppAirBnB.Layers.UI.Mantenimientos
{
    public partial class frmMantenimientoHuesped : Form
    {
        public frmMantenimientoHuesped()
        {
            InitializeComponent();
        }

        private void frmMantenimientoHuesped_Load(object sender, EventArgs e)
        {
            try
            {
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
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void CambiarEstado(EstadoMantenimiento estado)
        {
            this.txtId.Clear();
            this.txtNombre.Clear();
            this.txtApellido1.Clear();
            this.txtApellido2.Clear();
            this.txtTelefono.Clear();
            this.txtCorreo.Clear();

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.cmbPais.Enabled = false;
            this.txtId.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtApellido1.Enabled = false;
            this.txtApellido2.Enabled = false;
            this.txtCorreo.Enabled = false;
            this.txtTelefono.Enabled = false;



            // Coloca el combo por defecto

            if (this.cmbPais.Items.Count > 0)
                this.cmbPais.SelectedIndex = 0;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.txtId.Enabled = true;
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.txtTelefono.Enabled = true;
                    this.txtCorreo.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.cmbPais.Enabled = true;
                    this.txtId.Focus();
                    break;
                case EstadoMantenimiento.Editar:
                    this.txtId.Enabled = false;
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.txtTelefono.Enabled = true;
                    this.txtCorreo.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.cmbPais.Enabled = true;
                    this.txtNombre.Focus();
                    break;
                case EstadoMantenimiento.Borrar:
                    break;
                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }

        private void CargarDatos()
        {
            IBLLHuesped _BLLHuesped = new BLLHuesped();
            IBLLPais _BLLPais = new BLLPais();
            List<Pais> lista = null;

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            // Configuracion del DataGridView para que se vea bien la imagen.
            dgvDatos.AutoGenerateColumns = false;
            //  dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;



            // Cargar el DataGridView
            this.dgvDatos.DataSource = _BLLHuesped.GetAllHuesped();

            // Cargar el combo
            this.cmbPais.Items.Clear();
            lista = _BLLPais.GetAllPais();
            foreach (Pais oPais in lista)
            {

                this.cmbPais.Items.Add(oPais);
            }
            // Colocar el primero como default
            this.cmbPais.SelectedIndex = 0;




        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                this.CambiarEstado(EstadoMantenimiento.Nuevo);
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

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CambiarEstado(EstadoMantenimiento.Editar);
                Huesped _Huesped = null;
                IBLLPais _Pais = new BLLPais();


                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.CambiarEstado(EstadoMantenimiento.Editar);
                    //Extraer el DTO seleccionado
                    // oElectronicoBodegaDTO = this.dgvDatos.SelectedRows[0].DataBoundItem as ElectronicoBodegaDTO;
                    _Huesped = this.dgvDatos.SelectedRows[0].DataBoundItem as Huesped;
                    this.txtId.Text = _Huesped.ID.ToString();
                    this.txtNombre.Text = _Huesped.Nombre;
                    this.txtApellido1.Text = _Huesped.Apellido1;
                    this.txtApellido2.Text = _Huesped.Apellido2;
                    this.txtTelefono.Text = _Huesped.Telefono;
                    this.txtCorreo.Text = _Huesped.Correo;
                    this.cmbPais.SelectedIndex = (int)_Pais.GetPaisById(_Huesped._Pais.ID).ID ;

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

        private void toolStripBtnBorrar_Click(object sender, EventArgs e)
        {
            IBLLHuesped _BLLHuesped = new BLLHuesped();
            //IBLLCliente _BLLCliente = new BLLCliente();

            //try
            //{
            //    this.CambiarEstado(EstadoMantenimiento.Editar);
            //    Cliente _Cliente = null;


            //    if (this.dgvDatos.SelectedRows.Count > 0)
            //    {
            //        // Cambiar de estado
            //        this.CambiarEstado(EstadoMantenimiento.Editar);
            //        _Cliente = this.dgvDatos.SelectedRows[0].DataBoundItem as Cliente;
            //        this.txtIdCliente.Text = _Cliente.IdCliente.ToString();
            //        this.txtNombre.Text = _Cliente.Nombre;
            //        this.txtApellido1.Text = _Cliente.Apellido1;
            //        this.txtApellido2.Text = _Cliente.Apellido2;
            //        if (_Cliente.Sexo == 1)
            //        {
            //            this.rbnMas.Checked = true;
            //        }
            //        else
            //        {
            //            this.rbnFem.Checked = true;


            //        }

            //        this.dtpFechaNacimiento.Value = _Cliente.FechaNacimiento;
            //        this.cmbProvincia.SelectedIndex = _Cliente.IdProvincia;

            //        _BLLCliente.DeleteCliente(Convert.ToDouble(_Cliente.IdCliente));

            //    }
            //    else
            //    {
            //        MessageBox.Show("Seleccione el registro !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }



            //}
            //catch (Exception er)
            //{

            //    StringBuilder msg = new StringBuilder();
            //    msg.AppendFormat("Message        {0}\n", er.Message);
            //    msg.AppendFormat("Source         {0}\n", er.Source);
            //    msg.AppendFormat("InnerException {0}\n", er.InnerException);
            //    msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
            //    msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);
            //    // Log error
            //    _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
            //    // Mensaje de Error
            //    MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            //}
            try
            {


                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.CambiarEstado(EstadoMantenimiento.Borrar);

                    Huesped _Huesped = null;
                    _Huesped = this.dgvDatos.SelectedRows[0].DataBoundItem as Huesped;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {_Huesped.ID} {_Huesped.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _BLLHuesped.DeleteHuesped(Convert.ToDouble(_Huesped.ID));
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

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IBLLHuesped _BLLHuesped = new BLLHuesped();
            IBLLPais _Pais = new BLLPais();
            try
            {

                Huesped oHuesped = new Entities.Huesped();
                oHuesped.ID = Double.Parse(this.txtId.Text);
                oHuesped.Nombre = this.txtNombre.Text;
                oHuesped.Apellido1 = this.txtApellido1.Text;
                oHuesped.Apellido2 = this.txtApellido2.Text;
                oHuesped.Telefono = this.txtTelefono.Text;
                oHuesped.Correo = this.txtCorreo.Text;
                oHuesped._Pais = _Pais.GetPaisById(((Pais)(this.cmbPais.SelectedItem)).ID);


                _BLLHuesped.SaveHuesped(oHuesped);

                if (oHuesped != null)
                {
                    this.CargarDatos();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Ninguno);
        }
    }
}
