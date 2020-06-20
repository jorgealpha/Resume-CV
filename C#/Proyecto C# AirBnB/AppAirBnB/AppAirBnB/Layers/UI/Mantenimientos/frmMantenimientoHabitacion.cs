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
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Entities.DTO;
using UTN.Winform.AppAirBnB.Layers.Interface;

namespace UTN.Winform.AppAirBnB.Layers.UI.Mantenimientos
{
    public partial class frmMantenimientoHabitacion : Form
    {
        

        public frmMantenimientoHabitacion()
        {
            InitializeComponent();
        }

        private void CambiarEstado(EstadoMantenimiento estado)
        {
            this.mskDescripcion.Clear();
            this.mskCodigo.Clear();
            this.pbImagen.Tag = null;
            this.chkDisponible.Checked = false;
            this.chkOcupado.Checked = false;

            this.mskCodigo.Enabled = false;
            this.mskDescripcion.Enabled = false;
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.pbImagen.Enabled = false;
            this.chkDisponible.Enabled = false;
            this.chkOcupado.Enabled = false;


            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.mskDescripcion.Enabled = true;
                    
                    this.mskCodigo.Enabled = true;
                    
                    this.mskCodigo.Enabled = true;
                  
                    this.pbImagen.Enabled = true;
                    
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;

                    this.chkDisponible.Enabled = true;
                    this.chkOcupado.Enabled = true;

                    this.txtPrecio.Text = "";
                    mskCodigo.Focus();
                    break;
                case EstadoMantenimiento.Editar:
                    this.mskDescripcion.Enabled = true;
                    
                    this.mskCodigo.Enabled = false;
                    
                    
                    this.pbImagen.Enabled = true;
                    
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;

                    this.chkDisponible.Enabled = true;
                    this.chkOcupado.Enabled = true;
                    mskDescripcion.Focus();
                    break;
                case EstadoMantenimiento.Borrar:
                    break;
                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }

        private void CargarDatos()
        {
            IBLLHabitacion _IBLLHabitacion = new BLLHabitacion();
            //IBLLBodega _BLLBodega = new BLLBodega();
            //List<Bodega> lista = null;

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            // Configuracion del DataGridView para que se vea bien la imagen.
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


            this.pbImagen.Enabled = false;

            // Cargar el DataGridView
            this.dgvDatos.DataSource = _IBLLHabitacion.GetAllHabitacion();

      
            // Colocar el primero como default
            

            
       
          
            this.pbImagen.SizeMode = PictureBoxSizeMode.CenterImage;



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
               // _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opt = new OpenFileDialog();
                opt.Title = "Seleccione la Imagen ";
                opt.SupportMultiDottedExtensions = true;
                opt.DefaultExt = "*.jpg";
                opt.Filter = "Archivos de Imagenes (*.jpg)|*.jpg| All files (*.*)|*.*";
                opt.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                opt.FileName = "";

                if (opt.ShowDialog(this) == DialogResult.OK)
                {

                    
                    //this.pbImagen.ImageLocation = opt.FileName;
                    //pbImagen.SizeMode = PictureBoxSizeMode.AutoSize;

                    this.pbImagen.ImageLocation = opt.FileName;
                    pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

                    byte[] cadenaBytes = File.ReadAllBytes(opt.FileName);

                    // Guarla la imagenen Bytes en el Tag de la imagen.
                    pbImagen.Tag = (byte[])cadenaBytes;

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

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            HabitacionDTO oHabitacionDTO = null;
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.CambiarEstado(EstadoMantenimiento.Editar);
                    //Extraer el DTO seleccionado
                    oHabitacionDTO = this.dgvDatos.SelectedRows[0].DataBoundItem as HabitacionDTO;

                    this.mskCodigo.Text = oHabitacionDTO.NUM.ToString();
                    this.mskDescripcion.Text = oHabitacionDTO.Descripcion;
                    this.pbImagen.BackgroundImage = null;   
                    this.pbImagen.Image = new Bitmap(new MemoryStream(oHabitacionDTO.Foto));
                    this.pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pbImagen.Tag = oHabitacionDTO.Foto;
                    this.txtPrecio.Text = oHabitacionDTO.Precio.ToString();

                    if (oHabitacionDTO.Estado == 1)
                    {
                        this.chkDisponible.Checked = true;
                    }

                    else
                    {
                        this.chkOcupado.Checked = true;
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
               // _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Habitacion oHabitacion = null;

            try
            {
                IBLLHabitacion _IBLLHabitacion = new BLLHabitacion();


                if (this.pbImagen.Tag == null)
                {

                    MessageBox.Show("La Imagen  es un dato requerido !", "Atención");
                    return;
                }



                oHabitacion = new Habitacion();


                oHabitacion.NUM = double.Parse(this.mskCodigo.Text);

                oHabitacion.Descripcion = this.mskDescripcion.Text;
                
                oHabitacion.Foto = (byte[])this.pbImagen.Tag;

                oHabitacion.Precio = double.Parse(this.txtPrecio.Text);

                

                if (chkDisponible.Checked == true)
                {
                    oHabitacion.Estado = 1;
                }

                else
                {
                    oHabitacion.Estado = 2;
                }
                
                
                
                
                

                oHabitacion = _IBLLHabitacion.SaveHabitacion(oHabitacion);

                if (oHabitacion != null)
                    this.CargarDatos();

                this.txtPrecio.Text = "";
                this.pbImagen.Image = null;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Ninguno);
        }

        private void frmMantenimientoHabitacion_Load(object sender, EventArgs e)
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

        private void toolStripBtnBorrar_Click(object sender, EventArgs e)
        {
            IBLLHabitacion _BLLHabitacion = new BLLHabitacion();

            try
            {


                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.CambiarEstado(EstadoMantenimiento.Borrar);

                    HabitacionDTO oHabitacionDTO = this.dgvDatos.SelectedRows[0].DataBoundItem as HabitacionDTO;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oHabitacionDTO.NUM} {oHabitacionDTO.Descripcion}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _BLLHabitacion.DeleteHabitacion(oHabitacionDTO.NUM);
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
    }
}
