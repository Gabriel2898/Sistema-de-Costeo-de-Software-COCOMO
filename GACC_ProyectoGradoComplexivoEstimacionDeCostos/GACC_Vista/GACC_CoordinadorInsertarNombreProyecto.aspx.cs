using System;
using System.Collections.Generic;
using GACC_Modelo;
using GACC_Controlador;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_CoordinadorInsertarNombreProyecto1 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        GACC_ViewNombreProyectoListar usu = new GACC_ViewNombreProyectoListar();
        private GACC_TblNombreProyecto usuarioInfo = new GACC_TblNombreProyecto();
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
                    usu = GACC_ControladorNombreProyecto.ObtenerProyectoxidvista(codigo);
                    if (usu != null)
                    {
                        gacc_hdfNombreproyecto.Value = usu.gacc_NompNombre.ToString();

                        gacc_hdfestado.Value = usu.gacc_NompEstado.ToString();
                        gacc_hdfNombreproyecto1.Value = usu.gacc_EmpId.ToString();
                        gacc_txtnombre.Text = usu.gacc_NompNombre.ToString();
                        gacc_ddlempresa.SelectedValue = usu.gacc_EmpId.ToString();
                        gacc_ddlestado.SelectedValue = usu.gacc_NompEstado.ToString();
                        gacc_ddlencargado.SelectedValue = usu.gacc_PerId.ToString();
                        gacc_ddlcargo.SelectedValue = usu.gacc_CarId.ToString();

                    }

                }
                else
                {
                    gacc_ddlestadopersona.Visible = false;
                    lblestadop.Visible = false;
                    gacc_ddlestado.Visible = false;
                    lblestado.Visible = false;
                    gacc_ddlestado.Items.FindByValue("F").Enabled = false;
                    gacc_ddlestadopersona.Items.FindByValue("O").Enabled = false;
                }
                cargarCargos();
                cargarEmpresa();
                cargarEmpleado();
            }
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
        private void cargarEmpleado()
        {
            var list = (from persona in dc.GACC_ViewPersonaCargoEmpresa2 where persona.gacc_CarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue)  select persona).ToList();
            gacc_ddlencargado.DataSource = list;
            gacc_ddlencargado.DataTextField = "Nombres_Completos";
            gacc_ddlencargado.DataValueField = "gacc_PerId";
            gacc_ddlencargado.DataBind();
            gacc_ddlencargado.Items.Insert(0, new ListItem("", "0"));
        }

        private void Limpiar()
        {
            gacc_txtnombre.Text = string.Empty;
            gacc_ddlempresa.Text = null;
            gacc_ddlestado.Text = null;
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
            Response.Redirect("GACC_CoordinadorInsertarNombreProyecto.aspx");
        }
        private void Guardar()
        {
            usuarioInfo = new GACC_TblNombreProyecto();
            try
            {

               var count =    (from prod in dc.GACC_TblNombreProyecto where prod.gacc_CodPerId==int.Parse(gacc_ddlencargado.SelectedValue)&& prod.gacc_NompEstado =='E'  select prod).Count();
               
                var existe = GACC_ControladorNombreProyecto.Autentificoproyectoxempresa(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlempresa.Text));
                {
                    if (existe != null)
                    {
                        GACC_TblNombreProyecto usur = new GACC_TblNombreProyecto();
                        usur = GACC_ControladorNombreProyecto.ObtenerProyectoxempresasynombre(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlempresa.Text));
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre del proyecto ya  existe')", true);
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

                                        usuarioInfo.gacc_NompNombre = gacc_txtnombre.Text;
                                usuarioInfo.gacc_NompEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                usuarioInfo.gacc_CodEmpId = Convert.ToInt32(gacc_ddlempresa.SelectedValue);
                                usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.SelectedValue);
                                GACC_ControladorNombreProyecto.save(usuarioInfo);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                            }
                            else
                            {
                                var query = (from a in dc.GACC_TblPersona
                                             where a.gacc_PerId == Convert.ToInt32(gacc_ddlencargado.SelectedValue)
                                             select a).FirstOrDefault();

                                query.gacc_PerEstado = Convert.ToChar("O");

                                dc.SubmitChanges();
                                usuarioInfo.gacc_NompNombre = gacc_txtnombre.Text;
                                usuarioInfo.gacc_NompEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                                usuarioInfo.gacc_CodEmpId = Convert.ToInt32(gacc_ddlempresa.SelectedValue);
                                usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.SelectedValue);
                                GACC_ControladorNombreProyecto.save(usuarioInfo);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La Persona Tiene bastante trabajo, Porfavor Selecciona otra ')", true);
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

            usuarioInfo = new GACC_TblNombreProyecto();

            string hdfValor = gacc_hdfNombreproyecto.Value;
            string hdfvalor2 = gacc_hdfNombreproyecto1.Value;
            string hdfValorestado = gacc_hdfestado.Value;
            if (hdfValorestado != "E")
            {

                var query = (from a in dc.GACC_TblPersona
                             where a.gacc_PerId == Convert.ToInt32(gacc_ddlencargado.SelectedValue)
                             select a).FirstOrDefault();

                query.gacc_PerEstado = Convert.ToChar("D");

                dc.SubmitChanges();
            }
            else if ((hdfValor == gacc_txtnombre.Text)&&(hdfvalor2==gacc_ddlempresa.SelectedValue))
             {
                 GuardarDatos(int.Parse(Request["cod"]));
             }

             else if ((hdfValor != gacc_txtnombre.Text) || (hdfvalor2!=gacc_ddlempresa.SelectedValue) )
             {
                 var existe = GACC_ControladorNombreProyecto.Autentificoproyectoxempresa(gacc_txtnombre.Text, Convert.ToInt32(gacc_ddlempresa.SelectedValue));
                 {
                     if (existe != null)
                     {

                             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre del proyecto ya  existe')", true);

                     }
                     else
                     {
            GuardarDatos(int.Parse(Request["cod"]));
             }

         }

     }

        }

        private void Modificar(GACC_TblNombreProyecto usuarioInfo)
        {
            try
            {
                var query = (from a in dc.GACC_TblPersona
                             where a.gacc_PerId == Convert.ToInt32(gacc_ddlencargado.SelectedValue)
                             select a).FirstOrDefault();

                query.gacc_PerEstado = Convert.ToChar(gacc_ddlestadopersona.SelectedValue);

                dc.SubmitChanges();
                usuarioInfo.gacc_NompNombre = gacc_txtnombre.Text;
                usuarioInfo.gacc_NompEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.SelectedValue);
                usuarioInfo.gacc_CodEmpId = Convert.ToInt32(gacc_ddlempresa.SelectedValue);
                GACC_ControladorNombreProyecto.modify(usuarioInfo);
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
                usuarioInfo = GACC_ControladorNombreProyecto.ObtenerProyectoxid(codigo);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }

        protected void gacc_lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorListarNombreProyecto.aspx");
        }

        protected void gacc_lnklimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

      

        protected void gacc_ddlcargo_SelectedIndexChanged(object sender, EventArgs e)
        {

                List<GACC_ViewPersonaCargoEmpresa2> listaProveedor = new List<GACC_ViewPersonaCargoEmpresa2>();
                var list = (from persona in dc.GACC_ViewPersonaCargoEmpresa2 where persona.gacc_CarId == int.Parse(gacc_ddlcargo.SelectedValue) && persona.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue)select persona).ToList();
                gacc_ddlencargado.DataSource = list;
                gacc_ddlencargado.DataTextField = "Nombres_Completos";
                gacc_ddlencargado.DataValueField = "gacc_PerId";
                gacc_ddlencargado.DataBind();
            gacc_ddlencargado.Items.Insert(0, new ListItem("", "0"));

        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorListarUnicaPersona.aspx");
        }

        protected void gacc_lnklineas_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorLineasCodigo.aspx");
        }
    }
}