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
    public partial class GACC_LiderProyectoInsertarProyectoPersona1 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        GACC_ViewPersonaProyecto usu = new GACC_ViewPersonaProyecto();
        private GACC_TblProyectoTblPersona usuarioInfo = new GACC_TblProyectoTblPersona();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
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
                    usu = GACC_ControladorProyectoPersona.ObtenerProyectoxidddls(codigo);
                    if (usu != null)
                    {
                        gacc_hdfNombreproyecto.Value = usu.gacc_PerId.ToString();
                        gacc_hdfNombreproyecto1.Value = usu.gacc_NompId.ToString();
                        gacc_ddlnombreproyecto.Text = usu.gacc_NompId.ToString();
                        gacc_ddlencargado.Text = usu.gacc_PerId.ToString();
                        gacc_ddlempresa.SelectedValue = usu.gacc_EmpId.ToString();

                    }

                }
                cargarEmpresa();
                cargarEmpleado();
                cargarNombreProyecto();
            }
        }
        private void cargarEmpleado()
        {
            List<GACC_ViewPersonaProyecto> listaProveedor = new List<GACC_ViewPersonaProyecto>();
            var list = (from nombreproyecto in dc.GACC_ViewPersonaCargoEmpresa2 where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) select nombreproyecto).ToList();
           gacc_ddlencargado.DataSource = list;
            gacc_ddlencargado.DataTextField = "Nombres_Completos";
            gacc_ddlencargado.DataValueField = "gacc_PerId";
            gacc_ddlencargado.DataBind();
            gacc_ddlencargado.Items.Insert(0, new ListItem("Nombre Persona", "0"));
        }
        private void cargarNombreProyecto()
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresa where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue)  select nombreproyecto).ToList();
            listaProveedor.Insert(0, new GACC_ViewNombreProyectoEmpresa() { gacc_NompNombre = "Nombre Proyecto" });
            gacc_ddlnombreproyecto.DataSource = list;
            gacc_ddlnombreproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombreproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombreproyecto.DataBind();
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
            gacc_ddlnombreproyecto.Text = null;
            gacc_ddlnombreproyecto.Text = null;
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
            Response.Redirect("GACC_LiderProyectoInsertarProyectoPersona.aspx");
        }
        private void Guardar()
        {
            usuarioInfo = new GACC_TblProyectoTblPersona();
            try
            {

                usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue);
                usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.SelectedValue);
                GACC_ControladorProyectoPersona.save(usuarioInfo);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
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
            usuarioInfo = new GACC_TblProyectoTblPersona();

            string hdfValor = gacc_hdfNombreproyecto.Value;
            string hdfvalor2 = gacc_hdfNombreproyecto1.Value;
            if ((hdfvalor2 == gacc_ddlempresa.SelectedValue) && (hdfValor == gacc_ddlencargado.SelectedValue))
            {
                GuardarDatos(int.Parse(Request["cod"]));
            }

            else if ((hdfValor != gacc_ddlencargado.SelectedValue) || (hdfvalor2 != gacc_ddlempresa.SelectedValue))
            {
                var existe = GACC_ControladorProyectoPersona.Autentificopersonaproyecto(Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue), Convert.ToInt32(gacc_ddlempresa.SelectedValue));
                {
                    if (existe != null)
                    {

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La persona ya  existe')", true);

                    }
                    else
                    {

                        GuardarDatos(int.Parse(Request["cod"]));
                    }
                }
            }
        }

        private void Modificar(GACC_TblProyectoTblPersona usuarioInfo)
        {
            try
            {
                usuarioInfo.gacc_CodPerId = Convert.ToInt32(gacc_ddlencargado.SelectedValue);
                usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue);
                GACC_ControladorProyectoPersona.modify(usuarioInfo);
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
                usuarioInfo = GACC_ControladorProyectoPersona.ObtenerProyectoxid(codigo);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }

        protected void gacc_lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarProyectoPersona.aspx");
        }

        protected void gacc_lnklimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void gacc_ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {

          
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresa where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_NompEstado == 'E' select nombreproyecto).ToList();
            gacc_ddlnombreproyecto.DataSource = list;
            gacc_ddlnombreproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombreproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombreproyecto.DataBind();
            gacc_ddlnombreproyecto.Items.Insert(0, new ListItem("Nombre Proyecto", "0"));
            var lista = (from nombreproyecto in dc.GACC_ViewPersonaCargoEmpresa2 where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) select nombreproyecto).ToList();
            gacc_ddlencargado.DataSource = lista;
            gacc_ddlencargado.DataTextField = "Nombres_Completos";
            gacc_ddlencargado.DataValueField = "gacc_PerId";
            gacc_ddlencargado.DataBind();
            gacc_ddlencargado.Items.Insert(0, new ListItem("Nombre Persona", "0"));
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }
    }
}