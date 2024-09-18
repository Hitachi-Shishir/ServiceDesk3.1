<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddKnowledgeBase.aspx.cs" Inherits="frmAddKnowledgeBase"  ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="assets/plugins/summernote/jquery.js"></script>
    <link href="assets/plugins/summernote/summernote-bs4.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>

            <div class="row mb-1">
                <div class="col-md-6 col-lg-12 col-sm-4">
                    <div class="card card-default">

                        <div class="card-body">

                            <div class="row">
                                <div class="col-md-6 col-lg-12 col-sm-4">
                                    <label class="cardheader">New Resolution</label>
                                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Button ID="btnAddPriority" Text="Add Resolution" runat="server" CssClass="btn btn-sm btnDisabled" OnClick="btnAddPriority_Click" />
                                    <asp:Button ID="btnViewPriority" runat="server" Text-="View Details" CssClass="btn btn-sm btnEnabled" OnClick="btnViewPriority_Click" />
                                </div>
                            </div>


                            <asp:Panel ID="pnlIncident" runat="server">
                                <div class="form-group row ">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                        Summary : 
                                                    <asp:RequiredFieldValidator ID="RfvtxtSummary" runat="server" ControlToValidate="txtSummary" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-10 pr-5">
                                        <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group row ">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                        Issue in Detail : 
                                                 <asp:RequiredFieldValidator ID="RfvtxtDescription" runat="server" ControlToValidate="txtDescription" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-10 pr-5">
                                        <%--	<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" MaxLength="500" Height="200px"></asp:TextBox>--%>
                                        <asp:TextBox ID="txtDescription" runat="server" Rows="5" Columns="5" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row ">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                        View To User
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:CheckBox ID="chkViewToUser" runat="server" CssClass="form-control form-control-sm"></asp:CheckBox>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="Addticket" OnClick="btnSubmit_Click" CssClass="btn btn-sm savebtn " />
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="Addticket" OnClick="btnUpdate_Click" CssClass="btn btn-sm savebtn " />

                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" CssClass="btn btn-sm cancelbtn " />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlShowPriority" runat="server">
                                <div class="row">
                                    <div class="col-md-8 graphs">
                                        <div class="xs">
                                            <div class="well1 white">
                                                <div class="card card-default">

                                                    <div class="card-body">
                                                        <div class="row ">
                                                            <div class="col-md-4">

                                                                <asp:Label ID="lblsofname" runat="server" Text="Resolution Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

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
                                                        <asp:GridView GridLines="None" ID="gvResolution" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="data-table table table-striped table-bordered table-sm"
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
                                                                <asp:ButtonField ButtonType="Image" CommandName="SelectState" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                                <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />
                                                            </Columns>
                                                        </asp:GridView>
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

