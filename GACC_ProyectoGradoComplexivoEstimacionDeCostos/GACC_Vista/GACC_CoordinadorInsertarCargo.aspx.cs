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
    public partial class GACC_CoordinadorInsertarCargo1 : System.Web.UI.Page
    {
        private GACC_TblCargo usuarioInfo = new GACC_TblCargo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gacc_txtnombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
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

                    gacc_lnkguardar.Visible = false;
                    gacc_lnkeditar.Visible = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    usuarioInfo = GACC_ControladorCargo.ObtenerCargoxid(codigo);
                    if (usuarioInfo != null)
                    {
                        gacc_hdfCargo.Value = usuarioInfo.gacc_CarNombre.ToString();
                        gacc_txtnombre.Text = usuarioInfo.gacc_CarNombre.ToString();
                        gacc_ddlestado.SelectedValue = usuarioInfo.gacc_CarEstado.ToString();
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
            gacc_ddlestado.SelectedValue = null;
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
            Response.Redirect("GACC_CoordinadorInsertarCargo.aspx");
        }
        private void Guardar()
        {
            usuarioInfo = new GACC_TblCargo();

            try
            {
                bool existe = GACC_ControladorCargo.AutentificarCargoxnombres(gacc_txtnombre.Text);
                {
                    if (existe)
                    {
                        GACC_TblCargo usur = new GACC_TblCargo();
                        usur = GACC_ControladorCargo.ObtenerCargoxnombre(gacc_txtnombre.Text);
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El  cargo ya  existe')", true);
                        }
                    }
                    else
                    {


                        usuarioInfo.gacc_CarNombre = gacc_txtnombre.Text;
                        usuarioInfo.gacc_CarEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                        GACC_ControladorCargo.save(usuarioInfo);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                    }
                }
            }catch(Exception e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO guardados   ')", true);
            }
        }

        protected void gacc_lnkguardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        protected void gacc_lnkeditar_Click(object sender, EventArgs e)
        {
            usuarioInfo = new GACC_TblCargo();

            string hdfValor = gacc_hdfCargo.Value;
            if (hdfValor == gacc_txtnombre.Text)
            {
                GuardarDatos(int.Parse(Request["cod"]));
            }
            else if (hdfValor != gacc_txtnombre.Text)
            {

                var existe = GACC_ControladorCargo.AutentificarCargoxnombre(gacc_txtnombre.Text);
                {
                    if (existe != null)
                    {

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El  cargo ya  existe')", true);

                    }

                    else
                    {
                        GuardarDatos(int.Parse(Request["cod"]));

                    }
                }
            }
        }





        private void Modificar(GACC_TblCargo usuarioInfo)
        {
            try
            {
                usuarioInfo.gacc_CarNombre = gacc_txtnombre.Text;
                usuarioInfo.gacc_CarEstado = Convert.ToChar(gacc_ddlestado.Text);
                GACC_ControladorCargo.modify(usuarioInfo);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos modificados')", true);
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
                usuarioInfo = GACC_ControladorCargo.ObtenerCargoxid(id);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }
        protected void gacc_lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorListarCargo.aspx");
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