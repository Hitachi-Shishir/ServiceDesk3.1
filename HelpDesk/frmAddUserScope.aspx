<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddUserScope.aspx.cs" Inherits="HelpDesk_frmAddUserScope" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnAddUserScope" Text="Add Scope" runat="server" CssClass="btn btn-sm btnDisabled" OnClick="btnAddUserScope_Click" />
                    <asp:Button ID="btnViewScope" runat="server" Text-="View Details" CssClass="btn btn-sm btnEnabled" OnClick="btnViewScope_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <asp:Panel ID="pnlAddscope" runat="server" Visible="false">
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Scope Name : <span title="*"></span>
                                        <asp:RequiredFieldValidator ID="rfvtxtScopeName" runat="server" ControlToValidate="txtScopeName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtScopeName" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>
                                    </div>
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Scope Status: <span title="*"></span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtScopeDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:DropDownList ID="ddlScopeStatus" runat="server" CssClass="form-control  form-control-sm chzn-select">
                                            <asp:ListItem Text="Active" Selected="True" Value="True"></asp:ListItem>
                                            <asp:ListItem Text="In Active" Value="False"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Scope Description : <span title="*"></span>
                                        <asp:RequiredFieldValidator ID="rfvtxtScopeDesc" runat="server" ControlToValidate="txtScopeDesc" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="UserScope"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-10 pr-5">
                                        <asp:TextBox ID="txtScopeDesc" runat="server" TextMode="MultiLine" Rows="5" Columns="5" CssClass="form-control  form-control-sm"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-3 offset-5 ">
                                        <asp:Button ID="btnInsertScope" runat="server" Text="Save" class="btn btn-sm savebtn" OnClick="btnInsertScope_Click" ValidationGroup="UserScope" />
                                        <asp:Button ID="btnUpdateScope" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateScope_Click" ValidationGroup="UserScope" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel_Click" CausesValidation="false" />
                                    </div>
                                </div>

                            </asp:Panel>
                            <asp:Panel ID="pnlViewScope" runat="server">
                                <div class="row">
                                    <div class="col-lg-12 col-md-6 col-sm-4 graphs">
                                        <div class="xs">
                                            <div class="well1 white">
                                                <div class="card card-default">

                                                    <div class="card-body">
                                                        <div class="row ">
                                                            <div class="col-md-4">

                                                                <asp:Label ID="lblsofname" runat="server" Text="Scope Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

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
                                                        <div class="table-responsive p-0" style="height: 400px; width: 100%">
                                                            <asp:GridView GridLines="None" ID="gvScope" runat="server" DataKeyNames="ScopeID" AutoGenerateColumns="false" CssClass="data-table table table-striped table-bordered table-sm"
                                                                Width="100%" OnRowCommand="gvScope_RowCommand" OnRowDataBound="gvScope_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                        <ItemTemplate>
                                                                            <%#Container.DataItemIndex+1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField DataField="ScopeName" HeaderText="Scope Name" NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="ScopeDesc" HeaderText="Scope Description" NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="IsActive" HeaderText="Status" />

                                                                    <asp:ButtonField ButtonType="Image" CommandName="UpdateScope" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                                    <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteScope" ItemStyle-Width="20px" ItemStyle-Height="5px" />
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

        </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="ImgBtnExport" />
            <asp:PostBackTrigger ControlID="btnAddUserScope" />

            <asp:PostBackTrigger ControlID="btnViewScope" />

            <%--<asp:PostBackTrigger ControlID="btnInsertScope" />--%>

            <%--<asp:PostBackTrigger ControlID="gvScope" />--%>
            <%--<asp:PostBackTrigger ControlID="btnUpdateScope" />--%>
        </Triggers>

    </asp:UpdatePanel>
</asp:Content>

