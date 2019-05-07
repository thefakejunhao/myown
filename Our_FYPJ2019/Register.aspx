<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Our_FYPJ2019.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        body {
            font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
            font-size: 16px;
            line-height: 1.5;
            background-image: url(../Images/background.jpg);
            background-size: cover;
            background-repeat: no-repeat;
            background-size: 100%;
            background-color: whitesmoke;
        }

        .panel {
            background-color: white;
            opacity: 0.90;
            margin: 5% 5% auto;
            border-radius: 15px;
            width: 36%;
            float: left;
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

        .auto-style1 {
            text-align: center;
        }

        .btn_next {
            background-color: #4CAF50;
            color: #ffffff;
            border: none;
            padding: 10px 20px;
            font-size: 17px;
            cursor: pointer;
        }

        #message2 {
            display: none;
            background: #f1f1f1;
            color: #000;
            padding: 10px;
        }

            #message2 p {
                padding-left: 35px;
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

        .button {
            border: none;
            height: 50px;
            width: 150px;
            font-size: 1em;
            background-color: transparent;
        }

        .afterclick {
            border: none;
            height: 50px;
            width: 150px;
            font-size: 1em;
            background-color: whitesmoke;
        }

        .auto-style3 {
            text-align: center;
            margin-left: 30px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="float: left; width: 45%; margin: 3% auto auto 5%;">
                <tr>
                    <td>
                        <h1>Don't know what to do with your recyclable materials? </h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="border-radius: 50%; width: 130px; height: 130px; border: 10px solid orange; float: left" class="auto-style3">
                            <div style="margin-top: 40px; font-size: 30px" class="auto-style1"><strong>Join</strong></div>
                        </div>


                        <div style="border-radius: 50%; width: 130px; height: 130px; border: 10px solid orange; float: left" class="auto-style3">
                            <div style="margin-top: 40px; font-size: 30px" class="auto-style1"><strong>Post</strong></div>
                        </div>

                        <div style="border-radius: 50%; width: 130px; height: 130px; border: 10px solid orange; float: left" class="auto-style3">
                            <div style="margin-top: 30px; font-size: 25px" class="auto-style1"><strong>Earn incentives</strong></div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h2 style="margin-left: 10px"><i class="fa fa-check" style="font-size: 48px; color: green"></i>
                            Clear your garbage
                        </h2>
                        <h2 style="margin-left: 10px">
                            <i class="fa fa-check" style="font-size: 48px; color: green"></i>
                            Recycle Your stuffs
                        </h2>
                        <h2 style="margin-left: 10px">
                            <i class="fa fa-check" style="font-size: 48px; color: green"></i>
                            Save the earth
                        </h2>
                    </td>
                </tr>
            </table>

            <div class="panel">
                <asp:Panel ID="RegisterAsPanel" runat="server">
                    <h1 style="text-align: center">Register as:</h1>
                    <div style="text-align: center">
                        <asp:Button ID="btn_buyer" runat="server" Text="Buyer" OnClick="btn_buyer_Click" CausesValidation="False" CssClass="button" />
                        <asp:Button ID="btn_seller" runat="server" Text="Seller" OnClick="btn_seller_Click" CausesValidation="False" CssClass="button" />
                    </div>
                </asp:Panel>

                <br />

                <asp:Panel ID="SellerPanel" runat="server" Visible="false">
                    <table style="margin: 0 auto; width: 80%">
                        <tr>
                            <td>
                                <div class="input-container">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_email" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <i class="fa fa-envelope icon"></i>
                                    <asp:TextBox ID="tb_email" runat="server" placeholder="Email" CssClass="input-field"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tb_email" Display="dynamic" ErrorMessage="Please enter a valid email address" Font-Bold="true" ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                                <asp:Label ID="Label2" runat="server" Text="Email is already taken" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="input-container">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tb_username" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <i class="fa fa-user icon"></i>
                                    <asp:TextBox ID="tb_username" runat="server" placeholder="Username" CssClass="input-field"></asp:TextBox>
                                </div>
                                <asp:Label ID="Label1" runat="server" Text="Username is already taken" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="input-container">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tb_password" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <i class="fa fa fa-key icon"></i>
                                    <asp:TextBox ID="tb_password" runat="server" TextMode="Password" placeholder="Password" CssClass="input-field"></asp:TextBox>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tb_cpassword" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <i class="fa fa fa-key icon"></i>
                                    <asp:TextBox ID="tb_cpassword" runat="server" TextMode="Password" placeholder="Confirm Password" CssClass="input-field"></asp:TextBox>
                                </div>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password do not match" ControlToCompare="tb_password" ForeColor="Red" Font-Bold="true" ControlToValidate="tb_cpassword" Display="Dynamic"></asp:CompareValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="input-container">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tb_mobileno" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <i class="fa fa-mobile icon"></i>
                                    <asp:TextBox ID="tb_mobileno" runat="server" placeholder="Mobile Number" CssClass="input-field"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid mobile number" ControlToValidate="tb_mobileno" ValidationExpression="^[9|8][0-9]{7}$" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr>
                            <td colspan="2">By creating an account you agree to our <a href="#">Terms & Privacy.</a>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" style="text-align: right">
                                <asp:Button ID="btn_next2" runat="server" Text="Next" OnClick="btn_next2_Click" CssClass="btn_next" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" style="text-align: center">Already have an account? <a href="Login.aspx" style="text-decoration: none">Login now.</a></td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="BuyerPanel" runat="server" Visible="false">
                    <table style="margin: 0 auto">
                        <tr>
                            <td>
                                <div class="input-container">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_bemail" Display="Dynamic" ErrorMessage="*" Font-Bold="False" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <i class="fa fa-envelope icon"></i>
                                    <asp:TextBox ID="tb_bemail" runat="server" placeholder="Email" CssClass="input-field"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tb_bemail" Display="dynamic" ErrorMessage="Please enter a valid email address" Font-Bold="true" ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                                <asp:Label ID="Label4" runat="server" Font-Bold="true" ForeColor="Red" Text="Email is already taken" Visible="false"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="input-container">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tb_busername" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <i class="fa fa-user icon"></i>
                                    <asp:TextBox ID="tb_busername" placeholder="Username" runat="server" CssClass="input-field"></asp:TextBox>
                                </div>
                                <asp:Label ID="Label5" runat="server" Font-Bold="true" ForeColor="Red" Text="Username is already taken" Visible="false"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="input-container">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tb_bpassword" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <i class="fa fa-key icon"></i>
                                    <asp:TextBox ID="tb_bpassword" runat="server" placeholder="Password" CssClass="input-field" TextMode="Password"></asp:TextBox>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div id="message2">
                                    <h3>Password must contain the following:</h3>
                                    <p id="letter2" class="invalid">A <b>lowercase</b> letter</p>
                                    <p id="capital2" class="invalid">A <b>capital (uppercase)</b> letter</p>
                                    <p id="number2" class="invalid">A <b>number</b></p>
                                    <p id="length2" class="invalid">Minimum <b>8 characters</b></p>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="tb_bpassword" Display="Dynamic" ErrorMessage="Passwords must be at least 8 characters and contain upper case (A-Z), lower case (a-z) and number (0-9)." Font-Bold="true" ForeColor="Red" ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="input-container">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tb_bcpassword" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <i class="fa fa-key icon"></i>
                                    <asp:TextBox ID="tb_bcpassword" runat="server" placeholder="Confirm Password" CssClass="input-field" TextMode="Password"></asp:TextBox>
                                </div>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="tb_bpassword" ControlToValidate="tb_bcpassword" ErrorMessage="Password do not match" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="input-container">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tb_bmobileNo" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <i class="fa fa-mobile icon"></i>
                                    <asp:TextBox ID="tb_bmobileNo" runat="server" placeholder="Mobile Number" CssClass="input-field"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tb_bmobileNo" Display="Dynamic" ErrorMessage="Please enter a valid mobile number" Font-Bold="true" ForeColor="Red" ValidationExpression="^[9|8][0-9]{7}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="RadioButtonList1" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <div style="margin-left: 10px">
                                    How do you intend to use this platform?<br />
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                        <asp:ListItem>Business</asp:ListItem>
                                        <asp:ListItem>Personal</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Panel ID="BusinessPanel" runat="server" Visible="false">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tb_businessName" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                Please enter your full legal business name:</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="input-container">
                                                    <i class="fa fa-id-card-o icon"></i>
                                                    <asp:TextBox ID="tb_businessName" runat="server" CssClass="input-field" placeholder="Business Name"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="RadioButtonList2" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                Select an option to receive the OTP to verify your account :<asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>SMS</asp:ListItem>
                                                    <asp:ListItem>Email</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-left: 10px">By creating an account you agree to our <a href="#">Terms & Privacy.</a></div>
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right">
                                <asp:Button ID="btn_next3" runat="server" Text="Next" OnClick="btn_next3_Click" CssClass="btn_next" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">Already have an account? <a href="Login.aspx" style="text-decoration: none">Login now.</a></td>
                        </tr>
                    </table>
                </asp:Panel>


                <asp:Panel ID="EmailVerificationPanel" runat="server" Visible="false">
                    <table style="margin: 0 auto; width: 85%">
                        <tr>
                            <td class="auto-style1">Please verify your identity by entering the OTP sent to
                     <strong>
                         <asp:Label ID="lbl_Email" runat="server" Text="Label"></asp:Label></strong>.
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <div class="input-container">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red" Font-Bold="true" ControlToValidate="tb_code"></asp:RequiredFieldValidator>
                                    <i class="fa fa-envelope icon"></i>
                                    <asp:TextBox ID="tb_code" runat="server" CssClass="input-field"></asp:TextBox>
                                </div>
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Red" Text="Failed to authenticate. Code is invalid" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Didn&#39;t get code yet?
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Style="text-decoration: none">Resend OTP</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: right">
                                    <asp:Button ID="btn_verify" runat="server" OnClick="btn_verify_Click" Text="Verify" CssClass="btn_next" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="SMSVerificationPanel" runat="server" Visible="False">
                    <table style="margin: 0 auto; width: 85%">
                        <tr>
                            <td class="auto-style1">Please verify your identity by entering the OTP sent to <strong>
                                <asp:Label ID="lbl_mobileNo" runat="server" Text="Label"></asp:Label>
                            </strong>.
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <div class="input-container">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ForeColor="Red" Font-Bold="true" ControlToValidate="tb_code2"></asp:RequiredFieldValidator>
                                    <i class="fa fa-mobile-phone icon"></i>
                                    <asp:TextBox ID="tb_code2" runat="server" CssClass="input-field"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Red" Text="Failed to authenticate. Code is invalid" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Didn&#39;t get code yet?
                    <asp:LinkButton ID="linkbtn_sms" runat="server" Style="text-decoration: none">Resend OTP</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: right">
                                    <asp:Button ID="btn_verify2" runat="server" OnClick="btn_verify2_Click" Text="Verify" CssClass="btn_next" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
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

    <script>
        var myInput2 = document.getElementById("tb_bpassword");
        var letter2 = document.getElementById("letter2");
        var capital2 = document.getElementById("capital2");
        var number2 = document.getElementById("number2");
        var length2 = document.getElementById("length2");

        // When the user clicks on the password field, show the message box
        myInput2.onfocus = function () {
            document.getElementById("message2").style.display = "block";
        }

        // When the user clicks outside of the password field, hide the message box
        myInput2.onblur = function () {
            document.getElementById("message2").style.display = "none";
        }

        // When the user starts to type something inside the password field
        myInput2.onkeyup = function () {
            // Validate lowercase letters
            var lowerCaseLetters2 = /[a-z]/g;
            if (myInput2.value.match(lowerCaseLetters2)) {
                letter2.classList.remove("invalid");
                letter2.classList.add("valid");
            } else {
                letter2.classList.remove("valid");
                letter2.classList.add("invalid");
            }

            // Validate capital letters
            var upperCaseLetters2 = /[A-Z]/g;
            if (myInput2.value.match(upperCaseLetters2)) {
                capital2.classList.remove("invalid");
                capital2.classList.add("valid");
            } else {
                capital2.classList.remove("valid");
                capital2.classList.add("invalid");
            }

            // Validate numbers
            var numbers2 = /[0-9]/g;
            if (myInput2.value.match(numbers2)) {
                number2.classList.remove("invalid");
                number2.classList.add("valid");
            } else {
                number2.classList.remove("valid");
                number2.classList.add("invalid");
            }

            // Validate length
            if (myInput2.value.length >= 8) {
                length2.classList.remove("invalid");
                length2.classList.add("valid");
            } else {
                length2.classList.remove("valid");
                length2.classList.add("invalid");
            }
        }
    </script>
</body>
</html>
