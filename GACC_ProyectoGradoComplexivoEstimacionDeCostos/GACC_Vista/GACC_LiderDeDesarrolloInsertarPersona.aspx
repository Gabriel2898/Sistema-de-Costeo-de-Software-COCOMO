<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_LiderDeDesarrolloInsertarPersona.Master" AutoEventWireup="true" CodeBehind="GACC_LiderDeDesarrolloInsertarPersona.aspx.cs" Inherits="GACC_Vista.GACC_LiderDeDesarrolloInsertarPersona1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="gacc_cphhead" runat="server">
     <script>
     function validarLetras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
    especiales = [8, 37, 39, 46, 44];

    tecla_especial = false
    for(var i in especiales) {
        if(key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if(letras.indexOf(tecla) == -1 && !tecla_especial)
        return false;
         }
          function validarNumeros(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = "0123456789";
    especiales = [8, 37, 39, 46, 44];

    tecla_especial = false
    for(var i in especiales) {
        if(key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if(letras.indexOf(tecla) == -1 && !tecla_especial)
        return false;
}

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="gacc_cph1" runat="server">
           <asp:Label ID="gacc_lblnombreusuario" runat="server" > </asp:Label></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="gacc_cph2" runat="server">
            <asp:LinkButton ID="gacc_lnkbtnsalir" runat="server" OnClick="gacc_lnkbtnsalir_Click" >  <i class="icon_key_alt"></i>LogOut</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="gacc_cph4" runat="server">    
     <asp:LinkButton ID="gacc_lnkperfil" runat="server" OnClick="gacc_lnkperfil_Click">  <i class="icon_profile"></i>Mi Perfil</asp:LinkButton>
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="gacc_cph3" runat="server">
     <asp:ScriptManager ID="gacc_scm1" runat="server"></asp:ScriptManager>
    <asp:HiddenField runat="server" ID="gacc_hdfPersona" />
    <asp:HiddenField runat="server" ID="gacc_hdfPersona1" />
        <asp:UpdatePanel ID="gacc_up1" runat="server">
    <ContentTemplate>
             <div>

           
            <table style="width:100%" class="table table-striped table-advance table-hover">

                <tr>
                    <td>
                                              
                        <asp:LinkButton ID="gacc_lnkeditar" runat="server" OnClick="gacc_lnkeditar_Click" Visible="false" class="btn btn-danger btn-sm" >Editar</asp:LinkButton>
                       
                    </td>
                </tr>
                 <tr>
                    <td colspan="2">
                        <br />
                        <table style="width:100%" class="table table-striped table-advance table-hover">
                            <tr>
                                <td style="align-content:center">
                                    <table class="table table-striped table-advance table-hover">
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Usuario Nombre</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtnombreusuario"   runat="server" class="form-control" MaxLength="10"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtnombreusuario" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Contraseña</label>
                                            </td>
                                           <td colspan="2">
                                                <div class="col-lg-10">
                                                     <span class="btn-show-pass"><i class="fa fa-eye"></i>
						</span>
						                  <asp:TextBox ID="gacc_txtcontraseña"   runat="server" class="form-control" MaxLength="50" TextMode="Password" > </asp:TextBox> 
                                           
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtcontraseña" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Cédula</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtcedula"   runat="server" class="form-control" MaxLength="10" ></asp:TextBox> 
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtcedula" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Primer Nombre</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtprimernombre"   runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtprimernombre" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Segundo Nombre</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtsegundonombre"   runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtsegundonombre" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Primer Apellido</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtprimerapellido"   runat="server" class="form-control" MaxLength="50" ></asp:TextBox> 
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtprimerapellido" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Segundo Apellido</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtsegundoapellido"   runat="server" class="form-control" MaxLength="50" ></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtsegundoapellido" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Género</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:DropDownList ID="gacc_ddlgenero" runat="server" class="form-control"  >
                                                            <asp:ListItem Text="SELECCIONE GÉNERO"></asp:ListItem>
                                                            <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                                                            <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                                                            <asp:ListItem Text="Transgénero" Value="T"></asp:ListItem>
                                                        </asp:DropDownList> </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Empresa</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:DropDownList ID="gacc_ddlempresa" runat="server" class="form-control" >
                                                        </asp:DropDownList> </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Cargo</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:DropDownList ID="gacc_ddlcargo" runat="server" class="form-control" >
                                                        </asp:DropDownList> </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Especialidad</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtespecialidad"   runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtespecialidad" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Experiencia</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                    <asp:TextBox ID="gacc_txtexperiencia" runat="server" class="form-control"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtexperiencia" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Salario</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtsalario"   runat="server" class="form-control"  ></asp:TextBox> 
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtsalario" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                              
                                        </tr>
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Dirección</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtdireccion"   runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtdireccion" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Teléfono</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txttelefono"   runat="server" class="form-control" MaxLength="10"></asp:TextBox> 
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="gacc_txttelefono" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Correo</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtcorreo"   runat="server" class="form-control" MaxLength="200"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtcorreo" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="gacc_txtcorreo" ErrorMessage="CORREO NO VALIDO" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                                                </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Estado </label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                               
                                                <asp:DropDownList ID="gacc_ddlestado" runat="server" class="form-control">
                                                    <asp:ListItem Text="SELECCIONE ESTADO " ></asp:ListItem>
                                                    <asp:ListItem Text="Disponible" Value="D"></asp:ListItem>
                                                    <asp:ListItem Text="Ocupado" Value="O"></asp:ListItem>
                                                </asp:DropDownList> </div>
                                            </td>
                                        </tr>
                                         
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </ContentTemplate>

    </asp:UpdatePanel>
            

</asp:Content>
