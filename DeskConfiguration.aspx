<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DeskConfiguration.aspx.cs" Inherits="DeskConfiguration" MaintainScrollPositionOnPostback="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .dataTables_filter {
            margin-top: -29px !important;
        }

        .dt-buttons > .btn-outline-secondary {
            padding: 0.25rem 0.5rem !important;
            font-size: 0.875rem !important;
        }

        .pagination {
            --bs-pagination-padding-x: 0.5rem;
            --bs-pagination-padding-y: 0.25rem;
            --bs-pagination-font-size: 0.875rem;
            --bs-pagination-border-radius: var(--bs-border-radius-sm);
            /*margin-top: -1.7rem!important;*/
        }
    </style>
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

        .vr {
            rotate: 90deg;
            margin: 5px 1px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
    <div id="stepper1" class="bs-stepper">

        <%--Stepper Start--%>
        <asp:UpdatePanel ID="updtcardbtn" runat="server">
            <ContentTemplate>
                <div class="card mb-0" style="border-radius: 0.375rem 0.375rem 0 0">
                    <div class="card-header ">
                        <div class="row">
                            <div class="d-lg-flex flex-lg-row align-items-lg-center justify-content-lg-between " role="tablist">

                                <!-- Step 1 -->
                                <asp:LinkButton ID="stepper1trigger1" runat="server" CssClass='<%# CurrentStep == 1 ? "btn step-trigger btn-grd-primary  p-2 rounded-circle" : "btn step-trigger" %>' OnClick="StepButton_Click1">
                         <div class="bs-stepper-circle">1</div>
                      
                                </asp:LinkButton>
                                <div class="vr"></div>



                                <!-- Step 2 -->
                                <asp:LinkButton ID="stepper1trigger2" runat="server" CssClass='<%# CurrentStep == 2 ? "btn step-trigger btn-grd-primary  p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 2 %>' OnClick="StepButton_Click2">
                        <div class="bs-stepper-circle">2</div>
                      
                                </asp:LinkButton>

                                <div class="vr"></div>

                                <!-- Step 3 -->
                                <asp:LinkButton ID="stepper1trigger3" runat="server" CssClass='<%# CurrentStep == 3 ? "btn step-trigger btn-grd-primary  p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 3 %>' OnClick="StepButton_Click3">
                         <div class="bs-stepper-circle">3</div>
                        
                                </asp:LinkButton>

                                <div class="vr"></div>
                                <!-- Step 4 -->
                                <asp:LinkButton ID="stepper1trigger4" runat="server" CssClass='<%# CurrentStep == 4 ? "btn step-trigger btn-grd-primary  p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 4 %>' OnClick="StepButton_Click4">
                            <div class="bs-stepper-circle">4</div>
                           
                                </asp:LinkButton>
                                <div class="vr"></div>
                                <!-- Step 5 -->
                                <asp:LinkButton ID="stepper1trigger5" runat="server" CssClass='<%# CurrentStep == 5 ? "btn step-trigger btn-grd-primary  p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 5 %>' OnClick="StepButton_Click5">
<div class="bs-stepper-circle">5</div>
                       
                                </asp:LinkButton>
                                <div class="vr"></div>
                                <!-- Step 6 -->
                                <asp:LinkButton ID="stepper1trigger6" runat="server" CssClass='<%# CurrentStep == 6 ? "btn step-trigger btn-grd-primary p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 6 %>' OnClick="StepButton_Click6">
<div class="bs-stepper-circle">6</div>
                       
                                </asp:LinkButton>
                                <div class="vr"></div>
                                <!-- Step 7 -->
                                <asp:LinkButton ID="stepper1trigger7" runat="server" CssClass='<%# CurrentStep == 7 ? "btn step-trigger btn-grd-primary p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 7 %>' OnClick="StepButton_Click7">
<div class="bs-stepper-circle">7</div>
                     
                                </asp:LinkButton>
                                <div class="vr"></div>
                                <!-- Step 8 -->
                                <asp:LinkButton ID="stepper1trigger8" runat="server" CssClass='<%# CurrentStep == 8 ? "btn step-trigger btn-grd-primary p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 8 %>' OnClick="StepButton_Click8">
        <div class="bs-stepper-circle">8</div>
      
                                </asp:LinkButton>
                                <div class="vr"></div>
                                <!-- Step 9 -->
                                <asp:LinkButton ID="stepper1trigger9" runat="server" CssClass='<%# CurrentStep == 9 ? "btn step-trigger btn-grd-primary p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 9 %>' OnClick="StepButton_Click9">
<div class="bs-stepper-circle">9</div>
                       
                                </asp:LinkButton>
                                <div class="vr"></div>
                                <!-- Step 10 -->
                                <asp:LinkButton ID="stepper1trigger10" runat="server" CssClass='<%# CurrentStep == 10 ? "btn step-trigger btn-grd-primary p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 10 %>' OnClick="StepButton_Click10">
        <div class="bs-stepper-circle">10</div>
       
                                </asp:LinkButton>
                                <div class="vr"></div>
                                <!-- Step 11 -->
                                <asp:LinkButton ID="stepper1trigger11" runat="server" CssClass='<%# CurrentStep == 11 ? "btn step-trigger btn-grd-primary p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 11 %>' OnClick="StepButton_Click11">
        <div class="bs-stepper-circle">11</div>
       
                                </asp:LinkButton>
                                <div class="vr"></div>
                                <!-- Step 12 -->
                                <asp:LinkButton ID="stepper1trigger12" runat="server" CssClass='<%# CurrentStep == 12 ? "btn step-trigger btn-grd-primary p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 12 %>' OnClick="StepButton_Click12">
        <div class="bs-stepper-circle">12</div>
       
                                </asp:LinkButton>

                                <div class="col-md-3" hidden>
                                    <!-- Step 13 -->
                                    <asp:LinkButton ID="stepper1trigger13" runat="server" CssClass='<%# CurrentStep == 13 ? "btn step-trigger btn-grd-primary p-2 rounded-circle" : "btn step-trigger" %>' Enabled='<%# CurrentStep >= 13 %>' OnClick="StepButton_Click13">
        <div class="bs-stepper-circle">13</div>
        <div class="">
            <h5 class="mb-0 steper-title">Exclation Matrix</h5>
            <p class="mb-0 steper-sub-title">Exclation Matrix</p>
        </div>
                                    </asp:LinkButton>
                                </div>
                            </div>
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
                    <div class="card mb-1" style="border-radius: 0 0 0.375rem 0.375rem">
                        <div class="card-body">
                            <div class="d-flex align-items-start justify-content-between">
                                <h6 class="mb-4">Organisation</h6>
                                <div class="">
                                    <asp:LinkButton class="btn btn-sm bs-stepper-circle rounded-circle btn-secondary" ID="lnkNextAddReq" runat="server" OnClick="lnkNextAddReq_Click"><i class="fa-solid fa-angle-right"></i></asp:LinkButton>

                                </div>
                            </div>

                            <div class=" row gy-3 gx-2">
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Organization Name  
                                        <asp:RequiredFieldValidator ID="rfvtxtprioritye" runat="server" ControlToValidate="txtOrgName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtOrgName" runat="server" CssClass="form-control  form-control-sm" onkeypress="return /^[a-zA-Z\s]*$/.test(event.key) && this.value.length < 20;"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <label for="staticEmail" class="form-label">
                                        Organization Description 
                                        <asp:RequiredFieldValidator ID="rfvPriority" runat="server" ControlToValidate="txtOrgDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtOrgDesc" runat="server" TextMode="MultiLine" Rows="2" Columns="5" CssClass="form-control  form-control-sm" MaxLength="1000"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Contact Person Name 
                                              <asp:RequiredFieldValidator ID="rfvtxtCntnctPrnsName" runat="server" ControlToValidate="txtCntnctPrnsName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtCntnctPrnsName" runat="server" CssClass="form-control  form-control-sm" onkeypress="return /^[a-zA-Z\s]*$/.test(event.key) && this.value.length < 20;" MaxLength="20"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Contact Person Mobile 
                                             <asp:RequiredFieldValidator ID="rfvtxtCntctPrnsMob" runat="server" ControlToValidate="txtCntctPrnsMob" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtCntctPrnsMob" runat="server" CssClass="form-control  form-control-sm" onkeypress="return /^[0-9]*$/.test(event.key) && this.value.length < 12;" MaxLength="12"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Contact Person Email
                                       <asp:RequiredFieldValidator ID="rfvtxtCntctPrsnEmail" runat="server" ControlToValidate="txtCntctPrsnEmail" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>


                                    <asp:TextBox ID="txtCntctPrsnEmail" runat="server" CssClass="form-control  form-control-sm" MaxLength="100"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Contact PersonII Name 
                                    </label>


                                    <asp:TextBox ID="txtCntctPrsnNameII" runat="server" CssClass="form-control  form-control-sm" onkeypress="return /^[a-zA-Z\s]*$/.test(event.key) && this.value.length < 20;" MaxLength="20"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Contact PersonII Mobile
                                    </label>


                                    <asp:TextBox ID="txtCntctPrsnMobII" runat="server" CssClass="form-control  form-control-sm" onkeypress="return /^[0-9]*$/.test(event.key) && this.value.length < 12;" MaxLength="12"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Contact PersonII Email
                                    </label>


                                    <asp:TextBox ID="txtCntctPrnsEmailII" runat="server" CssClass="form-control  form-control-sm" MaxLength="100"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                </div>
                                <div class="col-6 text-end">
                                    <asp:Button ID="btnInsertOrg" runat="server" Text="Save" class="btn btn-sm btn-grd btn-grd-info " OnClick="btnInsertOrg_Click" ValidationGroup="Priority" />
                                    <asp:Button ID="btnUpdateOrg" runat="server" Text="Update" Visible="false" class="btn btn-sm btn-grd btn-grd-info " OnClick="btnUpdateOrg_Click" ValidationGroup="Priority" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-sm btn-grd btn-grd-danger " OnClick="btnCancel_Click" CausesValidation="false" />

                                </div>

                            </div>
                        </div>

                    </div>
                    <div class="card">
                        <div class="card-body">

                            <div class="d-flex align-items-start justify-content-between">
                                <div class="">
                                    <h6 class="mb-0">
                                        <asp:Label ID="lblsofname" runat="server" Text="Organization Details"></asp:Label></h6>
                                </div>
                                <asp:LinkButton ID="ImgBtnExport" CssClass="btn btn-sm btn-outline-secondary " runat="server" OnClick="ImgBtnExport_Click"> Excel <i class="fa-solid fa-download"></i></asp:LinkButton>

                            </div>
                            <div class="row ">

                                <div class="col-md-6">
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-12 text-end">
                                    <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                        <%--  <asp:ImageButton ID="" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" />--%>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="table-responsive table-container">
                                        <asp:GridView GridLines="None" ID="gvOrg" runat="server" DataKeyNames="Org_ID" AutoGenerateColumns="false" CssClass="data-table table table-striped border table-sm text-nowrap"
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
                                                <%--<asp:ButtonField ButtonType="Image" CommandName="SelectState" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />--%>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="SelectState" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Edit">
                                                <i class="fa-solid fa-edit"></i>
                                                </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteEx" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                                <i class="fa-solid fa-xmark text-danger"></i> 
                                                </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
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

                    <div class="card mb-1" style="border-radius: 0 0 0.375rem 0.375rem">
                        <div class="card-body">
                            <div class="d-flex align-items-start justify-content-between">
                                <h6 class="mb-3 fw-bold">Add Request Type</h6>
                                <div class="d-flex">
                                    <asp:LinkButton class="btn btn-sm bs-stepper-circle rounded-circle btn-secondary" ID="lnkPrevOrg" runat="server" OnClick="lnkPrevOrg_Click"><i class="fa-solid fa-angle-left"></i></asp:LinkButton>
                                    &nbsp;
                                    <asp:LinkButton class="btn btn-sm bs-stepper-circle rounded-circle btn-secondary" ID="lnkNextStage" runat="server" OnClick="lnkNextStage_Click"><i class="fa-solid fa-angle-right"></i></asp:LinkButton>
                                </div>
                            </div>
                            <div class=" row gx-2 gy-3">
                                <div class="col-md-6">
                                    <label for="staticEmail" class="form-label">
                                        Organization
                                                <asp:RequiredFieldValidator ID="rfvddlOrg" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label for="staticEmail" class="form-label">
                                        Request Type 
                                                <asp:RequiredFieldValidator ID="rfvReqType" runat="server" ControlToValidate="txtRequestType" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtRequestType" runat="server" CssClass="form-control  form-control-sm" onkeypress="return /^[a-zA-Z\s]*$/.test(event.key) && this.value.length < 20;"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <label for="staticEmail" class="form-label">
                                        Request Description 
                                                <asp:RequiredFieldValidator ID="rfvRequestDesc" runat="server" ControlToValidate="txtReqDescription" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtReqDescription" runat="server" TextMode="MultiLine" Rows="2" Columns="3" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>

                                <div class="col-6 ">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSaveReqType_Click" class="btn btn-sm btn-grd btn-grd-info" ValidationGroup="ReqType"></asp:Button>
                                    <asp:Button ID="btnUpdateReqType" runat="server" Text="Update" Visible="false" class="btn btn-sm btn-grd btn-grd-info" OnClick="btnUpdateReqType_Click" ValidationGroup="ReqType" />
                                    <asp:Button ID="btnCancel1" runat="server" Text="Cancel" CssClass="btn btn-sm btn-grd btn-grd-danger" OnClick="btnCancel1_Click" />
                                </div>
                                <div class="col-6 text-end">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-body">
                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <div class="">
                                    <h6 class="mb-0">
                                        <asp:Label ID="Label2" runat="server" Text="Request Type Details"></asp:Label>
                                    </h6>
                                </div>
                                <asp:LinkButton ID="ImgBtnExportReq" runat="server" CssClass="btn btn-sm btn-outline-secondary" OnClick="ImgBtnExportReq_Click">Export <i class="fa-solid fa-download"></i></asp:LinkButton>
                            </div>
                            <div class="row ">

                                <div class="col-md-6">
                                    <asp:Label ID="Label4" runat="server"></asp:Label>
                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                </div>

                                <div class="col-md-12">
                                    <div class="table-responsive table-container">
                                        <asp:GridView GridLines="None" ID="gvReqType" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="data-table table table-striped border table-sm text-nowrap"
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
                                                <%-- <asp:ButtonField ButtonType="Image" CommandName="SelectState" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />--%>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit1" runat="server" CommandName="SelectState" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Edit">
                                                    <i class="fa-solid fa-edit"></i>
                                                    </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete1" runat="server" CommandName="DeleteEx" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                                    <i class="fa-solid fa-xmark text-danger"></i> 
                                                    </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>




                </ContentTemplate>
                <Triggers>
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

                    <div class="card mb-1" style="border-radius: 0 0 0.375rem 0.375rem">
                        <div class="card-body">
                            <h6 class="mb-3 fw-bold">Add Stage</h6>
                            <div class="row gx-2 gy-3">
                                <div class="col-md-6">
                                    <label for="staticEmail" class="form-label">
                                        Organization
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlOrg2" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Stage"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlOrg2" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg2_SelectedIndexChanged">
                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label for="staticEmail" class="form-label">
                                        Request Type
                                                <asp:RequiredFieldValidator ID="rfvddlRequestType" runat="server" ControlToValidate="ddlRequestType" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Stage"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlRequestType" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label for="staticEmail" class="form-label">
                                        Stage Name
                                        <asp:RequiredFieldValidator ID="rfvtxtStageName" runat="server" ControlToValidate="txtStageName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Stage"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtStageName" runat="server" CssClass="form-control  form-control-sm" onkeypress="return /^[a-zA-Z\s]*$/.test(event.key) && this.value.length < 20;"></asp:TextBox>

                                </div>
                                <div class="col-md-6">
                                    <label for="staticEmail" class="form-label">
                                        Stage Description 
     <asp:RequiredFieldValidator ID="rfvtxtStageDesc" runat="server" ControlToValidate="txtStageDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Stage"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtStageDesc" runat="server" TextMode="MultiLine" Rows="1" CssClass="form-control  form-control-sm"></asp:TextBox>

                                </div>
                                <div class="col-6 ">
                                    <asp:Button ID="btnInsertStage" runat="server" Text="Save" class="btn btn-sm btn-grd btn-grd-info" OnClick="btnInsertStage_Click" ValidationGroup="Stage" />
                                    <asp:Button ID="btnUpdateStage" runat="server" Text="Update" Visible="false" class="btn btn-sm btn-grd btn-grd-info" OnClick="btnUpdateStage_Click" ValidationGroup="Severity" />
                                    <asp:Button ID="btnCancel2" runat="server" Text="Cancel" class="btn btn-sm btn-grd btn-grd-danger" OnClick="btnCancel2_Click" CausesValidation="false" />
                                </div>
                                <div class="col-6 text-end">
                                    <asp:LinkButton class="btn btn-grd-info btn-sm" ID="lnkbtnPrevAddReq" runat="server" OnClick="lnkbtnPrevAddReq_Click">Previous</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-grd-primary btn-sm" ID="lnkbtnNextStatus" runat="server" OnClick="lnkbtnNextStatus_Click">Next</asp:LinkButton>
                                </div>


                            </div>
                        </div>
                    </div>

                    <div class="card ">

                        <div class="card-body">
                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <div class="">
                                    <h6 class="mb-0">
                                        <asp:Label ID="Label6" runat="server" Text="Stage Details"></asp:Label>
                                    </h6>
                                </div>
                                <asp:LinkButton ID="ImgBtnExport2" runat="server" CssClass="btn btn-sm btn-outline-secondary" OnClick="ImgBtnExport2_Click">Export <i class="fa-solid fa-download"></i></asp:LinkButton>

                            </div>


                            <div class="row ">

                                <div class="col-md-6">
                                    <asp:Label ID="Label7" runat="server"></asp:Label>
                                    <asp:Label ID="Label8" runat="server"></asp:Label>
                                </div>

                            </div>
                            <asp:GridView GridLines="None" ID="gvStage" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="data-table table table-striped border table-sm"
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
                                    <%--<asp:ButtonField ButtonType="Image" CommandName="SelectStage" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                    <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />--%>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit2" runat="server" CommandName="SelectStage" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Edit">
                                <i class="fa-solid fa-edit"></i>
                                </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete2" runat="server" CommandName="DeleteEx" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                <i class="fa-solid fa-xmark text-danger"></i> 
                                </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>





                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="ddlRequestType" />
                    <asp:PostBackTrigger ControlID="ImgBtnExport2" />
                    <asp:PostBackTrigger ControlID="gvStage" />
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

                    <div class="card mb-1" style="border-radius: 0 0 0.375rem 0.375rem">
                        <div class="card-body">
                            <h6 class="mb-3 fw-bold">Add Status</h6>
                            <div class="row gx-2 gy-3">
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Organization
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlOrg3" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Status"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlOrg3" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg3_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Request Type
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlRequestTypeStatus" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Status"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlRequestTypeStatus" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestTypeStatus_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Stage
									<asp:RequiredFieldValidator ID="rfvddlStage" runat="server" ControlToValidate="ddlStage" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Status"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlStage" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Status Name
                                            <asp:RequiredFieldValidator ID="rfvtxtStatusName" runat="server" ControlToValidate="txtStatusName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Status"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtStatusName" runat="server" CssClass="form-control  form-control-sm" onkeypress="return /^[a-zA-Z\s]*$/.test(event.key) && this.value.length < 50;"></asp:TextBox>

                                </div>

                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Status Description
                                            <asp:RequiredFieldValidator ID="rfvtxtStatusDesc" runat="server" ControlToValidate="txtStatusDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Status"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtStatusDesc" runat="server" TextMode="MultiLine" Rows="1" CssClass="form-control  form-control-sm"></asp:TextBox>

                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Choose Status Color 
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtColorForStatus" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Status"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtColorForStatus" TextMode="Color" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>

                                </div>
                                <div class="col-6">
                                    <asp:Button ID="btnInsertStatus" runat="server" Text="Save" class="btn btn-sm btn-grd btn-grd-info " OnClick="btnInsertStatus_Click" ValidationGroup="Status" />
                                    <asp:Button ID="btnUpdateStatus" runat="server" Text="Update" Visible="false" class="btn btn-sm btn-grd btn-grd-info " OnClick="btnUpdateStatus_Click" ValidationGroup="Status" />
                                    <asp:Button ID="btnCancel3" runat="server" Text="Cancel" class="btn btn-sm btn-grd btn-grd-danger " OnClick="btnCancel3_Click" CausesValidation="false" />
                                </div>
                                <div class="col-6 text-end">
                                    <asp:LinkButton class="btn btn-grd-info btn-sm" ID="lnkPrevStage" runat="server" OnClick="lnkPrevStage_Click">Previous</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-grd-primary btn-sm" ID="lnkNextSeverity" runat="server" OnClick="lnkNextSeverity_Click">Next</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card ">

                        <div class="card-body">


                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <div class="">
                                    <h6 class="mb-0 fw-bold">
                                        <asp:Label ID="Label9" runat="server" Text="Status Details"></asp:Label></h6>
                                    </h6>
                                </div>
                                <asp:LinkButton ID="ImgBtnExport3" runat="server" CssClass="btn btn-sm btn-outline-secondary" OnClick="ImgBtnExport3_Click">Export <i class="fa-solid fa-download"></i></asp:LinkButton>
                            </div>


                            <div class="row ">

                                <div class="col-md-6">
                                    <asp:Label ID="Label10" runat="server"></asp:Label>
                                    <asp:Label ID="Label11" runat="server"></asp:Label>
                                </div>

                                <div class="col-md-12">
                                    <div class="table-responsive table-container">
                                        <asp:GridView GridLines="None" ID="gvStatus" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="data-table table table-striped border text-nowrap table-sm"
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
                                                <%--<asp:ButtonField ButtonType="Image" CommandName="SelectStatus" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />--%>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit3" runat="server" CommandName="SelectStatus" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Edit">
                                                <i class="fa-solid fa-edit"></i>
                                                </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete3" runat="server" CommandName="DeleteEx" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                                <i class="fa-solid fa-xmark text-danger"></i> 
                                                </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>



                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="ddlRequestType" />
                    <asp:PostBackTrigger ControlID="ImgBtnExport3" />
                    <asp:PostBackTrigger ControlID="gvStatus" />
                    <asp:PostBackTrigger ControlID="ddlOrg3" />
                    <asp:PostBackTrigger ControlID="ddlRequestTypeStatus" />
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

                    <div class="card mb-1" style="border-radius: 0 0 0.375rem 0.375rem">
                        <div class="card-body">
                            <h6 class="mb-3 fw-bold">Add Severtiy</h6>
                            <div class="row gx-2 gy-3">
                                <div class="col-md-3">
                                    <label for="staticEmail" class="form-label">
                                        Organization
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlOrg4" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlOrg4" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg4_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <label for="staticEmail" class="form-label">
                                        Request Type
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlRequestTypeSeverity" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity"></asp:RequiredFieldValidator>
                                    </label>


                                    <asp:DropDownList ID="ddlRequestTypeSeverity" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestTypeSeverity_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <label for="staticEmail" class="form-label">
                                        Severity Name
                                            <asp:RequiredFieldValidator ID="rfvtxtSeverityName" runat="server" ControlToValidate="txtSeverityName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity" onkeypress="return /^[a-zA-Z0-9\s]*$/.test(event.key) && this.value.length < 20;" MaxLength="20"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtSeverityName" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label for="staticEmail" class="form-label">
                                        Response Time(in Min)
                                            <asp:RequiredFieldValidator ID="rfvtxtResponseTime" runat="server" ControlToValidate="txtResponseTime" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity"></asp:RequiredFieldValidator>
                                    </label>


                                    <asp:TextBox ID="txtResponseTime" runat="server" CssClass="form-control  form-control-sm" TextMode="Number"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label for="staticEmail" class="form-label">
                                        Resolution Time(in Min) 
                                            <asp:RequiredFieldValidator ID="rfvtxtResolutionTime" runat="server" ControlToValidate="txtResolutionTime" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtResolutionTime" runat="server" CssClass="form-control  form-control-sm" TextMode="Number"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <label for="staticEmail" class="form-label">
                                        Severity Description 
                                            <asp:RequiredFieldValidator ID="rfvSeverityDesc" runat="server" ControlToValidate="txtSeverityDescription" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Severity"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtSeverityDescription" runat="server" TextMode="MultiLine" Rows="3" Columns="3" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                    <asp:Button ID="btnInsertSeverity" runat="server" Text="Save" class="btn btn-sm btn-grd btn-grd-info " OnClick="btnInsertSeverity_Click" ValidationGroup="Severity" />
                                    <asp:Button ID="btnUpdateSeverity" runat="server" Text="Update" Visible="false" class="btn btn-sm btn-grd btn-grd-info " OnClick="btnUpdateSeverity_Click" ValidationGroup="Severity" />
                                    <asp:Button ID="btnCancel5" runat="server" Text="Cancel" class="btn btn-sm btn-grd btn-grd-danger " OnClick="btnCancel5_Click" CausesValidation="false" />
                                </div>
                                <div class="col-6 text-end">
                                    <asp:LinkButton class="btn btn-grd-info btn-sm" ID="lnkPrevStatus" runat="server" OnClick="lnkPrevStatus_Click">Previous</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-grd-primary btn-sm" ID="lnkNextPriority" runat="server" OnClick="lnkNextPriority_Click">Next</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="card ">
                        <div class="card-body">
                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <div class="">
                                    <h6 class="mb-0">
                                        <asp:Label ID="Label12" runat="server" Text="Severity Details"></asp:Label>
                                    </h6>
                                </div>
                                <asp:LinkButton ID="ImgBtnExport4" runat="server" CssClass="btn btn-sm btn-outline-secondary" OnClick="ImgBtnExport4_Click">Export <i class="fa-solid fa-download"></i></asp:LinkButton>


                            </div>
                            <div class="row ">

                                <div class="col-md-6">
                                    <asp:Label ID="Label13" runat="server"></asp:Label>
                                    <asp:Label ID="Label14" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <div class="table-responsive table-container">
                                        <asp:GridView GridLines="None" ID="gvSeverity" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="data-table table table-striped border table-sm text-nowrap "
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
                                                <%-- <asp:ButtonField ButtonType="Image" CommandName="SelectSeverity" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />--%>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit4" runat="server" CommandName="SelectSeverity" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Edit">
                                                     <i class="fa-solid fa-edit"></i>
                                                     </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete4" runat="server" CommandName="DeleteEx" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                                     <i class="fa-solid fa-xmark text-danger"></i> 
                                                     </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>



                </ContentTemplate>

                <Triggers>
                    <asp:PostBackTrigger ControlID="ImgBtnExport" />
                    <asp:PostBackTrigger ControlID="ddlRequestTypeSeverity" />
                    <asp:PostBackTrigger ControlID="gvSeverity" />
                    <asp:PostBackTrigger ControlID="ddlOrg4" />
                    <asp:PostBackTrigger ControlID="lnkPrevStatus" />
                    <asp:PostBackTrigger ControlID="lnkNextPriority" />
                    <asp:PostBackTrigger ControlID="ImgBtnExport4" />
                </Triggers>

            </asp:UpdatePanel>
        </asp:Panel>
        <%--Add Severity End--%>

        <%--Add Priority Start--%>
        <asp:Panel ID="pnlAddPriority" runat="server" Visible="false">
            <asp:UpdatePanel ID="updatepanel6" runat="server">
                <ContentTemplate>

                    <div class="card mb-1" style="border-radius: 0 0 0.375rem 0.375rem">
                        <div class="card-body">
                            <h6 class="mb-3 fw-bold">Add Priority</h6>
                            <div class="row gx-2 gy-3 ">
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Organization
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlOrg5" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlOrg5" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg5_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Request Type
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlRequestTypePriority" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlRequestTypePriority" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestTypePriority_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Priority Name 
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtpriority" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtpriority" runat="server" CssClass="form-control  form-control-sm" onkeypress="return /^[a-zA-Z\s]*$/.test(event.key) && this.value.length < 20;" MaxLength="20"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <label for="staticEmail" class="form-label">
                                        Priority Description
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPriorityDescription" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Priority"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtPriorityDescription" runat="server" TextMode="MultiLine" Rows="5" Columns="5" CssClass="form-control  form-control-sm" MaxLength="1000"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                    <asp:Button ID="btnInsertPriority" runat="server" Text="Save" class="btn btn-sm btn-grd-info" OnClick="btnInsertPriority_Click" ValidationGroup="Priority" />
                                    <asp:Button ID="btnUpdatePriority" runat="server" Text="Update" Visible="false" class="btn btn-sm  btn-grd-info" OnClick="btnUpdatePriority_Click" ValidationGroup="Priority" />
                                    <asp:Button ID="btnCancel6" runat="server" Text="Cancel" class="btn btn-sm  btn-grd-danger" OnClick="btnCancel6_Click" CausesValidation="false" />
                                </div>
                                <div class="col-6 text-end">
                                    <asp:LinkButton class="btn btn-grd-info btn-sm" ID="lnkPreviousSeverity" runat="server" OnClick="lnkPreviousSeverity_Click">Previous</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-grd-primary btn-sm" ID="lnkNextCategory" runat="server" OnClick="lnkNextCategory_Click">Next</asp:LinkButton>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="card ">
                        <div class="card-body">

                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <div class="">
                                    <h6 class="mb-0">
                                        <asp:Label ID="Label15" runat="server" Text="Priority Details"></asp:Label>
                                    </h6>
                                </div>

                                <asp:LinkButton ID="ImgBtnExport7" runat="server" CssClass="btn btn-sm btn-outline-secondary" OnClick="ImgBtnExport7_Click">Export <i class="fa-solid fa-download"></i></asp:LinkButton>
                            </div>

                            <div class="row ">
                                <div class="col-md-12">
                                    <asp:GridView GridLines="None" ID="gvPriority" runat="server" DataKeyNames="PriorityRef" AutoGenerateColumns="false" CssClass="data-table table table-striped border text-nowrap table-sm"
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
                                            <%-- <asp:ButtonField ButtonType="Image" CommandName="SelectState" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                            <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />--%>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit5" runat="server" CommandName="SelectState" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Edit">
                                                 <i class="fa-solid fa-edit"></i>
                                                 </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete5" runat="server" CommandName="DeleteEx" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                             <i class="fa-solid fa-xmark text-danger"></i> 
                                             </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

                        </div>
                    </div>



                </ContentTemplate>

                <Triggers>
                    <asp:PostBackTrigger ControlID="ImgBtnExport7" />
                    <asp:PostBackTrigger ControlID="ddlRequestTypePriority" />
                    <asp:PostBackTrigger ControlID="gvPriority" />
                    <asp:PostBackTrigger ControlID="ddlOrg5" />
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

                    <div class="card mb-3">
                        <div class="card-body">
                            <h6 class="mb-3 fw-bold">Add Categroy</h6>

                            <div class="row gy-3 gx-2">
                                <div class="col-md-4 ">
                                    <label class="form-label ">
                                        Organization

                                    </label>
                                    <asp:DropDownList ID="ddlOrg6" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="ddlOrg6_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label class="form-label">
                                        Request Type
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlRequestType" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlRequestTypeCategory" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestTypeCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-4">
                                    <label class="form-label">
                                        Category
           <asp:ImageButton ID="imgbtnAddParentCategory" runat="server" ImageUrl="~/Images/plus.png" ToolTip="Add Category" OnClick="imgbtnAddParentCategory_Click" />
                                        <asp:ImageButton ID="imgbtnSaveParentCategory" runat="server" ImageUrl="~/Images/save.png" ToolTip="Save Category" OnClick="imgbtnSaveParentCategory_Click" ValidationGroup="SaveCatI" Enabled="false" />
                                        <asp:ImageButton ID="imgbtnUpdateParentCategory" runat="server" ImageUrl="~/Images/update.png" ToolTip="Update Category" OnClick="imgbtnUpdateParentCategory_Click" ValidationGroup="SaveCatI" Visible="false" />
                                        <asp:ImageButton ID="imgbtnEditParentCategory" runat="server" ImageUrl="~/Images/edit23.png" Width="16" Height="16" ToolTip="Edit Category" OnClick="imgbtnEditParentCategory_Click" />
                                        <asp:ImageButton ID="imgbtnCancelParent" runat="server" Enabled="false" ImageUrl="~/Images/reset1.png" Width="16" Height="16" ToolTip="Add Category" OnClick="imgbtnCancelParent_Click" />
                                        <asp:RequiredFieldValidator ID="rfvtxtParentCategory" runat="server" ControlToValidate="txtParentCategory" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SaveCatI"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rfvddlParentCategory" runat="server" ControlToValidate="ddlParentCategory" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddCatII"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtParentCategory" runat="server" CssClass="form-control  form-control-sm" ToolTip="Add Category" Visible="false" onkeypress="return /^[a-zA-Z0-9\s]*$/.test(event.key) && this.value.length < 50;"></asp:TextBox>
                                    <asp:DropDownList ID="ddlParentCategory" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlParentCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-4">
                                    <label class="form-label">
                                        Category II
           <asp:ImageButton ID="imgbtnCatII" runat="server" ImageUrl="~/Images/plus.png" OnClick="imgbtnCatII_Click" ValidationGroup="AddCatII" />
                                        <asp:ImageButton ID="imgbtnSaveCatII" runat="server" ImageUrl="~/Images/save.png" ToolTip="Save Category" OnClick="imgbtnSaveCatII_Click" ValidationGroup="SaveCatII" Enabled="false" />
                                        <asp:ImageButton ID="imtbtnUpdateCatII" runat="server" ImageUrl="~/Images/update.png" ToolTip="Update Category" OnClick="imtbtnUpdateCatII_Click" ValidationGroup="SaveCatII" Visible="false" />
                                        <asp:ImageButton ID="imgbtnEditCatII" runat="server" ImageUrl="~/Images/edit23.png" Width="16" Height="16" ToolTip="Edit Category" OnClick="imgbtnEditCatII_Click" />
                                        <asp:ImageButton ID="imgbtnCancelCatII" runat="server" ImageUrl="~/Images/reset1.png" Width="16" Height="16" ToolTip="Add Category" OnClick="imgbtnCancelCatII_Click" />
                                        <asp:RequiredFieldValidator ID="rfvtxtCatII" runat="server" ControlToValidate="txtCatII" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SaveCatII"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rfvddlCatII" runat="server" ControlToValidate="ddlCatII" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddCatIII"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtCatII" runat="server" CssClass="form-control  form-control-sm" ValidationGroup="SaveCatII" Visible="false" onkeypress="return /^[a-zA-Z0-9\s]*$/.test(event.key) && this.value.length < 50;"></asp:TextBox>
                                    <asp:DropDownList ID="ddlCatII" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlCatII_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-4">
                                    <label class="form-label">
                                        Category III
           <asp:ImageButton ID="imgAddCatIII" runat="server" ImageUrl="~/Images/plus.png" OnClick="imgAddCatIII_Click" ValidationGroup="AddCatIII" />
                                        <asp:ImageButton ID="imgSaveCatIII" runat="server" ImageUrl="~/Images/save.png" OnClick="imgSaveCatIII_Click" ValidationGroup="SaveCatIII" Enabled="false" />
                                        <asp:ImageButton ID="imgbtnUpdateCatIII" runat="server" ImageUrl="~/Images/update.png" ToolTip="Update Category" OnClick="imgbtnUpdateCatIII_Click" ValidationGroup="SaveCatIII" Visible="false" />
                                        <asp:ImageButton ID="imgbtnEditCatIII" runat="server" ImageUrl="~/Images/edit23.png" Width="16" Height="16" ToolTip="Edit Category" OnClick="imgbtnEditCatIII_Click" />
                                        <asp:ImageButton ID="imgbtnCancelCatIII" runat="server" Enabled="false" ImageUrl="~/Images/reset1.png" Width="16" Height="16" ToolTip="Add Category" OnClick="imgbtnCancelCatIII_Click" />
                                        <asp:RequiredFieldValidator ID="rfvtxtCatLevelIII" runat="server" ControlToValidate="txtCatLevelIII" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SaveCatIII"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rfvddlCateLevelIII" runat="server" ControlToValidate="ddlCateLevelIII" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddCatIV"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtCatLevelIII" runat="server" CssClass="form-control  form-control-sm" ValidationGroup="SaveCatIII" Visible="false" onkeypress="return /^[a-zA-Z0-9\s]*$/.test(event.key) && this.value.length < 50;"></asp:TextBox>
                                    <asp:DropDownList ID="ddlCateLevelIII" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlCateLevelIII_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-4">
                                    <label class="form-label">
                                        Category IV
           <asp:ImageButton ID="imgbtnCatelevelIV" runat="server" ImageUrl="~/Images/plus.png" OnClick="imgbtnCatelevelIV_Click" ValidationGroup="AddCatIV" />
                                        <asp:ImageButton ID="imgbtnSaveCateLvlIV" runat="server" ImageUrl="~/Images/save.png" OnClick="imgbtnSaveCateLvlIV_Click" ValidationGroup="SaveCatIV" Enabled="false" />
                                        <asp:ImageButton ID="imgbtnUpdateCateLvIV" runat="server" ImageUrl="~/Images/update.png" ToolTip="Update Category" OnClick="imgbtnUpdateCateLvIV_Click" ValidationGroup="SaveCatIV" Visible="false" />
                                        <asp:ImageButton ID="imgbtnEditCatLvIV" runat="server" ImageUrl="~/Images/edit23.png" Width="16" Height="16" ToolTip="Edit Category" OnClick="imgbtnEditCatLvIV_Click" />
                                        <asp:ImageButton ID="imgbtnCancelCatIV" runat="server" Enabled="false" ImageUrl="~/Images/reset1.png" Width="16" Height="16" ToolTip="Add Category" OnClick="imgbtnCancelCatIV_Click" />
                                        <asp:RequiredFieldValidator ID="rfvtxtCateLevelIV" runat="server" ControlToValidate="txtCateLevelIV" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SaveCatIV"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rfvddlCateLevelIV" runat="server" ControlToValidate="ddlCateLevelIV" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="AddCatV"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtCateLevelIV" runat="server" CssClass="form-control  form-control-sm" ValidationGroup="SaveCatIV" Visible="false" onkeypress="return /^[a-zA-Z0-9\s]*$/.test(event.key) && this.value.length < 50;"></asp:TextBox>
                                    <asp:DropDownList ID="ddlCateLevelIV" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlCateLevelIV_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-4">

                                    <label class="form-label">
                                        Category V
           <asp:ImageButton ID="imgbtnAddCatV" runat="server" ImageUrl="~/Images/plus.png" OnClick="imgbtnAddCatV_Click" ValidationGroup="AddCatV" />
                                        <asp:ImageButton ID="imgbtnSaveCatV" runat="server" ImageUrl="~/Images/save.png" OnClick="imgbtnSaveCatV_Click" ValidationGroup="SaveCatV" Enabled="false" />
                                        <asp:ImageButton ID="imgbtnUpdateCatV" runat="server" ImageUrl="~/Images/update.png" ToolTip="Update Category" OnClick="imgbtnUpdateCatV_Click" ValidationGroup="SaveCatV" Visible="false" />
                                        <asp:ImageButton ID="imgbtnEditCatV" runat="server" ImageUrl="~/Images/edit23.png" Width="16" Height="16" ToolTip="Edit Category" OnClick="imgbtnEditCatV_Click" />
                                        <asp:ImageButton ID="imgbtnCancelCatV" runat="server" ImageUrl="~/Images/reset1.png" Width="16" Height="16" ToolTip="Add Category" OnClick="imgbtnCancelCatV_Click" />
                                        <asp:RequiredFieldValidator ID="rfvtxtCatV" runat="server" ControlToValidate="txtCatV" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SaveCatV"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtCatV" runat="server" CssClass="form-control  form-control-sm" ValidationGroup="SaveCatV" Visible="false" onkeypress="return /^[a-zA-Z0-9\s]*$/.test(event.key) && this.value.length < 50;"></asp:TextBox>
                                    <asp:DropDownList ID="ddlCatV" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" Enabled="false">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 text-end">
                                    <label class="form-label" style="color: transparent">.</label><br />
                                    <asp:LinkButton class="btn btn-grd-info btn-sm" ID="lnkPreviousPriority" runat="server" OnClick="lnkPreviousPriority_Click">Previous</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-grd-primary btn-sm" ID="lnkNextEmailConfig" runat="server" OnClick="lnkNextEmailConfig_Click">Next</asp:LinkButton>
                                </div>
                            </div>

                            <div class="form-row d-none">
                                <div class="col-md-2 offset-10 ">
                                    <asp:Button ID="btnClose7" runat="server" Text="Close" class="btn btn-danger" OnClick="btnClose7_Click" />
                                </div>
                            </div>
                        </div>
                    </div>


                    <asp:HiddenField ID="hdnVarCategoryI" runat="server" />
                    <asp:HiddenField ID="hdnVarCategoryII" runat="server" />
                    <asp:HiddenField ID="hdnVarCategoryIII" runat="server" />
                    <asp:HiddenField ID="hdnVarCategoryIV" runat="server" />
                    <asp:HiddenField ID="hdnVarCategoryV" runat="server" />
                </ContentTemplate>

                <Triggers>
                    <asp:PostBackTrigger ControlID="ddlOrg6" />
                    <%--Parent Controls  Category I Controls--%>
                    <asp:PostBackTrigger ControlID="ddlParentCategory" />
                    <asp:PostBackTrigger ControlID="imgbtnAddParentCategory" />
                    <%--<asp:PostBackTrigger ControlID="imgbtnSaveParentCategory" />--%>
                    <asp:PostBackTrigger ControlID="imgbtnEditParentCategory" />
                    <asp:PostBackTrigger ControlID="imgbtnCancelParent" />
                    <%--Parent Controls  Category II Controls--%>
                    <asp:PostBackTrigger ControlID="ddlCatII" />
                    <asp:PostBackTrigger ControlID="imgbtnCatII" />
                    <%--<asp:PostBackTrigger ControlID="imgbtnSaveCatII" />--%>
                    <asp:PostBackTrigger ControlID="imgbtnEditCatII" />
                    <asp:PostBackTrigger ControlID="imgbtnCancelCatII" />
                    <%--Parent Controls  Category III Controls--%>
                    <asp:PostBackTrigger ControlID="ddlCateLevelIII" />
                    <asp:PostBackTrigger ControlID="imgAddCatIII" />
                    <%--<asp:PostBackTrigger ControlID="imgSaveCatIII" />--%>
                    <asp:PostBackTrigger ControlID="imgbtnEditCatIII" />
                    <asp:PostBackTrigger ControlID="imgbtnCancelCatIII" />

                    <%--Parent Controls  Category IV Controls--%>
                    <asp:PostBackTrigger ControlID="ddlCateLevelIV" />
                    <asp:PostBackTrigger ControlID="imgbtnCatelevelIV" />
                    <%--<asp:PostBackTrigger ControlID="imgbtnSaveCateLvlIV" />--%>
                    <asp:PostBackTrigger ControlID="imgbtnEditCatLvIV" />
                    <asp:PostBackTrigger ControlID="imgbtnCancelCatIV" />
                    <%--Parent Controls  Category V Controls--%>

                    <asp:PostBackTrigger ControlID="imgbtnAddCatV" />
                    <asp:PostBackTrigger ControlID="imgbtnSaveCatV" />
                    <asp:PostBackTrigger ControlID="imgbtnEditCatV" />
                    <asp:PostBackTrigger ControlID="imgbtnCancelCatV" />
                    <asp:PostBackTrigger ControlID="lnkPreviousPriority" />
                    <asp:PostBackTrigger ControlID="lnkNextEmailConfig" />
                    <asp:PostBackTrigger ControlID="ddlRequestTypeCategory" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
        <%--Add Category End--%>

        <%--Add Email Config Start--%>
        <asp:Panel ID="pnlAddEmailConfig" runat="server" Visible="false">
            <asp:UpdatePanel ID="updatepanel8" runat="server">
                <ContentTemplate>

                    <div class="card mb-1" style="border-radius: 0 0 0.375rem 0.375rem">
                        <div class="card-body">
                            <h6 class="fw-bold mb-3">Email Configuration</h6>
                            <div class="row gx-2 gy-3">
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Host Name
                                    <asp:RequiredFieldValidator ID="rfvtxtHostName" runat="server" ControlToValidate="txtHostName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtHostName" runat="server" CssClass="form-control  form-control-sm" MaxLength="200"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Port
                                    <asp:RequiredFieldValidator ID="rfvtxtPort" runat="server" ControlToValidate="txtPort" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtPort" runat="server" TextMode="Number" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        User Name
                                    <asp:RequiredFieldValidator ID="rfvtxtUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control  form-control-sm" MaxLength="200"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Password 
                                    <asp:RequiredFieldValidator ID="rfvtxtPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control  form-control-sm" autocomplete="new-password"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Sender Email
                                    <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Retry Interval 
                                    <asp:RequiredFieldValidator ID="rfvtxtRetry" runat="server" ControlToValidate="txtRetry" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtRetry" runat="server" TextMode="Number" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>

                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Client ID
                                    <asp:RequiredFieldValidator ID="rfvtxtClientID" runat="server" ControlToValidate="txtClientID" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtClientID" runat="server" TextMode="MultiLine" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Client Secret Key 
                                    <asp:RequiredFieldValidator ID="rfvtxtClientSecretKey" runat="server" ControlToValidate="txtClientSecretKey" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtClientSecretKey" runat="server" TextMode="MultiLine" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Tenant ID
                                    <asp:RequiredFieldValidator ID="rfvtxtTenantID" runat="server" ControlToValidate="txtTenantID" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtTenantID" runat="server" TextMode="MultiLine" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Organization
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlOrgEmailConfig" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="EmailConfig"></asp:RequiredFieldValidator>
                                    </label>


                                    <asp:DropDownList ID="ddlOrgEmailConfig" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-8 text-end">
                                    <label class="form-label"></label>
                                    <br />
                                    <asp:Button ID="btnInsertEmailConfig" runat="server" Text="Save" class="btn btn-sm btn-grd-info" OnClick="btnInsertEmailConfig_Click" ValidationGroup="EmailConfig" />
                                    <asp:Button ID="btnUpdateEmailConfig" runat="server" Text="Update" Visible="false" class="btn btn-sm btn-grd-info" OnClick="btnUpdateEmailConfig_Click" ValidationGroup="EmailConfig" />
                                    <asp:Button ID="btnCancel8" runat="server" Text="Cancel" class="btn btn-sm btn-grd-danger" OnClick="btnCancel8_Click" CausesValidation="false" />
                                    <asp:LinkButton class="btn btn-grd-info btn-sm" ID="lnkPreviousCategory" runat="server" OnClick="lnkPreviousCategory_Click">Previous</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-grd-primary btn-sm" ID="lnkNextResolution" runat="server" OnClick="lnkNextResolution_Click">Next</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="card">
                        <div class="card-body">
                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <div class="">
                                    <h6 class="mb-0">
                                        <asp:Label ID="Label18" runat="server" Text="EmailConfig Details"></asp:Label>
                                    </h6>
                                </div>

                                <asp:LinkButton ID="ImgBtnExport8" runat="server" CssClass="btn btn-sm btn-outline-secondary" OnClick="ImgBtnExport8_Click">Export <i class="fa-solid fa-download"></i></asp:LinkButton>
                            </div>
                            <div class="row ">
                                <div class="col-md-12">
                                    <div class="table-responsive table-container">
                                        <asp:GridView GridLines="None" ID="gvEmailConfig" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="data-table table table-striped border table-sm text-nowrap"
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
                                                <%-- <asp:ButtonField ButtonType="Image" CommandName="UpdateEmailConfig" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEmailConfig" ItemStyle-Width="20px" ItemStyle-Height="5px" />--%>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit11" runat="server" CommandName="UpdateEmailConfig" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Edit">
                                                        <i class="fa-solid fa-edit"></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete11" runat="server" CommandName="DeleteEmailConfig" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                                        <i class="fa-solid fa-xmark text-danger"></i> 
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                </div>


                            </div>
                        </div>
                    </div>


                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="ImgBtnExport" />
                    <asp:PostBackTrigger ControlID="gvEmailConfig" />
                    <asp:PostBackTrigger ControlID="lnkPreviousCategory" />
                    <asp:PostBackTrigger ControlID="lnkNextResolution" />
                    <asp:PostBackTrigger ControlID="ImgBtnExport8" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
        <%--Add Email Config End--%>

        <%--Add Resolution Start--%>
        <asp:Panel ID="pnlAddResolution" runat="server" Visible="false">
            <asp:UpdatePanel ID="updatepanel9" runat="server">
                <ContentTemplate>

                    <div class="card mb-1" style="border-radius: 0 0 0.375rem 0.375rem">
                        <div class="card-body">
                            <h6 class="fw-bold mb-3">Add Resolution</h6>
                            <div class="row gx-2 gy-3">
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Organization
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlOrgResolution" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Resol"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlOrgResolution" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrgResolution_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Request Type
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlRequestTypeResolution" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Resol"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlRequestTypeResolution" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Resolution Name
                                            <asp:RequiredFieldValidator ID="rfvtxtResolution" runat="server" ControlToValidate="txtResolution" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Resol"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox onkeypress="return /^[a-zA-Z\s]*$/.test(event.key) && this.value.length < 50;" MaxLength="50"
                                        ID="txtResolution" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <label for="staticEmail" class="form-label">
                                        Resolution Description 
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtResolutnDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Resol"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtResolutnDesc" MaxLength="1000" runat="server" TextMode="MultiLine" Rows="5" Columns="5" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                    <asp:Button ID="btnInsertResolution" runat="server" Text="Save" class="btn btn-sm btn-grd-info" OnClick="btnInsertResolution_Click" ValidationGroup="Resol" />
                                    <asp:Button ID="btnUpdateResolution" runat="server" Text="Update" Visible="false" class="btn btn-sm btn-grd-info" OnClick="btnUpdateResolution_Click" ValidationGroup="Resol" />
                                    <asp:Button ID="btnCancel9" runat="server" Text="Cancel" class="btn btn-sm btn-grd-danger" OnClick="btnCancel9_Click" CausesValidation="false" />
                                </div>
                                <div class="col-6 text-end">
                                    <asp:LinkButton class="btn btn-grd-info btn-sm" ID="lnkPreviousEmailConfig" runat="server" OnClick="lnkPreviousEmailConfig_Click">Previous</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-grd-primary btn-sm" ID="lnkNextSLA" runat="server" OnClick="lnkNextSLA_Click">Next</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card ">
                        <div class="card-body">
                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <div class="">
                                    <h6 class="mb-0">
                                        <asp:Label ID="Label21" runat="server" Text="Resolution Details"></asp:Label>
                                    </h6>
                                </div>

                                <asp:LinkButton ID="ImgBtnExport9" runat="server" CssClass="btn btn-sm btn-outline-secondary" OnClick="ImgBtnExport9_Click">Export <i class="fa-solid fa-download"></i></asp:LinkButton>
                            </div>

                            <div class="row ">
                                <div class="col-md-12">
                                    <div class="table-responsive table-container">
                                        <asp:GridView GridLines="None" ID="gvResolution" runat="server" DataKeyNames="ResolutionRef" AutoGenerateColumns="false" CssClass="table border table-sm table-striped text-nowrap"
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
                                                <%-- <asp:ButtonField ButtonType="Image" CommandName="SelectState" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />--%>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit7" runat="server" CommandName="SelectState" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Edit">
                                                        <i class="fa-solid fa-edit"></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete8" runat="server" CommandName="DeleteEx" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                                        <i class="fa-solid fa-xmark text-danger"></i> 
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
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
                    <asp:PostBackTrigger ControlID="gvResolution" />
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

                    <div class="card mb-1" style="border-radius: 0 0 0.375rem 0.375rem">
                        <div class="card-body">
                            <h6
                                class="mb-0 fw-bold">Add SLA</h6>
                            <div class="row gx-2 gy-3">
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Organization
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlOrgSLA" ErrorMessage="*" Font-Bold="true" InitialValue="0" ForeColor="Red" ValidationGroup="SLA"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlOrgSLA" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        SLA Name
                                            <asp:RequiredFieldValidator ID="rfvtxtSLAName" runat="server" ControlToValidate="txtSLAName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SLA"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtSLAName" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        SLA Description
                                            <asp:RequiredFieldValidator ID="rfvtxtSLADescription" runat="server" ControlToValidate="txtSLADescription" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SLA"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtSLADescription" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                    <asp:Button ID="btnInsertSLA" runat="server" Text="Save" class="btn btn-sm btn-grd-info" OnClick="btnInsertSLA_Click" ValidationGroup="SLA" />
                                    <asp:Button ID="btnUpdateSLA" runat="server" Text="Update" Visible="false" class="btn btn-sm btn-grd-info" OnClick="btnUpdateSLA_Click" ValidationGroup="SLA" />
                                    <asp:Button ID="btnCancel10" runat="server" Text="Cancel" class="btn btn-sm btn-grd-danger" OnClick="btnCancel10_Click" CausesValidation="false" />
                                </div>
                                <div class="col-6 text-end">
                                    <asp:LinkButton class="btn btn-grd-info btn-sm" ID="lnkPreviousResolution" runat="server" OnClick="lnkPreviousResolution_Click">Previous</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-grd-primary btn-sm" ID="lnkNextDeskConfig" runat="server" OnClick="lnkNextDeskConfig_Click">Next</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card">

                        <div class="card-body">
                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <div class="">
                                    <h6 class="mb-0">Add Details</h6>
                                </div>

                                <asp:LinkButton ID="ImgBtnExport10" CssClass="btn btn-sm btn-outline-secondary" runat="server" OnClick="ImgBtnExport10_Click">Export <i class="fa-solid fa-download"></i></asp:LinkButton>
                            </div>

                            <div class="row ">
                                <div class="col-md-12">
                                    <div class="table-responsive table-container">

                                        <asp:GridView GridLines="None" ID="gvSLA" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-head-fixed text-nowrap text-nowrap table-sm table-striped border"
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
                                                <%-- <asp:ButtonField ButtonType="Image" CommandName="UpdateSLA" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteSLA" ItemStyle-Width="20px" ItemStyle-Height="5px" />--%>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit8" runat="server" CommandName="UpdateSLA" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Edit">
                                                    <i class="fa-solid fa-edit"></i>
                                                    </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete9" runat="server" CommandName="DeleteSLA" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                                  <i class="fa-solid fa-xmark text-danger"></i> 
                                                  </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>



                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="ImgBtnExport10" />
                    <asp:PostBackTrigger ControlID="gvSLA" />
                    <asp:PostBackTrigger ControlID="lnkPreviousResolution" />
                    <asp:PostBackTrigger ControlID="lnkNextDeskConfig" />
                </Triggers>

            </asp:UpdatePanel>
        </asp:Panel>
        <%--Add SLA End--%>

        <%--Add DeskConfig Start--%>
        <asp:Panel ID="pnlAdddeskConfig" runat="server" Visible="false">
            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>

                    <div class="card mb-1" style="border-radius: 0 0 0.375rem 0.375rem">
                        <div class="card-body">
                            <h6 class="mb-3 fw-bold">Desk Template</h6>
                            <asp:Literal ID="ltlCount" runat="server" Text="0" Visible="false" />
                            <asp:Literal ID="ltlRemoved" runat="server" Visible="false" />
                            <div class="row gx-2 gy-3">
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Organization
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlOrgDeskConfig" ErrorMessage="Required" ForeColor="Red" InitialValue="0" ValidationGroup="www"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlOrgDeskConfig" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrgDeskConfig_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Request Type
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlRequestTypeDeskConfig" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="www"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlRequestTypeDeskConfig" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestTypeDeskConfig_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Service PreFix 
                                    <asp:RequiredFieldValidator ID="rfvtxtSDPrefix" runat="server" ControlToValidate="txtSDPrefix" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="www"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtSDPrefix" runat="server" MaxLength="4" CssClass="form-control  form-control-sm" onkeypress="return /^[a-zA-Z]*$/.test(event.key) && this.value.length < 4;"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Service Desk Description :
                                        <asp:RequiredFieldValidator ID="rfvtxtSDDescription" runat="server" ControlToValidate="txtSDDescription" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="www"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtSDDescription" runat="server" TextMode="MultiLine" Rows="1" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Archive Time(in Days)
                                    <asp:RequiredFieldValidator ID="rfvtxtArchiveTime" runat="server" ControlToValidate="txtArchiveTime" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="www"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtArchiveTime" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Severity 
                                                <asp:RequiredFieldValidator ID="RfvddlSeverity" runat="server" ControlToValidate="ddlSeverity" ErrorMessage="Required" ForeColor="Red" InitialValue="0" ValidationGroup="www" Enabled="false"></asp:RequiredFieldValidator>
                                        &nbsp;</label>

                                    <asp:DropDownList ID="ddlSeverity" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        <asp:Label ID="lblSolution" runat="server" Text="Solution Type :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RfvddlSolutionType" runat="server" ControlToValidate="ddlSolutionType" ErrorMessage="Required" ForeColor="Red" InitialValue="0" ValidationGroup="www"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlSolutionType" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Priority 
                                                <asp:RequiredFieldValidator ID="rfvddlPriority" runat="server" ControlToValidate="ddlPriority" ErrorMessage="Required" ForeColor="Red" InitialValue="0" ValidationGroup="www"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Coverage Schedule
								<asp:RequiredFieldValidator ID="rfvddlCoverageSch" runat="server" ControlToValidate="ddlCoverageSch" ErrorMessage="Required" ForeColor="Red" InitialValue="0" ValidationGroup="www"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlCoverageSch" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Stage 
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="ddlStageDeskConfig" ErrorMessage="Required" ForeColor="Red" InitialValue="0" ValidationGroup="www"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlStageDeskConfig" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlStageDeskConfig_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Status
                                                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Required" ForeColor="Red" InitialValue="0" ValidationGroup="www"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        <asp:Label ID="lblCategory1" runat="server" Text="Category 1"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RfvddlCategory1" runat="server" ControlToValidate="ddlCategory1" ValidationGroup="www" ForeColor="Red" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlCategory1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory1_SelectedIndexChanged" CssClass="form-control form-control-sm single-select-optgroup-field"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        SLA 
					   <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="ddlSlA" ErrorMessage="Required" ForeColor="Red" InitialValue="0" ValidationGroup="www"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlSlA" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        <asp:Label ID="lblCategory2" runat="server" Text="Category 2 "></asp:Label>
                                        <asp:RequiredFieldValidator ID="RfvddlCategory2" runat="server" InitialValue="0" ControlToValidate="ddlCategory2" ValidationGroup="www" ForeColor="Red" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlCategory2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory2_SelectedIndexChanged" CssClass="form-control form-control-sm single-select-optgroup-field"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        <asp:Label ID="lblCategory3" runat="server" Text="Category 3"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RfvddlCategory3" runat="server" InitialValue="0" ControlToValidate="ddlCategory3" ValidationGroup="www" ForeColor="Red" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlCategory3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory3_SelectedIndexChanged" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        <asp:Label ID="lblCategory4" runat="server" Text="Category 4"></asp:Label>
                                    </label>

                                    <asp:DropDownList ID="ddlCategory4" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory4_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        <asp:Label ID="lblCategory5" runat="server" Text="Category 5"></asp:Label>
                                    </label>

                                    <asp:DropDownList ID="ddlCategory5" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="col-md-8 text-end">
                                    <label class="form-label"></label>
                                    <br />
                                    <asp:Button ID="btnInsert" runat="server" Text="Save" class="btn btn-sm btn-grd-info" OnClick="btnInsert_Click" ValidationGroup="www" />
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-sm btn-grd-info" OnClick="btnUpdate_Click" ValidationGroup="wwww" Visible="False" />
                                    <asp:Button ID="btnCancel11" runat="server" Text="Cancel" class="btn btn-sm btn-grd-danger" OnClick="btnCancel11_Click" CausesValidation="false" />
                                    <asp:LinkButton class="btn btn-grd-info btn-sm" ID="lnkPreviousSLA" runat="server" OnClick="lnkPreviousSLA_Click">Previous</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-grd-primary btn-sm" ID="lnkNextCustomFields" runat="server" OnClick="lnkNextCustomFields_Click">Next</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card">
                        <div class="card-body">
                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <div class="">
                                    <h6 class="mb-0">
                                        <asp:Label ID="Label19" runat="server" Text="Desk Details"></asp:Label>
                                    </h6>
                                </div>
                                <asp:LinkButton ID="ImgBtnExport12" runat="server" CssClass="btn btn-sm btn-outline-secondary" OnClick="ImgBtnExport12_Click">Export <i class="fa-solid fa-download"></i></asp:LinkButton>

                            </div>

                            <div class="row ">
                                <div class="col-md-12">
                                    <div class="table-responsive table-container">
                                        <asp:GridView GridLines="None" ID="gvDesk" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-sm table-striped text-nowrap"
                                            Width="100%" OnRowCommand="gvDesk_RowCommand" OnRowDataBound="gvDesk_RowDataBound">
                                            <Columns>
                                                <%--<asp:ButtonField ButtonType="Image" CommandName="EditDesk" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />--%>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit9" runat="server" CommandName="EditDesk" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Edit">
                                                        <i class="fa-solid fa-edit"></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete10" runat="server" CommandName="DeleteEx" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                                        <i class="fa-solid fa-xmark text-danger"></i> 
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="TemplateName" HeaderText="Template Name" NullDisplayText="NA" />
                                                <asp:BoundField DataField="DeskRef" HeaderText="Request Type" NullDisplayText="NA" />
                                                <asp:BoundField DataField="DeskPrefix" HeaderText="SD Prefix" NullDisplayText="NA" />
                                                <asp:BoundField DataField="DeskDesc" HeaderText="Desk Desc" NullDisplayText="NA" />
                                                <asp:TemplateField HeaderText="SD Category">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSDCategoryFk" runat="server" Text='<%# Eval("sdCategoryFK") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblSDCategoryName" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Stage">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSDStageFk" runat="server" Text='<%# Eval("sdStageFK") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblSDStageName" runat="server" Text='<%# Eval("StageCodeRef") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSDStatusFk" runat="server" Text='<%# Eval("sdStatusFK") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblSDStatusName" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Priority">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSDPriorityFk" runat="server" Text='<%# Eval("sdPriorityFK") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblSDPriorityName" runat="server" Text='<%# Eval("Priority") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Severity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSDSeverityFk" runat="server" Text='<%# Eval("sdSeverityFK") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblSDSeverityName" runat="server" Text='<%# Eval("Severity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Resolution">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsdSolutionTypeFK" runat="server" Text='<%# Eval("sdSolutionTypeFK") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblSDResolutionName" runat="server" Text='<%# Eval("Resolution") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="autoArchiveTime" HeaderText="Archive Time" NullDisplayText="0" />
                                                <asp:TemplateField HeaderText=" SLA">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSLAid" runat="server" Text='<%# Eval("SLAID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblSLAName" runat="server" Text='<%# Eval("SLAName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Coverage Sch">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCvrgID" runat="server" Text='<%# Eval("CoverageID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblCvrgName" runat="server" Text='<%# Eval("CoverageName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Organization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrgFk" runat="server" Text='<%# Eval("OrgFk") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblOrgName" runat="server" Text='<%# Eval("OrgName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>


                    <asp:HiddenField ID="hdnCategoryID" runat="server" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                    <asp:HiddenField ID="HiddenField4" runat="server" />
                    <asp:HiddenField ID="HiddenField5" runat="server" />
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="gvDesk" />
                    <asp:PostBackTrigger ControlID="btnUpdate" />
                    <asp:PostBackTrigger ControlID="lnkPreviousSLA" />
                    <asp:PostBackTrigger ControlID="lnkNextCustomFields" />
                    <asp:PostBackTrigger ControlID="ddlStageDeskConfig" />
                    <asp:PostBackTrigger ControlID="ImgBtnExport12" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
        <%--Add DeskConfig End--%>

        <%--Add Custom Fields Start--%>
        <%--<asp:Panel runat="server" ID="pnlAddCustomFields" Visible="false">
                <asp:UpdatePanel ID="updatepanel12" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="form-label">
                                                Organization: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlOrgCustomField" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrgCustomField_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Request Type: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlRequestType" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlRequestTypeCustomField" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestTypeCustomField_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                SD Role : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvddlSDRole" runat="server" ControlToValidate="ddlSDRole" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlSDRole" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field">
                                                    <asp:ListItem Selected="True" Text="----Select Role----" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Master" Value="Master"></asp:ListItem>
                                                    <asp:ListItem Text="ITManager" Value="ITManager"></asp:ListItem>
                                                    <asp:ListItem Text="CRM" Value="CRM"></asp:ListItem>
                                                    <asp:ListItem Text="ITEngineer" Value="ITEngineer"></asp:ListItem>
                                                    <asp:ListItem Text="UAT" Value="UAT"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Field Type : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvddlFieldType" runat="server" ControlToValidate="ddlFieldType" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SDCustomFields"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlFieldType" runat="server" CssClass="form-control  form-control-sm">
                                                    <asp:ListItem Text="---Select Field---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="TextBox" Value="TextBox"></asp:ListItem>
                                                    <asp:ListItem Text="List" Value="DropDown"></asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Field Name : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvtxtFieldName" runat="server" ControlToValidate="txtFieldName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SDCustomFields"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-4 pr-5">
                                                <asp:TextBox ID="txtFieldName" runat="server" TextMode="SingleLine" CssClass="form-control  form-control-sm"></asp:TextBox>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Field Mode : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvddlFieldMode" runat="server" ControlToValidate="ddlFieldMode" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SDCustomFields"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlFieldMode" runat="server" CssClass="form-control  form-control-sm">
                                                    <asp:ListItem Text="---Select Mode---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="DateTime" Value="DateTime"></asp:ListItem>
                                                    <asp:ListItem Text="Number" Value="int"></asp:ListItem>
                                                    <asp:ListItem Text="SingleLine" Value="varchar(500)"></asp:ListItem>
                                                    <asp:ListItem Text="MultiLine" Value="varchar(max)"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                IS Visible : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="frvddlVisibilty" runat="server" ControlToValidate="ddlVisibilty" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SDCustomFields"></asp:RequiredFieldValidator>
                                            </label>

                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlVisibilty" runat="server" CssClass="form-control  form-control-sm">
                                                    <asp:ListItem Text="---Select Visibilty---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="True" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="False" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Is Required: <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvddlRequiredStatus" runat="server" ControlToValidate="ddlRequiredStatus" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SDCustomFields"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlRequiredStatus" runat="server" CssClass="form-control  form-control-sm">
                                                    <asp:ListItem Text="---Select ---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="True" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="False" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                                Field Scope : <span title="*"></span>
                                                <asp:RequiredFieldValidator ID="rfvddlFieldScope" runat="server" ControlToValidate="ddlFieldScope" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SDCustomFields"></asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlFieldScope" runat="server" CssClass="form-control  form-control-sm">
                                                    <asp:ListItem Text="---Select Scope---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="For Both" Value="ForBoth"></asp:ListItem>
                                                    <asp:ListItem Text="For User" Value="ForUser"></asp:ListItem>
                                                    <asp:ListItem Text="For Technician" Value="ForTechnician"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="col-md-3  offset-5">
                                                <asp:Button ID="btnInsertSDCustomFields" runat="server" Text="Save" class="btn btn-sm savebtn" OnClick="btnInsertSDCustomFields_Click" ValidationGroup="SDCustomFields" />
                                                <asp:Button ID="btnUpdateSDCustomFields" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateSDCustomFields_Click" ValidationGroup="SDCustomFields" />
                                                <asp:Button ID="btnCancel12" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel12_Click" CausesValidation="false" />
                                            </div>
                                        </div>
                                        <div class="d-flex align-items-center gap-3">
                                            <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkPreviousDeskConfig" runat="server" OnClick="lnkPreviousDeskConfig_Click">Previous</asp:LinkButton>
                                            <asp:LinkButton class="btn btn-grd-primary px-4" ID="lnkNextEsclation" runat="server" OnClick="lnkNextEsclation_Click">Next</asp:LinkButton>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12 graphs">
                                                <div class="xs">
                                                    <div class="well1 white">
                                                        <div class="card card-default">
                                                            <div class="card-body">
                                                                <div class="row ">
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="Label20" runat="server" Text="SDCustomFields Details" Font-Size="Larger" ForeColor="Black"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label24" runat="server"></asp:Label>
                                                                        <asp:Label ID="Label25" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-2 ">
                                                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                                            <label class="mr-2 ml-1 mb-0">Export</label>
                                                                            <asp:ImageButton ID="ImgBtnExport13" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport13_Click" />
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                                <div style="overflow-x: scroll">
                                                                    <asp:GridView GridLines="None" ID="gvSDCustomFields" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-bordered"
                                                                        Width="100%" OnRowCommand="gvSDCustomFields_RowCommand" OnRowDataBound="gvSDCustomFields_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                                <ItemTemplate>
                                                                                    <%#Container.DataItemIndex+1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DeskRef" HeaderText="Request Type" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="FieldID" HeaderText="FieldID" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="FieldName" HeaderText="Field Name" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="FieldMode" HeaderText="Field Mode" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="fieldType" HeaderText="Field Type" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="Status" HeaderText="Status" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="IsFieldReq" HeaderText="IsFieldReq" NullDisplayText="NA" />
                                                                            <asp:BoundField DataField="FieldScope" HeaderText="FieldScope" NullDisplayText="NA" />
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
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="ImgBtnExport13" />
                        <asp:PostBackTrigger ControlID="ddlRequestTypeCustomField" />
                        <asp:PostBackTrigger ControlID="ddlOrgCustomField" />
                        <asp:PostBackTrigger ControlID="btnInsertSDCustomFields" />
                        <asp:PostBackTrigger ControlID="gvSDCustomFields" />
                        <asp:PostBackTrigger ControlID="btnUpdateSDCustomFields" />
                        <asp:PostBackTrigger ControlID="lnkPreviousDeskConfig" />
                        <asp:PostBackTrigger ControlID="lnkNextEsclation" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>--%>
        <%--Add Custom Fields End--%>

        <%--Add Esclation Matrix Strat--%>
        <asp:Panel ID="pnlExclation" runat="server" Visible="false">
            <asp:UpdatePanel ID="updatepanel13" runat="server">
                <ContentTemplate>

                    <div class="card">
                        <div class="card-body mb-1">
                            <div class="row gx-2 gy-3">
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Esclation Level 
                                            <asp:RequiredFieldValidator ID="rfvddlEsclationLevel" runat="server" ControlToValidate="ddlEsclationLevel" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserEcslevel"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlEsclationLevel" runat="server" CssClass="form-control  form-control-sm">
                                        <asp:ListItem Text="L1" Value="L1"></asp:ListItem>
                                        <asp:ListItem Text="L2" Value="L2"></asp:ListItem>
                                        <asp:ListItem Text="L3" Value="L3"></asp:ListItem>
                                        <asp:ListItem Text="L4" Value="L4"></asp:ListItem>
                                        <asp:ListItem Text="L5" Value="L5"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        User Name
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtUserNameEsc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserEcslevel"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtUserNameEsc" runat="server" CssClass="form-control  form-control-sm ">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Email
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                Display="Dynamic" ErrorMessage="Invalid Email" ValidationGroup="UserEcslevel" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtEmailEsc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserEcslevel"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtEmailEsc" runat="server" CssClass="form-control  form-control-sm ">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Mobile
                                        <asp:RegularExpressionValidator ID="rvPhoneNumber" runat="server"
                                            ControlToValidate="txtMobile"
                                            ValidationExpression="^(?:(?:\+?\d{1,3}[-.\s]?)?\(?(?:\d{3})?\)?[-.\s]?\d{3}[-.\s]?\d{4})|(?:(?:\+?\d{1,3}[-.\s]?)?\(?(?:\d{2,4})?\)?[-.\s]?\d{6,8})$"
                                            ErrorMessage="Invalid Number" ForeColor="Red"
                                            Display="Dynamic" ValidationGroup="UserEcslevel">
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="rfvtxtMobile" runat="server" ControlToValidate="txtMobile" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserEcslevel"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txtMobile" TextMode="Phone" runat="server" CssClass="form-control  form-control-sm " onkeypress="return /^[0-9]*$/.test(event.key) && this.value.length < 12;">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Esclation Time(in Min)
                                            <asp:RequiredFieldValidator ID="rfvtxttimeforEsclation" runat="server" ControlToValidate="txttimeforEsclation" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserEcslevel"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:TextBox ID="txttimeforEsclation" runat="server" TextMode="Number" CssClass="form-control  form-control-sm ">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="staticEmail" class="form-label">
                                        Organization

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:DropDownList ID="ddlOrgEcs" runat="server" CssClass="form-control form-control-sm single-select-optgroup-field">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-12 text-end">
                                    <asp:Button ID="btnInsertEcslevel" runat="server" Text="Save" class="btn btn-sm btn-grd-info" OnClick="btnInsertEcslevel_Click" ValidationGroup="UserEcslevel" />
                                    <asp:Button ID="btnUpdateEcslevel" runat="server" Text="Update" Visible="false" class="btn btn-sm btn-grd-info" OnClick="btnUpdateEcslevel_Click" ValidationGroup="UserEcslevel" />
                                    <asp:Button ID="btnCancel14" runat="server" Text="Cancel" class="btn btn-sm btn-grd-danger" OnClick="btnCancel14_Click" CausesValidation="false" />
                                    <asp:LinkButton class="btn btn-grd-info btn-sm" ID="lnkPreviousCustomField" runat="server" OnClick="lnkPreviousCustomField_Click">Previous</asp:LinkButton>

                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="card">
                        <div class="card-body">
                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <div class="">
                                    <h6 class="mb-0">
                                        <asp:Label ID="Label26" runat="server" Text="Ecslevel Details"></asp:Label>
                                    </h6>
                                </div>
                                <asp:LinkButton ID="ImgBtnExport14" runat="server" class="btn btn-sm btn-outline-secondary" OnClick="ImgBtnExport14_Click">Export <i class="fa-solid fa-download"></i></asp:LinkButton>

                            </div>
                            <div class="row ">
                                <div class="col-md-12">
                                    <div class="table-responsive table-container">
                                        <asp:GridView GridLines="None" ID="gvEcslevel" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-head-fixed text-nowrap table-sm border"
                                            Width="100%" OnRowCommand="gvEcslevel_RowCommand" OnRowDataBound="gvEcslevel_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="EsclationLevel" HeaderText="Escltion Level" NullDisplayText="NA" />
                                                <asp:BoundField DataField="UserName" HeaderText="UserName" NullDisplayText="NA" />
                                                <asp:BoundField DataField="UserEmail" HeaderText="User Email" NullDisplayText="NA" />
                                                <asp:BoundField DataField="Mobile" HeaderText="Mobile" NullDisplayText="NA" />
                                                <asp:BoundField DataField="TimeForEsclatn" HeaderText="Esclation Time" NullDisplayText="NA" />
                                                <asp:TemplateField HeaderText=" Organization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrgFk" runat="server" Text='<%# Eval("Org_ID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblOrgName" runat="server" Text='<%# Eval("OrgName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:ButtonField ButtonType="Image" CommandName="UpdateEcslevel" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEcslevel" ItemStyle-Width="20px" ItemStyle-Height="5px" />--%>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit11" runat="server" CommandName="UpdateEcslevel" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Edit">
                                                <i class="fa-solid fa-edit"></i>
                                                    </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete11" runat="server" CommandName="DeleteEcslevel" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                                <i class="fa-solid fa-xmark text-danger"></i> 
                                                </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>


                            </div>

                        </div>
                    </div>



                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="ImgBtnExport14" />
                    <asp:PostBackTrigger ControlID="gvEcslevel" />
                    <asp:PostBackTrigger ControlID="lnkPreviousCustomField" />
                </Triggers>

            </asp:UpdatePanel>
        </asp:Panel>
        <%--Add Esclation Matrix End--%>
    </div>
</asp:Content>

