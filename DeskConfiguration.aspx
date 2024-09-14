<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DeskConfiguration.aspx.cs" Inherits="DeskConfiguration" MaintainScrollPositionOnPostback="false" %>

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
            <asp:UpdatePanel ID="updtcardbtn" runat="server">
                <ContentTemplate>
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
                                <!-- Step 6 -->
                                <asp:LinkButton ID="stepper1trigger6" runat="server" CssClass='<%# CurrentStep == 6 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 6 %>' OnClick="StepButton_Click6">
                        <div class="bs-stepper-circle">6</div>
                        <div class="">
                            <h5 class="mb-0 steper-title">Add Priority</h5>
                            <p class="mb-0 steper-sub-title">Priority Details</p>
                        </div>
                                </asp:LinkButton>
                            </div>
                            <div class="col-md-3">
                                <!-- Step 7 -->
                                <asp:LinkButton ID="stepper1trigger7" runat="server" CssClass='<%# CurrentStep == 7 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 7 %>' OnClick="StepButton_Click7">
                        <div class="bs-stepper-circle">7</div>
                        <div class="">
                            <h5 class="mb-0 steper-title">Add Category</h5>
                            <p class="mb-0 steper-sub-title">Category Details</p>
                        </div>
                                </asp:LinkButton>
                            </div>
                            <div class="col-md-3">
                                <!-- Step 8 -->
                                <asp:LinkButton ID="stepper1trigger8" runat="server" CssClass='<%# CurrentStep == 8 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 8 %>' OnClick="StepButton_Click8">
                                <div class="bs-stepper-circle">8</div>
                                <div class="">
                                    <h5 class="mb-0 steper-title">Email Config</h5>
                                    <p class="mb-0 steper-sub-title">Add Email Config</p>
                                </div>
                                </asp:LinkButton>
                            </div>
                            <div class="col-md-3">
                                <!-- Step 9 -->
                                <asp:LinkButton ID="stepper1trigger9" runat="server" CssClass='<%# CurrentStep == 9 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 9 %>' OnClick="StepButton_Click9">
                        <div class="bs-stepper-circle">9</div>
                        <div class="">
                            <h5 class="mb-0 steper-title">Resolution</h5>
                            <p class="mb-0 steper-sub-title">Add Resolution</p>
                        </div>
                                </asp:LinkButton>
                            </div>
                            <div class="col-md-3">
                                <!-- Step 10 -->
                                <asp:LinkButton ID="stepper1trigger10" runat="server" CssClass='<%# CurrentStep == 10 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 10 %>' OnClick="StepButton_Click10">
                                <div class="bs-stepper-circle">10</div>
                                <div class="">
                                    <h5 class="mb-0 steper-title">Add SLA</h5>
                                    <p class="mb-0 steper-sub-title">Add SLA</p>
                                </div>
                                </asp:LinkButton>
                            </div>
                            <div class="col-md-3">
                                <!-- Step 11 -->
                                <asp:LinkButton ID="stepper1trigger11" runat="server" CssClass='<%# CurrentStep == 11 ? "btn step-trigger btn-grd-primary px-4" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 11 %>' OnClick="StepButton_Click11">
                                <div class="bs-stepper-circle">11</div>
                                <div class="">
                                    <h5 class="mb-0 steper-title">Add SLA</h5>
                                    <p class="mb-0 steper-sub-title">Add SLA</p>
                                </div>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
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

            <%--Add Priority Start--%>
            <asp:Panel ID="pnlAddPriority" runat="server" Visible="false">
                <asp:UpdatePanel ID="updatepanel6" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Organization: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlOrg5" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg5_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Request Type: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlRequestType" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlRequestTypePriority" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestTypePriority_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Priority Name : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtpriority" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtpriority" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Priority Description : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPriorityDescription" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-10 pr-5">
                                                <asp:TextBox ID="txtPriorityDescription" runat="server" TextMode="MultiLine" Rows="5" Columns="5" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="col-md-3  offset-5">
                                                <asp:Button ID="btnInsertPriority" runat="server" Text="Save" class="btn btn-sm savebtn" OnClick="btnInsertPriority_Click" ValidationGroup="Priority" />
                                                <asp:Button ID="btnUpdatePriority" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdatePriority_Click" ValidationGroup="Priority" />
                                                <asp:Button ID="btnCancel6" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel6_Click" CausesValidation="false" />
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="d-flex align-items-center gap-3">
                                                <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkPreviousSeverity" runat="server" OnClick="lnkPreviousSeverity_Click">Previous</asp:LinkButton>
                                                <asp:LinkButton class="btn btn-grd-primary px-4" ID="lnkNextCategory" runat="server" OnClick="lnkNextCategory_Click">Next</asp:LinkButton>
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
                                                                        <asp:Label ID="Label15" runat="server" Text="Priority Details" Font-Size="Larger" ForeColor="Black"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label16" runat="server"></asp:Label>
                                                                        <asp:Label ID="Label17" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-2 ">
                                                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                                            <label class="mr-2 ml-1 mb-0">Export</label>
                                                                            <asp:LinkButton ID="ImgBtnExport7" runat="server" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport7_Click">Import</asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <asp:GridView GridLines="None" ID="gvPriority" runat="server" DataKeyNames="PriorityRef" AutoGenerateColumns="false" CssClass="table table-bordered"
                                                                    Width="100%" OnRowCommand="gvPriority_RowCommand" OnRowDataBound="gvPriority_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                            <ItemTemplate>
                                                                                <%#Container.DataItemIndex+1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="DeskRef" HeaderText="Request Type" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="PriorityCodeRef" HeaderText="Priority Name" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="PriorityDesc" HeaderText="Priority Description" NullDisplayText="NA" />
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
                        <asp:PostBackTrigger ControlID="ImgBtnExport7" />
                        <asp:PostBackTrigger ControlID="ddlRequestType" />
                        <asp:PostBackTrigger ControlID="btnInsertPriority" />
                        <asp:PostBackTrigger ControlID="gvPriority" />
                        <asp:PostBackTrigger ControlID="ddlOrg" />
                        <asp:PostBackTrigger ControlID="btnUpdatePriority" />
                        <asp:PostBackTrigger ControlID="lnkPreviousSeverity" />
                        <asp:PostBackTrigger ControlID="lnkNextCategory" />

                    </Triggers>

                </asp:UpdatePanel>
            </asp:Panel>
            <%--Add Priority End--%>

            <%--Add Category Start--%>
            <asp:Panel ID="pnlCategory" runat="server" Visible="false">
                <asp:UpdatePanel ID="updatepanel7" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12  ">
                                <div class="card card-default">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <label class="labelcolorl1">Category</label>
                                            </div>
                                        </div>
                                        <div class="row mt-3">
                                            <div class="col-md-4 ">
                                                <label class="control-label ">
                                                    Organization:

                                                </label>
                                                <asp:DropDownList ID="ddlOrg6" runat="server" CssClass="form-control form-control-sm" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="ddlOrg6_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-4">
                                                <label class="control-label ">
                                                    Request Type:
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlRequestType" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:DropDownList ID="ddlRequestTypeCategory" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestTypeCategory_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <label class=" col-form-label">
                                                    Category: <span title="*"></span>
                                                    <asp:ImageButton ID="imgbtnAddParentCategory" runat="server" ImageUrl="~/Images/plus.png" ToolTip="Add Category" OnClick="imgbtnAddParentCategory_Click" />
                                                    <asp:ImageButton ID="imgbtnSaveParentCategory" runat="server" ImageUrl="~/Images/save.png" ToolTip="Save Category" OnClick="imgbtnSaveParentCategory_Click" ValidationGroup="SaveCatI" Enabled="false" />
                                                    <asp:ImageButton ID="imgbtnUpdateParentCategory" runat="server" ImageUrl="~/Images/update.png" ToolTip="Update Category" OnClick="imgbtnUpdateParentCategory_Click" ValidationGroup="SaveCatI" Visible="false" />
                                                    <asp:ImageButton ID="imgbtnEditParentCategory" runat="server" ImageUrl="~/Images/edit23.png" Width="16" Height="16" ToolTip="Edit Category" OnClick="imgbtnEditParentCategory_Click" />
                                                    <asp:ImageButton ID="imgbtnCancelParent" runat="server" Enabled="false" ImageUrl="~/Images/reset1.png" Width="16" Height="16" ToolTip="Add Category" OnClick="imgbtnCancelParent_Click" />
                                                    <asp:RequiredFieldValidator ID="rfvtxtParentCategory" runat="server" ControlToValidate="txtParentCategory" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SaveCatI"></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="rfvddlParentCategory" runat="server" ControlToValidate="ddlParentCategory" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddCatII"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:TextBox ID="txtParentCategory" runat="server" CssClass="form-control  form-control-sm" ToolTip="Add Category" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="ddlParentCategory" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlParentCategory_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row mt-1">
                                            <div class="col-md-4">
                                                <label class=" col-form-label">
                                                    Category II: <span title="*"></span>
                                                    <asp:ImageButton ID="imgbtnCatII" runat="server" ImageUrl="~/Images/plus.png" OnClick="imgbtnCatII_Click" ValidationGroup="AddCatII" />
                                                    <asp:ImageButton ID="imgbtnSaveCatII" runat="server" ImageUrl="~/Images/save.png" ToolTip="Save Category" OnClick="imgbtnSaveCatII_Click" ValidationGroup="SaveCatII" Enabled="false" />
                                                    <asp:ImageButton ID="imtbtnUpdateCatII" runat="server" ImageUrl="~/Images/update.png" ToolTip="Update Category" OnClick="imtbtnUpdateCatII_Click" ValidationGroup="SaveCatII" Visible="false" />
                                                    <asp:ImageButton ID="imgbtnEditCatII" runat="server" ImageUrl="~/Images/edit23.png" Width="16" Height="16" ToolTip="Edit Category" OnClick="imgbtnEditCatII_Click" />
                                                    <asp:ImageButton ID="imgbtnCancelCatII" runat="server" ImageUrl="~/Images/reset1.png" Width="16" Height="16" ToolTip="Add Category" OnClick="imgbtnCancelCatII_Click" />
                                                    <asp:RequiredFieldValidator ID="rfvtxtCatII" runat="server" ControlToValidate="txtCatII" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SaveCatII"></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="rfvddlCatII" runat="server" ControlToValidate="ddlCatII" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddCatIII"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:TextBox ID="txtCatII" runat="server" CssClass="form-control  form-control-sm" ValidationGroup="SaveCatII" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="ddlCatII" runat="server" CssClass="form-control form-control-sm chzn-select" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlCatII_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row mt-1">
                                            <div class="col-md-4">
                                                <label class=" col-form-label">
                                                    Category III: <span title="*"></span>
                                                    <asp:ImageButton ID="imgAddCatIII" runat="server" ImageUrl="~/Images/plus.png" OnClick="imgAddCatIII_Click" ValidationGroup="AddCatIII" />
                                                    <asp:ImageButton ID="imgSaveCatIII" runat="server" ImageUrl="~/Images/save.png" OnClick="imgSaveCatIII_Click" ValidationGroup="SaveCatIII" Enabled="false" />
                                                    <asp:ImageButton ID="imgbtnUpdateCatIII" runat="server" ImageUrl="~/Images/update.png" ToolTip="Update Category" OnClick="imgbtnUpdateCatIII_Click" ValidationGroup="SaveCatIII" Visible="false" />
                                                    <asp:ImageButton ID="imgbtnEditCatIII" runat="server" ImageUrl="~/Images/edit23.png" Width="16" Height="16" ToolTip="Edit Category" OnClick="imgbtnEditCatIII_Click" />
                                                    <asp:ImageButton ID="imgbtnCancelCatIII" runat="server" Enabled="false" ImageUrl="~/Images/reset1.png" Width="16" Height="16" ToolTip="Add Category" OnClick="imgbtnCancelCatIII_Click" />
                                                    <asp:RequiredFieldValidator ID="rfvtxtCatLevelIII" runat="server" ControlToValidate="txtCatLevelIII" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SaveCatIII"></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="rfvddlCateLevelIII" runat="server" ControlToValidate="ddlCateLevelIII" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddCatIV"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:TextBox ID="txtCatLevelIII" runat="server" CssClass="form-control  form-control-sm" ValidationGroup="SaveCatIII" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="ddlCateLevelIII" runat="server" CssClass="form-control form-control-sm chzn-select" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlCateLevelIII_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row mt-1">
                                            <div class="col-md-4">
                                                <label class=" col-form-label">
                                                    Category IV: <span title="*"></span>
                                                    <asp:ImageButton ID="imgbtnCatelevelIV" runat="server" ImageUrl="~/Images/plus.png" OnClick="imgbtnCatelevelIV_Click" ValidationGroup="AddCatIV" />
                                                    <asp:ImageButton ID="imgbtnSaveCateLvlIV" runat="server" ImageUrl="~/Images/save.png" OnClick="imgbtnSaveCateLvlIV_Click" ValidationGroup="SaveCatIV" Enabled="false" />
                                                    <asp:ImageButton ID="imgbtnUpdateCateLvIV" runat="server" ImageUrl="~/Images/update.png" ToolTip="Update Category" OnClick="imgbtnUpdateCateLvIV_Click" ValidationGroup="SaveCatIV" Visible="false" />
                                                    <asp:ImageButton ID="imgbtnEditCatLvIV" runat="server" ImageUrl="~/Images/edit23.png" Width="16" Height="16" ToolTip="Edit Category" OnClick="imgbtnEditCatLvIV_Click" />
                                                    <asp:ImageButton ID="imgbtnCancelCatIV" runat="server" Enabled="false" ImageUrl="~/Images/reset1.png" Width="16" Height="16" ToolTip="Add Category" OnClick="imgbtnCancelCatIV_Click" />
                                                    <asp:RequiredFieldValidator ID="rfvtxtCateLevelIV" runat="server" ControlToValidate="txtCateLevelIV" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SaveCatIV"></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="rfvddlCateLevelIV" runat="server" ControlToValidate="ddlCateLevelIV" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddCatV"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:TextBox ID="txtCateLevelIV" runat="server" CssClass="form-control  form-control-sm" ValidationGroup="SaveCatIV" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="ddlCateLevelIV" runat="server" CssClass="form-control form-control-sm chzn-select" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlCateLevelIV_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row mt-1">
                                            <div class="col-md-4">

                                                <label class=" col-form-label">
                                                    Category V: <span title="*"></span>
                                                    <asp:ImageButton ID="imgbtnAddCatV" runat="server" ImageUrl="~/Images/plus.png" OnClick="imgbtnAddCatV_Click" ValidationGroup="AddCatV" />
                                                    <asp:ImageButton ID="imgbtnSaveCatV" runat="server" ImageUrl="~/Images/save.png" OnClick="imgbtnSaveCatV_Click" ValidationGroup="SaveCatV" Enabled="false" />
                                                    <asp:ImageButton ID="imgbtnUpdateCatV" runat="server" ImageUrl="~/Images/update.png" ToolTip="Update Category" OnClick="imgbtnUpdateCatV_Click" ValidationGroup="SaveCatV" Visible="false" />
                                                    <asp:ImageButton ID="imgbtnEditCatV" runat="server" ImageUrl="~/Images/edit23.png" Width="16" Height="16" ToolTip="Edit Category" OnClick="imgbtnEditCatV_Click" />
                                                    <asp:ImageButton ID="imgbtnCancelCatV" runat="server" ImageUrl="~/Images/reset1.png" Width="16" Height="16" ToolTip="Add Category" OnClick="imgbtnCancelCatV_Click" />
                                                    <asp:RequiredFieldValidator ID="rfvtxtCatV" runat="server" ControlToValidate="txtCatV" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SaveCatV"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:TextBox ID="txtCatV" runat="server" CssClass="form-control  form-control-sm" ValidationGroup="SaveCatV" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="ddlCatV" runat="server" CssClass="form-control form-control-sm chzn-select" Enabled="false">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="col-md-2 offset-10 ">
                                                <asp:Button ID="btnClose7" runat="server" Text="Close" class="btn btn-danger" OnClick="btnClose7_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="d-flex align-items-center gap-3">
                                <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkPreviousPriority" runat="server" OnClick="lnkPreviousPriority_Click">Previous</asp:LinkButton>
                                <asp:LinkButton class="btn btn-grd-primary px-4" ID="lnkNextEmailConfig" runat="server" OnClick="lnkNextEmailConfig_Click">Next</asp:LinkButton>
                            </div>
                        </div>
                        <asp:HiddenField ID="hdnVarCategoryI" runat="server" />
                        <asp:HiddenField ID="hdnVarCategoryII" runat="server" />
                        <asp:HiddenField ID="hdnVarCategoryIII" runat="server" />
                        <asp:HiddenField ID="hdnVarCategoryIV" runat="server" />
                        <asp:HiddenField ID="hdnVarCategoryV" runat="server" />
                    </ContentTemplate>

                    <Triggers>
                        <asp:PostBackTrigger ControlID="ddlRequestType" />
                        <%--Parent Controls  Category I Controls--%>
                        <asp:PostBackTrigger ControlID="ddlParentCategory" />
                        <asp:PostBackTrigger ControlID="imgbtnAddParentCategory" />
                        <asp:PostBackTrigger ControlID="imgbtnSaveParentCategory" />
                        <asp:PostBackTrigger ControlID="imgbtnEditParentCategory" />
                        <asp:PostBackTrigger ControlID="imgbtnCancelParent" />
                        <%--Parent Controls  Category II Controls--%>
                        <asp:PostBackTrigger ControlID="ddlCatII" />
                        <asp:PostBackTrigger ControlID="imgbtnCatII" />
                        <asp:PostBackTrigger ControlID="imgbtnSaveCatII" />
                        <asp:PostBackTrigger ControlID="imgbtnEditCatII" />
                        <asp:PostBackTrigger ControlID="imgbtnCancelCatII" />
                        <%--Parent Controls  Category III Controls--%>
                        <asp:PostBackTrigger ControlID="ddlCateLevelIII" />
                        <asp:PostBackTrigger ControlID="imgAddCatIII" />
                        <asp:PostBackTrigger ControlID="imgSaveCatIII" />
                        <asp:PostBackTrigger ControlID="imgbtnEditCatIII" />
                        <asp:PostBackTrigger ControlID="imgbtnCancelCatIII" />

                        <%--Parent Controls  Category IV Controls--%>
                        <asp:PostBackTrigger ControlID="ddlCateLevelIV" />
                        <asp:PostBackTrigger ControlID="imgbtnCatelevelIV" />
                        <asp:PostBackTrigger ControlID="imgbtnSaveCateLvlIV" />
                        <asp:PostBackTrigger ControlID="imgbtnEditCatLvIV" />
                        <asp:PostBackTrigger ControlID="imgbtnCancelCatIV" />
                        <%--Parent Controls  Category V Controls--%>

                        <asp:PostBackTrigger ControlID="imgbtnAddCatV" />
                        <asp:PostBackTrigger ControlID="imgbtnSaveCatV" />
                        <asp:PostBackTrigger ControlID="imgbtnEditCatV" />
                        <asp:PostBackTrigger ControlID="imgbtnCancelCatV" />
                        <asp:PostBackTrigger ControlID="lnkPreviousPriority" />
                        <asp:PostBackTrigger ControlID="lnkNextEmailConfig" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
            <%--Add Category End--%>

            <%--Add Email Config Start--%>
            <asp:Panel ID="pnlAddEmailConfig" runat="server" Visible="false">
                <asp:UpdatePanel ID="updatepanel8" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Host Name : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtHostName" runat="server" ControlToValidate="txtHostName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtHostName" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Port: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtPort" runat="server" ControlToValidate="txtPort" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtPort" runat="server" TextMode="Number" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                User Name: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Password : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Sender Email: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                RetryInterval : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtRetry" runat="server" ControlToValidate="txtRetry" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtRetry" runat="server" TextMode="Number" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Client ID: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtClientID" runat="server" ControlToValidate="txtClientID" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtClientID" runat="server" TextMode="MultiLine" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Client Secret Key : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtClientSecretKey" runat="server" ControlToValidate="txtClientSecretKey" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtClientSecretKey" runat="server" TextMode="MultiLine" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Tenant ID: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtTenantID" runat="server" ControlToValidate="txtTenantID" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtTenantID" runat="server" TextMode="MultiLine" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>

                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Organization: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlOrgEmailConfig" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlOrgEmailConfig" runat="server" CssClass="form-control form-control-sm chzn-select">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="col-md-3 offset-5 ">
                                                <asp:Button ID="btnInsertEmailConfig" runat="server" Text="Save" class="btn btn-sm savebtn" OnClick="btnInsertEmailConfig_Click" ValidationGroup="EmailConfig" />
                                                <asp:Button ID="btnUpdateEmailConfig" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateEmailConfig_Click" ValidationGroup="EmailConfig" />
                                                <asp:Button ID="btnCancel8" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel8_Click" CausesValidation="false" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12 col-md-8 col-sm-6 graphs">
                                                <div class="xs">
                                                    <div class="well1 white">
                                                        <div class="card card-default">
                                                            <div class="card-body">
                                                                <div class="row ">
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="Label18" runat="server" Text="EmailConfig Details" Font-Size="Larger" ForeColor="Black"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-2 ">
                                                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                                            <label class="mr-2 ml-1 mb-0">Export</label>
                                                                            <asp:ImageButton ID="ImgBtnExport8" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport8_Click" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-12">
                                                                        <div class="d-flex align-items-center gap-3">
                                                                            <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkPreviousCategory" runat="server" OnClick="lnkPreviousCategory_Click">Previous</asp:LinkButton>
                                                                            <asp:LinkButton class="btn btn-grd-primary px-4" ID="lnkNextResolution" runat="server" OnClick="lnkNextResolution_Click">Next</asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="table-responsive p-0" style="height: 400px; width: 100%">
                                                                    <asp:GridView GridLines="None" ID="gvEmailConfig" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-head-fixed text-nowrap"
                                                                        Width="100%" OnRowCommand="gvEmailConfig_RowCommand" OnRowDataBound="gvEmailConfig_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                                <ItemTemplate>
                                                                                    <%#Container.DataItemIndex+1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Hostname" HeaderText="Host Name" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="Port" HeaderText="Port" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="UserName" HeaderText="UserName" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="Email" HeaderText="Email" NullDisplayText="NA" />
                                                                            <asp:TemplateField HeaderText="Password" ItemStyle-Width="20">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl" runat="server" Text="*********"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Retry" HeaderText="Retry" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="ClientID" HeaderText="ClientID" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="ClientSecretKey" HeaderText="ClientSecretKey" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="TenantID" HeaderText="TenantID" NullDisplayText="NA" />
                                                                            <asp:TemplateField HeaderText=" Organization">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblOrgFk" runat="server" Text='<%# Eval("Org_ID") %>' Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lblOrgName" runat="server" Text='<%# Eval("OrgName") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:ButtonField ButtonType="Image" CommandName="UpdateEmailConfig" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                                            <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEmailConfig" ItemStyle-Width="20px" ItemStyle-Height="5px" />
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
                        <asp:PostBackTrigger ControlID="btnInsertEmailConfig" />
                        <asp:PostBackTrigger ControlID="gvEmailConfig" />
                        <asp:PostBackTrigger ControlID="btnUpdateEmailConfig" />
                        <asp:PostBackTrigger ControlID="lnkPreviousCategory" />
                        <asp:PostBackTrigger ControlID="lnkNextResolution" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
            <%--Add Email Config End--%>

            <%--Add Resolution Start--%>
            <asp:Panel ID="pnlAddResolution" runat="server" Visible="false">
                <asp:UpdatePanel ID="updatepanel9" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Organization: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlOrgResolution" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlOrgResolution_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Request Type: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlRequestType" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlRequestTypeResolution" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Resolution Name : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtResolution" runat="server" ControlToValidate="txtResolution" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Resol"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtResolution" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Resolution Description : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtResolutnDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Resol"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-10 pr-5">
                                                <asp:TextBox ID="txtResolutnDesc" runat="server" TextMode="MultiLine" Rows="5" Columns="5" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="col-md-3  offset-5">
                                                <asp:Button ID="btnInsertResolution" runat="server" Text="Save" class="btn btn-sm savebtn" OnClick="btnInsertResolution_Click" ValidationGroup="Resol" />
                                                <asp:Button ID="btnUpdateResolution" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateResolution_Click" ValidationGroup="Resol" />
                                                <asp:Button ID="btnCancel9" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel9_Click" CausesValidation="false" />
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="d-flex align-items-center gap-3">
                                                <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkPreviousEmailConfig" runat="server" OnClick="lnkPreviousEmailConfig_Click">Previous</asp:LinkButton>
                                                <asp:LinkButton class="btn btn-grd-primary px-4" ID="lnkNextSLA" runat="server" OnClick="lnkNextSLA_Click">Next</asp:LinkButton>
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
                                                                        <asp:Label ID="Label21" runat="server" Text="Resolution Details" Font-Size="Larger" ForeColor="Black"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label22" runat="server"></asp:Label>
                                                                        <asp:Label ID="Label23" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-2 ">
                                                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                                            <label class="mr-2 ml-1 mb-0">Export</label>
                                                                            <asp:ImageButton ID="ImgBtnExport9" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport9_Click" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <asp:GridView GridLines="None" ID="gvResolution" runat="server" DataKeyNames="ResolutionRef" AutoGenerateColumns="false" CssClass="table table-bordered"
                                                                    Width="100%" OnRowCommand="gvResolution_RowCommand" OnRowDataBound="gvResolution_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                            <ItemTemplate>
                                                                                <%#Container.DataItemIndex+1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="DeskRef" HeaderText="Request Type" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="ResolutionCodeRef" HeaderText=" Resolution Name" NullDisplayText="NA" />
                                                                        <asp:BoundField DataField="ResolutionDesc" HeaderText="Resolution Description" NullDisplayText="NA" />
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
                        <asp:PostBackTrigger ControlID="ImgBtnExport9" />
                        <asp:PostBackTrigger ControlID="ddlOrgResolution" />
                        <asp:PostBackTrigger ControlID="ddlRequestTypeResolution" />
                        <asp:PostBackTrigger ControlID="btnInsertResolution" />
                        <asp:PostBackTrigger ControlID="gvResolution" />
                        <asp:PostBackTrigger ControlID="btnUpdateResolution" />
                        <asp:PostBackTrigger ControlID="lnkPreviousEmailConfig" />
                        <asp:PostBackTrigger ControlID="lnkNextSLA" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
            <%--Add Resolution End--%>

            <%--Add SLA Start--%>
            <asp:Panel ID="pnlAddSLA" runat="server" Visible="false">
                <asp:UpdatePanel ID="updatepanel10" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Organization: : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlOrgSLA" ErrorMessage="*" Font-Bold="true" InitialValue="0" ForeColor="Red" ValidationGroup="SLA"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlOrgSLA" runat="server" CssClass="form-control form-control-sm chzn-select">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                SLA Name : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtSLAName" runat="server" ControlToValidate="txtSLAName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SLA"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtSLAName" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                SLA Description : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtSLADescription" runat="server" ControlToValidate="txtSLADescription" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SLA"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtSLADescription" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="col-md-3 offset-5 ">
                                                <asp:Button ID="btnInsertSLA" runat="server" Text="Save" class="btn btn-sm savebtn" OnClick="btnInsertSLA_Click" ValidationGroup="SLA" />
                                                <asp:Button ID="btnUpdateSLA" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateSLA_Click" ValidationGroup="SLA" />
                                                <asp:Button ID="btnCancel10" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel10_Click" CausesValidation="false" />
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="d-flex align-items-center gap-3">
                                                <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkPreviousResolution" runat="server" OnClick="lnkPreviousResolution_Click">Previous</asp:LinkButton>
                                                <asp:LinkButton class="btn btn-grd-primary px-4" ID="LinkButton2" runat="server" OnClick="lnkNextSLA_Click">Next</asp:LinkButton>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-10 col-md-8 col-sm-6 graphs">
                                                    <div class="xs">
                                                        <div class="well1 white">
                                                            <div class="card card-default">

                                                                <div class="card-body">
                                                                    <div class="row ">
                                                                        <div class="col-md-2 ">
                                                                            <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                                                <label class="mr-2 ml-1 mb-0">Export</label>
                                                                                <asp:ImageButton ID="ImgBtnExport10" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport10_Click" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="table-responsive p-0" style="height: 400px; width: 100%">
                                                                        <asp:GridView GridLines="None" ID="gvSLA" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-head-fixed text-nowrap"
                                                                            Width="100%" OnRowCommand="gvSLA_RowCommand" OnRowDataBound="gvSLA_RowDataBound">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                                    <ItemTemplate>
                                                                                        <%#Container.DataItemIndex+1 %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="SlaName" HeaderText="SLA Name" NullDisplayText="NA" />
                                                                                <asp:BoundField DataField="SLADesc" HeaderText="SLA Description" NullDisplayText="NA" />
                                                                                <asp:TemplateField HeaderText=" Organization">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblOrgFk" runat="server" Text='<%# Eval("Org_ID") %>' Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblOrgName" runat="server" Text='<%# Eval("OrgName") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:ButtonField ButtonType="Image" CommandName="UpdateSLA" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                                                <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteSLA" ItemStyle-Width="20px" ItemStyle-Height="5px" />
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
                        <asp:PostBackTrigger ControlID="ImgBtnExport10" />
                        <asp:PostBackTrigger ControlID="btnInsertSLA" />
                        <asp:PostBackTrigger ControlID="gvSLA" />
                        <asp:PostBackTrigger ControlID="btnUpdateSLA" />
                    </Triggers>

                </asp:UpdatePanel>
            </asp:Panel>
            <%--Add SLA End--%>
        </div>
    </div>
</asp:Content>

