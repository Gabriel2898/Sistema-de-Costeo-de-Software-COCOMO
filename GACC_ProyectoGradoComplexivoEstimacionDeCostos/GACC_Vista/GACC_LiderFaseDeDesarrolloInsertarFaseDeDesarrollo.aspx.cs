using System;
using System.Collections.Generic;
using System.Linq;
using GACC_Modelo;
using GACC_Controlador;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_LiderFaseDeDesarrolloInsertarFaseDeDesarrollo1 : System.Web.UI.Page
    {
        private DataClasses1DataContext dc = new DataClasses1DataContext();
        private GACC_TblFaseDeDesarrollo usuarioInfo = new GACC_TblFaseDeDesarrollo();
        GACC_ViewMetodologiaFase2 usu = new GACC_ViewMetodologiaFase2();
        private GACC_TblProyectoTblPersona usuario = new GACC_TblProyectoTblPersona();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gacc_txtnombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
                Session.Timeout = 60;
                if (Session["LiderFaseDeDesarrollo"] != null)
                {
                    gacc_lblnombreusuario.Text = Session["LiderFaseDeDesarrollo"].ToString();
                }
                else
                {
                    Response.Redirect("GACC_Index.aspx");
                }


                if (Request["cod"] != null)
                {
                    gacc_ddlempresa.Attributes["disabled"] = "disabled";
                    gacc_ddlestadopersona.Attributes["disabled"] = "disabled";
                    gacc_ddlproyecto.Attributes["disabled"] = "disabled";
                    gacc_ddlmetodologia.Attributes["disabled"] = "disabled";
                    gacc_ddlcargo.Attributes["disabled"] = "disabled";
                    gacc_ddlpersona.Attributes["disabled"] = "disabled";
                    gacc_txtnombre.Attributes["disabled"] = "disabled";
                    gacc_lnkeditar.Visible = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    usu = GACC_ControladorFaseDeDesarrollo.ObtenerFasexidvista(codigo);
                    if (usuarioInfo != null)
                    {
                        gacc_hdfmetodologia.Value = usu.gacc_MetId.ToString();
                        gacc_hdffase.Value = usu.gacc_FasNombre.ToString();
                        gacc_txtnombre.Text = usu.gacc_FasNombre.ToString();
                        gacc_ddlempresa.SelectedValue = usu.gacc_CodEmpId.ToString();
                        gacc_ddlproyecto.SelectedValue = usu.gacc_NompId.ToString();
                        gacc_ddlmetodologia.Text = usu.gacc_MetId.ToString();
                        gacc_ddlcargo.SelectedValue = usu.gacc_CodCarId.ToString();
                        gacc_ddlestado.Text = usu.gacc_FasEstado.ToString();
                        gacc_ddlestadopersona.Text = usu.gacc_PerEstado.ToString();
                        gacc_ddlpersona.Text = usu.gacc_PerId.ToString();
                    }
                }
                cargarEmpresa();
                cargarCargos();
                cargarEmpleado();
                cargarNombreProyecto();
                cargarMetodologia();
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


      



        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["LiderFaseDeDesarrollo"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }

      
        private void Guardar()
        {

            usuario = new GACC_TblProyectoTblPersona();
            usuarioInfo = new GACC_TblFaseDeDesarrollo();
            try
            {

                bool existe = GACC_ControladorFaseDeDesarrollo.AutentificarFasexnombress(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlmetodologia.Text));
                {
                    if (existe)
                    {
                        GACC_TblFaseDeDesarrollo usur = new GACC_TblFaseDeDesarrollo();
                        usur = GACC_ControladorFaseDeDesarrollo.ObtenerFasexnombress(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlmetodologia.Text));
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre de la fase ya tiene metodologia')", true);
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
                                    usuarioInfo.gacc_FasNombre = gacc_txtnombre.Text;
                                    usuarioInfo.gacc_CodMetId = Convert.ToInt32(gacc_ddlmetodologia.SelectedValue);
                                    usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                                    usuarioInfo.gacc_FasEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                    GACC_ControladorFaseDeDesarrollo.save(usuarioInfo);
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                                    Response.Redirect("GACC_LiderFaseDeDesarrolloListarFaseDeDesarrollo.aspx");
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
                                usuarioInfo.gacc_FasNombre = gacc_txtnombre.Text;
                                usuarioInfo.gacc_CodMetId = Convert.ToInt32(gacc_ddlmetodologia.SelectedValue);
                                usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                                usuarioInfo.gacc_FasEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                GACC_ControladorFaseDeDesarrollo.save(usuarioInfo);
                                GACC_ControladorProyectoPersona.save(usuario);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                                Response.Redirect("GACC_LiderFaseDeDesarrolloListarFaseDeDesarrollo.aspx");
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

            string hdfValor = gacc_hdfmetodologia.Value;
            string hdfValor1 = gacc_hdffase.Value;
            if (hdfValor1 == gacc_txtnombre.Text && hdfValor == gacc_ddlmetodologia.Text)
            {
                GuardarDatos(int.Parse(Request["cod"]));
            }
            else if (hdfValor1 != gacc_txtnombre.Text || hdfValor != gacc_ddlmetodologia.Text)
            {
                var existe = GACC_ControladorFaseDeDesarrollo.Autentificarfasexmetodologia(Convert.ToInt32(gacc_ddlmetodologia.Text), gacc_txtnombre.Text);
                {
                    if (existe != null)
                    {
                        GACC_TblFaseDeDesarrollo usur = new GACC_TblFaseDeDesarrollo();
                        usur = GACC_ControladorFaseDeDesarrollo.ObtenerFasexnombress(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlmetodologia.Text));
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre de la fase ya tiene metodologia')", true);
                        }
                    }
                    else
                    {

                        GuardarDatos(int.Parse(Request["cod"]));
                    }
                }
            }
        }
        private void Modificar(GACC_TblFaseDeDesarrollo usuarioInfo)
        {
            try
            {

                var query = (from a in dc.GACC_TblPersona
                             where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                             select a).FirstOrDefault();

                query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                dc.SubmitChanges();
                usuarioInfo.gacc_FasNombre = gacc_txtnombre.Text;
                usuarioInfo.gacc_CodMetId = Convert.ToInt32(gacc_ddlmetodologia.SelectedValue);
                usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                usuarioInfo.gacc_FasEstado = Convert.ToChar(gacc_ddlestado.Text);
                GACC_ControladorFaseDeDesarrollo.modify(usuarioInfo);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos modificados  ')", true);
            }
            catch (Exception e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO modificados  ')" , true);
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
                usuarioInfo = GACC_ControladorFaseDeDesarrollo.ObtenerFasexid(id);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }



        protected void gacc_lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderFaseDeDesarrolloListarFaseDeDesarrollo.aspx");
        }



        protected void gacc_ddlcargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                List<GACC_ViewPersonaCargoEmpresa2> listaProveedor = new List<GACC_ViewPersonaCargoEmpresa2>();
                var list = (from persona in dc.GACC_ViewPersonaCargoEmpresa2 where persona.gacc_CarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_PerUsuarioNombre == gacc_lblnombreusuario.Text && persona.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue)  select persona).ToList();
                listaProveedor.Insert(0, new GACC_ViewPersonaCargoEmpresa2() { Nombres_Completos = "Nombre Persona" });
                gacc_ddlpersona.DataSource = list;
                gacc_ddlpersona.DataTextField = "Nombres_Completos";
                gacc_ddlpersona.DataValueField = "gacc_PerId";
                gacc_ddlpersona.DataBind();
            
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
            List<GACC_ViewMetodologiaPersonaNombreProy2> listaProveedor = new List<GACC_ViewMetodologiaPersonaNombreProy2>();
            var listado = (from nombreproyecto in dc.GACC_ViewMetodologiaPersonaNombreProy2 where nombreproyecto.gacc_NompId == int.Parse(gacc_ddlproyecto.SelectedValue) && nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_MetEstado == 'E' select nombreproyecto).ToList();
            gacc_ddlmetodologia.DataSource = listado;
            gacc_ddlmetodologia.DataTextField = "gacc_MetNombre";
            gacc_ddlmetodologia.DataValueField = "gacc_MetId";
            gacc_ddlmetodologia.DataBind();
            gacc_ddlmetodologia.Items.Insert(0, new ListItem("Nombre Metodologia", "0"));
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderFaseDeDesarrolloListarUnicaPersona.aspx");
        }
    }
}