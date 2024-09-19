<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmOrgWiseTickets.aspx.cs" Inherits="Reports_frmOrgWiseTickets" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <section class="content">
        <div class="container-fluid">
            <div class="row ">
                <div class="col-md-12 graphs">
                    <div class="card card-default">
                        <div class="card-body">
                            <div class="row mb-2">
                                <div class="col-md-3 grid_box1">
                                    <label class="control-label ">
                                        Select Desk : 
                    <asp:RequiredFieldValidator ID="RequiredSDDrop" runat="server" ControlToValidate="DropDesks" InitialValue="0" ErrorMessage="Required" ForeColor="Red" ValidationGroup="searchbtn"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="DropDesks" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2 grid_box1">
                                    <label class="control-label ">
                                        From : 
                                <asp:RequiredFieldValidator ID="RequiredtxtFrom" runat="server" ControlToValidate="txtFrom" ErrorMessage="Required" ForeColor="Red" ValidationGroup="searchbtn"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="input-group mb-3">
                                        <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control form-control-sm datepicker" autocomplete="off" ClientIDMode="static"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 grid_box1">
                                    <label class="control-label ">
                                        Before : 
                                <asp:RequiredFieldValidator ID="RequiredSDtxtTo" runat="server" ControlToValidate="txtTo" ErrorMessage="Required" ForeColor="Red" ValidationGroup="searchbtn"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="input-group mb-3">
                                        <asp:TextBox ID="txtTo" runat="server" CssClass="form-control form-control-sm datepicker" autocomplete="off" ClientIDMode="static"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2  mt-4 pt-2">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" ValidationGroup="searchbtn" CssClass="btn btn-sm savebtn" />
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row mt-2">
                                <div class="col-md-3">
                                    <asp:Label ID="Label1" runat="server" Text="All Ticket Details" Font-Size="Larger" ForeColor="Black"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                </div>
                                <div class="col-md-3">
                                    <div class="btn btn-sm elevation-1 ml-2" style="padding: 0px; margin-bottom: 10px; padding-top: 0px">
                                        <label class="mr-1 ml-1 mb-0">Export</label>
                                        <asp:ImageButton ID="ImageBtnExport" runat="server" ImageUrl="~/Images/New folder/excelnew.png" OnClick="ImageBtnExport_Click" CssClass="pull-right ml-2 mt-0 btn-outline-success control-label" class="fa fa-download" />
                                    </div>
                                    <asp:Label ID="Label4" runat="server" CssClass="ml-1  " Font-Size="Medium" Text="Total: "></asp:Label>
                                    <asp:Label ID="lblTotalCount" runat="server" CssClass="" Font-Size="Medium" Text="0"></asp:Label>
                                </div>
                            </div>
                            <div class="table-responsive p-0" style="height: 300px;">
                                <asp:GridView ID="gvAllTickets" runat="server" CssClass="data-table table table-striped table-bordered table-sm text-nowrap" OnPageIndexChanging="gvAllTickets_PageIndexChanging" PageSize="100" AllowPaging="True">
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

