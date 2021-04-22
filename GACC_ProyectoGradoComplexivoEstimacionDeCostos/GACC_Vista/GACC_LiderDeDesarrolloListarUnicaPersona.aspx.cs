using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GACC_Modelo;
using GACC_Controlador;

namespace GACC_Vista
{
    public partial class GACC_LiderDeDesarrolloListarUnicaPersona1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Timeout = 60;
                if (Session["LiderDeDesarrollo"] != null)
                {
                    gacc_lblnombreusuario.Text = Session["LiderDeDesarrollo"].ToString();
                }
                else
                {
                    Response.Redirect("GACC_Index.aspx");
                }
                cargarPersona();
            }
        }
        private void cargarPersona()
        {
            List<GACC_ViewPersonaCargoEmpresa> listaproductos = new List<GACC_ViewPersonaCargoEmpresa>();
            listaproductos = GACC_ControladorPersona.ObtenerEmpleadoxnombreusuario(gacc_lblnombreusuario.Text);
            if (listaproductos != null)
            {
                gacc_grv.DataSource = listaproductos;
                gacc_grv.DataBind();
            }
        }

        protected void gacc_btnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["LiderDeDesarrollo"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }




        protected void gacc_grv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("Editar"))
            {
                Response.Redirect("GACC_LiderDeDesarrolloInsertarPersona.aspx?cod=" + codigo, true);
            }

        }

        protected void gacc_grv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderDeDesarrolloListarUnicaPersona.aspx");
        }
    }
}