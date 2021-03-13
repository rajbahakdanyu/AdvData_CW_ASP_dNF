<%@ Page Title="Order Details" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Order Detail.aspx.cs" Inherits="AdvData_CW_ASP_dNF.Order_Detail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="jumbotron">            
            <asp:Label ID="lbTitle" runat="server" Font-Size="XX-Large" Text="Order Details"></asp:Label>

            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbName" runat="server" Text="Customer Name"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlName" runat="server" DataSourceID="SqlDataSource1" DataTextField="CUSTOMER_NAME" DataValueField="CUSTOMER_ID"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;CUSTOMER_ID&quot;, &quot;CUSTOMER_NAME&quot; FROM &quot;CUSTOMER&quot;"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button class="btn btn-success" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
            <hr>            
            <div>
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No records has been added." CssClass="table table-striped table-dark"></asp:GridView>
            </div>
        </div>
</asp:Content>