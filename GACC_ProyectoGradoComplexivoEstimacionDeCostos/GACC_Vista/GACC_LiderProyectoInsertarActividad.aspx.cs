using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GACC_Controlador;
using GACC_Modelo;

namespace GACC_Vista
{
    public partial class GACC_LiderProyectoInsertarActividad1 : System.Web.UI.Page
    {
        private DataClasses1DataContext dc = new DataClasses1DataContext();
        private GACC_TblActividad usuarioInfo = new GACC_TblActividad();
        GACC_ViewFaseActividad2 usu = new GACC_ViewFaseActividad2();
        private GACC_TblProyectoTblPersona usuario = new GACC_TblProyectoTblPersona();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gacc_txtnombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
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

                    gacc_ddlestadopersona.Attributes["disabled"] = "disabled";
                    lblestadop.Visible = true;
                    gacc_ddlestadopersona.Visible = true;
                    lblestado.Visible = true;
                    gacc_ddlestado.Visible = true;
                    gacc_lnkguardar.Visible = false;
                    gacc_lnkeditar.Visible = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    usu = GACC_ControladorActividad.ObtenerActividadxidvista(codigo);
                    if (usuarioInfo != null)
                    {
                        gacc_hdfActividad.Value = usu.gacc_ActNombre.ToString();
                        gacc_hdfestado.Value = usu.gacc_ActEstado.ToString();
                        gacc_hdffase.Value = usu.gacc_FasId.ToString();
                        gacc_txtnombre.Text = usu.gacc_ActNombre.ToString();
                        gacc_ddlempresa.SelectedValue = usu.gacc_EmpId.ToString();
                        gacc_ddlproyecto.Text = usu.gacc_NompId.ToString();
                        gacc_ddlmetodologia.Text = usu.gacc_MetId.ToString();
                        gacc_ddlfase.SelectedValue = usu.gacc_FasId.ToString();
                        gacc_ddlcargo.SelectedValue = usu.gacc_CodCarId.ToString();
                        gacc_ddlestado.Text = usu.gacc_ActEstado.ToString();
                        gacc_ddlestadopersona.Text = usu.gacc_PerEstado.ToString();
                        gacc_ddlpersona.Text = usu.idpersona.ToString();
                    }
                }
                else
                {
                    gacc_ddlestadopersona.Visible = false;
                    lblestadop.Visible = false;
                    gacc_ddlestado.Visible = false;
                    lblestado.Visible = false;
                    gacc_ddlestadopersona.Items.FindByValue("O").Enabled = false;
                    gacc_ddlestado.Items.FindByValue("F").Enabled = false;

                }
                cargarCargos();
                cargarEmpresa();
                cargarNombreProyecto();
                cargarMetodologia();
                cargarFase();
                cargarEmpleado();
            }
        }
        private void cargarEmpleado()
        {
            List<GACC_ViewPersonaCargoEmpresa2> listaProveedor = new List<GACC_ViewPersonaCargoEmpresa2>();
            var list = (from persona in dc.GACC_ViewPersonaCargoEmpresa2 where persona.gacc_CarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) select persona).ToList();
            gacc_ddlpersona.DataSource = list;
            gacc_ddlpersona.DataTextField = "Nombres_Completos";
            gacc_ddlpersona.DataValueField = "gacc_PerId";
            gacc_ddlpersona.DataBind();
            gacc_ddlpersona.Items.Insert(0, new ListItem("", "0"));
        }
        private void cargarNombreProyecto()
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) select nombreproyecto).ToList();
            gacc_ddlproyecto.DataSource = list;
            gacc_ddlproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlproyecto.DataValueField = "gacc_NompId";
            gacc_ddlproyecto.DataBind();
            gacc_ddlproyecto.Items.Insert(0, new ListItem("", "0"));
        }
        private void cargarMetodologia()
        {
            List<GACC_ViewMetodologiaPersonaNombreProy2> listaProveedor = new List<GACC_ViewMetodologiaPersonaNombreProy2>();
            var list = (from nombreproyecto in dc.GACC_ViewMetodologiaPersonaNombreProy2 where nombreproyecto.gacc_NompId == int.Parse(gacc_ddlproyecto.SelectedValue)  select nombreproyecto).ToList();
            gacc_ddlmetodologia.DataSource = list;
            gacc_ddlmetodologia.DataTextField = "gacc_MetNombre";
            gacc_ddlmetodologia.DataValueField = "gacc_MetId";
            gacc_ddlmetodologia.DataBind();
            gacc_ddlmetodologia.Items.Insert(0, new ListItem("", "0"));
        }
        private void cargarFase()
        {
            List<GACC_ViewMetodologiaFase2> listaProveedor = new List<GACC_ViewMetodologiaFase2>();
            var list = (from metodologia in dc.GACC_ViewMetodologiaFase2 where metodologia.gacc_MetId == int.Parse(gacc_ddlmetodologia.SelectedValue)  select metodologia).ToList();
            gacc_ddlfase.DataSource = list;
            gacc_ddlfase.DataTextField = "gacc_FasNombre";
            gacc_ddlfase.DataValueField = "gacc_FasId";
            gacc_ddlfase.DataBind();
            gacc_ddlfase.Items.Insert(0, new ListItem("", "0"));
        }
        private void cargarCargos()
        {
            var list = (from persona in dc.GACC_TblCargo where persona.gacc_CarId == int.Parse("4") select persona).ToList();
            gacc_ddlcargo.DataSource = list;
            gacc_ddlcargo.DataTextField = "gacc_CarNombre";
            gacc_ddlcargo.DataValueField = "gacc_CarId";
            gacc_ddlcargo.DataBind();
            gacc_ddlcargo.Items.Insert(0, new ListItem("", "0"));
        }
        private void Limpiar()
        {
            gacc_txtnombre.Text = string.Empty;
            gacc_ddlfase.Text = null;
            gacc_ddlestado.Text = null;
            gacc_ddlpersona.Text = null;
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


        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["LiderProyecto"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }

        protected void gacc_lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoInsertarActividad.aspx");
        }

        private void Guardar()
        {
            usuarioInfo = new GACC_TblActividad();
            usuario = new GACC_TblProyectoTblPersona();
            try
            {
                var count = (from prod in dc.GACC_TblActividad where prod.gacc_CodPerId == int.Parse(gacc_ddlpersona.SelectedValue) && prod.gacc_ActEstado == 'E' select prod).Count();
                
                bool existe = GACC_ControladorActividad.AutentificarActividadxnombreyfase(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlfase.Text));
                {
                    if (existe)
                    {
                        GACC_TblActividad usur = new GACC_TblActividad();
                        usur = GACC_ControladorActividad.ObtenerActividadxnombrexfase(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlfase.Text));
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre de la Actividad ya tiene Fase de desarrollo')", true);
                        }
                    }
                    else
                    {
                        bool existepersona = GACC_ControladorProyectoPersona.AutentificarPersonaProyecto(Convert.ToInt32(gacc_ddlproyecto.SelectedValue), Convert.ToInt32(gacc_ddlpersona.SelectedValue));
                        {
                            if (existepersona)
                            {
                                if (count < 2)
                                {
                                    if (count < 1)
                                    {

                                        var query = (from a in dc.GACC_TblPersona
                                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                                                     select a).FirstOrDefault();

                                        query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                                        dc.SubmitChanges();
                                        usuarioInfo.gacc_ActNombre = gacc_txtnombre.Text;
                                        usuarioInfo.gacc_CodFasId = Convert.ToInt32(gacc_ddlfase.SelectedValue);
                                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                                        usuarioInfo.gacc_ActEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                        GACC_ControladorActividad.save(usuarioInfo);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                                    }
                                    else
                                    {
                                        var query = (from a in dc.GACC_TblPersona
                                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                                                     select a).FirstOrDefault();

                                        query.gacc_PerEstado = Convert.ToChar("O");

                                        dc.SubmitChanges();
                                        usuarioInfo.gacc_ActNombre = gacc_txtnombre.Text;
                                        usuarioInfo.gacc_CodFasId = Convert.ToInt32(gacc_ddlfase.SelectedValue);
                                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                                        usuarioInfo.gacc_ActEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                        GACC_ControladorActividad.save(usuarioInfo);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                                    }

                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La Persona Tiene bastante trabajo, Porfavor Selecciona otra ')", true);
                                }

                            }
                            else
                            {
                                if (count < 2)
                                {
                                    if (count < 1)
                                    {
                                        var query = (from a in dc.GACC_TblPersona
                                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                                                     select a).FirstOrDefault();

                                        query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                                        dc.SubmitChanges();
                                        usuario.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                                        usuario.gacc_CodNompId = Convert.ToInt32(gacc_ddlproyecto.SelectedValue);
                                        usuarioInfo.gacc_ActNombre = gacc_txtnombre.Text;
                                        usuarioInfo.gacc_CodFasId = Convert.ToInt32(gacc_ddlfase.SelectedValue);
                                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                                        usuarioInfo.gacc_ActEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                        GACC_ControladorProyectoPersona.save(usuario);
                                        GACC_ControladorActividad.save(usuarioInfo);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                                    }
                                    else
                                    {
                                        var query = (from a in dc.GACC_TblPersona
                                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                                                     select a).FirstOrDefault();

                                        query.gacc_PerEstado = Convert.ToChar("O");

                                        dc.SubmitChanges();
                                        usuario.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                                        usuario.gacc_CodNompId = Convert.ToInt32(gacc_ddlproyecto.SelectedValue);
                                        usuarioInfo.gacc_ActNombre = gacc_txtnombre.Text;
                                        usuarioInfo.gacc_CodFasId = Convert.ToInt32(gacc_ddlfase.SelectedValue);
                                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                                        usuarioInfo.gacc_ActEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                        GACC_ControladorProyectoPersona.save(usuario);
                                        GACC_ControladorActividad.save(usuarioInfo);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La Persona Tiene bastante trabajo, Porfavor Selecciona otra ')", true);
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO guardados  ')" , true);
            }
        }
        protected void gacc_lnkguardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        protected void gacc_lnkeditar_Click(object sender, EventArgs e)
        {
            string hdfValor = gacc_hdfActividad.Value;
            string hdfValor1 = gacc_hdffase.Value;
            string hdfValorestado = gacc_hdfestado.Value;
            if (hdfValorestado != "E")
            {

                var query = (from a in dc.GACC_TblPersona
                             where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                             select a).FirstOrDefault();

                query.gacc_PerEstado = Convert.ToChar("D");

                dc.SubmitChanges();
            }
            else if (hdfValor == gacc_txtnombre.Text && hdfValor1 == gacc_ddlfase.SelectedValue)
            {
                GuardarDatos(int.Parse(Request["cod"]));
            }
            else if (hdfValor != gacc_txtnombre.Text || hdfValor1 != gacc_ddlfase.SelectedValue)
            {
                var existe = GACC_ControladorActividad.AutentificaActividadxfase(Convert.ToInt32(gacc_ddlfase.SelectedValue), gacc_txtnombre.Text);
                {
                    if (existe != null)
                    {
                        GACC_TblActividad usur = new GACC_TblActividad();
                        usur = GACC_ControladorActividad.ObtenerActividadxnombrexfase(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlfase.SelectedValue));
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre de la Actividad ya tiene Fase de desarrollo')", true);
                        }
                    }
                    else
                    {

                        GuardarDatos(int.Parse(Request["cod"]));
                    }
                }
            }
        }
        private void Modificar(GACC_TblActividad usuarioInfo)
        {
            try
            {
                var query = (from a in dc.GACC_TblPersona
                             where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                             select a).FirstOrDefault();

                query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                dc.SubmitChanges();
                usuarioInfo.gacc_ActNombre = gacc_txtnombre.Text;
                usuarioInfo.gacc_CodFasId = Convert.ToInt32(gacc_ddlfase.Text);
                usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.Text);
                usuarioInfo.gacc_ActEstado = Convert.ToChar(gacc_ddlestado.Text);
                GACC_ControladorActividad.modify(usuarioInfo);
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
                usuarioInfo = GACC_ControladorActividad.ObtenerActividadxid(id);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }

        protected void gacc_lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarActividad.aspx");
        }

        protected void gacc_lnklimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        protected void gacc_ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_PerUsuarioNombre == Convert.ToString(gacc_lblnombreusuario.Text) && nombreproyecto.gacc_NompEstado == 'E' select nombreproyecto).ToList();
            gacc_ddlproyecto.DataSource = list;
            gacc_ddlproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlproyecto.DataValueField = "gacc_NompId";
            gacc_ddlproyecto.DataBind();
            gacc_ddlproyecto.Items.Insert(0, new ListItem("", "0"));
        }

        protected void gacc_ddlproyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewMetodologiaPersonaNombreProy2> listaProveedor = new List<GACC_ViewMetodologiaPersonaNombreProy2>();
            var list = (from nombreproyecto in dc.GACC_ViewMetodologiaPersonaNombreProy2 where nombreproyecto.gacc_NompId == int.Parse(gacc_ddlproyecto.SelectedValue) && nombreproyecto.gacc_MetEstado == 'E' select nombreproyecto).ToList();
            gacc_ddlmetodologia.DataSource = list;
            gacc_ddlmetodologia.DataTextField = "gacc_MetNombre";
            gacc_ddlmetodologia.DataValueField = "gacc_MetId";
            gacc_ddlmetodologia.DataBind();
            gacc_ddlmetodologia.Items.Insert(0, new ListItem("", "0"));
        }

        protected void gacc_ddlmetodologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewMetodologiaFase2> listaProveedor = new List<GACC_ViewMetodologiaFase2>();
            var list = (from metodologia in dc.GACC_ViewMetodologiaFase2 where metodologia.gacc_MetId == int.Parse(gacc_ddlmetodologia.SelectedValue) && metodologia.gacc_FasEstado == 'E' select metodologia).ToList();
            gacc_ddlfase.DataSource = list;
            gacc_ddlfase.DataTextField = "gacc_FasNombre";
            gacc_ddlfase.DataValueField = "gacc_FasId";
            gacc_ddlfase.DataBind();
            gacc_ddlfase.Items.Insert(0, new ListItem("", "0"));
        }

        protected void gacc_ddlcargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gacc_lnkguardar.Visible == true)
            {
                List<GACC_ViewPersonaCargoEmpresa2> listaProveedor = new List<GACC_ViewPersonaCargoEmpresa2>();
                var list = (from persona in dc.GACC_ViewPersonaCargoEmpresa2 where persona.gacc_CarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue)  select persona).ToList();
                gacc_ddlpersona.DataSource = list;
                gacc_ddlpersona.DataTextField = "Nombres_Completos";
                gacc_ddlpersona.DataValueField = "gacc_PerId";
                gacc_ddlpersona.DataBind();
                gacc_ddlpersona.Items.Insert(0, new ListItem("Nombre Persona", "0"));
            }
            else
            {
                List<GACC_ViewPersonaCargoEmpresa2> listaProveedor = new List<GACC_ViewPersonaCargoEmpresa2>();
                var list = (from persona in dc.GACC_ViewPersonaCargoEmpresa2 where persona.gacc_CarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue)  select persona).ToList();
                gacc_ddlpersona.DataSource = list;
                gacc_ddlpersona.DataTextField = "Nombres_Completos";
                gacc_ddlpersona.DataValueField = "gacc_PerId";
                gacc_ddlpersona.DataBind();
                gacc_ddlpersona.Items.Insert(0, new ListItem("", "0"));
            }
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }

        protected void gacc_lnkactividad_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoInsertarTarea.aspx");
        }
    }
}