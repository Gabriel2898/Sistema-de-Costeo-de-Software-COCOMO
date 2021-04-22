    <%@ Page Title="" Language="C#" MasterPageFile="~/GACC_CoordinadorLineasCodigo.Master" AutoEventWireup="true" CodeBehind="GACC_CoordinadorLineasCodigo.aspx.cs" Inherits="GACC_Vista.GACC_CoordinadorLineasCodigo1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="gacc_cphhead" runat="server">
      <link href="Plantillas/administrador/css/wizard.css" rel="stylesheet">
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
    <asp:HiddenField runat="server" ID="gacc_hdfNombreproyecto1" />
     <asp:HiddenField runat="server" ID="gacc_hdfNombreproyecto" />
     <asp:UpdatePanel ID="gacc_up1" runat="server">
    <ContentTemplate>
             <div>

           
            <table style="width:100%" class="table table-striped table-advance table-hover">

                <tr>
                    <td>
                        <asp:LinkButton ID="gacc_lnkGuardar" runat="server" OnClick="gacc_lnkGuardar_Click" class="btn btn-primary btn-sm" >Guardar</asp:LinkButton>                        
                        <asp:LinkButton ID="gacc_lnkmetodologia" runat="server" OnClick="gacc_lnkmetodologia_Click"  class="btn btn-danger btn-sm" ><i class="fa fa-plus" aria-hidden="true">Agregar Metodologia</i></asp:LinkButton>
                    </td>
                </tr>
                 <tr>
                    <td colspan="2">
                        <br />
                        <table style="width:100%" class="table table-striped table-advance table-hover">
                            <tr>
                                <td style="align-content:center">
                                    <table class="table table-striped table-advance table-hover" style="width:100%">

                                        <asp:Wizard ID="Wizard1" runat="server"  ActiveStepIndex="0" class="table table-striped table-advance table-hover" OnFinishButtonClick="Wizard1_FinishButtonClick" DisplaySideBar="false" OnPreRender="Wizard1_PreRender"><NavigationButtonStyle  BorderColor="Blue" />
                                            <WizardSteps>
                                                <asp:WizardStep ID="WizardStep1" runat="server" Title=" PFNA">
<table class="table table-striped table-advance table-hover" style="width:100%" >
                                                       <tr>
             <td><center><b>Parametros Significativos</b></center></td>
             <td><center><b>Complejidad Baja </b></center></td>
             <td><center><b>Complejidad Media</b></center></td>
             <td><center><b>Camplejidad Alta</b></center></td>
             <td><center><b>Total Pametro</b></center></td>
          
         </tr>
         <tr>
             <td><center><b>Entradas</b></center></td>
             <td><center><asp:TextBox ID="gacc_entrada1"   runat="server" class="form-control" Text=""   MaxLength="2"></asp:TextBox><b>*3</b></center><asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                  
             <td><center><asp:TextBox ID="gacc_entrada2"   runat="server" class="form-control" Text="" MaxLength="2"></asp:TextBox><b>*4</b></center> <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada2" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                 
             <td><center><asp:TextBox ID="gacc_entrada3"   runat="server" class="form-control" Text="" MaxLength="2"></asp:TextBox><b>*6</b></center> <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada3" ForeColor="Red"></asp:RequiredFieldValidator></td>
             <td><center><asp:TextBox ID="gacc_entrada4"   runat="server" class="form-control" Text="0" ></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada4" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                  
         </tr>
         <tr>
             <td><center><b>Salidas</b></center></td>
             <td><center><asp:TextBox ID="gacc_entrada5"  runat="server" class="form-control"  MaxLength="2"></asp:TextBox><b>*4</b></center>                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada5" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
             <td><center><asp:TextBox ID="gacc_entrada6"  runat="server" class="form-control"  MaxLength="2"></asp:TextBox><b>*5</b></center>                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada6" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
             <td><center><asp:TextBox ID="gacc_entrada7"  runat="server" class="form-control"  MaxLength="2"></asp:TextBox><b>*7</b></center>                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada7" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
             <td><center><asp:TextBox ID="gacc_entrada8"  runat="server" class="form-control" Text="0"  ></asp:TextBox></center>                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada8" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
            
         </tr>
         <tr>
            <td><center><b>Ficheros Internos Lógicos</b></center></td>
             <td><center><asp:TextBox ID="gacc_entrada9"  runat="server" class="form-control"  MaxLength="2"></asp:TextBox><b>*7</b></center></td>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada9" ForeColor="Red"></asp:RequiredFieldValidator>
             <td><center><asp:TextBox ID="gacc_entrada10"  runat="server" class="form-control"  MaxLength="2"></asp:TextBox><b>*10</b></center></td>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada10" ForeColor="Red"></asp:RequiredFieldValidator>
             <td><center><asp:TextBox ID="gacc_entrada11"  runat="server" class="form-control"  MaxLength="2"></asp:TextBox><b>*15</b></center></td>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada11" ForeColor="Red"></asp:RequiredFieldValidator>
             <td><center><asp:TextBox ID="gacc_entrada12"  runat="server" class="form-control" Text="0" ></asp:TextBox></center>             </td>
            
         </tr>
         <tr>
            <td><center><b>Ficheros de Interfaz Externos</b></center></td>
             <td><center><asp:TextBox ID="gacc_entrada13"  runat="server" class="form-control" MaxLength="2" ></asp:TextBox><b>*5</b></center>                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada13" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
             <td><center><asp:TextBox ID="gacc_entrada14"  runat="server" class="form-control" MaxLength="2" ></asp:TextBox><b>*7</b></center>                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada14" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
             <td><center><asp:TextBox ID="gacc_entrada15"  runat="server" class="form-control" MaxLength="2" ></asp:TextBox><b>*10</b></center>                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada15" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
             <td><center><asp:TextBox ID="gacc_entrada16"  runat="server" class="form-control" Text="0" ></asp:TextBox></center></td> 
            
         </tr>
         <tr>
             <td><center><b>Consultas Externas</b></center></td>
             <td><center><asp:TextBox ID="gacc_entrada17"  runat="server" class="form-control"  MaxLength="2"></asp:TextBox><b>*3</b></center>                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada17" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
             <td><center><asp:TextBox ID="gacc_entrada18"  runat="server" class="form-control"  MaxLength="2"></asp:TextBox><b>*4</b></center>                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada18" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
             <td><center><asp:TextBox ID="gacc_entrada19"  runat="server" class="form-control" MaxLength="2" ></asp:TextBox><b>*6</b></center>                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada19" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
             <td><center><asp:TextBox ID="gacc_entrada20"  runat="server" class="form-control" Text="0" ></asp:TextBox></center> </td>
            
         </tr>
         <tr>
            <td><center><b>Total Puntos de Función no ajustados </b></center></td>
             <td colspan="4"><center><asp:TextBox ID="gacc_entrada21"  runat="server" class="form-control" Text="?"  ></asp:TextBox></center>   
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ErrorMessage="*" ControlToValidate="gacc_entrada21" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
         </tr>
        <tr>
               <td colspan="5">
                   <center><asp:LinkButton ID="gacc_lnktotalPFNA" runat="server" OnClick="gacc_lnktotalPFNA_Click" class="btn btn-default btn-sm">Calcular</asp:LinkButton></center>
                   
                         
              </td>
          </tr>
         
            </table>
            </asp:WizardStep>
                                                <asp:WizardStep ID="WizardStep2" runat="server" Title=" PF">
                                                     <table class="table table-striped table-advance table-hover" style="width:100%" >
                                                         <tr>
                                                             <td colspan="2"> <label runat="server"><b>Valores: 0=Sin Influencia, 
                                                                 1=Accidental,
                                                                 2=Moderado,  
                                                                 3=Medio,
                                                                 4=Significativo,
                                                                 5=Esencial</b> </label></td>
                                                         </tr>
                                                       <tr>
                                                           
             <td><center><b>Factor de Complejidad (FC)</b></center></td>
             <td><center><b>Valores entre 0-5 </b></center></td>
          
         </tr>
         <tr>
             <td><center><b>Comunicacion de Datos</b></center></td>
             <td><center><asp:TextBox ID="gacc_fc1"   runat="server" class="form-control"  Text="" MaxLength="1"></asp:TextBox></center> <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc1" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc1"></asp:RangeValidator> 
</td>

            
         </tr>
         <tr>
             <td><center><b>Rendimiento</b></center></td>
              <td><center><asp:TextBox ID="gacc_fc2"   runat="server" class="form-control" Text="" MaxLength="1"></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc2" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc2"></asp:RangeValidator></td></tr>
                                                         <tr>
                                                              <td><center><b>Frecuencia de Transacciones</b></center></td>
             <td><center><asp:TextBox ID="gacc_fc3"   runat="server" class="form-control" Text="" MaxLength="1"></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc3" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc3"></asp:RangeValidator></td>
                               </tr>
         
         <tr>
            <td><center><b>Requisitos de Manejo del Usuario Final</b></center></td>
             <td><center><asp:TextBox ID="gacc_fc4"   runat="server" class="form-control" Text="" MaxLength="1"></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc4" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc4"></asp:RangeValidator></td>
                                 
            
         </tr>
         <tr>
             <td><center><b>Procesos Complejos</b></center></td>
             <td><center><asp:TextBox ID="gacc_fc5"   runat="server" class="form-control" Text="" MaxLength="1"></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc5" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc5"></asp:RangeValidator></td>
                                   
         </tr>
         <tr>
            <td><center><b>Facilidad de Mantenimiento </b></center></td>
             <td><center><asp:TextBox ID="gacc_fc6"   runat="server" class="form-control" Text="" MaxLength="1"></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc6" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator6" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc6"></asp:RangeValidator></td>
                                    
         </tr>
        <tr>
            <td><center><b>Instalación en Multiples Lugares </b></center></td>
             <td><center><asp:TextBox ID="gacc_fc7"   runat="server" class="form-control" Text="" MaxLength="1"></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc7" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator7" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc7"></asp:RangeValidator></td>
                                  
         </tr>
        <tr>
            <td><center><b>Funciones Distribuidas </b></center></td>
             <td><center><asp:TextBox ID="gacc_fc8"   runat="server" class="form-control" Text="" MaxLength="1" ></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc8" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator8" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc8"></asp:RangeValidator></td>

         </tr>
        <tr>
            <td><center><b>Gran carga de Trabajo  </b></center></td>
             <td><center><asp:TextBox ID="gacc_fc9"   runat="server" class="form-control" Text="" MaxLength="1" ></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc9" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator9" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc9"></asp:RangeValidator></td>

         </tr>
          <tr>
            <td><center><b>Entrada On-Line de Datos  </b></center></td>
             <td><center><asp:TextBox ID="gacc_fc10"   runat="server" class="form-control" Text="" MaxLength="1"></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc10" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator10" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc10"></asp:RangeValidator></td>

         </tr>
           <tr>
            <td><center><b>Actualizaciones On-Line </b></center></td>
             <td><center><asp:TextBox ID="gacc_fc11"   runat="server" class="form-control" Text="" MaxLength="1"></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc11" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator11" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc11"></asp:RangeValidator></td>

         </tr>
        <tr>
            <td><center><b>Utilización con otros Sistemas  </b></center></td>
             <td><center><asp:TextBox ID="gacc_fc12"   runat="server" class="form-control" Text="" MaxLength="1"></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc12" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator12" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc12"></asp:RangeValidator></td>

         </tr>
        <tr>
            <td><center><b>Facilidad de Operación </b></center></td>
             <td><center><asp:TextBox ID="gacc_fc13"   runat="server" class="form-control" Text="" MaxLength="1"></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc13" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator13" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc13"></asp:RangeValidator></td>
         </tr>
         <tr>
            <td><center><b>Facilidad de Cambio </b></center></td>
             <td><center><asp:TextBox ID="gacc_fc14"   runat="server" class="form-control" Text="" MaxLength="1"></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ErrorMessage="*" ControlToValidate="gacc_fc14" ForeColor="Red" ></asp:RequiredFieldValidator>
                 <asp:RangeValidator ID="RangeValidator14" runat="server" ErrorMessage="Debe ser entre 0 y 5" ForeColor="Red" MinimumValue="0" MaximumValue="5" ControlToValidate="gacc_fc14"></asp:RangeValidator></td>

         </tr>
         <tr>
            <td><center><b>Total </b></center></td>
             <td><center><asp:TextBox ID="gacc_total"   runat="server" class="form-control" Text="?" ></asp:TextBox></center><asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ErrorMessage="*" ControlToValidate="gacc_total" ForeColor="Red"></asp:RequiredFieldValidator>
</td>

         </tr>                                              
         <tr>
               <td colspan="5">
                     <center> <asp:LinkButton ID="gacc_lnktotalFA" runat="server" OnClick="gacc_lnktotalFA_Click" class="btn btn-default btn-sm">Calcular</asp:LinkButton></center>
              </td>
          </tr>
         </table>
                                                </asp:WizardStep>
                                           
                                                <asp:WizardStep ID="WizardStep3" runat="server" Title="Lineas de Códigó">
                                                     
                                                     <table class="table table-striped table-advance table-hover" style="width:100%" >
                                                         
          <tr>
              <td><label class="control-label col-lg-2">Factor Ajuste</label></td>
              
             <td><center><asp:TextBox ID="gacc_factorajuste"   runat="server" class="form-control" Text="?" ></asp:TextBox></center></td>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ErrorMessage="*" ControlToValidate="gacc_factorajuste" ForeColor="Red"></asp:RequiredFieldValidator>

          </tr>
          <tr>
              <td><label class="control-label col-lg-2">Puntos Funcion</label></td>  
             <td><center><asp:TextBox ID="gacc_puntosfuncion"   runat="server" class="form-control" Text="?" ></asp:TextBox></center></td>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ErrorMessage="*" ControlToValidate="gacc_puntosfuncion" ForeColor="Red"></asp:RequiredFieldValidator>

          </tr> 
          <tr>
               <td>
                                                <label class="control-label col-lg-2">Lenguaje de programacion</label>
                                            </td>
               <td>
                                                <div class="col-lg-10">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddllenguajeslineas" ForeColor="Red"></asp:RequiredFieldValidator>
                                               <asp:DropDownList ID="gacc_ddllenguajeslineas" runat="server" class="form-control" >
                                                            <asp:ListItem Text=""></asp:ListItem>
                                                            <asp:ListItem Text="C" Value="150"></asp:ListItem>
                                                            <asp:ListItem Text="Java" Value="53"></asp:ListItem>
                                                            <asp:ListItem Text="Perl" Value="27"></asp:ListItem>
                                                            <asp:ListItem Text="Php" Value="167"></asp:ListItem>
                                                            <asp:ListItem Text="Phyton" Value="40"></asp:ListItem>
                                                            <asp:ListItem Text="C++" Value="55"></asp:ListItem>                                                       
                                                            <asp:ListItem Text="C#" Value="58"></asp:ListItem>
                                                            <asp:ListItem Text="Visual Basic" Value="29"></asp:ListItem>                                                   
                                                            <asp:ListItem Text="Cobol" Value="91"></asp:ListItem>
                                                            <asp:ListItem Text="Access" Value="38"></asp:ListItem>
                                                        </asp:DropDownList> </div>
                                            </td>
                                              
                                              </tr>
                                               <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Lineas de código</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtlineasdecodigo"   runat="server" class="form-control" Text="0" ></asp:TextBox> 
                                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtlineasdecodigo" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>                                                
                        
                                            </td>
                                       </tr>  <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Lineas de código Existentes</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_lineascodigoexistentes"   runat="server" class="form-control" Text="0" ></asp:TextBox> 
                                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ErrorMessage="*" ControlToValidate="gacc_lineascodigoexistentes" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>                                                
                        
                                            </td>
                                       </tr>
                                                           <tr>
               <td colspan="5">
               <center><asp:LinkButton ID="gacc_lnklineas" runat="server" class="btn btn-default btn-sm" OnClick="gacc_lnklineas_Click">Calcular</asp:LinkButton></center>
              </td>
          </tr>
                                                         </table>
                                                          </asp:WizardStep>
                                                
                                            <asp:WizardStep ID="WizardStep4" runat="server" Title="Datos">
                                            
                                                     <table class="table table-striped table-advance table-hover" style="width:100%" >
                                                     
                                                <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Empresa</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddlempresa" ForeColor="Red"></asp:RequiredFieldValidator>
                                                 <asp:DropDownList ID="gacc_ddlempresa" runat="server" class="form-control" OnSelectedIndexChanged="gacc_ddlempresa_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList> </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Nombre Del Proyecto</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddlnombredelproyecto" ForeColor="Red"></asp:RequiredFieldValidator>                     
                                                 <asp:DropDownList ID="gacc_ddlnombredelproyecto" runat="server" class="form-control"  AutoPostBack="true">
                                                        </asp:DropDownList> </div>
                                            </td>
                                        </tr>
                                               
                                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Lenguaje de programacion</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddllenguajes" ForeColor="Red"></asp:RequiredFieldValidator>
                                               <asp:DropDownList ID="gacc_ddllenguajes" runat="server" class="form-control"  >
                                                            <asp:ListItem Text="" ></asp:ListItem>
                                                            <asp:ListItem Text="C" Value="C"></asp:ListItem>
                                                            <asp:ListItem Text="Java" Value="Java"></asp:ListItem>
                                                            <asp:ListItem Text="Perl" Value="Perl"></asp:ListItem>
                                                            <asp:ListItem Text="Php" Value="Php"></asp:ListItem>
                                                            <asp:ListItem Text="Phyton" Value="Phyton"></asp:ListItem>
                                                            <asp:ListItem Text="C++" Value="C++"></asp:ListItem>                                                       
                                                            <asp:ListItem Text="C#" Value="C#"></asp:ListItem>
                                                            <asp:ListItem Text="Visual Basic " Value="Visual Basic"></asp:ListItem>                                                   
                                                            <asp:ListItem Text="Cobol" Value="Cobol"></asp:ListItem>
                                                            <asp:ListItem Text="Access" Value="Access"></asp:ListItem>
                                                        </asp:DropDownList> </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Gestor de BD </label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddlgestordebase" ForeColor="Red"></asp:RequiredFieldValidator>
                                                  <asp:DropDownList ID="gacc_ddlgestordebase" runat="server" class="form-control"  >
                                                            <asp:ListItem Text=""></asp:ListItem>
                                                            <asp:ListItem Text="MySQL" Value="MySQL"></asp:ListItem>
                                                            <asp:ListItem Text="MariaDB" Value="MariaDB"></asp:ListItem>
                                                            <asp:ListItem Text="SQLite" Value="SQLite"></asp:ListItem>
                                                            <asp:ListItem Text="PostgreSql" Value="PostgreSql"></asp:ListItem>
                                                            <asp:ListItem Text="Microsoft SQL Server" Value="Microsoft SQL Server"></asp:ListItem>
                                                            <asp:ListItem Text="Oracle" Value="Oracle"></asp:ListItem>                                                            
                                                            <asp:ListItem Text="MongoDB" Value="MongoDB"></asp:ListItem>
                                                            <asp:ListItem Text="Redis" Value="Redis"></asp:ListItem>
                                                            <asp:ListItem Text="Cassandra " Value="Cassandra"></asp:ListItem>
                                                        </asp:DropDownList> </div>
                                            </td>
                                              
                                        </tr>
                                             <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Modelo de proyecto</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddlmodelodeproyecto" ForeColor="Red"></asp:RequiredFieldValidator>
                                                         <asp:DropDownList ID="gacc_ddlmodelodeproyecto" runat="server" class="form-control"   >
                                                      <asp:ListItem Text="" ></asp:ListItem>
                                                            <asp:ListItem Text="Básico" Value="Básico"></asp:ListItem>
                                                            <asp:ListItem Text="Intermedio" Value="Intermedio"></asp:ListItem>

                                                 </asp:DropDownList></div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Tipo de proyecto</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" ControlToValidate="gacc_ddltipoproyecto" ForeColor="Red"></asp:RequiredFieldValidator>

                                                 <asp:DropDownList ID="gacc_ddltipoproyecto" runat="server" class="form-control"   >
                                                      <asp:ListItem Text="" ></asp:ListItem>
                                                            <asp:ListItem Text="Orgánico" Value="Orgánico"></asp:ListItem>
                                                            <asp:ListItem Text="Semi-Libre" Value="Semi-Libre"></asp:ListItem>
                                                            <asp:ListItem Text="Empotrado" Value="Empotrado"></asp:ListItem>

                                                 </asp:DropDownList>
                                                            </div>
                                            </td>                                              
                                        </tr>
                                                     </table>
                                                </asp:WizardStep>
                                                <asp:WizardStep ID="WizardStep5" runat="server" Title="Valores de Proyecto " > 
                                            <table class="table table-striped table-advance table-hover" style="width:100%" >
          <tr>
             <td colspan="7"><center><b>Valor</b></center></td>
          
         </tr>
         <tr>
             <td>Atributos</td>
                       
         </tr>
         <tr>
             <td colspan="7"><center><b>Atributos del Software</b></center></td>
            
         </tr>
         <tr>
             <td>Fiabilidad</td>
             <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbfiabilidad" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Value="0.75">Muy Bajo</asp:ListItem>
                <asp:ListItem Value="0.88">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="1.15">Alto</asp:ListItem>
                <asp:ListItem Value="1.40">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            
         </tr>
         <tr>
              <td>Tamaño de Base de Datos</td>
               <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbtamaño" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false">Muy Bajo</asp:ListItem>
                <asp:ListItem Value="0.94">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="1.08">Alto</asp:ListItem>
                <asp:ListItem Value="1.16">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            
         </tr>
         <tr>
             <td>Complejidad</td>
                <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbcomplejidad" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Value="0.70">Muy Bajo</asp:ListItem>
                <asp:ListItem Value="0.85">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="1.15">Alto</asp:ListItem>
                <asp:ListItem Value="1.30">Muy Alto</asp:ListItem>
                <asp:ListItem Value="1.65">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            
         </tr>
         <tr>
             <td colspan="7"><center><b>Atributos del Haardware</b></center></td>
             
         </tr>
         <tr>
              <td>Restricciones Tipo de ejecucion </td>
                <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbrestricciones" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false">Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="1.11">Alto</asp:ListItem>
                <asp:ListItem Value="1.30">Muy Alto</asp:ListItem>
                <asp:ListItem Value="1.66">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            </tr>
         <tr>
              <td>Restrcciones de memoria </td>
              <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbrestricmemoria" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false">Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="1.06">Alto</asp:ListItem>
                <asp:ListItem Value="1.21">Muy Alto</asp:ListItem>
                <asp:ListItem Value="1.56">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
         </tr>
         <tr>
              <td>Volatilidad de Maquina Virtual</td>
             <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbmaquinavirtual" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false">Muy Bajo</asp:ListItem>
                <asp:ListItem Value="0.87">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="1.15">Alto</asp:ListItem>
                <asp:ListItem Value="1.30">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
        </tr>
         <tr>
               <td>Tiempo de Respuesa</td>
              <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbtiemporespuesta" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false" >Muy Bajo</asp:ListItem>
                <asp:ListItem Value="0.87">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="1.07">Alto</asp:ListItem>
                <asp:ListItem Value="1.15">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            
         </tr>
         <tr>
             <td colspan="7"><center><b>Atributos del Personal</b></center></td>
             
         </tr>
         <tr>
                <td>Capacidad de análisis</td>      
              <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbcapacidad" runat="server" AutoPostBack="false" RepeatColumns="6" >
                <asp:ListItem Value="1.46" >Muy Bajo</asp:ListItem>
                <asp:ListItem Value="1.19">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="0.86">Alto</asp:ListItem>
                <asp:ListItem Value="0.71">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            
         </tr>
         <tr>
                  <td>Experiencia en la Aplicación</td>            
              <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbexperienciaenaplicacion" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Value="1.29" >Muy Bajo</asp:ListItem>
                <asp:ListItem Value="1.13">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="0.91">Alto</asp:ListItem>
                <asp:ListItem Value="0.82">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
         </tr>
         <tr>
                  <td>Calidad de los Programadores</td> 
             <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbcalidaddeprogramadores" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Value="1.42" >Muy Bajo</asp:ListItem>
                <asp:ListItem Value="1.17">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="0.86">Alto</asp:ListItem>
                <asp:ListItem Value="0.70">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
        </tr>
         <tr>
                 <td>Experiencia maquina virtual </td>    
             <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbexperienciamaquinavirtual" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Value="1.21" >Muy Bajo</asp:ListItem>
                <asp:ListItem Value="1.10">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="0.90">Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            
         </tr>
         <tr>
                  <td>Experiencia de lenguaje de Programacion </td>    
             <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbexplenguaje" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Value="1.14" >Muy bajo</asp:ListItem>
                <asp:ListItem Value="1.07">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="0.95">Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            
         </tr>
         <tr>
             <td colspan="7"><center><b>Atributos del Proyecto</b></center></td>
            
         </tr>
         <tr>
             
                  <td>Tecnicas Actualizadas </td>            
              <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbtecactualizadas" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Value="1.24" >Muy Bajo</asp:ListItem>
                <asp:ListItem Value="1.10">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="0.91">Alto</asp:ListItem>
                <asp:ListItem Value="0.82">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
             
         </tr>
         <tr>
            
                  <td> Utilizacion de herraminetas</td>            
             <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbutilizaciondeherramientas" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Value="1.24" >Muy Bajo</asp:ListItem>
                <asp:ListItem Value="1.10">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="0.91">Alto</asp:ListItem>
                <asp:ListItem Value="0.83">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
         </tr>
         <tr>
            
                  <td>Restricciones tiempo de Desarrollo </td>            
               <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbrestriccionestiempo" runat="server" AutoPostBack="false" RepeatColumns="6" >
                <asp:ListItem Value="1.23" >Muy Bajo</asp:ListItem>
                <asp:ListItem Value="1.08">Bajo</asp:ListItem>
                <asp:ListItem Value="1.00">Nominal</asp:ListItem>
                <asp:ListItem Value="1.04">Alto</asp:ListItem>
                <asp:ListItem Value="1.10">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
             </tr>
          <tr>                               
              <td colspan="7">
               <asp:Label ID="gacc_txtresultado" runat="server" Enabled="false" class="form-control" Text=""></asp:Label></td>

          </tr>
           <tr>
               <td colspan="7">
                   
                         <asp:LinkButton ID="gacc_lnkcalcularvalortodo" runat="server" OnClick="gacc_lnkcalcularvalortodo_Click" class="btn btn-default btn-sm" >Calcular Valor Projecto </asp:LinkButton>
              </td>
          </tr>
           </table>

                                                </asp:WizardStep>
                                                <asp:WizardStep ID="WizardStep6" runat="server" Title="Cálculo de COCOMO  " >
                                            <table class="table table-striped table-advance table-hover" style="width:100%" >
                                         
                                         
                                    
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Esfuerzo Nominal</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtesfuerzonominal"   runat="server" class="form-control" Text="?"></asp:TextBox> 
                                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtesfuerzonominal" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2" id="gacc_lblesfuerzoajustado" runat="server" Text="?">Esfuerzo Ajustado</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtesfuerzoajustado"   runat="server" class="form-control" Text="?" ></asp:TextBox>
                                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtesfuerzoajustado" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Tiempo</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txttiempo"   runat="server" class="form-control" Text=""></asp:TextBox> 

                                                </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Fecha de Inicio</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_fechainicio"   runat="server" class="form-control" TextMode="Date"></asp:TextBox> 
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ErrorMessage="*" ControlToValidate="gacc_fechainicio" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                            </td>
                                              
                                        </tr>
                                                 <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Fecha Final</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_fechafin"   runat="server" class="form-control" Text=""></asp:TextBox> 

                                                </div>
                                            </td>
                                              
                                        </tr>
                                         
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Número de persona</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtnumeropersonas"   runat="server" class="form-control" Text="?"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtnumeropersonas" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                               
                                            </td>
                                        </tr>
                                                                                               
                       
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2" runat="server" id="gacc_lblestado">Estado </label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                                <asp:DropDownList ID="gacc_ddlestado" runat="server" class="form-control">
                                                    <asp:ListItem Text="Activo" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="Inactivo" Value="I"></asp:ListItem>
                                                </asp:DropDownList> </div>
                                            </td>
                                        </tr>
                                                 <tr >
                                                             <td colspan="2"><center><asp:LinkButton ID="gacc_lnkcalculartodo" runat="server" OnClick="gacc_lnkcalculartodo_Click" class="btn btn-default btn-sm" >Calcular Todo </asp:LinkButton></center></td>
                                                             <td colspan="2"><center><asp:LinkButton ID="gacc_lnkfechafin" runat="server" OnClick="gacc_lnkfechafin_Click" class="btn btn-default btn-sm" >Calcular Fecha Fin </asp:LinkButton></center></td>
                                                         </tr>

                                                </table>
                                                    </asp:WizardStep>
                                         </WizardSteps>
                                             <HeaderTemplate>
               <ul id="wizHeader">
                   <asp:Repeater ID="SideBarList" runat="server">
                       <ItemTemplate>
                           <li><a class="<%# GetClassForWizardStep(Container.DataItem) %>" title="<%#Eval("Name")%>">
                               <%# Eval("Name")%></a> </li>
                       </ItemTemplate>
                   </asp:Repeater>
               </ul>
           </HeaderTemplate>
                                        </asp:Wizard>
                         
                                         
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


