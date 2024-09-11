<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmEmailTemplate.aspx.cs" Inherits="frmEmailTemplate" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="assets/plugins/summernote/jquery.js"></script>
    <link href="assets/plugins/summernote/summernote-bs4.css" rel="stylesheet" />
    <script src="
https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="
https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
                <div class="breadcrumb-title pe-3">Components</div>
                <div class="ps-3">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb mb-0 p-0">
                            <li class="breadcrumb-item"><a href="javascript:;"><i class="bx bx-home-alt"></i>Templates</a>
                            </li>
                            <li class="breadcrumb-item active" aria-current="page">Email Template </li>
                        </ol>
                    </nav>
                </div>

            </div>

            <div class="card">
                <div class="card-body">
                    <div class=" row gy-3 gx-2">
                        <div class="col-md-4">
                            <label for="staticEmail" class="form-label">
                                Organization <span title="*"></span>

                                <asp:RequiredFieldValidator ID="rfvddlOrg" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddEmailTemp"></asp:RequiredFieldValidator>
                            </label>

                            <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label for="staticEmail" class="form-label ">
                                Service Desk  <span class="red">*</span>
                                <asp:RequiredFieldValidator ID="RfvddlRequestType" runat="server" InitialValue="0" ControlToValidate="ddlRequestType" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </label>

                            <asp:DropDownList ID="ddlRequestType" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged"></asp:DropDownList>
                        </div>


                        <div class="col-md-4">
                            <label for="staticEmail" class="form-label">
                                Email Template 
							<span title="*"></span>
                                <asp:ImageButton ID="ImgAddEmailTemp" runat="server" ImageUrl="~/Images/plus.png" OnClick="ImgAddEmailTemp_Click" />
                                <%--<asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>--%>
                                <asp:RequiredFieldValidator ID="rfvddlEmailTemplate" runat="server" ControlToValidate="ddlEmailTemplate" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddEmailTemp"></asp:RequiredFieldValidator>
                            </label>



                            <asp:TextBox ID="txtEmailTemplate" runat="server" CssClass="form-control form-control-sm" />
                            <asp:DropDownList ID="ddlEmailTemplate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmailTemplate_SelectedIndexChanged" CssClass="form-control  form-control-sm chzn-select"></asp:DropDownList>



                        </div>
                        <div class="col-md-12">

                            <label for="staticEmail" class="form-label">
                                <asp:Label ID="Label1" Text="Summary" runat="server"></asp:Label>

                                <asp:RequiredFieldValidator ID="rfvtxtSummary" runat="server" ControlToValidate="txtSummary" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddEmailTemp"></asp:RequiredFieldValidator>
                            </label>




                            <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control  form-control-sm "></asp:TextBox>


                        </div>
                        <div class="col-md-12">
                            <label for="staticEmail" class="form-label">
                                Email Body 
                                               <asp:RequiredFieldValidator ID="RfvtxtDescription" runat="server" ControlToValidate="txtDescription" ValidationGroup="AddEmailTemp" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </label>

                            <%--	<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" MaxLength="500" Height="200px"></asp:TextBox>--%>
                            <%--							<asp:TextBox ID="txtDescription" runat="server" Rows="8" Columns="8" TextMode="MultiLine"></asp:TextBox>--%>
                            <textarea id="txtDescription" runat="server"></textarea>

                        </div>

                        <div class="col-md-12 text-end">
                            <asp:Button ID="btnSave" runat="server" Text="Submit" ValidationGroup="AddEmailTemp" OnClick="btnSave_Click" CssClass="btn btn-sm  btn-grd btn-grd-primary  " />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" CssClass="btn btn-sm  btn-grd btn-grd-danger " />
                        </div>

                    </div>
                </div>
            </div>
            </div>
            </div>
        </ContentTemplate>

        <Triggers>

            <asp:PostBackTrigger ControlID="ddlEmailTemplate" />
            <asp:PostBackTrigger ControlID="ddlOrg" />
            <asp:PostBackTrigger ControlID="ImgAddEmailTemp" />
            <asp:PostBackTrigger ControlID="ddlRequestType" />

        </Triggers>

    </asp:UpdatePanel>
    <%--</div>--%>
    <script type="text/javascript">
        function Showalert(imtype, imtitle) {
            var Toast = Swal.mixin({
                toast: true,
                position: 'top-middle',

                showConfirmButton: false,
                showCloseButton: true,
                timer: 4000,


            });
            console.log("hello");
            Toast.fire({
                icon: imtype,
                title: imtitle
            });

            console.log("fire1234567");
        }
    </script>
    <script src="assets/plugins/summernote/summernote-bs4.js"></script>
    <script>
        $(document).ready(function () {

            $('#<%= txtDescription.ClientID %>').summernote();
        });
    </script>
</asp:Content>

