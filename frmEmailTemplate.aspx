<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmEmailTemplate.aspx.cs" Inherits="frmEmailTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../plugins/jquery/jquery.min.js"></script>
    <script src="../Scripts/chosen.jquery.js"></script>

    <link rel="stylesheet" href="../plugins/summernote/summernote-bs4.min.css" />
    <script>
        function getxtValue(that) {
            document.getElementById("lable").innerHTML = that.value;
        }
    </script>
    <script>
        function pageLoad() {
            jQuery(".chzn-select").data("placeholder", "Select Frameworks...").chosen();
        }
    </script>
    <link rel="stylesheet" href="../plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css" />
    <link rel="stylesheet" href="../plugins/toastr/toastr.min.css" />
    <link rel="stylesheet" href="../plugins/fontawesome-free/css/all.min.css" />
    <!-- overlayScrollbars -->
    <link rel="stylesheet" href="../plugins/overlayScrollbars/css/OverlayScrollbars.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="../Scripts/chosen.css" />
    <link rel="stylesheet" href="../dist/css/adminlte.min.css" />
    <link rel="stylesheet" href="../dist/css/ServiceDeskCustom.css" />
    <style>
        .c {
            color: white;
            /*  //background: #698DF2;*/
            background: transparent linear-gradient(180deg, #5D7FA7 0%, #2E4E74 100%) 0% 0% no-repeat padding-box;
            border: none;
        }

        .chart_label {
            font-size: larger;
            font-weight: 500;
            letter-spacing: 0px;
            opacity: 1;
            text-align: left;
        }

        .fonts {
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="col-md-12">
                    <div class="card">

                        <div class="card-body">
                            <div class="form-group row mt-3">
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    Organization: <span title="*"></span>

                                    <asp:RequiredFieldValidator ID="rfvddlOrg" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddEmailTemp"></asp:RequiredFieldValidator>
                                </label>

                                <div class="col-sm-4 pr-5">

                                    <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4 ">
                                    Service Desk : <span class="red">*</span>
                                    <asp:RequiredFieldValidator ID="RfvddlRequestType" runat="server" InitialValue="0" ControlToValidate="ddlRequestType" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </label>
                                <div class="col-sm-4 pr-5">
                                    <asp:DropDownList ID="ddlRequestType" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                            </div>
                            <div class="form-group row mt-2">
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                    Email Template :
							<span title="*"></span>
                                    <asp:ImageButton ID="ImgAddEmailTemp" runat="server" ImageUrl="~/Images/plus.png" OnClick="ImgAddEmailTemp_Click" />

                                    <asp:RequiredFieldValidator ID="rfvddlEmailTemplate" runat="server" ControlToValidate="ddlEmailTemplate" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddEmailTemp"></asp:RequiredFieldValidator>
                                </label>


                                <div class="col-sm-4 pr-5">
                                    <asp:TextBox ID="txtEmailTemplate" runat="server" CssClass="form-control form-control-sm" />
                                    <asp:DropDownList ID="ddlEmailTemplate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmailTemplate_SelectedIndexChanged" CssClass="form-control  form-control-sm chzn-select"></asp:DropDownList>

                                </div>

                            </div>
                            <div class="form-group row ">

                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    <asp:Label ID="Label1" Text="Summary" runat="server"></asp:Label>

                                    <asp:RequiredFieldValidator ID="rfvtxtSummary" runat="server" ControlToValidate="txtSummary" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddEmailTemp"></asp:RequiredFieldValidator>
                                </label>


                                <div class="col-sm-10 pr-5">

                                    <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control  form-control-sm "></asp:TextBox>

                                </div>

                            </div>
                            <div class="form-group row ">
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    Email Body : 
                                               <asp:RequiredFieldValidator ID="RfvtxtDescription" runat="server" ControlToValidate="txtDescription" ValidationGroup="AddEmailTemp" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </label>
                                <div class="col-sm-10 pr-5">
                                    <%--	<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" MaxLength="500" Height="200px"></asp:TextBox>--%>
                                    <%--							<asp:TextBox ID="txtDescription" runat="server" Rows="8" Columns="8" TextMode="MultiLine"></asp:TextBox>--%>
                                    <textarea id="txtDescription" runat="server"></textarea>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 offset-5">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" ValidationGroup="AddEmailTemp" OnClick="btnSave_Click" CssClass="btn btn-sm savebtn " />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" CssClass="btn btn-sm cancelbtn " />
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
    <link rel="stylesheet" type="text/css" href="../Script/build/jquery.datetimepicker.css" />
    <script src="../Script/build/jquery.js"></script>
    <script src="../Script/build/jquery.datetimepicker.full.js"></script>

    <script src="../plugins/jquery/jquery.min.js"></script>
    <script src="../plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript"> $(".chzn-select").chosen();

        $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    <link rel="stylesheet" href="../Scripts/chosen.css" />
    <script src="../plugins/toastr/toastr.min.js"></script>
    <script src="../plugins/sweetalert2/sweetalert2.min.js"></script>

    <script src="../plugins/summernote/summernote-bs4.min.js"></script>
    <script>
        $(document).ready(function () {

            $('#<%= txtDescription.ClientID %>').summernote();
        });
    </script>
</asp:Content>

