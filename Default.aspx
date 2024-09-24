<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html lang="en" data-bs-theme="blue-theme">

<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--favicon-->
    <link rel="icon" href="https://pcv-demo.hitachi-systems-mc.com:2020/assets/images/Hitachi/Hitachi_logo.png" type="image/png">
    <!-- loader-->
    <link href="https://pcv-demo.hitachi-systems-mc.com:2020/assets/css/pace.min.css" rel="stylesheet">
    <script src="https://pcv-demo.hitachi-systems-mc.com:2020/assets/js/pace.min.js"></script>

    <!--plugins-->
    <link href="https://pcv-demo.hitachi-systems-mc.com:2020/assets/plugins/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="https://pcv-demo.hitachi-systems-mc.com:2020/assets/plugins/metismenu/metisMenu.min.css">
    <link rel="stylesheet" type="text/css" href="https://pcv-demo.hitachi-systems-mc.com:2020/assets/plugins/metismenu/mm-vertical.css">
    <!--bootstrap css-->
    <link href="https://pcv-demo.hitachi-systems-mc.com:2020/assets/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Noto+Sans:wght@300;400;500;600&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Material+Icons+Outlined" rel="stylesheet">
    <!--main css-->
    <link href="https://pcv-demo.hitachi-systems-mc.com:2020/assets/css/bootstrap-extended.css" rel="stylesheet">
    <link href="https://pcv-demo.hitachi-systems-mc.com:2020/sass/main.css" rel="stylesheet">
    <link href="https://pcv-demo.hitachi-systems-mc.com:2020//dark-theme.css" rel="stylesheet">
    <link href="https://pcv-demo.hitachi-systems-mc.com:2020/sass/blue-theme.css" rel="stylesheet">
    <link href="https://pcv-demo.hitachi-systems-mc.com:2020/sass/responsive.css" rel="stylesheet">
    <style>
        #lnkFrgtPass:hover {
            text-decoration: underline;
            color: #808080
        }
    </style>
</head>

<body>

    <!--authentication-->

    <div class="section-authentication-cover">
        <div class="">
            <div class="row g-0">

                <div class="col-12 col-xl-7 col-xxl-8 auth-cover-left align-items-center justify-content-center d-none d-xl-flex border-end bg-transparent">

                    <div class="card rounded-0 mb-0 border-0 shadow-none bg-transparent bg-none">
                        <div class="card-body">
                            <img src="assets/images/auth/login1.png" class="img-fluid auth-img-cover-login" width="600" alt="">
                        </div>
                    </div>

                </div>

                <div class="col-12 col-xl-5 col-xxl-4 auth-cover-right align-items-center justify-content-center border-top border-4 border-primary border-gradient-1">
                    <div class="card rounded-0 m-3 mb-0 border-0 shadow-none bg-none">
                        <div class="card-body p-sm-5">
                            <%--<img src="assets/images/logo1.png" class="mb-4" width="145" alt="">--%>
                            <%--<img src="assets/images/Hitachi-Logo-White.png" class="mb-4" width="145" alt="logo here"/>--%>




                            <div class="form-body mt-0">
                                <form id="frm" runat="server">
                                    <asp:Panel ID="pnlLogin" runat="server">
                                        <%--	<p>Don't have an account? <a href="#">Create Your Account</a> </p>it takes less than a minute</p>--%>
                                        <h4 class="fw-bold">Get Started Now</h4>
                                        <p class="mb-4">Enter your credentials to login your account</p>
                                        <div class="row g-3">
                                            <div class="col-12">
                                                <label for="email" class="form-label">
                                                    User ID
                                                    <asp:RequiredFieldValidator ID="RfvtxtUserName" runat="server" ErrorMessage="*" ForeColor="Red" Font-Bold="true" ControlToValidate="txtUserName" ValidationGroup="Login"></asp:RequiredFieldValidator></label>

                                                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" placeholder="User Name"></asp:TextBox>
                                            </div>
                                            <div class="col-12">
                                                <label for="password" class="form-label">
                                                    Password
                                                    <asp:RequiredFieldValidator ID="rfvtxtPassword" runat="server" ErrorMessage="*" ForeColor="Red" Font-Bold="true" ControlToValidate="txtPassword" ValidationGroup="Login"></asp:RequiredFieldValidator></label>
                                                <div class="input-group" id="show_hide_password">

                                                    <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                                                    <a href="javascript:;" class="input-group-text bg-transparent"><i class="bi bi-eye-slash-fill"></i></a>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <%--<div class="form-check">--%>
                                                <asp:CheckBox ID="chk" runat="server" name="item" />
                                                <label class="form-check-label" for="checkbox">Remember Me</label>
                                                <%--</div>--%>
                                            </div>
                                            <div class="col-md-6 text-end">

                                                <asp:LinkButton ID="lnkFrgtPass" Text="Forget Password?" runat="server" OnClick="lnkFrgtPass_Click"></asp:LinkButton>
                                            </div>
                                            <div class="col-12">
                                                <div class="d-grid">
                                                    <asp:Button ID="btnSubmit" class="btn btn-grd-primary" runat="server" Text="Sign In" OnClick="btnSubmit_Click" ValidationGroup="Login" />

                                                </div>
                                            </div>

                                        </div>

                                    </asp:Panel>
                                    <asp:Panel ID="pnl2FA" runat="server" Visible="false">
                                        <div class=" row gy-3 gx-1">
                                            <div class="col-12">
                                                <asp:Label ID="lbl2FA" runat="server" Text="2FA Authenticator" CssClass="h6 text-success"></asp:Label>
                                            </div>
                                            <div class="col-12">
                                                <asp:Image ID="imgQrCode" runat="server" Width="120" Height="120" />
                                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                                <asp:Label ID="lblSecretKey" runat="server" Text=""></asp:Label>
                                                <asp:Label ID="lblVerificationResult" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-12">
                                                <label class="form-label">
                                                    Enter 2FA
                                                <asp:RequiredFieldValidator ID="rfvtxt2fa" runat="server" ErrorMessage="*" ForeColor="Red" Font-Bold="true" ControlToValidate="txt2fa" ValidationGroup="2FA"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:TextBox ID="txt2fa" CssClass="form-control" runat="server" placeholder="Enter 2FA" TextMode="SingleLine"></asp:TextBox>
                                            </div>
                                            <div class="col-12">
                                                <div class="form-check ">

                                                    <asp:CheckBox ID="chkRemb2FA" runat="server" name="item" />
                                                    <label class="form-check-label" for="flexSwitchCheckChecked">Remember 2FA For 30 Days in this System ! </label>
                                                </div>
                                            </div>
                                            <div class="col-12 d-none">

                                                <asp:LinkButton ID="LinkButton1" Text="Forget password?" runat="server" OnClick="lnkFrgtPass_Click"></asp:LinkButton>
                                            </div>
                                            <div class="col-6">
                                                <asp:Button ID="btn2FA" runat="server" Text="Enter OTP" class="btn btn-grd-primary w-100" OnClick="btn2FA_Click" ValidationGroup="2FA" />
                                            </div>
                                            <div class="col-6">
                                                <asp:Button ID="btnReset" runat="server" Text="Go Back" class="btn btn-grd-info w-100" OnClick="btnReset_Click" CausesValidation="false" />
                                            </div>



                                        </div>







                                    </asp:Panel>
                                    <asp:Panel ID="pnlEnterEmail" runat="server" Visible="false">
                                        <h4 class="fw-bold">Forget Password !</h4>
                                        <p class="mb-4">
                                            No worries, we’ve got you covered!

                                        </p>
                                        <div class="row g-3">
                                            <div class="col-md-12">
                                                <label class="form-label">Enter Login ID</label>
                                                <asp:TextBox ID="txtLoginName" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">
                                                <label class="form-label">Enter Registered Email</label>
                                                <asp:TextBox ID="txtRegisEmail" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:Button ID="btnVerifyUser" runat="server" Text="Set Password" class="btn btn-grd-primary w-100" OnClick="btnVerifyUser_Click" ValidationGroup="ResetPass" />

                                            </div>
                                        </div>

                                        <div class="d-none">
                                            <asp:Label ID="lblGetMail" ForeColor="Red" runat="server" Style="font-size: 14px !important"></asp:Label>
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
                                </form>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
            <!--end row-->
        </div>
    </div>

    <!--authentication-->

    <script src="https://pcv-demo.hitachi-systems-mc.com:2020/assets/js/jquery.min.js"></script>

    <script>
        $(document).ready(function () {
            $("#show_hide_password a").on('click', function (event) {
                event.preventDefault();
                if ($('#show_hide_password input').attr("type") == "text") {
                    $('#show_hide_password input').attr('type', 'password');
                    $('#show_hide_password i').addClass("bi-eye-slash-fill");
                    $('#show_hide_password i').removeClass("bi-eye-fill");
                } else if ($('#show_hide_password input').attr("type") == "password") {
                    $('#show_hide_password input').attr('type', 'text');
                    $('#show_hide_password i').removeClass("bi-eye-slash-fill");
                    $('#show_hide_password i').addClass("bi-eye-fill");
                }
            });
        });
    </script>

</body>
</html>
