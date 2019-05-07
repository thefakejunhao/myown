<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Our_FYPJ2019.BuyerProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

    <style type="text/css">
        body {
            font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
            font-size: 16px;
            line-height: 1.5;
            background-color: whitesmoke;
        }

        .Image1 {
            border-radius: 100px;
        }

        .vl {
            border-left: 1px solid black;
            height: 300px;
        }

        .button {
            background-color: #4CAF50;
            color: #ffffff;
            border: none;
            padding: 10px 20px;
            font-size: 17px;
            cursor: pointer;
        }
    </style>


    <div>
        <div style="border: 1px solid black; width: 55%; margin:0 auto; border-radius: 20px; background-color: white">
             <table style="margin: 10px 15px 10px 15px;">
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" Height="150px" Width="150px" CssClass="Image1" />
                        <br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td>
                        <p>
                            <asp:Label ID="lbl_username" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lbl_buyer" runat="server" Text="Label" Visible="false"></asp:Label>
                        </p>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>

                <%--  <div class="vl" style="float: left; margin-left: 4%; margin-right: 2%"></div>--%>

                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:Label ID="lbl_username2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Gender:</td>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>Date of Birth:</td>
                    <td>
                        <asp:TextBox ID="tb_DOB" runat="server" TextMode="Date"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Date cannot be greater than today's date" ControlToValidate="tb_DOB" Font-Bold="True" ForeColor="Red" MaximumValue="2018-12-31"></asp:RangeValidator>
                    </td>
                </tr>
                <tr runat="server" visible="false" id="business">
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label>
                        <asp:Label ID="lbl_companyName" runat="server" Text="Company Name:" Visible="False"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="tb_companyName" runat="server" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_companyName" Display="Dynamic" ErrorMessage="Company name is mandatory" ForeColor="Red" Font-Bold="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>Address:</td>
                    <td>
                        <asp:TextBox ID="tb_Address" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Postal Code:</td>
                    <td>
                        <asp:TextBox ID="tb_postalCode" runat="server"></asp:TextBox>
                        Unit No:
                        <asp:TextBox ID="tb_unitno" runat="server" Width="20%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please enter a valid postal code" ForeColor="Red" ValidationExpression="^(\d{6})$" ControlToValidate="tb_postalCode" Font-Bold="True" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please enter a valid unit number" ForeColor="Red" ValidationExpression="^[0-9]{2}(-)[0-9]{3}$" ControlToValidate="tb_unitno" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        Email:</td>
                    <td>
                        <asp:TextBox ID="tb_Email" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_Email" Display="Dynamic" ErrorMessage="Email is mandatory" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tb_email" Display="dynamic" ErrorMessage="Please enter a valid email address" Font-Bold="true" ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                        <asp:Label ID="Label2" runat="server" Text="Email is already taken" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                    </td>
                </tr>
               
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        Mobile Phone:
                    </td>
                    <td>
                        <asp:Label ID="lbl_mobileNo" runat="server" Text="Label"></asp:Label>
                        <asp:LinkButton ID="linkbtn_edit" runat="server" CausesValidation="False" OnClick="linkbtn_edit_Click" style="text-decoration:none">Change</asp:LinkButton>
                        <asp:TextBox ID="tb_mobileNo" runat="server" Visible="False"></asp:TextBox>
                        <asp:LinkButton ID="linkbtn_verify" runat="server" OnClick="linkbtn_verify_Click" ValidationGroup="mobileno" Visible="False" style="text-decoration:none">Verify</asp:LinkButton>
                        <span id="sent" runat="server" visible="false"><i class="fa fa-check" style="font-size: 20px; color: green"></i>
                            <asp:Label ID="lbl_send" runat="server" Text="Code sent"></asp:Label>
                        </span>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_mobileno" Display="Dynamic" ErrorMessage="Please enter a valid mobile number" Font-Bold="true" ForeColor="Red" ValidationExpression="^[9|8][0-9]{7}$" ValidationGroup="mobileno"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_mobileNo" Display="Dynamic" ErrorMessage="Mobile phone is mandatory" Font-Bold="True" ForeColor="Red" ValidationGroup="mobileno"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_code" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="code" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tb_code" runat="server" placeholder="4-digit verification code" Visible="false"></asp:TextBox>
                        <asp:LinkButton ID="linkbtn_save" runat="server" OnClick="linkbtn_save_Click" ValidationGroup="code" Visible="false" style="text-decoration:none">Save</asp:LinkButton>
                        <br />
                        <asp:Label ID="lbl_error" runat="server" Font-Bold="True" ForeColor="Red" Text="Failed to authenticate. Code is invalid" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" Style="float: right" CssClass="button" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
