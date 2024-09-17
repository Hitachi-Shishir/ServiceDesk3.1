<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmSDCustomFieldCnrtl.aspx.cs" Inherits="HelpDesk_frmSDCustomFieldCnrtl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnAddSDCustomFields" Text="Add SDCustomFields" runat="server" CssClass="btn btn-sm btnDisabled" OnClick="btnAddSDCustomFields_Click" />
                    <asp:Button ID="btnViewSDCustomFields" runat="server" Text-="View Details" CssClass="btn btn-sm btnEnabled" OnClick="btnViewSDCustomFields_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">

                            <asp:Panel ID="pnlAddSDCustomFields" runat="server" Visible="false">
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Organization: <span title="*"></span>

                                        <asp:ImageButton ID="imgbtnAddOrg" runat="server" ImageUrl="~/Images/plus.png" OnClick="imgbtnAddOrg_Click" hidden />
                                        <asp:RequiredFieldValidator ID="rfvddlOrg" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="ReqType"></asp:RequiredFieldValidator>
                                    </label>

                                    <div class="col-sm-4 pr-5">

                                        <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Request Type: <span title="*"></span>

                                        <asp:ImageButton ID="ImgAddRequestType" runat="server" ImageUrl="~/Images/plus.png" OnClick="ImgAddRequestType_Click" hidden />
                                        <asp:RequiredFieldValidator ID="rfvddlRequestType" runat="server" ControlToValidate="ddlRequestType" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                    </label>

                                    <div class="col-sm-4 pr-5">

                                        <asp:DropDownList ID="ddlRequestType" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        SD Role : <span title="*"></span>

                                        <asp:RequiredFieldValidator ID="rfvddlSDRole" runat="server" ControlToValidate="ddlSDRole" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                    </label>

                                    <div class="col-sm-4 pr-5">

                                        <asp:DropDownList ID="ddlSDRole" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field">
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
                                        <asp:DropDownList ID="ddlFieldType" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field">
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
                                        <asp:DropDownList ID="ddlFieldMode" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field">
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
                                        <asp:DropDownList ID="ddlRequiredStatus" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field">
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
                                        <asp:DropDownList ID="ddlFieldScope" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field">
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
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel_Click" CausesValidation="false" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlShowSDCustomFields" runat="server">
                                <div class="row">
                                    <div class="col-md-12 graphs">
                                        <div class="xs">
                                            <div class="well1 white">
                                                <div class="card card-default">

                                                    <div class="card-body">
                                                        <div class="row ">
                                                            <div class="col-md-4">

                                                                <asp:Label ID="lblsofname" runat="server" Text="SDCustomFields Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

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
                                                        <div style="overflow-x: scroll">
                                                            <asp:GridView GridLines="None" ID="gvSDCustomFields" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="data-table table table-striped table-bordered table-sm"
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
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal " id="basicModal" <%-- tabindex="-1"--%> role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="card-header" style="border-bottom: none">

                            <button type="button" class="close" onclick="javascript:window.location.reload()" data-dismiss="modal" aria-hidden="true">&times;</button>


                        </div>
                        <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>--%>
                        <div class="card-body">
                            <asp:Label ID="lblsuccess" runat="server" Text=""></asp:Label>
                            <asp:PlaceHolder ID="pnlShowRqstType" runat="server"></asp:PlaceHolder>
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
            <asp:PostBackTrigger ControlID="ImgBtnExport" />
            <asp:AsyncPostBackTrigger ControlID="ImgAddRequestType" EventName="Click" />
            <asp:PostBackTrigger ControlID="ddlRequestType" />
            <asp:PostBackTrigger ControlID="ddlOrg" />
            <asp:PostBackTrigger ControlID="btnAddSDCustomFields" />
            <asp:PostBackTrigger ControlID="btnViewSDCustomFields" />
            <asp:PostBackTrigger ControlID="gvSDCustomFields" />
            <asp:AsyncPostBackTrigger ControlID="imgbtnAddOrg" EventName="Click" />
        </Triggers>

    </asp:UpdatePanel>
</asp:Content>

