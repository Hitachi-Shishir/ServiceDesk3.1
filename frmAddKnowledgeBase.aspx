﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddKnowledgeBase.aspx.cs" Inherits="frmAddKnowledgeBase" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="assets/plugins/summernote/jquery.js"></script>
    <link href="assets/plugins/summernote/summernote-bs4.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>
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
            margin-top: -1.7rem !important;
        }

        .note-editor {
            border: var(--bs-border-width) var(--bs-border-style) var(--bs-border-color) !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>

            <div class="card">
                <div class="card-body">

                    <div class="row d-none">
                        <div class="col-md-6 col-lg-12 col-sm-4">
                            <label class="cardheader">New Resolution</label>
                            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>

                    <div class="row mb-2">
                        <div class="col-md-12">
                            <div class="btn-group">
                                <asp:Button ID="btnAddPriority" Text="Add Resolution" runat="server" CssClass="btn btn-sm btn-outline-secondary" OnClick="btnAddPriority_Click" />
                                <asp:Button ID="btnViewPriority" runat="server" Text-="View Details" CssClass="btn btn-sm btn-outline-secondary" OnClick="btnViewPriority_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="card border bg-transparent shadow-none ">
                        <div class="card-body">
                            <asp:Panel ID="pnlIncident" runat="server">
                                <div class="  row gx-2 gy-3">
                                    <div class="col-md-12">
                                        <label for="staticEmail" class="form-label">
                                            Summary 
                                                    <asp:RequiredFieldValidator ID="RfvtxtSummary" runat="server" ControlToValidate="txtSummary" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>

                                        <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                    <div class="col-md-12">
                                        <label for="staticEmail" class="form-label">
                                            Issue in Detail
              <asp:RequiredFieldValidator ID="RfvtxtDescription" runat="server" ControlToValidate="txtDescription" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>

                                        <%--	<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" MaxLength="500" Height="200px"></asp:TextBox>--%>
                                        <asp:TextBox ID="txtDescription" runat="server" Rows="3" Columns="5" TextMode="MultiLine"></asp:TextBox>

                                    </div>
                                    <div class="col-md-8">
                                        <div class="form-check">
 <asp:CheckBox ID="chkViewToUser" runat="server" CssClass="form-check-input"></asp:CheckBox>                                            <label class="form-check-label" for="staticEmail">
                                                View To User						
                                            </label>
                                        </div>
                                        <label for="" class="form-label">
                                        </label>

                                       

                                    </div>
                                    <div class="col-md-4 text-end">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="Addticket" OnClick="btnSubmit_Click" CssClass="btn btn-sm btn-grd btn-grd-info " />
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="Addticket" OnClick="btnUpdate_Click" CssClass="btn btn-sm btn-grd btn-grd-info  " />

                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" CssClass="btn btn-sm btn-grd btn-grd-danger " />
                                    </div>
                                </div>






                            </asp:Panel>
                            <asp:Panel ID="pnlShowPriority" runat="server">

                                <div class="row ">
                                    <div class="col-md-4 d-none">

                                        <asp:Label ID="lblsofname" runat="server" Text="Resolution Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 d-none">
                                        <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                            <label class="mr-2 ml-1 mb-0">Export</label>
                                            <asp:ImageButton ID="ImgBtnExport" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport_Click" />
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="table-responsive table-container">
                                            <asp:GridView GridLines="None" ID="gvResolution" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="data-table table table-striped table-bordered table-sm text-nowrap"
                                                Width="100%" OnRowCommand="gvResolution_RowCommand" OnRowDataBound="gvResolution_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="KBNumber" HeaderText="Article" NullDisplayText="NA" />
                                                    <asp:BoundField DataField="Issue" HeaderText="Issue" NullDisplayText="NA" />
                                                    <%--																<asp:BoundField DataField="ResolutionDetail" HeaderText="Resolution Description" NullDisplayText="NA" />--%>
                                                    <asp:TemplateField HeaderText="Description" SortExpression="Description" ItemStyle-Font-Size="Smaller">

                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDescription" runat="server" Font-Size="Smaller" Text='<%# Server.HtmlDecode(Eval("ResolutionDetail").ToString()) %>'> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ViewToUser" HeaderText="ViewToUser" NullDisplayText="NA" />
                                                    <asp:TemplateField HeaderText=" Organization">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOrgFk" runat="server" Text='<%# Eval("Org_ID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblOrgName" runat="server" Text='<%# Eval("OrgName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="SelectState" CommandArgument="<%# Container.DataItemIndex %>">
                                                  <i class="fa-solid fa-edit"></i> 
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteEx" CommandArgument="<%# Container.DataItemIndex %>">
          <i class="fa-solid fa-xmark text-danger"></i> 
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                </div>


                            </asp:Panel>

                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="btnAddPriority" />
            <asp:PostBackTrigger ControlID="btnViewPriority" />
            <asp:PostBackTrigger ControlID="gvResolution" />
        </Triggers>

    </asp:UpdatePanel>
    <script src="assets/plugins/summernote/summernote-bs4.js"></script>
    <script>
        $(document).ready(function () {
            $('#<%= txtDescription.ClientID %>').summernote();
        });
    </script>
</asp:Content>

