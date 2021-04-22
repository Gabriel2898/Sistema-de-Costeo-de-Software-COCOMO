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
    public partial class GACC_CoordinadorInsertarMetodologia1 : System.Web.UI.Page
    {
        private GACC_TblMetodologia usuarioInfo = new GACC_TblMetodologia();
        private GACC_TblPersona persona= new GACC_TblPersona();
        GACC_ViewMetodologiaPersonaNombreProy2 usu = new GACC_ViewMetodologiaPersonaNombreProy2();
        private GACC_TblProyectoTblPersona usuario = new GACC_TblProyectoTblPersona();
        private DataClasses1DataContext dc = new DataClasses1DataContext();
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

                    gacc_ddlestadopersona.Attributes["disabled"] = "disabled";
                    lblestadop.Visible = true;
                    gacc_ddlestadopersona.Visible = true;
                    lblestado.Visible = true;
                    gacc_ddlestado.Visible = true;
                    gacc_lnkguardar.Visible = false;
                    gacc_lnkeditar.Visible = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    usu = GACC_ControladorMetodologia.ObtenerMetodologiaxidyvista(codigo);
                    if (usuarioInfo != null)
                    {
                        
                        gacc_hdfmetodologia.Value = usu.gacc_MetNombre.ToString();
                        gacc_hdfestado.Value = usu.gacc_MetEstado.ToString();
                        gacc_hdfnombreproyecto.Value = usu.gacc_NompId.ToString();
                        gacc_ddlempresa.Text = usu.gacc_EmpId.ToString();
                        gacc_ddlcargo.SelectedValue = usu.gacc_CarId.ToString();
                        gacc_ddlestado.SelectedValue = usu.gacc_MetEstado.ToString();
                        gacc_txtnombre.Text = usu.gacc_MetNombre.ToString();
                        gacc_ddlestadopersona.Text = usu.gacc_PerEstado.ToString();
                        gacc_ddlencargado.Text = usu.gacc_PerId.ToString();
                        gacc_ddlnombreproyecto.SelectedValue = usu.gacc_NompId.ToString();
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


               
                cargarEmpresa();
                cargarCargos();
                cargarEmpleado();
                cargarNombreProyecto();

            }
        }
        private void cargarEmpleado()
        {
            List<GACC_ViewPersonaCargoEmpresa2> listaProveedor = new List<GACC_ViewPersonaCargoEmpresa2>();
            var list = (from persona in dc.GACC_ViewPersonaCargoEmpresa2 where persona.gacc_CarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue)  select persona).ToList();
            gacc_ddlencargado.DataSource = list;
            gacc_ddlencargado.DataTextField = "Nombres_Completos";
            gacc_ddlencargado.DataValueField = "gacc_PerId";
            gacc_ddlencargado.DataBind();
            gacc_ddlencargado.Items.Insert(0, new ListItem("", "0"));
        }
        private void cargarNombreProyecto()
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresa where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue)  select nombreproyecto).ToList();
            gacc_ddlnombreproyecto.DataSource = list;
            gacc_ddlnombreproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombreproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombreproyecto.DataBind();
            gacc_ddlnombreproyecto.Items.Insert(0, new ListItem("", "0"));
        }
        private void cargarCargos()
        {
            var list = (from persona in dc.GACC_TblCargo where persona.gacc_CarId == int.Parse("2") select persona).ToList();
            gacc_ddlcargo.DataSource = list;
            gacc_ddlcargo.DataTextField = "gacc_CarNombre";
            gacc_ddlcargo.DataValueField = "gacc_CarId";
            gacc_ddlcargo.DataBind();
            gacc_ddlcargo.Items.Insert(0, new ListItem("", "0"));
        }

        private void cargarEmpresa()
        {
            List<GACC_TblEmpresa> listaProveedor = new List<GACC_TblEmpresa>();
            listaProveedor = GACC_ControladorEmpresa.ObtenerEmpresaddls();
            listaProveedor.Insert(0, new GACC_TblEmpresa() { gacc_EmpNombre = "" });
            gacc_ddlempresa.DataSource = listaProveedor;
            gacc_ddlempresa.DataTextField = "gacc_EmpNombre";
            gacc_ddlempresa.DataValueField = "gacc_EmpId";
            gacc_ddlempresa.DataBind();
        }


        private void Limpiar()
        {
            gacc_txtnombre.Text = string.Empty;
            gacc_ddlencargado.Text = null;
            gacc_ddlnombreproyecto.Text = null;
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
            Response.Redirect("GACC_CoordinadorInsertarMetodologia.aspx");
        }
        private void Guardar()
        {
            persona = new GACC_TblPersona();
            usuario = new GACC_TblProyectoTblPersona();
            usuarioInfo = new GACC_TblMetodologia();
            try {
                var count = (from prod in dc.GACC_TblMetodologia where prod.gacc_CodPerId == int.Parse(gacc_ddlencargado.SelectedValue) && prod.gacc_MetEstado == 'E' select prod).Count();
                
                bool existe = GACC_ControladorMetodologia.AutentificarMetodologiaxnombreproyecto(Convert.ToInt32(gacc_ddlnombreproyecto.Text), gacc_txtnombre.Text);
                {
                    if (existe)
                    {
                        GACC_TblMetodologia usur = new GACC_TblMetodologia();
                        usur = GACC_ControladorMetodologia.ObtenerMetodologiaxnombreynombreproyectoproyecto(Convert.ToInt32(gacc_ddlnombreproyecto.Text), gacc_txtnombre.Text);
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre del proyecto ya tiene metodología')", true);
                        }
                    }
                    else
                    {
                        bool existepersona = GACC_ControladorProyectoPersona.AutentificarPersonaProyecto(Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue), Convert.ToInt32(gacc_ddlencargado.SelectedValue));
                       {
                            if (existepersona)
                            {
                                if (count < 2)
                                {
                                    if (count < 1)
                                    {
                                        var query = (from a in dc.GACC_TblPersona
                                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlencargado.SelectedValue)
                                                     select a).FirstOrDefault();

                                        query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                                        dc.SubmitChanges();
                                        usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.Text);
                                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.Text);
                                        usuarioInfo.gacc_MetNombre = gacc_txtnombre.Text;
                                        usuarioInfo.gacc_MetEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                        GACC_ControladorMetodologia.save(usuarioInfo);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);

                                    }
                                    else
                                    {
                                        var query = (from a in dc.GACC_TblPersona
                                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlencargado.SelectedValue)
                                                     select a).FirstOrDefault();

                                        query.gacc_PerEstado = Convert.ToChar("O");

                                        dc.SubmitChanges();
                                        usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.Text);
                                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.Text);
                                        usuarioInfo.gacc_MetNombre = gacc_txtnombre.Text;
                                        usuarioInfo.gacc_MetEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                        GACC_ControladorMetodologia.save(usuarioInfo);
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
                                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlencargado.SelectedValue)
                                                     select a).FirstOrDefault();

                                        query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                                        dc.SubmitChanges();

                                        usuario.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.SelectedValue);
                                        usuario.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue);
                                        usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.Text);
                                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.Text);
                                        usuarioInfo.gacc_MetNombre = gacc_txtnombre.Text;
                                        usuarioInfo.gacc_MetEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                        GACC_ControladorMetodologia.save(usuarioInfo);
                                        GACC_ControladorProyectoPersona.save(usuario);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                                    }
                                    else
                                    {
                                        var query = (from a in dc.GACC_TblPersona
                                                     where a.gacc_PerId == Convert.ToInt32(gacc_ddlencargado.SelectedValue)
                                                     select a).FirstOrDefault();

                                        query.gacc_PerEstado = Convert.ToChar("O");

                                        dc.SubmitChanges();

                                        usuario.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.SelectedValue);
                                        usuario.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue);
                                        usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.Text);
                                        usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.Text);
                                        usuarioInfo.gacc_MetNombre = gacc_txtnombre.Text;
                                        usuarioInfo.gacc_MetEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                        GACC_ControladorMetodologia.save(usuarioInfo);
                                        GACC_ControladorProyectoPersona.save(usuario);
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

            usuario = new GACC_TblProyectoTblPersona();
            usuarioInfo = new GACC_TblMetodologia();
            string hdfValor = gacc_hdfmetodologia.Value;
            string hdfValor1 = gacc_hdfnombreproyecto.Value;
            string hdfValorestado = gacc_hdfestado.Value;
            if (hdfValorestado != "E") {
            
                var query = (from a in dc.GACC_TblPersona
                             where a.gacc_PerId == Convert.ToInt32(gacc_ddlencargado.SelectedValue)
                             select a).FirstOrDefault();

                query.gacc_PerEstado = Convert.ToChar("D");

                dc.SubmitChanges();
            }else if (hdfValor == gacc_txtnombre.Text && hdfValor1==gacc_ddlnombreproyecto.Text)
            {
                GuardarDatos(int.Parse(Request["cod"]));
            }
            else if (hdfValor != gacc_txtnombre.Text || hdfValor1!=gacc_ddlnombreproyecto.Text)
            {

                var existe = GACC_ControladorMetodologia.AutentificarMetodologiaxnombreproyectoss(Convert.ToInt32(gacc_ddlnombreproyecto.Text), gacc_txtnombre.Text);
                {
                    if (existe!=null)
                    {

                        GACC_TblMetodologia usur = new GACC_TblMetodologia();
                        usur = GACC_ControladorMetodologia.ObtenerMetodologiaxnombreynombreproyectoproyecto(Convert.ToInt32(gacc_ddlnombreproyecto.Text), gacc_txtnombre.Text);
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre del proyecto ya tiene metodología ')", true);

                        }

                    }
                    else
                    {

                        GuardarDatos(int.Parse(Request["cod"]));
                    }
                }
            }
        }
        private void Modificar(GACC_TblMetodologia usuarioInfo)
        {

            try
            {
                var query = (from a in dc.GACC_TblPersona
                             where a.gacc_PerId == Convert.ToInt32(gacc_ddlencargado.SelectedValue)
                             select a).FirstOrDefault();

                query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                dc.SubmitChanges();
                usuarioInfo.gacc_MetEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue);
                usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.SelectedValue);
                usuarioInfo.gacc_MetNombre = gacc_txtnombre.Text;
                GACC_ControladorMetodologia.modify(usuarioInfo);
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
                usuarioInfo = GACC_ControladorMetodologia.ObtenerMetodologiaxid(id);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }

        protected void gacc_lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorListarMetodologia.aspx");
        }


        protected void gacc_lnklimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void gacc_ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresa where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) &&nombreproyecto.gacc_NompEstado=='E' select nombreproyecto).ToList();
            gacc_ddlnombreproyecto.DataSource = list;
            gacc_ddlnombreproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombreproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombreproyecto.DataBind();
            gacc_ddlnombreproyecto.Items.Insert(0, new ListItem("", "0"));

        }

        protected void gacc_ddlcargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lista = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresa where nombreproyecto.gacc_NompId == int.Parse(gacc_ddlnombreproyecto.SelectedValue) select nombreproyecto).ToList();
            gacc_ddlencargado.DataSource = lista;
            gacc_ddlencargado.DataTextField = "Nombres_Completos";
            gacc_ddlencargado.DataValueField = "gacc_PerId";
            gacc_ddlencargado.DataBind();
            gacc_ddlencargado.Items.Insert(0, new ListItem("", "0"));
          
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorListarUnicaPersona.aspx");
        }

        protected void gacc_lnkfasededesarrollo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorInsertarFaseDeDesarrollo.aspx");
        }
    }
}