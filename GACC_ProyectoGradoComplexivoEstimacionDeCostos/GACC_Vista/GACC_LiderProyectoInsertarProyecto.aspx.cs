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
    public partial class GACC_LiderProyectoInsertarProyecto1 : System.Web.UI.Page
    {
        GACC_ViewTablaProyecto2 usu = new GACC_ViewTablaProyecto2();

        DataClasses1DataContext dc = new DataClasses1DataContext();

        private GACC_TblProyecto usuarioInfo = new GACC_TblProyecto();
        protected void Page_Load(object sender, EventArgs e)
        {
            Wizard1.PreRender += new EventHandler(Wizard1_PreRender);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            gacc_txtcostoindirecto.Attributes["disabled"] = "disabled";
            gacc_txtcostotrabajadores.Attributes["disabled"] = "disabled";
            gacc_txtcostototal.Attributes["disabled"] = "disabled";
            gacc_ddlgestordebase.Attributes["disabled"] = "disabled";
            gacc_ddlmodelodeproyecto.Attributes["disabled"] = "disabled";
            gacc_ddltipoproyecto.Attributes["disabled"] = "disabled";
            gacc_ddllenguajes.Attributes["disabled"] = "disabled";
            gacc_txtesfuerzoajustado.Attributes["disabled"] = "disabled";
            gacc_txtesfuerzonominal.Attributes["disabled"] = "disabled";
            gacc_txtlineasdecodigo.Attributes["disabled"] = "disabled";
            gacc_txtnumeropersonas.Attributes["disabled"] = "disabled";
            gacc_txttiempo.Attributes["disabled"] = "disabled";
            gacc_ddlestado.Attributes["disabled"] = "disabled";
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

                cargarEmpresa();
                cargarNombreProyecto();
            }
        }

        private int sumalineaodigo()
        {

            var x = from a in dc.GACC_ViewActividadTarea2
                    where a.gacc_NompId == int.Parse(gacc_ddlnombredelproyecto.SelectedValue)
                    select a;
            var suma = Convert.ToInt32(x.Sum(y => y.gacc_TarLineaCodigo as int?) ?? 0);
            gacc_txtlineasdecodigo.Text = Convert.ToString(suma);
            return suma;

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
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_PerUsuarioNombre == Convert.ToString(gacc_lblnombreusuario.Text) && nombreproyecto.gacc_NompEstado == 'F' select nombreproyecto).ToList();
            listaProveedor.Insert(0, new GACC_ViewNombreProyectoEmpresa() { gacc_NompNombre = "Nombre Proyecto" });
            gacc_ddlnombredelproyecto.DataSource = list;
            gacc_ddlnombredelproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombredelproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombredelproyecto.DataBind();
        }
        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["LiderProyecto"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }
        
        protected void gacc_lnkeditar_Click(object sender, EventArgs e)
        {
            try
            {
                var query = (from a in dc.GACC_TblProyecto
                             where a.gacc_CodNompId == Convert.ToInt32(gacc_ddlnombredelproyecto.SelectedValue)
                             select a).ToList();

                foreach (var item in query)
                {

                    item.gacc_ProCostoTrabajadores = Convert.ToDecimal(gacc_txtcostotrabajadores.Text);
                    item.gacc_ProCostoCostoIndirectos = Convert.ToDecimal(gacc_txtcostoindirecto.Text);
                    item.gacc_ProCostoTotal = Convert.ToDecimal(gacc_txtcostototal.Text);
                }

                dc.SubmitChanges();



                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos Insertados ')", true);
            }
            catch (Exception exx)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO Insertados  ')", true);
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


        
        protected void gacc_lnkcalculartodo_Click(object sender, EventArgs e)
        {

            CostosIndirectos();
            Salario();
            decimal tiempo = Convert.ToDecimal(gacc_txttiempo.Text);
            decimal costototal = Math.Round(CostosIndirectos() * tiempo, 2);
            double costoindirecto = Convert.ToDouble(costototal);
            gacc_txtcostoindirecto.Text = costoindirecto.ToString();
            decimal esfuerzo = Convert.ToDecimal(gacc_txtesfuerzoajustado.Text);
            decimal salario = Convert.ToDecimal(gacc_txtcostotrabajadores.Text);
            decimal costoproyecto = Math.Round(esfuerzo * salario, 2);
            decimal costototalproyecto = Math.Round(costoproyecto + costototal, 2);
            gacc_txtcostototal.Text = costototalproyecto.ToString();


        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            int id = int.Parse(gacc_ddlnombredelproyecto.SelectedValue);
            var Contacto = GACC_ControladorProyecto.BuscarProyecto(id);
            gacc_txtesfuerzoajustado.Text = Contacto.gacc_ProEsfuerzoAjustado.ToString();
            gacc_txtesfuerzonominal.Text = Contacto.gacc_ProEsfuerzoNominal.ToString();
            gacc_ddlgestordebase.Text = Contacto.gacc_ProGestorBaseDatos.ToString();
            gacc_ddllenguajes.Text = Contacto.gacc_ProLenguaje.ToString();
            gacc_txtlineasdecodigo.Text = Contacto.gacc_ProLineasCodigo.ToString();
            gacc_ddlmodelodeproyecto.Text = Contacto.gacc_ProModeloProyecto.ToString();
            gacc_txtnumeropersonas.Text = Contacto.gacc_ProNumeroPersonas.ToString();
            gacc_txttiempo.Text = Contacto.gacc_ProTiempo.ToString();
            gacc_ddltipoproyecto.Text = Contacto.gacc_ProTipoProyecto.ToString();
            gacc_ddlestado.Text = Contacto.gacc_ProEstado.ToString();
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