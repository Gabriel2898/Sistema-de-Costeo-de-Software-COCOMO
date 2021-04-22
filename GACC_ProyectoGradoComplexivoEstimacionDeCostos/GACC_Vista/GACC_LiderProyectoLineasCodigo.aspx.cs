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
    public partial class GACC_LiderProyectoLineasCodigo1 : System.Web.UI.Page
    {
        GACC_ViewTablaProyecto2 usu = new GACC_ViewTablaProyecto2();

        DataClasses1DataContext dc = new DataClasses1DataContext();

        private GACC_TblProyecto usuarioInfo = new GACC_TblProyecto();
        protected void Page_Load(object sender, EventArgs e)
        {
            Wizard1.PreRender += new EventHandler(Wizard1_PreRender);
            int indice = gacc_ddllenguajeslineas.SelectedIndex;
            gacc_ddllenguajes.Text = gacc_ddllenguajeslineas.Items[indice].ToString();
            gacc_ddlestado.Items.FindByValue("I").Enabled = false;
            gacc_lblestado.Visible = false;
            gacc_ddlestado.Visible = false;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            gacc_entrada4.Attributes["disabled"] = "disabled";
            gacc_fechafin.Attributes["disabled"] = "disabled";
            gacc_entrada8.Attributes["disabled"] = "disabled";
            gacc_entrada12.Attributes["disabled"] = "disabled";
            gacc_entrada16.Attributes["disabled"] = "disabled";
            gacc_entrada20.Attributes["disabled"] = "disabled";
            gacc_entrada21.Attributes["disabled"] = "disabled";
            gacc_total.Attributes["disabled"] = "disabled";
            gacc_factorajuste.Attributes["disabled"] = "disabled";
            gacc_puntosfuncion.Attributes["disabled"] = "disabled";
            gacc_txtlineasdecodigo.Attributes["disabled"] = "disabled";
            gacc_lineascodigoexistentes.Attributes["disabled"] = "disabled";
            gacc_txtresultado.Attributes["disabled"] = "disabled";
            gacc_txtesfuerzonominal.Attributes["disabled"] = "disabled";
            gacc_txtesfuerzoajustado.Attributes["disabled"] = "disabled";
            gacc_txttiempo.Attributes["disabled"] = "disabled";
            gacc_txtnumeropersonas.Attributes["disabled"] = "disabled";

            modeloproyecto();
            if (Wizard1.ActiveStepIndex == Wizard1.WizardSteps.IndexOf(this.WizardStep4))
            {
                if ((gacc_ddlmodelodeproyecto.SelectedValue == "Básico"))
                {
                    Wizard1.MoveTo(this.WizardStep5);
                }
                else
                {
                    Wizard1.MoveTo(this.WizardStep4);
                }
            }

            if (!IsPostBack)
            {

                gacc_entrada1.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada2.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada3.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada5.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada6.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada7.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada9.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada10.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada11.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada13.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada14.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada15.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada17.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada18.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_entrada19.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc1.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc2.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc3.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc4.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc5.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc6.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc7.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc8.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc9.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc10.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc11.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc12.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc13.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_fc14.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
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
        private void cargarEmpresa()
        {
            List<GACC_ViewEmpresaNombreUsuario> listaProveedor = new List<GACC_ViewEmpresaNombreUsuario>();
            listaProveedor = GACC_ControladorEmpresa.ObtenerEmpresaxvisatanombreusuario(gacc_lblnombreusuario.Text);
            listaProveedor.Insert(0, new GACC_ViewEmpresaNombreUsuario() { gacc_EmpNombre = "" });
            gacc_ddlempresa.DataSource = listaProveedor;
            gacc_ddlempresa.DataTextField = "gacc_EmpNombre";
            gacc_ddlempresa.DataValueField = "gacc_EmpId";
            gacc_ddlempresa.DataBind();
        }
        private void cargarNombreProyecto()
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) select nombreproyecto).ToList();
            listaProveedor.Insert(0, new GACC_ViewNombreProyectoEmpresa() { gacc_NompNombre = "" });
            gacc_ddlnombredelproyecto.DataSource = list;
            gacc_ddlnombredelproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombredelproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombredelproyecto.DataBind();
        }
        private void modeloproyecto()
        {
            double x;
            x = Convert.ToDouble(gacc_txtlineasdecodigo.Text)/1000;
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
        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            Session["LiderProyecto"] = null;
            Response.Redirect("GACC_Index.aspx");
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }

        public void Guardar()
        {
            DateTime hoy = DateTime.Today;
            DateTime f = Convert.ToDateTime(gacc_fechainicio.Text);
            usuarioInfo = new GACC_TblProyecto();
            try
            {

                bool existeced = GACC_ControladorProyecto.AutentificarProyectoxnombreyempresa(Convert.ToInt32(gacc_ddlnombredelproyecto.SelectedValue), Convert.ToInt32(gacc_ddlempresa.SelectedValue));
                {
                    if (existeced)
                    {
                        GACC_TblProyecto usur = new GACC_TblProyecto();
                        usur = GACC_ControladorProyecto.ObtenerProyectoxnombreyempresa(Convert.ToInt32(gacc_ddlnombredelproyecto.SelectedValue), Convert.ToInt32(gacc_ddlempresa.SelectedValue));
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ya existe este Costeo ')", true);
                        }

                    }
                    else if (DateTime.Compare(f, hoy) < 0)
                    {


                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Escoja una Fecha actual o mayor')", true);

                        }
                    }
                    else
                    {

                        usuarioInfo.gacc_ProFechaInicio = Convert.ToDateTime(gacc_fechainicio.Text);
                        usuarioInfo.gacc_ProFechaFin = Convert.ToDateTime(gacc_fechafin.Text);
                        usuarioInfo.gacc_CodEmpId = Convert.ToInt32(gacc_ddlempresa.Text);
                        usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombredelproyecto.Text);
                        usuarioInfo.gacc_ProLineasCodigo = Convert.ToInt32(gacc_txtlineasdecodigo.Text);
                        usuarioInfo.gacc_ProLineaCodigoExistente = Convert.ToInt32(gacc_lineascodigoexistentes.Text);
                        usuarioInfo.gacc_ProLenguaje = gacc_ddllenguajes.Text;
                        usuarioInfo.gacc_ProGestorBaseDatos = gacc_ddlgestordebase.Text;
                        usuarioInfo.gacc_ProTipoProyecto = gacc_ddltipoproyecto.Text;
                        usuarioInfo.gacc_ProModeloProyecto = gacc_ddlmodelodeproyecto.Text;
                        usuarioInfo.gacc_ProEsfuerzoNominal = Convert.ToDecimal(gacc_txtesfuerzonominal.Text);
                        usuarioInfo.gacc_ProEsfuerzoAjustado = Convert.ToDecimal(gacc_txtesfuerzoajustado.Text);
                        usuarioInfo.gacc_ProTiempo = Convert.ToDecimal(gacc_txttiempo.Text);
                        usuarioInfo.gacc_ProNumeroPersonas = Convert.ToDecimal(gacc_txtnumeropersonas.Text);
                        usuarioInfo.gacc_ProEstado = Convert.ToChar(gacc_ddlestado.Text);
                        GACC_ControladorProyecto.save(usuarioInfo);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO guardados   ')", true);
            }
        }
        protected void gacc_lnkGuardar_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            DateTime f = Convert.ToDateTime(gacc_fechainicio.Text);
            usuarioInfo = new GACC_TblProyecto();
            try
            {

                bool existeced = GACC_ControladorProyecto.AutentificarProyectoxnombreyempresa(Convert.ToInt32(gacc_ddlnombredelproyecto.SelectedValue), Convert.ToInt32(gacc_ddlempresa.SelectedValue));
                {
                    if (existeced)
                    {
                        GACC_TblProyecto usur = new GACC_TblProyecto();
                        usur = GACC_ControladorProyecto.ObtenerProyectoxnombreyempresa(Convert.ToInt32(gacc_ddlnombredelproyecto.SelectedValue), Convert.ToInt32(gacc_ddlempresa.SelectedValue));
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ya existe este Costeo ')", true);
                        }

                    }
                    else if (DateTime.Compare(f, hoy) < 0)
                    {


                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Escoja una Fecha actual o mayor')", true);

                        }
                    }
                    else
                    {

                        usuarioInfo.gacc_ProFechaInicio = Convert.ToDateTime(gacc_fechainicio.Text);
                        usuarioInfo.gacc_ProFechaFin = Convert.ToDateTime(gacc_fechafin.Text);
                        usuarioInfo.gacc_CodEmpId = Convert.ToInt32(gacc_ddlempresa.Text);
                        usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombredelproyecto.Text);
                        usuarioInfo.gacc_ProLineasCodigo = Convert.ToInt32(gacc_txtlineasdecodigo.Text);
                        usuarioInfo.gacc_ProLineaCodigoExistente = Convert.ToInt32(gacc_lineascodigoexistentes.Text);
                        usuarioInfo.gacc_ProLenguaje = gacc_ddllenguajes.Text;
                        usuarioInfo.gacc_ProGestorBaseDatos = gacc_ddlgestordebase.Text;
                        usuarioInfo.gacc_ProTipoProyecto = gacc_ddltipoproyecto.Text;
                        usuarioInfo.gacc_ProModeloProyecto = gacc_ddlmodelodeproyecto.Text;
                        usuarioInfo.gacc_ProEsfuerzoNominal = Convert.ToDecimal(gacc_txtesfuerzonominal.Text);
                        usuarioInfo.gacc_ProEsfuerzoAjustado = Convert.ToDecimal(gacc_txtesfuerzoajustado.Text);
                        usuarioInfo.gacc_ProTiempo = Convert.ToDecimal(gacc_txttiempo.Text);
                        usuarioInfo.gacc_ProNumeroPersonas = Convert.ToDecimal(gacc_txtnumeropersonas.Text);
                        usuarioInfo.gacc_ProEstado = Convert.ToChar(gacc_ddlestado.Text);
                        GACC_ControladorProyecto.save(usuarioInfo);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO guardados   ')" , true);
            }

        }

        protected void gacc_lnktotalPFNA_Click(object sender, EventArgs e)
        {
            int total, total2, total3, total4, total5;
            total = (int.Parse(gacc_entrada1.Text) * 3) + (int.Parse(gacc_entrada2.Text) * 4) + (int.Parse(gacc_entrada3.Text) * 6);
            gacc_entrada4.Text = total.ToString();
            total2 = (int.Parse(gacc_entrada5.Text) * 4) + (int.Parse(gacc_entrada6.Text) * 5) + (int.Parse(gacc_entrada7.Text) * 7);
            gacc_entrada8.Text = total2.ToString();
            total3 = (int.Parse(gacc_entrada9.Text) * 7) + (int.Parse(gacc_entrada10.Text) * 10) + (int.Parse(gacc_entrada11.Text) * 15);
            gacc_entrada12.Text = total3.ToString();
            total4 = (int.Parse(gacc_entrada13.Text) * 5) + (int.Parse(gacc_entrada14.Text) * 7) + (int.Parse(gacc_entrada15.Text) * 10);
            gacc_entrada16.Text = total4.ToString();
            total5 = (int.Parse(gacc_entrada17.Text) * 3) + (int.Parse(gacc_entrada18.Text) * 4) + (int.Parse(gacc_entrada19.Text) * 6);
            gacc_entrada20.Text = total5.ToString();
            int suma = Convert.ToInt32(gacc_entrada4.Text) + Convert.ToInt32(gacc_entrada8.Text) + Convert.ToInt32(gacc_entrada12.Text) + Convert.ToInt32(gacc_entrada16.Text) + Convert.ToInt32(gacc_entrada20.Text);
            gacc_entrada21.Text = suma.ToString();
        }

        protected void gacc_lnktotalFA_Click(object sender, EventArgs e)
        {
            int total = int.Parse(gacc_fc1.Text) + int.Parse(gacc_fc2.Text) + int.Parse(gacc_fc3.Text) + int.Parse(gacc_fc4.Text) + int.Parse(gacc_fc5.Text) +
              int.Parse(gacc_fc6.Text) + int.Parse(gacc_fc7.Text) + int.Parse(gacc_fc8.Text) + int.Parse(gacc_fc9.Text) + int.Parse(gacc_fc10.Text) + int.Parse(gacc_fc11.Text) +
              int.Parse(gacc_fc12.Text) + int.Parse(gacc_fc13.Text) + int.Parse(gacc_fc14.Text);
            gacc_total.Text = total.ToString();
        }

        protected void gacc_lnklineas_Click(object sender, EventArgs e)
        {
            double FA = (0.01 * Convert.ToDouble(gacc_total.Text)) + 0.65;
            gacc_factorajuste.Text = FA.ToString();
            double PuntosFuncionPF = Math.Round(Convert.ToDouble(gacc_entrada21.Text) * Convert.ToDouble(gacc_factorajuste.Text), 2);
            gacc_puntosfuncion.Text = PuntosFuncionPF.ToString();
            double lineas = Math.Round(double.Parse(gacc_puntosfuncion.Text) * double.Parse(gacc_ddllenguajeslineas.SelectedValue),0);
            gacc_txtlineasdecodigo.Text = lineas.ToString();
            gacc_lineascodigoexistentes.Text = lineas.ToString();

        }

        protected void gacc_ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_PerUsuarioNombre == Convert.ToString(gacc_lblnombreusuario.Text) && nombreproyecto.gacc_NompEstado == 'E' select nombreproyecto).ToList();
            listaProveedor.Insert(0, new GACC_ViewNombreProyectoEmpresa() { gacc_NompNombre = "" });
            gacc_ddlnombredelproyecto.DataSource = list;
            gacc_ddlnombredelproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombredelproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombredelproyecto.DataBind();
        }

        protected void gacc_lnkcalcularvalortodo_Click(object sender, EventArgs e)
        {
            decimal totalvalordeproyecto = Convert.ToDecimal(gacc_rdbcalidaddeprogramadores.SelectedValue) * Convert.ToDecimal(gacc_rdbcapacidad.SelectedValue) * Convert.ToDecimal(gacc_rdbcomplejidad.SelectedValue)
          * Convert.ToDecimal(gacc_rdbexperienciaenaplicacion.SelectedValue) * Convert.ToDecimal(gacc_rdbexperienciamaquinavirtual.SelectedValue) * Convert.ToDecimal(gacc_rdbexplenguaje.SelectedValue) *
          Convert.ToDecimal(gacc_rdbfiabilidad.SelectedValue) * Convert.ToDecimal(gacc_rdbmaquinavirtual.SelectedValue) * Convert.ToDecimal(gacc_rdbrestricciones.SelectedValue) * Convert.ToDecimal(gacc_rdbrestriccionestiempo.SelectedValue)
          * Convert.ToDecimal(gacc_rdbrestricmemoria.SelectedValue) * Convert.ToDecimal(gacc_rdbtamaño.SelectedValue) * Convert.ToDecimal(gacc_rdbtecactualizadas.SelectedValue) * Convert.ToDecimal(gacc_rdbtiemporespuesta.SelectedValue)
          * Convert.ToDecimal(gacc_rdbutilizaciondeherramientas.SelectedValue);


            decimal total = Math.Round(totalvalordeproyecto, 2);
            gacc_txtresultado.Text = Convert.ToString(total);
        }

        protected void gacc_lnkfechafin_Click(object sender, EventArgs e)
        {
            DateTime fechainicio = Convert.ToDateTime(gacc_fechainicio.Text);
            DateTime fechafin = fechainicio.AddMonths(int.Parse(gacc_txttiempo.Text));
            gacc_fechafin.Text = fechafin.ToString("yyyy-MM-dd");
        }

        protected void gacc_lnkcalculartodo_Click(object sender, EventArgs e)
        {
            if ((gacc_ddlmodelodeproyecto.SelectedValue == "Básico"))
            {
                Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(this.WizardStep6);
            }

            if ((gacc_ddlmodelodeproyecto.SelectedValue == "Básico") && (gacc_ddltipoproyecto.SelectedValue == "Orgánico"))
            {
                double lineascodigo, resultadopm, esfuerzoajustado, resultadotd, resultadonp, costoproyecto, costototalproyecto;
                lineascodigo = Convert.ToDouble(gacc_txtlineasdecodigo.Text) / 1000;
                double PM, TD, NP;
                double a = 2.40;
                double b = 1.05;
                double c = 2.50;
                double d = 0.38;

                PM = a * (Math.Pow(lineascodigo, b));
                resultadopm = Math.Round(PM, 0);
                gacc_txtesfuerzonominal.Text = Convert.ToString(resultadopm);
                esfuerzoajustado = Math.Round(resultadopm , 0);
                gacc_txtesfuerzoajustado.Text = Convert.ToString(esfuerzoajustado);
                TD = c * (Math.Pow(esfuerzoajustado, d));
                resultadotd = Math.Round(TD, 0);
                gacc_txttiempo.Text = resultadotd.ToString();
                NP = esfuerzoajustado / resultadotd;
                resultadonp = Math.Round(NP, 0);
                gacc_txtnumeropersonas.Text = Convert.ToString(resultadonp);


            }
            else if ((gacc_ddlmodelodeproyecto.SelectedValue == "Básico") && (gacc_ddltipoproyecto.SelectedValue == "Semi-Libre"))
            {
                double lineascodigo, resultadopm, esfuerzoajustado, resultadotd, resultadonp, costoproyecto, costototalproyecto;
                lineascodigo = Convert.ToDouble(gacc_txtlineasdecodigo.Text) / 1000;
                double PM, TD, NP;
                double a = 3.00;
                double b = 1.12;
                double c = 2.50;
                double d = 0.35;
                PM = a * (Math.Pow(lineascodigo, b));
                resultadopm = Math.Round(PM, 0);
                gacc_txtesfuerzonominal.Text = Convert.ToString(resultadopm);
                esfuerzoajustado = Math.Round(resultadopm, 0);
                gacc_txtesfuerzoajustado.Text = Convert.ToString(esfuerzoajustado);
                TD = c * (Math.Pow(esfuerzoajustado, d));
                resultadotd = Math.Round(TD, 0);
                gacc_txttiempo.Text = resultadotd.ToString();
                NP = esfuerzoajustado / resultadotd;
                resultadonp = Math.Round(NP, 0);
                gacc_txtnumeropersonas.Text = Convert.ToString(resultadonp);

            }
            else if ((gacc_ddlmodelodeproyecto.SelectedValue == "Básico") && (gacc_ddltipoproyecto.SelectedValue == "Empotrado"))
            {
                double lineascodigo, resultadopm, esfuerzoajustado, resultadotd, resultadonp, costoproyecto, costototalproyecto;
                lineascodigo = Convert.ToDouble(gacc_txtlineasdecodigo.Text) / 1000;
                double PM, TD, NP;
                double a = 3.60;
                double b = 1.20;
                double c = 2.50;
                double d = 0.32;
                PM = a * (Math.Pow(lineascodigo, b));
                resultadopm = Math.Round(PM, 0);
                gacc_txtesfuerzonominal.Text = Convert.ToString(resultadopm);
                esfuerzoajustado = Math.Round(resultadopm , 0);
                gacc_txtesfuerzoajustado.Text = Convert.ToString(esfuerzoajustado);
                TD = c * (Math.Pow(esfuerzoajustado, d));
                resultadotd = Math.Round(TD, 0);
                gacc_txttiempo.Text = resultadotd.ToString();
                NP = esfuerzoajustado / resultadotd;
                resultadonp = Math.Round(NP, 0);
                gacc_txtnumeropersonas.Text = Convert.ToString(resultadonp);

            }
            else if ((gacc_ddlmodelodeproyecto.SelectedValue == "Intermedio") && (gacc_ddltipoproyecto.SelectedValue == "Orgánico"))
            {
                double lineascodigo, resultadopm, esfuerzoajustado, resultadotd, resultadonp, costoproyecto, costototalproyecto;
                lineascodigo = Convert.ToDouble(gacc_txtlineasdecodigo.Text) / 1000;
                double totalvalor = Convert.ToDouble(gacc_txtresultado.Text);
                double PM, TD, NP;
                double a = 3.20;
                double b = 1.05;
                double c = 2.50;
                double d = 0.38;
                PM = a * (Math.Pow(lineascodigo, b));
                resultadopm = Math.Round(PM, 0);
                gacc_txtesfuerzonominal.Text = Convert.ToString(resultadopm);
                esfuerzoajustado = Math.Round(resultadopm * totalvalor, 0);
                gacc_txtesfuerzoajustado.Text = Convert.ToString(esfuerzoajustado);
                TD = c * (Math.Pow(esfuerzoajustado, d));
                resultadotd = Math.Round(TD, 0);
                gacc_txttiempo.Text = resultadotd.ToString();
                NP = esfuerzoajustado / resultadotd;
                resultadonp = Math.Round(NP, 0);
                gacc_txtnumeropersonas.Text = Convert.ToString(resultadonp);


            }
            else if ((gacc_ddlmodelodeproyecto.SelectedValue == "Intermedio") && (gacc_ddltipoproyecto.SelectedValue == "Semi-Libre"))
            {
                double lineascodigo, resultadopm, esfuerzoajustado, resultadotd, resultadonp, costoproyecto, costototalproyecto;
                lineascodigo = Convert.ToDouble(gacc_txtlineasdecodigo.Text) / 1000;
                double totalvalor = Convert.ToDouble(gacc_txtresultado.Text);
                double PM, TD, NP;
                double a = 3.00;
                double b = 1.12;
                double c = 2.50;
                double d = 0.35;
                PM = a * (Math.Pow(lineascodigo, b));
                resultadopm = Math.Round(PM, 0);
                gacc_txtesfuerzonominal.Text = Convert.ToString(resultadopm);
                esfuerzoajustado = Math.Round(resultadopm * totalvalor, 0);
                gacc_txtesfuerzoajustado.Text = Convert.ToString(esfuerzoajustado);
                TD = c * (Math.Pow(esfuerzoajustado, d));
                resultadotd = Math.Round(TD, 0);
                gacc_txttiempo.Text = resultadotd.ToString();
                NP = esfuerzoajustado / resultadotd;
                resultadonp = Math.Round(NP, 0);
                gacc_txtnumeropersonas.Text = Convert.ToString(resultadonp);


            }
            else if ((gacc_ddlmodelodeproyecto.SelectedValue == "Intermedio") && (gacc_ddltipoproyecto.SelectedValue == "Empotrado"))
            {
                double lineascodigo, resultadopm, esfuerzoajustado, resultadotd, resultadonp, costoproyecto, costototalproyecto;
                lineascodigo = Convert.ToDouble(gacc_txtlineasdecodigo.Text) / 1000;
                double totalvalor = Convert.ToDouble(gacc_txtresultado.Text);
                double PM, TD, NP;
                double a = 2.80;
                double b = 1.20;
                double c = 2.50;
                double d = 0.32;
                PM = a * (Math.Pow(lineascodigo, b));
                resultadopm = Math.Round(PM, 0);
                gacc_txtesfuerzonominal.Text = Convert.ToString(resultadopm);
                esfuerzoajustado = Math.Round(resultadopm * totalvalor, 0);
                gacc_txtesfuerzoajustado.Text = Convert.ToString(esfuerzoajustado);
                TD = c * (Math.Pow(esfuerzoajustado, d));
                resultadotd = Math.Round(TD, 0);
                gacc_txttiempo.Text = resultadotd.ToString();
                NP = esfuerzoajustado / resultadotd;
                resultadonp = Math.Round(NP, 0);
                gacc_txtnumeropersonas.Text = Convert.ToString(resultadonp);

            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            Guardar();
        }

        protected void gacc_lnknombreproyecto_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoInsertarMetodologia.aspx");

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
