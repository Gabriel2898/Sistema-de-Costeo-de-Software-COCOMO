<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_RegistrarEmpresa.Master" AutoEventWireup="true" CodeBehind="GACC_RegistrarEmpresa.aspx.cs" Inherits="GACC_Vista.GACC_RegistrarEmpresa1" %>
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
    <asp:TextBox class="input100" ID="gacc_txtruc" runat="server" MaxLength="13" placeholder="Ruc"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtruc" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="gacc_cph2" runat="server">
    <asp:TextBox class="input100" ID="gacc_txtnombre" runat="server" MaxLength="100" placeholder="Nombre de la empresa"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtnombre" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="gacc_cph3" runat="server">
    <asp:TextBox class="input100" ID="gacc_txtdireccion" runat="server"  placeholder="Direccion"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtdireccion" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="gacc_cph4" runat="server">
    <asp:TextBox class="input100" ID="gacc_txttelefono" runat="server" MaxLength="10" placeholder="Teléfono"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="gacc_txttelefono" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="gacc_cph5" runat="server">
     <asp:TextBox class="input100" ID="gacc_txtcorreo" runat="server" placeholder="Correo"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtcorreo" ForeColor="Red"></asp:RequiredFieldValidator>
                                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="gacc_txtcorreo" ErrorMessage="CORREO NO VALIDO" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="gacc_cph6" runat="server">
     <asp:DropDownList ID="gacc_ddlestado" runat="server"  class="input100" Visible="false">
        <asp:ListItem Text="Activo" Value="A"></asp:ListItem>
        <asp:ListItem Text="Inactivo" Value="I"></asp:ListItem>
    </asp:DropDownList>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="gacc_cph7" runat="server">
     <asp:Button ID="gacc_btnenviar" runat="server" Text="Enviar " OnClick="gacc_btnenviar_Click" class="login100-form-btn"/>
</asp:Content>


    