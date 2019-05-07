<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="Our_FYPJ2019.Leaderboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
            font-size: 16px;
            line-height: 1.5;
        }

        .image {
            border-radius: 100px;
        }

        .auto-style2 {
            text-align: center;
        }

        .linkbtn {
            border: 2px solid orange;
            background-color: orange;
            color: white;
        }

        a {
            text-decoration: none;
        }

        #Image4 {
            border-radius: 100px;
        }

        .gridview {
            border-top-style: none;
            border-left-style: none;
            border-right-style: none;
        }

        .auto-style4 {
            font-size: x-large;
        }

        .ui-progressbar {
            position: relative;
        }

        .progress-label {
            position: absolute;
            left: 50%;
            top: 4px;
            font-weight: bold;
            text-shadow: 1px 1px 0 #fff;
            font-size: 16px;
        }

        .auto-style5 {
            font-size: large;
        }

        body {
            background-image: url(../Images/green.jpg);
            background-size: cover;
            background-repeat: no-repeat;
            background-size: 20%;
            background-position-x: right;
            background-position-y: bottom;
        }

        .header {
            background-image: url(../Images/header.png);
            background-size: cover;
            background-repeat: no-repeat;
            background-size: 100%;
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

     <div>
        <div runat="server" class="header">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

            <h1 class="auto-style2">Leaderboard</h1>

            <div class="auto-style2" style="width: 50%; margin: 0 auto">
                <h4>
                    <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>&nbsp;Top 10 recycler </h4>
            </div>

            <div style="border: 5px solid green; width: 55%; margin: 0 auto; border-radius: 20px; background-color: #e9fce9">
                <div class="auto-style2" style="border: 1px solid black; width: 90%; margin: 5% auto; border-left: hidden; border-right: hidden">
                    <asp:LinkButton ID="linkbtn_alltime" runat="server" OnClick="linkbtn_alltime_Click">All time</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp; 
                     <asp:LinkButton ID="linkbtn_thismonth" runat="server" OnClick="linkbtn_thismonth_Click">This month</asp:LinkButton>&nbsp&nbsp;&nbsp;&nbsp;               
                     <br />
                </div>

                <asp:Panel ID="userAlltimePanel" runat="server">
                    <table style="width: 50%; margin: 0 auto;">
                        <tr>
                            <td colspan="2" class="auto-style2">
                                <asp:Image ID="Image4" runat="server" Height="60px" Width="60px" CssClass="image" />
                                <br />
                                <asp:Label ID="lbl_name" runat="server" Text="Label"></asp:Label>
                                <br />
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">View my activity</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan='2' class="auto-style2">Points available: 
                            <strong>
                                <asp:Label ID="Label17" runat="server" Text="Label" CssClass="auto-style4"></asp:Label>
                            </strong>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2" style="background-color: white;">Rank<br />
                                <strong style="color: pink">
                                    <asp:Label ID="lbl_QRrank" runat="server" Text="-" CssClass="auto-style4"></asp:Label>
                                </strong>
                            </td>
                            <td class="auto-style2" style="background-color: white;">Points<br />
                                <strong style="color: green">
                                    <asp:Label ID="lbl_QRpts" runat="server" Text="-" CssClass="auto-style4"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="userThismonthPanel" runat="server" Visible="false">
                    <table style="width: 50%; margin: 0 auto;">
                        <tr>
                            <td colspan="2" class="auto-style2">
                                <asp:Image ID="Image5" runat="server" Height="60px" Width="60px" CssClass="image" />
                                <br />
                                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                                <br />
                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click">View my activity</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="auto-style2">Total points left:<strong>
                                <asp:Label ID="Label13" runat="server" Text="Label" CssClass="auto-style4"></asp:Label>
                            </strong>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2" style="background-color: whitesmoke">Rank<br />
                                <strong style="color: pink">
                                    <asp:Label ID="Label11" runat="server" Text="-" CssClass="auto-style4"></asp:Label>
                                </strong>
                            </td>
                            <td class="auto-style2" style="background-color: whitesmoke">Points
                            <br />
                                <strong style="color: green">
                                    <asp:Label ID="Label12" runat="server" Text="-" CssClass="auto-style4"></asp:Label>
                                </strong>
                            </td>
                        </tr>

                    </table>
                </asp:Panel>

                <hr style="width: 90%; color: black" />
                <asp:Panel ID="Top3alltimePanel" runat="server">
                    <table style="width: 50%; margin: 0 auto">
                        <tr>
                            <td>&nbsp;</td>
                            <td rowspan="5">
                                <asp:DataList ID="DataList1" runat="server" HorizontalAlign="Center" OnItemDataBound="DataList1_ItemDataBound" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <table>
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
                                                    <strong>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                    </strong>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DataList ID="DataList2" runat="server" HorizontalAlign="Center" OnItemDataBound="DataList2_ItemDataBound" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td class="auto-style2">
                                                    <asp:Image ID="Image2" runat="server" CssClass="image" Height="110px" ImageUrl='<%# Eval("image", "~/Images/{0}") %>' Width="110px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                    <strong>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                    </strong>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                            <td>
                                <asp:DataList ID="DataList3" runat="server" HorizontalAlign="Center" OnItemDataBound="DataList3_ItemDataBound" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <table>
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
                                                    <strong>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                    </strong>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="height: 50px; background-color: silver; margin-top: 20px" class="auto-style2">
                                    <strong><span class="auto-style5">2nd</span> </strong>
                                </div>
                            </td>
                            <td>
                                <div style="height: 70px; background-color: gold; margin: 0 auto" class="auto-style2">
                                    <strong><span class="auto-style5">1st</span> </strong>
                                </div>
                            </td>
                            <td>
                                <div style="height: 50px; background-color: #cd7f32; margin-top: 20px" class="auto-style2">
                                    <strong><span class="auto-style5">3rd</span> </strong>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>



                <asp:Panel ID="Top3thismonthPanel" runat="server" Visible="false">
                    <table style="width: 50%; margin: 0 auto;">
                        <tr>
                            <td>&nbsp;</td>
                            <td rowspan="4">
                                <asp:DataList ID="DataList4" runat="server" HorizontalAlign="Center" OnItemDataBound="DataList4_ItemDataBound" RepeatDirection="Horizontal">
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
                                                <td class="auto-style2"><strong>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("mTotal") %>'></asp:Label>
                                                </strong></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DataList ID="DataList5" runat="server" HorizontalAlign="Center" OnItemDataBound="DataList5_ItemDataBound" RepeatDirection="Horizontal">
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
                                                    <asp:Image ID="Image2" runat="server" CssClass="image" Height="110px" ImageUrl='<%# Eval("image", "~/Images/{0}") %>' Width="110px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2"><strong>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("mTotal") %>'></asp:Label>
                                                </strong></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                            <td>
                                <asp:DataList ID="DataList6" runat="server" HorizontalAlign="Center" OnItemDataBound="DataList6_ItemDataBound" RepeatDirection="Horizontal">
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
                                                <td class="auto-style2"><strong>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("mTotal") %>'></asp:Label>
                                                </strong></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="auto-style2" style="height: 50px; background-color: silver; margin-top: 20px">
                                    <strong><span class="auto-style5">2nd</span> </strong>
                                </div>
                            </td>
                            <td>
                                <div class="auto-style2" style="height: 70px; background-color: gold; margin: 0 auto">
                                    <strong><span class="auto-style5">1st</span> </strong>
                                </div>
                            </td>
                            <td>
                                <div class="auto-style2" style="height: 50px; background-color: #cd7f32; margin-top: 20px">
                                    <strong><span class="auto-style5">3rd</span> </strong>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <br />


                <br />

                <asp:Panel ID="alltimePanel" runat="server" Style="margin-top: 15px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" GridLines="None" HorizontalAlign="Center">
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
                                <ItemStyle Width="250px" />
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="Total" HeaderText="Points">
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Points">
                                <ItemTemplate>
                                    <div class='progress'>
                                        <div class="progress-label">
                                            <%# Eval("Total") %>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <ItemStyle Width="290px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>


                <asp:Panel ID="thismonthPanel" runat="server" Visible="false">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound" GridLines="None" HorizontalAlign="Center" OnRowCommand="GridView2_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="DensePowerRank" HeaderText="Rank">
                                <HeaderStyle Font-Bold="True" />
                                <ItemStyle HorizontalAlign="Center" Font-Bold="True" />
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
                                <ItemStyle Width="250px" />
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="mTotal" HeaderText="Points">
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Points">
                                <ItemTemplate>
                                    <div class='progress'>
                                        <div class="progress-label">
                                            <%# Eval("mTotal") %>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <ItemStyle Width="290px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btn_claimpts" runat="server" ImageUrl="~/Images/reward.png" Width="50" Height="50" Visible="false" CommandName="select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
        <br />
    </div>
</asp:Content>