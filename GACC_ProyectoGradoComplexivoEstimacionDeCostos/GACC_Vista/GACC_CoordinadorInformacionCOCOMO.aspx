<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_CoordinadorInformacionCOCOMO.Master" AutoEventWireup="true" CodeBehind="GACC_CoordinadorInformacionCOCOMO.aspx.cs" Inherits="GACC_Vista.GACC_CoordinadorInformacionCOCOMO1" %>
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
    
     <table class="table table-striped table-advance table-hover" style="width: 100%; height: 55px">
         <table  class="table table-striped table-advance table-hover" style="width: 100%; height: 55px" >
        <td>
            <table  class="table table-striped table-advance table-hover" style="width: 0%; height: 55px" >
        <tr>
            <td colspan="5">
                <div style="text-align:center"> <label >COCOMO BÁSICO </label></div>
            </td>
           
        </tr>
        
        <tr>
            <td colspan="2">
                 <div style="text-align:center">   <label >TIPO DESARROLLO </label></div>
            </td>
            <td colspan="3">
                 <div style="text-align:center">   <label > VALORES </label></div>
            </td>
            
            
        </tr>
        <tr>
            <td >
                      <div style="text-align:center">   <label >TIPO DESARROLLO </label></div>
            </td>
            <td> 
                <div style="text-align:center">   <label >A </label></div>
            </td>
            <td>
                 <div style="text-align:center">   <label ">B</label></div>
            </td>
            <td> 
                <div style="text-align:center">    <label ">C </label></div>
            </td>
            <td>
                 <div style="text-align:center">   <label ">D</label></div>
            </td>
            
        </tr>
        <tr>
            <td>
                <div style="text-align:center">   <label ">ORGANICO</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >2.40</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >1.05</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >2.50</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >0.38</label></div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="text-align:center">   <label >SEMILIBRE</label></div>

            </td>
            <td>
                <div style="text-align:center">   <label >3.00</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >1.12</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >2.50</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >0.35</label></div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="text-align:center">   <label >EMPOTRADO</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >3.60</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label>1.20</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >2.50</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >0.32</label></div>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                 <div style="text-align:center"><label >PM= a(KLDC)^b </br> PM: Personas-Mes</label></div>
            </td></tr>
                <tr>

            
            <td colspan="5">
                 <div style="text-align:center"><label >TD= c(PM)^d  </br> TD: Tiempo de desarrollo-Mes</label>
                 </div>
            </td></tr>
                 <tr>
            <td colspan="5">
                 <div style="text-align:center"><label >P= PM/TD  </br>  P: Número de Personas</label></div>
            </td>
            
        </tr>
            </table>
            </td>

        <td>

        
        <table  class="table table-striped table-advance table-hover" style="width: 0%; height: 55px" >
        <tr>
            <td colspan="5">
                <div style="text-align:center"> <label >COCOMO INTERMEDIO </label></div>
            </td>
           
        </tr>
        
        <tr>
            <td colspan="2">
                 <div style="text-align:center">   <label >TIPO DESARROLLO </label></div>
            </td>
            <td colspan="3">
                 <div style="text-align:center">   <label > VALORES </label></div>
            </td>
            
            
        </tr>
        <tr>
            <td >
                
                      <div style="text-align:center">   <label >TIPO DESARROLLO </label></div>
            </td>
            <td> 
                <div style="text-align:center">   <label >A </label></div>
            </td>
            <td>
                 <div style="text-align:center">   <label ">B</label></div>
            </td>
            <td> 
                <div style="text-align:center">    <label ">C </label></div>
            </td>
            <td>
                 <div style="text-align:center">   <label ">D</label></div>
            </td>
            
        </tr>
        <tr>
            <td>
                <div style="text-align:center">   <label ">ORGANICO</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >3.20</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >1.20</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >2.5</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >0.38</label></div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="text-align:center">   <label >SEMILIBRE</label></div>

            </td>
            <td>
                <div style="text-align:center">   <label >3.00</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >1.12</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >2.50</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >0.35</label></div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="text-align:center">   <label >EMPOTRADO</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >2.80</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label>1.20</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >2.50</label></div>
            </td>
            <td>
                <div style="text-align:center">   <label >0.32</label></div>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                 <div style="text-align:center"><label >PM= a(KLDC)^b </br> PM: Personas-Mes</label></div>
            </td></tr>
                <tr>

            
            <td colspan="5">
                 <div style="text-align:center"><label >TD= c(PM)^d  </br> TD: Tiempo de desarrollo-Mes</label>
                 </div>
            </td></tr>
                 <tr>
            <td colspan="5">
                 <div style="text-align:center"><label >P= PM/TD  </br>  P: Número de Personas</label></div>
            </td>
            
        </tr>
    </table>
            </td>
             </table>
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
                <asp:ListItem Enabled="false" Value="0.75">0.75--Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.88">0.88--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.15">1.15--Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.40">1.40--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            
         </tr>
         <tr>
              <td>Tamaño de Base de Datos</td>
               <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbtamaño" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false">Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.94">0.94--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.08">1.00--Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.16">1.16--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            
         </tr>
         <tr>
             <td>Complejidad</td>
                <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbcomplejidad" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false" Value="0.70">0.70--Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.85">0.85--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.15">1.15--Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.30">1.30--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.65">1.65--Extra Alto</asp:ListItem>
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
                <asp:ListItem Enabled="false" >Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.11">1.11--Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.30">1.30--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.66">1.66--Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            </tr>
         <tr>
              <td>Restrcciones de memoria </td>
              <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbrestricmemoria" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false">Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false">Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.06">1.06--Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.21">1.21--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.56">1.56--Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
         </tr>
         <tr>
              <td>Volatilidad de Maquina Virtual</td>
             <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbmaquinavirtual" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false">Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.87">0.87--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00-Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.15">1.15--Altoa</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.30">1.30--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false" >Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
        </tr>
         <tr>
               <td>Tiempo de Respuesa</td>
              <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbtiemporespuesta" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false"  >Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.87">0.87--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.07">1.07--Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.15">1.15--Muy Alto</asp:ListItem>
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
                <asp:ListItem Enabled="false" Value="1.46" >1.46--Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.19">1.19--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.86">0.86--ALto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.71">0.71--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            
         </tr>
         <tr>
                  <td>Experiencia en la Aplicación</td>            
              <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbexperienciaenaplicacion" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false" Value="1.29" >1.29--Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.13">1.13--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.91">0.91--Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.82">0.82--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
         </tr>
         <tr>
                  <td>Calidad de los Programadores</td> 
             <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbcalidaddeprogramadores" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false" Value="1.42" >1.42--Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.17">1.17--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.86">0.86--Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.70">0.70--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
        </tr>
         <tr>
                 <td>Experiencia maquina virtual </td>    
             <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbexperienciamaquinavirtual" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false" Value="1.21" >1.21--Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.10">1.10--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.90">0.90--Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
            
         </tr>
         <tr>
                  <td>Experiencia de lenguaje de Programacion </td>    
             <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbexplenguaje" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false" Value="1.14" >1.14--Muy bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.07">1.07--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.95">0.95--ALto</asp:ListItem>
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
                <asp:ListItem Enabled="false" Value="1.24" >1.24--Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.10">1.10--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.91">0.91--Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.82">0.82--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
             
         </tr>
         <tr>
            
                  <td> Utilizacion de herraminetas</td>            
             <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbutilizaciondeherramientas" runat="server" AutoPostBack="false" RepeatColumns="6">
                <asp:ListItem Enabled="false" Value="1.24" >1.24--Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.10">1.10--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.91">0.91--Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="0.83">0.83--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
         </tr>
         <tr>
            
                  <td>Restricciones tiempo de Desarrollo </td>            
               <td colspan="6">
             <asp:RadioButtonList ID="gacc_rdbrestriccionestiempo" runat="server" AutoPostBack="false" RepeatColumns="6" >
                <asp:ListItem Enabled="false" Value="1.23" >1.23--Muy Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.08">1.00--Bajo</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.00">1.00--Nominal</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.04">1.04--Alto</asp:ListItem>
                <asp:ListItem Enabled="false" Value="1.10">1.10--Muy Alto</asp:ListItem>
                <asp:ListItem Enabled="false">Extra Alto</asp:ListItem>
             </asp:RadioButtonList>             
             </td>
             </tr>
          <tr>                               
              <td colspan="7">
               <asp:Label ID="gacc_txtresultado" runat="server" Enabled="false" class="form-control"></asp:Label></td>
          </tr>
          
           </table>
       </table>
  
</asp:Content>
