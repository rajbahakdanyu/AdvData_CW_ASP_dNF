﻿<%@ Page Title="Loyalty Points " MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Loyalty.aspx.cs" Inherits="AdvData_CW_ASP_dNF.Loyalty" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="jumbotron">
            <asp:Label ID="lbTitle" runat="server" Font-Size="XX-Large" Text="Loyalty Points"></asp:Label>

            <br />

            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbId" runat="server" Text="Loyalty Id"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
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
                        <asp:Label ID="lbStart" runat="server" Text="Start Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStart" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="btnStart" runat="server" ImageUrl="~/calendar.png" ImageAlign="AbsBottom" OnClick="btnStart_Click"/>
                        <asp:Calendar ID="calStart" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="calStart_SelectionChanged" OnDayRender="calStart_DayRender">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbEnd" runat="server" Text="End Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEnd" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="btnEnd" runat="server" ImageUrl="~/calendar.png" ImageAlign="AbsBottom" OnClick="btnEnd_Click"/>
                        <asp:Calendar ID="calEnd" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="calEnd_SelectionChanged" OnDayRender="calEnd_DayRender">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC"/>
                        </asp:Calendar>
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

            <hr />

            <div>
                <asp:GridView ID="GridView1" runat="server" DataKeyNames="loyalty_id" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" 
                OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
                AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" CssClass="table table-striped">
            </asp:GridView>
            </div>
        </div>
</asp:Content>
