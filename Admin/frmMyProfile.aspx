﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmMyProfile.aspx.cs" Inherits="Admin_frmMyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="row mt-4">
                <div class="col-md-12">
                    <div class="card rounded-4">
                        <div class="card-body p-4">
                            <div class="position-relative mb-5">
                                <button type="button" class="btn btn-grd-primary btn-sm rounded-circle position-absolute" style="top: 10px; right: 357px; z-index: 100;"
                                    onclick="document.getElementById('<%= FileUpload1.ClientID %>').click();">
                                    <i class="fas fa-plus"></i>
                                </button>
                                                                <label>
                                   
<asp:RequiredFieldValidator ID="rfvFileUpload1" runat="server" ControlToValidate="FileUpload1"
    ErrorMessage="Required" ForeColor="Red" ValidationGroup="ImgUpload"></asp:RequiredFieldValidator>
                                </label>

                                <!-- Hidden File Upload Control -->
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-sm d-none" onchange="this.form.submit();" />

                                <!-- Button with Plus Icon (using Font Awesome) -->


                                <asp:RegularExpressionValidator ID="regFileUpload1" runat="server" ForeColor="Red"
                                    ErrorMessage="Only .jpeg or .JPEG or .gif or .GIF or .png or .PNG"
                                    ValidationExpression="^.*\.(jpg|jpeg|JPEG|gif|GIF|png|PNG)$" ControlToValidate="FileUpload1"
                                    ValidationGroup="ImgUpload">
                                </asp:RegularExpressionValidator>
                                <img src="assets/images/gallery/profile-cover.png" class="img-fluid rounded-4 shadow" alt="">

                                <div class="profile-avatar position-absolute top-100 start-50 translate-middle">
                                    <asp:Image ID="img" runat="server" class="img-fluid rounded-circle p-1 bg-grd-danger shadow" Width="170" Height="170" alt="" />
                                </div>
                            </div>


                            <div class="profile-info pt-5 d-flex align-items-center justify-content-between">
                                <div class="">
                                    <asp:Label ID="lblUserName" runat="server" CssClass="h3" Text="Label"></asp:Label>
                                    <asp:Label ID="lblEmpId" runat="server" CssClass="h5 opacity-75" Text="Label"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblEmailID" runat="server" Text="Label" class="mb-0 mt-1"></asp:Label>
                                </div>
                                <div class="">
                                    <label class="form-label">Login ID : </label>
                                    <asp:Label ID="lblLoginID" runat="server" Text="Label"></asp:Label> <br />
                                    <label  class="form-label">User Role :
                                    </label>
                                      <asp:Label ID="lblUserRole" runat="server" Text="Label"></asp:Label>
                                </div>

                            </div>
                            <div class="kewords d-flex align-items-center gap-3 mt-4 overflow-x-auto">

                                <asp:Label ID="lblDesignation" class="btn btn-sm btn-light rounded-5 px-4" runat="server" Text="Label" data-bs-toggle="tooltip" data-bs-placement="left" title="Designation"></asp:Label>
                                <asp:Label ID="lblDomainType" runat="server" class="btn btn-sm btn-light rounded-5 px-4" Text="Label" data-bs-toggle="tooltip" data-bs-placement="left" title="Domain Type"></asp:Label>
                                <asp:Label ID="lblContactNo" runat="server" class="btn btn-sm btn-light rounded-5 px-4" Text="Label" data-bs-toggle="tooltip" data-bs-placement="left" title="Contact No"></asp:Label>
                            </div>
                            <div class="mt-4">
                                <asp:CheckBox Visible="false" ID="chkTheme" AutoPostBack="true" runat="server" ToolTip="The theme cannot be modified by anyone except you." Text=" Make the theme consistent for everyone." OnCheckedChanged="chkTheme_CheckedChanged" />

                            </div>

                            
            <div id="toggle" runat="server" visible="false"  class="d-flex align-items-center gap-3 my-3" >
                <asp:RadioButton ID="rbdBlueTheme" Text="blue-theme" runat="server" GroupName="theme"  AutoPostBack="true" OnCheckedChanged="Theme_CheckedChanged" />
                <asp:RadioButton ID="rbdLightTheme" Text="light" runat="server" GroupName="theme" AutoPostBack="true" OnCheckedChanged="Theme_CheckedChanged" />
                <asp:RadioButton ID="rbdDarkTheme" Text="dark" runat="server" GroupName="theme" AutoPostBack="true" OnCheckedChanged="Theme_CheckedChanged" />
                <asp:RadioButton ID="rbdSemiDarkTheme" Text="semi-dark" runat="server" GroupName="theme" AutoPostBack="true" OnCheckedChanged="Theme_CheckedChanged" />
                <asp:RadioButton ID="rbdBoderedTheme" Text="bodered-theme" runat="server" GroupName="theme" AutoPostBack="true" OnCheckedChanged="Theme_CheckedChanged" />

            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 d-none">
                    <div class="card rounded-4 border-top border-4 border-primary border-gradient-1">
                        <div class="card-body p-4">
                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <div class="row">
                                    <div class="col-md-12">
                                    </div>
                                    <div class="col-md-12">
                                        <label>EmpID</label>

                                    </div>
                                    <div class="col-md-12">
                                        <label>UserName</label>

                                    </div>
                                    <div class="col-md-12">
                                        <label>EmailID</label>

                                    </div>
                                    <div class="col-md-12">
                                    </div>
                                    <div class="col-md-12">
                                        <label>User Role</label>
                                      
                                    </div>
                                    <div class="col-md-12">
                                        <label>ContactNo</label>
                                    </div>
                                    <div class="col-md-12">
                                        <label>Designation</label>

                                    </div>
                                    <div class="col-md-12">
                                        <label>Domain Type</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4" visible="false" runat="server" id="abc">
                    <div class="card rounded-4 border-top border-4 border-primary border-gradient-1">
                        <div class="card-body p-4">
                            <div class="d-flex align-items-start justify-content-between mb-3">
                                <asp:DetailsView ID="DetailsCheckInAsset" runat="server" CssClass="table" Style="border-collapse: collapse; border: 0px solid #ffffff00;"
                                    AllowPaging="True"
                                    AutoGenerateRows="False"
                                    GridLines="None" OnPageIndexChanging="DetailsCheckInAsset_PageIndexChanging">
                                    <%--<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
<EditRowStyle BackColor="#999999" />
<FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />--%>
                                    <Fields>
                                        <asp:BoundField DataField="EmpID" HeaderText="EmpID" />
                                        <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                        <asp:BoundField DataField="EmailID" HeaderText="EmailID" />
                                        <asp:BoundField DataField="LoginName" HeaderText="Login ID" />
                                        <asp:BoundField DataField="UserRole" HeaderText="User Role" />
                                        <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                                        <asp:BoundField DataField="Designation" HeaderText="Designation" />
                                        <asp:BoundField DataField="DomainType" HeaderText="Domain Type" />

                                    </Fields>
                                    <%--<RowStyle BackColor="#fafafa" BorderColor="#e3e4e6" BorderWidth="1px" CssClass="font_label" Font-Size="Medium" />
<FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" CssClass="font_label" />
<PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Center" />
<HeaderStyle BackColor="#e3e4e6" Font-Bold="True" ForeColor="#000000" Height="30px" CssClass="font_label" Font-Size="Medium" />
<EditRowStyle BackColor="#EDEDED" BorderColor="#e3e4e6" BorderStyle="Solid" CssClass="font_label" BorderWidth="1px" Font-Size="Medium" />
<AlternatingRowStyle BackColor="White" BorderColor="#e3e4e6" BorderStyle="Solid" CssClass="font_label" BorderWidth="1px" />--%>
                                </asp:DetailsView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row d-none">

                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                              
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                   

                                </div>
                                <%--<div class="col-md-2 mt-4 ">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" ValidationGroup="ImgUpload" CssClass="btn btn-sm" Style="background: linear-gradient(to right,#4A68DF,#A1C4FF)" />
                                </div>--%>
                            </div>
                            <div class="row">

                                <div class="row" hidden>
                                    <div class="col-md-6">
                                        <asp:Image ID="showimg" runat="server" Width="300" Height="200" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
          
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="btnUpload" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

