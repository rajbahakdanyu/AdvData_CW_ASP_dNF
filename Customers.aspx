﻿<%@ Page Title="Customers"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="AdvData_CW_ASP_dNF.Customers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
            <asp:Label ID="lbTitle" runat="server" Font-Size="XX-Large" Text="Customers"></asp:Label>

            <br />

            <div class="form-group">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbId" runat="server" Text="Customer Id"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbName" runat="server" Text="Customer Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbPhone" runat="server" Text="Phone Number"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbAddress" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbPoints" runat="server" Text="Loyalty Points"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPoints" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button class="btn btn-success" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button class="btn btn-primary" ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>
            </div>

            <hr />

            <div>
                <asp:GridView ID="GridView1" runat="server" DataKeyNames="Customer_id" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" 
                OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
                AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" CssClass="table table-striped">
            </asp:GridView>
            </div>
        </div>
</asp:Content>

