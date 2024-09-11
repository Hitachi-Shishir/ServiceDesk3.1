<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DeskConfiguration.aspx.cs" Inherits="DeskConfiguration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
    <div id="stepper1" class="bs-stepper">
        <div class="card">

            <div class="card-header">
                <div class="d-lg-flex flex-lg-row align-items-lg-center justify-content-lg-between" role="tablist">
                    <div class="step" data-target="#test-l-1">
                        <div class="step-trigger" role="tab" id="stepper1trigger1" aria-controls="test-l-1">
                            <div class="bs-stepper-circle">1</div>
                            <div class="">
                                <h5 class="mb-0 steper-title">Personal Info</h5>
                                <p class="mb-0 steper-sub-title">Enter Your Details</p>
                            </div>
                        </div>
                    </div>
                    <div class="bs-stepper-line"></div>
                    <div class="step" data-target="#test-l-2">
                        <div class="step-trigger" role="tab" id="stepper1trigger2" aria-controls="test-l-2">
                            <div class="bs-stepper-circle">2</div>
                            <div class="">
                                <h5 class="mb-0 steper-title">Account Details</h5>
                                <p class="mb-0 steper-sub-title">Setup Account Details</p>
                            </div>
                        </div>
                    </div>
                    <div class="bs-stepper-line"></div>
                    <div class="step" data-target="#test-l-3">
                        <div class="step-trigger" role="tab" id="stepper1trigger3" aria-controls="test-l-3">
                            <div class="bs-stepper-circle">3</div>
                            <div class="">
                                <h5 class="mb-0 steper-title">Education</h5>
                                <p class="mb-0 steper-sub-title">Education Details</p>
                            </div>
                        </div>
                    </div>
                    <div class="bs-stepper-line"></div>
                    <div class="step" data-target="#test-l-4">
                        <div class="step-trigger" role="tab" id="stepper1trigger4" aria-controls="test-l-4">
                            <div class="bs-stepper-circle">4</div>
                            <div class="">
                                <h5 class="mb-0 steper-title">Work Experience</h5>
                                <p class="mb-0 steper-sub-title">Experience Details</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

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
                                        <asp:LinkButton class="btn btn-grd-info px-4" ID="lnkNext" runat="server" OnClick="lnkNext_Click" OnClientClick="stepper1.next()">Next<i class='bx bx-right-arrow-alt ms-2'></asp:LinkButton>
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
                        <asp:PostBackTrigger ControlID="lnkNext" />
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

                                                <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-control form-control-sm chzn-select">
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
                                                <asp:LinkButton ID="lnkPrev" runat="server" OnClientClick="stepper1.previous()" OnClick="lnkPrev_Click"><i class='bx bx-left-arrow-alt me-2'></i>Previous</asp:LinkButton>
                                                <asp:LinkButton ID="lnkNext2" runat="server"  OnClientClick="stepper1.next()" OnClick="lnkNext2_Click">Next<i class='bx bx-right-arrow-alt ms-2'></i></asp:LinkButton>
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
                        <div class="modal" id="CategoryModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-centered modal-xl">
                                <div class="modal-content">
                                    <div class="card-header">
                                        Organization
                         <button type="button" class="close" onclick="javascript:window.location.reload()" data-dismiss="modal" aria-hidden="true">&times;</button>


                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

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

                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>

            <%--Add Request Type End--%>
        </div>
    </div>
</asp:Content>

