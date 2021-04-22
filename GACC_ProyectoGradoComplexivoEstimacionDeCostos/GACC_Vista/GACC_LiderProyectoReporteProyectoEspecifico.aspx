<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_LiderProyectoReporteProyectoEspecifico.Master" AutoEventWireup="true" CodeBehind="GACC_LiderProyectoReporteProyectoEspecifico.aspx.cs" Inherits="GACC_Vista.GACC_LiderProyectoReporteProyectoEspecifico1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="gacc_cphhead" runat="server">
   
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
    <Table >
        <tr>
         <td>Buscar por:</td>                   
        <td>

                              <asp:LinkButton ID="gacc_lnkbuscar" runat="server" OnClick="gacc_lnkbuscar_Click" class="btn btn-success btn-sm" >Buscar</asp:LinkButton>

                           </td>
   </tr>
 
    <tr>
        
    
                     
                           <td>
                                                <label class="control-label col-lg-2">Empresa  </label>
                                            </td>
       
                                            <td>
                                                <div class="col-lg-10" style="height: 30px">
                                               
                                                <asp:DropDownList ID="gacc_ddlempresa" runat="server" class="form-control" OnSelectedIndexChanged="gacc_ddlempresa_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList> </div>
                                            </td>
       
    </tr>

                                       <br />
    <tr>
                                            <td>
                                                <label class="control-label col-lg-2">Proyecto  </label>
                                            </td>
                                            <td>
                                                <div class="col-lg-10">
                                               
                                                <asp:DropDownList ID="gacc_ddlproyecto" runat="server" class="form-control"  AutoPostBack="true"  >
                                                </asp:DropDownList> </div>
                                            </td>
      
 
                   </tr>
    </Table>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="1132px">
        <LocalReport ReportPath="GACC_LiderProyectoReporteProyectoEspecifico.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
            </DataSources>
        </LocalReport>
     </rsweb:ReportViewer>


     <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetData" TypeName="GACC_Vista.DataSet5TableAdapters.GACC_ViewPersonaProyectoTableAdapter"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="GACC_Vista.DataSet5TableAdapters.GACC_ViewProyectoCostoTableAdapter"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="GACC_Vista.DataSet5TableAdapters.GACC_ViewTablaProyecto2TableAdapter"></asp:ObjectDataSource>


</asp:Content>
