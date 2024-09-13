<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddUsersRoles.aspx.cs" Inherits="frmAddUsersRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
                <div class="breadcrumb-title pe-3">Users and Premissions</div>
                <div class="ps-3">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb mb-0 p-0">
                          
                            <li class="breadcrumb-item active" aria-current="page">Roles</li>
                        </ol>
                    </nav>
                </div>
            </div>
            <div class="card">
          <%--      <div class="card-header">
                    <div class="card-title mb-0">
                        Add User Roles
                    </div>
                </div>--%>
                <div class="card-body">
                    <div class="row gx-2 gy-3">
                        <div class="col-md-5">
                            <label class="form-label">
                                Enter Role
                        <asp:RequiredFieldValidator ID="RfvtxtRoleName" runat="server" ErrorMessage="*" ForeColor="Red" Font-Bold="true" ControlToValidate="txtRoleName" ValidationGroup="Role"></asp:RequiredFieldValidator>
                            </label>
                            <div class="input-group input-group-sm">
                                <asp:TextBox ID="txtRoleName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                <asp:Button ID="btnSaveRole" runat="server" Text="Submit" CssClass="btn btn-sm btn-grd btn-grd-info " OnClick="btnSaveRole_Click" ValidationGroup="Role" />
                            </div>
                        </div>
                        <div class="col-md-5">
                            <label class="form-label">
                                Select Role 
                        <asp:RequiredFieldValidator ID="RfvddlUsers" runat="server" ErrorMessage="*" InitialValue="0" ForeColor="Red" Font-Bold="true" ControlToValidate="ddlUsers" ValidationGroup="RoleA"></asp:RequiredFieldValidator>
                            </label>
                            <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="True" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row gy-3 gx-2 mt-2  ">
                        <div class="col-md-5">
                            <div class="card shadow-none border  ">
                                <div class="card-body ">
                                    <div class="d-flex flex-lg-row flex-column align-items-start align-items-lg-center justify-content-between gap-3">
                 <div class="flex-grow-1">
                    <h6 class=" fw-bold">Menu List</h6>
                 </div>
                 <div class="overflow-auto">
                                    <asp:Button ID="btnMasterRoleApply" runat="server" Text="Apply" OnClick="btnMasterRoleApply_Click" CssClass="btn btn-sm btn-outline-info" ValidationGroup="RoleA" />
                
                </div>
              </div>
                                   

                                    <div class="row mt-2">

                                        <div class="col-md-12">
                                            <div class="table-responsive table-container  white-space-nowrap" style="height: 230px">
                                                <asp:GridView ID="gvMasterRoles" DataKeyNames="MenuID" AutoGenerateColumns="false" runat="server" CssClass="table table-head-fixed text-nowrap table-sm ">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="MenuName" DataField="MenuName" ItemStyle-Font-Size="Smaller" />
                                                        <asp:BoundField HeaderText="MenuID" DataField="MenuID" ItemStyle-Font-Size="Smaller" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <div class="card shadow-none border  ">

                                <div class="card-body">
                                    <h6 class=" fw-bold">Role Wise Menu List</h6>
                                    <div class="row mt-4    ">
                                        <div class="col-md-12">
                                            <div class="table-responsive table-container" style="height: 230px">
                                                <asp:GridView ID="gvAllRoles" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table table-head-fixed text-nowrap table-sm" runat="server" OnRowCommand="gvAllRoles_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" Checked='<%# Eval("MenuStatus").ToString().Equals("Active")  %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Menu Name" DataField="MenuName" ItemStyle-Font-Size="Smaller" />
                                                        <asp:BoundField HeaderText="User Name" DataField="UserName" ItemStyle-Font-Size="Smaller" />
                                                        <asp:BoundField HeaderText="Menu Status" DataField="MenuStatus" ItemStyle-Font-Size="Smaller" />
                                                        <asp:BoundField HeaderText="MenuID" DataField="MenuID" ItemStyle-Font-Size="Smaller" />
                                                        <asp:TemplateField HeaderText="Remove">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="imgdel" runat="server"  CommandName="DeleterRole" CommandArgument='<%#Eval("ID") %>'  ToolTip="Delete" CausesValidation="false"  ><i class="fa-sharp fa-solid fa-xmark text-danger"></i></asp:LinkButton>
                                                              
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
