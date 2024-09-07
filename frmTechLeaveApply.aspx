<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmTechLeaveApply.aspx.cs" Inherits="frmTechLeaveApply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
     <asp:ScriptManager ID="scrmg" runat="server" EnablePageMethods="true">
 </asp:ScriptManager>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
     <ContentTemplate>
    <div class="container-fluid">
        <div class="card p-3">
            <div class="row">
                <div class="col-md-3">
                    <label>Organization</label>
                    <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label>Technician</label>
                    <asp:DropDownList ID="ddltech" runat="server" CssClass="form-select form-select-sm single-select-optgroup-field"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <label>Leave From Date</label>
                    <asp:TextBox runat="server" ID="txtfrmDate" class="form-control form-control-sm datepicker"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <label>Leave To Date</label>
                    <asp:TextBox runat="server" ID="txttoDate" class="form-control form-control-sm datepicker"></asp:TextBox>
                </div>
                <div class="col-md-2 p-4">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success btn-sm" OnClick="btnSave_Click" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger btn-sm" OnClick="btnReset_Click" />
                </div>
            </div>
           

            <div class="row py-2">
                <div class="col-xl-12 col-lg-12">
                    <div class="table-responsive">
                        <asp:GridView ID="grv" HeaderStyle-Height="25px" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false"
                            runat="server" Width="100%" Class="data-table table table-striped table-bordered">
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Sr No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Technician">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnid" Value='<%#Eval("id")%>' runat="server" />
                                        <asp:Label ID="lblTechName" runat="server" Text='<%#Eval("TechName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leave FromDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeaveFromdate" runat="server" Text='<%#Eval("LeaveFromdate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leave ToDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeaveTodate" runat="server" Text='<%#Eval("LeaveTodate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leave ApplyDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplyDate" runat="server" Text='<%#Eval("ApplyDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leave ApplyBy">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAppliedbyUserid" runat="server" Text='<%#Eval("AppliedbyUserid")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkdelete" OnClick="lnkdelete_Click" OnClientClick="return confirm('Are you sure you want to Delete this ?');">
                                <label style="color:red; font-weight: bold;">X</label>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>
    </div>
         </ContentTemplate>
     <Triggers>
         <asp:PostBackTrigger ControlID="ddlOrg" />
     </Triggers>
     </asp:UpdatePanel>
</asp:Content>

