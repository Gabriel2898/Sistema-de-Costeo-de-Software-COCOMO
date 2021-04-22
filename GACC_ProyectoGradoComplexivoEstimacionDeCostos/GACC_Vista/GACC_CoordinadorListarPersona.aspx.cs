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
    public partial class GACC_CoordinadorListarPersona1 : System.Web.UI.Page
    {
       
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
                cargarPersona();
                }
            }
            private void cargarPersona()
            {
                List<GACC_ViewPersonaCargoEmpresa> listaproductos = new List<GACC_ViewPersonaCargoEmpresa>();
                listaproductos = GACC_ControladorPersona.ObtenerEmpleadoxvista();
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
                Response.Redirect("GACC_CoordinadorInsertarPersona.aspx");
            }

            protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
            {
                List<GACC_ViewPersonaCargoEmpresa> list = new List<GACC_ViewPersonaCargoEmpresa>();
                GACC_ViewPersonaCargoEmpresa pro = new GACC_ViewPersonaCargoEmpresa();
                string op = gacc_ddlcriterio.SelectedValue;
                if (op != "0")
                {
                    switch (op)
                    {
                        case "N":
                            pro = GACC_ControladorPersona.ObtenerEmpleadoxcedulaxvista(gacc_txtbuscar.Text);
                            if (pro != null)
                            {
                                list.Add(pro);
                                gacc_grv.DataSource = list;
                                gacc_grv.DataBind();
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('no se encontro la persona ')", true);
                                cargarPersona();
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
                    Response.Redirect("GACC_CoordinadorInsertarPersona.aspx?cod=" + codigo, true);
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    GACC_TblPersona prod = new GACC_TblPersona();
                    prod = GACC_ControladorPersona.ObtenerEmpleadoxid(codigo);
                    if (prod != null)
                    {
                        GACC_ControladorPersona.delete(prod);
                        cargarPersona();
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