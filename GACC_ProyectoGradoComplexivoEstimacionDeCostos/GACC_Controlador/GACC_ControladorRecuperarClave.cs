using System;
using System.Collections.Generic;
using System.Linq;
using GACC_Modelo;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GACC_Controlador
{
   public class GACC_ControladorRecuperarClave
    {
        SmtpClient smtpCliente;
        MailMessage mailMsg;

        string emailUsuario;
        string emailClave;
        string emailServidor;
        int numPuerto;

        public static DataClasses1DataContext dc = new DataClasses1DataContext();


        public GACC_ControladorRecuperarClave()
        {
            emailServidor = "smtp.gmail.com";
            numPuerto = 587;
            emailUsuario = "empresagacc@gmail.com";
            emailClave = "EmpresaG@cc2898";
            smtpCliente = new SmtpClient();
            smtpCliente.Port = numPuerto;
            smtpCliente.Host = emailServidor;
            smtpCliente.EnableSsl = true;
            smtpCliente.Timeout = 60000;
            smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpCliente.UseDefaultCredentials = false;
            smtpCliente.Credentials = new System.Net.NetworkCredential(emailUsuario, emailClave);
        }
        public static GACC_TblPersona ComprobarCorreo(string correo)
        {
            var user = dc.GACC_TblPersona.SingleOrDefault(usu => usu.gacc_PerCorreo.Equals(correo));
            return user;

        }
        public Boolean EnviarCorreo(string destino, string msg)
        {
            try
            {
                string texto = "";
                string asunto = "Recuperación de la contraseña";
                texto = "<br/>Su contraseña es:<br/><p>" + msg + "</p>";
                mailMsg = new MailMessage(emailUsuario, destino, asunto, texto);
                mailMsg.IsBodyHtml = true;
                mailMsg.BodyEncoding = UTF8Encoding.UTF8;
                mailMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                smtpCliente.Send(mailMsg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
   }
}
