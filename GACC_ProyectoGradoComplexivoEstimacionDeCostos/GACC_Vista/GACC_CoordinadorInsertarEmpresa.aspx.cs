using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using GACC_Modelo;
using GACC_Controlador;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_CoordinadorInsertarEmpresa1 : System.Web.UI.Page
    {
        private GACC_TblEmpresa usuarioInfo = new GACC_TblEmpresa();
        public GACC_ControladorCedulayRuc ced = new GACC_ControladorCedulayRuc();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                gacc_txtnombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
                gacc_txtruc.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_txttelefono.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                Session.Timeout = 60;
                if (Session["CoordinadorProyecto"] != null)
                {
                    gacc_lblnombreusuario.Text = Session["CoordinadorProyecto"].ToString();
                }
                else
                {
                    Response.Redirect("GACC_Index.aspx");
                }



                if (Request["cod"] != null)
                {

                    gacc_lnkGuardar.Visible = false;
                    gacc_lnkeditar.Visible = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    usuarioInfo = GACC_ControladorEmpresa.ObtenerEmpresaxid(codigo);
                    if (usuarioInfo != null)
                    {
                        gacc_hdfEmpresa1.Value = usuarioInfo.gacc_EmpRuc.ToString();
                        gacc_hdfEmpresa.Value = usuarioInfo.gacc_EmpNombre.ToString();
                        gacc_txtnombre.Text = usuarioInfo.gacc_EmpNombre.ToString();
                        gacc_txtdireccion.Text = usuarioInfo.gacc_EmpDireccion.ToString();
                        gacc_txtcorreo.Text = usuarioInfo.gacc_EmpCorreo.ToString();
                        gacc_txttelefono.Text = usuarioInfo.gacc_EmpTelefono.ToString();
                        gacc_txtruc.Text = usuarioInfo.gacc_EmpRuc.ToString();
                        gacc_ddlestado.SelectedValue = usuarioInfo.gacc_EmpEstado.ToString();
                    }
                }
                else
                {
                    gacc_lblestado.Visible = false;
                    gacc_ddlestado.Visible = false;
                    gacc_ddlestado.Items.FindByValue("I").Enabled = false;
                }
            }
        }
        private void Limpiar()
        {
            gacc_txtnombre.Text = string.Empty;
            gacc_txtdireccion.Text = string.Empty;
            gacc_txtcorreo.Text = string.Empty;
            gacc_txttelefono.Text = string.Empty;
            gacc_ddlestado.Text = null;
            gacc_txtruc.Text = string.Empty;
        }
        private void Guardar()
        {
            usuarioInfo = new GACC_TblEmpresa();
            try
            {


                if (!GACC_ControladorCedulayRuc.RucPersonaNatural(gacc_txtruc.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ruc Incorrecto')", true);
                }
                else
                {
                    var existe = GACC_ControladorEmpresa.AutentificarEmpresaxnombres(gacc_txtnombre.Text);
                    var existes = GACC_ControladorEmpresa.AutentificarEmpresaxrucs(gacc_txtruc.Text);
                    {
                        if (existe != null || existes !=null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre o Ruc de la empresa ya existen  ')", true);
                        }
                        else { 
                        
                         


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
            catch (Exception e)
            {

              ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO  Guardados  ')" , true);
            }
        }
    

    


        private void Modificar(GACC_TblEmpresa usuarioInfo)
        {
            try
            {
                usuarioInfo.gacc_EmpCorreo = gacc_txtcorreo.Text;
                usuarioInfo.gacc_EmpDireccion = gacc_txtdireccion.Text;
                usuarioInfo.gacc_EmpNombre = gacc_txtnombre.Text;
                usuarioInfo.gacc_EmpRuc = gacc_txtruc.Text;
                usuarioInfo.gacc_EmpTelefono = gacc_txttelefono.Text;
                usuarioInfo.gacc_EmpEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                GACC_ControladorEmpresa.modify(usuarioInfo);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos modificados  ')", true);
            }
            catch (Exception e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO modificados  ')", true);
            }
        }
        private void GuardarDatos(int id)
        {
            if (id == 0)
            {
                Guardar();
            }
            else
            {
                usuarioInfo = GACC_ControladorEmpresa.ObtenerEmpresaxid(id);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }



        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["CoordinadorProyecto"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }

        protected void gacc_lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorInsertarEmpresa.aspx");
        }

        protected void gacc_lnkGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        protected void gacc_lnkeditar_Click(object sender, EventArgs e)
        {
            usuarioInfo = new GACC_TblEmpresa();
            string hdfValor1 = gacc_hdfEmpresa1.Value;
            string hdfValor = gacc_hdfEmpresa.Value;
            if (hdfValor == gacc_txtnombre.Text && hdfValor1 == gacc_txtruc.Text)
            {
                GuardarDatos(int.Parse(Request["cod"]));
            }else if (!GACC_ControladorCedulayRuc.RucPersonaNatural(gacc_txtruc.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ruc Incorrecto')", true);
            }
            else if (hdfValor != gacc_txtnombre.Text)
            {

                var existe = GACC_ControladorEmpresa.AutentificarEmpresaxnombres(gacc_txtnombre.Text);
                {
                    if (existe != null)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre de la empresa ya existen  ')", true);
                    }
                    else
                    {
                        GuardarDatos(int.Parse(Request["cod"]));
                    }
                }
            }
            else if (hdfValor1 != gacc_txtruc.Text)
            {
                if (!GACC_ControladorCedulayRuc.RucPersonaNatural(gacc_txtruc.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ruc Incorrecto')", true);
                }
                else
                {
                    var existes = GACC_ControladorEmpresa.AutentificarEmpresaxrucs(gacc_txtruc.Text);
                    {
                        if (existes != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El Ruc de la empresa ya existe  ')", true);
                        }
                        else
                        {
                            GuardarDatos(int.Parse(Request["cod"]));
                        }
                    }
                }
            }
        }





        protected void gacc_lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorListarEmpresa.aspx");
        }

        protected void gacc_lnklimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorListarUnicaPersona.aspx");
        }
    }
}