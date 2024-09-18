<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddCustomFieldValues.aspx.cs" Inherits="HelpDesk_frmAddCustomFieldValues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="row mb-1">
                <div class="col-lg-12 col-md-6 col-sm-4">
                    <asp:Button ID="btnAddCustomField" runat="server" Text="Add CustomField" CausesValidation="false" OnClick="btnAddCustomField_Click" />
                    <asp:Button ID="btnimportUser" runat="server" Text="Import CustomField" CausesValidation="false" OnClick="btnimportUser_Click" />
                    <asp:Button ID="btnViewUsers" runat="server" Text="View CustomField" CausesValidation="false" OnClick="btnViewUsers_Click" />
                </div>
            </div>
            <asp:Panel ID="pnlAddCustomField" Visible="false" runat="server">

                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-12" style="border-bottom: 1px solid lightgrey">
                                        <label class="form-label">Add CustomField Value</label>
                                    </div>

                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Organization: <span title="*"></span>

                                        <asp:ImageButton ID="imgbtnAddOrg" runat="server" ImageUrl="~/Images/plus.png" OnClick="imgbtnAddOrg_Click" hidden />
                                        <asp:RequiredFieldValidator ID="rfvddlOrg" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                    </label>

                                    <div class="col-sm-4 pr-5">

                                        <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Custom Field Name<span class="red">*</span>
                                        <asp:RequiredFieldValidator ID="rfvddlCustomFieldName" runat="server" ControlToValidate="ddlCustomFieldName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:DropDownList ID="ddlCustomFieldName" class="form-control form-control-sm chzn-select" runat="server"></asp:DropDownList>
                                    </div>

                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Enter Value<span class="red">*</span>
                                        <asp:RequiredFieldValidator ID="rfvtxtCustomFieldValue" runat="server" ControlToValidate="txtCustomFieldValue" ErrorMessage="*" ForeColor="Red" ValidationGroup="SearchUser"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtCustomFieldValue" class="form-control form-control-sm" runat="server" />
                                    </div>




                                </div>


                                <div class="form-row">
                                    <div class="col-md-3 offset-5  ">

                                        <asp:Button ID="btnInsertCustomField" runat="server" Text="Save" OnClick="btnInsertCustomField_Click" class="btn btn-sm savebtn" ValidationGroup="Tech"></asp:Button>
                                        <asp:Button ID="btnUpdateCustomField" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateCustomField_Click" ValidationGroup="ReqType" />
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

                                                <asp:Label ID="lblsofname" runat="server" Text="Custom Field Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

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
                                        <div class="form-group row mt-3">
                                            <label for="staticEmail" class="col-sm-3 labelcolorl1 pl-5">
                                                Custom Field Name<span class="red">*</span>
                                                <asp:RequiredFieldValidator ID="rfvddlCustomField" runat="server" ControlToValidate="ddlCustomField" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                                </asp:RequiredFieldValidator>
                                            </label>
                                            <div class="col-sm-4 pr-5">
                                                <asp:DropDownList ID="ddlCustomField" class="form-control form-control-sm chzn-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomField_SelectedIndexChanged"></asp:DropDownList>
                                            </div>





                                        </div>
                                        <div class="row">
                                            <label for="staticEmail" class="col-sm-3 labelcolorl1 pl-5">
                                            </label>
                                            <div class="col-md-4 pr-5">
                                                <div class="table-responsive p-0" style="height: 400px; width: 100%">
                                                    <asp:GridView GridLines="None" ID="gvCustomField" runat="server" AutoGenerateColumns="false" CssClass="table table-head-fixed text-nowrap"
                                                        Width="100%" OnRowCommand="gvCustomField_RowCommand" OnRowDataBound="gvCustomField_RowDataBound" DataKeyNames="ID">
                                                        <Columns>
                                                            <asp:ButtonField ButtonType="Image" CommandName="SelectTech" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                            <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />
                                                            <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--											<asp:TemplateField HeaderText="FieldValue">

														<ItemTemplate>
															<asp:Label ID="lblDescription" runat="server" Text='<%# Eval("FieldValue") %>'> </asp:Label>
														</ItemTemplate>
													</asp:TemplateField>--%>
                                                            <asp:BoundField DataField="FieldValue" HeaderText="Value" NullDisplayText="NA" />
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
            </asp:Panel>
            <asp:Panel ID="pnlImportUser" runat="server" Visible="false">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-2">
                                        <label class="labelcolorl1">
                                            Select Users(s) :
                                        
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
                                        <a href="SampleFiles/UserMaster.xlsx" target="_blank" download="Insert Format" class="  btn-sm warning_3"><u>Download Sample Excel</u>
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
                                            <asp:GridView ID="gvExcelFile" runat="server" CssClass="data-table table table-striped table-bordered table-sm" AutoGenerateColumns="true">

                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="modal" id="CategoryModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-xl">
                    <div class="modal-content">
                        <div class="card-header">
                            Organization
                          <button type="button" class="close" onclick="javascript:window.location.reload()" data-dismiss="modal" aria-hidden="true">&times;</button>


                        </div>
                        <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                          <ContentTemplate>--%>

                        <div class="row">
                            <div class="col-md-12">
                                <asp:PlaceHolder ID="pnlShowOrg" runat="server"></asp:PlaceHolder>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>

            <asp:PostBackTrigger ControlID="btnn" />
            <asp:PostBackTrigger ControlID="butttonsubmit" />
            <asp:PostBackTrigger ControlID="gvCustomField" />
            <asp:PostBackTrigger ControlID="ImgBtnExport" />
            <asp:PostBackTrigger ControlID="ddlOrg" />
            <asp:PostBackTrigger ControlID="ddlCustomField" />
            <asp:PostBackTrigger ControlID="btnAddCustomField" />
            <asp:PostBackTrigger ControlID="btnimportUser" />
            <asp:PostBackTrigger ControlID="btnViewUsers" />

            <asp:AsyncPostBackTrigger ControlID="imgbtnAddOrg" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

