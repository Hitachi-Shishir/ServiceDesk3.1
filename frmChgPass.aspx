<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmChgPass.aspx.cs" Inherits="frmChgPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
 
    <div class="card">
        <div class="card-body">
            <div class="row gy-3 gx-2">
                <div class="col-md-5">
                    <label class="form-label ">
                        Enter New Password 	<a href="#" title="Minimum 8 and Maximum 10 characters 
              at least 1 Uppercase Alphabet, 1 Lowercase Alphabet,
             1 Number and 1 Special Character"
                            class="tooltipcustom"><i class="fa fa-info-circle"></i></a>
                        <asp:RegularExpressionValidator ID="regtxtPassword" runat="server" ControlToValidate="txtPassword"
                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}"
                            ErrorMessage="Invalid Password" ForeColor="Red" Display="Dynamic" ValidationGroup="chgpass" />
                        <asp:RequiredFieldValidator ID="rfvchagpass" runat="server" ControlToValidate="txtpassword" Font-Size="Medium" ErrorMessage="Enter Password!!" Font-Bold="True" ForeColor="Red" ValidationGroup="chgpass"></asp:RequiredFieldValidator>
                    </label>
                    <div class="input-group" id="show_hide_password">
                        <asp:TextBox ID="txtpassword" runat="server" CssClass=" form-control form-control-sm" MaxLength="50" ValidationGroup="chgpass" TextMode="Password" placeholder="Password"></asp:TextBox>

                        <%--<input type="password" class="form-control border-end-0" id="inputChoosePassword" value="12345678" placeholder="Enter Password">--%>
                        <a href="javascript:;" class="input-group-text bg-transparent"><i class="bi bi-eye-slash-fill"></i></a>
                    </div>
                </div>
              
                <div class="col-6 ">
                    <label class="form-label opacity-0 mt-1">
                        ..
                    </label>
                    <br />
                    <asp:Button ID="btnChgpass" runat="server" Text="Change Password" CssClass="btn btn-sm btn-grd btn-grd-info" OnClick="btnChgpass_Click" ValidationGroup="chgpass" />
                    <asp:Label ID="lblmessge" runat="server" Text=""></asp:Label>
                </div>

            </div>

        </div>
    </div>
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
</asp:Content>

