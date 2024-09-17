﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAllTicketsEngTransf.aspx.cs" Inherits="frmAllTicketsEngTransf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

            <div class="row ">
                <div class="col-md-12 graphs">

                    <div class="card card-default">

                        <div class="card-body">

                            <asp:Panel ID="pnlgridrow" runat="server">
                                <div class="row">
                                    <div class="col-md-12" style="border-bottom: none">
                                        <asp:Label ID="lblheader" CssClass="headline" runat="server" Font-Size="Larger" Text="ALL Engineer Tickets"></asp:Label>
                                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-md-1">
                                        <label class="labelcolorl1">Column</label>
                                        <br />
                                        <asp:ImageButton ID="imgcolumnfilter" runat="server" CssClass="ml-1" AlternateText="Column Chooser" ToolTip="Select Column" ImageAlign="left" ImageUrl="~/Images/New folder/columnfilter.png" OnClick="imgcolumnfilter_Click" />
                                        <asp:ImageButton ID="imgRowFilter" runat="server" AlternateText="Column Chooser" ToolTip="Select Column" ImageAlign="left" ImageUrl="~/Images/New folder/funnelfilter.png" OnClick="imgRowFilter_Click" OnClientClick="togglePanel(); return false;" />
                                    </div>
                                    <div class="col-md-2">
                                        <label class="labelcolorl1">Organization</label>
                                        <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="labelcolorl1">Request Type</label>
                                        <asp:DropDownList ID="ddlRequestType" runat="server" ToolTip="Select Desk Type" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">

                                        <div class="row">
                                            <div class="col-md-4 mr-0">
                                                <label class="labelcolorl1 ml-4">Action</label>
                                                <br />
                                                <asp:Button ID="btnDelteBulkTicket" runat="server" Text="Delete" ToolTip="Delete Ticket" CssClass="btn btn-sm cancelbtn" OnClick="btnDelteBulkTicket_Click" hidden />

                                                <asp:Button ID="btnPickupTicket" runat="server" Text="Transfer" ToolTip="Transfer" CssClass="btn btn-sm savebtn" OnClick="btnPickupTicket_Click" ValidationGroup="Pickup" />
                                            </div>
                                            <div class="col-md-8 ml-0">
                                                <label class="labelcolorl1 ml-4">
                                                    Reason For Change
																									<asp:RequiredFieldValidator ID="rfvtxtReason" runat="server" ControlToValidate="txtReason" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Pickup"></asp:RequiredFieldValidator>

                                                </label>
                                                <br />
                                                <asp:TextBox ID="txtReason" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="labelcolorl1">Paging</label>
                                        <br />
                                        <asp:Repeater ID="rptpageindexing" runat="server">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPage" Font-Size="Small" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%#Eval("Value") %>' Enabled='<%#Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div class="col-md-1">
                                        <label class="labelcolorl1">Size</label>
                                        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass-="form-control form-control-sm chzn-select" OnSelectedIndexChanged="PageSize_Changed">

                                            <asp:ListItem Text="50" Value="50" Selected="True" />
                                            <asp:ListItem Text="100" Value="100" />
                                            <asp:ListItem Text="150" Value="150" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-1   " hidden>
                                        <label class=" labelcolorl1">Ageing</label>
                                        <asp:DropDownList ID="ddlGetticketFilter" runat="server" CssClass="form-control form-control-sm   " Width="110px" ToolTip="Get Ticket" AutoPostBack="true" OnSelectedIndexChanged="ddlGetticketFilter_SelectedIndexChanged">
                                            <asp:ListItem Selected="True" Text="Get Tickets" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Last 1 hour" Value="Last1hour"></asp:ListItem>
                                            <asp:ListItem Text="Last 24 hours" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Last 30 days" Value="30"></asp:ListItem>
                                            <asp:ListItem Text="Last 90 days" Value="90"></asp:ListItem>
                                            <asp:ListItem Text="More than 90 days" Value="Morethan90Days"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <%--<div style="overflow-y: scroll; height: 500px">--%>
                            </asp:Panel>
                            <asp:Panel ID="pnlRowFilter" runat="server" Visible="false">
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtTicketNoFltr" runat="server" CssClass="form-control form-control-sm p-0" placeholder="Enter Ticket No"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtTickSumFltr" runat="server" CssClass="form-control form-control-sm" placeholder="Enter  Summary"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtPriorFltr" runat="server" CssClass="form-control form-control-sm" placeholder="Enter Priority"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtSeverityFltr" runat="server" CssClass="form-control form-control-sm" placeholder="Enter Severity"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtStatfltr" runat="server" CssClass="form-control form-control-sm" placeholder="Enter Status"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:DropDownList ID="ddlAssigneEmail" runat="server" CssClass-="form-control form-control-sm chzn-select"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnGridFilter" runat="server" Text="Go" ToolTip="Click Button to Get Ticket As Per Filter" CssClass="btn btn-sm savebtn mb-3 " OnClick="btnGridFilter_Click" />
                                        <asp:ImageButton ID="imgRemoveFilter" runat="server" ImageUrl="~/Images/reset1.png" ToolTip="Removes Filter" OnClick="imgRemoveFilter_Click" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnltickcount" runat="server">

                                <div style="zoom: 85%">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <asp:Button ID="btnOpenTicket" ToolTip="Ticket With Open Status" Width="180px" runat="server" Text="Open  (0)" CssClass="btn  btn-outline-success  fa-pull-left" OnClick="btnOpenTicket_Click" />
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnWipTicket" Width="180px" ToolTip="Tickets that are not resolved and open" runat="server" Text="WIP  (0)" CssClass="btn  btn-outline-warning " OnClick="btnWipTicket_Click" />
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnTicketAssigntoME" ToolTip="Tickets Assgined to me" Width="180px" runat="server" Text="Assigned (0)" CssClass="btn  btn-outline-info " OnClick="btnTicketAssigntoME_Click" />
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnAssignToOther" Width="180px" ToolTip="Tickets that are not assign" runat="server" Text="UnAssiged-Open(0)" CssClass="btn  btn-outline-secondary " OnClick="btnAssignToOther_Click" />
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnDueSoonTickets" Width="180px" ToolTip="Tickets that are goin to esclate  or Response goin to Missed" runat="server" Text="Due Soon  (0)" CssClass="btn  btn-outline-dark " OnClick="btnDueSoonTickets_Click" />
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnTicketEsclated" Width="180px" runat="server" ToolTip="Tickets that esclated or response missed" Text="Overdue  (0)" CssClass="btn  btn-outline-danger fa-pull-left " OnClick="btnTicketEsclated_Click" />
                                        </div>
                                    </div>
                            </asp:Panel>
                        </div>
                        <div style="zoom: 85%">
                            <div class="table-responsive p-0 mt-1" style="height: 400px;">

                                <asp:GridView ID="gvAllTickets" runat="server" CssClass="table table-head-fixed text-nowrap  " DataKeyNames="ID" AllowCustomPaging="True"
                                    AutoGenerateColumns="False" OnRowCommand="gvAllTickets_RowCommand" OnRowCreated="gvAllTickets_RowCreated" OnSorting="gvAllTickets_Sorting" OnRowDataBound="gvAllTickets_RowDataBound" AllowSorting="True" OnRowEditing="gvAllTickets_RowEditing">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30" ItemStyle-Height="5px">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="grdHeaderCheckBox(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                                        </asp:TemplateField>
                                        <asp:ButtonField ButtonType="Image" CommandName="EditTicket" HeaderText="Edit" ImageUrl="~/Images/edit.png" ItemStyle-Width="5px" ItemStyle-Height="10px" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" Visible="true">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Width="20px" Height="20px" Wrap="False" />
                                        </asp:ButtonField>

                                        <asp:TemplateField HeaderText="TicketNumber" ItemStyle-Font-Size="Smaller" SortExpression="TicketNumber" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTicketNumberColor" runat="server" Text='<%# Eval("color") %>' Font-Size="Smaller" Visible="false"></asp:Label>
                                                <asp:Label ID="lblTicketNumber" runat="server" Text='<%# Eval("TicketNumber") %>' Font-Size="Smaller" Visible="true"></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ServiceDesk" HeaderText="ServiceDesk" SortExpression="ServiceDesk" ItemStyle-Height="5px" ItemStyle-Font-Size="Smaller" Visible="true" />

                                        <%--	<asp:BoundField DataField="TicketNumber" HeaderText="TicketNumber" SortExpression="TicketNumber" ItemStyle-Height="5px" ItemStyle-Font-Size="Smaller" Visible="true" />--%>
                                        <asp:BoundField DataField="Summary" HeaderText="Summary" SortExpression="Summary" ItemStyle-Width="300px" HeaderStyle-Width="400px" HeaderStyle-Wrap="false" ItemStyle-Height="5px" ItemStyle-Wrap="true" ItemStyle-Font-Size="Smaller" Visible="true">
                                            <ItemStyle Wrap="True" />

                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Category" ItemStyle-Height="20px" SortExpression="Category" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategoryFK" runat="server" Text='<%# Eval("Category") %>' Font-Size="Smaller" Visible="false"></asp:Label>
                                                <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("Category") %>' Font-Size="Smaller" Visible="true"></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate" ItemStyle-Font-Size="Smaller" ItemStyle-Height="5px" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}" />

                                        <asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority" ItemStyle-Font-Size="Smaller" />
                                        <asp:TemplateField HeaderText="stage " ItemStyle-Width="150" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstagecode" runat="server" Font-Size="X-Small" CssClass=" badge badge-notifications" Text='<%# Eval("Stage") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status " ItemStyle-Width="150" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusCode" runat="server" Font-Size="X-Small" CssClass=" badge badge-notifications" ForeColor="White" BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("StatusColorCode").ToString())%>' Text='<%# Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--	<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ItemStyle-Font-Size="Smaller" />--%>
                                        <asp:BoundField DataField="Severity" HeaderText="Severity" SortExpression="Severity" ItemStyle-Font-Size="Smaller" ItemStyle-Height="5px" />
                                        <%--	<asp:TemplateField HeaderText="Description" SortExpression="Description" ItemStyle-Font-Size="Smaller" >
									
									<ItemTemplate>
										<asp:Label ID="lblDescription" runat="server" Font-Size="Smaller" Text='<%# Server.HtmlDecode(Eval("Description").ToString()) %>'> </asp:Label>
									</ItemTemplate>
								</asp:TemplateField>--%>
                                        <asp:BoundField DataField="TechLoginName" HeaderText="Assigne" SortExpression="TechLoginName" ItemStyle-Height="5px" NullDisplayText="UnAssigned" ItemStyle-Font-Size="Smaller" />
                                        <asp:BoundField DataField="SubmitterType" HeaderText="SubmitterType" SortExpression="SubmitterType" ItemStyle-Height="5px" ItemStyle-Font-Size="Smaller" />
                                        <asp:BoundField DataField="SubmitterName" HeaderText="SubmitterName" SortExpression="SubmitterName" ItemStyle-Height="5px" ItemStyle-Font-Size="Smaller" />
                                        <asp:BoundField DataField="SubmitterEmail" HeaderText="SubmitterEmail" SortExpression="SubmitterEmail" ItemStyle-Height="5px" ItemStyle-Font-Size="Smaller" />
                                        <asp:BoundField DataField="SubmitterPhone" HeaderText="SubmitterPhone" SortExpression="SubmitterPhone" ItemStyle-Height="5px" ItemStyle-Font-Size="Smaller" />
                                        <asp:BoundField DataField="DueDate" HeaderText="Expect. Response Dt" SortExpression="SubmitterPhone" ItemStyle-Height="5px" ItemStyle-Font-Size="Smaller" />
                                        <asp:BoundField DataField="ExpectedResolutionDt" HeaderText="Expect Resoution Dt " SortExpression="SubmitterPhone" ItemStyle-Height="5px" ItemStyle-Font-Size="Smaller" />
                                        <asp:BoundField DataField="location" HeaderText="Location " SortExpression="Location" ItemStyle-Height="5px" ItemStyle-Font-Size="Smaller" />

                                        <asp:BoundField DataField="SourceType" HeaderText="SourceType" SortExpression="SourceType" ItemStyle-Height="5px" ItemStyle-Font-Size="Smaller" />
                                    </Columns>
                                    <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="5px" />
                                    <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Left" Height="5px" VerticalAlign="NotSet" CssClass="header" />
                                    <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" Height="5px" />
                                    <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="5px" BorderColor="WhiteSmoke" CssClass="header sorting_asc" Font-Size="Small" />
                                    <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" Height="5px" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" BackColor="#EDEDED" />
                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" Height="5px" BorderStyle="Solid" BorderWidth="1px" />

                                </asp:GridView>
                            </div>
                            <%--	</div>--%>
                        </div>

                    </div>
                </div>

            </div>
            </div>
			
			<div class="modal" id="CategoryModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog" style="bottom: 20%">
                    <div class="modal-content">
                        <div class="card-header ">
                            Select Colums
								<button type="button" class=" fa-pull-right badge-danger" data-dismiss="modal" onclick="javascript:window.location.reload()" aria-hidden="true">&times;</button>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="checkbox checkbox-columns">
                                        <asp:CheckBoxList ID="chkcolumn" runat="server" RepeatDirection="Vertical" OnSelectedIndexChanged="chkcolumn_SelectedIndexChanged" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btngetCheckcolumn" runat="server" Text="Go" OnClick="btngetCheckcolumn_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="rptpageindexing" />
            <asp:AsyncPostBackTrigger ControlID="imgcolumnfilter" EventName="Click" />
            <asp:PostBackTrigger ControlID="btngetCheckcolumn" />
            <asp:PostBackTrigger ControlID="ddlGetticketFilter" />
            <asp:PostBackTrigger ControlID="ddlPageSize" />
            <asp:PostBackTrigger ControlID="btnDelteBulkTicket" />
            <asp:PostBackTrigger ControlID="gvAllTickets" />
            <asp:PostBackTrigger ControlID="imgRowFilter" />
            <asp:PostBackTrigger ControlID="ddlOrg" />
            <asp:PostBackTrigger ControlID="ddlRequestType" />
            <asp:PostBackTrigger ControlID="btnPickupTicket" />
            <asp:PostBackTrigger ControlID="btnGridFilter" />
            <asp:PostBackTrigger ControlID="btnOpenTicket" />
            <asp:PostBackTrigger ControlID="btnWipTicket" />
            <asp:PostBackTrigger ControlID="btnTicketAssigntoME" />
            <asp:PostBackTrigger ControlID="btnAssignToOther" />
            <asp:PostBackTrigger ControlID="btnDueSoonTickets" />
            <asp:PostBackTrigger ControlID="btnTicketEsclated" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

