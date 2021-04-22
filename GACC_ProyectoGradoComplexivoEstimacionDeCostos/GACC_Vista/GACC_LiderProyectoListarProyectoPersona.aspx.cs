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
    public partial class GACC_LiderProyectoListarProyectoPersona1 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
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
                cargarEmpresa();
            }
        }
        private void cargarNombreProyeccto()
        {

            List<GACC_ViewPersonaProyecto> listaproductos = new List<GACC_ViewPersonaProyecto>();
            var list = (from nombreproyecto in dc.GACC_ViewPersonaProyecto where nombreproyecto.gacc_NompId == int.Parse(gacc_ddlnombreproyecto.SelectedValue) select nombreproyecto).ToList();
            if (list != null)
            {
                gacc_grv.DataSource = list;
                gacc_grv.DataBind();
            }
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

        protected void gacc_btnsalir_Click(object sender, EventArgs e)
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

        protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
        {
            cargarNombreProyeccto();
        }

        protected void gacc_grv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("Editar"))
            {
                Response.Redirect("GACC_LiderProyectoInsertarProyectoPersona.aspx?cod=" + codigo, true);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                GACC_TblProyectoTblPersona prod = new GACC_TblProyectoTblPersona();
                prod = GACC_ControladorProyectoPersona.ObtenerProyectoxid(codigo);
                if (prod != null)
                {
                    GACC_ControladorProyectoPersona.delete(prod);
                    cargarNombreProyeccto();
                }

            }
        }

        protected void gacc_grv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_PerUsuarioNombre == Convert.ToString(gacc_lblnombreusuario.Text) select nombreproyecto).ToList();
            listaProveedor.Insert(0, new GACC_ViewNombreProyectoEmpresa() { gacc_NompNombre = "Nombre Proyecto" });
            gacc_ddlnombreproyecto.DataSource = list;
            gacc_ddlnombreproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlnombreproyecto.DataValueField = "gacc_NompId";
            gacc_ddlnombreproyecto.DataBind();
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }
    }
}