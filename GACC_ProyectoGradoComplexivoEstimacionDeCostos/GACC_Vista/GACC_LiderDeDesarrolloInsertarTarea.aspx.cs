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
    public partial class GACC_LiderDeDesarrolloInsertarTarea1 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        GACC_ViewActividadTarea2 usu = new GACC_ViewActividadTarea2();

        private GACC_TblProyectoTblPersona usuario = new GACC_TblProyectoTblPersona();
        private GACC_TblTarea usuarioInfo = new GACC_TblTarea();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gacc_txtnombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
                gacc_txtlineas.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                Session.Timeout = 60;
                if (Session["LiderDeDesarrollo"] != null)
                {
                    gacc_lblnombreusuario.Text = Session["LiderDeDesarrollo"].ToString();
                }
                else
                {
                    Response.Redirect("GACC_Index.aspx");
                }

                if (Request["cod"] != null)
                {
                    lblestado.Visible = true;
                    lblestadop.Visible = true;
                    gacc_ddlestado.Visible = true;
                    gacc_ddlestadopersona.Visible = true;
                    gacc_ddlestadopersona.Attributes["disabled"] = "disabled";
                    gacc_txtfechafin.Attributes["disabled"] = "disabled";
                    gacc_txtfechainicio.Attributes["disabled"] = "disabled";
                    gacc_ddlempresa.Attributes["disabled"] = "disabled";
                    gacc_ddlproyecto.Attributes["disabled"] = "disabled";
                    gacc_ddlmetodologia.Attributes["disabled"] = "disabled";
                    gacc_ddlfase.Attributes["disabled"] = "disabled";
                    gacc_ddlactividad.Attributes["disabled"] = "disabled";
                    gacc_ddlcargo.Attributes["disabled"] = "disabled";
                    gacc_ddlpersona.Attributes["disabled"] = "disabled";
                    gacc_txtlineas.Attributes["disabled"] = "disabled";
                    gacc_txtnombre.Attributes["disabled"] = "disabled";
                    gacc_lnkeditar.Visible = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    usu = GACC_ControladorTarea.ObtenerTareaxidvista(codigo);
                    if (usuarioInfo != null)
                    {
                        gacc_txtfechainicio.Text = usu.gacc_TarFechaInicio.ToString("yyyy-MM-dd");
                        gacc_txtfechafin.Text = usu.gacc_TarFechaFin.ToString("yyyy-MM-dd");
                        gacc_hdflienascodigo.Value = usu.gacc_TarLineaCodigo.ToString();
                        gacc_hdfActividad.Value = usu.gacc_ActId.ToString();
                        gacc_hdfTarea.Value = usu.gacc_TarNombre.ToString();
                        gacc_txtlineas.Text = usu.gacc_TarLineaCodigo.ToString();
                        lineas2.Text = usu.gacc_TarLineaCodigo.ToString();
                        gacc_txtnombre.Text = usu.gacc_TarNombre.ToString();
                        gacc_ddlestado.Text = usu.gacc_TarEstado.ToString();
                        gacc_ddlactividad.SelectedValue = usu.gacc_ActId.ToString();
                        gacc_ddlempresa.SelectedValue = usu.gacc_EmpId.ToString();
                        gacc_ddlproyecto.Text = usu.gacc_NompId.ToString();
                        gacc_ddlmetodologia.Text = usu.gacc_MetId.ToString();
                        gacc_ddlfase.SelectedValue = usu.gacc_FasId.ToString();
                        gacc_ddlcargo.SelectedValue = usu.gacc_CodCarId.ToString();
                        gacc_ddlestadopersona.Text = usu.gacc_PerEstado.ToString();
                        gacc_ddlpersona.Text = usu.gacc_PerId.ToString();
                    }
                }
                cargarCargos();
                cargarEmpresa();
                cargarNombreProyecto();
                cargarMetodologia();
                cargarFase();
                cargarActividad();
                cargarEmpleado();
            }
        }
        private void cargarEmpleado()
        {
            List<GACC_ViewPersona> listaProveedor = new List<GACC_ViewPersona>();
            listaProveedor = GACC_ControladorPersona.ObtenerPersonadls();
            listaProveedor.Insert(0, new GACC_ViewPersona() { Nombres_Completos = "Nombre Persona" });
            gacc_ddlpersona.DataSource = listaProveedor;
            gacc_ddlpersona.DataTextField = "Nombres_Completos";
            gacc_ddlpersona.DataValueField = "gacc_PerId";
            gacc_ddlpersona.DataBind();
        }
        private void cargarNombreProyecto()
        {
            List<GACC_TblNombreProyecto> listaProveedor = new List<GACC_TblNombreProyecto>();
            listaProveedor = GACC_ControladorNombreProyecto.ObtenerProyectodls();
            listaProveedor.Insert(0, new GACC_TblNombreProyecto() { gacc_NompNombre = "Nombre Proyecto" });
            gacc_ddlproyecto.DataSource = listaProveedor;
            gacc_ddlproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlproyecto.DataValueField = "gacc_NompId";
            gacc_ddlproyecto.DataBind();
        }
        private void cargarMetodologia()
        {
            List<GACC_TblMetodologia> listaProveedor = new List<GACC_TblMetodologia>();
            listaProveedor = GACC_ControladorMetodologia.ObtenerMetodologiadls();
            listaProveedor.Insert(0, new GACC_TblMetodologia() { gacc_MetNombre = "Nombre Metodologia" });
            gacc_ddlmetodologia.DataSource = listaProveedor;
            gacc_ddlmetodologia.DataTextField = "gacc_MetNombre";
            gacc_ddlmetodologia.DataValueField = "gacc_MetId";
            gacc_ddlmetodologia.DataBind();
        }
        private void cargarFase()
        {
            List<GACC_TblFaseDeDesarrollo> listaProveedor = new List<GACC_TblFaseDeDesarrollo>();
            listaProveedor = GACC_ControladorFaseDeDesarrollo.Obtenerfasedls();
            listaProveedor.Insert(0, new GACC_TblFaseDeDesarrollo() { gacc_FasNombre = "Nombre Fase" });
            gacc_ddlfase.DataSource = listaProveedor;
            gacc_ddlfase.DataTextField = "gacc_FasNombre";
            gacc_ddlfase.DataValueField = "gacc_FasId";
            gacc_ddlfase.DataBind();
        }
        private void cargarActividad()
        {
            List<GACC_TblActividad> listaProveedor = new List<GACC_TblActividad>();
            listaProveedor = GACC_ControladorActividad.ObtenerActividaddls();
            listaProveedor.Insert(0, new GACC_TblActividad() { gacc_ActNombre = "Nombre Actividad" });
            gacc_ddlactividad.DataSource = listaProveedor;
            gacc_ddlactividad.DataTextField = "gacc_ActNombre";
            gacc_ddlactividad.DataValueField = "gacc_ActId";
            gacc_ddlactividad.DataBind();
        }
        private void cargarCargos()
        {
            List<GACC_TblCargo> listaProveedor = new List<GACC_TblCargo>();
            listaProveedor = GACC_ControladorCargo.ObtenerCargo();
            listaProveedor.Insert(0, new GACC_TblCargo() { gacc_CarNombre = "Nombre Cargo" });
            gacc_ddlcargo.DataSource = listaProveedor;
            gacc_ddlcargo.DataTextField = "gacc_CarNombre";
            gacc_ddlcargo.DataValueField = "gacc_CarId";
            gacc_ddlcargo.DataBind();
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
        private void Limpiar()
        {
            gacc_txtnombre.Text = string.Empty;
            gacc_txtlineas.Text = string.Empty;
            gacc_ddlactividad.Text = null;
            gacc_ddlestado.Text = null;
            gacc_ddlpersona.Text = null;

        }
        private void Guardar()
        {
            usuario = new GACC_TblProyectoTblPersona();
            usuarioInfo = new GACC_TblTarea();
            try
            {



                bool existe = GACC_ControladorTarea.AutentificarTareaxnombress(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlactividad.SelectedValue));
                {
                    if (existe)
                    {
                        GACC_TblTarea usur = new GACC_TblTarea();
                        usur = GACC_ControladorTarea.ObtenerTareaxnombress(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlactividad.SelectedValue));
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre de la tarea ya tiene Actividad')", true);
                        }
                    }
                    else
                    {
                        bool existepersona = GACC_ControladorProyectoPersona.AutentificarPersonaProyecto(Convert.ToInt32(gacc_ddlproyecto.SelectedValue), Convert.ToInt32(gacc_ddlpersona.SelectedValue));
                        {
                            if (existepersona)
                            {
                                GACC_TblProyectoTblPersona perso = new GACC_TblProyectoTblPersona();
                                perso = GACC_ControladorProyectoPersona.ObtenerPersonaProyecto(Convert.ToInt32(gacc_ddlproyecto.SelectedValue), Convert.ToInt32(gacc_ddlpersona.SelectedValue));
                                if (perso != null)
                                {
                                    var query = (from a in dc.GACC_TblPersona
                                                 where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                                                 select a).FirstOrDefault();

                                    query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                                    dc.SubmitChanges();
                                    usuarioInfo.gacc_TarNombre = gacc_txtnombre.Text;
                                    usuarioInfo.gacc_TarLineaCodigo = Convert.ToInt32(gacc_txtlineas.Text);
                                    usuarioInfo.gacc_CodActId = Convert.ToInt32(gacc_ddlactividad.Text);
                                    usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.Text);
                                    usuarioInfo.gacc_TarEstado = Convert.ToChar(gacc_ddlestado.Text);
                                    GACC_ControladorTarea.save(usuarioInfo);
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                                    Response.Redirect("GACC_LiderDeDesarrolloListarTarea.aspx");
                                }

                            }
                            else
                            {
                                var query = (from a in dc.GACC_TblPersona
                                             where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                                             select a).FirstOrDefault();

                                query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                                dc.SubmitChanges();
                                usuario.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                                usuario.gacc_CodNompId = Convert.ToInt32(gacc_ddlproyecto.SelectedValue);
                                usuarioInfo.gacc_TarNombre = gacc_txtnombre.Text;
                                usuarioInfo.gacc_TarLineaCodigo = Convert.ToInt32(gacc_txtlineas.Text);
                                usuarioInfo.gacc_CodActId = Convert.ToInt32(gacc_ddlactividad.Text);
                                usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.Text);
                                usuarioInfo.gacc_TarEstado = Convert.ToChar(gacc_ddlestado.Text);
                                GACC_ControladorProyectoPersona.save(usuario);
                                GACC_ControladorTarea.save(usuarioInfo);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                                Response.Redirect("GACC_LiderDeDesarrolloListarTarea.aspx");
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO guardados ')", true);
            }
        }
        private void Modificar(GACC_TblTarea usuarioInfo)
        {
            try
            {

                var query = (from a in dc.GACC_TblPersona
                             where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                             select a).FirstOrDefault();

                query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                dc.SubmitChanges();
                usuarioInfo.gacc_TarEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                GACC_ControladorTarea.modify(usuarioInfo);
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
                usuarioInfo = GACC_ControladorTarea.ObtenerTareaxid(id);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }

        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["LiderDeDesarrollo"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }

        protected void gacc_lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderDeDesarrolloInsertarTarea.aspx");
        }

        protected void gacc_lnkguardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        protected void gacc_lnkeditar_Click(object sender, EventArgs e)
        {
            string hdfValor = gacc_hdfActividad.Value;
            string hdfValor1 = gacc_hdfTarea.Value;
            if (hdfValor1 == gacc_txtnombre.Text && hdfValor == gacc_ddlactividad.Text)
            {
                GuardarDatos(int.Parse(Request["cod"]));
            }
            else if (hdfValor1 != gacc_txtnombre.Text || hdfValor != gacc_ddlactividad.Text)
            {
                var existe = GACC_ControladorTarea.AutentificarTareaxacividad(Convert.ToInt32(gacc_ddlactividad.SelectedValue), gacc_txtnombre.Text);
                {
                    if (existe != null)
                    {
                        GACC_TblTarea usur = new GACC_TblTarea();
                        usur = GACC_ControladorTarea.ObtenerTareaxnombress(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlactividad.SelectedValue));
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre de la Tarea ya tiene Actividad')", true);
                        }
                    }
                    else
                    {


                        GuardarDatos(int.Parse(Request["cod"]));
                    }
                }
            }
        }

        protected void gacc_lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderDeDesarrolloListarTarea.aspx");
        }

      

        protected void gacc_ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresa where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_NompEstado == 'E' select nombreproyecto).ToList();
            gacc_ddlproyecto.DataSource = list;
            gacc_ddlproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlproyecto.DataValueField = "gacc_NompId";
            gacc_ddlproyecto.DataBind();
            gacc_ddlproyecto.Items.Insert(0, new ListItem("Nombre Proyecto", "0"));
        }

        protected void gacc_ddlproyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewFaseActividad2> listaProveedor = new List<GACC_ViewFaseActividad2>();
            var list = (from nombreproyecto in dc.GACC_ViewMetodologiaPersonaNombreProy2 where nombreproyecto.gacc_NompId == int.Parse(gacc_ddlproyecto.SelectedValue) && nombreproyecto.gacc_MetEstado == 'E' select nombreproyecto).ToList();
            gacc_ddlmetodologia.DataSource = list;
            gacc_ddlmetodologia.DataTextField = "gacc_MetNombre";
            gacc_ddlmetodologia.DataValueField = "gacc_MetId";
            gacc_ddlmetodologia.DataBind();
            gacc_ddlmetodologia.Items.Insert(0, new ListItem("Nombre Metodologia", "0"));

        }

        protected void gacc_ddlmetodologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewFaseActividad2> listaProveedor = new List<GACC_ViewFaseActividad2>();
            var list = (from metodologia in dc.GACC_ViewMetodologiaFase2 where metodologia.gacc_MetId == int.Parse(gacc_ddlmetodologia.SelectedValue) && metodologia.gacc_FasEstado == 'E' select metodologia).ToList();
            gacc_ddlfase.DataSource = list;
            gacc_ddlfase.DataTextField = "gacc_FasNombre";
            gacc_ddlfase.DataValueField = "gacc_FasId";
            gacc_ddlfase.DataBind();
            gacc_ddlfase.Items.Insert(0, new ListItem("Nombre Fase de Desarrollo", "0"));
        }

        protected void gacc_ddlfase_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewFaseActividad2> listaProveedor = new List<GACC_ViewFaseActividad2>();
            var list = (from metodologia in dc.GACC_ViewFaseActividad2 where metodologia.gacc_FasId == int.Parse(gacc_ddlfase.SelectedValue) && metodologia.gacc_ActEstado == 'E' select metodologia).ToList();
            gacc_ddlactividad.DataSource = list;
            gacc_ddlactividad.DataTextField = "gacc_ActNombre";
            gacc_ddlactividad.DataValueField = "gacc_ActId";
            gacc_ddlactividad.DataBind();
            gacc_ddlactividad.Items.Insert(0, new ListItem("Nombre de Actividad", "0"));
        }

        protected void gacc_ddlcargo_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                List<GACC_ViewPersonaCargoEmpresa2> listaProveedor = new List<GACC_ViewPersonaCargoEmpresa2>();
                var list = (from persona in dc.GACC_ViewPersonaCargoEmpresa2 where persona.gacc_CarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) select persona).ToList();
                gacc_ddlpersona.DataSource = list;
                gacc_ddlpersona.DataTextField = "Nombres_Completos";
                gacc_ddlpersona.DataValueField = "gacc_PerId";
                gacc_ddlpersona.DataBind();
                gacc_ddlpersona.Items.Insert(0, new ListItem("Nombre Persona", "0"));
            
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderDeDesarrolloListarUnicaPersona.aspx");
        }
    }
}