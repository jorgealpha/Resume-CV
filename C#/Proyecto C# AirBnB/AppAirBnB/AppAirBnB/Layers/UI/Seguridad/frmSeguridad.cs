using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.AppAirBnB.Layers.BLL;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Entities.DTO;
using UTN.Winform.AppAirBnB.Layers.Interface;

namespace UTN.Winform.AppAirBnB.Layers.UI.Seguridad
{
    public partial class frmSeguridad : Form
    {

        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        public frmSeguridad()
        {
            InitializeComponent();
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TaskBarMensaje()
        {
            ntfMensaje.Visible = true;
            ntfMensaje.BalloonTipIcon = ToolTipIcon.Info;
            ntfMensaje.BalloonTipText = "Usuario creado correctamente";
            ntfMensaje.BalloonTipTitle = "Atención";
            
            ntfMensaje.Text = "";
            ntfMensaje.ShowBalloonTip(1000);
            Thread.Sleep(3000);
            ntfMensaje.Visible = false;

        }

        private void frmSeguridad_Load(object sender, EventArgs e)
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

        private void CargarDatos()
        {
            IBLLSysUserRolDTO _BLLUser = new BLLSysUserRolDTO();
            
            

            // Configuracion del DataGridView para que se vea bien la imagen.
            dgvDatos.AutoGenerateColumns = false;
            //  dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;



            // Cargar el DataGridView
            this.dgvDatos.DataSource = _BLLUser.GetAllSysUser();
            this.dgvDatos.Sort(this.dgvDatos.Columns[1], ListSortDirection.Ascending);
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            this.txtContrasena.Clear();
            this.txtUsuario.Clear();
            this.txtIdRol.Clear();
            this.txtIdUser.Clear();
            txtUsuario.Focus();
        }

        private void toolStripBtnSalvarUsuario_Click(object sender, EventArgs e)
        {

            SysUser oSysUser = null;

            try
            {
                IBLLSysUserRolDTO _IBLLUser = new BLLSysUserRolDTO();

                oSysUser = new SysUser();


                oSysUser.Login = this.txtUsuario.Text;

                oSysUser.Password = this.txtContrasena.Text;

                oSysUser.IDUser = int.Parse(this.txtIdUser.Text);

                oSysUser.IdRol = int.Parse(this.txtIdRol.Text);

               
                oSysUser = _IBLLUser.SaveSysUser(oSysUser);

                if (oSysUser != null)
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
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SysUserRolDTO oSysUserRolDTO = null;
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado

                    //Extraer el DTO seleccionado
                    oSysUserRolDTO = this.dgvDatos.SelectedRows[0].DataBoundItem as SysUserRolDTO;

                    this.txtUsuario.Text = oSysUserRolDTO.Login.ToString();
                    this.txtIdUser.Text = oSysUserRolDTO.IDUser.ToString();
                    this.txtContrasena.Text = oSysUserRolDTO.Password.ToString();
                    this.txtIdRol.Text = oSysUserRolDTO.Id.ToString();          

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
                 _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SysUserRolDTO oSysUserRolDTO = new SysUserRolDTO();

            IBLLSysUserRolDTO _BLLSysUser = new BLLSysUserRolDTO();

            try
            {


                if (this.dgvDatos.SelectedRows.Count > 0)
                {


                    
                    oSysUserRolDTO = this.dgvDatos.SelectedRows[0].DataBoundItem as SysUserRolDTO;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oSysUserRolDTO.Login} {oSysUserRolDTO.IDUser}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _BLLSysUser.DeleteSysUser(oSysUserRolDTO.Login);
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
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
