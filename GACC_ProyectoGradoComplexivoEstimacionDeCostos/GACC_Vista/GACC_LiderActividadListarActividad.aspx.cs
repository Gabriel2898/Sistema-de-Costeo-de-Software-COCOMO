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
    public partial class GACC_LiderActividadListarActividad1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            Session.Timeout = 60;
            if (Session["LiderActividad"] != null)
            {
                gacc_lblnombreusuario.Text = Session["LiderActividad"].ToString();
            }
            else
            {
                Response.Redirect("GACC_Index.aspx");
            }
            cargarActividad();
        }


        private void cargarActividad()
        {
            List<GACC_ViewFaseActividad3> listaproductos = new List<GACC_ViewFaseActividad3>();
            listaproductos = GACC_ControladorActividad.ObtenerActividadxvvistass(gacc_lblnombreusuario.Text);
            if (listaproductos != null)
            {
                gacc_grv.DataSource = listaproductos;
                gacc_grv.DataBind();
            }
        }



        protected void gacc_btnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["LiderActividad"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }

        protected void gacc_lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderActividadInsertarActividad.aspx");
        }

        protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
        {
            List<GACC_ViewFaseActividad3> list = new List<GACC_ViewFaseActividad3>();
            GACC_ViewFaseActividad3 pro = new GACC_ViewFaseActividad3();
            string op = gacc_ddlcriterio.SelectedValue;
            if (op != "0")
            {
                switch (op)
                {
                    case "N":
                        pro = GACC_ControladorActividad.ObtenerActividadxvvistassbuscar(gacc_txtbuscar.Text);
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
                Response.Redirect("GACC_LiderActividadInsertarActividad.aspx?cod=" + codigo, true);
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
            Response.Redirect("GACC_LiderActividadListarUnicaPersona.aspx");
        }
    }
}