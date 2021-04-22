﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_CoordinadorInsertarMetodologia.Master" AutoEventWireup="true" CodeBehind="GACC_CoordinadorInsertarMetodologia.aspx.cs" Inherits="GACC_Vista.GACC_CoordinadorInsertarMetodologia1" %>

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
      <asp:HiddenField runat="server" ID="gacc_hdfmetodologia" />
      <asp:HiddenField runat="server" ID="gacc_hdfnombreproyecto" />
      <asp:HiddenField runat="server" ID="gacc_hdfestado" />
     <asp:ScriptManager ID="gacc_scm1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="gacc_up1" runat="server">
    <ContentTemplate>
             <div>

           
            <table style="width:100%" class="table table-striped table-advance table-hover">

                <tr>
                    <td>
                        <asp:LinkButton ID="gacc_lnknuevo" runat="server" OnClick="gacc_lnknuevo_Click" class="btn btn-primary btn-sm" >Nuevo</asp:LinkButton>
                    
                        <asp:LinkButton ID="gacc_lnkguardar" runat="server" OnClick="gacc_lnkguardar_Click" class="btn btn-success btn-sm" >Guardar </asp:LinkButton>
                    
                        <asp:LinkButton ID="gacc_lnkeditar" runat="server" OnClick="gacc_lnkeditar_Click" Visible="false" class="btn btn-danger btn-sm" >Editar</asp:LinkButton>
                        <asp:LinkButton ID="gacc_lnkfasededesarrollo" runat="server" OnClick="gacc_lnkfasededesarrollo_Click"  class="btn btn-danger btn-sm" ><i class="fa fa-plus" aria-hidden="true">Agregar Fase de Desarrollo</i></asp:LinkButton>
                        <asp:LinkButton ID="gacc_lnkregresar" runat="server" OnClick="gacc_lnkregresar_Click" class="btn btn-warning btn-sm" >Regresar </asp:LinkButton>
                         <asp:LinkButton ID="gacc_lnklimpiar" runat="server" OnClick="gacc_lnklimpiar_Click" class="btn btn-default btn-sm" >Limpiar </asp:LinkButton>
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
                                                <label class="control-label col-lg-2">Nombre de empresa</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddlempresa" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="gacc_ddlempresa" runat="server" class="form-control" AutoPostBack="true"  OnSelectedIndexChanged="gacc_ddlempresa_SelectedIndexChanged">
                                                </asp:DropDownList> </div>
                                            </td>
                                        </tr>
                                         
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Nombre del proyecto </label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddlnombreproyecto" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="gacc_ddlnombreproyecto" runat="server" class="form-control" AutoPostBack="true"  >
                                                </asp:DropDownList> </div>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Cargo Necesario</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddlcargo" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="gacc_ddlcargo" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="gacc_ddlcargo_SelectedIndexChanged">
                                                </asp:DropDownList> </div>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Nombre</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtnombre"   runat="server" class="form-control" ></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtnombre" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                       <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Delegado </label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddlencargado" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="gacc_ddlencargado" runat="server" class="form-control" AutoPostBack="true">
                                                </asp:DropDownList> </div>
                                            </td>
                                        </tr>
                                        
                                          <tr>
                                            <td>
                                                <label class="control-label col-lg-2" Visible="false" runat="server" ID="lblestadop">Estado persona </label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddlestadopersona" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="gacc_ddlestadopersona" runat="server" class="form-control" Visible="false">
                                                    <asp:ListItem Text="Disponible" Value="D"></asp:ListItem>
                                                    <asp:ListItem Text="Ocupado" Value="O"></asp:ListItem>
                                                </asp:DropDownList> </div>
                                            </td>
                                        </tr>
                                         
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2" Visible="false" runat="server" ID="lblestado">Estado </label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Visible="false" ErrorMessage="*" ControlToValidate="gacc_ddlestado" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="gacc_ddlestado" runat="server" class="form-control">
                                                    <asp:ListItem Text="En Proceso" Value="E"></asp:ListItem>
                                                    <asp:ListItem Text="Finalizado" Value="F"></asp:ListItem>
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


