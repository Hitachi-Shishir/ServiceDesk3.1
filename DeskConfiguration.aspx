<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DeskConfiguration.aspx.cs" Inherits="DeskConfiguration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .step-trigger {
            background-color: #f8f9fa; /* Default button background */
            border: none;
            display: flex;
            align-items: center;
            gap: 10px;
            width: auto;
            padding: 10px;
            text-align: left;
        }

            .step-trigger:enabled {
                background-color: #ff5a9e; /* Active state background color */
                color: white;
            }

        .bs-stepper-circle {
            background-color: #e9ecef;
            width: 30px;
            height: 30px;
            display: flex;
            align-items: center;
            justify-content: center;
            border-radius: 50%;
        }

        .step-trigger:enabled .bs-stepper-circle {
            background-color: white; /* Active state circle color */
        }

        .steper-title {
            font-size: 1.1rem;
            margin-bottom: 0;
        }

        .steper-sub-title {
            font-size: 0.85rem;
            margin-bottom: 0;
        }

        .bs-stepper-line {
            width: 100px; /* Adjust width as per layout */
            height: 2px;
            background-color: #e9ecef;
            margin-left: 15px;
            margin-right: 15px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
    <div id="stepper1" class="bs-stepper">
        <div class="card">
            <%--Stepper Start--%>
            <div class="card-header">
                <div class="row">
                    <div class="d-lg-flex flex-lg-row align-items-lg-center justify-content-lg-between" role="tablist">
                        <div class="col-md-3">


                            <!-- Step 1 -->
                            <asp:LinkButton ID="stepper1trigger1" runat="server" CssClass='<%# CurrentStep == 1 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' OnClick="StepButton_Click1">
                         <div class="bs-stepper-circle">1</div>
                         <div class="">
                             <h5 class="mb-0 steper-title">Organisation Info</h5>
                             <p class="mb-0 steper-sub-title">Enter Org Details</p>
                         </div>
                        
                            </asp:LinkButton>
                        </div>

                        <div class="col-md-3">
                            <div class="bs-stepper-line"></div>

                            <!-- Step 2 -->
                            <asp:LinkButton ID="stepper1trigger2" runat="server" CssClass='<%# CurrentStep == 2 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 2 %>' OnClick="StepButton_Click2">
                        <div class="bs-stepper-circle">2</div>
                        <div class="">
                            <h5 class="mb-0 steper-title">Add Request Type</h5>
                            <p class="mb-0 steper-sub-title">Setup Request Details</p>
                        </div>
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-3">
                            <div class="bs-stepper-line"></div>

                            <!-- Step 3 -->
                            <asp:LinkButton ID="stepper1trigger3" runat="server" CssClass='<%# CurrentStep == 3 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 3 %>' OnClick="StepButton_Click3">
                         <div class="bs-stepper-circle">3</div>
                         <div class="">
                             <h5 class="mb-0 steper-title">Add Stage</h5>
                             <p class="mb-0 steper-sub-title">Stage Details</p>
                         </div>
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-3">
                            <div class="bs-stepper-line"></div>

                            <!-- Step 4 -->
                            <asp:LinkButton ID="stepper1trigger4" runat="server" CssClass='<%# CurrentStep == 4 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 4 %>' OnClick="StepButton_Click4">
                            <div class="bs-stepper-circle">4</div>
                            <div class="">
                                <h5 class="mb-0 steper-title">Add Status</h5>
                                <p class="mb-0 steper-sub-title">Status Details</p>
                            </div>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <!-- Step 5 -->
                        <asp:LinkButton ID="stepper1trigger5" runat="server" CssClass='<%# CurrentStep == 5 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 5 %>' OnClick="StepButton_Click5">
                        <div class="bs-stepper-circle">5</div>
                        <div class="">
                            <h5 class="mb-0 steper-title">Add Severity</h5>
                            <p class="mb-0 steper-sub-title">Severity Details</p>
                        </div>
                        </asp:LinkButton>
                    </div>
                    <div class="col-md-3">
                        <!-- Step 5 -->
                        <asp:LinkButton ID="stepper1trigger6" runat="server" CssClass='<%# CurrentStep == 6 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 6 %>' OnClick="StepButton_Click6">
                        <div class="bs-stepper-circle">6</div>
                        <div class="">
                            <h5 class="mb-0 steper-title">Add Severity</h5>
                            <p class="mb-0 steper-sub-title">Severity Details</p>
                        </div>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <%--Stepper End--%>

            <%--ADD Organisation Start--%>
            <asp:Panel ID="pnlShowOrg" runat="server">
                <asp:UpdatePanel ID="updatepanel1" runat="server">
                    <ContentTemplate>
                        <div class="card">
                            <div class="card-body">
                                <h5 class="mb-1">Organisation</h5>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Organization Name : <span title="*"></span>
                                        <asp:RequiredFieldValidator ID="rfvtxtprioritye" runat="server" ControlToValidate="txtOrgName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>

                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtOrgName" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Organization Description : <span title="*"></span>
                                        <asp:RequiredFieldValidator ID="rfvPriority" runat="server" ControlToValidate="txtOrgDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-10 pr-5">
                                        <asp:TextBox ID="txtOrgDesc" runat="server" TextMode="MultiLine" Rows="5" Columns="5" CssClass="form-control  form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Contact Person Name : <span title="*"></span>
                                        <asp:RequiredFieldValidator ID="rfvtxtCntnctPrnsName" runat="server" ControlToValidate="txtCntnctPrnsName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtCntnctPrnsName" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                    </div>
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Contact Person Mobile : <span title="*"></span>
                                        <asp:RequiredFieldValidator ID="rfvtxtCntctPrnsMob" runat="server" ControlToValidate="txtCntctPrnsMob" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtCntctPrnsMob" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row mt-3">

                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Contact Person Email : <span title="*"></span>
                                        <asp:RequiredFieldValidator ID="rfvtxtCntctPrsnEmail" runat="server" ControlToValidate="txtCntctPrsnEmail" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>

                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtCntctPrsnEmail" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>

                                    </div>
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Contact PersonII Name : <span title="*"></span>

                                    </label>

                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtCntctPrsnNameII" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="form-group row mt-3">

                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Contact PersonII Mobile : <span title="*"></span>

                                    </label>

                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtCntctPrsnMobII" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>

                                    </div>
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Contact PersonII Email : <span title="*"></span>
                                    </label>

                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtCntctPrnsEmailII" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-3  offset-5">
                                        <asp:Button ID="btnInsertOrg" runat="server" Text="Save" class="btn btn-sm savebtn" OnClick="btnInsertOrg_Click" ValidationGroup="Priority" />
                                        <asp:Button ID="btnUpdateOrg" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateOrg_Click" ValidationGroup="Priority" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel_Click" CausesValidation="false" />
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="d-flex align-items-center gap-3">
                                        <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkNextAddReq" runat="server" OnClick="lnkNextAddReq_Click">Next</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 graphs">
                                        <div class="xs">
                                            <div class="well1 white">
                                                <div class="card card-default">
                                                    <div class="card-body">
                                                        <div class="row ">
                                                            <div class="col-md-4">
                                                                <asp:Label ID="lblsofname" runat="server" Text="Organization Details" Font-Size="Larger" ForeColor="Black"></asp:Label>
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
                                                        <div class="table-responsive table-container">
                                                            <asp:GridView GridLines="None" ID="gvOrg" runat="server" DataKeyNames="Org_ID" AutoGenerateColumns="false" CssClass="data-table table table-striped table-bordered table-sm"
                                                                Width="100%" OnRowCommand="gvOrg_RowCommand" OnRowDataBound="gvOrg_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                        <ItemTemplate>
                                                                            <%#Container.DataItemIndex+1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="OrgName" HeaderText="Organization Name" NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="OrgDesc" HeaderText="Organization Desc" NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="CntctPrsnName" HeaderText="Cont Person Name" NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="CntctPrsnMob" HeaderText="Cont Person Mob " NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="CntctPrsnEmail" HeaderText="Cont Person Email " NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="CntctPrsnNameII" HeaderText="Cont Person Name II" NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="CntctPrsnMobII" HeaderText="Cont Person Mob II" NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="CntctPrsnEmailII" HeaderText="Cont Person Email II " NullDisplayText="NA" />
                                                                    <asp:ButtonField ButtonType="Image" CommandName="SelectState" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                                    <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal " id="basicModal" <%-- tabindex="-1"--%> role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-centered">
                                <div class="modal-content">
                                    <div class="card-header">
                                        New Request Type
                                        <button type="button" class="close" onclick="javascript:window.location.reload()" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    </div>
                                    <div class="card-body">
                                        <asp:Label ID="lblsuccess" runat="server" Text=""></asp:Label>
                                        <asp:PlaceHolder ID="pnlShowRqstType" runat="server"></asp:PlaceHolder>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="ImgBtnExport" />
                        <asp:PostBackTrigger ControlID="gvOrg" />
                        <asp:PostBackTrigger ControlID="lnkNextAddReq" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
            <%--Add Organisation END--%>

            <%--Add Request Type Start--%>
            <asp:Panel ID="pnlReqType" runat="server" Visible="false">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Organization: <span title="*"></span>

                                                <asp:RequiredFieldValidator ID="rfvddlOrg" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-4 pr-5">

                                                <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field">
                                                </asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Request Type : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvReqType" runat="server" ControlToValidate="txtRequestType" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtRequestType" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Request Description : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvRequestDesc" runat="server" ControlToValidate="txtReqDescription" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-10 pr-5">
                                                <asp:TextBox ID="txtReqDescription" runat="server" TextMode="MultiLine" Rows="3" Columns="3" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="col-md-3 offset-3 ">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSaveReqType_Click" class="btn btn-sm savebtn" ValidationGroup="ReqType"></asp:Button>
                                                <asp:Button ID="btnUpdateReqType" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateReqType_Click" ValidationGroup="ReqType" />
                                                <asp:Button ID="btnCancel1" runat="server" Text="Cancel" CssClass="btn btn-sm cancelbtn" OnClick="btnCancel1_Click" />
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="d-flex align-items-center gap-3">
                                                <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkPrevOrg" runat="server" OnClick="lnkPrevOrg_Click">Previous</asp:LinkButton>
                                                <asp:LinkButton class="btn btn-grd-primary px-4" ID="lnkNextStage" runat="server" OnClick="lnkNextStage_Click">Next</asp:LinkButton>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-8 graphs">
                                                <div class="xs">
                                                    <div class="well1 white">
                                                        <div class="card card-default">
                                                            <div class="card-body">
                                                                <div class="row ">
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="Label2" runat="server" Text="Request Type Details" Font-Size="Larger" ForeColor="Black"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label4" runat="server"></asp:Label>
                                                                        <asp:Label ID="Label5" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-2 ">
                                                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                                            <label class="mr-2 ml-1 mb-0">Export</label>
                                                                            <asp:ImageButton ID="ImgBtnExportReq" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExportReq_Click" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <asp:GridView GridLines="None" ID="gvReqType" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-bordered"
                                                                    Width="100%" OnRowCommand="gvReqType_RowCommand" OnRowDataBound="gvReqType_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                            <ItemTemplate>
                                                                                <%#Container.DataItemIndex+1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="ReqTypeRef" HeaderText="Request Type" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="ReqTypeDef" HeaderText="ReqType Definition" NullDisplayText="NA" />
                                                                        <asp:TemplateField HeaderText=" Organization">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOrgFk" runat="server" Text='<%# Eval("Org_ID") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblOrgName" runat="server" Text='<%# Eval("OrgName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="SelectState" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                                        <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnSave" />
                        <asp:PostBackTrigger ControlID="gvReqType" />
                        <asp:PostBackTrigger ControlID="ImgBtnExportReq" />
                        <asp:PostBackTrigger ControlID="lnkPrevOrg" />
                        <asp:PostBackTrigger ControlID="lnkNextStage" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>

            <%--Add Request Type End--%>

            <%--Add Stage Start--%>
            <asp:Panel ID="pnlAddStage" runat="server" Visible="false">
                <asp:UpdatePanel ID="updatepanel3" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Organization: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlOrg2" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg2_SelectedIndexChanged">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Request Type:
                                                <asp:RequiredFieldValidator ID="rfvddlRequestType" runat="server" ControlToValidate="ddlRequestType" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlRequestType" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Stage Name : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtStageName" runat="server" ControlToValidate="txtStageName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Stage"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtStageName" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>

                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Stage Description : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtStageDesc" runat="server" ControlToValidate="txtStageDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Stage"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtStageDesc" runat="server" TextMode="MultiLine" Rows="1" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="col-md-3 offset-5">
                                                <asp:Button ID="btnInsertStage" runat="server" Text="Save" class="btn btn-sm savebtn" OnClick="btnInsertStage_Click" ValidationGroup="Stage" />
                                                <asp:Button ID="btnUpdateStage" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateStage_Click" ValidationGroup="Severity" />
                                                <asp:Button ID="btnCancel2" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel2_Click" CausesValidation="false" />
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="d-flex align-items-center gap-3">
                                                <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkbtnPrevAddReq" runat="server" OnClick="lnkbtnPrevAddReq_Click">Previous</asp:LinkButton>
                                                <asp:LinkButton class="btn btn-grd-primary px-4" ID="lnkbtnNextStatus" runat="server" OnClick="lnkbtnNextStatus_Click">Next</asp:LinkButton>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10 graphs">
                                                <div class="xs">
                                                    <div class="well1 white">
                                                        <div class="card card-default">

                                                            <div class="card-body">
                                                                <div class="row ">
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="Label6" runat="server" Text="Stage Details" Font-Size="Larger" ForeColor="Black"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label7" runat="server"></asp:Label>
                                                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-2 ">
                                                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                                            <label class="mr-2 ml-1 mb-0">Export</label>
                                                                            <asp:ImageButton ID="ImgBtnExport2" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport2_Click" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <asp:GridView GridLines="None" ID="gvStage" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-bordered"
                                                                    Width="100%" OnRowCommand="gvStage_RowCommand" OnRowDataBound="gvStage_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                            <ItemTemplate>
                                                                                <%#Container.DataItemIndex+1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="DeskRef" HeaderText="Request Type" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="StageCodeRef" HeaderText="Stage Name" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="StageDesc" HeaderText="Stage Description" NullDisplayText="NA" />
                                                                        <asp:TemplateField HeaderText=" Organization">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOrgFk" runat="server" Text='<%# Eval("Org_ID") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblOrgName" runat="server" Text='<%# Eval("OrgName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="SelectStage" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                                        <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="ddlRequestType" />
                        <asp:PostBackTrigger ControlID="btnInsertStage" />
                        <asp:PostBackTrigger ControlID="ImgBtnExport2" />
                        <asp:PostBackTrigger ControlID="gvStage" />
                        <asp:PostBackTrigger ControlID="btnUpdateStage" />
                        <asp:PostBackTrigger ControlID="ddlOrg2" />
                        <asp:PostBackTrigger ControlID="lnkbtnPrevAddReq" />
                        <asp:PostBackTrigger ControlID="lnkbtnNextStatus" />
                    </Triggers>

                </asp:UpdatePanel>
            </asp:Panel>
            <%--Add Stage End--%>

            <%--Add Status Start--%>
            <asp:Panel ID="pnlStatus" runat="server" Visible="false">
                <asp:UpdatePanel ID="updatepanel4" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Organization: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-4 pr-5">

                                                <asp:DropDownList ID="ddlOrg3" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg3_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Request Type:
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlRequestTypeStatus" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-4 pr-5">

                                                <asp:DropDownList ID="ddlRequestTypeStatus" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestTypeStatus_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Stage:
									<asp:RequiredFieldValidator ID="rfvddlStage" runat="server" ControlToValidate="ddlStage" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-4 pr-5">

                                                <asp:DropDownList ID="ddlStage" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field">
                                                </asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Status Name : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtStatusName" runat="server" ControlToValidate="txtStatusName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Status"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtStatusName" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>

                                            </div>


                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Status Description : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtStatusDesc" runat="server" ControlToValidate="txtStatusDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Status"></asp:RequiredFieldValidator>
                                            </label>



                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtStatusDesc" runat="server" TextMode="MultiLine" Rows="1" CssClass="form-control  form-control-sm"></asp:TextBox>

                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Choose Status Color  : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtColorForStatus" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Status"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtColorForStatus" TextMode="Color" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>

                                            </div>
                                        </div>



                                        <div class="form-row">
                                            <div class="col-md-3 offset-5">
                                                <asp:Button ID="btnInsertStatus" runat="server" Text="Save" class="btn btn-sm savebtn" OnClick="btnInsertStatus_Click" ValidationGroup="Status" />
                                                <asp:Button ID="btnUpdateStatus" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateStatus_Click" ValidationGroup="Severity" />
                                                <asp:Button ID="Button1" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel3_Click" CausesValidation="false" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12 graphs">
                                                <div class="xs">
                                                    <div class="well1 white">
                                                        <div class="card card-default">

                                                            <div class="card-body">
                                                                <div class="row ">
                                                                    <div class="col-md-4">

                                                                        <asp:Label ID="Label9" runat="server" Text="Status Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label10" runat="server"></asp:Label>
                                                                        <asp:Label ID="Label11" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-2 ">
                                                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                                            <label class="mr-2 ml-1 mb-0">Export</label>
                                                                            <asp:ImageButton ID="ImgBtnExport3" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport3_Click" />
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                                <div class="col-12">
                                                                    <div class="d-flex align-items-center gap-3">
                                                                        <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkPrevStage" runat="server" OnClick="lnkPrevStage_Click">Previous</asp:LinkButton>
                                                                        <asp:LinkButton class="btn btn-grd-primary px-4" ID="lnkNextSeverity" runat="server" OnClick="lnkNextSeverity_Click">Next</asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <asp:GridView GridLines="None" ID="gvStatus" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-bordered"
                                                                    Width="100%" OnRowCommand="gvStatus_RowCommand" OnRowDataBound="gvStatus_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                            <ItemTemplate>
                                                                                <%#Container.DataItemIndex+1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>


                                                                        <asp:BoundField DataField="DeskRef" HeaderText="Request Type" NullDisplayText="NA" />
                                                                        <asp:TemplateField HeaderText="Stage">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStageFk" runat="server" Text='<%# Eval("sd_stageFK") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblStageName" runat="server" Text='<%# Eval("StageCodeRef") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="StatusCodeRef" HeaderText="Status Name" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="StatusDesc" HeaderText="Status Description" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="StatusColorCode" HeaderText=" Color Code" ControlStyle-CssClass="hidden" NullDisplayText="NA" />
                                                                        <asp:TemplateField HeaderText="Status Color" ItemStyle-Width="150" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStatusCode" runat="server" Font-Size="XX-Small" CssClass=" badge badge-notifications" BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("StatusColorCode").ToString())%>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("StatusColorCode").ToString())%>' Text='<%# Eval("StatusColorCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText=" Organization">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOrgFk" runat="server" Text='<%# Eval("Org_ID") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblOrgName" runat="server" Text='<%# Eval("OrgName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="SelectStatus" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                                        <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />
                                                                    </Columns>

                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>

                    <Triggers>
                        <asp:PostBackTrigger ControlID="ddlRequestType" />
                        <asp:PostBackTrigger ControlID="btnInsertStatus" />
                        <asp:PostBackTrigger ControlID="ImgBtnExport3" />
                        <asp:PostBackTrigger ControlID="gvStatus" />
                        <asp:PostBackTrigger ControlID="btnUpdateStatus" />
                        <asp:PostBackTrigger ControlID="ddlOrg3" />
                        <asp:PostBackTrigger ControlID="lnkPrevStage" />
                        <asp:PostBackTrigger ControlID="lnkNextSeverity" />
                    </Triggers>

                </asp:UpdatePanel>
            </asp:Panel>
            <%--Add Status End--%>

            <%--Add Severity Start--%>
            <asp:Panel runat="server" ID="pnlAddSeverity" Visible="false">
                <asp:UpdatePanel ID="updatepanel5" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Organization: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlOrg4" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg4_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Request Type: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlRequestType" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-4 pr-5">

                                                <asp:DropDownList ID="ddlRequestTypeSeverity" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestTypeSeverity_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Severity Name : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtSeverityName" runat="server" ControlToValidate="txtSeverityName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtSeverityName" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>

                                            </div>


                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Response Time(in Min): <span title="*"></span>

                                                <asp:RequiredFieldValidator ID="rfvtxtResponseTime" runat="server" ControlToValidate="txtResponseTime" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-4 pr-5">

                                                <asp:TextBox ID="txtResponseTime" runat="server" CssClass="form-control  form-control-sm" TextMode="Number"></asp:TextBox>

                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Resolution Time(in Min) : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtResolutionTime" runat="server" ControlToValidate="txtResolutionTime" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtResolutionTime" runat="server" CssClass="form-control  form-control-sm" TextMode="Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Severity Description : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvSeverityDesc" runat="server" ControlToValidate="txtSeverityDescription" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-10 pr-5">
                                                <asp:TextBox ID="txtSeverityDescription" runat="server" TextMode="MultiLine" Rows="3" Columns="3" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-row">
                                            <div class="col-md-3 offset-5">
                                                <asp:Button ID="btnInsertSeverity" runat="server" Text="Save" class="btn btn-sm savebtn" OnClick="btnInsertSeverity_Click" ValidationGroup="Severity" />
                                                <asp:Button ID="btnUpdateSeverity" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateSeverity_Click" ValidationGroup="Severity" />
                                                <asp:Button ID="btnCancel5" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel5_Click" CausesValidation="false" />
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="d-flex align-items-center gap-3">
                                                <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkPrevStatus" runat="server" OnClick="lnkPrevStatus_Click">Previous</asp:LinkButton>
                                                <asp:LinkButton class="btn btn-grd-primary px-4" ID="lnkNextPriority" runat="server" OnClick="lnkNextPriority_Click">Next</asp:LinkButton>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10 graphs">
                                                <div class="xs">
                                                    <div class="well1 white">
                                                        <div class="card card-default">

                                                            <div class="card-body">
                                                                <div class="row ">
                                                                    <div class="col-md-4">

                                                                        <asp:Label ID="Label12" runat="server" Text="Severity Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label13" runat="server"></asp:Label>
                                                                        <asp:Label ID="Label14" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-2 ">
                                                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                                            <label class="mr-3 ml-1 mb-0">Export</label>
                                                                            <asp:ImageButton ID="ImgBtnExport4" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport4_Click" />
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                                <asp:GridView GridLines="None" ID="gvSeverity" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-bordered"
                                                                    Width="100%" OnRowCommand="gvSeverity_RowCommand" OnRowDataBound="gvSeverity_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                            <ItemTemplate>
                                                                                <%#Container.DataItemIndex+1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>



                                                                        <asp:BoundField DataField="DeskRef" HeaderText="Request Type" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="Serveritycoderef" HeaderText="Severity Name" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="SeverityDesc" HeaderText="Severity Description" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="ResponseTime" HeaderText="ResponseTime(Min)" NullDisplayText="0" />
                                                                        <asp:BoundField DataField="ResolutionTime" HeaderText="ResolutionTime(Min)" NullDisplayText="0" />
                                                                        <asp:TemplateField HeaderText=" Organization">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOrgFk" runat="server" Text='<%# Eval("Org_ID") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblOrgName" runat="server" Text='<%# Eval("OrgName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="SelectSeverity" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                                        <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
 
                    </ContentTemplate>

                    <Triggers>
                        <asp:PostBackTrigger ControlID="ImgBtnExport" />
                        <asp:PostBackTrigger ControlID="ddlRequestType" />
                        <asp:PostBackTrigger ControlID="btnInsertSeverity" />
                        <asp:PostBackTrigger ControlID="gvSeverity" />
                        <asp:PostBackTrigger ControlID="ddlOrg" />
                        <asp:PostBackTrigger ControlID="btnUpdateSeverity" />
                        <asp:PostBackTrigger ControlID="lnkPrevStatus" />
                        <asp:PostBackTrigger ControlID="lnkNextPriority" />
                    </Triggers>

                </asp:UpdatePanel>
            </asp:Panel>
            <%--Add Severity End--%>


        </div>
    </div>

</asp:Content>

