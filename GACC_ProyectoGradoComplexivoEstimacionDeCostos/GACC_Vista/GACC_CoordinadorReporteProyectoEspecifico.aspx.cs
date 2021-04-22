using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using GACC_Controlador;
using GACC_Modelo;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace GACC_Vista
{
    public partial class GACC_CoordinadorReporteProyectoEspecifico1 : System.Web.UI.Page
    {
        private DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ReportViewer1.LocalReport.Refresh();
            if (!IsPostBack)
            {
                Session.Timeout = 60;
                if (Session["CoordinadorProyecto"] != null)
                {
                    gacc_lblnombreusuario.Text = Session["CoordinadorProyecto"].ToString();
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
            List<GACC_TblEmpresa> listaProveedor = new List<GACC_TblEmpresa>();
            listaProveedor = GACC_ControladorEmpresa.ObtenerEmpresaddls();


            gacc_ddlempresa.DataSource = listaProveedor;
            gacc_ddlempresa.DataTextField = "gacc_EmpNombre";
            gacc_ddlempresa.DataValueField = "gacc_EmpId";
            gacc_ddlempresa.DataBind();
            gacc_ddlempresa.Items.Insert(0, new ListItem("Nombre Empresa", "0"));
        }
        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            Session["CoordinadorProyecto"] = null;
            Response.Redirect("GACC_Index.aspx");
        }
        protected void gacc_ddlempresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GACC_ViewNombreProyectoEmpresa> listaProveedor = new List<GACC_ViewNombreProyectoEmpresa>();
            var list = (from nombreproyecto in dc.GACC_ViewNombreProyectoEmpresa where nombreproyecto.gacc_EmpId == int.Parse(gacc_ddlempresa.SelectedValue) && nombreproyecto.gacc_NompEstado == 'E' select nombreproyecto).ToList();
            gacc_ddlproyecto.DataSource = list;
            gacc_ddlproyecto.DataTextField = "gacc_NompNombre";
            gacc_ddlproyecto.DataValueField = "gacc_NompNombre";
            gacc_ddlproyecto.DataBind();
            gacc_ddlproyecto.Items.Insert(0, new ListItem("Nombre Proyecto", "0"));
        }

        protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
        {
            ReportParameter p = new ReportParameter("x", gacc_ddlproyecto.Text);
            ReportViewer1.LocalReport.SetParameters(p);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorListarUnicaPersona.aspx");
        }
    }
}