<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Activity.aspx.cs" Inherits="Our_FYPJ2019.Activity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        body {
            font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
            font-size: 16px;
            line-height: 1.5;
        }

        .auto-style1 {
            width: 100%;
        }

        .auto-style3 {
            text-align: left;
        }

        .auto-style4 {
            text-align: right;
        }

        .image {
            border-radius: 100px;
        }

        h1 {
            width: 60%;
            text-align: center;
            border-bottom: 1px solid #000;
            line-height: 0.1em;
            margin: 10px auto 20px;
        }

            h1 span {
                background: #fff;
                padding: 0 10px;
            }
    </style>

    <div class="auto-style3">
        <%--        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" Width="500px" HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table class="auto-style1">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_activityName" runat="server" Text='<%# Eval("activityName") %>' ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="lbl_dateTime" runat="server" Text='<%# Eval("dateTime") %>' ></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>

        <h1><span>Activity</span></h1>
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" CellSpacing="10" HorizontalAlign="Center">

            <ItemTemplate>
                <table class="auto-style1" style="background-color: whitesmoke; width: 500px">
                    <tr>
                        <td rowspan="2">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image", "~/Images/{0}") %>' CssClass="image" Height="60px" Width="60px" />
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("activityName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("dateTime") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="None">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("dateTime", "{0:dd MMM yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="activityName" />
                <asp:BoundField DataField="change" HeaderText="Points">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="balance" HeaderText="Balance">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
</asp:Content>

