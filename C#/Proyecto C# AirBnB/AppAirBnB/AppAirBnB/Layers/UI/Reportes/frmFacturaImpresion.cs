using log4net;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTN.Winform.AppAirBnB.Layers.UI.Reportes
{
    public partial class frmFacturaImpresion : Form
    {
        private int _IdFactura;
        private string _Nombre;
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        

        public frmFacturaImpresion(int pIdFactura,string pNombre)
        {
            InitializeComponent();
            _IdFactura = pIdFactura;
            _Nombre = pNombre;
        }

        ///
        private void frmFacturaImpresion_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.Facturas' table. You can move, or remove it, as needed.
            this.FacturasTableAdapter.Fill(this.DataSet2.Facturas , _IdFactura);

            this.reportViewer1.RefreshReport();


            string ruta = @"file:///" + @"C:/TEMP/qr.png";
            // Habilitar imagenes externas
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter param = new ReportParameter("quickresponse", ruta);
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }
        /// <summary>
        /// https://www.airbnb.co.cr/help/article/971/how-do-i-know-if-an-email-is-really-from-airbnb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnExportarPDF_Click(object sender, EventArgs e)
        {
            string ruta = @"c:\temp\reporte.pdf";
            try
            {

                if (!Directory.Exists(@"c:\temp"))
                    Directory.CreateDirectory(@"c:\temp");

                byte[] Bytes = this.reportViewer1.LocalReport.Render(format: "PDF", deviceInfo: "");

                using (FileStream stream = new FileStream(ruta, FileMode.Create))
                {
                    stream.Write(Bytes, 0, Bytes.Length);
                }

                Process.Start(ruta);

                


                MailMessage mensaje = new MailMessage();
                mensaje.IsBodyHtml = true;
                mensaje.Subject = "Estimado Huesped "+ _Nombre + "! Este correo incluye una copia de su factura de AirBnB";
                mensaje.Body = "Buenas Estimado Huesped, Te enviamos una copia de la factura numero : " + _IdFactura + " Si tienes dudas sobre este correo electrónico, entra a www.airbnb.mx e inicia sesión en tu cuenta. Le esperamos pronto . Saludos ";
                mensaje.From = new MailAddress("jorgemario0728@gmail.com");
                mensaje.To.Add("jorgemario0728@gmail.com");
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("jorgemario0728@gmail.com", "kaiser0728jl");
                smtp.EnableSsl = true;
                Attachment attachment = new Attachment(@"c:\temp\reporte.pdf");
                mensaje.Attachments.Add(attachment);

                smtp.Send(mensaje);

                
                mensaje.Attachments.Clear();

              

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
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
