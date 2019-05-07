<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Our_FYPJ2019.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .ui-progressbar {
            position: relative;
        }

        .progress-label {
            position: absolute;
            left: 50%;
            top: 4px;
            font-weight: bold;
            text-shadow: 1px 1px 0 #fff;
        }

        body {
            font-family: Arial;
            font-size: 10pt;
        }

        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-align: center;
            font-size: large;
        }
    </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/start/jquery-ui.css">
    <script type="text/javascript" src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".progress").each(function () {
                $(this).progressbar({
                    value: parseInt($(this).find('.progress-label').text())
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  GridLines="None">
                <Columns>
                    <asp:BoundField DataField="DensePowerRank" HeaderText="Rank">
                        <HeaderStyle Font-Bold="True" />
                        <ItemStyle HorizontalAlign="Center" Font-Bold="True" Width="50px" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image", "~/Images/{0}") %>' Width="60" Height="60" CssClass="image" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Username">
                        <ItemTemplate>
                            <asp:Label ID="lbl_username" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="450px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Total" HeaderText="Points">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundField>
                    <asp:TemplateField ItemStyle-Width="300">
                        <ItemTemplate>
                            <div class='progress'>
                                <div class="progress-label">
                                    <%# Eval("Total") %>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
        </div>
        <asp:Panel ID="Top3alltimePanel" runat="server">
            <table style="width: 50%; margin: 0 auto" >
                <tr>
                    <td>
                        <asp:DataList ID="DataList2" runat="server" RepeatDirection="Horizontal" HorizontalAlign="Center">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td class="auto-style2">
                                            <h3>
                                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("DensePowerRank") %>'></asp:Label>
                                                nd</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("image", "~/Images/{0}") %>' CssClass="image" Width="110px" Height="110px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList></td>
                    <td>
                        <asp:DataList ID="DataList1" runat="server" HorizontalAlign="Center" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td class="auto-style2">
                                            <h3>
                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("DensePowerRank") %>'></asp:Label>
                                                st</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Image ID="Image1" runat="server" class="image" Height="170px" ImageUrl='<%# Eval("image", "~/Images/{0}") %>' Width="170px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td>
                        <asp:DataList ID="DataList3" runat="server" HorizontalAlign="Center" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td class="auto-style2">
                                            <h3>
                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("DensePowerRank") %>'></asp:Label>
                                                rd</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Image ID="Image3" runat="server" CssClass="image" Height="110px" ImageUrl='<%# Eval("image", "~/Images/{0}") %>' Width="110px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="height: 50px; background-color: silver; margin-top: 20px" class="auto-style3"><strong>2nd </strong>
                        </div>
                    </td>
                    <td>
                        <div style="height: 70px; background-color: gold; margin: 0 auto" class="auto-style3"><strong>1st </strong>
                        </div>
                    </td>
                    <td>
                        <div style="height: 50px; background-color: #cd7f32; margin-top: 20px" class="auto-style3"><strong>3rd </strong>
                        </div>
                    </td>
                </tr>
             
            </table>
        </asp:Panel>
    </form>
</body>

</html>
