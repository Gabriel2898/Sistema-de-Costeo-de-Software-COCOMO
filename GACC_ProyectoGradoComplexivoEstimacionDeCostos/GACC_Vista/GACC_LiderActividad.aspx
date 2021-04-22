<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_LiderActividad.Master" AutoEventWireup="true" CodeBehind="GACC_LiderActividad.aspx.cs" Inherits="GACC_Vista.GACC_LiderActividad1" %>
<asp:Content ID="gacc_cont1" ContentPlaceHolderID="gacc_cphhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="gacc_cph1" runat="server">
      <asp:Label ID="gacc_lblnombreusuario" runat="server"> </asp:Label>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="gacc_cph2" runat="server">
     <asp:LinkButton ID="gacc_lnkbtnsalir" runat="server" OnClick="gacc_lnkbtnsalir_Click" >  <i class="icon_key_alt"></i>LogOut</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="gacc_cph4" runat="server">    
     <asp:LinkButton ID="gacc_lnkperfil" runat="server" OnClick="gacc_lnkperfil_Click">  <i class="icon_profile"></i>Mi Perfil</asp:LinkButton>
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="gacc_cph3" runat="server">
    
      <asp:Label ID="gacc_lblcontenido" runat="server" Text="" > </asp:Label>
</asp:Content>
