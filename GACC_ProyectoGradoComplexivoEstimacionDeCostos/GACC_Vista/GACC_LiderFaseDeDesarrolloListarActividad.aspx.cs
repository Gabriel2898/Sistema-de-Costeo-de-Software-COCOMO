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
    public partial class GACC_LiderFaseDeDesarrolloListarActividad1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            cargarActividad();
        }


        private void cargarActividad()
        {
            List<GACC_ViewFaseActividadUsuarioUsuario2> listaproductos = new List<GACC_ViewFaseActividadUsuarioUsuario2>();
            listaproductos = GACC_ControladorActividad.ObtenerActividadxvvista(gacc_lblnombreusuario.Text);
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
            Response.Redirect("GACC_LiderFaseDeDesarrolloInsertarActividad.aspx");
        }

        protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
        {
            List<GACC_ViewFaseActividadUsuarioUsuario2> list = new List<GACC_ViewFaseActividadUsuarioUsuario2>();
            GACC_ViewFaseActividadUsuarioUsuario2 pro = new GACC_ViewFaseActividadUsuarioUsuario2();
            string op = gacc_ddlcriterio.SelectedValue;
            if (op != "0")
            {
                switch (op)
                {
                    case "N":
                        pro = GACC_ControladorActividad.ObtenerActividadxvvistabuscar(gacc_txtbuscar.Text);
                        if (pro != null)
                        {
                            list.Add(pro);
                            gacc_grv.DataSource = list;
                            gacc_grv.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se encontro la actividad')", true);
                            cargarActividad();
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
                Response.Redirect("GACC_LiderFaseDeDesarrolloInsertarActividad.aspx?cod=" + codigo, true);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                GACC_TblActividad prod = new GACC_TblActividad();
                prod = GACC_ControladorActividad.ObtenerActividadxid(codigo);
                if (prod != null)
                {
                    GACC_ControladorActividad.delete(prod);
                    cargarActividad();
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