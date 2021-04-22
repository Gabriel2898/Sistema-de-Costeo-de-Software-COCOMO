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
    public partial class GACC_LiderProyectoEditarProyecto1 : System.Web.UI.Page
    {
        GACC_ViewTablaProyecto2 usu = new GACC_ViewTablaProyecto2();

        DataClasses1DataContext dc = new DataClasses1DataContext();

        private GACC_TblProyecto usuarioInfo = new GACC_TblProyecto();
        protected void Page_Load(object sender, EventArgs e)
        {
            Wizard1.PreRender += new EventHandler(Wizard1_PreRender);
            if (!IsPostBack)
            {
                gacc_txtcostoindirecto.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_txtcostototal.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_txtcostotrabajadores.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_txtesfuerzoajustado.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_txtesfuerzonominal.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_txtlineasdecodigo.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_txtnumeropersonas.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_txttiempo.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
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
                    Wizard1.DisplaySideBar = false;
                    gacc_txtcostoindirecto.Attributes["disabled"] = "disabled";
                    gacc_txtcostotrabajadores.Attributes["disabled"] = "disabled";
                    gacc_txtlineasdecodigo.Attributes["disabled"] = "disabled";
                    gacc_txtcostototal.Attributes["disabled"] = "disabled";
                    gacc_txtesfuerzoajustado.Attributes["disabled"] = "disabled";
                    gacc_txtesfuerzonominal.Attributes["disabled"] = "disabled";
                    gacc_txtnumeropersonas.Attributes["disabled"] = "disabled";
                    gacc_txttiempo.Attributes["disabled"] = "disabled";
                    gacc_lnkeditar.Visible = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    usu = GACC_ControladorProyecto.ObtenerProyectoxidvista(codigo);
                    if (usuarioInfo != null)
                    {
                        gacc_hdfNombreproyecto.Value = usu.gacc_NompId.ToString();
                        gacc_hdfNombreproyecto1.Value = usu.gacc_EmpId.ToString();
                        gacc_ddlempresa.Text = usu.gacc_EmpId.ToString();
                        gacc_ddlnombredelproyecto.Text = usu.gacc_NompId.ToString();
                        gacc_txtlineasdecodigo.Text = usu.gacc_ProLineasCodigo.ToString();
                        gacc_ddllenguajes.Text = usu.gacc_ProLenguaje.ToString();
                        gacc_ddlgestordebase.Text = usu.gacc_ProGestorBaseDatos.ToString();
                        gacc_ddltipoproyecto.Text = usu.gacc_ProTipoProyecto.ToString();
                        gacc_ddlmodelodeproyecto.Text = usu.gacc_ProModeloProyecto.ToString();
                        gacc_txtesfuerzonominal.Text = usu.gacc_ProEsfuerzoNominal.ToString();
                        gacc_txtesfuerzoajustado.Text = usu.gacc_ProEsfuerzoAjustado.ToString();
                        gacc_txttiempo.Text = usu.gacc_ProTiempo.ToString();
                        gacc_txtcostotrabajadores.Text = usu.gacc_ProCostoTrabajadores.ToString();
                        gacc_txtcostoindirecto.Text = usu.gacc_ProCostoCostoIndirectos.ToString();
                        gacc_txtcostototal.Text = usu.gacc_ProCostoTotal.ToString();
                        gacc_txtnumeropersonas.Text = usu.gacc_ProNumeroPersonas.ToString();
                        gacc_lineascodigoexistentes.Text = usu.gacc_ProLineaCodigoExistente.ToString();
                        gacc_ddlestado.Text = usu.gacc_ProEstado.ToString();
                        gacc_fechainicio.Text = usu.gacc_ProFechaInicio.ToString("yyyy-MM-dd");
                        gacc_fechafin.Text = usu.gacc_ProFechaFin.ToString("yyyy-MM-dd");
                    }
                }
                cargarEmpresa();
                cargarNombreProyecto();
                modeloproyecto();
            }
        }
        private void modeloproyecto()
        {
            int x;
            x = Convert.ToInt32(gacc_txtlineasdecodigo.Text);
            if (x <= 50)
            {
                gacc_ddltipoproyecto.Items.FindByValue("Semi-Libre").Enabled = false;
                gacc_ddltipoproyecto.Items.FindByValue("Empotrado").Enabled = false;
                gacc_ddltipoproyecto.Items.FindByValue("Orgánico").Enabled = true;

            }
            else if (x > 50 && x < 300)
            {
                gacc_ddltipoproyecto.Items.FindByValue("Orgánico").Enabled = false;
                gacc_ddltipoproyecto.Items.FindByValue("Empotrado").Enabled = false;
                gacc_ddltipoproyecto.Items.FindByValue("Semi-Libre").Enabled = true;


            }
            else if (x >= 300)
            {
                gacc_ddltipoproyecto.Items.FindByValue("Semi-Libre").Enabled = false;
                gacc_ddltipoproyecto.Items.FindByValue("Orgánico").Enabled = false;
                gacc_ddltipoproyecto.Items.FindByValue("Empotrado").Enabled = true;

            }

        }
        private decimal Salario()
        {

            var x = from a in dc.GACC_ViewPersonaProyecto
                    where a.gacc_NompId == int.Parse(gacc_ddlnombredelproyecto.SelectedValue)
                    select a;
            var suma = Convert.ToDecimal(x.Sum(y => y.gacc_PerSalario as decimal?) ?? 0);
            gacc_txtcostotrabajadores.Text = Convert.ToString(suma);
            return suma;
        }
        private decimal CostosIndirectos()
        {

            var x = from a in dc.GACC_TblCostoIndirecto
                    where a.gacc_CostNombreProyectoID == int.Parse(gacc_ddlnombredelproyecto.SelectedValue)
                    select a;
            var sumacosto = Convert.ToDecimal(x.Sum(y => y.gacc_CostValor as decimal?) ?? 0);
            gacc_txtcostoindirecto.Text = Convert.ToString(sumacosto);
            return sumacosto;
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
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) select nombreproyecto).ToList();
            listaProveedor.Insert(0, new GACC_ViewNombreProyectoEmpresa() { gacc_NompNombre = "Nombre Proyecto" });
            gacc_ddlnombredelproyecto.DataSource = list;
            gacc_ddlnombredelproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombredelproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombredelproyecto.DataBind();
        }
        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            Session["LiderProyecto"] = null;
            Response.Redirect("GACC_Index.aspx");
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }

        protected void gacc_lnkeditar_Click(object sender, EventArgs e)
        {
            usuarioInfo = new GACC_TblProyecto();

            string hdfValor = gacc_hdfNombreproyecto.Value;
            string hdfvalor2 = gacc_hdfNombreproyecto1.Value;
            if ((hdfValor == gacc_ddlnombredelproyecto.SelectedValue) && (hdfvalor2 == gacc_ddlempresa.SelectedValue))
            {
                GuardarDatos(int.Parse(Request["cod"]));
            }

            else if ((hdfValor != gacc_ddlnombredelproyecto.SelectedValue) || (hdfvalor2 != gacc_ddlempresa.SelectedValue))
            {
                var existe = GACC_ControladorProyecto.Autentificarproyectoempresa(Convert.ToInt32(gacc_ddlnombredelproyecto.SelectedValue), Convert.ToInt32(gacc_ddlempresa.SelectedValue));
                {
                    if (existe != null)
                    {

                        GACC_TblProyecto usur = new GACC_TblProyecto();
                        usur = GACC_ControladorProyecto.ObtenerProyectoxnombreyempresa(Convert.ToInt32(gacc_ddlnombredelproyecto.SelectedValue), Convert.ToInt32(gacc_ddlempresa.SelectedValue));

                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ya existe este Costeo ')", true);
                        }

                    }
                    else
                    {
                        GuardarDatos(int.Parse(Request["cod"]));
                    }

                }

            }
        }
        private void Modificar(GACC_TblProyecto usuarioInfo)
        {
            try
            {

                usuarioInfo.gacc_CodEmpId = Convert.ToInt32(gacc_ddlempresa.SelectedValue);
                usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombredelproyecto.SelectedValue);
                usuarioInfo.gacc_ProLineasCodigo = Convert.ToInt32(gacc_txtlineasdecodigo.Text);
                usuarioInfo.gacc_ProLenguaje = gacc_ddllenguajes.Text;
                usuarioInfo.gacc_ProGestorBaseDatos = gacc_ddlgestordebase.Text;
                usuarioInfo.gacc_ProTipoProyecto = gacc_ddltipoproyecto.Text;
                usuarioInfo.gacc_ProModeloProyecto = gacc_ddlmodelodeproyecto.Text;
                usuarioInfo.gacc_ProEsfuerzoNominal = Convert.ToDecimal(gacc_txtesfuerzonominal.Text);
                usuarioInfo.gacc_ProEsfuerzoAjustado = Convert.ToDecimal(gacc_txtesfuerzoajustado.Text);
                usuarioInfo.gacc_ProTiempo = Convert.ToDecimal(gacc_txttiempo.Text);
                usuarioInfo.gacc_ProCostoTrabajadores = Convert.ToDecimal(gacc_txtcostotrabajadores.Text);
                usuarioInfo.gacc_ProCostoCostoIndirectos = Convert.ToDecimal(gacc_txtcostoindirecto.Text);
                usuarioInfo.gacc_ProCostoTotal = Convert.ToDecimal(gacc_txtcostototal.Text);
                usuarioInfo.gacc_ProNumeroPersonas = Convert.ToDecimal(gacc_txtnumeropersonas.Text);
                usuarioInfo.gacc_ProEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                usuarioInfo.gacc_ProLineaCodigoExistente = Convert.ToInt32(gacc_lineascodigoexistentes.Text);
                usuarioInfo.gacc_ProFechaInicio = Convert.ToDateTime(gacc_fechainicio.Text);
                usuarioInfo.gacc_ProFechaFin = Convert.ToDateTime(gacc_fechafin.Text);
                GACC_ControladorProyecto.modify(usuarioInfo);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos modificados  ')", true);

            }
            catch (Exception e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO modificados  ')", true);
            }
        }
        private void GuardarDatos(int codigo)
        {
            if (codigo == 0)
            {
                //Guardar();
            }
            else
            {
                usuarioInfo = GACC_ControladorProyecto.ObtenerProyectoxid(codigo);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }




        }

        protected void gacc_ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_PerUsuarioNombre == Convert.ToString(gacc_lblnombreusuario.Text) && nombreproyecto.gacc_NompEstado == 'E' select nombreproyecto).ToList();
            listaProveedor.Insert(0, new GACC_ViewNombreProyectoEmpresa() { gacc_NompNombre = "Nombre Proyecto" });
            gacc_ddlnombredelproyecto.DataSource = list;
            gacc_ddlnombredelproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombredelproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombredelproyecto.DataBind();
        }

        protected void gacc_lnkcalcular_Click(object sender, EventArgs e)
        {
            decimal sumasalario = Math.Round(Salario(), 2);
            decimal sumacosto = Math.Round(CostosIndirectos(), 2);
            gacc_txtcostotrabajadores.Text = Convert.ToString(sumasalario);
            gacc_txtcostoindirecto.Text = Convert.ToString(sumacosto);
            modeloproyecto();
        }

        protected void gacc_lnkcalculartodo_Click(object sender, EventArgs e)
        {

        }

        protected void Wizard1_PreRender(object sender, EventArgs e)
        {
            Repeater SideBarList = Wizard1.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
            SideBarList.DataSource = Wizard1.WizardSteps;
            SideBarList.DataBind();

        }

        protected string GetClassForWizardStep(object wizardStep)
        {
            WizardStep step = wizardStep as WizardStep;

            if (step == null)
            {
                return "";
            }
            int stepIndex = Wizard1.WizardSteps.IndexOf(step);

            if (stepIndex < Wizard1.ActiveStepIndex)
            {
                return "prevStep";
            }
            else if (stepIndex > Wizard1.ActiveStepIndex)
            {
                return "nextStep";
            }
            else
            {
                return "currentStep";
            }
        }

    }
}