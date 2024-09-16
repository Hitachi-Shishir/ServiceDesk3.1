<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmEmailLogs.aspx.cs" Inherits="HelpDesk_frmEmailLogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
<style>
      .dataTables_filter {
          margin-top: -29px !important;
      }
      .dt-buttons > .btn-outline-secondary{
          padding:0.25rem 0.5rem!important;
          font-size: 0.875rem!important;
	
}
      .pagination{
	--bs-pagination-padding-x: 0.5rem;
	--bs-pagination-padding-y: 0.25rem;
	--bs-pagination-font-size: 0.875rem;
	--bs-pagination-border-radius: var(--bs-border-radius-sm);
    margin-top: -1.7rem!important;
}
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
           <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
    <div class="breadcrumb-title pe-3">Admin</div>
    <div class="ps-3">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb mb-0 p-0">
               
                <li class="breadcrumb-item active" aria-current="page"><i class="fa-regular fa-envelope"></i> Email logs </li>
            </ol>
        </nav>
    </div>

</div>

                    <div class="card">
                        <div class="card-body">
                            <div class="row d-none">
                                <div class="col-md-12" style="border-bottom: none">
                                    <asp:Label ID="lblheader" CssClass="headline" runat="server" Font-Size="Larger" Text="Email Logs"></asp:Label>
                                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                        <div class="table-responsive table-container" >
        <asp:GridView ID="gvAllTickets" runat="server" CssClass="data-table table table-striped table-bordered table-sm text-nowrap" DataKeyNames="ID"
            AutoGenerateColumns="True">
        </asp:GridView>
    </div>
                                </div>
                            </div>
                        
                        </div>
                    </div>

                
            <div class="modal" id="CategoryModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="card-header">
                            Select Colums
							<button type="button" class="close" data-dismiss="modal" onclick="javascript:window.location.reload()" aria-hidden="true">&times;</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="gvAllTickets" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

