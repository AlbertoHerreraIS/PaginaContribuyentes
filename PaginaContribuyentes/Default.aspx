<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PaginaContribuyentes.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link href="CSS/Grid.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Modulo de Contribuyentes</title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="card text-center" style="text-align:center; align-content:center">
         <div class="card-header">
            Modulo de Contribuyentes
        </div>
        <div class="card-body" >
            <h5 class="card-title">Seleccion el contribuyente que desea editar</h5>      
            
            <div style="padding-left:20%; width:80%">

                
                 <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-dark" CellPadding="0" CellSpacing="0" GridLines="None" 
                     AutoGenerateColumns="False" DataKeyNames="ContribuyenteID" OnRowEditing="GridView1_RowEditing" ShowFooter="true"
                     OnRowCommand="GridView1_RowCommand" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating"
                      OnRowDeleting="GridView1_RowDeleting" AllowPaging="true" PageSize="2" OnPageIndexChanging="GridView1_PageIndexChanging" EmptyDataText="No Data Found" 
                      ShowHeaderWhenEmpty="true">
                           


                       <Columns>
                            <asp:TemplateField HeaderText ="ID">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("ContribuyenteID") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtID" Text='<%# Eval("ContribuyenteID") %>' runat="server" enabled="false"/>
                            </EditItemTemplate>
                            
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText ="RazonSocial">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("RazonSocial") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtrs" Text='<%# Eval("RazonSocial") %>' runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtrsFooter" runat="server" />
                            </FooterTemplate> 
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText ="Mail">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Mail") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMail" Text='<%# Eval("Mail") %>' runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtMailFooter" runat="server" />
                            </FooterTemplate> 
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText ="RFC">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("RFC") %>' runat="server" Enabled="false"/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRFC" Text='<%# Eval("RFC") %>' runat="server" Enabled="false" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtRFCFooter" runat="server" />
                            </FooterTemplate> 
                            </asp:TemplateField>
                           <asp:TemplateField>
                               <ItemTemplate> 
                                   <asp:ImageButton ImageUrl="~/images/lapiz.png" runat="server" CommandName="Edit" ToolTip="Editar elemento" Width="20px" Height="20px" />                                   
                               </ItemTemplate>
                               <EditItemTemplate>
                                   <asp:ImageButton ImageUrl="~/images/save.png" runat="server" CommandName="Update" ToolTip="Actualizar elemento" Width="20px" Height="20px" />
                                   <asp:ImageButton ImageUrl="~/images/bote.png" runat="server" CommandName="Delete" ToolTip="Borrar elemento" Width="20px" Height="20px" />
                                   <asp:ImageButton ImageUrl="~/images/x.png" runat="server" CommandName="Cancel" ToolTip="Cancelar elemento" Width="20px" Height="20px" />
                               </EditItemTemplate>
                               <FooterTemplate>
                                   <asp:ImageButton ImageUrl="~/images/mas.png" runat="server" CommandName="AddNew" ToolTip="Añadir elemento" Width="20px" Height="20px" />
                               </FooterTemplate>
                           </asp:TemplateField>

                           <%--<asp:BoundField HeaderText="ID" DataField="ContribuyenteID"/>
                           <asp:BoundField HeaderText="Razon Social" DataField="RazonSocial"/>
                           <asp:BoundField HeaderText="Mail" DataField="Mail"/>
                           <asp:BoundField HeaderText="UserId" DataField="UserId" Visible="false"/>
                           <asp:BoundField HeaderText="Active" DataField="Active" Visible="false"/>
                           <asp:BoundField HeaderText="RFC" DataField="RFC"/>
                           <asp:CommandField ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton="true" />--%>                                                     
                      </Columns>
                </asp:GridView>
                <br />
                <asp:Label ID="lblSuccess" Text="" runat="server" ForeColor="Green" />
                <br />
                <asp:Label ID="lblError" Text="" runat="server" ForeColor="Red" />
            </div>
        </div>
        <div class="card-footer text-muted">
            Powered By Bootstrap
        </div>
        </div>

    </form>
</body>
</html>
