<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="E-vouchers.aspx.cs" Inherits="Our_FYPJ2019.E_vouchers" %>

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

        .panel {
            margin: auto;
            width: 40%;
        }

        .auto-style2 {
            text-align: center;
        }

        .Image4 {
            border-radius: 100px;
        }

        a {
            text-decoration: none;
        }

        .auto-style3 {
            width: 70%;
        }

        .linkbtn {
            border: 2px solid orange;
            background-color: orange;
            color: white;
        }
    </style>

    <div>
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>

        <table style="width: 50%; margin: 0 auto;">
            <tr>
                <td colspan="2" class="auto-style2">
                    <asp:Image ID="Image4" runat="server" Height="60px" Width="60px" CssClass="Image4" />
                    <br />
                    <asp:Label ID="lbl_name" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan='2' class="auto-style2" style="background-color: whitesmoke">
                    <strong>
                        <asp:Label ID="Label17" runat="server" Text="Label" CssClass="auto-style4"></asp:Label>
                        &nbsp;</strong>points available
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <div class="auto-style2" style="border: 1px solid black; width: 100%; margin: 0 auto; border-left: hidden; border-right: hidden" runat="server" id="nav">
                        <asp:LinkButton ID="linkbtn_catalog" runat="server" OnClick="linkbtn_catalog_Click">Catalog</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:LinkButton ID="linkbtn_ewallet" runat="server" OnClick="linkbtn_ewallet_Click">E-Wallet</asp:LinkButton>
                        <br />
                    </div>
                </td>
            </tr>
        </table>

        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CellSpacing="30" DataKeyField="id" OnItemCommand="DataList1_ItemCommand" HorizontalAlign="Center">
            <ItemTemplate>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("image", "~/Images/{0}") %>' Width="200px" Height="200px" CommandName="select" CommandArgument='<%# Eval("id")%>' BorderColor="Black" BorderWidth="2px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <strong>
                                <asp:Label ID="lbl_voucherName" runat="server" Text='<%# Eval("vouchersName") %>'></asp:Label>
                            </strong></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lbl_requiredPts" runat="server" Text='<%# Eval("requiredPts") %>'></asp:Label>
                            points</td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <br />

        <asp:Panel ID="redemptionPanel" runat="server" Visible="false" Style="margin-left: 35%">
            <table>
                <tr>
                    <td class="auto-style2">Total points:
                            <strong>
                                <asp:Label ID="lbl_totalpts" runat="server" Text="Label"></asp:Label>
                            </strong>
                        <br />
                    </td>
                </tr>

                <tr style="background-color: whitesmoke">
                    <td class="auto-style2">
                        <asp:Image ID="Image2" runat="server" Height="150px" Width="150px" /><br />
                        <strong style="font-size: 35px">
                            <asp:Label ID="lbl_voucherName3" runat="server" Text="Label"></asp:Label>
                        </strong>
                        <br />
                        <asp:Label ID="lbl_voucherPoints" runat="server" Text="Label"></asp:Label>&nbsp;points each<br />
                        <br />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">Points required to Redeem:
                                            <strong>
                                                <asp:Label ID="lbl_ptsRequired" runat="server" Text="Label"></asp:Label>
                                            </strong>
                        <br />
                        Points balance after Redemption:
                             <strong>
                                 <asp:Label ID="lbl_ptsLeft" runat="server" Text="Label"></asp:Label>
                             </strong>
                        <br />
                        <br />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btn_minus" runat="server" OnClick="btn_minus_Click" Text="-" />
                        <asp:TextBox ID="tb_quantity" runat="server" OnTextChanged="tb_quantity_TextChanged" Text="1" AutoPostBack="True" Width="10%" Min="2" onkeypress="restrictMinus(event);"></asp:TextBox>
                        <asp:Button ID="btn_add" runat="server" OnClick="btn_add_Click" Text="+" />
                        <br />
                        <asp:Label ID="lbl_error" runat="server" Text="Please enter a valid value" ForeColor="Red" Visible="false"></asp:Label>
                        <br />
                        <asp:Button ID="btn_redeem" runat="server" Text="Redeem Now" Style="width: 350px; height: 40px; border: none" OnClick="btn_redeem_Click" OnClientClick="return confirm('Upon confirmation, no refund of e-voucher or exchange for other items is allowed. Do you wish to proceed?')" />
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <%-- <asp:Panel ID="redemptionPanel" runat="server" Visible="false" Style="margin-left: 35%">
                <table>
                    <tr>
                        <td class="auto-style2">Total points:
                            <strong>
                                <asp:Label ID="lbl_totalpts" runat="server" Text="Label"></asp:Label>
                            </strong>
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style2">
                            <asp:Image ID="Image2" runat="server" Height="150px" Width="150px" />
                            <strong style="font-size: 35px">
                                <br />
                                <asp:Label ID="lbl_voucherName3" runat="server" Text="Label"></asp:Label></strong></td>
                    </tr>

                    

                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lbl_voucherPoints" runat="server" Text="Label"></asp:Label>
                            &nbsp; points each</td>
                    </tr>

                    <tr>
                        <td class="auto-style2">Points required to Redeem: <strong>
                            <asp:Label ID="lbl_ptsRequired" runat="server" Text="Label"></asp:Label>
                        </strong>
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style2">Points balance after Redemption: <strong>
                            <asp:Label ID="lbl_ptsLeft" runat="server" Text="Label"></asp:Label>
                        </strong></td>
                    </tr>

                    <tr>
                        <td class="auto-style2">
                            <asp:Button ID="btn_minus" runat="server" OnClick="btn_minus_Click" Text="-" />
                            <asp:TextBox ID="tb_quantity" runat="server" OnTextChanged="tb_quantity_TextChanged" Text="1" AutoPostBack="True" Width="10%"></asp:TextBox>
                            <asp:Button ID="btn_add" runat="server" OnClick="btn_add_Click" Text="+" /></td>
                    </tr>

                    <tr>
                        <td class="auto-style2">
                            <asp:Button ID="btn_redeem" runat="server" Text="Redeem Now" Style="width: 350px; height: 40px; border: none" OnClick="btn_redeem_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>--%>

        <asp:Panel ID="redemptionSucessPanel" runat="server" Style="margin-left: 35%" Visible="false">
            <table>
                <tr>
                    <td colspan="2">
                        <h2 class="auto-style2">Redemption Successful</h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/success.png" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lbl_quantity" runat="server" Text="Label"></asp:Label>x
                            <asp:Label ID="lbl_voucherName2" runat="server" Text="Label"></asp:Label>
                        &nbsp;has been added into your wallet.</td>
                </tr>

                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>Quantity </td>
                    <td>
                        <asp:Label ID="lbl_quantity2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Completed</td>
                    <td>
                        <asp:Label ID="lbl_dateTime" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Redemption ID </td>
                    <td>
                        <asp:Label ID="lbl_redemptionID" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Balance points</td>
                    <td>
                        <asp:Label ID="lbl_balance" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Button ID="btn_eWallet" runat="server" OnClick="btn_eWallet_Click" Text="View E-wallet" Style="width: 100px; height: 40px; border: none; float: right" />
                    </td>
                </tr>
            </table>
        </asp:Panel>

       <asp:Panel ID="eWalletPanel" runat="server" Visible="false">
            <asp:DataList ID="DataList2" runat="server" CellSpacing="30" HorizontalAlign="Center" Width="700px" OnItemDataBound="DataList2_ItemDataBound">
                <ItemTemplate>

                    <table class="auto-style1" style="border: 1px solid black; margin-bottom:20px">
                        <tr>
                            <td colspan="2" class="auto-style2" style="background-color: whitesmoke">
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("DateDiff") %>'></asp:Label>
                                &nbsp;days left
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2" rowspan="2" style="width: 30%">
                                <asp:Image ID="Image3" runat="server" Height="200px" ImageUrl='<%# Eval("image", "~/Images/{0}") %>' Width="200px" />
                            </td>
                            <td style="padding: 20px" class="auto-style3">
                                <strong>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>x
                              <asp:Label ID="Label1" runat="server" Text='<%# Eval("vouchersName") %>'></asp:Label>
                                </strong>
                                <br />
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("requiredPts") %>'></asp:Label>
                                points ||
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("vouchersName") %>'></asp:Label>
                                <br></br>
                                <br></br>
                                Expiry date:
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ExpiryDate", "{0:dd MMM yyyy}") %>'></asp:Label>
                                <br></br>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <%--<asp:DataList ID="DataList2" runat="server" CellSpacing="30" HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style2" style="background-color: whitesmoke">
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("DateDiff") %>'></asp:Label>
                                    &nbsp;days left</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Image ID="Image3" runat="server" Height="200px" ImageUrl='<%# Eval("image", "~/Images/{0}") %>' Width="200px" BorderColor="Black" BorderWidth="2px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <strong>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>
                                        x&nbsp;</strong> <strong>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("vouchersName") %>'></asp:Label>
                                        </strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Expires&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("ExpiryDate", "{0:dd MMM yyyy}") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>--%>
        </asp:Panel>

        <%--  <table style="width: 50%; margin: 0 auto">
                <tr>
                    <td>
                        <asp:Panel ID="voucherPanel" runat="server" Visible="false">
                            <table style="width: 90%; margin: 0 auto">
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="lbl_header" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="lbl_voucherName0" runat="server" Text="Label"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td class="auto-style2">
                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Panel ID="transactionPanel" runat="server" Visible="false">
                            <table style="width: 90%; margin: 0 auto">
                                <tr>
                                    <td>
                                        <div class="auto-style2">
                                            Please complete your transaction in
                                <br />
                                        </div>
                                        <h1 class="auto-style2">
                                            <asp:Label ID="lbl_timer" runat="server" Text="120"></asp:Label></h1>
                                        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Button ID="btn_done" runat="server" Text="Done" OnClick="btn_done_Click" /></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Panel ID="completedPanel" runat="server" Visible="false">
                            <table style="width: 90%; margin: 0 auto">
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="lbl_dateTime" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3 class="auto-style2">
                                            <asp:Label ID="Label3" runat="server" Text="USED"></asp:Label></h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_close" runat="server" Text="Close" /></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>--%>
    </div>


    <%--prevent user from entering negative sign --%>
    <script>
        function restrictMinus(e) {
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode != null) {
                if (inputKeyCode == 45) e.preventDefault();
            }
        }
    </script>
</asp:Content>
