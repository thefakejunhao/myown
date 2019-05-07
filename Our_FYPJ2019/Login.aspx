<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Our_FYPJ2019.Login1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <style type="text/css">
        body {
            font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
            font-size: 16px;
            line-height: 1.5;
            background-image: url(../Images/bacskground.jpg);
            background-size: cover;
            background-repeat: no-repeat;
            background-size: 100%;
            background-color: whitesmoke;
        }

        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content */
        .modal-content {
            position: relative;
            background-color: #fefefe;
            margin: auto;
            padding: 0;
            border: 1px solid #888;
            width: 50%;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
            -webkit-animation-name: animatetop;
            -webkit-animation-duration: 0.4s;
            animation-name: animatetop;
            animation-duration: 0.4s;
        }

        /* Add Animation */
        @-webkit-keyframes animatetop {
            from {
                top: -300px;
                opacity: 0;
            }

            to {
                top: 0;
                opacity: 1;
            }
        }

        @keyframes animatetop {
            from {
                top: -300px;
                opacity: 0;
            }

            to {
                top: 0;
                opacity: 1;
            }
        }

        /* The Close Button */
        .close {
            color: white;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

        .close:hover,
        .close:focus {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }

        .modal-header {
            padding: 2px 16px;
            /*background-color: dodgerblue;*/
            color: black;
        }

        .modal-body {
            padding: 2px 16px;
        }

        .auto-style2 {
            float: right;
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

        .panel {
            background-color: white;
            opacity: 0.90;
            margin: 5% 5% auto;
            border-radius: 15px;
            width: 36%;
            float: left;
        }

        .button {
            background-color: #4CAF50;
            color: #ffffff;
            border: none;
            padding: 10px 20px;
            font-size: 17px;
            cursor: pointer;
        }

        .auto-style3 {
            text-align: center;
            margin-left: 30px;
        }

        .fasocialmedia {
            padding: 20px;
            font-size: 30px;
            width: 30px;
            text-align: center;
            text-decoration: none;
            margin: 5px 2px;
            border-radius: 50%;
        }

        .fa-facebook {
            background: #3B5998;
            color: white;
        }

        .fa-twitter {
            background: #55ACEE;
            color: white;
        }

        .fa-instagram {
            background: radial-gradient(circle at 33% 100%, #fed373 4%, #f15245 30%, #d92e7f 62%, #9b36b7 85%, #515ecf);
            color: white;
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
                <h1 style="text-align: center">Login:</h1>
                <table style="margin: 0 auto; width: 80%">
                    <tr>
                        <td>
                            <div class="input-container" style="margin-top: 10px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_username" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <i class="fa fa-user icon"></i>
                                <asp:TextBox ID="tb_username" runat="server" CssClass="input-field" placeholder="Username"></asp:TextBox>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <div class="input-container">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_password" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <i class="fa fa-key icon"></i>
                                <asp:TextBox ID="tb_password" runat="server" TextMode="Password" CssClass="input-field" placeholder="Password"></asp:TextBox>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <input type="checkbox" onchange="document.getElementById('tb_password').type = this.checked ? 'text' : 'password'" />Show password</td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <span style="margin-bottom: 2%" class="auto-style2">
                                <asp:HyperLink ID="HyperLink1" runat="server">Forgot your password?</asp:HyperLink>

                                <!-- The Modal -->
                                <div id="myModal" class="modal">

                                    <!-- Modal content -->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <span class="close">&times;</span>
                                            <h1 style="text-align: center">Forgot your password?</h1>
                                        </div>

                                        <div class="modal-body">
                                            <p style="text-align: center">Don&#39;t worry! Just fill in your email and we&#39;ll help you reset your password.</p>
                                            <div style="margin: 30px 20%" class="input-container">
                                                <i class="fa fa-envelope icon"></i>
                                                <asp:TextBox ID="tb_femail" runat="server" Height="23px" Width="45%" CssClass="input-field" placeholder="Email"></asp:TextBox>
                                            </div>

                                            <p style="text-align: center">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid email address" ForeColor="Red" Font-Bold="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tb_femail"></asp:RegularExpressionValidator>
                                            </p>

                                            <p>
                                                <asp:Button ID="btn_Send" runat="server" Text="Send Email" OnClick="btn_Send_Click" Style="margin-left: 65%;" CausesValidation="false" CssClass="button" />
                                            </p>

                                            <p style="text-align: center;">
                                                <asp:Label ID="lbl_result" runat="server"></asp:Label>
                                            </p>
                                        </div>

                                    </div>
                                </div>
                            </span>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server" Text="Invalid username or password. Please try again!" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span id="captcha" style="margin-left: 100px; color: red" />
                            <div id="recaptcha" class="g-recaptcha" data-sitekey="6LdeV2UUAAAAADPBE5LXXCHnLSVZyyWRYjJflvNj"></div>
                            <asp:Label ID="lbl_msg" runat="server" Text="" ForeColor="Red" Font-Bold="true" class="msg-error error"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click" CssClass="button" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">Don't have an account? <a href="Register.aspx" style="text-decoration: none">Sign Up</a></td>
                    </tr>
                </table>
            </div>

            <%-- <footer style="clear: both; margin-left: 20%;">
                <br />
                <div style="float: left">
                    <h4>Contact us</h4>
                    <i class="fa fa-map-marker" style="font-size: 24px"></i>180 Ang Mo Kio Avenue 8,
                    569830
  <br />
                    <br />
                    <i class="fa fa-phone" style="font-size: 24px"></i>&nbsp;Tel: 65 12345678<br />
                    <i class="fa fa-fax" style="font-size: 24px"></i>&nbsp;Fax: 65 12345678<br />
                </div>

                <div style="float: left; margin-left: 10%; margin-right: 20%">
                    <h4>About the company</h4>
                    <a href="#" class="fa fa-facebook fasocialmedia"></a>
                    <a href="#" class="fa fa-twitter fasocialmedia"></a>
                    <a href="#" class="fa fa-instagram fasocialmedia"></a>
                    <br />
                    <br />
                    <br />
                </div>
            </footer>--%>
        </div>
    </form>

    <%-- <script src='https://www.google.com/recaptcha/api.js'></script>
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
    <script src="https://www.google.com/recaptcha/api.js?onload=renderRecaptcha&render=explicit" async defer></script>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>--%>

    <%-- <script type="text/javascript">
        function WebForm_OnSubmit() {
            var recaptcha = $("#g-recaptcha-response").val();
            if (recaptcha === "") {
                event.preventDefault();
                $("#lbl_msg").text("Please verify that you are not a robot.");
            }
        }
    </script>--%>

    <script>
        $('#btn_login').click(function () {
            var $captcha = $('#recaptcha'),
                response = grecaptcha.getResponse();

            if (response.length === 0) {
                event.preventDefault();
                $('.msg-error').text("Please verify that you are not a robot.");
                if (!$captcha.hasClass("error")) {
                    $captcha.addClass("error");
                }
            } else {
                $('.msg-error').text('');
                $captcha.removeClass("error");
            }
        })
    </script>

    <%-- <script>

        $('#btn_login').click(function () {
            var $captcha = $('#recaptcha'),
                response = grecaptcha.getResponse();

            if (response.length === 0) {
                $('.msg-error').text("reCAPTCHA is mandatory");
                if (!$captcha.hasClass("error")) {
                    $captcha.addClass("error");
                }
            } else {
                $('.msg-error').text('');
                $captcha.removeClass("error");
                alert('reCAPTCHA marked');
            }
        })
    </script>--%>

    <script>
        // Get the modal
        var modal = document.getElementById('myModal');

        // Get the button that opens the modal
        var btn = document.getElementById("HyperLink1");

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks the button, open the modal 
        btn.onclick = function () {
            modal.style.display = "block";
        }

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }


        //// When the user clicks anywhere outside of the modal, close it
        //window.onclick = function (event) {
        //    if (event.target == modal) {
        //        modal.style.display = "none";
        //    }
        //}

    </script>


</body>
</html>
