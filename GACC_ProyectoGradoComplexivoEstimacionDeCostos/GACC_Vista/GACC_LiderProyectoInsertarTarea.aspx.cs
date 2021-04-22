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
    public partial class GACC_LiderProyectoInsertarTarea1 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        GACC_ViewActividadTarea2 usu = new GACC_ViewActividadTarea2();
        GACC_TblTarea tar = new GACC_TblTarea();
        private GACC_TblProyectoTblPersona usuario = new GACC_TblProyectoTblPersona();
        private GACC_TblTarea usuarioInfo = new GACC_TblTarea();
        protected void Page_Load(object sender, EventArgs e)
        {

            lineaexistentes.Attributes["disabled"] = "disabled";
            if (!IsPostBack)
            {
                gacc_txtnombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
                gacc_txtlineas.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
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
                    usu = GACC_ControladorTarea.ObtenerTareaxidvista(codigo);
                    if (usuarioInfo != null)
                    {

                        gacc_txtfechainicio.Text = usu.gacc_TarFechaInicio.ToString("yyyy-MM-dd");
                        gacc_txtfechafin.Text = usu.gacc_TarFechaFin.ToString("yyyy-MM-dd");
                        gacc_hdflienascodigo.Value = usu.gacc_TarLineaCodigo.ToString();
                        gacc_hdfActividad.Value = usu.gacc_ActId.ToString();
                        gacc_hdfTarea.Value = usu.gacc_TarNombre.ToString();
                        gacc_hdfestado.Value = usu.gacc_TarEstado.ToString();
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
                        gacc_ddlespecialidad.SelectedValue = usu.gacc_PerEspecialidad.ToString();
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
                cargarActividad();
                cargarEspecialidad();
                cargarEmpleado();
            }
        }
        private void cargarEspecialidad()
        {

            List<GACC_TblPersona> listaProveedor = new List<GACC_TblPersona>();
            listaProveedor = GACC_ControladorPersona.ObtenerPersonas(int.Parse(gacc_ddlempresa.SelectedValue));

            gacc_ddlespecialidad.DataSource = listaProveedor;
            gacc_ddlespecialidad.DataTextField = "gacc_PerEspecialidad";
            gacc_ddlespecialidad.DataValueField = "gacc_PerEspecialidad";
            gacc_ddlespecialidad.DataBind();
            gacc_ddlespecialidad.Items.Insert(0, new ListItem("", "0"));


        }
        private void cargarEmpleado()
        {
            List<GACC_TblPersona> listaProveedor = new List<GACC_TblPersona>();
            var list = (from persona in dc.GACC_ViewPersona where persona.gacc_CodCarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_PerEspecialidad == gacc_ddlespecialidad.SelectedValue select persona).ToList();
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
            if (gacc_lnkeditar.Visible == true)
            {
                var Contacto = (from i in dc.GACC_TblProyecto
                                where i.gacc_CodNompId == int.Parse(gacc_ddlproyecto.SelectedValue)
                                select new
                                {
                                    i.gacc_ProLineaCodigoExistente,
                                    i.gacc_ProFechaInicio,
                                    i.gacc_ProFechaFin

                                }).FirstOrDefault();

                lineaexistentes.Text = Contacto.gacc_ProLineaCodigoExistente.ToString();
                inicio.Text = Contacto.gacc_ProFechaInicio.ToString("yyyy-MM-dd");
                fin.Text = Contacto.gacc_ProFechaFin.ToString("yyyy-MM-dd");
            }
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
        private void cargarActividad()
        {
            List<GACC_ViewFaseActividad2> listaProveedor = new List<GACC_ViewFaseActividad2>();
            var list = (from metodologia in dc.GACC_ViewFaseActividad2 where metodologia.gacc_FasId == int.Parse(gacc_ddlfase.SelectedValue)  select metodologia).ToList();
            gacc_ddlactividad.DataSource = list;
            gacc_ddlactividad.DataTextField = "gacc_ActNombre";
            gacc_ddlactividad.DataValueField = "gacc_ActId";
            gacc_ddlactividad.DataBind();
            gacc_ddlactividad.Items.Insert(0, new ListItem("", "0"));
        }
        private void cargarCargos()
        {
            var list = (from persona in dc.GACC_TblCargo where persona.gacc_CarId == int.Parse("5") select persona).ToList();
            gacc_ddlcargo.DataSource = list;
            gacc_ddlcargo.DataTextField = "gacc_CarNombre";
            gacc_ddlcargo.DataValueField = "gacc_CarId";
            gacc_ddlcargo.DataBind();
            gacc_ddlcargo.Items.Insert(0, new ListItem("", "0"));
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
        private void Limpiar()
        {
            gacc_txtnombre.Text = string.Empty;
            gacc_txtlineas.Text = string.Empty;
            gacc_ddlactividad.Text = null;
            gacc_ddlestado.Text = null;
            gacc_ddlpersona.Text = null;

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

        protected void gacc_lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoInsertarTarea.aspx");
        }
        private void Guardar()
        {
            DateTime i = Convert.ToDateTime(inicio.Text);
            DateTime f = Convert.ToDateTime(fin.Text);
            usuario = new GACC_TblProyectoTblPersona();
            usuarioInfo = new GACC_TblTarea();
            try
            {
                var count = (from prod in dc.GACC_TblTarea where prod.gacc_CodPerId == int.Parse(gacc_ddlpersona.SelectedValue) && prod.gacc_TarEstado == 'E' select prod).Count();
                
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
                    else if (Convert.ToDateTime(gacc_txtfechainicio.Text) < i)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Escoja una Fecha igual o mayor a la del proyecto')", true);

                    }
                    else if (Convert.ToDateTime(gacc_txtfechafin.Text) > f)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Escoja una Fecha igual o menor a la del proyecto')", true);

                    }
                    else if (int.Parse(gacc_txtlineas.Text) > int.Parse(lineaexistentes.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El número de Lineas supera el total de lineas que tienes  ')", true);
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(gacc_txtfechainicio.Text), Convert.ToDateTime(gacc_txtfechafin.Text)) > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tu fecha Final no puede ser menor que tu fecha inicial  ')", true);
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
                                        var queryy = (from a in dc.GACC_TblProyecto
                                                      where a.gacc_CodNompId == Convert.ToInt32(gacc_ddlproyecto.SelectedValue)
                                                      select a).FirstOrDefault();

                                        queryy.gacc_ProLineaCodigoExistente = queryy.gacc_ProLineaCodigoExistente - Convert.ToInt32(gacc_txtlineas.Text);

                                        dc.SubmitChanges();
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
                                        usuarioInfo.gacc_TarFechaInicio = Convert.ToDateTime(gacc_txtfechainicio.Text);
                                        usuarioInfo.gacc_TarFechaFin = Convert.ToDateTime(gacc_txtfechafin.Text);
                                        GACC_ControladorTarea.save(usuarioInfo);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito, Por favor si deseas agregar Costos Indirectos Selecciona el boton Agregar Costos indirectos, sino lo deseas dirigete a Costo Proyecto   ')", true);


                                    }
                                    else
                                    {
                                        var queryy = (from a in dc.GACC_TblProyecto
                                                      where a.gacc_CodNompId == Convert.ToInt32(gacc_ddlproyecto.SelectedValue)
                                                      select a).FirstOrDefault();

                                        queryy.gacc_ProLineaCodigoExistente = queryy.gacc_ProLineaCodigoExistente - Convert.ToInt32(gacc_txtlineas.Text);

                                        dc.SubmitChanges();
                                        var query = (from a in dc.GACC_TblPersona
                                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                                                     select a).FirstOrDefault();

                                        query.gacc_PerEstado = Convert.ToChar("O");

                                        dc.SubmitChanges();
                                        usuarioInfo.gacc_TarNombre = gacc_txtnombre.Text;
                                        usuarioInfo.gacc_TarLineaCodigo = Convert.ToInt32(gacc_txtlineas.Text);
                                        usuarioInfo.gacc_CodActId = Convert.ToInt32(gacc_ddlactividad.Text);
                                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.Text);
                                        usuarioInfo.gacc_TarEstado = Convert.ToChar(gacc_ddlestado.Text);
                                        usuarioInfo.gacc_TarFechaInicio = Convert.ToDateTime(gacc_txtfechainicio.Text);
                                        usuarioInfo.gacc_TarFechaFin = Convert.ToDateTime(gacc_txtfechafin.Text);
                                        GACC_ControladorTarea.save(usuarioInfo);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito, Por favor si deseas agregar Costos Indirectos Selecciona el boton Agregar Costos indirectos, sino lo deseas dirigete a Costo Proyecto   ')", true);
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


                                        var queryy = (from a in dc.GACC_TblProyecto
                                                      where a.gacc_CodNompId == Convert.ToInt32(gacc_ddlproyecto.SelectedValue)
                                                      select a).FirstOrDefault();

                                        queryy.gacc_ProLineaCodigoExistente = queryy.gacc_ProLineaCodigoExistente - Convert.ToInt32(gacc_txtlineas.Text);
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
                                        usuarioInfo.gacc_TarFechaInicio = Convert.ToDateTime(gacc_txtfechainicio.Text);
                                        usuarioInfo.gacc_TarFechaFin = Convert.ToDateTime(gacc_txtfechafin.Text);
                                        GACC_ControladorProyectoPersona.save(usuario);
                                        GACC_ControladorTarea.save(usuarioInfo);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito, Por favor si deseas agregar Costos Indirectos Selecciona el boton Agregar Costos indirectos, sino lo deseas dirigete a Costo Proyecto   ')", true);
                                    }
                                    else
                                    {

                                        var queryy = (from a in dc.GACC_TblProyecto
                                                      where a.gacc_CodNompId == Convert.ToInt32(gacc_ddlproyecto.SelectedValue)
                                                      select a).FirstOrDefault();

                                        queryy.gacc_ProLineaCodigoExistente = queryy.gacc_ProLineaCodigoExistente - Convert.ToInt32(gacc_txtlineas.Text);
                                        var query = (from a in dc.GACC_TblPersona
                                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                                                     select a).FirstOrDefault();

                                        query.gacc_PerEstado = Convert.ToChar("O");

                                        dc.SubmitChanges();
                                        usuario.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                                        usuario.gacc_CodNompId = Convert.ToInt32(gacc_ddlproyecto.SelectedValue);
                                        usuarioInfo.gacc_TarNombre = gacc_txtnombre.Text;
                                        usuarioInfo.gacc_TarLineaCodigo = Convert.ToInt32(gacc_txtlineas.Text);
                                        usuarioInfo.gacc_CodActId = Convert.ToInt32(gacc_ddlactividad.Text);
                                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.Text);
                                        usuarioInfo.gacc_TarEstado = Convert.ToChar(gacc_ddlestado.Text);
                                        usuarioInfo.gacc_TarFechaInicio = Convert.ToDateTime(gacc_txtfechainicio.Text);
                                        usuarioInfo.gacc_TarFechaFin = Convert.ToDateTime(gacc_txtfechafin.Text);
                                        GACC_ControladorProyectoPersona.save(usuario);
                                        GACC_ControladorTarea.save(usuarioInfo);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito, Por favor si deseas agregar Costos Indirectos Selecciona el boton Agregar Costos indirectos, sino lo deseas dirigete a Costo Proyecto   ')", true);
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO guardados ')" , true);
            }
        }
        private void Modificar(GACC_TblTarea usuarioInfo)
        {
            string hdfValor = gacc_hdflienascodigo.Value;
            DateTime i = Convert.ToDateTime(inicio.Text);
            DateTime f = Convert.ToDateTime(fin.Text);
            int lienasdos = int.Parse(lineas2.Text);
            int lieasexis = int.Parse(lineaexistentes.Text);
            int suma = lienasdos + lieasexis;
            int lienasnuevas = int.Parse(gacc_txtlineas.Text);
            int total = suma - lienasnuevas;
            lineasexistentesnuevas.Text = total.ToString();
            try
            {
                if (hdfValor == gacc_txtlineas.Text)
                {
                    if (Convert.ToDateTime(gacc_txtfechainicio.Text) < i)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Escoja una Fecha igual o mayor a la del proyecto')", true);

                    }
                    else if (Convert.ToDateTime(gacc_txtfechafin.Text) > f)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Escoja una Fecha igual o menor a la del proyecto')", true);

                    }
                    else if (int.Parse(gacc_txtlineas.Text) > Convert.ToInt32(suma))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El número de Lineas supera el total de lineas que tienes  ')", true);
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(gacc_txtfechainicio.Text), Convert.ToDateTime(gacc_txtfechafin.Text)) > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tu fecha Final no puede ser menor que tu fecha inicial  ')", true);
                    }
                    else
                    {


                        var query = (from a in dc.GACC_TblPersona
                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                                     select a).FirstOrDefault();

                        query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                        dc.SubmitChanges();
                        usuarioInfo.gacc_TarNombre = gacc_txtnombre.Text;
                        usuarioInfo.gacc_TarLineaCodigo = Convert.ToInt32(gacc_txtlineas.Text);
                        usuarioInfo.gacc_CodActId = Convert.ToInt32(gacc_ddlactividad.Text);
                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                        usuarioInfo.gacc_TarEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                        usuarioInfo.gacc_TarFechaInicio = Convert.ToDateTime(gacc_txtfechainicio.Text);
                        usuarioInfo.gacc_TarFechaFin = Convert.ToDateTime(gacc_txtfechafin.Text);
                        GACC_ControladorTarea.modify(usuarioInfo);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos modificados  ')", true);

                    }
                }
                else if (hdfValor != gacc_txtlineas.Text)
                {
                    if (Convert.ToDateTime(gacc_txtfechainicio.Text) < i)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Escoja una Fecha igual o mayor a la del proyecto')", true);

                    }
                    else if (Convert.ToDateTime(gacc_txtfechafin.Text) > f)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Escoja una Fecha igual o menor a la del proyecto')", true);

                    }
                    else if (int.Parse(gacc_txtlineas.Text) > Convert.ToInt32(suma))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El número de Lineas supera el total de lineas que tienes  ')", true);
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(gacc_txtfechainicio.Text), Convert.ToDateTime(gacc_txtfechafin.Text)) > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tu fecha Final no puede ser menor que tu fecha inicial  ')", true);
                    }
                    else
                    {
                        var queryy = (from a in dc.GACC_TblProyecto
                                      where a.gacc_CodNompId == Convert.ToInt32(gacc_ddlproyecto.SelectedValue)
                                      select a).FirstOrDefault();

                        queryy.gacc_ProLineaCodigoExistente = Convert.ToInt32(lineasexistentesnuevas.Text);

                        dc.SubmitChanges();
                        var query = (from a in dc.GACC_TblPersona
                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                                     select a).FirstOrDefault();

                        query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                        dc.SubmitChanges();
                        usuarioInfo.gacc_TarNombre = gacc_txtnombre.Text;
                        usuarioInfo.gacc_TarLineaCodigo = Convert.ToInt32(gacc_txtlineas.Text);
                        usuarioInfo.gacc_CodActId = Convert.ToInt32(gacc_ddlactividad.Text);
                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlpersona.SelectedValue);
                        usuarioInfo.gacc_TarEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                        usuarioInfo.gacc_TarFechaInicio = Convert.ToDateTime(gacc_txtfechainicio.Text);
                        usuarioInfo.gacc_TarFechaFin = Convert.ToDateTime(gacc_txtfechafin.Text);
                        GACC_ControladorTarea.modify(usuarioInfo);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos modificados  ')", true);

                    }

                }
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
                usuarioInfo = GACC_ControladorTarea.ObtenerTareaxid(id);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }
        protected void gacc_lnkguardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        protected void gacc_lnkeditar_Click(object sender, EventArgs e)
        {
            string hdfValor = gacc_hdfActividad.Value;
            string hdfValor1 = gacc_hdfTarea.Value;
            string hdfValorestado = gacc_hdfTarea.Value;
            if (hdfValorestado != "E")
            {

                var query = (from a in dc.GACC_TblPersona
                             where a.gacc_PerId == Convert.ToInt32(gacc_ddlpersona.SelectedValue)
                             select a).FirstOrDefault();

                query.gacc_PerEstado = Convert.ToChar("D");

                dc.SubmitChanges();
            }
            else if (hdfValor1 == gacc_txtnombre.Text && hdfValor == gacc_ddlactividad.Text)
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
            Response.Redirect("GACC_LiderProyectoListarTarea.aspx");
        }

        protected void gacc_lnklimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void gacc_ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_TblPersona> listaProveedor = new List<GACC_TblPersona>();
            listaProveedor = GACC_ControladorPersona.ObtenerPersonas(int.Parse(gacc_ddlempresa.SelectedValue));

            gacc_ddlespecialidad.DataSource = listaProveedor;
            gacc_ddlespecialidad.DataTextField = "gacc_PerEspecialidad";
            gacc_ddlespecialidad.DataValueField = "gacc_PerEspecialidad";
            gacc_ddlespecialidad.DataBind();
            gacc_ddlespecialidad.Items.Insert(0, new ListItem("", "0"));

            List<GACC_ViewNombreProyectoEmpresa> listaProveedo = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_PerUsuarioNombre == Convert.ToString(gacc_lblnombreusuario.Text) && nombreproyecto.gacc_NompEstado == 'E' select nombreproyecto).ToList();
            gacc_ddlproyecto.DataSource = list;
            gacc_ddlproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlproyecto.DataValueField = "gacc_NompId";
            gacc_ddlproyecto.DataBind();
            gacc_ddlproyecto.Items.Insert(0, new ListItem("", "0"));
        }

        protected void gacc_ddlproyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewFaseActividad2> listaProveedor = new List<GACC_ViewFaseActividad2>();
            var list = (from nombreproyecto in dc.GACC_ViewMetodologiaPersonaNombreProy2 where nombreproyecto.gacc_NompId == int.Parse(gacc_ddlproyecto.SelectedValue) && nombreproyecto.gacc_MetEstado == 'E' select nombreproyecto).ToList();
            gacc_ddlmetodologia.DataSource = list;
            gacc_ddlmetodologia.DataTextField = "gacc_MetNombre";
            gacc_ddlmetodologia.DataValueField = "gacc_MetId";
            gacc_ddlmetodologia.DataBind();
            gacc_ddlmetodologia.Items.Insert(0, new ListItem("", "0"));
            var Contacto = (from i in dc.GACC_TblProyecto
                            where i.gacc_CodNompId == int.Parse(gacc_ddlproyecto.SelectedValue)
                            select new
                            {
                                i.gacc_ProLineaCodigoExistente,
                                i.gacc_ProFechaInicio,
                                i.gacc_ProFechaFin

                            }).FirstOrDefault();

            lineaexistentes.Text = Contacto.gacc_ProLineaCodigoExistente.ToString();
            inicio.Text = Contacto.gacc_ProFechaInicio.ToString("yyyy-MM-dd");
            fin.Text = Contacto.gacc_ProFechaFin.ToString("yyyy-MM-dd");

        }

        protected void gacc_ddlmetodologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewFaseActividad2> listaProveedor = new List<GACC_ViewFaseActividad2>();
            var list = (from metodologia in dc.GACC_ViewMetodologiaFase2 where metodologia.gacc_MetId == int.Parse(gacc_ddlmetodologia.SelectedValue) && metodologia.gacc_FasEstado == 'E' select metodologia).ToList();
            gacc_ddlfase.DataSource = list;
            gacc_ddlfase.DataTextField = "gacc_FasNombre";
            gacc_ddlfase.DataValueField = "gacc_FasId";
            gacc_ddlfase.DataBind();
            gacc_ddlfase.Items.Insert(0, new ListItem("", "0"));

        }

        protected void gacc_ddlfase_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewFaseActividad2> listaProveedor = new List<GACC_ViewFaseActividad2>();
            var list = (from metodologia in dc.GACC_ViewFaseActividad2 where metodologia.gacc_FasId == int.Parse(gacc_ddlfase.SelectedValue) && metodologia.gacc_ActEstado == 'E' select metodologia).ToList();
            gacc_ddlactividad.DataSource = list;
            gacc_ddlactividad.DataTextField = "gacc_ActNombre";
            gacc_ddlactividad.DataValueField = "gacc_ActId";
            gacc_ddlactividad.DataBind();
            gacc_ddlactividad.Items.Insert(0, new ListItem("", "0"));
        }

        protected void gacc_ddlcargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (gacc_lnkguardar.Visible == true)
            //{
            //    List<GACC_ViewPersonaCargoEmpresa2> listaProveedor = new List<GACC_ViewPersonaCargoEmpresa2>();
            //    var list = (from persona in dc.GACC_ViewPersonaCargoEmpresa2 where persona.gacc_CarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && persona.gacc_PerEstado == 'D' select persona).ToList();
            //    gacc_ddlpersona.DataSource = list;
            //    gacc_ddlpersona.DataTextField = "Nombres_Completos";
            //    gacc_ddlpersona.DataValueField = "gacc_PerId";
            //    gacc_ddlpersona.DataBind();
            //    gacc_ddlpersona.Items.Insert(0, new ListItem("Nombre Persona", "0"));
            //}
            //else
            //{
            //    List<GACC_ViewPersonaCargoEmpresa2> listaProveedor = new List<GACC_ViewPersonaCargoEmpresa2>();
            //    var list = (from persona in dc.GACC_ViewPersonaCargoEmpresa2 where persona.gacc_CarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && persona.gacc_PerEstado == 'D' select persona).ToList();
            //    gacc_ddlpersona.DataSource = list;
            //    gacc_ddlpersona.DataTextField = "Nombres_Completos";
            //    gacc_ddlpersona.DataValueField = "gacc_PerId";
            //    gacc_ddlpersona.DataBind();
            //    gacc_ddlpersona.Items.Insert(0, new ListItem("Nombre Persona", "0"));
            //}
        }

        protected void gacc_ddlespecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_TblPersona> listaProveedor = new List<GACC_TblPersona>();
            var list = (from persona in dc.GACC_ViewPersona where persona.gacc_CodCarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_PerEspecialidad == gacc_ddlespecialidad.SelectedValue  select persona).ToList();
            gacc_ddlpersona.DataSource = list;
            gacc_ddlpersona.DataTextField = "Nombres_Completos";
            gacc_ddlpersona.DataValueField = "gacc_PerId";
            gacc_ddlpersona.DataBind();
            gacc_ddlpersona.Items.Insert(0, new ListItem("", "0"));
        }

        protected void gacc_lnkcostos_Click(object sender, EventArgs e)
        {

            Response.Redirect("GACC_LiderProyectoInsertarCostosIndirecto.aspx");
        }

       
    }
}