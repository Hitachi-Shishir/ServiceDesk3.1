<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddLocation.aspx.cs" Inherits="Admin_frmAddLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scrmg" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnAddDep" Text="Add Location" runat="server" CssClass="btn btn-sm btn-dark" OnClick="btnAddDep_Click" />
                    <asp:Button ID="btnViewDep" runat="server" Text-="View Details" CssClass="btn btn-sm savebtn" OnClick="btnViewDep_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <asp:Panel ID="pnlAddDep" runat="server" Visible="false">
                                <div class="row" style="border-bottom: 1px solid darkgrey">
                                    <div class="col-lg-12 col-md-6 col-sm-4">
                                        <label>Add Location</label>
                                    </div>
                                </div>
                                <div class="form-group row mt-5">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Location Code :
                                <asp:RequiredFieldValidator ID="RfvtxtLocationCode" runat="server" ControlToValidate="txtLocationCode" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                    </label>

                                    <div class="col-sm-4 pr-5">

                                        <asp:TextBox ID="txtLocationCode" runat="server" CssClass="form-control form-control-sm" AutoComplete="off"></asp:TextBox>
                                    </div>
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Location Name :
                                <asp:RequiredFieldValidator ID="rfvtxtLocationName" runat="server" ControlToValidate="txtLocationName" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="btnSave"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtLocationName" runat="server" CssClass="form-control form-control-sm" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group mt-2">
                                    <div class="col-md-3 offset-5">
                                        <asp:Button ID="btnTypeAdd" runat="server" CssClass="btn btn-sm savebtn" Text="Save" ValidationGroup="btnSave" OnClick="btnTypeAdd_Click" />
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-sm savebtn" Text="Update" ValidationGroup="btnSave" OnClick="btnUpdate_Click" />
                                        <asp:Label ID="lblsuccess" runat="server" Text=""></asp:Label>
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-sm cancelbtn" OnClick="btnCancel_Click" CausesValidation="false" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlViewDepart" runat="server">
                                <div class="row">
                                    <div class="col-md-8 graphs">
                                        <div class="card  ">
                                            <div class="card-body">
                                                <div class="row ">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="lblsofname" runat="server" Text="Location Details" Font-Size="Larger" ForeColor="Black"></asp:Label>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2 ">
                                                        <div class="btn btn-sm shadow-lg ml-1 mr-0 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                            <label class="mr-2  mb-0">Export</label>
                                                            <asp:ImageButton ID="ImgBtnExport" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success" OnClick="ImgBtnExport_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <asp:GridView GridLines="None" ID="gvstate" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="data-table table table-striped table-bordered table-sm"
                                                    Width="100%" OnRowCommand="gvstate_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="LocCode" HeaderText="Location Code" NullDisplayText="0" />
                                                        <asp:BoundField DataField="LocName" HeaderText="Location Name" NullDisplayText="0" />
                                                        <asp:ButtonField ButtonType="Image" CommandName="SelectState" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                        <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />
                                                    </Columns>
                                                </asp:GridView>
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
    </asp:UpdatePanel>
</asp:Content>

