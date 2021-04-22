using System;
using GACC_Modelo;
using GACC_Controlador;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_LiderFaseDeDesarrolloListarTarea1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Session.Timeout = 60;
                if (Session["LiderFaseDeDesarrollo"] != null)
                {
                    gacc_lblnombreusuario.Text = Session["LiderFaseDeDesarrollo"].ToString();
                }
                else
                {
                    Response.Redirect("GACC_Index.aspx");
                }
                cargarTarea();
            }
        }

        private void cargarTarea()
        {
            List<GACC_ViewFaseActividadTarea> listaproductos = new List<GACC_ViewFaseActividadTarea>();
            listaproductos = GACC_ControladorTarea.ObtenerTareaxvista(gacc_lblnombreusuario.Text);
            if (listaproductos != null)
            {
                gacc_grv.DataSource = listaproductos;
                gacc_grv.DataBind();
            }
        }




        protected void gacc_btnsalir_Click(object sender, EventArgs e)
        {

            {
                Session["LiderFaseDeDesarrollo"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }

        protected void gacc_lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderFaseDeDesarrolloInsertarTarea.aspx");
        }

        protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
        {
            List<GACC_ViewFaseActividadTarea> list = new List<GACC_ViewFaseActividadTarea>();
            GACC_ViewFaseActividadTarea pro = new GACC_ViewFaseActividadTarea();
            string op = gacc_ddlcriterio.SelectedValue;
            if (op != "0")
            {
                switch (op)
                {
                    case "N":
                        pro = GACC_ControladorTarea.ObtenerTareavista(gacc_txtbuscar.Text);
                        if (pro != null)
                        {
                            list.Add(pro);
                            gacc_grv.DataSource = list;
                            gacc_grv.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('no se encontro la Tarea')", true);
                            cargarTarea();
                        }
                        break;
                }
            }
        }

        protected void gacc_grv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("Editar"))
            {
                Response.Redirect("GACC_LiderFaseDeDesarrolloInsertarTarea.aspx?cod=" + codigo, true);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                GACC_TblTarea prod = new GACC_TblTarea();
                prod = GACC_ControladorTarea.ObtenerTareaxid(codigo);
                if (prod != null)
                {
                    GACC_ControladorTarea.delete(prod);
                    cargarTarea();
                }

            }
        }

        protected void gacc_grv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderFaseDeDesarrolloListarUnicaPersona.aspx");
        }
    }
}