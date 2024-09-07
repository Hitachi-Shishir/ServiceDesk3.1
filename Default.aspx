<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hitachi System -Service Desk</title>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet" />


    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous" />
    <%--<link rel="stylesheet" href="LoginCSS/style.css"/>
	 <link rel="stylesheet" href="../dist/css/adminlte.min.css"/>--%>

    
    <style type="text/css">
        .modal.modalPopup {
            top: 0 !important;
            left: 0 !important;
            display: block;
        }

        .modalBackground {
            background-color: #000;
            opacity: 0.5;
        }

        .form-check {
            display: inline-block;
            vertical-align: middle;
        }

        label[for="chkRemb2FA"] {
            display: inline-block;
            vertical-align: middle;
            margin-left: 5px; /* Adjust spacing as needed */
        }
        

  

        /* Background when checked */
        input[type="checkbox"]:checked {
            background-color: #4caf50 !important; /* Green when checked */
            border: 2px solid #4caf50 !important;
        }

     
    </style>
    <style>
        * {
            padding: 0;
            margin: 0;
            color: #1a1f36;
            box-sizing: border-box;
            word-wrap: break-word;
            font-family: -apple-system,BlinkMacSystemFont,Segoe UI,Roboto,Helvetica Neue,Ubuntu,sans-serif;
        }

        .zoom:hover {
            transform: scale(1.5); /* (150% zoom - Note: if the zoom is too large, it will go outside of the viewport) */
        }

        .grid-container {
            display: grid;
            /* grid-template-columns: auto auto ; */
            grid-template-columns: 60% auto;
        }
    .footer {
    position: fixed;
    bottom: 0;
    left: 0;
    width: 100%;
    padding: 10px 0; /* Padding for spacing */
    text-align: center;
    font-size: 0.875em; /* Font size for the footer text */
    color: #6c757d; /* Text color (adjust as needed) */
}

/* Main content styling */
main {
    padding-bottom: 50px; /* Space for footer height to avoid overlap */
}

        body {
            min-height: 100%;
            background-color: #ffffff;
        }


        h1 {
            letter-spacing: -1px;
        }

        a {
            color: #e60027;
            text-decoration: unset;
        }

            a:hover {
                color: #363636;
                /* text-decoration: unset; */
            }

        .login-root {
            background: #fff;
            display: flex;
            width: 100%;
            min-height: 100vh;
            overflow: hidden;
        }

        .loginbackground {
            min-height: 692px;
            position: fixed;
            bottom: 0;
            left: 0;
            right: 0;
            top: 0;
            z-index: 0;
            overflow: hidden;
        }

        .flex-flex {
            display: flex;
        }

        .align-center {
            align-items: center;
        }

        .center-center {
            align-items: center;
            justify-content: center;
        }

        .box-root {
            box-sizing: border-box;
        }

        .flex-direction--column {
            -ms-flex-direction: column;
            flex-direction: column;
        }

        .loginbackground-gridContainer {
            display: grid;
            grid-template-columns: [start] 1fr [left-gutter] repeat(16, 86.6px) [left-gutter] 1fr [end];
            grid-template-rows: [top] 1fr [top-gutter] repeat(8, 64px) [bottom-gutter] 1fr [bottom];
            justify-content: center;
            margin: 0 -2%; /* Check if this is necessary */
            transform: rotate(-12deg) skew(-12deg); /* Ensure this is desired */
        }

        .box-divider--light-all-2 {
            box-shadow: inset 0 0 0 2px #6161612a;
        }

        .box-background--blue {
            background-color: #e6002729;
        }

        .box-background--white {
            background-color: #f0f0f0;
        }

        .box-background--blue800 {
            background-color: #212d63;
        }

        .box-background--gray100 {
            background-color: #25212241;
        }

        .box-background--cyan200 {
            background-color: #5050504f;
        }

        .padding-top--64 {
            padding-top: 64px;
        }

        .padding-top--24 {
            /* padding-top: 24px; */
        }

        .padding-top--48 {
            padding-top: 48px;
        }

        .padding-bottom--24 {
            padding-bottom: 24px;
        }

        .padding-horizontal--48 {
            /* padding: 48px; */
        }

        .padding-bottom--15 {
            padding-bottom: 15px;
        }


        .flex-justifyContent--center {
            -ms-flex-pack: center;
            justify-content: center;
        }

        .formbg {
            margin: 0px auto;
            width: 100%;
            max-width: 850px;
            background: white;
            border-radius: 4px;
            box-shadow: rgba(172, 59, 51, 0.12) 0px 7px 14px 0px, rgba(0, 0, 0, 0.12) 0px 3px 6px 0px;
        }

        span {
            display: block;
            font-size: 20px;
            line-height: 28px;
            color: #e60027;
        }

        label {
            margin-bottom: 10px;
        }

        .reset-pass a, label {
            font-size: 14px;
            font-weight: 600;
            display: block;
        }

        .reset-pass > a {
            text-align: right;
            margin-bottom: 10px;
        }

        .grid--50-50 {
            display: grid;
            grid-template-columns: 50% 50%;
            align-items: center;
        }

        .field input {
            font-size: 16px;
            line-height: 28px;
            padding: 8px 16px;
            width: 100%;
            min-height: 44px;
            border: unset;
            border-radius: 4px;
            outline-color: rgb(84 105 212 / 0.5);
            background-color: rgb(255, 255, 255);
            box-shadow: rgba(0, 0, 0, 0) 0px 0px 0px 0px, rgba(0, 0, 0, 0) 0px 0px 0px 0px, rgba(0, 0, 0, 0) 0px 0px 0px 0px, rgba(60, 66, 87, 0.16) 0px 0px 0px 1px, rgba(0, 0, 0, 0) 0px 0px 0px 0px, rgba(0, 0, 0, 0) 0px 0px 0px 0px, rgba(0, 0, 0, 0) 0px 0px 0px 0px;
        }

        input[type="submit"] {
            background-color: #252122;
            box-shadow: rgba(0, 0, 0, 0) 0px 0px 0px 0px, rgba(0, 0, 0, 0) 0px 0px 0px 0px, rgba(0, 0, 0, 0.12) 0px 1px 1px 0px, #d9b250, rgba(0, 0, 0, 0) 0px 0px 0px 0px, rgba(0, 0, 0, 0) 0px 0px 0px 0px, rgba(60, 66, 87, 0.08) 0px 2px 5px 0px;
            color: #fff;
            font-weight: 600;
            cursor: pointer;
        }

        .field-checkbox input {
            width: 20px;
            height: 15px;
            margin-right: 5px;
            box-shadow: unset;
            min-height: unset;
        }

        .field-checkbox label {
            display: flex;
            align-items: center;
            margin: 0;
        }

        a.ssolink {
            display: block;
            text-align: center;
            font-weight: 600;
        }

        .footer-link span {
            font-size: 14px;
            text-align: center;
        }

        .listing a {
            color: #697386;
            font-weight: 600;
            margin: 0 10px;
        }

        .animationRightLeft {
            animation: animationRightLeft 15s ease-in-out infinite;
        }

        .animationLeftRight {
            animation: animationLeftRight 13s ease-in-out infinite;
        }

        .tans3s {
            animation: animationLeftRight 12s ease-in-out infinite;
        }

        .tans4s {
            animation: animationLeftRight 13s ease-in-out infinite;
        }

        @keyframes animationLeftRight {
            0% {
                transform: translateX(0px);
            }

            50% {
                transform: translateX(1000px);
            }

            100% {
                transform: translateX(0px);
            }
        }

        @keyframes animationRightLeft {
            0% {
                transform: translateX(0px);
            }

            50% {
                transform: translateX(-1000px);
            }

            100% {
                transform: translateX(0px);
            }
        }

        @media (max-width:600px) {
            .grid-container {
                display: block;
            }
        }
    </style>
</head>
<body>
    <%--    <div class="login-box1">--%>
    <form id="frm" runat="server">
        <div class="login-root">
            <div class="box-root flex-flex flex-direction--column" style="min-height: 100vh; flex-grow: 1;">
                <div class="loginbackground box-background--white padding-top--64">
                    <div class="loginbackground-gridContainer">
                        <div class="box-root flex-flex" style="grid-area: top / start / 8 / end;">
                            <div class="box-root" style="background-image: linear-gradient(white 0%, rgb(247, 250, 252) 33%); flex-grow: 1;">
                            </div>
                        </div>
                        <div class="box-root flex-flex" style="grid-area: 4 / 2 / auto / 5;">
                            <div class="box-root box-divider--light-all-2 animationLeftRight tans3s" style="flex-grow: 1;"></div>
                        </div>
                        <div class="box-root flex-flex" style="grid-area: 6 / start / auto / 2;">
                            <div class="box-root box-background--blue800" style="flex-grow: 1;"></div>
                        </div>
                        <div class="box-root flex-flex" style="grid-area: 7 / start / auto / 4;">
                            <div class="box-root box-background--blue animationLeftRight" style="flex-grow: 1;"></div>
                        </div>
                        <div class="box-root flex-flex" style="grid-area: 8 / 4 / auto / 6;">
                            <div class="box-root box-background--gray100 animationLeftRight tans3s" style="flex-grow: 1;"></div>
                        </div>
                        <div class="box-root flex-flex" style="grid-area: 2 / 15 / auto / end;">
                            <div class="box-root box-background--cyan200 animationRightLeft tans4s" style="flex-grow: 1;">lorem</div>
                        </div>
                        <div class="box-root flex-flex" style="grid-area: 3 / 14 / auto / end;">
                            <div class="box-root box-background--blue animationRightLeft" style="flex-grow: 1;"></div>
                        </div>
                        <div class="box-root flex-flex" style="grid-area: 4 / 17 / auto / 20;">
                            <div class="box-root box-background--gray100 animationRightLeft tans4s" style="flex-grow: 1;"><%--<div class="text-white text-center h2">ITC</div>--%></div>
                        </div>
                        <div class="box-root flex-flex" style="grid-area: 5 / 14 / auto / 17;">
                            <div class="box-root box-divider--light-all-2 animationRightLeft tans3s" style="flex-grow: 1;"></div>
                        </div>
                    </div>
                </div>

                <div class="box-root  flex-flex flex-direction--column" style="flex-grow: 1; z-index: 9;">
                    <div class="row d-none">

                        <div class="col-6 ">

                            <div class="box-root  flex-flex pt-3 px-3">
                                <!-- <h1><a href="#" rel="dofollow">Hitachi</a></h1> -->
                                <img src="Images/Asset/hitachi_logo.png" alt="" style="width: 130px;" />
                            </div>
                        </div>
                        <div class="col-6 text-end d-none">
                            <div class="box-root  flex-flex p-3 float-end">
                                <!-- <h1><a href="#" rel="dofollow">Hitachi</a></h1> -->
                                <img src="./Asset/logo.png" alt="" style="width: 130px;" />
                            </div>
                        </div>
                    </div>

                    <div class="formbg-outer mt-5">


                        <div class="formbg">

                            <div class="formbg-inner padding-horizontal--48 ">
                                <div class="grid-container mt-4">
                                    <div class="grid-item p-5 " style="">
                                        <span class="padding-bottom--15">Login to your Account</span>
                                        <div class="right " id="stripe-login">
                                            <asp:Panel ID="pnlLogin" runat="server">




                                                <%--	<p>Don't have an account? <a href="#">Create Your Account</a> </p>it takes less than a minute</p>--%>
                                                <div class="inputs">

                                                    <div class="field padding-bottom--24">
                                                        <div class="grid--50-50">
                                                            <label for="email">
                                                                <asp:RequiredFieldValidator ID="RfvtxtUserName" runat="server" ErrorMessage="*" ForeColor="Red" Font-Bold="true" ControlToValidate="txtUserName" ValidationGroup="Login"></asp:RequiredFieldValidator>User ID</label>
                                                        </div>

                                                        <asp:TextBox ID="txtUserName" runat="server" placeholder="User Name"></asp:TextBox>
                                                    </div>

                                                    <div class="field padding-bottom--24">
                                                        <div class="grid--50-50">
                                                            <label for="password">Password    </label>
                                                            <asp:RequiredFieldValidator ID="rfvtxtPassword" runat="server" ErrorMessage="*" ForeColor="Red" Font-Bold="true" ControlToValidate="txtPassword" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                                    </div>

                                                    <div class="field field-checkbox flex-flex align-center padding-bottom--24" style="display: flex; align-items: flex-start; justify-content: space-between;">
                                                        <label for="checkbox">
                                                            <asp:CheckBox ID="chk" runat="server" name="item" />
                                                            Remember Me
                                                        </label>
                                                        <div class="reset-pass">
                                                            <asp:LinkButton ID="lnkFrgtPass" Text="Forget Password?" runat="server" OnClick="lnkFrgtPass_Click"></asp:LinkButton>
                                                        </div>
                                                    </div>






                                                </div>


                                                <%--	<div class="inputs">
				<asp:CheckBox ID="chkRememberMe" Text="Remember Me" runat="server" />
             <asp:LinkButton ID="lnkFrgtPass" Text="forget password?" runat="server" OnClick="lnkFrgtPass_Click"></asp:LinkButton>
			</div>--%>


                                                <div class="field ">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Sign In" OnClick="btnSubmit_Click" ValidationGroup="Login" />
                                                </div>

                                            </asp:Panel>
                                            <asp:Panel ID="pnl2FA" runat="server" Visible="false">

                                                <div class="field">
                                                    <asp:Label ID="lbl2FA" runat="server" Text="2FA Authenticator" CssClass="h6 text-success"></asp:Label>
                                                </div>
                                                <div class="field  text-center">

                                                    <asp:Image ID="imgQrCode" runat="server" Width="120" Height="120" />
                                                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblSecretKey" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblVerificationResult" runat="server" Text=""></asp:Label>
                                                </div>




                                                <div class="field padding-bottom--24 row">
                                                    <div class="grid--50-50 ">

                                                        <label>Enter 2FA </label>
                                                        <asp:RequiredFieldValidator ID="rfvtxt2fa" runat="server" ErrorMessage="*" ForeColor="Red" Font-Bold="true" ControlToValidate="txt2fa" ValidationGroup="2FA"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <div class="col-12">
                                                        <asp:TextBox ID="txt2fa" runat="server" placeholder="Enter 2FA" TextMode="SingleLine"></asp:TextBox>

                                                    </div>
                                                    <div class="field field-checkbox flex-flex align-center mt-2" style="display: flex; align-items: flex-start; justify-content: space-between;">
                                                        <label for="checkbox">
                                                            <asp:CheckBox ID="chkRemb2FA" runat="server" name="item" />
                                                            Remember 2FA For 30 Days in this System ! 
                                                        </label>
                                                       

                                                                                                            </div>
                                                     <div class="small text-start">
     <asp:LinkButton ID="LinkButton1" Text="Forget password?" runat="server" OnClick="lnkFrgtPass_Click"></asp:LinkButton>

 </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-6">
                                                        <div class="field ">
                                                            <asp:Button ID="btn2FA" runat="server" Text="Enter OTP" OnClick="btn2FA_Click" ValidationGroup="2FA" />
                                                        </div>
                                                    </div>
                                                    <div class="col-6">
                                                        <div class="field ">
                                                            <asp:Button ID="btnReset" runat="server" Text="Go Back" OnClick="btnReset_Click" CausesValidation="false" />
                                                        </div>
                                                    </div>
                                                </div>







                                            </asp:Panel>
                                            <asp:Panel ID="pnlEnterEmail" runat="server" Visible="false">
                                                <br />

                                                <div class="field padding-bottom--24">
                                                    <asp:Label ID="lblGetMail" ForeColor="Red" runat="server" Style="font-size: 14px !important"></asp:Label>
                                                </div>
                                                <div class="field padding-bottom--24">
                                                    <label>Enter LoginID</label>
                                                    <asp:TextBox ID="txtLoginName" runat="server" placeholder="Enter Login ID" TextMode="SingleLine"></asp:TextBox>
                                                </div>
                                                <div class="field padding-bottom--24">
                                                    <label>Enter Registered Email</label>
                                                    <asp:TextBox ID="txtRegisEmail" runat="server" placeholder="Enter Registered Email" TextMode="SingleLine"></asp:TextBox>
                                                </div>
                                                <div class="field ">
                                                    <asp:Button ID="btnVerifyUser" runat="server" Text="Set Password" OnClick="btnVerifyUser_Click" ValidationGroup="ResetPass" />
                                                </div>



                                            </asp:Panel>
                                            <asp:Panel ID="pnlForgotPass" runat="server" Visible="false">
                                                <center>


                                                    <asp:Label ID="lblForgortPass" runat="server" CssClass=" col-md-1 ml-3  font_fam offset-1" Font-Size="XX-Large" Text="Forgot Password"></asp:Label>


                                                </center>
                                                <br />
                                                <asp:Label ID="lblotpmsg" ForeColor="Red" runat="server"></asp:Label>
                                                <asp:TextBox ID="txtOTP" runat="server" placeholder="Enter OTP" ClientIDMode="Static" TextMode="SingleLine"></asp:TextBox>
                                                <asp:LinkButton ID="resendButton" Text="Resent OTP" OnClick="resendButton_Click" runat="server"></asp:LinkButton>
                                                <asp:RegularExpressionValidator ID="regtxtPassword" runat="server" ControlToValidate="txtResetPass"
                                                    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}" ValidationGroup="ResetPass"
                                                    ErrorMessage="Invalid Password" ForeColor="Red" Display="Dynamic" />
                                                <asp:RequiredFieldValidator ID="rfvtxtResetPass" Display="Dynamic" runat="server" ControlToValidate="txtResetPass" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ResetPass" />

                                                <asp:TextBox ID="txtResetPass" runat="server" placeholder="Enter Password" ClientIDMode="Static" TextMode="Password"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="regtxtConfResetPass" runat="server" ControlToValidate="txtConfResetPass"
                                                    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}"
                                                    ErrorMessage="Invalid Password" ForeColor="Red" Display="Dynamic" ValidationGroup="ResetPass" />
                                                <asp:RequiredFieldValidator ID="rfvtxtConfResetPass" Display="Dynamic" runat="server" ControlToValidate="txtConfResetPass" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ResetPass" />

                                                <asp:TextBox ID="txtConfResetPass" runat="server" placeholder="Enter Confirm Pass" TextMode="Password"></asp:TextBox>
                                                <asp:Button ID="btnResetPass" runat="server" Text="Verfiy" class="button  btn btn-success" OnClick="btnResetPass_Click" ValidationGroup="ResetPass" />
                                            </asp:Panel>
                                        </div>
                                    </div>

                                    <div class="grid-item d-none d-sm-block" style="background-image: url(Images/Asset/xyz.jpg); background-size: cover; background-repeat: no-repeat; border-radius: 0 0.4rem 0.4rem 0;">
                                        <div class="row">
                                            <div class="col-12 px-4 py-4 text-end">
                                                <img src="Images/Asset/img/Hitachi-Logo-White.png" style="width: 100px;" />
                                            </div>
                                            <div class="col-12 text-center text-white-50 py-3 mt-5 px-3">
                                                <%--<h4 class="text-white-50 py-3">Welcome Back!</h4>--%>
                                                <%--<h5 class="text-white-50 px-4" id="dynamic-text">"Your personal space is ready for you"</h5>--%>
                                                <%--<h5 class="text-white-50 px-5 mt-5"  >SOCIAL INNOVATION – IT'S OUR FUTURE</h5>--%>
                                                <h5 class="text-white-50 px-5 mt-5"  >Hitachi
Social Innovation is POWERING GOOD</h5>
                                                <h5 class="text-white-50 px-3">_____</h5>
                                            </div>
                                        </div>



                                    </div>


                                </div>
                            </div>


                            <!-- <div class="footer-link padding-top--24">
       <span>Don't have an account? <a href="">Sign up</a></span>
      
     </div> -->
                        </div>



        <footer class="footer text-center">
        <p class="text-muted mb-0" style="font-size:0.675em;">©<a href="https://hitachi-systems.co.in/" class="text-muted" target="_blank">Hitachi Systems India</a>  2022. All rights reserved.</p>
    </footer>

                    </div>
                </div>
            </div>


        </div>

        <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Login Alert?</h5>
                        <button class="close close border-0 bg-white" type="button" data-dismiss="modal" aria-label="Close"><span aria-hidden="true" class="text-dark border-0">×</span> </button>
                    </div>
                    <div class="modal-body">An active session for this user is detected. Terminate the existing session and continue with login ?</div>
                    <div class="modal-footer">
                        <button class="btn btn-danger btn-sm" type="button" data-dismiss="modal" onclick="HideModal()">Cancel</button>
                        <asp:LinkButton ID="btnLogout" runat="server" class="btn btn-dark btn-sm" OnClick="btnLogout_Click">Ok</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function Confirm() {
                $('#logoutModal').modal('show');
            }
            function HideModal() {
                $('#logoutModal').modal('hide');
                window.location.href = "Default.aspx";
            }
        </script>
        <script>
            const texts = [
                "SOCIAL INNOVATION – IT'S OUR FUTURE",
                "Hitachi Social Innovation is POWERING GOOD"
               
            ];

            let currentIndex = 0;
            const textElement = document.getElementById('dynamic-text');

            function changeText() {
                textElement.classList.add('fade-out'); // Start fade-out

                setTimeout(() => {
                    currentIndex = (currentIndex + 1) % texts.length;
                    textElement.textContent = texts[currentIndex];

                    textElement.classList.remove('fade-out'); // End fade-out
                }, 1000); // Time to wait before changing text (should match the duration of the fade-out)
            }

            // Change text every 2 seconds
            setInterval(changeText, 3000); // 2s fade effect + 1s wait before changing text
        </script>
    </form>
</body>
</html>
