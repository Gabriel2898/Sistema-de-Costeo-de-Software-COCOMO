<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_LiderProyectoInsertarProyecto.Master" AutoEventWireup="true" CodeBehind="GACC_LiderProyectoInsertarProyecto.aspx.cs" Inherits="GACC_Vista.GACC_LiderProyectoInsertarProyecto1" %>
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
                        <asp:LinkButton ID="gacc_lnkeditar" runat="server" OnClick="gacc_lnkeditar_Click"  class="btn btn-primary btn-sm" >Guardar</asp:LinkButton>
                
                    </td>
                </tr>
                 <tr>
                    <td colspan="2">
                        <br />
                        <table style="width:100%" class="table table-striped table-advance table-hover">
                            <tr>
                                <td style="align-content:center">
                                    <table class="table table-striped table-advance table-hover" style="width:100%">

                                        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" class="table table-striped table-advance table-hover" OnNextButtonClick="Wizard1_NextButtonClick"  DisplaySideBar="false" OnPreRender="Wizard1_PreRender"><NavigationButtonStyle  BorderColor="Blue" />
                                            <WizardSteps>
                                                <asp:WizardStep ID="WizardStep1" runat="server" Title="Empresa">
                                                     
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
                                                         </table>
                                                    </asp:WizardStep>
                                         <asp:WizardStep ID="WizardStep2" runat="server" Title="Datos">
                                                     
                                                     <table class="table table-striped table-advance table-hover" style="width:100%" >
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
                                                            <asp:ListItem Text="GESTOR DE BASE DE DATOS    "></asp:ListItem>
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
                                                <label class="control-label col-lg-2">Lineas de código</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtlineasdecodigo"   runat="server" class="form-control" Text="0" ></asp:TextBox> </div>                                                
                        
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
                                                      <asp:ListItem Text="Seleccione El Modelo De Proyecto" Value="0"></asp:ListItem>
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
                                                      <asp:ListItem Text="Seleccione El Tipo De Proyecto" ></asp:ListItem>
                                                            <asp:ListItem Text="Orgánico" Value="Orgánico"></asp:ListItem>
                                                            <asp:ListItem Text="Semi-Libre" Value="Semi-Libre"></asp:ListItem>
                                                            <asp:ListItem Text="Empotrado" Value="Empotrado"></asp:ListItem>

                                                 </asp:DropDownList>
                                                            </div>
                                            </td>
                                              
                                        </tr>
                                               
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Esfuerzo Nominal</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtesfuerzonominal"   runat="server" class="form-control" Text="0"></asp:TextBox> </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2" id="gacc_lblesfuerzoajustado" runat="server" Text="0">Esfuerzo Ajustado</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtesfuerzoajustado"   runat="server" class="form-control" Text="0" ></asp:TextBox> </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Tiempo</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txttiempo"   runat="server" class="form-control" Text="0"></asp:TextBox> </div>
                                            </td>
                                              
                                        </tr>
                                             
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Número de persona</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                     
                                                 <asp:TextBox ID="gacc_txtnumeropersonas"   runat="server" class="form-control" Text="0"></asp:TextBox> </div>
                                               
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
                                                    <asp:ListItem Text="Activo" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="Inactivo" Value="I"></asp:ListItem>
                                                </asp:DropDownList> </div>
                                            </td>
                                        </tr>
                                                         </table>
                                             </asp:WizardStep>
                                                          <asp:WizardStep ID="WizardStep3" runat="server" Title="Costeo">
                                                     
                                                     <table class="table table-striped table-advance table-hover" style="width:100%" >
                                                                <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Costo Trabajadores</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtcostotrabajadores" ForeColor="Red"></asp:RequiredFieldValidator>
                                                 <asp:TextBox ID="gacc_txtcostotrabajadores"   runat="server" class="form-control"  Text="?"></asp:TextBox> </div>
                                            </td>
                                              
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Costo Indirecto</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtcostoindirecto" ForeColor="Red"></asp:RequiredFieldValidator>
                                                 <asp:TextBox ID="gacc_txtcostoindirecto"   runat="server" class="form-control" Text="?"></asp:TextBox> </div>
                                                 
                                            </td>
                                              
                                        </tr>
                                         <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Costo total</label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="gacc_txtcostototal" ForeColor="Red"></asp:RequiredFieldValidator>
                                                 <asp:TextBox ID="gacc_txtcostototal"   runat="server" class="form-control" Text="?"></asp:TextBox> </div>
                                            </td>
                                        </tr>

                                                 <tr >
                                                             <td colspan="2"><center> <asp:LinkButton ID="gacc_lnkcalculartodo" runat="server" OnClick="gacc_lnkcalculartodo_Click" class="btn btn-default btn-sm" >Calcular Todo </asp:LinkButton></center></td>
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
