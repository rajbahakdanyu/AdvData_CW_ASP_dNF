<%@ Page Title="Dish Search" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Dish Search.aspx.cs" Inherits="AdvData_CW_ASP_dNF.Dish_Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>            
            <asp:Label ID="lbTitle" runat="server" Font-Size="XX-Large" Text="Dish Search"></asp:Label>

            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbName" runat="server" Text="Dish Name"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlName" runat="server" DataSourceID="SqlDataSource1" DataTextField="DISH" DataValueField="DISH_ID"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;DISH_ID&quot;, &quot;DISH&quot; FROM &quot;DISH&quot;"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
            <hr>            
            <div>
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No records has been added."></asp:GridView>
            </div>
        </div>
</asp:Content>
