using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GACC_Modelo;
using GACC_Controlador;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_CoordinadorListarActividad1 : System.Web.UI.Page
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
                cargarActividad();
            }
        }

        private void cargarActividad()
        {
            List<GACC_ViewFaseActividad> listaproductos = new List<GACC_ViewFaseActividad>();
            listaproductos = GACC_ControladorActividad.ObtenerActividadxvista();
            if (listaproductos != null)
            {
                gacc_grv.DataSource = listaproductos;
                gacc_grv.DataBind();
            }
        }



        protected void gacc_btnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["CoordinadorProyecto"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }

        protected void gacc_lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_CoordinadorInsertarActividad.aspx");
        }

        protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
        {
            List<GACC_ViewFaseActividad> list = new List<GACC_ViewFaseActividad>();
            GACC_ViewFaseActividad pro = new GACC_ViewFaseActividad();
            string op = gacc_ddlcriterio.SelectedValue;
            if (op != "0")
            {
                switch (op)
                {
                    case "N":
                        pro = GACC_ControladorActividad.ObtenerActividadxnombress(gacc_txtbuscar.Text);
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
                Response.Redirect("GACC_CoordinadorInsertarActividad.aspx?cod=" + codigo, true);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                GACC_TblPersona per = new GACC_TblPersona();
                GACC_TblActividad prod = new GACC_TblActividad();
                prod = GACC_ControladorActividad.ObtenerActividadxid(codigo);
                if (prod != null)
                {
                    var query = (from a in dc.GACC_TblPersona
                                 where a.gacc_PerId == prod.gacc_CodPerId
                                 select a).FirstOrDefault();

                    query.gacc_PerEstado = Convert.ToChar("D");

                    dc.SubmitChanges();
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
            Response.Redirect("GACC_CoordinadorListarUnicaPersona.aspx");
        }
    }
}