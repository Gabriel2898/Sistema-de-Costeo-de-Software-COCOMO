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
    public partial class GACC_LiderProyectoListarNombreProyecto1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                cargarNombreProyeccto();
            }
        }
        private void cargarNombreProyeccto()
        {
            List<GACC_ViewNombreProyectoEmpresaUsuario> listaproductos = new List<GACC_ViewNombreProyectoEmpresaUsuario>();
            listaproductos = GACC_ControladorNombreProyecto.ObtenerProyectoxusuario(gacc_lblnombreusuario.Text);
            if (listaproductos != null)
            {
                gacc_grv.DataSource = listaproductos;
                gacc_grv.DataBind();
            }
        }



        protected void gacc_btnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["LiderProyecto"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }

        protected void gacc_lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoInsertarNombreProyecto.aspx");
        }

        protected void gacc_lnkbuscar_Click(object sender, EventArgs e)
        {
            List<GACC_ViewNombreProyectoEmpresa> list = new List<GACC_ViewNombreProyectoEmpresa>();
            List<GACC_ViewNombreProyectoEmpresa> lists = new List<GACC_ViewNombreProyectoEmpresa>();
            GACC_ViewNombreProyectoEmpresa pro = new GACC_ViewNombreProyectoEmpresa();
            GACC_ViewNombreProyectoEmpresa pros = new GACC_ViewNombreProyectoEmpresa();
            string op = gacc_ddlcriterio.SelectedValue;
            if (op != "0")
            {
                switch (op)
                {
                    case "N":
                        pro = GACC_ControladorNombreProyecto.ObtenerProyectoxempresa(gacc_txtbuscar.Text);
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
                Response.Redirect("GACC_LiderProyectoInsertarNombreProyecto.aspx?cod=" + codigo, true);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                GACC_TblNombreProyecto prod = new GACC_TblNombreProyecto();
                prod = GACC_ControladorNombreProyecto.ObtenerProyectoxid(codigo);
                if (prod != null)
                {
                    GACC_ControladorNombreProyecto.delete(prod);
                    cargarNombreProyeccto();
                }

            }
        }

        protected void gacc_grv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderProyectoListarUnicaPersona.aspx");
        }
    }
}