using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_CoordinadorProyecto1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gacc_lblcontenido.Text = "Bienvenido" + " " + Session["CoordinadorProyecto"].ToString();
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
            }
        }


        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["CoordinadorProyecto"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {

            Response.Redirect("GACC_CoordinadorListarUnicaPersona.aspx");
        }
    }
}