<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddIncident.aspx.cs" Inherits="frmAddIncident" %>

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

        .hidden-dropdown {
            visibility: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row mb-1">
        <div class="col-md-6 col-lg-12 col-sm-4">
            <div class="card card-default">

                <div class="card-body">

                    <div class="row">
                        <div class="col-md-6 col-lg-12 col-sm-4">
                            <label class="cardheader">New Ticket</label>
                            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red" Style="font-weight: bold;"></asp:Label>
                        </div>
                    </div>
                    <asp:Panel ID="showChangeControl" runat="server">
                        <div class="row mb-1">
                            <div class="col-lg-12 col-md-6 col-sm-4">
                                <asp:Button ID="btnShowBasicDetails" runat="server" Text="Basic Details" CssClass="btn btn-sm btnEnabled" CausesValidation="false" OnClick="btnShowBasicDetails_Click" />
                                <asp:Button ID="btnImpactDetails" runat="server" Text="Impact Details" CssClass="btn btn-sm btnDisabled" CausesValidation="false" OnClick="btnImpactDetails_Click" />
                                <asp:Button ID="btnRolloutPlan" runat="server" Text="RollOut Details" CssClass="btn btn-sm btnDisabled" CausesValidation="false" OnClick="btnRolloutPlan_Click" />
                                <asp:Button ID="btnDowntime" runat="server" Text="Downtime" CssClass="btn btn-sm btnDisabled" CausesValidation="false" OnClick="btnDowntime_Click" />
                                <asp:Button ID="btnTaskAssociation" runat="server" Text="Task " CssClass="btn btn-sm btnDisabled" CausesValidation="false" OnClick="btnTaskAssociationShowPanel_Click" />
                            </div>
                        </div>

                    </asp:Panel>

                    <asp:Panel ID="pnlIncident" runat="server">
                        <div class="form-group row mt-2">
                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4 ">
                                Service Desk : <span class="red">*</span>
                                <asp:RequiredFieldValidator ID="RfvddlRequestType" runat="server" InitialValue="0" ControlToValidate="ddlRequestType" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-4 pr-5">
                                <asp:DropDownList ID="ddlRequestType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                            </div>
                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                Employee ID<span class="red">*</span>
                                <asp:RequiredFieldValidator ID="rfvtxtLoginName" runat="server" ControlToValidate="txtLoginName" ErrorMessage="*" ForeColor="Red" ValidationGroup="SearchUser"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-4">
                                <div class="input-group input-group-sm pr-5">
                                    <asp:TextBox ID="txtLoginName" runat="server" class="form-control form-control-sm" autocomplete="off" ValidationGroup="SearchUser"></asp:TextBox>
                                    <div class="input-group-append">
                                        <asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" Width="30" ValidationGroup="SearchUser" BackColor="blue" ImageUrl="~/Images/icons_search.png"></asp:ImageButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row ">
                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                Summary : 
                                                <asp:RequiredFieldValidator ID="RfvtxtSummary" runat="server" ControlToValidate="txtSummary" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-10 pr-5">
                                <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row ">
                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                Submitter Name:
                                                   <asp:RequiredFieldValidator ID="RfvtxtSubmitterName" runat="server" ControlToValidate="txtSubmitterName" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-4 pr-5">
                                <asp:TextBox ID="txtSubmitterName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                            </div>
                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-1">
                                Submitter Email : 
							<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSubmitterEmail"
                                ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                Display="Dynamic" ErrorMessage="Invalid email " ValidationGroup="Addticket" />
                                <asp:RequiredFieldValidator ID="RfvtxtSubmitterEmail" runat="server" ControlToValidate="txtSubmitterEmail" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-4 pr-5">
                                <asp:TextBox ID="txtSubmitterEmail" runat="server" TextMode="Email" CssClass="form-control form-control-sm"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row ">
                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                Contact Number: 
                                               <asp:RequiredFieldValidator ID="RfvtxtPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-4 pr-5">
                                <asp:TextBox ID="txtPhoneNumber" runat="server" TextMode="Number" CssClass="form-control form-control-sm"></asp:TextBox>
                            </div>
                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                Priority : 
                                  
                                    <asp:RequiredFieldValidator ID="rfvddlPriority" runat="server" ControlToValidate="ddlPriority" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-4 pr-5">
                                <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row " hidden>
                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                AgentGuid: 
							<%--                                                   <asp:RequiredFieldValidator ID="rfvtxtAgentGuid" runat="server" ControlToValidate="txtAgentGuid" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                            </label>
                            <div class="col-sm-4 pr-5">
                                <asp:TextBox ID="txtAgentGuid" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                            </div>
                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                Host Name : 
                                  
							<%--                                        <asp:RequiredFieldValidator ID="rfvtxtHostName" runat="server" ControlToValidate="txtHostName" ErrorMessage="*" ForeColor="Red" ValidationGroup="Addticket"></asp:RequiredFieldValidator>--%>
                            </label>
                            <div class="col-sm-4 pr-5">
                                <asp:TextBox ID="txtHostName" runat="server" CssClass="form-control form-control-sm "></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group row ">
                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                Location: 
                                               <asp:RequiredFieldValidator ID="rfvddlLocation" runat="server" ControlToValidate="ddlLocation" ValidationGroup="Addticket" InitialValue="0" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-4 pr-5">
                                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control form-control-sm chzn-select">
                                </asp:DropDownList>
                            </div>
                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                Department : 
                                  
                                    <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-4 pr-5">
                                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                            </div>
                        </div>
                        <asp:Panel ID="pnlChange" runat="server">
                            <div class="form-group row mb-0 pb-0">
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    Change Type: 
                                               <asp:RequiredFieldValidator ID="rfvddlChangeType" runat="server" InitialValue="0" ControlToValidate="ddlChangeType" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </label>
                                <div class="col-sm-4 pr-5">
                                    <asp:DropDownList ID="ddlChangeType" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                </div>
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    Reason For Change : 
                                  
                                    <asp:RequiredFieldValidator ID="rfvddlRFC" runat="server" ControlToValidate="ddlRFC" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                </label>
                                <div class="col-sm-4 pr-5">
                                    <asp:DropDownList ID="ddlRFC" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row ">
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    Duration From: 
                                               <asp:RequiredFieldValidator ID="rfvtxtChangeDurationfrom" runat="server" ControlToValidate="txtChangeDurationfrom" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </label>
                                <div class="col-sm-4 pr-5">
                                    <div class="input-group ">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-calendar"></i></span>
                                        </div>
                                        <asp:TextBox ID="txtChangeDurationfrom" runat="server" CssClass="form-control form-control-sm" MaxLength="10" autocomplete="off" ClientIDMode="static"></asp:TextBox>
                                    </div>
                                </div>
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    Duration To : 
                                  
                                    <asp:RequiredFieldValidator ID="rfvtxtChangeDurationTo" runat="server" ControlToValidate="txtChangeDurationTo" ErrorMessage="*" ForeColor="Red" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                </label>
                                <div class="col-sm-4 pr-5">
                                    <div class="input-group ">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-calendar"></i></span>
                                        </div>
                                        <asp:TextBox ID="txtChangeDurationTo" runat="server" CssClass="form-control form-control-sm " MaxLength="10" autocomplete="off" ClientIDMode="static"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlCloud" runat="server">
                            <div class="form-group row ">
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    Account ID: 
                                               <asp:RequiredFieldValidator ID="rfvtxtAccountID" runat="server" ControlToValidate="txtAccountID" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="txtAccountID" ErrorMessage="Not Greater than 12 digits!!" ForeColor="Red" ValidationGroup="Addticket"
                                        ValidationExpression="[0-9]{12}"></asp:RegularExpressionValidator>

                                </label>
                                <div class="col-sm-4 pr-5">
                                    <asp:TextBox ID="txtAccountID" runat="server" TextMode="Number" CssClass="form-control form-control-sm"></asp:TextBox>
                                </div>
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    User Email : 
                                  
                                    <asp:RequiredFieldValidator ID="rfvtxtUserEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="*" ForeColor="Red" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                </label>
                                <div class="col-sm-4 pr-5">
                                    <asp:TextBox ID="txtUserEmail" runat="server" CssClass="form-control form-control-sm "></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row ">
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    Not As Submitter Email: 
						
                                </label>
                                <div class="col-sm-4 pr-5">
                                    <asp:CheckBox ID="checkAnotherEmail" runat="server" CssClass="form-control form-control-sm"></asp:CheckBox>
                                </div>
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    Email Change Reason : 
                                  
                                    <asp:RequiredFieldValidator ID="rfvtxtEmailReason" runat="server" ControlToValidate="txtEmailReason" ErrorMessage="*" ForeColor="Red" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                </label>
                                <div class="col-sm-4 pr-5">
                                    <asp:TextBox ID="txtEmailReason" runat="server" CssClass="form-control form-control-sm "></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row ">
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    Duration From: 
                                               <asp:RequiredFieldValidator ID="rfvtxtDurationFrom" runat="server" ControlToValidate="txtDurationFrom" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </label>
                                <div class="col-sm-4 pr-5">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-calendar"></i></span>
                                        </div>
                                        <asp:TextBox ID="txtDurationFrom" runat="server" CssClass="form-control form-control-sm" MaxLength="10" autocomplete="off" ClientIDMode="static"></asp:TextBox>
                                    </div>
                                </div>
                                <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                    Duration To : 
                                    <asp:RequiredFieldValidator ID="rfvtxtDurationto" runat="server" ControlToValidate="txtDurationto" ErrorMessage="*" ForeColor="Red" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                </label>
                                <div class="col-sm-4 pr-5">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-calendar"></i></span>
                                        </div>
                                        <asp:TextBox ID="txtDurationto" runat="server" CssClass="form-control form-control-sm " MaxLength="10" autocomplete="off" ClientIDMode="static"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="form-group row ">
                            <%-- this is area for Category--%>
                            <div class="col-lg-6 col-md-8 col-sm-12">
                                <div class="form-group row ">
                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                        Severity :<asp:RequiredFieldValidator ID="RfvddlSeverity" runat="server" ControlToValidate="ddlSeverity" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="Addticket" Enabled="false"></asp:RequiredFieldValidator>
                                        &nbsp;</label>
                                    <div class="col-sm-8 pr-5">
                                        <asp:DropDownList ID="ddlSeverity" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                    </div>

                                </div>
                                <div id="divCategory1" class="form-group row" runat="server">

                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">

                                        <asp:Label ID="lblCategory1" runat="server" Text="Category1 :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RfvddlCategory1" runat="server" ControlToValidate="ddlCategory1" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-8 pr-5">


                                        <asp:DropDownList ID="ddlCategory1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory1_SelectedIndexChanged" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                    </div>

                                </div>
                                <div id="divCategory2" class="form-group row" runat="server">


                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                        <asp:Label ID="lblCategory2" runat="server" Text="Category2 :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RfvddlCategory2" runat="server" InitialValue="0" ControlToValidate="ddlCategory2" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-8 pr-5">


                                        <asp:DropDownList ID="ddlCategory2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory2_SelectedIndexChanged" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                    </div>
                                </div>
                                <div id="divCategory3" class="form-group row" runat="server">

                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                        <asp:Label ID="lblCategory3" runat="server" Text="Category3 :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RfvddlCategory3" runat="server" InitialValue="0" ControlToValidate="ddlCategory3" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>

                                    </label>
                                    <div class="col-sm-8 pr-5">


                                        <asp:DropDownList ID="ddlCategory3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory3_SelectedIndexChanged" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                    </div>
                                </div>
                                <div id="divCategory4" class="form-group row" runat="server">

                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                        <asp:Label ID="lblCategory4" runat="server" Text="Category4 :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfvddlCategory4" runat="server" InitialValue="0" ControlToValidate="ddlCategory4" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>

                                    </label>
                                    <div class="col-sm-8 pr-5">


                                        <asp:DropDownList ID="ddlCategory4" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory4_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div id="divCategory5" class="form-group row" runat="server">

                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                        <asp:Label ID="lblCategory5" runat="server" Text="Category5 :"></asp:Label>
                                    </label>
                                    <div class="col-sm-8 pr-5">


                                        <asp:DropDownList ID="ddlCategory5" runat="server" CssClass="form-control form-control-sm chzn-select hidden-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory5_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row " hidden>

                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                        Category6 :
                                    </label>
                                    <div class="col-sm-8 pr-5">


                                        <asp:DropDownList ID="ddlCategory6" runat="server" CssClass="form-control form-control-sm chzn-select "></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row ">

                                    <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                        Attach File :
									 <asp:Label ID="lblinvoiceupload" runat="server" Text=""></asp:Label>
                                    </label>
                                    <div class="col-sm-8 pr-5">


                                        <asp:FileUpload ID="FileUploadTickDoc" runat="server" CssClass="form-control form-control-sm p-0" ToolTip="Select Only Pdf,Excel File" />

                                    </div>
                                </div>
                            </div>
                            <%-- this is area for Custom Field--%>
                            <div class="col-lg-6 col-md-8 col-ms-12">


                                <asp:Repeater ID="rptOddControl" runat="server" OnItemDataBound="rptOddControl_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="form-group row ">

                                            <label for="staticEmail" class="col-sm-4 fa-pull-left labelcolorl1 pl-4">
                                                <asp:Label ID="lbl" Text='<%# Eval("FieldValue") %>' Visible="false" runat="server"></asp:Label>
                                                <asp:Label ID="Label1" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txt" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
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
                                                <asp:Label ID="lblOddlist" Text='<%# Eval("FieldValue") %>' Visible="false" runat="server"></asp:Label>
                                                <asp:Label ID="Label2" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>

                                                <asp:RequiredFieldValidator ID="rfvddl" runat="server" ControlToValidate="ddlOdd" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-8 pr-5">
                                                <asp:DropDownList ID="ddlOdd" runat="server" CssClass="form-control  form-control-sm chzn-select"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <%--		<asp:PlaceHolder ID="pnlOddTypeCustFlds" runat="server"></asp:PlaceHolder>--%>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="rptEvenControl" runat="server" OnItemDataBound="rptEvenControl_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="form-group row ">

                                            <label for="staticEmail" class="col-sm-4 labelcolorl1 pl-4">
                                                <asp:Label ID="lbleven" Text='<%# Eval("FieldValue") %>' Visible="false" runat="server"></asp:Label>
                                                <asp:Label ID="Label3" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>

                                                <asp:RequiredFieldValidator ID="rfvddl" runat="server" ControlToValidate="txteven" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
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
                                                <asp:Label ID="lblEvenlist" Text='<%# Eval("FieldValue") %>' Visible="false" runat="server"></asp:Label>
                                                <asp:Label ID="Label4" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>

                                                <asp:RequiredFieldValidator ID="rfvddleveb" runat="server" ControlToValidate="ddlEven" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
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
                                Issue in Detail : 
                                             <asp:RequiredFieldValidator ID="RfvtxtDescription" runat="server" ControlToValidate="txtDescription" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-10 pr-5">
                                <%--	<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" MaxLength="500" Height="200px"></asp:TextBox>--%>
                                <asp:TextBox ID="txtDescription" runat="server" Rows="5" Columns="5" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>

                    </asp:Panel>
                    <div class="row">
                        <div class="col-md-4">
                        </div>
                    </div>



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
                                        <asp:RequiredFieldValidator ID="rfvtxtImpactDesc" runat="server" ControlToValidate="txtImpactDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddImapct">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-10 pr-5">
                                        <asp:TextBox ID="txtImpactDesc" TextMode="MultiLine" Rows="4" Columns="10" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-2 offset-6  mt-3">
                                        <asp:Button ID="btnAddImpactDetails" runat="server" Text="Add" CssClass="btn btn-sm bg-success" CausesValidation="true" ValidationGroup="AddImapct" OnClick="btnAddImpactDetails_Click"></asp:Button>
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
                                        <asp:RequiredFieldValidator ID="rfvtxtRollOut" runat="server" ControlToValidate="txtRollOut" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="RollOut">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-10 pr-5">
                                        <asp:TextBox ID="txtRollOut" TextMode="MultiLine" Rows="4" Columns="10" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-dm-2">
                                        <asp:Button ID="btnAddRollOutGrid" runat="server" Text="Add" CssClass="btn btn-sm bg-success" CausesValidation="true" ValidationGroup="RollOut" OnClick="btnAddRollOutGrid_Click"></asp:Button>
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
																				<asp:RequiredFieldValidator ID="rfvtxtTaskSummary" runat="server" ControlToValidate="txtTaskSummary" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Task">
                                                                                </asp:RequiredFieldValidator>

                                        </label>
                                        <asp:TextBox ID="txtTaskSummary" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="ml-1">
                                            Task Status :
                                        </label>

                                        <asp:DropDownList ID="ddlTaskStatus" runat="server" Enabled="false" CssClass="form-control form-control-sm chzn-select">
                                            <asp:ListItem Text="Open" Selected="True" Value="Open"></asp:ListItem>
                                            <asp:ListItem Text="WIP" Value="WIP"></asp:ListItem>
                                            <asp:ListItem Text="Hold" Value="Hold"></asp:ListItem>
                                            <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div class="col-md-3">
                                        <label class="ml-1">
                                            Technician Associaiton :
													<asp:RequiredFieldValidator ID="rfvlstTechAssoc" runat="server" ControlToValidate="lstTechAssoc" ErrorMessage="*" InitialValue="0" Font-Bold="true" ForeColor="Red" ValidationGroup="Task">
                                                    </asp:RequiredFieldValidator>
                                        </label>

                                        <asp:ListBox ID="lstTechAssoc" runat="server" CssClass="form-control form-control-sm chzn-select" SelectionMode="Multiple"></asp:ListBox>

                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-1">
                                        <div class="col-dm-2">
                                            <asp:Button ID="btnAddTaskAssociationData" runat="server" Text="Add" CssClass="btn btn-sm bg-success" ValidationGroup="Task" OnClick="btnAddTaskAssociationData_Click"></asp:Button>
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


                            </div>
                        </div>
                    </asp:Panel>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Button ID="btnPrev" runat="server" Text="Prev" CausesValidation="false" OnClick="btnPrev_Click" CssClass="btn btn-sm cancelbtn " />


                            <asp:Button ID="btnNext" runat="server" Text="Next" ValidationGroup="Addticket" CausesValidation="false" OnClick="btnNext_Click" CssClass="btn btn-sm savebtn " />

                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="Addticket" OnClick="btnSubmit_Click" CssClass="btn btn-sm savebtn " />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" CssClass="btn btn-sm cancelbtn " />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <%--			  </ContentTemplate>
  
    <Triggers>
    
		 <asp:PostBackTrigger ControlID="rptOddControl" />
         
		 <asp:PostBackTrigger ControlID="btnSearch" />
         
         <asp:PostBackTrigger ControlID="btnSubmit" />
         
               
    </Triggers>
     
</asp:UpdatePanel>--%>
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

    <script>
        $.datetimepicker.setLocale('en');
        $('#txtChangeDurationfrom').datetimepicker({
            dayOfWeekStart: 1,
            lang: 'en',
            startDate: '+1d'
        });

    </script>
    <script>
        $.datetimepicker.setLocale('en');
        $('#rfvtxtChangeDurationTo').datetimepicker({
            dayOfWeekStart: 1,
            lang: 'en',
            startDate: '+1d'
        });

    </script>
    <script>
        $.datetimepicker.setLocale('en');
        $('#txtDurationFrom').datetimepicker({
            dayOfWeekStart: 1,
            lang: 'en',
            startDate: '+1d'
        });

    </script>
    <script>
        $.datetimepicker.setLocale('en');
        $('#txtDownTimeTo').datetimepicker({
            dayOfWeekStart: 1,
            lang: 'en',
            startDate: '+1d'
        });

    </script>
    <script>
        $.datetimepicker.setLocale('en');
        $('#txtDurationto').datetimepicker({
            dayOfWeekStart: 1,
            lang: 'en',
            startDate: '+1d'
        });
    </script>
    <script>
        $.datetimepicker.setLocale('en');
        $('#txtDownTimeStart').datetimepicker({
            dayOfWeekStart: 1,
            lang: 'en',
            startDate: '+1d'
        });

    </script>
    <script src="../plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap -->
    <%--<script src="../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>--%>
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
        // Summernote
	//	var textarea = document.getElementById('<%=txtDescription.ClientID %>');
            //	textarea.summernote()

            $('#<%= txtDescription.ClientID %>').summernote();
        });
    </script>
    <script type="text/javascript">
        function clearLabelAfter5Seconds() {
            setTimeout(function () {
                var label = document.getElementById('<%= lblErrorMsg.ClientID %>');
                if (label) {
                    label.innerHTML = '';
                }
            }, 5000); // 5000 milliseconds = 5 seconds
        }
        window.onload = clearLabelAfter5Seconds;
    </script>
</asp:Content>

