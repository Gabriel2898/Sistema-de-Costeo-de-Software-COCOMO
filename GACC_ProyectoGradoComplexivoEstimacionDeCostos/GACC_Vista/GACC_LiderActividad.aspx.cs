using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_LiderActividad1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gacc_lblcontenido.Text = "Bienvenido" + " " + Session["LiderActividad"].ToString();
            if (!IsPostBack)
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
            }
        }
    

        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
        {
            Session["LiderActividad"] = null;
            Response.Redirect("GACC_Index.aspx");
        }
    }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderActividadListarUnicaPersona.aspx");
        }
    }
}