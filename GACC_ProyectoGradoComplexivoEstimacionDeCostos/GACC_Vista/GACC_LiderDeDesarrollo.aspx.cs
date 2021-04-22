using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_LiderDeDesarrollo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gacc_lblcontenido.Text = "Bienvenido" + " " + Session["LiderDeDesarrollo"].ToString();
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
            }
        }

        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            Session["LiderDeDesarrollo"] = null;
            Response.Redirect("GACC_Index.aspx");
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderDeDesarrolloListarUnicaPersona.aspx");
        }
    }
}