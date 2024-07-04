﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="CRUD.Clube.Editar" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" CssClass="fs-4 fw-bold" Text="Editar Atleta"></asp:Label>

    <div class="mb-3">
        <asp:Label CssClass="form-label" runat="server" Text="Nome Completo"></asp:Label>
        <asp:TextBox ID="txtNomeCompleto" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label CssClass="form-label" runat="server" Text="Apelido"></asp:Label>
        <asp:TextBox ID="txtApelido" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label CssClass="form-label" runat="server" Text="Data Nascimento"></asp:Label>
        <asp:TextBox ID="dtDataNascimento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label CssClass="form-label" runat="server" Text="Altura"></asp:Label>
        <asp:TextBox ID="txtAltura" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label CssClass="form-label" runat="server" Text="Peso"></asp:Label>
        <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label CssClass="form-label" runat="server" Text="Posição"></asp:Label>
        <asp:TextBox ID="txtPosicao" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label CssClass="form-label" runat="server" Text="NroCamisa"></asp:Label>
        <asp:TextBox ID="txtNroCamisa" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-sm btn-primary" OnClick="EditarAtleta"/>
    <asp:LinkButton runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-sm btn-warning">Voltar</asp:LinkButton>
</asp:Content>


