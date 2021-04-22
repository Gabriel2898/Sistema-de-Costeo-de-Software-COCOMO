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
    public partial class GACC_CoordinadorListarEmpresa1 : System.Web.UI.Page
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
                    cargarEmpresa();
                }
            }
            private void cargarEmpresa()
            {
                List<GACC_TblEmpresa> listaproductos = new List<GACC_TblEmpresa>();
                listaproductos = GACC_ControladorEmpresa.ObtenerEmpresa();
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
                Response.Redirect("GACC_CoordinadorInsertarEmpresa.aspx");
            }

            protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
            {
                List<GACC_TblEmpresa> list = new List<GACC_TblEmpresa>();
                GACC_TblEmpresa pro = new GACC_TblEmpresa();
                string op = gacc_ddlcriterio.SelectedValue;
                if (op != "0")
                {
                    switch (op)
                    {
                        case "N":
                            pro = GACC_ControladorEmpresa.ObtenerEmpresaxnombres(gacc_txtbuscar.Text);
                            if (pro != null)
                            {
                                list.Add(pro);
                                gacc_grv.DataSource = list;
                                gacc_grv.DataBind();
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se encontro la empresa ')", true);
                                cargarEmpresa();
                            }
                            break;
                        case "R":
                            pro = GACC_ControladorEmpresa.ObtenerEmpresaxruc(gacc_txtbuscar.Text);
                            if (pro != null)
                            {
                                list.Add(pro);
                                gacc_grv.DataSource = list;
                                gacc_grv.DataBind();
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se encontro la empresa ')", true);
                                cargarEmpresa();
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
                    Response.Redirect("GACC_CoordinadorInsertarEmpresa.aspx?cod=" + codigo, true);
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    GACC_TblEmpresa prod = new GACC_TblEmpresa();
                    prod = GACC_ControladorEmpresa.ObtenerEmpresaxid(codigo);
                    if (prod != null)
                    {
                        GACC_ControladorEmpresa.delete(prod);
                        cargarEmpresa();
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