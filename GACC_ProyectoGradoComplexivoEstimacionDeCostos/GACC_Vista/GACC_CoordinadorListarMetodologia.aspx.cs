using System;
using System.Collections.Generic;
using GACC_Controlador;
using GACC_Modelo;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_CoordinadorListarMetodologia1 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                cargarMetodologia();

            }
        }
        private void cargarMetodologia()
        {
            List<GACC_ViewMetodologiaPersonaNombreProy> listaproductos = new List<GACC_ViewMetodologiaPersonaNombreProy>();
            listaproductos = GACC_ControladorMetodologia.ObtenerMetodologiaxvista();
            if (listaproductos != null)
            {
                gacc_grv.DataSource = listaproductos;
                gacc_grv.DataBind();
            }
        }


        protected void gacc_btnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["CoordinadorPrpyecto"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }

        protected void gacc_lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorInsertarMetodologia.aspx");
        }

        protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
        {
            List<GACC_ViewMetodologiaPersonaNombreProy> list = new List<GACC_ViewMetodologiaPersonaNombreProy>();
            GACC_ViewMetodologiaPersonaNombreProy pro = new GACC_ViewMetodologiaPersonaNombreProy();
            string op = gacc_ddlcriterio.SelectedValue;
            if (op != "0")
            {
                switch (op)
                {
                    case "N":
                        pro = GACC_ControladorMetodologia.ObtenerMetodologiaxnombrexvista(gacc_txtbuscar.Text);
                        if (pro != null)
                        {
                            list.Add(pro);
                            gacc_grv.DataSource = list;
                            gacc_grv.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('no se encontro la metodologia')", true);
                            cargarMetodologia();
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
                Response.Redirect("GACC_CoordinadorInsertarMetodologia.aspx?cod=" + codigo, true);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {

                GACC_TblMetodologia prod = new GACC_TblMetodologia();
                prod = GACC_ControladorMetodologia.ObtenerMetodologiaxid(codigo);
                if (prod != null)
                {
                    var query = (from a in dc.GACC_TblPersona
                                 where a.gacc_PerId == prod.gacc_CodPerId
                                 select a).FirstOrDefault();

                    query.gacc_PerEstado = Convert.ToChar("D");

                    dc.SubmitChanges();
                    GACC_ControladorMetodologia.delete(prod);
                    cargarMetodologia();
                }

            }
        }

        protected void gacc_grv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorListarUnicaPersona.aspx");
        }
    }
}