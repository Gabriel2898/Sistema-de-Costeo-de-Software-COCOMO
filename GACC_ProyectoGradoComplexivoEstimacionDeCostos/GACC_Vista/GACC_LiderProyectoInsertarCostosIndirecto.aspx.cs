using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GACC_Modelo;
using GACC_Controlador;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_LiderProyectoInsertarCostosIndirecto1 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        GACC_ViewCosto usu = new GACC_ViewCosto();
        GACC_TblProyectoTblCostoIndirecto usuario = new GACC_TblProyectoTblCostoIndirecto();
        private GACC_TblCostoIndirecto usuarioInfo = new GACC_TblCostoIndirecto();
        protected void Page_Load(object sender, EventArgs e)
        {

            int n = GACC_ControladorCostoIndirecto.RetornarId();
            TextBox1.Text = n.ToString();


            if (!IsPostBack)
            {
                gacc_txtnombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
                gacc_txtvalor.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                Session.Timeout = 60;
                if (Session["LiderProyecto"] != null)
                {
                    gacc_lblnombreusuario.Text = Session["LiderProyecto"].ToString();
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
                    usu = GACC_ControladorCostoIndirecto.ObtenerCostoIxidvista(codigo);
                    if (usuarioInfo != null)
                    {
                        gacc_hdfNombreproyecto.Value = usu.gacc_NompId.ToString();
                        gacc_hdfNombre.Value = usu.gacc_CostNombre.ToString();
                        gacc_txtnombre.Text = usu.gacc_CostNombre.ToString();
                        gacc_ddlestado.SelectedValue = usu.gacc_CostEstado.ToString();
                        gacc_txtvalor.Text = usu.gacc_CostValor.ToString();
                        gacc_ddlempresa.SelectedValue = usu.gacc_EmpId.ToString();
                        gacc_ddlnombreproyecto.SelectedValue = usu.gacc_CostNombreProyectoID.ToString();

                    }

                }
                else
                {
                    gacc_lblestado.Visible = false;
                    gacc_ddlestado.Visible = false;
                    gacc_ddlestado.Items.FindByValue("I").Enabled = false;
                }
                cargarEmpresa();
                cargarNombreProyecto();
            
                
            }
        }

        private void cargarEmpresa()
        {
            List<GACC_ViewEmpresaNombreUsuario> listaProveedor = new List<GACC_ViewEmpresaNombreUsuario>();
            listaProveedor = GACC_ControladorEmpresa.ObtenerEmpresaxvisatanombreusuario(gacc_lblnombreusuario.Text);
            listaProveedor.Insert(0, new GACC_ViewEmpresaNombreUsuario() { gacc_EmpNombre = "Nombre Empresa" });
            gacc_ddlempresa.DataSource = listaProveedor;
            gacc_ddlempresa.DataTextField = "gacc_EmpNombre";
            gacc_ddlempresa.DataValueField = "gacc_EmpId";
            gacc_ddlempresa.DataBind();
        }
        private void cargarNombreProyecto()
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) &&  nombreproyecto.gacc_PerUsuarioNombre == Convert.ToString(gacc_lblnombreusuario.Text) select nombreproyecto).ToList();
            listaProveedor.Insert(0, new GACC_ViewNombreProyectoEmpresa() { gacc_NompNombre = "Nombre Proyecto" });
            gacc_ddlnombreproyecto.DataSource = list;
            gacc_ddlnombreproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombreproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombreproyecto.DataBind();
        }
        private void Limpiar()
        {
            gacc_txtnombre.Text = string.Empty;
            gacc_ddlnombreproyecto.Text = null;
            gacc_ddlestado.Text = null;
            gacc_txtvalor.Text = string.Empty;
        }


       
        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["LiderProyecto"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }

        protected void gacc_lnknuevo_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("GACC_LiderProyectoInsertarCostosIndirecto.aspx");
        }
        private void Guardar()
        {
            usuario = new GACC_TblProyectoTblCostoIndirecto();
            usuarioInfo = new GACC_TblCostoIndirecto();
            try
            {

                bool existe = GACC_ControladorCostoIndirecto.AutentificarCostoproyectocosto(Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue), gacc_txtnombre.Text);
                {
                    if (existe)
                    {
                        GACC_TblCostoIndirecto usur = new GACC_TblCostoIndirecto();
                        usur = GACC_ControladorCostoIndirecto.ObtenerCostoproyectonombre(Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue), gacc_txtnombre.Text);
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre del costo ya  existe')", true);
                        }
                    }
                    else
                    {
                        bool existepersona = GACC_ControladorProyectoCostoIndirecto.AutentificarCostoProyecto(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue));
                        {
                            if (existepersona)
                            {
                                

                                    usuarioInfo.gacc_CostId = Convert.ToInt32(TextBox1.Text);
                                    usuarioInfo.gacc_CostNombre = gacc_txtnombre.Text;
                                    usuarioInfo.gacc_CostNombreProyectoID = Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue);
                                    usuarioInfo.gacc_CostValor = Convert.ToDecimal(gacc_txtvalor.Text);
                                    usuarioInfo.gacc_CostEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                    GACC_ControladorCostoIndirecto.save(usuarioInfo);
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                                    Response.Redirect("GACC_LiderProyectoListarCostosIndirecto.aspx");
                                
                            }
                            else
                            {

                                usuario.gacc_CodCostId = Convert.ToInt32(TextBox1.Text);
                                usuario.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue); usuarioInfo.gacc_CostId = Convert.ToInt32(TextBox1.Text);
                                usuarioInfo.gacc_CostId = Convert.ToInt32(TextBox1.Text);
                                usuarioInfo.gacc_CostNombre = gacc_txtnombre.Text;
                                usuarioInfo.gacc_CostNombreProyectoID = Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue);
                                usuarioInfo.gacc_CostValor = Convert.ToDecimal(gacc_txtvalor.Text);
                                usuarioInfo.gacc_CostEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                GACC_ControladorCostoIndirecto.save(usuarioInfo);
                                GACC_ControladorProyectoCostoIndirecto.save(usuario);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                            }
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO guardados   ')" , true);
            }
        }

        protected void gacc_lnkguardar_Click(object sender, EventArgs e)
        {

           
            Guardar();
        }

        protected void gacc_lnkeditar_Click(object sender, EventArgs e)
        {

            usuarioInfo = new GACC_TblCostoIndirecto();

            string hdfValor = gacc_hdfNombreproyecto.Value;
            string hdfvalor2 = gacc_hdfNombre.Value;
            if ((hdfvalor2 == gacc_txtnombre.Text) && (hdfValor == gacc_ddlnombreproyecto.SelectedValue))
            {
                GuardarDatos(int.Parse(Request["cod"]));
            }

            else if ((hdfValor != gacc_txtnombre.Text) || (hdfvalor2 != gacc_ddlnombreproyecto.SelectedValue))
            {
                var existe = GACC_ControladorCostoIndirecto.Autentificostoxproyecto(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue));
                {
                    if (existe != null)
                    {

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El Costo ya  existe')", true);

                    }
                    else
                    {
                        GuardarDatos(int.Parse(Request["cod"]));
                    }

                }

            }

        }

        private void Modificar(GACC_TblCostoIndirecto usuarioInfo)
        {
            try
            {
                usuarioInfo.gacc_CostNombre = gacc_txtnombre.Text;
                usuarioInfo.gacc_CostNombreProyectoID = Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue);
                usuarioInfo.gacc_CostValor = Convert.ToDecimal(gacc_txtvalor.Text);
                usuarioInfo.gacc_CostEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                GACC_ControladorCostoIndirecto.modify(usuarioInfo);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos modificados  ')", true);
            }
            catch (Exception e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO modificados  ')" , true);
            }
        }
        private void GuardarDatos(int codigo)
        {
            if (codigo == 0)
            {
                Guardar();
            }
            else
            {
                usuarioInfo = GACC_ControladorCostoIndirecto.ObtenerCostoIxid(codigo);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }

        protected void gacc_lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarCostosIndirecto.aspx");
        }

        protected void gacc_lnklimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }




        protected void gacc_ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_NompEstado == 'E' && nombreproyecto.gacc_PerUsuarioNombre == Convert.ToString(gacc_lblnombreusuario.Text) select nombreproyecto).ToList();
            listaProveedor.Insert(0, new GACC_ViewNombreProyectoEmpresa() { gacc_NompNombre = "Nombre Proyecto" });
            gacc_ddlnombreproyecto.DataSource = list;
            gacc_ddlnombreproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombreproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombreproyecto.DataBind();

        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }

        protected void gacc_lnkcosteo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoInsertarProyecto.aspx");

        }
    }
}