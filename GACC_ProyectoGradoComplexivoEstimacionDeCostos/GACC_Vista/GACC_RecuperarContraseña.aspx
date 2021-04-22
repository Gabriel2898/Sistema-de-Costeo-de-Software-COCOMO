<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_RecuperarContraseña.Master" AutoEventWireup="true" CodeBehind="GACC_RecuperarContraseña.aspx.cs" Inherits="GACC_Vista.GACC_RecuperarContraseña1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="gacc_cphhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="gacc_cph1" runat="server">
    <asp:Label ID="gacc_lblmensaje" runat="server" Text="Porfavor ingresa tu correo electronico !!!"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="gacc_cph2" runat="server">
     <asp:TextBox class="input100" ID="gacc_txtcorreo" runat="server" placeholder="Correo de usuario"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtcorreo" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="gacc_txtcorreo" ErrorMessage="CORREO NO VALIDO" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="gacc_cph3" runat="server">
    <asp:Button ID="gacc_btnenviar" runat="server" Text="Enviar " OnClick="gacc_btnenviar_Click" class="login100-form-btn"/>
</asp:Content>