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
    public partial class GACC_LiderProyectoInsertarProyectoCosto1 : System.Web.UI.Page
    {
        GACC_ViewProyectoCosto usu = new GACC_ViewProyectoCosto();
        DataClasses1DataContext dc = new DataClasses1DataContext();
        private GACC_TblProyectoTblCostoIndirecto usuarioInfo = new GACC_TblProyectoTblCostoIndirecto();
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
                    usu = GACC_ControladorProyectoCostoIndirecto.ObtenerCostoIxidvista(codigo);
                    if (usu != null)
                    {
                        gacc_hdfNombreproyecto.Value = usu.gacc_NompId.ToString();
                        gacc_hdfNombre.Value = usu.gacc_CostId.ToString();
                        gacc_ddlnombreproyecto.SelectedValue = usu.gacc_NompId.ToString();
                        gacc_ddlempresa.SelectedValue = usu.gacc_EmpId.ToString();
                        gacc_ddlcostoindirecto.SelectedValue = usu.gacc_CostId.ToString();

                    }

                }
                cargarEmpresa();
                cargarNombreProyecto();
                cargarCosto();
            }
        }
        private void cargarCosto()
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewCosto where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_NompId == int.Parse(gacc_ddlnombreproyecto.SelectedValue) select nombreproyecto).ToList();
            gacc_ddlcostoindirecto.Items.Insert(0, new ListItem("Nombre Proyecto", "0"));
            gacc_ddlcostoindirecto.DataSource = list;
            gacc_ddlcostoindirecto.DataTextField = "gacc_CostNombre";
            gacc_ddlcostoindirecto.DataValueField = "gacc_CostId";
            gacc_ddlcostoindirecto.DataBind();
        }
        private void cargarNombreProyecto()
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresa where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue)  select nombreproyecto).ToList();
            gacc_ddlnombreproyecto.DataSource = list;
            gacc_ddlnombreproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombreproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombreproyecto.DataBind();
            gacc_ddlnombreproyecto.Items.Insert(0, new ListItem("Nombre Proyecto", "0"));
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
            gacc_ddlcostoindirecto.Text = null;
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
            Response.Redirect("GACC_LiderProyectoInsertarProyectoCosto.aspx");
        }
        private void Guardar()
        {
            usuarioInfo = new GACC_TblProyectoTblCostoIndirecto();
            try
            {

                var existe = GACC_ControladorProyectoCostoIndirecto.Autentificostoxproyecto(Convert.ToInt32(gacc_ddlcostoindirecto.SelectedValue), Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue));
                {
                    if (existe != null)
                    {
                        GACC_TblProyectoTblCostoIndirecto usur = new GACC_TblProyectoTblCostoIndirecto();
                        usur = GACC_ControladorProyectoCostoIndirecto.ObtenerCostoIxnombreyproyecto(Convert.ToInt32(gacc_ddlcostoindirecto.SelectedValue), Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue));
                        if (usur != null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre del costo ya  existe')", true);
                        }
                    }
                    else
                    {


                        usuarioInfo.gacc_CodCostId = Convert.ToInt32(gacc_ddlcostoindirecto.SelectedValue);
                        usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue);
                        GACC_ControladorProyectoCostoIndirecto.save(usuarioInfo);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
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

            usuarioInfo = new GACC_TblProyectoTblCostoIndirecto();

            string hdfValor = gacc_hdfNombreproyecto.Value;
            string hdfvalor2 = gacc_hdfNombre.Value;
            if ((hdfvalor2 == gacc_ddlcostoindirecto.SelectedValue) && (hdfValor == gacc_ddlnombreproyecto.SelectedValue))
            {
                GuardarDatos(int.Parse(Request["cod"]));
            }

            else if (hdfvalor2 != gacc_ddlcostoindirecto.SelectedValue || hdfValor != gacc_ddlnombreproyecto.SelectedValue)
            {
                var existe = GACC_ControladorProyectoCostoIndirecto.Autentificostoxproyecto(Convert.ToInt32(gacc_ddlcostoindirecto.SelectedValue), Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue));
                {
                    if (existe != null)
                    {

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El costo ya  existe')", true);

                    }
                    else
                    {
                        GuardarDatos(int.Parse(Request["cod"]));
                    }

                }

            }

        }

        private void Modificar(GACC_TblProyectoTblCostoIndirecto usuarioInfo)
        {
            try
            {

                usuarioInfo.gacc_CodCostId = Convert.ToInt32(gacc_ddlcostoindirecto.SelectedValue);
                usuarioInfo.gacc_CodNompId = Convert.ToInt32(gacc_ddlnombreproyecto.SelectedValue);
                GACC_ControladorProyectoCostoIndirecto.modify(usuarioInfo);
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
                usuarioInfo = GACC_ControladorProyectoCostoIndirecto.ObtenerProyectoxid(codigo);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }

        protected void gacc_lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarProyectoCosto.aspx");
        }

        protected void gacc_lnklimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        protected void gacc_ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresa where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_NompEstado == 'E' select nombreproyecto).ToList();
            gacc_ddlnombreproyecto.DataSource = list;
            gacc_ddlnombreproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombreproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombreproyecto.DataBind();
            gacc_ddlnombreproyecto.Items.Insert(0, new ListItem("Nombre Proyecto", "0"));

        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }
    }
}