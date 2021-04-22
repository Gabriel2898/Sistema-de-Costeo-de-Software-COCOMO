using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using GACC_Controlador;
using GACC_Modelo;
using GACC_Vista;
using System.Web.UI.WebControls;


namespace GACC_Vista
{
    public partial class GACC_Index1 : System.Web.UI.Page
    {
        int gacc_contador = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                Session.Timeout = 20;
                Session["con"] = Session["ContAntiguo"];
            }
        }


        public void gacc_ingresar()
        {
            string contraseña;
            GACC_ControladorEncriptar b = new GACC_ControladorEncriptar();
            contraseña = b.EncriptarClave(gacc_txtpassword.Text);
            if (string.IsNullOrEmpty(gacc_txtnombreusuario.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Falta Usuario ')", true);

                return;
            }
            if (string.IsNullOrEmpty(gacc_txtpassword.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Falta Contraseña ')", true);

                return;
            }
            gacc_lblresultado.Text = (gacc_contador + (Convert.ToInt32(Session["con"]))).ToString();
            Session["ContAntiguo"] = gacc_lblresultado.Text.ToString();
            if (Convert.ToInt32(gacc_lblresultado.Text) > 2)
            {
                gacc_btnlogin.Enabled = false;
            }
            gacc_lblmensaje.Visible = false;
            bool user = GACC_ControladorLogin.AutentificarPersona(gacc_txtnombreusuario.Text);
            bool existe = GACC_ControladorLogin.AutenticarCredencialPersona(gacc_txtnombreusuario.Text,contraseña);
            {
                if (!user)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El Usuario no existe ')", true);

                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuario o contraseña incorrecto ')", true);

                    gacc_contador = +1;
                    gacc_lblresultado.Text = (gacc_contador + (Convert.ToInt32(Session["con"]))).ToString();
                    Session["ContAntiguo"] = gacc_lblresultado.Text.ToString();
                    if (Convert.ToInt32(gacc_lblresultado.Text) > 2)
                    {
                        gacc_btnlogin.Attributes["disabled"] = "disabled";
                        Session["con"] = null;
                        Session["ContAntiguo"] = null;
                    }

                    if (existe)
                    {
                        int contandor = int.Parse(gacc_lblresultado.Text);
                        GACC_TblPersona usuario = new GACC_TblPersona();
                        usuario = GACC_ControladorLogin.AutenticarLogin(gacc_txtnombreusuario.Text, contraseña);
                        int tiposuario = Convert.ToInt32(usuario.gacc_CodCarId);

                        if (tiposuario == 1)
                        {
                            Session["CoordinadorProyecto"] = gacc_txtnombreusuario.Text;
                            Response.Redirect("GACC_CoordinadorProyecto.aspx");
                        }
                        else if(tiposuario == 2)
                        {
                            
                                Session["LiderProyecto"] = gacc_txtnombreusuario.Text;
                                Response.Redirect("GACC_LiderProyecto.aspx");
                            
                        }
                        else if (tiposuario == 3)
                        {

                            Session["LiderFaseDeDesarrollo"] = gacc_txtnombreusuario.Text;
                            Response.Redirect("GACC_LiderFaseDeDesarrollo.aspx");

                        }
                        else if (tiposuario == 4)
                        {

                            Session["LiderActividad"] = gacc_txtnombreusuario.Text;
                            Response.Redirect("GACC_LiderActividad.aspx");

                        }
                        else if (tiposuario == 5)
                        {

                            Session["LiderDeDesarrollo"] = gacc_txtnombreusuario.Text;
                            Response.Redirect("GACC_LiderDeDesarrollo.aspx");

                        }
                    }

                }

            }
        }

            protected void gacc_btnlogin_Click1(object sender, EventArgs e)
            {
                int gacc_contandor = int.Parse(gacc_lblresultado.Text);
                gacc_ingresar();
            }
        }

    }
