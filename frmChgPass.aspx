<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmChgPass.aspx.cs" Inherits="frmChgPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">Admin</div>
        <div class="ps-3">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 p-0">

                    <li class="breadcrumb-item active" aria-current="page"><i class="fa-solid fa-key"></i> Change Password </li>
                </ol>
            </nav>
        </div>

    </div>
    <div class="card">
        <div class="card-body">
            <div class="row">
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
                    <asp:TextBox ID="txtpassword" runat="server" CssClass=" form-control form-control-sm" MaxLength="50" ValidationGroup="chgpass" TextMode="Password" placeholder="Password"></asp:TextBox>
                </div>
                <div class="col-6">
                    <label class="form-label" style="color: transparent">
                        ..
                    </label>
                    <br />
                    <asp:Button ID="btnChgpass" runat="server" Text="Change Password" CssClass="btn btn-sm btn-grd btn-grd-info" OnClick="btnChgpass_Click" ValidationGroup="chgpass" />
                    <asp:Label ID="lblmessge" runat="server" Text=""></asp:Label>
                </div>

            </div>

        </div>
    </div>

</asp:Content>

