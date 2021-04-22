using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GACC_Modelo;
using GACC_Controlador;

namespace GACC_Vista
{
    public partial class GACC_CoordinadorListarProyectoCosto1 : System.Web.UI.Page
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
                List<GACC_ViewProyectoCosto> listaproductos = new List<GACC_ViewProyectoCosto>();
                listaproductos = GACC_ControladorProyectoCostoIndirecto.ObtenerProyecto();
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
                Response.Redirect("GACC_CoordinadorInsertarProyectoCosto.aspx");
            }

            protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
            {
                List<GACC_ViewProyectoCosto> list = new List<GACC_ViewProyectoCosto>();
            GACC_ViewProyectoCosto pro = new GACC_ViewProyectoCosto();
                string op = gacc_ddlcriterio.SelectedValue;
                if (op != "0")
                {
                    switch (op)
                    {
                        case "N":
                            pro = GACC_ControladorProyectoCostoIndirecto.ObtenerCostoIxnombre(gacc_txtbuscar.Text);
                            if (pro != null)
                            {
                                list.Add(pro);
                                gacc_grv.DataSource = list;
                                gacc_grv.DataBind();
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se encontro el Proyecto')", true);
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
                    Response.Redirect("GACC_CoordinadorInsertarProyectoCosto.aspx?cod=" + codigo, true);
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                GACC_TblProyectoTblCostoIndirecto prod = new GACC_TblProyectoTblCostoIndirecto();
                    prod = GACC_ControladorProyectoCostoIndirecto.ObtenerProyectoxid(codigo);
                    if (prod != null)
                    {
                    GACC_ControladorProyectoCostoIndirecto.delete(prod);
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