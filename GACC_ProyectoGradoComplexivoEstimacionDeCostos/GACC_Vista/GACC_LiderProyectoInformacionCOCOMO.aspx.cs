using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GACC_Vista
{
    public partial class GACC_LiderProyectoInformacionCOCOMO1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

        }

        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            Session["LiderProyecto"] = null;
            Response.Redirect("GACC_Index.aspx");
        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }
    }
}