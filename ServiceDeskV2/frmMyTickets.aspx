<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmMyTickets.aspx.cs" Inherits="frmMyTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function getxtValue(that) {
            document.getElementById("lable").innerHTML = that.value;
        }
    </script>
    <script>
        function pageLoad() {
            jQuery(".chzn-select").data("placeholder", "Select Frameworks...").chosen();
        }
    </script>
  
    <style>
        .c {
            color: white;
            /*  //background: #698DF2;*/
            background: transparent linear-gradient(180deg, #5D7FA7 0%, #2E4E74 100%) 0% 0% no-repeat padding-box;
            border: none;
        }

        .chart_label {
            font-size: larger;
            font-weight: 500;
            letter-spacing: 0px;
            opacity: 1;
            text-align: left;
        }

        .fonts {
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif
        }
    </style>
    <style>
        .header {
            position: sticky;
            top: 0;
            bottom: 2px;
            font-weight: 200;
            border: #EEEEEE;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12 graphs">

                    <div class="card card-default">

                        <div class="card-body">
                            <div class="row ">
                                <div class="col-md-4">

                                    <asp:Label ID="lblsofname" runat="server" Text="My Ticket Details" Font-Size="Larger" ForeColor="Black"></asp:Label>

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

                            <div class="table-responsive p-0" style="height: 400px">

                                <asp:GridView ID="gvAllTickets" runat="server" CssClass="table table-head-fixed text-nowrap  " DataKeyNames="TicketNumber" AllowPaging="True" PageSize="10"
                                    AutoGenerateColumns="true" AllowSorting="True" OnPageIndexChanging="gvAllTickets_PageIndexChanging">

                                    <RowStyle BackColor="White" BorderColor="#e3e4e6" BorderWidth="1px" Height="5px" />
                                    <FooterStyle BackColor="#EDEDED" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#EDEDED" ForeColor="#000000" HorizontalAlign="Left" Height="20px" VerticalAlign="NotSet" CssClass="header" />
                                    <SelectedRowStyle BackColor="#fff" Font-Bold="True" ForeColor="#000000" Height="5px" />
                                    <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#414141" Height="5px" BorderColor="WhiteSmoke" CssClass="header sorting_asc" Font-Size="Small" />
                                    <EditRowStyle BackColor="#e9edf2" BorderColor="#e3e4e6" BorderStyle="Solid" BorderWidth="1px" Height="5px" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" BorderStyle="None" Height="5px" BorderColor="#EDEDED" BackColor="#EDEDED" />
                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    <AlternatingRowStyle BackColor="#EAEEFF" BorderColor="#e3e4e6" Height="5px" BorderStyle="Solid" BorderWidth="1px" />

                                </asp:GridView>
                            </div>
                            <%--	</div>--%>
                        </div>
                    </div>

                </div>
            </div>
            <div class="modal" id="CategoryModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="card-header">
                            Select Colums
							<button type="button" class="close" data-dismiss="modal" onclick="javascript:window.location.reload()" aria-hidden="true">&times;</button>


                        </div>
                        <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
							<ContentTemplate>--%>
                        <div class="card-body">
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ImgBtnExport" />
        </Triggers>

    </asp:UpdatePanel>

    <script type="text/javascript">
        function grdHeaderCheckBox(objRef) {
            var grd = objRef.parentNode.parentNode.parentNode;
            var inputList = grd.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>
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
                icon: imtype,
                title: imtitle
            });

            console.log("fire1234567");
        }
    </script>
   
</asp:Content>

