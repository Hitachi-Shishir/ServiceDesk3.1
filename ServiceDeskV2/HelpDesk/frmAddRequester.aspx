<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmAddRequester.aspx.cs" Inherits="HelpDesk_frmAddRequester" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="row mb-1">
                <div class="col-lg-12 col-md-6 col-sm-4">
                    <asp:Button ID="btnAddRequester" runat="server" Text="Add Requester" CausesValidation="false" OnClick="btnAddRequester_Click" />
                    <asp:Button ID="btnimportUser" runat="server" Text="Import Users" CausesValidation="false" OnClick="btnimportUser_Click" />
                    <asp:Button ID="btnViewUsers" runat="server" Text="View Users" CausesValidation="false" OnClick="btnViewUsers_Click" />
                </div>
            </div>
            <asp:Panel ID="pnlAddRequester" Visible="false" runat="server">

                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-12" style="border-bottom: 1px solid lightgrey">
                                        <label class="form-label">New Requester</label>
                                    </div>

                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Login Name<span class="red">*</span>
                                        <asp:RequiredFieldValidator ID="rfvtxtTechLoginName" runat="server" ControlToValidate="txtTechLoginName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtTechLoginName" class="form-control form-control-sm" runat="server" />
                                    </div>

                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Employee ID<span class="red">*</span>
                                        <asp:RequiredFieldValidator ID="rfvtxtEmployeeID" runat="server" ControlToValidate="txtEmployeeID" ErrorMessage="*" ForeColor="Red" ValidationGroup="SearchUser"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <div class="input-group input-group-sm ">
                                            <asp:TextBox ID="txtEmployeeID" runat="server" class="form-control form-control-sm" />
                                            <div class="input-group-append">
                                                <asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" Width="30" ValidationGroup="SearchUser" BackColor="blue" ImageUrl="~/Images/icons_search.png"></asp:ImageButton>
                                            </div>
                                        </div>
                                    </div>



                                </div>

                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        First Name<span class="red">*</span>
                                        <asp:RequiredFieldValidator ID="rfvtxtFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtFirstName" runat="server" class="form-control form-control-sm" />
                                    </div>
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Last Name<span class="red">*</span>

                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtLastName" runat="server" class="form-control form-control-sm" />
                                    </div>


                                </div>

                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Password<span class="red">*</span>
                                        <asp:RegularExpressionValidator ID="regtxtPassword" runat="server" ControlToValidate="txtPassword"
                                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}"
                                            ErrorMessage="Invalid Password" ForeColor="Red" Display="Dynamic" />
                                        <asp:RequiredFieldValidator ID="rfvtxtPassword" Display="Dynamic" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-sm" TextMode="Password" />
                                        <div>
                                            <a href="#" title="hello" alt=" 
								Minimum 8 and Maximum 10 characters 
								 at least 1 Uppercase Alphabet, 1 Lowercase Alphabet,
								1 Number and 1 Special Character"
                                                class="tooltipcustom"><i class="fa fa-info-circle"></i></a>
                                        </div>
                                    </div>

                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Confirm Password<span class="red">*</span>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtConfirmPassword"
                                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}" Display="Dynamic"
                                            ErrorMessage="Invalid Password" ForeColor="Red" />

                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control form-control-sm" TextMode="Password">
								
                                        </asp:TextBox>
                                        <a href="#" title="hello" alt=" 
								Minimum 8 and Maximum 10 characters 
								 at least 1 Uppercase Alphabet, 1 Lowercase Alphabet,
								1 Number and 1 Special Character"
                                            class="tooltipcustom"><i class="fa fa-info-circle"></i></a>
                                    </div>


                                </div>
                                <div class="row mt-3">
                                    <div class="col-md-12" style="border-bottom: 1px solid lightgrey">
                                        <label class="form-label">Contact Information</label>
                                    </div>

                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-lg-2 col-md-4 col-sm-6 labelcolorl1 pl-5">
                                        Email<span class="red">*</span>
                                        <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail"
                                            ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                            Display="Dynamic" ErrorMessage="Invalid Email " />

                                        <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtEmail" class="form-control form-control-sm" runat="server" TextMode="Email" />
                                    </div>
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Phone<span class="red">*</span>
                                        <asp:RegularExpressionValidator ID="regPhone" runat="server"
                                            ControlToValidate="txtPhone" ErrorMessage="Invalid Mobile No" Display="Dynamic" ForeColor="Red"
                                            ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="rfvtxtPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtPhone" class="form-control form-control-sm" runat="server" TextMode="Phone" MaxLength="10" />
                                    </div>
                                </div>


                                <div class="row mt-4">
                                    <div class="col-md-12" style="border-bottom: 1px solid lightgrey">
                                        <label class="form-label">Department Details</label>
                                    </div>

                                </div>
                                <div class="form-group row mt-3">


                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Organization:
                    
									<asp:RequiredFieldValidator ID="rfvddlOrg" runat="server" ControlToValidate="ddlOrg" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-4">
                                        Location: 
                                                   <asp:RequiredFieldValidator ID="rfvddlLocation" runat="server" ControlToValidate="ddlLocation" ValidationGroup="Addticket" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control form-control-sm chzn-select"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Department<span class="red">*</span>
                                        <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ControlToValidate="ddlDepartment" InitialValue="0" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:DropDownList ID="ddlDepartment" class="form-control form-control-sm chzn-select	" runat="server" />
                                    </div>
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Job Title<span class="red">*</span>
                                        <asp:RequiredFieldValidator ID="rfvtxtJobTitle" runat="server" ControlToValidate="txtJobTitle" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:TextBox ID="txtJobTitle" runat="server" class="form-control form-control-sm" />
                                    </div>
                                </div>
                                <div class="form-group row" style="border-bottom: 1px solid lightgrey">
                                    <asp:CheckBox ID="chkEnableTechnician" runat="server" AutoPostBack="true" OnCheckedChanged="chkEnableTechnician_CheckedChanged" />
                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                        Mark This User As Technician

                                    </label>

                                </div>
                                <asp:Panel ID="pnlEnableTechnician" runat="server" Visible="false">
                                    <div class="form-group row" style="border-bottom: 1px solid lightgrey">
                                        <label for="staticEmail" class="col-sm-6 col-form-label">
                                            Category Association<span class="red">*</span>

                                        </label>
                                    </div>

                                    <div class="form-group row mt-3">


                                        <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                            Request Type:
                    
									<asp:RequiredFieldValidator ID="rfvddlRequestType" runat="server" ControlToValidate="ddlRequestType" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>
                                        <div class="col-sm-4 pr-5">
                                            <asp:DropDownList ID="ddlRequestType" runat="server" CssClass="form-control form-control-sm chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>


                                        <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                            Category:
                    
									<asp:RequiredFieldValidator ID="rfvddlCategory1" runat="server" ControlToValidate="ddlCategory1" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech"></asp:RequiredFieldValidator>
                                        </label>
                                        <div class="col-sm-4 pr-5">
                                            <asp:DropDownList ID="ddlCategory1" runat="server" CssClass="form-control form-control-sm chzn-select">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </asp:Panel>
                                <div class="form-group row" style="border-bottom: 1px solid lightgrey">
                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                        Role & Scope

                                    </label>
                                </div>
                                <div class="form-group row mt-3 ">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Menu Role:
                    
									<asp:RequiredFieldValidator ID="rfvddlUserRole" runat="server" ControlToValidate="ddlUserRole" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:DropDownList ID="ddlUserRole" runat="server" CssClass="form-control form-control-sm chzn-select">
                                        </asp:DropDownList>
                                    </div>


                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        User Scope:
                    
									<asp:RequiredFieldValidator ID="rfvddlUserScope" runat="server" ControlToValidate="ddlUserScope" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:DropDownList ID="ddlUserScope" runat="server" CssClass="form-control form-control-sm chzn-select">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row mt-3">
                                    <label for="staticEmail" class="col-sm-2 labelcolorl1 pl-5">
                                        Custom field Role:
                    
									<asp:RequiredFieldValidator ID="rfvddlSDRole" runat="server" ControlToValidate="ddlSDRole" InitialValue="0" ErrorMessage="Required" Font-Bold="true" ForeColor="Red" ValidationGroup="Tech"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-4 pr-5">
                                        <asp:DropDownList ID="ddlSDRole" runat="server" CssClass="form-control form-control-sm chzn-select">
                                            <asp:ListItem Selected="True" Text="----Select Role----" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Master" Value="Master"></asp:ListItem>
                                            <asp:ListItem Text="ITManager" Value="ITManager"></asp:ListItem>
                                            <asp:ListItem Text="CRM" Value="CRM"></asp:ListItem>
                                            <asp:ListItem Text="ITEngineer" Value="ITEngineer"></asp:ListItem>
                                            <asp:ListItem Text="UAT" Value="UAT"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mt-1 pb-5">
                                    <div class="col-md-12" style="border-bottom: 1px solid lightgrey">
                                    </div>

                                </div>
                                <div class="form-row">
                                    <div class="col-md-3 ">

                                        <asp:Button ID="btnInsertTechnician" runat="server" Text="Save" OnClick="btnInsertTechnician_Click" class="btn btn-sm savebtn" ValidationGroup="Tech"></asp:Button>
                                        <asp:Button ID="btnUpdateTechnician" runat="server" Text="Update" Visible="false" class="btn btn-sm savebtn" OnClick="btnUpdateTechnician_Click" ValidationGroup="ReqType" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-sm  cancelbtn" OnClick="btnCancel_Click" CausesValidation="false" />
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlShowUsers" runat="server">

                <div class="row">
                    <div class="col-md-12 graphs">
                        <div class="xs">
                            <div class="well1 white">
                                <div class="card card-default">

                                    <div class="card-body">
                                        <div class="row ">
                                            <div class="col-md-4">

                                                <asp:Label ID="lblsofname" runat="server" Text="Request Type Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

                                            </div>

                                            <div class="col-md-2  offset-6">
                                                <div class="btn btn-sm elevation-1 ml-5 " style="padding: 0px; margin-bottom: 10px; padding-top: 1px">
                                                    <label class="mr-2 ml-1 mb-0">Export</label>
                                                    <asp:ImageButton ID="ImgBtnExport" runat="server" ImageUrl="~/Images/New folder/excelnew.png" CssClass="fa-pull-right btn-outline-success mr-1" OnClick="ImgBtnExport_Click" />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="table-responsive p-0" style="height: 400px; width: 100%">
                                            <asp:GridView GridLines="None" ID="gvTechnician" runat="server" DataKeyNames="UserID" AutoGenerateColumns="false" CssClass="data-table table table-striped table-bordered"
                                                Width="100%" OnRowCommand="gvTechnician_RowCommand" OnRowDataBound="gvTechnician_RowDataBound">
                                                <Columns>
                                                    <asp:ButtonField ButtonType="Image" CommandName="SelectTech" HeaderText="Edit" ImageUrl="~/images/edit23.png" ItemStyle-Width="20px" />
                                                    <asp:ButtonField HeaderText="Delete" ButtonType="Image" ImageUrl="~/Images/New folder/delnew.png" CommandName="DeleteEx" ItemStyle-Width="20px" ItemStyle-Height="5px" />
                                                    <asp:TemplateField HeaderText="Sr.No." ItemStyle-Width="20">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:BoundField DataField="EmpID" HeaderText="EmpID" NullDisplayText="NA" />
                                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" NullDisplayText="NA" />
                                                    <asp:BoundField DataField="LastName" HeaderText="LastName" NullDisplayText="NA" />
                                                    <asp:BoundField DataField="LoginName" HeaderText="LoginName" NullDisplayText="NA" />
                                                    <asp:BoundField DataField="EmailID" HeaderText="EmailID" NullDisplayText="NA" />
                                                    <asp:TemplateField HeaderText="User Scope">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblScopeID" runat="server" Text='<%# Eval("UserScopeID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblScopeName" runat="server" Text='<%# Eval("UserScope") %>' Visible="true"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="UserRole" HeaderText="UserRole" NullDisplayText="NA" />

                                                    <asp:BoundField DataField="Designation" HeaderText="JobTitle" NullDisplayText="NA" />
                                                    <asp:TemplateField HeaderText="Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepCode" runat="server" Text='<%# Eval("DepCode") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblDepName" runat="server" Text='<%# Eval("DepartmentName") %>' Visible="true"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ContactNo" HeaderText="Mobile" NullDisplayText="NA" />
                                                    <%--<asp:TemplateField HeaderText=" Category Association">
														<ItemTemplate>
															<asp:Label ID="lblDesk" runat="server" Text='<%# Eval("DeskRef") %>' Visible="false"></asp:Label>
															<asp:Label ID="lblCategoryID" runat="server" Text='<%# Eval("CategoryAssociation") %>' Visible="false"></asp:Label>
															<asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("CategoryCodeRef") %>'></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText=" Organization">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOrgFk" runat="server" Text='<%# Eval("Org_ID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblOrgName" runat="server" Text='<%# Eval("OrgName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Location">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLocCode" runat="server" Text='<%# Eval("LocCode") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblLocName" runat="server" Text='<%# Eval("LocName") %>' Visible="true"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="SDRole" HeaderText="CustomFieldRole" NullDisplayText="NA" />
                                                </Columns>
                                                <%--<RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="10px" />
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
            <asp:Panel ID="pnlImportUser" runat="server" Visible="false">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-2">
                                        <label class="labelcolorl1">
                                            Select Users(s) :
                                          
                                        </label>
                                    </div>
                                    <div class="col-md-3">

                                        <%--<div class="custom-file">--%>


                                        <asp:FileUpload ID="customFile" CssClass="form-control form-control-sm p-0" runat="server" />
                                        <%--<label class="custom-file-label" for="customFile">Choose File</label>--%>
                                        <asp:Label ID="lblfilename" runat="server" class="labelcolorl1" Text=""></asp:Label>
                                        <%--</div>--%>
                                    </div>
                                    <div class="col-md-3">
                                        <a href="SampleFiles/UserMaster.xlsx" target="_blank" download="Insert Format" class="  btn-sm warning_3"><u>Download Sample Excel</u>
                                        </a>
                                    </div>


                                </div>
                                <div class="row mt-1">
                                    <div class="col-md-2">
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="butttonsubmit" runat="server" Text="Import Excel" CssClass="btn btn-sm btn-success savebtn" OnClick="butttonsubmit_Click" CausesValidation="false" />
                                        <asp:Button ID="btnn" runat="server" Text="Insert Data" OnClick="btnn_Click" CssClass="btn btn-sm btn-success warning_3" Visible="false" CausesValidation="false" />
                                    </div>
                                </div>
                                <div class="row" style="display: none;">
                                    <asp:Label ID="Label2" runat="server" Text="Has Header ?"></asp:Label>
                                    <br />
                                    <asp:RadioButtonList ID="rbHDR" runat="server" RepeatLayout="Flow">
                                        <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive p-0" style="height: 400px; width: 100%">
                                            <asp:GridView ID="gvExcelFile" runat="server" CssClass="table table-head-fixed text-nowrap" AutoGenerateColumns="true">

                                                <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="10px" />
                                                <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" />
                                                <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="30px" CssClass="header" Font-Size="Small" />
                                                <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" />
                                                <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ImgBtnExport" />
            <asp:PostBackTrigger ControlID="btnn" />
            <asp:PostBackTrigger ControlID="butttonsubmit" />
            <%--<asp:PostBackTrigger ControlID="btnInsertTechnician" />--%>
            <asp:PostBackTrigger ControlID="btnUpdateTechnician" />
            <asp:PostBackTrigger ControlID="gvTechnician" />
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="chkEnableTechnician" />
            <asp:PostBackTrigger ControlID="btnAddRequester" />
            <%--<asp:PostBackTrigger ControlID="ddlRequestType" />--%>
            <%--<asp:PostBackTrigger ControlID="btnimportUser" />
            <asp:PostBackTrigger ControlID="btnViewUsers" />--%>
            <asp:PostBackTrigger ControlID="ddlOrg" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function Showalert(imtype, imtitle) {
            // alert('Call JavaScript function from codebehind');
            // var typeof=type
            // var titleof = title;
            var Toast = Swal.mixin({
                toast: true,
                position: 'top-middle',

                showConfirmButton: false,
                showCloseButton: true,
                timer: 4000,


            });
            console.log("hello");
            Toast.fire({
                /*icon: 'success',*/
                //type: 'success',
                //title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                icon: imtype,
                title: imtitle
            });

            console.log("fire1234567");
        }
    </script>
    <script>
        $(function () {
            bsCustomFileInput.init();
        });
    </script>
    <script>
        function displayfilename()
        $('#<%= customFile.ClientID %>').change(function (e) {
            var fileName = e.target.files[0].name;
            alert('The file "' + fileName + '" has been selected.');
        });
    </script>
</asp:Content>

