using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GACC_Modelo;
using GACC_Controlador;
namespace GACC_Vista
{
    public partial class GACC_RegistrarEmpresa1 : System.Web.UI.Page
    {
        private GACC_TblEmpresa usuarioInfo = new GACC_TblEmpresa();
        public GACC_ControladorCedulayRuc ced = new GACC_ControladorCedulayRuc();
        protected void Page_Load(object sender, EventArgs e)
        {

            gacc_txtnombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
            gacc_txtruc.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
            gacc_txttelefono.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");

            gacc_ddlestado.Items.FindByValue("I").Enabled = false;
        }
        public void VerificacionRuc()
        {
            int dvr = 0;
            int dvo = 0;
            long isNumeric;
            int isNumeric1;
            string ruc = gacc_txtruc.Text;
            string ruc1 = Convert.ToString(ruc.Substring(0, 10));
            const int tamanoLongitudRuc = 13;
            int tamanoLongitudRuc1 = 10;
            const string establecimiento = "001";
            var total = 0;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            const int numeroProvincias = 24;
            const int tercerDigito = 6;
            if (int.TryParse(ruc1, out isNumeric1) && ruc.Length == tamanoLongitudRuc1)
            {
                var provincia = Convert.ToInt32(string.Concat(ruc1[0], ruc1[1],
               string.Empty));
                var digitotres = Convert.ToInt32(ruc1[2] + string.Empty);
                if ((provincia > 0 && provincia <= numeroProvincias) && digitotres <
               tercerDigito)
                {
                    var digitoVerificadorRecibido = Convert.ToInt32(ruc1[9] +
                   string.Empty);
                    dvr = digitoVerificadorRecibido;
                    for (var k = 0; k < coeficientes.Length; k++)
                    {
                        var valor = Convert.ToInt32(coeficientes[k] + string.Empty) *
                       Convert.ToInt32(ruc1[k] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;
                    }
                    var digitoVerificadorObtenido = total >= 10 ? (total % 10) != 0 ? 10 -
                   (total % 10) : (total % 10) : total;
                    dvo = digitoVerificadorObtenido;

                    //return digitoVerificadorObtenido == digitoVerificadorRecibido;
                    //return 1;
                    /*
                    if (digitoVerificadorObtenido == digitoVerificadorRecibido)
                    {
                    ClientScript.RegisterClientScriptBlock(GetType(), "msgbox",
                   "alert('RUC Correcto');", true);
                    }
                    else
                    {
                    ClientScript.RegisterClientScriptBlock(GetType(), "msgbox",
                   "alert('RUC Incorrecto');", true);
                    }
                    * */
                }
                //return false;
                //return -1;
            }

        }

        protected void gacc_btnenviar_Click(object sender, EventArgs e)
        {
            usuarioInfo = new GACC_TblEmpresa();
            try
            {


                if (GACC_ControladorCedulayRuc.RucPersonaNatural(gacc_txtruc.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ruc Incorrecto')", true);
                }
                else
                {

                    var existe = GACC_ControladorEmpresa.AutentificarEmpresaxnombres(gacc_txtnombre.Text);
                    var existes = GACC_ControladorEmpresa.AutentificarEmpresaxrucs(gacc_txtruc.Text);
                    {
                        if (existe != null || existes != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre o Ruc de la empresa ya existen  ')", true);
                        }
                        else
                        {




                            usuarioInfo.gacc_EmpCorreo = gacc_txtcorreo.Text;
                            usuarioInfo.gacc_EmpDireccion = gacc_txtdireccion.Text;
                            usuarioInfo.gacc_EmpNombre = gacc_txtnombre.Text;
                            usuarioInfo.gacc_EmpRuc = gacc_txtruc.Text;
                            usuarioInfo.gacc_EmpTelefono = gacc_txttelefono.Text;
                            usuarioInfo.gacc_EmpEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                            GACC_ControladorEmpresa.save(usuarioInfo);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO  Guardados  ')" , true);
            }
        }
    }
}