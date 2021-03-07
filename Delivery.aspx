﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delivery.aspx.cs" Inherits="AdvData_CW_ASP_dNF.Delivery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<div>
            <asp:Label ID="lbTitle" runat="server" Font-Size="XX-Large" Text="Delivery Location"></asp:Label>

            <br />

            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbId" runat="server" Text="Delivery Id"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLatitude" runat="server" Text="Latitude"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLongitude" runat="server" Text="Longitude"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbDescription" runat="server" Text="Description"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>

            <hr />

            <div>
                <asp:GridView ID="GridView1" runat="server" DataKeyNames="delivery_id" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" 
                OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
                AutoGenerateEditButton="true" AutoGenerateDeleteButton="true">
            </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
