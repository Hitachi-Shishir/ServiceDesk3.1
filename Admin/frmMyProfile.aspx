<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmMyProfile.aspx.cs" Inherits="Admin_frmMyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
                <div class="breadcrumb-title pe-3">Admin</div>
                <div class="ps-3">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb mb-0 p-0">

                            <li class="breadcrumb-item active" aria-current="page"><i class="fa-solid fa-user"></i> Profile </li>
                        </ol>
                    </nav>
                </div>

            </div>
            <div class="row">
            <div class="col-md-8">   <div class="card rounded-4">
       <div class="card-body p-4">
           <div class="position-relative mb-5">
               <img src="assets/images/gallery/profile-cover.png" class="img-fluid rounded-4 shadow" alt="">

               <div class="profile-avatar position-absolute top-100 start-50 translate-middle">
                   <asp:Image ID="img" runat="server" class="img-fluid rounded-circle p-1 bg-grd-danger shadow" Width="170" Height="170" alt="" />

               </div>
           </div>
         
           <div class="profile-info pt-5 d-flex align-items-center justify-content-between">
               <div class="">
                   <h3>Jhon Deo</h3>
                   <p class="mb-0">
                       Engineer at BB Agency Industry<br>
                       New York, United States
                   </p>
               </div>
               <div class="">
                   <a href="javascript:;" class="btn btn-grd-primary rounded-5 px-4"><i class="bi bi-chat me-2"></i>Send Message</a>
               </div>
           </div>
           <div class="kewords d-flex align-items-center gap-3 mt-4 overflow-x-auto">
               <button type="button" class="btn btn-sm btn-light rounded-5 px-4">UX Research</button>
               <button type="button" class="btn btn-sm btn-light rounded-5 px-4">CX Strategy</button>
               <button type="button" class="btn btn-sm btn-light rounded-5 px-4">Management</button>
           </div>
       </div>
   </div></div>
         
            <div class="col-md-4">
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
            </div><div class="row">
               
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <label>Update Photo</label>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label>
                                        Choose Photo
			      <asp:RequiredFieldValidator ID="rfvFileUpload1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Required" ForeColor="Red" ValidationGroup="ImgUpload"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:FileUpload ID="FileUpload1" CssClass="form-control-sm" runat="server" />
                                    <asp:RegularExpressionValidator ID="regFileUpload1" runat="server" ForeColor="Red" ErrorMessage="Only .jpeg or .JPEG or .gif or .GIF or .png or .PNG" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpg|.jpeg|.JPEG|.gif|.GIF|.png|.PNG)$" ControlToValidate="FileUpload1" ValidationGroup="ImgUpload">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-2 mt-4 ">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" ValidationGroup="ImgUpload" CssClass="btn btn-sm" Style="background: linear-gradient(to right,#4A68DF,#A1C4FF)" />
                                </div>
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
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

