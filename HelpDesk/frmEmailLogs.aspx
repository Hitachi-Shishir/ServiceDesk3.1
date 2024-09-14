<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmEmailLogs.aspx.cs" Inherits="HelpDesk_frmEmailLogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12 graphs">
                    <div class="card card-default">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12" style="border-bottom: none">
                                    <asp:Label ID="lblheader" CssClass="headline" runat="server" Font-Size="Larger" Text="Email Logs"></asp:Label>
                                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="table-responsive p-0" style="height: 400px">
                                <asp:GridView ID="gvAllTickets" runat="server" CssClass="data-table table table-striped table-bordered table-sm" DataKeyNames="ID"
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

