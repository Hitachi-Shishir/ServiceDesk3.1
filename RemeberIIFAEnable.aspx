<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RemeberIIFAEnable.aspx.cs" Inherits="RemeberIIFAEnable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-md-12 graphs">
            <div class="card card-default">
                <div class="card-body">
                    <div class="row ">
                        <div class="col-md-4">
                            <label for="staticEmail" class="labelcolorl1 ">
                                Service Desk :<asp:RequiredFieldValidator ID="rfvddlOrg" runat="server" ControlToValidate="ddlOrg" ErrorMessage="*" InitialValue="0" Font-Bold="true" ForeColor="Red" ValidationGroup="Task">
                                </asp:RequiredFieldValidator>
                            </label>
                            <asp:DropDownList ID="ddlOrg" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm chzn-select" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label for="staticEmail" class="labelcolorl1 ">
                                User Name :
                            </label>
                            <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <label for="staticEmail" class="labelcolorl1 ">
                                Filter Type :<asp:RequiredFieldValidator ID="reqddlFIlterType" runat="server" ControlToValidate="ddlFIlterType" ErrorMessage="*" InitialValue="0" Font-Bold="true" ForeColor="Red" ValidationGroup="Task">
                                </asp:RequiredFieldValidator>
                            </label>
                            <asp:DropDownList ID="ddlFIlterType" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm chzn-select">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="30 Days Remember MFA" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2FA" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 p-4">
                            <asp:Button ID="btnGO" runat="server" Text="Go" CssClass="btn btn-success btn-sm" OnClick="btnGO_Click" ValidationGroup="Task" />
                            <asp:Button ID="Button1" runat="server" Text="Reset" CssClass="btn btn-danger btn-sm" OnClick="btnReset_Click" />
                        </div>
                    </div>
                    <div class="row py-2" id="RembMFA" runat="server" visible="false">
                        <div class="col-xl-12 col-lg-12">
                            <div class="table-responsive">
                                <asp:GridView ID="grd" HeaderStyle-Height="25px" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false"
                                    runat="server" Width="100%" CellPadding="10" BorderColor="#ede8e8" Class="data-table table table-striped table-bordered">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Sr No">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Name">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnid" Value='<%#Eval("UserID")%>' runat="server" />
                                                <asp:Label ID="lblUserNameN" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Login Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLoginNameN" runat="server" Text='<%#Eval("LoginName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Designation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesignationN" runat="server" Text='<%#Eval("Designation")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Org Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrgNameN" runat="server" Text='<%#Eval("OrgName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="30DaysRememberISMfa">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRememberISMfa" runat="server" Text='<%#Eval("RememberISMfa")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remaining Days">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemainingDaysN" runat="server" Text='<%#Eval("RemainingDays")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remove 30 Days Remb">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClick="lnkbtnDelete_Click"
                                                    OnClientClick="return confirm('Are you sure you want to Remove 30 Days Remember ?');"><i class="fa fa-trash"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <div class="row py-2" id="MFA" runat="server" visible="false">
                        <div class="col-xl-12 col-lg-12">
                            <div class="table-responsive">
                                <asp:GridView ID="grv" HeaderStyle-Height="25px" OnRowDataBound="grv_RowDataBound" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false"
                                    runat="server" Width="100%" CellPadding="10" BorderColor="#ede8e8" Class="data-table table table-striped table-bordered">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Sr No">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Name">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnuid" Value='<%#Eval("UserID")%>' runat="server" />
                                                <asp:HiddenField ID="hdnismfa" Value='<%#Eval("ISMfa")%>' runat="server" />
                                                <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Login Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLoginName" runat="server" Text='<%#Eval("LoginName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Designation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Org Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrgName" runat="server" Text='<%#Eval("OrgName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MFA Status" HeaderStyle-Width="20px">
                                            <ItemTemplate>
                                                <asp:Image ID="imgIsMfaStatus" runat="server" Style="width: 40%!important" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reset">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtn" ToolTip="Reset Status" runat="server" OnClientClick="return confirm('Are you sure you want to Reset it ?');"
                                                    OnClick="lnkBtn_Click">X</></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

