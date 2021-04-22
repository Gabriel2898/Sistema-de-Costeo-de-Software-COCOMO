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
    public partial class GACC_LiderFaseDeDesarrolloListarFaseDeDesarrollo1 : System.Web.UI.Page
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
                cargarFase();
            }
        }
        private void cargarFase()
        {
            List<GACC_ViewMetodologiaFaseUsuario2> listaproductos = new List<GACC_ViewMetodologiaFaseUsuario2>();
            listaproductos = GACC_ControladorFaseDeDesarrollo.ObtenerFasexvistaxusuario(gacc_lblnombreusuario.Text);
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
            Response.Redirect("GACC_LiderFaseDeDesarrolloInsertarFaseDeDesarrollo.aspx");
        }

        protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
        {
            List<GACC_ViewMetodologiaFaseUsuario2> list = new List<GACC_ViewMetodologiaFaseUsuario2>();
            GACC_ViewMetodologiaFaseUsuario2 pro = new GACC_ViewMetodologiaFaseUsuario2();
            string op = gacc_ddlcriterio.SelectedValue;
            if (op != "0")
            {
                switch (op)
                {
                    case "N":
                        pro = GACC_ControladorFaseDeDesarrollo.ObtenerFasexvusuario(gacc_txtbuscar.Text);
                        if (pro != null)
                        {
                            list.Add(pro);
                            gacc_grv.DataSource = list;
                            gacc_grv.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('no se encontro la fase')", true);
                            cargarFase();
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
                Response.Redirect("GACC_LiderFaseDeDesarrolloInsertarFaseDeDesarrollo.aspx?cod=" + codigo, true);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                GACC_TblFaseDeDesarrollo prod = new GACC_TblFaseDeDesarrollo();
                prod = GACC_ControladorFaseDeDesarrollo.ObtenerFasexid(codigo);
                if (prod != null)
                {
                    GACC_ControladorFaseDeDesarrollo.delete(prod);
                    cargarFase();
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