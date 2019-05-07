<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Our_FYPJ2019.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style type="text/css">
        body {
            font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
            font-size: 16px;
            line-height: 1.5;
        }

        .panel {
            background-color: white;
            opacity: 0.90;
            margin: auto;
            border-radius: 15px;
            width: 35%;
        }

        .input-container {
            display: -ms-flexbox; /* IE10 */
            display: flex;
            width: 100%;
            margin-bottom: 10px;
        }

        .input-field {
            width: 100%;
            padding: 10px;
            outline: none;
        }

        .icon {
            padding: 10px;
            background: dodgerblue;
            color: white;
            min-width: 50px;
            text-align: center;
        }

        .button {
            background-color: #4CAF50;
            color: #ffffff;
            border: none;
            padding: 10px 20px;
            font-size: 17px;
            cursor: pointer;
        }

        #message {
            display: none;
            background: #f1f1f1;
            color: #000;
            padding: 10px;
        }

            #message p {
                padding-left: 35px;
            }

        .valid {
            color: green;
        }

            .valid:before {
                position: relative;
                left: -35px;
                content: "✔";
            }

        .invalid {
            color: red;
        }

            .invalid:before {
                position: relative;
                left: -35px;
                content: "✖";
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="panel">
                <tr>
                    <td>Change Your Password
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="input-container">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_password" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                            <i class="fa fa-key icon"></i>
                            <asp:TextBox ID="tb_password" runat="server" TextMode="Password" placeholder="New Password" CssClass="input-field"></asp:TextBox>
                        </div>
                    </td>
                </tr>

                <tr>
                    <td>
                        <div id="message">
                            <h3>Password must contain the following:</h3>
                            <p id="letter" class="invalid">A <b>lowercase</b> letter</p>
                            <p id="capital" class="invalid">A <b>capital (uppercase)</b> letter</p>
                            <p id="number" class="invalid">A <b>number</b></p>
                            <p id="length" class="invalid">Minimum <b>8 characters</b></p>
                        </div>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tb_password" Display="Dynamic" ErrorMessage="Passwords must be at least 8 characters and contain upper case (A-Z), lower case (a-z) and number (0-9)." Font-Bold="true" ForeColor="Red" ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <div class="input-container">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_cpassword" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                            <i class="fa fa-key icon"></i>
                            <asp:TextBox ID="tb_cpassword" runat="server" TextMode="Password" placeholder="Confirm Password" CssClass="input-field"></asp:TextBox>
                        </div>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tb_password" ControlToValidate="tb_cpassword" ErrorMessage="Password do not match" Font-Bold="True" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btn_submit" runat="server" Text="Set new password" OnClick="btn_submit_Click" Style="float: right" CssClass="button" />
                    </td>
                </tr>
            </table>

        </div>
    </form>

    <%--    Password strength--%>
    <script>
        var myInput = document.getElementById("tb_password");
        var letter = document.getElementById("letter");
        var capital = document.getElementById("capital");
        var number = document.getElementById("number");
        var length = document.getElementById("length");

        // When the user clicks on the password field, show the message box
        myInput.onfocus = function () {
            document.getElementById("message").style.display = "block";
        }

        // When the user clicks outside of the password field, hide the message box
        myInput.onblur = function () {
            document.getElementById("message").style.display = "none";
        }

        // When the user starts to type something inside the password field
        myInput.onkeyup = function () {
            // Validate lowercase letters
            var lowerCaseLetters = /[a-z]/g;
            if (myInput.value.match(lowerCaseLetters)) {
                letter.classList.remove("invalid");
                letter.classList.add("valid");
            } else {
                letter.classList.remove("valid");
                letter.classList.add("invalid");
            }

            // Validate capital letters
            var upperCaseLetters = /[A-Z]/g;
            if (myInput.value.match(upperCaseLetters)) {
                capital.classList.remove("invalid");
                capital.classList.add("valid");
            } else {
                capital.classList.remove("valid");
                capital.classList.add("invalid");
            }

            // Validate numbers
            var numbers = /[0-9]/g;
            if (myInput.value.match(numbers)) {
                number.classList.remove("invalid");
                number.classList.add("valid");
            } else {
                number.classList.remove("valid");
                number.classList.add("invalid");
            }

            // Validate length
            if (myInput.value.length >= 8) {
                length.classList.remove("invalid");
                length.classList.add("valid");
            } else {
                length.classList.remove("valid");
                length.classList.add("invalid");
            }
        }
    </script>
</body>
</html>
