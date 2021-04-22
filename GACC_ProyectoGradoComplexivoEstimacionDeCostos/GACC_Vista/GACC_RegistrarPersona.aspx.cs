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
    public partial class GACC_RegistrarPersona1 : System.Web.UI.Page
    {
        private GACC_TblPersona usuarioInfo = new GACC_TblPersona();
        public GACC_ControladorCedulayRuc ced = new GACC_ControladorCedulayRuc();
        protected void Page_Load(object sender, EventArgs e)
        {
            gacc_txtcedula.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
            gacc_txtespecialidad.Attributes.Add("onkeypress", "javascript:return validar(event);");
            gacc_txtprimerapellido.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
            gacc_txtprimernombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
            gacc_txtsalario.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
            gacc_txtsegundoapellido.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
            gacc_txtsegundonombre.Attributes.Add("onkeypress", "javascript:return validarLetras(event);");
            gacc_txttelefono.Attributes.Add("onkeypress", "javascript:return validarNumeros(event);");
            if (!IsPostBack)
            {
                cargarEmpresa();
                cargarCargo();
            }
            gacc_ddlestado.Items.FindByValue("O").Enabled = false;
        }
        private void cargarEmpresa()
        {
            List<GACC_TblEmpresa> listaProveedor = new List<GACC_TblEmpresa>();
            listaProveedor = GACC_ControladorEmpresa.ObtenerEmpresaddls();
            listaProveedor.Insert(0, new GACC_TblEmpresa() { gacc_EmpNombre = "Seleccione Empresa" });
            gacc_ddlempresa.DataSource = listaProveedor;
            gacc_ddlempresa.DataTextField = "gacc_EmpNombre";
            gacc_ddlempresa.DataValueField = "gacc_EmpId";
            gacc_ddlempresa.DataBind();
        }
        private void cargarCargo()
        {
            List<GACC_TblCargo> listaProveedor = new List<GACC_TblCargo>();
            listaProveedor = GACC_ControladorCargo.ObtenerCargoRegistrarse();
            listaProveedor.Insert(0, new GACC_TblCargo() { gacc_CarNombre = "Seleccione Cargo" });
            gacc_ddlcargo.DataSource = listaProveedor;
            gacc_ddlcargo.DataTextField = "gacc_CarNombre";
            gacc_ddlcargo.DataValueField = "gacc_CarId";
            gacc_ddlcargo.DataBind();
        }

        protected void gacc_btnenviar_Click(object sender, EventArgs e)
        {

            usuarioInfo = new GACC_TblPersona();
            try
            {
                string contraseña;
                GACC_ControladorEncriptar b = new GACC_ControladorEncriptar();
                contraseña = b.EncriptarClave(gacc_txtcontraseña.Text);
                if (!GACC_ControladorCedulayRuc.CedulaCorrecta(gacc_txtcedula.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cédula Incorrecta')", true);
                }
                else
                {
                    bool existeusu = GACC_ControladorPersona.AutentificarUsuario(gacc_txtusuario.Text);
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
                        else if (existeusu)
                        {
                            GACC_TblPersona usuario = new GACC_TblPersona();
                            usuario = GACC_ControladorPersona.ObtenerEmpleadoxNombreUsusario(gacc_txtusuario.Text);
                            if (usuario != null)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El nombre de usuario ya existe !!! ')", true);
                            }
                        }
                        else if (existeced)
                        {
                            GACC_TblPersona usur = new GACC_TblPersona();
                            usur = GACC_ControladorPersona.ObtenerEmpleadoxnombres(gacc_txtprimernombre.Text, gacc_txtsegundonombre.Text, gacc_txtprimerapellido.Text, gacc_txtsegundoapellido.Text);
                            if (usur != null)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La persona ya existe !! ')", true);
                            }
                        }
                        else
                        {

                            usuarioInfo.gacc_PerUsuarioNombre = gacc_txtusuario.Text;
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
                             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos guardados !!!  ')", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos NO guardados   ')" , true);
            }
        }
        
    }
}

