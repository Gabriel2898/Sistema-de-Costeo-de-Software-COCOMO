<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_RegistrarPersona.Master" AutoEventWireup="true" CodeBehind="GACC_RegistrarPersona.aspx.cs" Inherits="GACC_Vista.GACC_RegistrarPersona1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="gacc_cphhead" runat="server">
     <script>
    
    function validar(e){
		 key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
    especiales = [8, 37, 39, 46, 44,];

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
  
     function validarLetras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
    especiales = [8, 37, 39, 46, 44,];

    tecla_especial = false
    for(var i in especiales) {
        if(key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }
         key = e.keyCode ? e.keyCode : e.which;
		if (key == 32) {return false;}
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
         <asp:TextBox class="input100" ID="gacc_txtcedula" runat="server" MaxLength="10" placeholder="Cedula" ></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtcedula" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="gacc_cph2" runat="server">
         <asp:TextBox class="input100" ID="gacc_txtprimernombre" runat="server" placeholder="Primer Nombre"></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtprimernombre" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "gacc_txtprimernombre" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{3,}$" runat="server" ErrorMessage="Minimo 3 Caracteres" ForeColor="Red"></asp:RegularExpressionValidator>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="gacc_cph3" runat="server">
         <asp:TextBox class="input100" ID="gacc_txtsegundonombre" runat="server" placeholder="Segundo Nombre"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtsegundonombre" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "gacc_txtsegundonombre" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{3,}$" runat="server" ErrorMessage="Minimo 3 Caracteres" ForeColor="Red"></asp:RegularExpressionValidator>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="gacc_cph4" runat="server">
         <asp:TextBox class="input100" ID="gacc_txtprimerapellido" runat="server" placeholder="Primer Apellido"></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtprimerapellido" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "gacc_txtprimerapellido" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{3,}$" runat="server" ErrorMessage="Minimo 3 Caracteres" ForeColor="Red"></asp:RegularExpressionValidator>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="gacc_cph5" runat="server">
         <asp:TextBox class="input100" ID="gacc_txtsegundoapellido" runat="server" placeholder="Segundo Apellido"></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtsegundoapellido" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "gacc_txtsegundoapellido" ID="RegularExpressionValidator4" ValidationExpression = "^[\s\S]{3,}$" runat="server" ErrorMessage="Minimo 3 Caracteres" ForeColor="Red"></asp:RegularExpressionValidator>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="gacc_cph6" runat="server" >
    <asp:DropDownList ID="gacc_ddlgenero" runat="server"  class="input100">
        <asp:ListItem Text="SELECCIONE GÉNERO"></asp:ListItem>
        <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
        <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
        <asp:ListItem Text="Transgénero" Value="T"></asp:ListItem>
    </asp:DropDownList>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="gacc_cph7" runat="server">
         <asp:TextBox class="input100" ID="gacc_txtespecialidad" runat="server" placeholder="Especialidad"></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtespecialidad" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="gacc_cph8" runat="server">
         <asp:TextBox class="input100" ID="gacc_txtexperiencia" runat="server" placeholder="Experiencia"></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtexperiencia" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="gacc_cph9" runat="server">
         <asp:TextBox class="input100" ID="gacc_txtsalario" runat="server" placeholder="Salario"></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtsalario" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="gacc_cph10" runat="server">
         <asp:TextBox class="input100" ID="gacc_txtdireccion" runat="server" placeholder="Direccion"></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtdireccion" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content12" ContentPlaceHolderID="gacc_cph11" runat="server">
         <asp:TextBox class="input100" ID="gacc_txttelefono" runat="server" placeholder="Teléfono" MaxLength="10"></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="gacc_txttelefono" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content13" ContentPlaceHolderID="gacc_cph12" runat="server">
         <asp:TextBox class="input100" ID="gacc_txtcorreo" runat="server" placeholder="Correo Electrónico"></asp:TextBox>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="gacc_txtcorreo" ErrorMessage="CORREO NO VALIDO" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtcorreo" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content14" ContentPlaceHolderID="gacc_cph13" runat="server">
         <asp:TextBox class="input100" ID="gacc_txtusuario" runat="server" placeholder="Nombre usuario" MaxLength="10"></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtusuario" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content15" ContentPlaceHolderID="gacc_cph14" runat="server">
    <span class="btn-show-pass">
							<i class="fa fa-eye"></i>
						</span>
         <asp:TextBox class="input100" ID="gacc_txtcontraseña" runat="server" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtcontraseña" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
<asp:Content ID="Content17" ContentPlaceHolderID="gacc_cph16" runat="server">
         <asp:DropDownList ID="gacc_ddlcargo" runat="server" value="Cargo de la persona" class="input100">
    </asp:DropDownList>
</asp:Content>
<asp:Content ID="Content18" ContentPlaceHolderID="gacc_cph17" runat="server">
         <asp:DropDownList ID="gacc_ddlempresa" runat="server" value="seleccione empresa que trabaja la persona" class="input100">
    </asp:DropDownList>
</asp:Content>
<asp:Content ID="Content16" ContentPlaceHolderID="gacc_cph15" runat="server">
          <asp:DropDownList ID="gacc_ddlestado" runat="server"  class="input100" Visible="false">
        <asp:ListItem Text="Disponible" Value="D"></asp:ListItem>
        <asp:ListItem Text="Ocupado" Value="O"></asp:ListItem>
    </asp:DropDownList>
</asp:Content>
<asp:Content ID="Content19" ContentPlaceHolderID="gacc_cph18" runat="server">
    <asp:Button ID="gacc_btnenviar" runat="server" Text="Enviar " OnClick="gacc_btnenviar_Click" class="login100-form-btn"/>
</asp:Content>