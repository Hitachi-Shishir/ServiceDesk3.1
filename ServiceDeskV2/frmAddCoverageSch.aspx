﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddCoverageSch.aspx.cs" Inherits="frmAddCoverageSch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnAddSLA" Text="Coverage Schedule" runat="server" CssClass="btn btn-sm btnDisabled" OnClick="btnAddSLA_Click" />
                    <asp:Button ID="btnViewSLA" runat="server" Text-="View Details" CssClass="btn btn-sm btnEnabled" OnClick="btnViewSLA_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <asp:Panel ID="pnlAddSLA" runat="server" Visible="false">
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Name : <span title="*"></span>
                                        <asp:RequiredFieldValidator ID="rfvtxtCvrgname" runat="server" ControlToValidate="txtCvrgname" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SLA"></asp:RequiredFieldValidator>
                                    </label>


                                    <div class="col-sm-4 pr-5">

                                        <asp:TextBox ID="txtCvrgname" runat="server" CssClass="form-control  form-control-sm"></asp:TextBox>

                                    </div>
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Days Covered : <span title="*"></span>
                                        <asp:RequiredFieldValidator ID="rfvlstDaysCvrd" runat="server" ControlToValidate="lstDaysCvrd" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SLA"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">

                                        <asp:ListBox ID="lstDaysCvrd" runat="server" SelectionMode="Multiple" CssClass="form-control  form-control-sm chzn-select">

                                            <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                                            <asp:ListItem Text="Tuesday" Value="Tuesday"></asp:ListItem>
                                            <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                                            <asp:ListItem Text="Thursday" Value="Thursday"></asp:ListItem>
                                            <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                                            <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                                            <asp:ListItem Text="Sunday" Value="Sunday"></asp:ListItem>
                                        </asp:ListBox>

                                    </div>


                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Hours Covered: <span title="*"></span>
                                        <asp:RequiredFieldValidator ID="rfvrdblist" runat="server" ControlToValidate="rdblist" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SLA"></asp:RequiredFieldValidator>
                                    </label>


                                    <div class="col-sm-10 pr-5">

                                        <asp:RadioButtonList ID="rdblist" runat="server" RepeatDirection="Horizontal" CellPadding="20" CellSpacing="20" AutoPostBack="true" OnSelectedIndexChanged="rdblist_SelectedIndexChanged">
                                            <asp:ListItem Text="No Coverage" Value="NoCoverage" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="24 Hour Coverage" Value="24hrCoverage"></asp:ListItem>
                                            <asp:ListItem Text="Use these Hours" Value="UseTheseHours"></asp:ListItem>
                                        </asp:RadioButtonList>

                                    </div>



                                </div>
                                <asp:Panel ID="pnlcvrgSch" runat="server" Enabled="false">

                                    <div class="form-group row mt-3">
                                        <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                            Begin Hour : <span title="*"></span>
                                            <asp:RequiredFieldValidator ID="rfvtxtBeginHour" runat="server" ControlToValidate="txtBeginHour" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SLA"></asp:RequiredFieldValidator>
                                        </label>
                                        <div class="col-sm-4 pr-5">
                                            <asp:TextBox ID="txtBeginHour" runat="server" CssClass="form-control  form-control-sm time-picker"></asp:TextBox>
                                        </div>
                                        <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                            End  Hour : <span title="*"></span>
                                            <asp:RequiredFieldValidator ID="rfvtxtEndHour" runat="server" ControlToValidate="txtEndHour" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SLA"></asp:RequiredFieldValidator>
                                        </label>
                                        <div class="col-sm-4 pr-5">

                                            <asp:TextBox ID="txtEndHour"  runat="server" CssClass="form-control  form-control-sm time-picker"></asp:TextBox>

                                        </div>


                                    </div>
                                </asp:Panel>
                                <div class="form-row">
                                    <div class="col-md-3 offset-5 ">
                                        <asp:Button ID="btnInsertSLA" runat="server" Text="Save" class="btn btn-sm savebtn" OnClick="btnInsertSLA_Click" ValidationGroup="SLA" />
                                        <asp:Button ID="btnUpdateSLA" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateSLA_Click" ValidationGroup="SLA" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel_Click" CausesValidation="false" />
                                    </div>
                                </div>

                            </asp:Panel>
                            <asp:Panel ID="pnlViewSLA" runat="server">
                                <div class="row">
                                    <div class="col-lg-12 col-md-8 col-sm-6 graphs">
                                        <div class="xs">
                                            <div class="well1 white">
                                                <div class="card card-default">

                                                    <div class="card-body">
                                                        <div class="row ">
                                                            <div class="col-md-4">

                                                                <asp:Label ID="lblsofname" runat="server" Text="Coverage Schedule" Font-Size="Larger" ForeColor="Black"></asp:Label>

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
                                                            <asp:GridView GridLines="None" ID="gvSLA" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="data-table table table-striped table-bordered"
                                                                Width="100%" OnRowCommand="gvSLA_RowCommand" OnRowDataBound="gvSLA_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                                        <ItemTemplate>
                                                                            <%#Container.DataItemIndex+1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>



                                                                    <asp:BoundField DataField="ScdhuleName" HeaderText="Schedule Name" NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="DaysCovered" HeaderText="DaysCovered" NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="HoursCovered" HeaderText="HoursCovered" NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="BeginHour" HeaderText="Begin Hour" NullDisplayText="NA" />
                                                                    <asp:BoundField DataField="EndHour" HeaderText="End Hour" NullDisplayText="NA" />

                                                                    <asp:ButtonField ButtonType="Image" CommandName="UpdateSLA" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                                    <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteSLA" ItemStyle-Width="20px" ItemStyle-Height="5px" />
                                                                </Columns>
                                                               <%-- <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="10px" />
                                                                <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" />
                                                                <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="30px" CssClass="header" Font-Size="Small" />
                                                                <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" />
                                                                <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" />--%>
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
                        <div class="card-header">
                            New Request Type
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
            <asp:PostBackTrigger ControlID="btnAddSLA" />
            <asp:PostBackTrigger ControlID="ImgBtnExport" />
            <asp:PostBackTrigger ControlID="btnViewSLA" />
            <asp:PostBackTrigger ControlID="btnInsertSLA" />
            <asp:PostBackTrigger ControlID="rdblist" />
            <asp:PostBackTrigger ControlID="gvSLA" />
            <asp:PostBackTrigger ControlID="btnUpdateSLA" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

