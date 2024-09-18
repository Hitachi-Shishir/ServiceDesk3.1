<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddIncident.aspx.cs" Inherits="frmAddIncident" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="assets/plugins/summernote/jquery.js"></script>
    <link href="assets/plugins/summernote/summernote-bs4.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>
    <style>
        .note-editor {
            border: var(--bs-border-width) var(--bs-border-style) var(--bs-border-color) !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scrmg" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
          
            <div class="card ">
                <div class="card-body">

                    <div class="row">
                        <div class="col-md-6 col-lg-12 col-sm-4">

                            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red" Style="font-weight: bold;"></asp:Label>
                        </div>
                    </div>
                    <asp:Panel ID="showChangeControl" runat="server">
                        <div class="row mb-2">
                            <div class="col-12 ">
                                <div class="btn-group">
                                    <asp:Button ID="btnShowBasicDetails" runat="server" Text="Basic Details" CssClass="btn btn-sm  btn-outline-secondary btnEnabled" CausesValidation="false" OnClick="btnShowBasicDetails_Click" />
                                    <asp:Button ID="btnImpactDetails" runat="server" Text="Impact Details" CssClass="btn btn-sm btn-outline-secondary btnDisabled" CausesValidation="false" OnClick="btnImpactDetails_Click" />
                                    <asp:Button ID="btnRolloutPlan" runat="server" Text="RollOut Details" CssClass="btn btn-sm btn-outline-secondary btnDisabled" CausesValidation="false" OnClick="btnRolloutPlan_Click" />
                                    <asp:Button ID="btnDowntime" runat="server" Text="Downtime" CssClass="btn btn-sm btn-outline-secondary btnDisabled" CausesValidation="false" OnClick="btnDowntime_Click" />
                                    <asp:Button ID="btnTaskAssociation" runat="server" Text="Task " CssClass="btn btn-sm btn-outline-secondary btnDisabled" CausesValidation="false" OnClick="btnTaskAssociationShowPanel_Click" />
                                </div>
                            </div>
                        </div>

                    </asp:Panel>

                    <asp:Panel ID="pnlIncident" runat="server">
                        <div class="card border bg-transparent shadow-none mb-3">
                            <div class="card-body">
                                <div class="row gx-2 gy-2">
                                    <div class="col-md-6">
                                        <label class="form-label" for="staticEmail">
                                            Service Desk  
                                            <asp:RequiredFieldValidator ID="RfvddlRequestType" runat="server" InitialValue="0" ControlToValidate="ddlRequestType" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:DropDownList ID="ddlRequestType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <label for="staticEmail" class="form-label">
                                            Employee ID 
                                            <asp:RequiredFieldValidator ID="rfvtxtLoginName" runat="server" ControlToValidate="txtLoginName" ErrorMessage="*" ForeColor="Red" ValidationGroup="SearchUser"></asp:RequiredFieldValidator>
                                        </label>
                                        <div class="input-group input-group-sm ">
                                            <asp:TextBox ID="txtLoginName" runat="server" class="form-control form-control-sm" autocomplete="off" ValidationGroup="SearchUser"></asp:TextBox>
                                            <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" ValidationGroup="SearchUser" CssClass="btn btn-sm btn-outline-secondary"><i class="fa-solid fa-search"></i></asp:LinkButton>
                                        </div>

                                    </div>
                                    <div class="col-md-12">
                                        <label for="staticEmail" class="form-label">
                                            Summary 
                                <asp:RequiredFieldValidator ID="RfvtxtSummary" runat="server" ControlToValidate="txtSummary" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>

                                        <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3 col-6">
                                        <label for="staticEmail" class="form-label">
                                            Submitter Name
                                 <asp:RequiredFieldValidator ID="RfvtxtSubmitterName" runat="server" ControlToValidate="txtSubmitterName" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="txtSubmitterName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </div>
                                    <div class="col-md-3 col-6">
                                        <label for="staticEmail" class="form-label">
                                            Submitter Email 
				<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSubmitterEmail"
                    ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                    Display="Dynamic" ErrorMessage="Invalid email " ValidationGroup="Addticket" />
                                            <asp:RequiredFieldValidator ID="RfvtxtSubmitterEmail" runat="server" ControlToValidate="txtSubmitterEmail" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>

                                        <asp:TextBox ID="txtSubmitterEmail" runat="server" TextMode="Email" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3 col-6">
                                        <label for="staticEmail" class="form-label">
                                            Contact Number
                                   <asp:RequiredFieldValidator ID="RfvtxtPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>

                                        <asp:TextBox ID="txtPhoneNumber" runat="server" TextMode="Number" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3 col-6">
                                        <label for="staticEmail" class="form-label">
                                            Priority
                              <asp:RequiredFieldValidator ID="rfvddlPriority" runat="server" ControlToValidate="ddlPriority" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                        </label>

                                        <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3 col-6">
                                        <label for="staticEmail" class="form-label">
                                            Location
                             <asp:RequiredFieldValidator ID="rfvddlLocation" runat="server" ControlToValidate="ddlLocation" ValidationGroup="Addticket" InitialValue="0" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3 col-6">
                                        <label for="staticEmail" class="form-label">
                                            Department              
                  <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group row " hidden>
                                    <label for="staticEmail" class="form-label">
                                        AgentGuid: 
							<%--                                                   <asp:RequiredFieldValidator ID="rfvtxtAgentGuid" runat="server" ControlToValidate="txtAgentGuid" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtAgentGuid" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                    <label for="staticEmail" class="form-label">
                                        Host Name : 
                                  
							<%--                                        <asp:RequiredFieldValidator ID="rfvtxtHostName" runat="server" ControlToValidate="txtHostName" ErrorMessage="*" ForeColor="Red" ValidationGroup="Addticket"></asp:RequiredFieldValidator>--%>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtHostName" runat="server" CssClass="form-control form-control-sm "></asp:TextBox>
                                    </div>
                                </div>


                                <asp:Panel ID="pnlChange" runat="server">
                                    <div class="form-group row mb-0 pb-0">
                                        <label for="staticEmail" class="form-label">
                                            Change Type: 
                                               <asp:RequiredFieldValidator ID="rfvddlChangeType" runat="server" InitialValue="0" ControlToValidate="ddlChangeType" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <div class="col-sm-4 pr-5">
                                            <asp:DropDownList ID="ddlChangeType" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                        </div>
                                        <label for="staticEmail" class="form-label">
                                            Reason For Change : 
                                  
                                    <asp:RequiredFieldValidator ID="rfvddlRFC" runat="server" ControlToValidate="ddlRFC" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                        </label>
                                        <div class="col-sm-4 pr-5">
                                            <asp:DropDownList ID="ddlRFC" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row ">
                                        <label for="staticEmail" class="form-label">
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
                                        <label for="staticEmail" class="form-label">
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
                                    <div class="row gy-3 gx-2 mt-1">
                                        <div class="col-md-4 col-6 ">
                                            <label for="staticEmail" class="form-label">
                                                Account ID
                                               <asp:RequiredFieldValidator ID="rfvtxtAccountID" runat="server" ControlToValidate="txtAccountID" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </label>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                ControlToValidate="txtAccountID" ErrorMessage="Not Greater than 12 digits!!" ForeColor="Red" ValidationGroup="Addticket"
                                                ValidationExpression="[0-9]{12}"></asp:RegularExpressionValidator>

                                            <asp:TextBox ID="txtAccountID" runat="server" TextMode="Number" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 col-6 ">
                                            <label for="staticEmail" class="form-label">
                                                User Email
                              
                                    <asp:RequiredFieldValidator ID="rfvtxtUserEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="*" ForeColor="Red" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                            </label>
                                            <asp:TextBox ID="txtUserEmail" runat="server" CssClass="form-control form-control-sm "></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 col-6 ">
                                            <label for="staticEmail" class="form-label">
                                                Not As Submitter Email
						
                                            </label>

                                            <asp:CheckBox ID="checkAnotherEmail" runat="server" CssClass="form-control form-control-sm"></asp:CheckBox>
                                        </div>
                                        <div class="col-md-4 col-6 ">
                                            <label for="staticEmail" class="form-label">
                                                Email Change Reason 
                                  
                                    <asp:RequiredFieldValidator ID="rfvtxtEmailReason" runat="server" ControlToValidate="txtEmailReason" ErrorMessage="*" ForeColor="Red" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                            </label>

                                            <asp:TextBox ID="txtEmailReason" runat="server" CssClass="form-control form-control-sm "></asp:TextBox>
                                        </div>

                                        <div class="col-md-4 col-6 ">
                                            <label for="staticEmail" class="form-label">
                                                Duration From 
                                               <asp:RequiredFieldValidator ID="rfvtxtDurationFrom" runat="server" ControlToValidate="txtDurationFrom" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="input-group input-group-sm">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text py-1"><i class="fadeIn animated bx bx-calendar-star"></i></span>
                                                </div>
                                                <asp:TextBox ID="txtDurationFrom" runat="server" CssClass="form-control form-control-sm" MaxLength="10" autocomplete="off" ClientIDMode="static"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4 col-6 ">
                                            <label for="staticEmail" class="form-label">
                                                Duration To 
                                    <asp:RequiredFieldValidator ID="rfvtxtDurationto" runat="server" ControlToValidate="txtDurationto" ErrorMessage="*" ForeColor="Red" ValidationGroup="Addticket"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="input-group input-group-sm">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text py-1"><i class="fadeIn animated bx bx-calendar-star"></i></span>
                                                </div>
                                                <asp:TextBox ID="txtDurationto" runat="server" CssClass="form-control form-control-sm " MaxLength="10" autocomplete="off" ClientIDMode="static"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </asp:Panel>
                                <div class="row gx-2 gy-3 mt-1">
                                    <div class="col-6">
                                        <div class="row gx-2 gy-3">
                                            <%-- this is area for Category--%>
                                            <div class="col-12">
                                                <label for="staticEmail" class="form-label">
                                                    Severity
                                    <asp:RequiredFieldValidator ID="RfvddlSeverity" runat="server" ControlToValidate="ddlSeverity" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="Addticket" Enabled="false"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:DropDownList ID="ddlSeverity" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                            </div>
                                            <div id="divCategory1" class="col-12" runat="server">
                                                <label for="staticEmail" class="form-label">
                                                    <asp:Label ID="lblCategory1" runat="server" Text="Category1 "></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RfvddlCategory1" runat="server" ControlToValidate="ddlCategory1" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:DropDownList ID="ddlCategory1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory1_SelectedIndexChanged" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                            </div>
                                            <div id="divCategory2" class="col-12" runat="server">
                                                <label for="staticEmail" class="form-label">
                                                    <asp:Label ID="lblCategory2" runat="server" Text="Category2 "></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RfvddlCategory2" runat="server" InitialValue="0" ControlToValidate="ddlCategory2" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:DropDownList ID="ddlCategory2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory2_SelectedIndexChanged" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                            </div>
                                            <div id="divCategory3" class="col-12" runat="server">
                                                <label for="staticEmail" class="form-label">
                                                    <asp:Label ID="lblCategory3" runat="server" Text="Category3 "></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RfvddlCategory3" runat="server" InitialValue="0" ControlToValidate="ddlCategory3" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:DropDownList ID="ddlCategory3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory3_SelectedIndexChanged" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                            </div>
                                            <div id="divCategory4" class="col-12" runat="server">
                                                <label for="staticEmail" class="form-label">
                                                    <asp:Label ID="lblCategory4" runat="server" Text="Category4 "></asp:Label>
                                                    <asp:RequiredFieldValidator ID="rfvddlCategory4" runat="server" InitialValue="0" ControlToValidate="ddlCategory4" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
                                                </label>
                                                s                               
                                <asp:DropDownList ID="ddlCategory4" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory4_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <div id="divCategory5" class="col-12" runat="server">

                                                <label for="staticEmail" class="form-label">
                                                    <asp:Label ID="lblCategory5" runat="server" Text="Category5 "></asp:Label>
                                                </label>


                                                <asp:DropDownList ID="ddlCategory5" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field hidden-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory5_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <div class="col-12" hidden>

                                                <label for="staticEmail" class="form-label">
                                                    Category6 
                                                </label>


                                                <asp:DropDownList ID="ddlCategory6" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field "></asp:DropDownList>
                                            </div>
                                            <div class="col-12">

                                                <label for="staticEmail" class="form-label">
                                                    Attach File 
								 <asp:Label ID="lblinvoiceupload" runat="server" Text=""></asp:Label>
                                                </label>



                                                <asp:FileUpload ID="FileUploadTickDoc" runat="server" CssClass="form-control form-control-sm " ToolTip="Select Only Pdf,Excel File" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <%-- this is area for Custom Field--%>
                                        <asp:Repeater ID="rptOddControl" runat="server" OnItemDataBound="rptOddControl_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="row gx-2 gy-3">
                                                    <div class="col-12">
                                                        <label for="staticEmail" class="form-label">
                                                            <asp:Label ID="lbl" Text='<%# Eval("FieldValue") %>' Visible="false" runat="server"></asp:Label>
                                                            <asp:Label ID="Label1" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txt" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <asp:TextBox ID="txt" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <%--		<asp:PlaceHolder ID="pnlOddTypeCustFlds" runat="server"></asp:PlaceHolder>--%>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <asp:Repeater ID="rptddlOddControl" runat="server" OnItemDataBound="rptddlOddControl_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="row ">
                                                    <div class="col-md-12">
                                                        <label for="staticEmail" class="form-label">
                                                            <asp:Label ID="lblOddlist" Text='<%# Eval("FieldValue") %>' Visible="false" runat="server"></asp:Label>
                                                            <asp:Label ID="Label2" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>

                                                            <asp:RequiredFieldValidator ID="rfvddl" runat="server" ControlToValidate="ddlOdd" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
                                                        </label>


                                                        <asp:DropDownList ID="ddlOdd" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                                    </div>
                                                </div>

                                                <%--		<asp:PlaceHolder ID="pnlOddTypeCustFlds" runat="server"></asp:PlaceHolder>--%>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <asp:Repeater ID="rptEvenControl" runat="server" OnItemDataBound="rptEvenControl_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="row ">
                                                    <div class="col-md-12 ">
                                                        <label for="staticEmail" class="form-label mt-2">
                                                            <asp:Label ID="lbleven" Text='<%# Eval("FieldValue") %>' Visible="false" runat="server"></asp:Label>
                                                            <asp:Label ID="Label3" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>

                                                            <asp:RequiredFieldValidator ID="rfvddl" runat="server" ControlToValidate="txteven" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope" ></asp:RequiredFieldValidator>
                                                        </label>




                                                        <asp:TextBox ID="txteven" runat="server" CssClass="form-control   form-control-sm" Text='<%# Eval("FieldMode") %>'></asp:TextBox>

                                                    </div>

                                                </div>
                                                <%--<asp:PlaceHolder ID="pnlEvenTypeCustFlds" runat="server"></asp:PlaceHolder>--%>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <asp:Repeater ID="rptddlEvenControl" runat="server" OnItemDataBound="rptddlEvenControl_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="row mt-2">
                                                    <div class="col-12 ">
                                                        <label for="staticEmail" class="form-label ">
                                                            <asp:Label ID="lblEvenlist" Text='<%# Eval("FieldValue") %>' Visible="false" runat="server"></asp:Label>
                                                            <asp:Label ID="Label4" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>

                                                            <asp:RequiredFieldValidator ID="rfvddleveb" runat="server" ControlToValidate="ddlEven" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
                                                        </label>

                                                        <asp:DropDownList ID="ddlEven" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                                    </div>

                                                </div>

                                                <%--		<asp:PlaceHolder ID="pnlOddTypeCustFlds" runat="server"></asp:PlaceHolder>--%>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>




                                </div>
                                <div class="row mt-1 gy-3 gx-2">
                                    <div class="col-12">
                                        <label for="staticEmail" class="form-label">
                                            Issue in Detail 
                     <asp:RequiredFieldValidator ID="RfvtxtDescription" runat="server" ControlToValidate="txtDescription" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>

                                        <%--	<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" MaxLength="500" Height="200px"></asp:TextBox>--%>
                                        <asp:TextBox ID="txtDescription" runat="server" Rows="5" Columns="5" CssClass="border" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </asp:Panel>




                    <%-- _____________Grid will Show Impact Details ________________________________--%>
                    <asp:Panel ID="pnlShowImpactDetails" runat="server">
                        <div class="card mb-0">
                            <div class="card-body p-0">
                                <div class="card border bg-transparent shadow-none mb-3">
                                    <div class="card-body">
                                        <p class="fs-5">Impact Details</p>
                                        <div class="row gy-3 gx-2">
                                            <div class="col-md-12">
                                                <label for="staticEmail" class="form-label">
                                                    Impact Description 
                                                    <asp:RequiredFieldValidator ID="rfvtxtImpactDesc" runat="server" ControlToValidate="txtImpactDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddImapct">

                                                    </asp:RequiredFieldValidator>
                                                </label>

                                                <asp:TextBox ID="txtImpactDesc" TextMode="MultiLine" Rows="4" Columns="10" class="form-control form-control-sm" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="col-md-12 text-end">
                                                <asp:Button ID="btnAddImpactDetails" runat="server" Text="Add" CssClass="btn btn-sm btn-grd btn-grd-info" CausesValidation="true" ValidationGroup="AddImapct" OnClick="btnAddImpactDetails_Click"></asp:Button>
                                            </div>
                                        </div>
                                        <div class="row mt-2">
                                            <div class="col-md-12 table-responsive table-container">
                                                <asp:GridView ID="gridAddImpact" runat="server" CssClass="table table-head-fixed text-nowrap table-sm "
                                                    AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderStyle-Width="120px" HeaderText="ImpactDetails" DataField="ImpactDetails" />
                                                    </Columns>
                                                    <%--    <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="5px" />
                                    <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Left" Height="20px" VerticalAlign="NotSet" CssClass="header" />
                                    <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" Height="5px" />
                                    <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="5px" BorderColor="WhiteSmoke" CssClass="header sorting_asc" Font-Size="Small" />
                                    <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" Height="5px" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" BorderStyle="None" Height="5px" BorderColor="#EDEDED" BackColor="#EDEDED" />--%>
                                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                    <%--<AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" Height="5px" BorderStyle="Solid" BorderWidth="1px" />--%>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </asp:Panel>

                    <%--        ________________________ Grid will show RollOut Plan   _____________________________--%>

                    <asp:Panel ID="pnlShowRollOutDetails" runat="server">
                        <div class="card">
                            <div class="card-body p-0">
                                <div class="card border bg-transparent shadow-none mb-3">
                                    <div class="card-body">
                                        <p class="fs-5">Roll Out Details</p>
                                        <div class="row">
                                        </div>
                                        <div class="row gy-3">
                                            <div class="col-md-12">
                                                <label for="staticEmail" class="form-label">
                                                    RollOut Description
                                        <asp:RequiredFieldValidator ID="rfvtxtRollOut" runat="server" ControlToValidate="txtRollOut" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="RollOut">

                                        </asp:RequiredFieldValidator>
                                                </label>

                                                <asp:TextBox ID="txtRollOut" TextMode="MultiLine" Rows="4" Columns="10" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12 text-end ">
                                                <asp:Button ID="btnAddRollOutGrid" runat="server" Text="Add" CssClass="btn btn-sm btn-grd btn-grd-info" CausesValidation="true" ValidationGroup="RollOut" OnClick="btnAddRollOutGrid_Click"></asp:Button>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12  mt-2">
                                                <div class="table-responsive table-container">
                                                    <asp:GridView ID="gridAddRollOut" runat="server" CssClass="table table-head-fixed text-nowrap table-sm "
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="5px">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderStyle-Width="120px" HeaderText="RollOutDetails" DataField="RollOutDetails" />
                                                        </Columns>
                                                        <%-- <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="5px" />
                                            <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Left" Height="20px" VerticalAlign="NotSet" CssClass="header" />
                                            <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" Height="5px" />
                                            <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="5px" BorderColor="WhiteSmoke" CssClass="header sorting_asc" Font-Size="Small" />
                                            <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" Height="5px" />
                                            <EmptyDataRowStyle HorizontalAlign="Center" BorderStyle="None" Height="5px" BorderColor="#EDEDED" BackColor="#EDEDED" />--%>
                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                        <%--<AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" Height="5px" BorderStyle="Solid" BorderWidth="1px" />--%>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </asp:Panel>

                    <%--        ________________________ Grid will show DownTime Plan   _____________________________--%>
                    <asp:Panel ID="pnlDownTime" runat="server" CssClass="mb-1">
                        <div class="card">
                            <div class="card-body p-0">
                                <div class="card border bg-transparent shadow-none mb-3">
                                    <div class="card-body">
                                        <p class="fs-5">Down Time Details</p>

                                        <div class="row">
                                            <div class="col-md-4">
                                                <label class="form-label">
                                                    Summary 
                                                </label>
                                                <asp:TextBox ID="txtDownTimeName" class="form-control form-control-sm" runat="server" ></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <label class="form-label">
                                                    Duration From 
                                                </label>
                                                <div class="col-sm-12">
                                                    <div class="input-group input-group-sm">
                                                        <asp:TextBox ID="txtDownTimeStart" runat="server" CssClass="form-control form-control-sm " MaxLength="10" autocomplete="off" ClientIDMode="static" type="date"></asp:TextBox>
                                                        <span class="input-group-text" id="basic-addon8"><i class="fas fa-calendar"></i></span>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <label class="form-label">
                                                    Duration To
                                                </label>
                                                <div class="col-sm-12">
                                                    <div class="input-group input-group-sm">
                                                        <asp:TextBox ID="txtDownTimeTo" runat="server" CssClass="form-control form-control-sm" MaxLength="10" autocomplete="off" ClientIDMode="static" type="date"></asp:TextBox>
                                                        <span class="input-group-text" id="basic-addon2"><i class="fas fa-calendar"></i></span>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </asp:Panel>

                    <%--________________________ Task Association   _____________________________--%>
                    <asp:Panel ID="pnlTaksAssociation" runat="server">

                        <div class="card">
                            <div class="card-body p-0">

                                <div class="card border bg-transparent shadow-none mb-3">
                                    <div class="card-body">
                                        <p class="fs-5">Task Association</p>

                                        <div class="row gx-2 gy-3">
                                            <div class="col-md-4">
                                                <label class="form-label">
                                                    Task Summary
																				<asp:RequiredFieldValidator ID="rfvtxtTaskSummary" runat="server" ControlToValidate="txtTaskSummary" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Task">
                                                                                </asp:RequiredFieldValidator>

                                                </label>
                                                <asp:TextBox ID="txtTaskSummary" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <label class="form-label">
                                                    Task Status 
                                                </label>

                                                <asp:DropDownList ID="ddlTaskStatus" runat="server" Enabled="false" CssClass="form-select form-select-sm single-select-optgroup-field">
                                                    <asp:ListItem Text="Open" Selected="True" Value="Open"></asp:ListItem>
                                                    <asp:ListItem Text="WIP" Value="WIP"></asp:ListItem>
                                                    <asp:ListItem Text="Hold" Value="Hold"></asp:ListItem>
                                                    <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                            <div class="col-md-4">
                                                <label class="form-label">
                                                    Technician Associaiton 
													<asp:RequiredFieldValidator ID="rfvlstTechAssoc" runat="server" ControlToValidate="lstTechAssoc" ErrorMessage="*" InitialValue="0" Font-Bold="true" ForeColor="Red" ValidationGroup="Task">
                                                    </asp:RequiredFieldValidator>
                                                </label>

                                                <asp:ListBox ID="lstTechAssoc" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" SelectionMode="Multiple"></asp:ListBox>

                                            </div>
                                            <div class="col-md-12 text-end">

                                                <asp:Button ID="btnAddTaskAssociationData" runat="server" Text="Add" CssClass="btn btn-sm btn-grd btn-grd-info" ValidationGroup="Task" OnClick="btnAddTaskAssociationData_Click"></asp:Button>

                                            </div>
                                            <div class="col-md-12 ">
                                                <div class="table-responsive table-container">
                                                    <asp:GridView ID="gvAddTask" runat="server" CssClass="table table-head-fixed text-nowrap table-sm  "
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
                                                        <%-- <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="5px" />
          <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Left" Height="20px" VerticalAlign="NotSet" CssClass="header" />
          <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" Height="5px" />
          <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="5px" BorderColor="WhiteSmoke" CssClass="header sorting_asc" Font-Size="Small" />
          <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" Height="5px" />
          <EmptyDataRowStyle HorizontalAlign="Center" BorderStyle="None" Height="5px" BorderColor="#EDEDED" BackColor="#EDEDED" />--%>
                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                        <%--<AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" Height="5px" BorderStyle="Solid" BorderWidth="1px" />--%>
                                                    </asp:GridView>
                                                </div>

                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </asp:Panel>
                    <div class="row">
                        <div class="col-md-12 text-end">
                            <asp:Button ID="btnPrev" runat="server" Text="Prev" CausesValidation="false" OnClick="btnPrev_Click" CssClass="btn btn-sm cancelbtn " />


                            <asp:Button ID="btnNext" runat="server" Text="Next" ValidationGroup="Addticket" CausesValidation="false" OnClick="btnNext_Click" CssClass="btn btn-sm savebtn " />

                            <asp:Button ID="btnSubmit" runat="server" AutoPostBack="true" Text="Submit" ValidationGroup="Addticket" OnClick="btnSubmit_Click" CssClass="btn btn-sm btn-grd btn-grd-info " />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" CssClass="btn btn-sm  btn-grd btn-grd-danger " />
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnCategoryID" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ddlRequestType" />
            <asp:PostBackTrigger ControlID="ddlCategory1" />
            <asp:PostBackTrigger ControlID="ddlCategory2" />
            <asp:PostBackTrigger ControlID="ddlCategory3" />
            <asp:PostBackTrigger ControlID="ddlCategory4" />
            <asp:PostBackTrigger ControlID="ddlCategory5" />
        </Triggers>
    </asp:UpdatePanel>

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
    <script src="assets/plugins/summernote/summernote-bs4.js"></script>
    <script>
        $(document).ready(function () {
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
            }, 5000);
        }
        window.onload = clearLabelAfter5Seconds;
    </script>
</asp:Content>

