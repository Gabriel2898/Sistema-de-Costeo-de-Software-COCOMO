<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_Index.Master" AutoEventWireup="true" CodeBehind="GACC_Index.aspx.cs" Inherits="GACC_Vista.GACC_Index1" %>
<asp:Content ID="gacc_cont1" ContentPlaceHolderID="gacc_cphhead" runat="server">
</asp:Content>
<asp:Content ID="gacc_cont2" ContentPlaceHolderID="gacc_cph1" runat="server">
        <asp:TextBox class="input100" ID="gacc_txtnombreusuario" runat="server" placeholder="Nombre usuario"></asp:TextBox>
</asp:Content>
<asp:Content ID="gacc_cont3" ContentPlaceHolderID="gacc_cph2" runat="server">
        <asp:TextBox class="input100" Id="gacc_txtpassword" runat="server" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
</asp:Content>
<asp:Content ID="gacc_cont4" ContentPlaceHolderID="gacc_cph3" runat="server">
     <asp:Button ID="gacc_btnlogin" runat="server" Text="Sing in " OnClick="gacc_btnlogin_Click1" class="login100-form-btn"/>
<asp:UpdatePanel runat="server" id="gacc_up" updatemode="Conditional">
            <ContentTemplate>
                
               
               <asp:Label ID="gacc_lblIntentos" runat="server" Text="Intentos:" Visible="False"></asp:Label>  <asp:Label ID="gacc_lblresultado" runat="server" Text="0" Visible="False"></asp:Label>
                 <asp:Label ID="gacc_lblmensaje" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>
