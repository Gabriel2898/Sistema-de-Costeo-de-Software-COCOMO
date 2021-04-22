using System;
using System.Collections.Generic;
using GACC_Modelo;
using GACC_Controlador;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace GACC_Vista
{
    public partial class GACC_LiderProyectoReporteProyecto1 : System.Web.UI.Page
    {
        private DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ReportViewer1.LocalReport.Refresh();
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
            Session["LiderProyecto"] = null;
            Response.Redirect("GACC_Index.aspx");
        }
        protected void gacc_ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresaUsuario where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_PerUsuarioNombre == Convert.ToString(gacc_lblnombreusuario.Text) && nombreproyecto.gacc_NompEstado == 'F' select nombreproyecto).ToList();
            listaProveedor.Insert(0, new GACC_ViewNombreProyectoEmpresa() { gacc_NompNombre = "Nombre Proyecto" });
            gacc_ddlproyecto.DataSource = list;
            gacc_ddlproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlproyecto.DataValueField = "gacc_NompNombre";
            gacc_ddlproyecto.DataBind();
        }

        protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
        {
            ReportParameter p = new ReportParameter("x", gacc_ddlproyecto.Text);
            ReportViewer1.LocalReport.SetParameters(p);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }
    }
}