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
    public partial class GACC_LiderFaseDeDesarrolloInsertarPersona1 : System.Web.UI.Page
    {
        private GACC_TblPersona usuarioInfo = new GACC_TblPersona();
        public GACC_ControladorCedulayRuc ced = new GACC_ControladorCedulayRuc();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                gacc_txtcedula.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_txtespecialidad.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
                gacc_txtprimerapellido.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
                gacc_txtprimernombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
                gacc_txtsalario.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                gacc_txtsegundoapellido.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
                gacc_txtsegundonombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
                gacc_txttelefono.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
                Session.Timeout = 60;
                if (Session["LiderFaseDeDesarrollo"] != null)
                {
                    gacc_lblnombreusuario.Text = Session["LiderFaseDeDesarrollo"].ToString();
                }
                else
                {
                    Response.Redirect("GACC_Index.aspx");
                }


                if (Request["cod"] != null)
                {
                    string contraseña;
                    gacc_lnkeditar.Visible = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    usuarioInfo = GACC_ControladorPersona.ObtenerEmpleadoxid(codigo);
                    if (usuarioInfo != null)
                    {
                        gacc_hdfPersona.Value = usuarioInfo.gacc_PerDni.ToString();
                        gacc_txtnombreusuario.Text = usuarioInfo.gacc_PerUsuarioNombre.ToString();
                        GACC_ControladorEncriptar b = new GACC_ControladorEncriptar();
                        contraseña = b.DesencriptarMD5(usuarioInfo.gacc_PerPassword);
                        gacc_txtcontraseña.Attributes.Add("value", contraseña);
                        gacc_txtcontraseña.Text = contraseña.ToString();
                        gacc_txtcedula.Text = usuarioInfo.gacc_PerDni.ToString();
                        gacc_txtprimernombre.Text = usuarioInfo.gacc_PerPrimerNombre.ToString();
                        gacc_txtsegundonombre.Text = usuarioInfo.gacc_PerSegundoNombre.ToString();
                        gacc_txtprimerapellido.Text = usuarioInfo.gacc_PerPrimerApellido.ToString();
                        gacc_txtsegundoapellido.Text = usuarioInfo.gacc_PerSegundoApellido.ToString();
                        gacc_ddlgenero.SelectedValue = usuarioInfo.gacc_PerGenero.ToString();
                        gacc_ddlempresa.SelectedValue = usuarioInfo.gacc_CodEmpId.ToString();
                        gacc_ddlcargo.SelectedValue = usuarioInfo.gacc_CodCarId.ToString();
                        gacc_txtespecialidad.Text = usuarioInfo.gacc_PerEspecialidad.ToString();
                        gacc_txtexperiencia.Text = usuarioInfo.gacc_PerExperiencia.ToString();
                        gacc_txtsalario.Text = usuarioInfo.gacc_PerSalario.ToString();
                        gacc_txtdireccion.Text = usuarioInfo.gacc_PerDireccion.ToString();
                        gacc_txttelefono.Text = usuarioInfo.gacc_PerTelefono.ToString();
                        gacc_txtcorreo.Text = usuarioInfo.gacc_PerCorreo.ToString();
                        gacc_ddlestado.SelectedValue = usuarioInfo.gacc_PerEstado.ToString();
                    }
                }
                cargarEmpresa();
                cargarCargo();
            }
        }
        private void cargarEmpresa()
        {
            List<GACC_TblEmpresa> listaProveedor = new List<GACC_TblEmpresa>();
            listaProveedor = GACC_ControladorEmpresa.ObtenerEmpresa();
            listaProveedor.Insert(0, new GACC_TblEmpresa() { gacc_EmpNombre = "Nombre Empresa" });
            gacc_ddlempresa.DataSource = listaProveedor;
            gacc_ddlempresa.DataTextField = "gacc_EmpNombre";
            gacc_ddlempresa.DataValueField = "gacc_EmpId";
            gacc_ddlempresa.DataBind();
        }
        private void cargarCargo()
        {
            List<GACC_TblCargo> listaProveedor = new List<GACC_TblCargo>();
            listaProveedor = GACC_ControladorCargo.ObtenerCargo();
            listaProveedor.Insert(0, new GACC_TblCargo() { gacc_CarNombre = "Nombre Cargo" });
            gacc_ddlcargo.DataSource = listaProveedor;
            gacc_ddlcargo.DataTextField = "gacc_CarNombre";
            gacc_ddlcargo.DataValueField = "gacc_CarId";
            gacc_ddlcargo.DataBind();
        }

        private void Guardar()
        {
            usuarioInfo = new GACC_TblPersona();
            try
            {
                string contraseña = gacc_txtcontraseña.Text;
                GACC_ControladorEncriptar b = new GACC_ControladorEncriptar();
                b.EncriptarClave(contraseña);
                if (!GACC_ControladorCedulayRuc.CedulaCorrecta(gacc_txtcedula.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cédula Incorrecta')", true);
                }
                else
                {
                    bool existes = GACC_ControladorPersona.AutentificarEmpleadoxcedula(gacc_txtcedula.Text);
                    bool existeced = GACC_ControladorPersona.AutentificarEmpleadoxnombre(gacc_txtprimernombre.Text, gacc_txtsegundonombre.Text, gacc_txtprimerapellido.Text, gacc_txtsegundoapellido.Text);
                    {

                        if (existes)
                        {
                            GACC_TblPersona usur = new GACC_TblPersona();
                            usur = GACC_ControladorPersona.ObtenerEmpleadoxcedula(gacc_txtcedula.Text);
                            if (usur != null)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ya cédula y nombres de la persona ya existe ')", true);
                            }
                        }
                        else
                        {

                            usuarioInfo.gacc_PerUsuarioNombre = gacc_txtnombreusuario.Text;
                            usuarioInfo.gacc_PerPassword = contraseña;
                            usuarioInfo.gacc_PerDni = gacc_txtcedula.Text;
                            usuarioInfo.gacc_PerPrimerNombre = gacc_txtprimernombre.Text;
                            usuarioInfo.gacc_PerSegundoNombre = gacc_txtsegundonombre.Text;
                            usuarioInfo.gacc_PerPrimerApellido = gacc_txtprimerapellido.Text;
                            usuarioInfo.gacc_PerSegundoApellido = gacc_txtsegundoapellido.Text;
                            usuarioInfo.gacc_PerGenero = Convert.ToChar(gacc_ddlgenero.SelectedValue);
                            usuarioInfo.gacc_CodEmpId = Convert.ToInt32(gacc_ddlempresa.SelectedValue);
                            usuarioInfo.gacc_CodCarId = Convert.ToInt32(gacc_ddlcargo.SelectedValue);
                            usuarioInfo.gacc_PerEspecialidad = gacc_txtespecialidad.Text;
                            usuarioInfo.gacc_PerExperiencia = Convert.ToString(gacc_txtexperiencia.Text);
                            usuarioInfo.gacc_PerSalario = Convert.ToDecimal(gacc_txtsalario.Text);
                            usuarioInfo.gacc_PerDireccion = gacc_txtdireccion.Text;
                            usuarioInfo.gacc_PerTelefono = gacc_txttelefono.Text;
                            usuarioInfo.gacc_PerCorreo = gacc_txtcorreo.Text;
                            usuarioInfo.gacc_PerEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);

                            GACC_ControladorPersona.save(usuarioInfo);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados con exito  ')", true);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO guardados   ')" , true);
            }
        }

        private void Modificar(GACC_TblPersona usuarioInfo)
        {
            string contraseña;
            GACC_ControladorEncriptar b = new GACC_ControladorEncriptar();
            contraseña = b.EncriptarClave(gacc_txtcontraseña.Text);
            try
            {
                usuarioInfo.gacc_PerDni = gacc_txtcedula.Text;
                usuarioInfo.gacc_PerPrimerNombre = gacc_txtprimernombre.Text;
                usuarioInfo.gacc_PerSegundoNombre = gacc_txtsegundonombre.Text;
                usuarioInfo.gacc_PerPrimerApellido = gacc_txtprimerapellido.Text;
                usuarioInfo.gacc_PerSegundoApellido = gacc_txtsegundoapellido.Text;
                usuarioInfo.gacc_PerGenero = Convert.ToChar(gacc_ddlgenero.SelectedValue);
                usuarioInfo.gacc_PerEspecialidad = gacc_txtespecialidad.Text;
                usuarioInfo.gacc_PerExperiencia = Convert.ToString(gacc_txtexperiencia.Text);
                usuarioInfo.gacc_PerSalario = Convert.ToDecimal(gacc_txtsalario.Text);
                usuarioInfo.gacc_PerDireccion = gacc_txtdireccion.Text;
                usuarioInfo.gacc_PerTelefono = gacc_txttelefono.Text;
                usuarioInfo.gacc_PerCorreo = gacc_txtcorreo.Text;
                usuarioInfo.gacc_PerUsuarioNombre = gacc_txtnombreusuario.Text;
                usuarioInfo.gacc_PerPassword = contraseña;
                usuarioInfo.gacc_PerEstado = Convert.ToChar(gacc_ddlestado.SelectedValue);
                usuarioInfo.gacc_CodEmpId = Convert.ToInt32(gacc_ddlempresa.SelectedValue);
                usuarioInfo.gacc_CodCarId = Convert.ToInt32(gacc_ddlcargo.SelectedValue);
                GACC_ControladorPersona.modify(usuarioInfo);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos modificados  ')", true);
            }
            catch (Exception e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO modificados  ')" , true);
            }
        }
        private void GuardarDatos(int id)
        {
            if (id == 0)
            {
                Guardar();
            }
            else
            {
                usuarioInfo = GACC_ControladorPersona.ObtenerEmpleadoxid(id);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }


        protected void gacc_lnkbtnsalir_Click(object sender, EventArgs e)
        {
            {
                Session["LiderFaseDeDesarrollo"] = null;
                Response.Redirect("GACC_Index.aspx");
            }
        }




        protected void gacc_lnkeditar_Click(object sender, EventArgs e)
        {


            string hdfValor1 = gacc_hdfPersona.Value;
            string hdfValor = gacc_txtcedula.Text;
            if (hdfValor == gacc_txtcedula.Text)
            {
                GuardarDatos(int.Parse(Request["cod"]));
            }
            else if (hdfValor != gacc_txtcedula.Text)
            {
                var existe = GACC_ControladorPersona.AutentificarPersonaxcedulas(gacc_txtcedula.Text);
                {
                    if (existe != null)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La cedula ya tiene otra persona  ')", true);
                    }
                    else
                    {
                        GuardarDatos(int.Parse(Request["cod"]));
                    }
                }
            }

        }


        protected void gacc_lnkperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("GACC_LiderFaseDeDesarrolloListarUnicaPersona.aspx");
        }
    }
}