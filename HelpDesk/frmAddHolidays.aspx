<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddHolidays.aspx.cs" Inherits="frmAddHolidays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        .header {
            position: sticky;
            top: 0;
            bottom: 2px;
            font-weight: 200;
            border: #EEEEEE;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="row mb-1">
                <div class="col-lg-12 col-md-6 col-sm-4">
                    <asp:Button ID="btnAddHoliday" runat="server" Text="Add Holiday" CausesValidation="false" OnClick="btnAddHoliday_Click" />
                    <asp:Button ID="btnimportUser" runat="server" Text="Import Holidays" CausesValidation="false" OnClick="btnimportUser_Click" />
                    <asp:Button ID="btnViewUsers" runat="server" Text="View Holiday" CausesValidation="false" OnClick="btnViewUsers_Click" />
                </div>
            </div>
            <asp:Panel ID="pnlAddHoliday" Visible="false" runat="server">

                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-12" style="border-bottom: 1px solid lightgrey">
                                        <label class="form-label">Add Holiday Value</label>
                                    </div>

                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Organization: <span title="*"></span>


                                        <asp:RequiredFieldValidator ID="rfvddlOrg" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                    </label>

                                    <div class="col-sm-4 pr-5">

                                        <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-control form-control-sm chzn-select">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Holiday Name<span class="red">*</span>
                                        <asp:RequiredFieldValidator ID="rfvtxtHolidayName" runat="server" ControlToValidate="txtHolidayName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtHolidayName" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                    </div>

                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Day<span class="red">*</span>
                                        <asp:RequiredFieldValidator ID="rfvtxtholidayDatee" runat="server" ControlToValidate="txtholidayDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="SearchUser"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtholidayDate" autocomplete="off" ClientIDMode="static" class="form-control form-control-sm" runat="server" />
                                    </div>




                                </div>


                                <div class="form-row">
                                    <div class="col-md-3  offset-5">

                                        <asp:Button ID="btnInsertHoliday" runat="server" Text="Save" OnClick="btnInsertHoliday_Click" class="btn btn-sm savebtn" ValidationGroup="Tech"></asp:Button>
                                        <asp:Button ID="btnUpdateHoliday" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateHoliday_Click" ValidationGroup="ReqType" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-sm  cancelbtn" OnClick="btnCancel_Click" CausesValidation="false" />
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlShowUsers" runat="server">

                <div class="row">
                    <div class="col-md-12 graphs">
                        <div class="xs">
                            <div class="well1 white">
                                <div class="card card-default">

                                    <div class="card-body">
                                        <div class="row ">
                                            <div class="col-md-4">

                                                <asp:Label ID="lblsofname" runat="server" Text="Holiday Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

                                            </div>
                                            <div class="col-md-6">
                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-2 ">
                                                <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                    <label class="mr-2 ml-1 mb-0">Export</label>
                                                    <asp:ImageButton ID="ImgBtnExport" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport_Click" />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="table-responsive p-0" style="height: 400px; width: 100%">
                                            <asp:GridView GridLines="None" ID="gvHoliday" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-head-fixed text-nowrap"
                                                Width="100%" OnRowCommand="gvHoliday_RowCommand" OnRowDataBound="gvHoliday_RowDataBound">
                                                <Columns>
                                                    <asp:ButtonField ButtonType="Image" CommandName="SelectTech" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                    <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />
                                                    <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="HolidayName" HeaderText="Holiday Name" NullDisplayText="NA" />
                                                    <asp:BoundField DataField="HolidayDate" HeaderText="Holiday Date" NullDisplayText="NA" DataFormatString="{0:dd-MM-yyyy}" />
                                                    <asp:TemplateField HeaderText=" Organization">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOrgFk" runat="server" Text='<%# Eval("Org_ID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblOrgName" runat="server" Text='<%# Eval("OrgName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                </Columns>
                                                <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="10px" />
                                                <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" />
                                                <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="30px" CssClass="header" Font-Size="Small" />
                                                <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" />
                                                <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlImportUser" runat="server" Visible="false">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-2">
                                        <label class="labelcolorl1">
                                            Select Holiday(s) :
                                          
                                        </label>
                                    </div>
                                    <div class="col-md-3">

                                        <%--<div class="custom-file">--%>
                                        <div class="mb-3">

                                            <asp:FileUpload ID="customFile" CssClass="form-control form-control-sm p-0" runat="server" />
                                            <%--<label class="custom-file-label" for="customFile">Choose File</label>--%>
                                            <asp:Label ID="lblfilename" runat="server" class="labelcolorl1" Text=""></asp:Label>
                                            <%--</div>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <a href="SampleFiles/HolidayFormat.xlsx" target="_blank" download="Insert Format" class="  btn-sm warning_3"><u>Download Sample Excel</u>
                                        </a>
                                    </div>


                                </div>
                                <div class="row mt-2">
                                    <div class="col-md-2">
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="butttonsubmit" runat="server" Text="Import Excel" CssClass="btn btn-sm btn-success savebtn" OnClick="butttonsubmit_Click" CausesValidation="false" />
                                        <asp:Button ID="btnn" runat="server" Text="Insert Data" OnClick="btnn_Click" CssClass="btn btn-sm btn-success warning_3" Visible="false" CausesValidation="false" />
                                    </div>
                                </div>
                                <div class="row" style="display: none;">
                                    <asp:Label ID="Label2" runat="server" Text="Has Header ?"></asp:Label>
                                    <br />
                                    <asp:RadioButtonList ID="rbHDR" runat="server" RepeatLayout="Flow">
                                        <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive p-0" style="height: 400px; width: 100%">
                                            <asp:GridView ID="gvExcelFile" runat="server" CssClass="table table-head-fixed text-nowrap" AutoGenerateColumns="true">

                                                <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="10px" />
                                                <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" />
                                                <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="30px" CssClass="header" Font-Size="Small" />
                                                <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" />
                                                <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>

            <asp:PostBackTrigger ControlID="btnn" />
            <asp:PostBackTrigger ControlID="butttonsubmit" />
            <asp:PostBackTrigger ControlID="btnInsertHoliday" />
            <asp:PostBackTrigger ControlID="btnUpdateHoliday" />
            <asp:PostBackTrigger ControlID="gvHoliday" />
            <asp:PostBackTrigger ControlID="ImgBtnExport" />


            <asp:PostBackTrigger ControlID="btnAddHoliday" />
            <asp:PostBackTrigger ControlID="btnimportUser" />
            <asp:PostBackTrigger ControlID="btnViewUsers" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function Showalert(imtype, imtitle) {
            // alert('Call JavaScript function from codebehind');
            // var typeof=type
            // var titleof = title;
            var Toast = Swal.mixin({
                toast: true,
                position: 'top-middle',

                showConfirmButton: false,
                showCloseButton: true,
                timer: 4000,


            });
            console.log("hello");
            Toast.fire({
                /*icon: 'success',*/
                //type: 'success',
                //title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                icon: imtype,
                title: imtitle
            });

            console.log("fire1234567");
        }
    </script>
    <script>
        $(function () {
            bsCustomFileInput.init();
        });
    </script>
    <script>
        function displayfilename()
        $('#<%= customFile.ClientID %>').change(function (e) {
            var fileName = e.target.files[0].name;
            alert('The file "' + fileName + '" has been selected.');
        });
    </script>
    <%--	<script>
		$(document).ready(function () {
			$('<%= customFile.ClientID %>').change(function () {
				var path = $(this).val();
				if (path != '' && path != null) {
					var q = path.substring(path.lastIndexOf('\\') + 1);
					$('<%= lblfilename.ClientID %>').html(q);
				}
			});
		});
	</script>--%>
    <link rel="stylesheet" type="text/css" href="../Script/build/jquery.datetimepicker.css" />
    <script src="../Script/build/jquery.js"></script>
    <script src="../Script/build/jquery.datetimepicker.full.js"></script>
    <script>
        $.datetimepicker.setLocale('en');
        $('#txtholidayDate').datetimepicker({
            dayOfWeekStart: 1,
            lang: 'en',
            startDate: '+1d'

        });
    </script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    <link rel="stylesheet" href="../Scripts/chosen.css" />
    <script type="text/javascript" src="../Script/Scroll/1.8.2.jquery.min.js"></script>
    <script type="text/javascript" src="../Script/Scroll/1.9.1.jquery-ui.min.js"></script>
    <script type="text/javascript" src="../Script/Scroll/gridviewScroll.min.js"></script>
    <script src="../plugins/toastr/toastr.min.js"></script>
    <script src="../plugins/sweetalert2/sweetalert2.min.js"></script>
</asp:Content>

