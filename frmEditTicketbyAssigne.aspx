<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmEditTicketbyAssigne.aspx.cs" Inherits="frmEditTicketbyAssigne" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            <div class="row mb-1">
                <div class="col-md-6 col-lg-12 col-sm-4">
                    <div class="card card-default">

                        <div class="card-body">

                            <div class="row">
                                <div class="col-md-6 col-lg-12 col-sm-4">
                                    <label class="cardheader">Update Ticket</label>
                                    <asp:Label ID="lblTicket" class="cardheader " runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red" Style="font-weight: bold;"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="btnUpdateTickView" Text="View Tickets" runat="server" CssClass="btn btn-sm savebtn" OnClick="btnUpdateTickView_Click" />
                                    <asp:Button ID="btnImpactDetails" runat="server" Text="Impact Details" CssClass="btn btn-sm btnDisabled" CausesValidation="false" OnClick="btnImpactDetails_Click" />
                                    <asp:Button ID="btnRolloutPlan" runat="server" Text="RollOut Details" CssClass="btn btn-sm btnDisabled" CausesValidation="false" OnClick="btnRolloutPlan_Click" />
                                    <asp:Button ID="btnDowntime" runat="server" Text="Downtime" CssClass="btn btn-sm btnDisabled" CausesValidation="false" OnClick="btnDowntime_Click" />
                                    <asp:Button ID="btnTaskAssociation" runat="server" Text="Task " CssClass="btn btn-sm btnDisabled" CausesValidation="false" OnClick="btnTaskAssociationShowPanel_Click" />

                                    <asp:Button ID="btnViewNotes" runat="server" Text-="View Notes" CssClass="btn btn-sm  btnDisabled" OnClick="btnViewNotes_Click" />

                                </div>
                            </div>
                            <asp:Panel ID="pnlTicket" runat="server">
                                <asp:Panel ID="pnlUpdateTicket" runat="server">
                                    <div class="form-group row mt-2">
                                        <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4 ">
                                            Service Desk : <span class="red">*</span>
                                            <asp:RequiredFieldValidator ID="RfvddlRequestType" runat="server" InitialValue="0" ControlToValidate="ddlRequestType" ValidationGroup="Submit" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <div class="col-sm-4 pr-5">
                                            <asp:DropDownList ID="ddlRequestType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                        </div>

                                    </div>

                                    <asp:Panel ID="pnlIncident" runat="server">
                                        <div class="form-group row ">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Summary : 
                                                <asp:RequiredFieldValidator ID="RfvtxtSummary" runat="server" ControlToValidate="txtSummary" ValidationGroup="Submit" ForeColor="Red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-10 pr-5">
                                                <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row ">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Submitter Name:
                                                   <asp:RequiredFieldValidator ID="RfvtxtSubmitterName" runat="server" ControlToValidate="txtSubmitterName" ValidationGroup="Submit" ForeColor="Red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtSubmitterName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-1">
                                                Submitter Email : 
                                             <asp:RequiredFieldValidator ID="RfvtxtSubmitterEmail" runat="server" ControlToValidate="txtSubmitterEmail" ValidationGroup="Submit" ForeColor="Red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtSubmitterEmail" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row ">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Contact Number: 
                                               <asp:RequiredFieldValidator ID="RfvtxtPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ValidationGroup="Submit" ForeColor="Red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Priority : 
                                  
                                    <asp:RequiredFieldValidator ID="rfvddlPriority" runat="server" ControlToValidate="ddlPriority" ErrorMessage="Required" ForeColor="Red" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row ">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Severity :<asp:RequiredFieldValidator ID="RfvddlSeverity" runat="server" ControlToValidate="ddlSeverity" ErrorMessage="Required" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" Enabled="false"></asp:RequiredFieldValidator>
                                                &nbsp;</label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlSeverity" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Assignee :
                                                  <asp:RequiredFieldValidator ID="rfvddlAssigne" runat="server" ControlToValidate="ddlAssigne" ValidationGroup="Submit" ForeColor="Red" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">


                                                <asp:DropDownList ID="ddlAssigne" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlAssigne_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group row ">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Location: 
                                               <asp:RequiredFieldValidator ID="rfvddlLocation" runat="server" ControlToValidate="ddlLocation" ValidationGroup="Addticket" ForeColor="Red" InitialValue="0" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Department : 
                                  
                                    <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group row ">

                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Category1 :
                                                  <asp:RequiredFieldValidator ID="RfvddlCategory1" runat="server" ControlToValidate="ddlCategory1" ValidationGroup="Submit" ForeColor="Red" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">


                                                <asp:DropDownList ID="ddlCategory1" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory1_SelectedIndexChanged"></asp:DropDownList>
                                            </div>

                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Resolution :
                                                  <asp:RequiredFieldValidator ID="rfvddlResoultion" runat="server" ControlToValidate="ddlResoultion" ValidationGroup="Submit" ForeColor="Red" InitialValue="0" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">


                                                <asp:DropDownList ID="ddlResoultion" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                            </div>

                                        </div>

                                        <div class="form-group row ">
                                            <%-- this is area for Category--%>
                                            <div class="col-lg-6 col-md-8 col-sm-12">


                                                <div id="divCategory2" class="form-group row" runat="server">


                                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                        Category2 : 
                                              <asp:RequiredFieldValidator ID="RfvddlCategory2" runat="server" InitialValue="0" ControlToValidate="ddlCategory2" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                                    </label>
                                                    <div class="col-sm-8 pr-5">


                                                        <asp:DropDownList ID="ddlCategory2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory2_SelectedIndexChanged" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div id="divCategory3" class="form-group row" runat="server">

                                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                        Category3 : 
                                              <asp:RequiredFieldValidator ID="RfvddlCategory3" runat="server" InitialValue="0" ControlToValidate="ddlCategory3" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="Required"></asp:RequiredFieldValidator>

                                                    </label>
                                                    <div class="col-sm-8 pr-5">


                                                        <asp:DropDownList ID="ddlCategory3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory3_SelectedIndexChanged" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div id="divCategory4" class="form-group row" runat="server">

                                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                        Category4 :
                                                    </label>
                                                    <div class="col-sm-8 pr-5">


                                                        <asp:DropDownList ID="ddlCategory4" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory4_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div id="divCategory5" class="form-group row" runat="server">

                                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                        Category5 :
                                                    </label>
                                                    <div class="col-sm-8 pr-5">


                                                        <asp:DropDownList ID="ddlCategory5" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory5_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group row " hidden>

                                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                        Category6 :
                                                    </label>
                                                    <div class="col-sm-8 pr-5">


                                                        <asp:DropDownList ID="ddlCategory6" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group row ">

                                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                        <asp:Label ID="tickAttach" runat="server" Text="Attachment"></asp:Label>
                                                    </label>
                                                    <div class="col-sm-8 pr-5">


                                                        <asp:LinkButton ID="lnkDownload" runat="server" Text="" OnClick="lnkDownload_Click"></asp:LinkButton>
                                                        <asp:FileUpload ID="FileUploadTickDoc" runat="server" CssClass="form-control form-control-sm p-0" ToolTip="Select Only Pdf,Excel File" />

                                                    </div>
                                                </div>
                                            </div>
                                            <%-- this is area for Custom Field--%>
                                            <div class="col-lg-6 col-md-8 col-ms-12">
                                                <div class="form-group row ">

                                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                        <asp:Label ID="Label2" Text="Stage" runat="server"></asp:Label>

                                                        <asp:RequiredFieldValidator ID="rfvddlStage" runat="server" ControlToValidate="ddlStage" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </label>


                                                    <div class="col-sm-8 pr-5">

                                                        <asp:DropDownList ID="ddlStage" runat="server" CssClass="form-control  form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlStage_SelectedIndexChanged"></asp:DropDownList>

                                                    </div>

                                                </div>
                                                <div class="form-group row " hidden>

                                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                        <asp:Label ID="lblStatus" Text="Status" runat="server"></asp:Label>

                                                        <asp:RequiredFieldValidator ID="rfvddlStatus" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Required" InitialValue="0" Font-Bold="true" ForeColor="Red" ValidationGroup="66t"></asp:RequiredFieldValidator>
                                                    </label>


                                                    <div class="col-sm-8 pr-5">

                                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control  form-control-sm chzn-select"></asp:DropDownList>

                                                    </div>

                                                </div>



                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-lg-6 col-md-8 col-ms-12">
                                                <asp:Repeater ID="rptOddControl" runat="server" OnItemDataBound="rptOddControl_ItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="form-group row ">

                                                            <label for="staticEmail" class="col-sm-4 fa-pull-left labelcolorl1 pl-4">
                                                                <asp:Label ID="lbl" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>

                                                                <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txt" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
                                                            </label>


                                                            <div class="col-sm-8 pr-5">

                                                                <asp:TextBox ID="txt" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>

                                                            </div>

                                                        </div>

                                                        <%--		<asp:PlaceHolder ID="pnlOddTypeCustFlds" runat="server"></asp:PlaceHolder>--%>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <asp:Repeater ID="rptddlOddControl" runat="server" OnItemDataBound="rptddlOddControl_ItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="form-group row ">

                                                            <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                                <asp:Label ID="lblOddlist" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>

                                                                <asp:RequiredFieldValidator ID="rfvddl" runat="server" ControlToValidate="ddlOdd" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
                                                            </label>


                                                            <div class="col-sm-8 pr-5">

                                                                <asp:DropDownList ID="ddlOdd" runat="server" CssClass="form-control  form-control-sm chzn-select"></asp:DropDownList>

                                                            </div>

                                                        </div>

                                                        <%--		<asp:PlaceHolder ID="pnlOddTypeCustFlds" runat="server"></asp:PlaceHolder>--%>
                                                    </ItemTemplate>
                                                </asp:Repeater>


                                            </div>
                                            <div class="col-lg-6 col-md-8 col-ms-12">
                                                <asp:Repeater ID="rptEvenControl" runat="server" OnItemDataBound="rptEvenControl_ItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="form-group row ">

                                                            <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                                <asp:Label ID="lbleven" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>

                                                                <asp:RequiredFieldValidator ID="rfvddl" runat="server" ControlToValidate="txteven" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
                                                            </label>


                                                            <div class="col-sm-8 pr-5">

                                                                <asp:TextBox ID="txteven" runat="server" CssClass="form-control  form-control-sm" Text='<%# Eval("FieldMode") %>'></asp:TextBox>

                                                            </div>

                                                        </div>
                                                        <%--<asp:PlaceHolder ID="pnlEvenTypeCustFlds" runat="server"></asp:PlaceHolder>--%>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <asp:Repeater ID="rptddlEvenControl" runat="server" OnItemDataBound="rptddlEvenControl_ItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="form-group row ">

                                                            <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                                <asp:Label ID="lblEvenlist" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>

                                                                <asp:RequiredFieldValidator ID="rfvddleveb" runat="server" ControlToValidate="ddlEven" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
                                                            </label>


                                                            <div class="col-sm-8 pr-5">

                                                                <asp:DropDownList ID="ddlEven" runat="server" CssClass="form-control  form-control-sm chzn-select"></asp:DropDownList>

                                                            </div>

                                                        </div>

                                                        <%--		<asp:PlaceHolder ID="pnlOddTypeCustFlds" runat="server"></asp:PlaceHolder>--%>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                        <div class="form-group row ">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Description : 
                                             <asp:RequiredFieldValidator ID="RfvtxtDescription" runat="server" ControlToValidate="txtDescription" ValidationGroup="Submit" ForeColor="Red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-10 pr-5">
                                                <%--	<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" MaxLength="500" Height="200px"></asp:TextBox>--%>
                                                <textarea id="txtDescription" runat="server" disabled="disabled" readonly="readonly"></textarea>
                                            </div>
                                        </div>
                                        <div class="form-group row ">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Notes : 
                                             <asp:RequiredFieldValidator ID="rfvtxtNotes" runat="server" ControlToValidate="txtNotes" ValidationGroup="Submit" ForeColor="Red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-10 pr-5">
                                                <%--	<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" MaxLength="500" Height="200px"></asp:TextBox>--%>
                                                <textarea id="txtNotes" runat="server"></textarea>
                                            </div>
                                        </div>
                                        <div class="form-group row ">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                                Resolution : 
                                            </label>
                                            <div class="col-sm-10 pr-5">
                                                <asp:RequiredFieldValidator ID="rfvtxtResolution" runat="server" ControlToValidate="txtResolution" ValidationGroup="Submit" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>

                                                <%--	<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" MaxLength="500" Height="200px"></asp:TextBox>--%>
                                                <textarea id="txtResolution" runat="server"></textarea>
                                            </div>
                                        </div>
                                    </asp:Panel>

                                </asp:Panel>

                                <%-- _____________Grid will Show Impact Details ________________________________--%>
                                <asp:Panel ID="pnlShowImpactDetails" runat="server">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <label>
                                                    Impact Details
                                                </label>
                                            </div>

                                            <div class="form-group row mt-3">
                                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                    Impact Description<span class="red">*</span>
                                                    <asp:RequiredFieldValidator ID="rfvtxtImpactDesc" runat="server" ControlToValidate="txtImpactDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                                    </asp:RequiredFieldValidator>
                                                </label>
                                                <div class="col-sm-10 pr-5">
                                                    <asp:TextBox ID="txtImpactDesc" TextMode="MultiLine" Rows="4" Columns="10" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-dm-2">
                                                    <asp:Button ID="btnAddImpactDetails" runat="server" Text="Add" CssClass="btn btn-sm savebtn" CausesValidation="false" OnClick="btnAddImpactDetails_Click"></asp:Button>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="gridAddImpact" runat="server" CssClass="table table-head-fixed text-nowrap  "
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="ImpactDetails" DataField="ImpactDetails" />
                                                        </Columns>
                                                        <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="5px" />
                                                        <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Left" Height="20px" VerticalAlign="NotSet" CssClass="header" />
                                                        <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" Height="5px" />
                                                        <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="5px" BorderColor="WhiteSmoke" CssClass="header sorting_asc" Font-Size="Small" />
                                                        <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" Height="5px" />
                                                        <EmptyDataRowStyle HorizontalAlign="Center" BorderStyle="None" Height="5px" BorderColor="#EDEDED" BackColor="#EDEDED" />
                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                        <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" Height="5px" BorderStyle="Solid" BorderWidth="1px" />

                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <asp:Panel ID="pnlImpactGrid" runat="server">
                                                <div class="row " style="border-bottom: solid 1px">
                                                    <div class="col-md-4">

                                                        <asp:Label ID="Label4" runat="server" Text="Impact Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Label ID="Label11" runat="server"></asp:Label>
                                                        <asp:Label ID="Label12" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2 " hidden>
                                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                            <label class="mr-2 ml-1 mb-0">Export</label>
                                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" />
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="table-responsive p-0" style="height: 400px">

                                                    <asp:GridView ID="gvImpactGrid" runat="server" CssClass="table table-head-fixed text-nowrap  " DataKeyNames="ID"
                                                        AutoGenerateColumns="false" AllowSorting="True">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="ImpactDetails" DataField="ImpactDescription" />
                                                        </Columns>
                                                        <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="5px" />
                                                        <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Left" Height="20px" VerticalAlign="NotSet" CssClass="header" />
                                                        <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" Height="5px" />
                                                        <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="5px" BorderColor="WhiteSmoke" CssClass="header sorting_asc" Font-Size="Small" />
                                                        <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" Height="5px" />
                                                        <EmptyDataRowStyle HorizontalAlign="Center" BorderStyle="None" Height="5px" BorderColor="#EDEDED" BackColor="#EDEDED" />
                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                        <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" Height="5px" BorderStyle="Solid" BorderWidth="1px" />

                                                    </asp:GridView>
                                                </div>
                                            </asp:Panel>

                                        </div>
                                    </div>
                                </asp:Panel>

                                <%--        ________________________ Grid will show RollOut Plan   _____________________________--%>

                                <asp:Panel ID="pnlShowRollOutDetails" runat="server">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <label>
                                                    Roll Out Details
                                                </label>
                                            </div>
                                            <div class="form-group row mt-3">
                                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                    RollOut Description<span class="red">*</span>
                                                    <asp:RequiredFieldValidator ID="rfvtxtRollOut" runat="server" ControlToValidate="txtRollOut" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                                    </asp:RequiredFieldValidator>
                                                </label>
                                                <div class="col-sm-10 pr-5">
                                                    <asp:TextBox ID="txtRollOut" TextMode="MultiLine" Rows="4" Columns="10" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-dm-2">
                                                    <asp:Button ID="btnAddRollOutGrid" runat="server" Text="Add" CssClass="btn btn-sm savebtn" CausesValidation="false" OnClick="btnAddRollOutGrid_Click"></asp:Button>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="gridAddRollOut" runat="server" CssClass="table table-head-fixed text-nowrap  "
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="5px">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="RollOutDetails" DataField="RollOutDetails" />
                                                        </Columns>
                                                        <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="5px" />
                                                        <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Left" Height="20px" VerticalAlign="NotSet" CssClass="header" />
                                                        <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" Height="5px" />
                                                        <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="5px" BorderColor="WhiteSmoke" CssClass="header sorting_asc" Font-Size="Small" />
                                                        <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" Height="5px" />
                                                        <EmptyDataRowStyle HorizontalAlign="Center" BorderStyle="None" Height="5px" BorderColor="#EDEDED" BackColor="#EDEDED" />
                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                        <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" Height="5px" BorderStyle="Solid" BorderWidth="1px" />

                                                    </asp:GridView>
                                                </div>
                                            </div>

                                            <asp:Panel ID="pnlRollOutGrid" runat="server">
                                                <div class="row " style="border-bottom: solid 1px">
                                                    <div class="col-md-4">

                                                        <asp:Label ID="Label5" runat="server" Text="RollOut Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Label ID="Label6" runat="server"></asp:Label>
                                                        <asp:Label ID="Label7" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2 " hidden>
                                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                            <label class="mr-2 ml-1 mb-0">Export</label>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" />
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="table-responsive p-0" style="height: 400px">

                                                    <asp:GridView ID="gvRollOutDetails" runat="server" CssClass="table table-head-fixed text-nowrap  " DataKeyNames="ID"
                                                        AutoGenerateColumns="false" AllowSorting="True">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="RollOutDetails" DataField="RolloutDescription" />
                                                        </Columns>
                                                        <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="5px" />
                                                        <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Left" Height="20px" VerticalAlign="NotSet" CssClass="header" />
                                                        <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" Height="5px" />
                                                        <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="5px" BorderColor="WhiteSmoke" CssClass="header sorting_asc" Font-Size="Small" />
                                                        <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" Height="5px" />
                                                        <EmptyDataRowStyle HorizontalAlign="Center" BorderStyle="None" Height="5px" BorderColor="#EDEDED" BackColor="#EDEDED" />
                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                        <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" Height="5px" BorderStyle="Solid" BorderWidth="1px" />

                                                    </asp:GridView>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <%--        ________________________ Grid will show DownTime Plan   _____________________________--%>
                                <asp:Panel ID="pnlDownTime" runat="server" CssClass="mb-1">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <label>
                                                    Down Time Details
                                                </label>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>
                                                        Summary :
                                                    </label>
                                                    <asp:TextBox ID="txtDownTimeName" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="ml-1">
                                                        Duration From :
                                                    </label>
                                                    <div class="col-sm-12">
                                                        <div class="input-group ">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text"><i class="fas fa-calendar"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txtDownTimeStart" runat="server" CssClass="form-control form-control-sm" MaxLength="10" autocomplete="off" ClientIDMode="static"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="ml-1">
                                                        Duration To :
                                                    </label>
                                                    <div class="col-sm-12">
                                                        <div class="input-group ">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text"><i class="fas fa-calendar"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txtDownTimeTo" runat="server" CssClass="form-control form-control-sm" MaxLength="10" autocomplete="off" ClientIDMode="static"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <%--        ________________________ Task Association   _____________________________--%>
                                <asp:Panel ID="pnlTaksAssociation" runat="server" CssClass="mb-1">

                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <label>
                                                    Task Association
                                                </label>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-5">
                                                    <label>
                                                        Task Summary :
                                                    </label>
                                                    <asp:TextBox ID="txtTaskSummary" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="ml-1">
                                                        Task Status :
                                                    </label>

                                                    <asp:DropDownList ID="ddlTaskStatus" runat="server" CssClass="form-control form-control-sm chzn-select">
                                                        <asp:ListItem Text="Open" Selected="True" Value="Open"></asp:ListItem>
                                                        <asp:ListItem Text="WIP" Value="WIP"></asp:ListItem>
                                                        <asp:ListItem Text="Hold" Value="Hold"></asp:ListItem>
                                                        <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                                <div class="col-md-3">
                                                    <label class="ml-1">
                                                        Technician Associaiton :
                                                    </label>

                                                    <asp:ListBox ID="lstTechAssoc" runat="server" CssClass="form-control form-control-sm chzn-select" SelectionMode="Multiple"></asp:ListBox>

                                                </div>

                                            </div>
                                            <div class="row">
                                                <div class="col-md-1">
                                                    <div class="col-dm-2">
                                                        <asp:Button ID="btnAddTaskAssociationData" runat="server" Text="Add" CssClass="btn btn-sm savebtn" CausesValidation="false" OnClick="btnAddTaskAssociationData_Click"></asp:Button>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="gvAddTask" runat="server" CssClass="table table-head-fixed text-nowrap  "
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="Task Description" DataField="TaskDescription" />
                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="Status" DataField="Status" />
                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="Engineer Association" DataField="EngineerAssociation" />




                                                        </Columns>
                                                        <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="5px" />
                                                        <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Left" Height="20px" VerticalAlign="NotSet" CssClass="header" />
                                                        <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" Height="5px" />
                                                        <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="5px" BorderColor="WhiteSmoke" CssClass="header sorting_asc" Font-Size="Small" />
                                                        <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" Height="5px" />
                                                        <EmptyDataRowStyle HorizontalAlign="Center" BorderStyle="None" Height="5px" BorderColor="#EDEDED" BackColor="#EDEDED" />
                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                        <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" Height="5px" BorderStyle="Solid" BorderWidth="1px" />

                                                    </asp:GridView>
                                                </div>
                                            </div>

                                            <asp:Panel ID="pnlShowTaskDetails" runat="server">
                                                <div class="row " style="border-bottom: solid 1px">
                                                    <div class="col-md-4">

                                                        <asp:Label ID="Label8" runat="server" Text="Task Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Label ID="Label9" runat="server"></asp:Label>
                                                        <asp:Label ID="Label10" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2 " hidden>
                                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                            <label class="mr-2 ml-1 mb-0">Export</label>
                                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" />
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="table-responsive p-0" style="height: 400px">

                                                    <asp:GridView ID="gvTaskDetails" runat="server" CssClass="table table-head-fixed text-nowrap  " DataKeyNames="ID"
                                                        AutoGenerateColumns="false" AllowSorting="True">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="Task ID" DataField="SubTicketRef" />

                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="Task Description" DataField="TaskDesc" />
                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="Status" DataField="Status" />
                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="Engineer Association" DataField="Assignee" />

                                                        </Columns>
                                                        <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="5px" />
                                                        <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Left" Height="20px" VerticalAlign="NotSet" CssClass="header" />
                                                        <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" Height="5px" />
                                                        <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="5px" BorderColor="WhiteSmoke" CssClass="header sorting_asc" Font-Size="Small" />
                                                        <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" Height="5px" />
                                                        <EmptyDataRowStyle HorizontalAlign="Center" BorderStyle="None" Height="5px" BorderColor="#EDEDED" BackColor="#EDEDED" />
                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                        <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" Height="5px" BorderStyle="Solid" BorderWidth="1px" />

                                                    </asp:GridView>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="Submit" OnClick="btnUpdate_Click" CssClass="btn btn-sm savebtn " />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" CssClass="btn btn-sm cancelbtn " />
                                    </div>
                                </div>
                            </asp:Panel>

                            <asp:Panel ID="pnlViewNotes" runat="server" Visible="false">
                                <div class="row">
                                    <div class="col-md-8 graphs">
                                        <div class="xs">
                                            <div class="well1 white">
                                                <div class="card card-default">

                                                    <div class="card-body">
                                                        <div class="row ">
                                                            <div class="col-md-4">

                                                                <asp:Label ID="lblsofname" runat="server" Text="Ticket Notes" Font-Size="Larger" ForeColor="Black"></asp:Label>

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
                                                        <asp:GridView GridLines="None" ID="gvTicketNotes" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                                            Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                    <ItemTemplate>
                                                                        <%#Container.DataItemIndex+1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="EditedDt" HeaderText="
														Event Time"
                                                                    SortExpression="EditedDt" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}" />
                                                                <asp:BoundField DataField="Ticketref" HeaderText="Ticket Number"
                                                                    SortExpression="Ticketref" />

                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description">

                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Server.HtmlDecode(Eval("NoteDesc").ToString()) %>'> </asp:Label>
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
                            </asp:Panel>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="ddlStage" />
            <asp:PostBackTrigger ControlID="ddlRequestType" />
            <asp:PostBackTrigger ControlID="btnUpdateTickView" />
            <asp:PostBackTrigger ControlID="btnViewNotes" />
            <asp:PostBackTrigger ControlID="ddlAssigne" />
            <asp:PostBackTrigger ControlID="ddlCategory1" />
            <asp:PostBackTrigger ControlID="ddlCategory2" />
            <asp:PostBackTrigger ControlID="ddlCategory3" />
            <asp:PostBackTrigger ControlID="ddlCategory4" />
            <asp:PostBackTrigger ControlID="ddlCategory5" />
            <asp:PostBackTrigger ControlID="lnkDownload" />
            <asp:PostBackTrigger ControlID="ddlCategory6" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
            <asp:PostBackTrigger ControlID="btnCancel" />
            <asp:PostBackTrigger ControlID="rptddlOddControl" />
            <asp:PostBackTrigger ControlID="rptddlEvenControl" />
            <asp:PostBackTrigger ControlID="rptOddControl" />
            <asp:PostBackTrigger ControlID="rptEvenControl" />


            <asp:PostBackTrigger ControlID="btnUpdateTickView" />
            <asp:PostBackTrigger ControlID="btnViewNotes" />
            <asp:PostBackTrigger ControlID="btnImpactDetails" />
            <asp:PostBackTrigger ControlID="btnRolloutPlan" />
            <asp:PostBackTrigger ControlID="btnDowntime" />
            <asp:PostBackTrigger ControlID="btnTaskAssociation" />
        </Triggers>

    </asp:UpdatePanel>
    <asp:HiddenField ID="hdnCategoryID" runat="server" />

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
    <link rel="stylesheet" type="text/css" href="../Script/build/jquery.datetimepicker.css" />
    <script src="../Script/build/jquery.js"></script>
    <script src="../Script/build/jquery.datetimepicker.full.js"></script>

    <script src="../plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap -->

    <!-- overlayScrollbars -->
    <script src="../plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript"> $(".chzn-select").chosen();

        $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    <link rel="stylesheet" href="../Scripts/chosen.css" />
    <script src="../plugins/toastr/toastr.min.js"></script>
    <script src="../plugins/sweetalert2/sweetalert2.min.js"></script>

    <script src="../plugins/summernote/summernote-bs4.min.js"></script>
    <script>
        $(document).ready(function () {


            $('#<%= txtDescription.ClientID %>').summernote('disable');
            $('#<%= txtNotes.ClientID %>').summernote();
            $('#<%= txtResolution.ClientID %>').summernote();
        });
    </script>
</asp:Content>

