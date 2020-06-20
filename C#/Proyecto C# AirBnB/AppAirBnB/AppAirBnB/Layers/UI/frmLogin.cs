using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.AppAirBnB.Layers.BLL;
using UTN.Winform.AppAirBnB.Layers.Interface;
using UTN.Winform.AppAirBnB.Properties;

namespace UTN.Winform.AppAirBnB.Layers.UI
{
    public partial class frmLogin : Form
    {

        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");



        private int contador = 0;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            // Debe validar los datos requeridos
            IBLLSysUserRolDTO _BLLUser = new BLLSysUserRolDTO();
            IBLLLogin _BLLLogin = new BLLLogin();
            epError.Clear();

            try
            {

                if (string.IsNullOrEmpty(this.txtUsuario.Text))
                {
                    epError.SetError(txtUsuario, "Usuario requerido");
                    this.txtUsuario.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtContrasena.Text))
                {
                    epError.SetError(txtContrasena, "Contraseá requerida");
                    this.txtContrasena.Focus();
                    return;
                }


                Settings.Default.Login = "sa";
                Settings.Default.Password = "123456";

                _BLLLogin.Login(Settings.Default.Login,
                                Settings.Default.Password);




                foreach (var item in _BLLUser.GetSysUserByFilter(this.txtUsuario.Text))
                {

                    if (item.Login == this.txtUsuario.Text && item.Password == this.txtContrasena.Text)
                    {




                        // Log de errores
                        _MyLogControlEventos.InfoFormat("Entró a la aplicación");
                        Settings.Default.User = txtUsuario.Text.Trim();
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
                msg.AppendFormat("Usuario        {0}\n", Settings.Default.Login);

                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());


                // Incrementar el contador
                contador++;

                // Si el mensaje es "Error de inicio de sesión del usuario" es un error de usuario inválido 
                if (er.Message.Trim().Contains("Error de inicio de sesión del usuario") == true || er.Message.Trim().Contains("Login failed") == true)
                    MessageBox.Show("Usuario inválido, intento No " + contador, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    // otro Error
                    MessageBox.Show("Error ->" + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Si el contador es 3 cierre la aplicación
                if (contador == 3)
                {
                    // se devuelve Cancel
                    this.DialogResult = DialogResult.Cancel;
                    Application.Exit();
                }

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Application.ProductName + " Versión:  " + Application.ProductVersion;

                _MyLogControlEventos.InfoFormat("Inicio Login");

               
                

            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                MessageBox.Show("Se produjo un error :" + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.ErrorFormat("Error {0}", er.Message);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
