<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmSDAccount.aspx.cs" Inherits="HelpDesk_frmSDAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <asp:Repeater ID="rptAccount" runat="server" OnItemDataBound="rptAccount_ItemDataBound" OnItemCommand="rptAccount_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-lg-1 ml-4 pl-2">
                                            <asp:Button ID="btn" runat="server" CssClass="form-control  form-control-sm p-1 " Width="100px" CommandName='<%# Eval("UserScope") %>' Text='<%# Eval("UserScope") %>'></asp:Button>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="row ">
                                <div class="col-md-4">
                                    <asp:Label ID="lblsofname" runat="server" Text="User Details" Font-Size="Larger" ForeColor="Black"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-2 ">
                                    <div class="btn btn-sm elevation-1 ml-1 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                        <label class="mr-3 ml-1 mb-0">Export</label>
                                        <%--<asp:ImageButton ID="ImgBtnExport" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport_Click" />--%>
                                        <asp:LinkButton ID="ImgBtnExport" runat="server" OnClick="ImgBtnExport_Click">LinkButton</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive table-container">
                                <asp:GridView GridLines="None" ID="gvSDAccount" runat="server" AutoGenerateColumns="false" CssClass="data-table table table-striped table-bordered table-sm"
                                    Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EmpID" HeaderText="EmpID" NullDisplayText="NA" />
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" NullDisplayText="NA" />
                                        <asp:BoundField DataField="LoginName" HeaderText="Login Name" NullDisplayText="NA" />
                                        <asp:BoundField DataField="EmailID" HeaderText="Email ID" NullDisplayText="NA" />
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="rptAccount" />
            <asp:PostBackTrigger ControlID="ImgBtnExport" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

