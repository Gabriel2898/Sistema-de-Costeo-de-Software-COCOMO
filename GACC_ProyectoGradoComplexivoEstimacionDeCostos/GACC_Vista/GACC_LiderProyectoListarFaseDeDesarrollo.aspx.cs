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
    public partial class GACC_LiderProyectoListarFaseDeDesarrollo1 : System.Web.UI.Page
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
                cargarFase();
            }
        }
        private void cargarFase()
        {
            List<GACC_ViewMetodologiaFaseUsuario> listaproductos = new List<GACC_ViewMetodologiaFaseUsuario>();
            listaproductos = GACC_ControladorFaseDeDesarrollo.ObtenerFase(gacc_lblnombreusuario.Text);
            if (listaproductos != null)
            {
                gacc_grv.DataSource = listaproductos;
                gacc_grv.DataBind();
            }
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
            Response.Redirect("GACC_LiderProyectoInsertarFaseDeDesarrollo.aspx");
        }

        protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
        {
            List<GACC_ViewMetodologiaFaseUsuario> list = new List<GACC_ViewMetodologiaFaseUsuario>();
            GACC_ViewMetodologiaFaseUsuario pro = new GACC_ViewMetodologiaFaseUsuario();
            string op = gacc_ddlcriterio.SelectedValue;
            if (op != "0")
            {
                switch (op)
                {
                    case "N":
                        pro = GACC_ControladorFaseDeDesarrollo.ObtenerFasexnombre(gacc_txtbuscar.Text);
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
                Response.Redirect("GACC_LiderProyectoInsertarFaseDeDesarrollo.aspx?cod=" + codigo, true);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                GACC_TblFaseDeDesarrollo prod = new GACC_TblFaseDeDesarrollo();
                prod = GACC_ControladorFaseDeDesarrollo.ObtenerFasexid(codigo);
                if (prod != null)
                {
                    var query = (from a in dc.GACC_TblPersona
                                 where a.gacc_PerId == prod.gacc_CodPerId
                                 select a).FirstOrDefault();

                    query.gacc_PerEstado = Convert.ToChar("D");

                    dc.SubmitChanges();
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
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }
    }
}