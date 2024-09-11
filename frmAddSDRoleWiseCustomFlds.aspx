<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddSDRoleWiseCustomFlds.aspx.cs" Inherits="frmAddSDRoleWiseCustomFlds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class=" col-lg-12 col-md-6 col-sm-4" style="border-bottom: 1px gray solid">
                            <label class="col-form-label">
                                Add User Roles
                            </label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2" hidden>
                            <label class="labelcolorl1">
                                Enter Role :
                                <asp:RequiredFieldValidator ID="RfvtxtRoleName" runat="server" ErrorMessage="*" ForeColor="Red" Font-Bold="true" ControlToValidate="txtRoleName" ValidationGroup="Role"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtRoleName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                        <div class="col-md-2 mt-1" hidden>
                            <label class="labelcolorl1"></label>
                            <asp:Button ID="btnSaveRole" runat="server" Text="Submit" CssClass="btn btn-sm savebtn" OnClick="btnSaveRole_Click" Style="margin-top: 25px" ValidationGroup="Role" />
                        </div>
                        <div class="col-md-3">
                            <div class="well1 white">
                                <label class="labelcolorl1">
                                    Select Role :
            <asp:RequiredFieldValidator ID="RfvddlUsers" runat="server" ErrorMessage="*" InitialValue="0" ForeColor="Red" Font-Bold="true" ControlToValidate="ddlUsers" ValidationGroup="RoleA"></asp:RequiredFieldValidator>
                                </label>
                                <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Text="----Select Role----" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Master" Value="Master"></asp:ListItem>
                                    <asp:ListItem Text="ITManager" Value="ITManager"></asp:ListItem>
                                    <asp:ListItem Text="CRM" Value="CRM"></asp:ListItem>
                                    <asp:ListItem Text="ITEngineer" Value="ITEngineer"></asp:ListItem>
                                    <asp:ListItem Text="UAT" Value="UAT"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col-md-5">
                            <div class="card">

                                <div class="card-body">
                                    <div class="row">
                                        <div class=" col-lg-12 col-md-6 col-sm-4" style="border-bottom: 1px gray solid">
                                            <label class="col-form-label">
                                                Menu List
                                            </label>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnMasterRoleApply" runat="server" Text="Apply" OnClick="btnMasterRoleApply_Click" CssClass="btn btn-sm savebtn mt-2" ValidationGroup="RoleA" />

                                    <div class="table-responsive p-0" style="height: 500px; width: 370px">
                                        <asp:GridView ID="gvMasterRoles" DataKeyNames="MenuID" AutoGenerateColumns="false" runat="server" CssClass="table table-head-fixed text-nowrap">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="MenuName" DataField="MenuName" ItemStyle-Font-Size="Smaller" />
                                                <asp:BoundField HeaderText="Desk" DataField="Deskref" ItemStyle-Font-Size="Smaller" />
                                                <asp:BoundField HeaderText="MenuID" DataField="MenuID" ItemStyle-Font-Size="Smaller" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4 ">
                            <div class="card" style="display: table">

                                <div class="card-body">
                                    <div class="row">
                                        <div class=" col-lg-12 col-md-6 col-sm-4" style="border-bottom: 1px gray solid">
                                            <label class="col-form-label">
                                                Role Wise Menu List
                                            </label>
                                        </div>


                                    </div>
                                    <div class="table-responsive p-0" style="height: 500px; width: 500px">
                                        <asp:GridView ID="gvAllRoles" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-head-fixed text-nowrap" runat="server" OnRowCommand="gvAllRoles_RowCommand">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" Checked='<%# Eval("MenuStatus").ToString().Equals("Active")  %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="Menu Name" DataField="MenuName" ItemStyle-Font-Size="Smaller" />

                                                <asp:BoundField HeaderText="Menu Status" DataField="MenuStatus" ItemStyle-Font-Size="Smaller" />
                                                <asp:BoundField HeaderText="MenuID" DataField="MenuID" ItemStyle-Font-Size="Smaller" />
                                                <asp:TemplateField HeaderText="Remove">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgdel" runat="server" CommandName="DeleterRole" CommandArgument='<%#Eval("ID") %>' ImageUrl="~/Images/New folder/delnew.png" ToolTip="Delete" CausesValidation="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <asp:Button ID="btnUpdateRoles" runat="server" Text="Apply" CssClass="btn btn-sm btn-success warning_3" OnClick="btnUpdateRoles_Click" Visible="false" />
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

