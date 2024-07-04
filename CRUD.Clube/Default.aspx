<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD.Clube._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="row">
       <div class="col-12">
           <asp:Label runat="server" Text="Número da camisa"></asp:Label>
           <asp:TextBox ID="txtNroCamisa" runat="server"></asp:TextBox>
           <asp:Label runat="server" Text="Apelido"></asp:Label>
           <asp:TextBox ID="txtApelido" runat="server"></asp:TextBox>
           <asp:Label runat="server" Text="Classificação do IMC"></asp:Label>
           <asp:DropDownList ID="ddlClassificacaoIMC" runat="server">
               <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
               <asp:ListItem Value="Abaixo do peso normal">Abaixo do peso normal</asp:ListItem>
               <asp:ListItem Value="Peso Normal">Peso Normal</asp:ListItem>
               <asp:ListItem Value="Excesso de peso">Excesso de peso</asp:ListItem>
               <asp:ListItem Value="Obesidade classe I">Obesidade classe I</asp:ListItem>
               <asp:ListItem Value="Obesidade classe II">Obesidade classe II</asp:ListItem>
               <asp:ListItem Value="Obesidade classe III">Obesidade classe III</asp:ListItem>
           </asp:DropDownList>
           <asp:Button CssClass="btn btn-sm btn-secondary" ID="btnBuscar" runat="server" Text="Pesquisar" OnClick="PesquisarAtletas"/>

           <asp:Button CssClass="btn btn-sm btn-success" ID="btnNovo" runat="server" Text="Novo Atleta" OnClick="NovoAtleta"/>

           <asp:GridView ID="gvAtleta" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowDataBound="gvAtleta_RowDataBound">
               <Columns>
                   <asp:BoundField DataField="IdAtleta" HeaderText="Id"/>
                   <asp:BoundField DataField="NomeCompleto" HeaderText="Nome Completo"/>
                   <asp:BoundField DataField="Apelido" HeaderText="Apelido"/>
                   <asp:BoundField DataField="DataNascimento" HeaderText="Data Nascimento" DataFormatString="{0:dd/MM/yyyy}"/>
                   <asp:BoundField DataField="Altura" HeaderText="Altura"/>
                   <asp:BoundField DataField="Peso" HeaderText="Peso(kg)"/>
                   <asp:BoundField DataField="Posicao" HeaderText="Posição"/>
                   <asp:BoundField DataField="NroCamisa" HeaderText="Numero Camisa"/>
                   <asp:BoundField DataField="Imc" HeaderText="IMC" DataFormatString="{0:n}"/>
                   <asp:BoundField DataField="ClassificacaoImc" HeaderText="Classificação do IMC"/>

                   <asp:TemplateField>
                       <ItemTemplate>
                           <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdAtleta") %>' OnClick="EditarAtleta" CssClass="btn btn-sm btn-primary">Editar</asp:LinkButton>
                           <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdAtleta") %>' OnClick="EliminarAtleta" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Deseja eliminar o atleta?')">Eliminar</asp:LinkButton>
                       </ItemTemplate>
                   </asp:TemplateField>
               </Columns>
           </asp:GridView>
       </div>
   </div>

</asp:Content>
