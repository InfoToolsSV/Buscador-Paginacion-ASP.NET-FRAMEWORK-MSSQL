<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Buscador.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registros de Usuarios</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.4/css/bulma.min.css" />
</head>
<body>
    <form runat="server" class="section">
        <div class="container">
            <h2 class="title">Buscador</h2>
            <div class="field is-group">
                <div class="control">
                    <asp:TextBox ID="txtTerminoBusqueda" runat="server" CssClass="input" placeholder="Ingrese término de búsqueda"></asp:TextBox>
                    <asp:Button runat="server" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click" CssClass="button is-primary" />
                </div>
            </div>
            <br />
            <div>
                <asp:Label runat="server" ID="lblNoResult" Visible="false" Text="No se encontraron resultados." CssClass="message"></asp:Label>
            </div>
            <div class="table-container">
                <asp:GridView runat="server" ID="gvResults" AutoGenerateColumns="true" CssClass="table is-hoverable is-fullwidth"
                    AllowPaging="true" OnPageIndexChanging="gvResults_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
