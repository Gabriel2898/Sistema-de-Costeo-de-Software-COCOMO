using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GACC_Controlador;
using GACC_Modelo;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_RecuperarContraseña1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static GACC_ControladorRecuperarClave CorreoEnvio;
        protected void gacc_btnenviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gacc_txtcorreo.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingrese el correo ')", true);

            }
            else
            {
                string contraseña;
                GACC_ControladorEncriptar b = new GACC_ControladorEncriptar();
                
                GACC_TblPersona cuenta_usuario = new GACC_TblPersona();
                contraseña = b.DesencriptarMD5(cuenta_usuario.gacc_PerPassword);
                cuenta_usuario = GACC_ControladorRecuperarClave.ComprobarCorreo(gacc_txtcorreo.Text);
                {
                    if (cuenta_usuario != null)
                    {
                        CorreoEnvio = new GACC_ControladorRecuperarClave();

                        bool estadoBool = CorreoEnvio.EnviarCorreo(gacc_txtcorreo.Text, contraseña);
                        if (estadoBool == false)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Verifique conexión a internet  ')", true);

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Se completó el envio con éxito  ')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El correo que ingreso no existe  ')", true);

                        return;
                    }
                }
            }
        }
    }
}