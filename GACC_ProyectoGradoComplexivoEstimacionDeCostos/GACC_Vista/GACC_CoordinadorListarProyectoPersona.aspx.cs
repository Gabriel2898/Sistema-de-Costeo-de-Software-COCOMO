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
    public partial class GACC_CoordinadorListarProyectoPersona1 : System.Web.UI.Page
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
                    cargarNombreProyeccto();
                }
            }
            private void cargarNombreProyeccto()
            {
                List<GACC_ViewPersonaProyecto> listaproductos = new List<GACC_ViewPersonaProyecto>();
                listaproductos = GACC_ControladorProyectoPersona.ObtenerProyectoslistar();
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
                Response.Redirect("GACC_CoordinadorInsertarProyectoPersona.aspx");
            }

            protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
            {
                List<GACC_ViewPersonaProyecto> list = new List<GACC_ViewPersonaProyecto>();
            GACC_ViewPersonaProyecto pro = new GACC_ViewPersonaProyecto();
                string op = gacc_ddlcriterio.SelectedValue;
                if (op != "0")
                {
                    switch (op)
                    {
                        case "N":
                            list = GACC_ControladorProyectoPersona.ObtenerProyectoxnombreslistar(gacc_txtbuscar.Text);
                            if (pro != null)
                            {
                                list.Add(pro);
                                gacc_grv.DataSource = list;
                                gacc_grv.DataBind();
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se encontro el proyecto')", true);
                                cargarNombreProyeccto();
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
                    Response.Redirect("GACC_CoordinadorInsertarProyectoPersona.aspx?cod=" + codigo, true);
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    GACC_TblProyectoTblPersona prod = new GACC_TblProyectoTblPersona();
                    prod = GACC_ControladorProyectoPersona.ObtenerProyectoxid(codigo);
                    if (prod != null)
                    {
                    GACC_ControladorProyectoPersona.delete(prod);
                        cargarNombreProyeccto();
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