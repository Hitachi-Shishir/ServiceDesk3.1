<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmDashboard.aspx.cs" Inherits="frmDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .gap-5 {
            gap: 2.6rem !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scrmg" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row g-2">
                <div class="col-xxl-8 d-flex align-items-stretch">
                    <div class="card w-100 overflow-hidden rounded-4 mb-3">
                        <div class="card-body position-relative p-4">
                            <div class="row g-2">
                                <div class="d-flex align-items-center gap-3 mb-5">
                                    <%--<asp:Image ID="img" runat="server" class="rounded-circle bg-grd-info p-1" width="60" height="60" alt="user"/>--%>
                                    <asp:Image ID="img" runat="server" class="rounded-circle p-1 border" Width="45" Height="45" alt="" />
                                    <div class="col-3">
                                        <p class="mb-0 fw-semibold">Welcome back</p>
                                        <h4 class="fw-semibold mb-0 fs-4 mb-0">
                                            <asp:Label ID="lblUserName" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                            </div>
                            <div class="row " style="margin-bottom: 81px;">
                                <div class="col-3">
                                    <asp:DropDownList ID="ddlRequestType" runat="server" ToolTip="Select Desk Type" CssClass="form-select form-select-sm single-select-optgroup-field" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-3">
                                    <asp:DropDownList ID="ddlCategory" runat="server" ToolTip="Select Desk Type" CssClass="form-select form-select-sm single-select-optgroup-field" >
                                    </asp:DropDownList>
                                </div>
                                <div class="col-2">
                                    <asp:TextBox runat="server" Placeholder="From Date" ID="txtfrmDate" class="form-control form-control-sm datepicker"></asp:TextBox>
                                </div>
                                <div class="col-2">
                                    <asp:TextBox runat="server" Placeholder="To Date" ID="txttoDate" class="form-control form-control-sm datepicker"></asp:TextBox>
                                </div>
                                <div class="col-1">
                                    <asp:Button ID="btnGo" runat="server" Text="GO" CssClass="btn btn-sm  btn-grd btn-grd-info " OnClick="btnGo_Click" />
                                </div>
                            </div>
                            <div class="d-flex align-items-center gap-5">
                                <div class="">
                                    <h4 class="mb-1 fw-semibold d-flex align-content-center">
                                        <asp:Label ID="lbltot" runat="server"></asp:Label><i class="ti ti-arrow-up-right fs-5 lh-base text-success"></i>
                                    </h4>
                                    <p class="mb-3">Total Tickets</p>

                                </div>
                                <div class="vr"></div>
                                <div class="">
                                    <h4 class="mb-1 fw-semibold d-flex align-content-center">
                                        <asp:Label ID="lblOpen" runat="server"></asp:Label><i class="ti ti-arrow-up-right fs-5 lh-base text-success"></i>
                                    </h4>
                                    <p class="mb-3">Open Tickets</p>

                                </div>
                                <div class="vr"></div>
                                <div class="">
                                    <h4 class="mb-1 fw-semibold d-flex align-content-center">
                                        <asp:Label ID="lblHold" runat="server"></asp:Label><i class="ti ti-arrow-up-right fs-5 lh-base text-success"></i>
                                    </h4>
                                    <p class="mb-3">Hold Tickets</p>

                                </div>
                                <div class="vr"></div>
                                <div class="">
                                    <h4 class="mb-1 fw-semibold d-flex align-content-center">
                                        <asp:Label ID="lblWip" runat="server"></asp:Label><i class="ti ti-arrow-up-right fs-5 lh-base text-success"></i>
                                    </h4>
                                    <p class="mb-3">WIP Tickets</p>

                                </div>
                                <div class="vr"></div>
                                <div class="">
                                    <h4 class="mb-1 fw-semibold d-flex align-content-center">
                                        <asp:Label ID="lblClosed" runat="server"></asp:Label><i class="ti ti-arrow-up-right fs-5 lh-base text-success"></i>
                                    </h4>
                                    <p class="mb-3">Closed Tickets</p>

                                </div>
                                <div class="vr"></div>
                                <div class="">
                                    <h4 class="mb-1 fw-semibold d-flex align-content-center">
                                        <asp:Label ID="lblResolved" runat="server"></asp:Label><i class="ti ti-arrow-up-right fs-5 lh-base text-success"></i>
                                    </h4>
                                    <p class="mb-3">Resolved</p>

                                </div>
                            </div>
                            <div class="col-12 col-sm-2">
                                <div class="welcome-back-img pt-4">
                                    <img src="assets/images/gallery/welcome-back-3.png" height="160" alt="">
                                </div>
                            </div>
                        </div>
                        <!--end row-->
                    </div>
                </div>
            </div>
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="card w-100 rounded-4">
                        <div class="card-body">
                            <div class="d-flex align-items-start justify-content-between ">
                                <div class="">
                                    <h6 class="mb-0">Ticket by Status</h6>
                                </div>
                            </div>
                            <div id="chart5"></div>
                            <div class="d-flex flex-column gap-3 mx-3 my-4">
                                <div class="d-flex align-items-center justify-content-between">
                                    <p class="mb-0 d-flex align-items-center gap-2 w-25">Open</p>
                                    <div class="">
                                        <p class="mb-0">
                                            <asp:Label ID="lblOpenPer" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </div>
                                <div class="d-flex align-items-center justify-content-between">
                                    <p class="mb-0 d-flex align-items-center gap-2 w-25">Hold</p>
                                    <div class="">
                                        <p class="mb-0">
                                            <asp:Label ID="lblHoldPer" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </div>
                                <div class="d-flex align-items-center justify-content-between">
                                    <p class="mb-0 d-flex align-items-center gap-2 w-25">WIP</p>
                                    <div class="">
                                        <p class="mb-0">
                                            <asp:Label ID="lblWipPer" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </div>
                                <div class="d-flex align-items-center justify-content-between">
                                    <p class="mb-0 d-flex align-items-center gap-2 w-25">Closed</p>
                                    <div class="">
                                        <p class="mb-0">
                                            <asp:Label ID="lblClosedPer" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </div>
                                <div class="d-flex align-items-center justify-content-between">
                                    <p class="mb-0 d-flex align-items-center gap-2 w-25">Resolved</p>
                                    <div class="">
                                        <p class="mb-0">
                                            <asp:Label ID="lblResolvedPer" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="row g-3">
                        <div class="col-md-12">

                            <div class="card w-100 rounded-4 mb-0">
                                <div class="card-body">
                                    <div class="d-flex align-items-start justify-content-between mb-3">
                                        <div class="">
                                            <h6 class="mb-0">Details by Severity</h6>
                                        </div>

                                    </div>
                                    <div id="chart1"></div>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-12">

                            <div class="card w-100 rounded-4 mb-0">
                                <div class="card-body">
                                    <div class="d-flex align-items-start justify-content-between mb-3">
                                        <div class="">
                                            <h6 class="mb-0">Details by Priority</h6>
                                        </div>

                                    </div>
                                    <div id="chart2"></div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-12 mt-0">
                    <div class="card rounded-4">


                        <div class="card-body">
                            <div class="d-flex align-items-center justify-content-between">
                                <h6 class="mb-0">Tickets by Category</h6>

                            </div>
                            <div id="chart3"></div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 mt-0">
                    <div class="card rounded-4">


                        <div class="card-body">
                            <div class="d-flex align-items-center justify-content-between">
                                <h6 class="mb-0">Day-Wise Ticket Generation </h6>


                            </div>
                            <div id="chart3a"></div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 mt-0" id="divlocation" runat="server">
                    <div class="card rounded-4">
                        <div class="card-body">
                            <div class="d-flex align-items-center justify-content-between">
                                <h6 class="mb-0">Location Wise Ticket Generation </h6>
                            </div>
                            <div id="chart3b"></div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 mt-0" id="divAssigne" runat="server">
                    <div class="card rounded-4">
                        <div class="card-body">
                            <div class="d-flex align-items-center justify-content-between">
                                <h6 class="mb-0">Assigne Wise Ticket Allocations </h6>
                            </div>
                            <div id="chart3c"></div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnSeverityS1" runat="server" />
                <asp:HiddenField ID="hdnSeverityS2" runat="server" />
                <asp:HiddenField ID="hdnSeverityS3" runat="server" />

                <asp:HiddenField ID="hdnLowPriority" runat="server" />
                <asp:HiddenField ID="hdnMediumPriority" runat="server" />
                <asp:HiddenField ID="hdnHighPriority" runat="server" />

                <asp:HiddenField ID="hdncategories" runat="server" />
                <asp:HiddenField ID="hdntotalTickets" runat="server" />

            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGo" />
            <asp:PostBackTrigger ControlID="ddlRequestType" />
        </Triggers>
    </asp:UpdatePanel>
    <!--end row-->

    <script>

        $(function () {
            "use strict";
            var s1 = parseFloat(document.getElementById('<%= hdnSeverityS1.ClientID %>').value);
            var s2 = parseFloat(document.getElementById('<%= hdnSeverityS2.ClientID %>').value);
            var s3 = parseFloat(document.getElementById('<%= hdnSeverityS3.ClientID %>').value);

            // Details by Severity

            var options = {
                series: [{
                    name: "Total Tickets",
                    /*data: [4, 10, 6]*/
                    data: [s1, s2, s3]
                }],
                chart: {
                    foreColor: "#9ba7b2",
                    height: 180,
                    type: 'area',
                    zoom: {
                        enabled: false
                    },
                    toolbar: {
                        show: !1,
                    },
                },
                dataLabels: {
                    enabled: false
                },
                stroke: {
                    width: 4,
                    curve: 'smooth'
                },
                fill: {
                    type: 'gradient',
                    gradient: {
                        shade: 'dark',
                        gradientToColors: ['#ff0080'],
                        shadeIntensity: 1,
                        type: 'vertical',
                        opacityFrom: 0.8,
                        opacityTo: 0.1,
                        stops: [0, 100, 100, 100]
                    },
                },
                colors: ["#ffd200"],
                grid: {
                    show: true,
                    borderColor: 'rgba(0, 0, 0, 0.15)',
                    strokeDashArray: 4,
                },
                tooltip: {
                    theme: "dark",
                },
                xaxis: {
                    categories: ['Severity 1', 'Severity 1', 'Severity 1'],
                },
                markers: {
                    show: !1,
                    size: 5,
                },
            };

            var chart = new ApexCharts(document.querySelector("#chart1"), options);
            chart.render();




            // Details by Priority
            var LowPriority = parseFloat(document.getElementById('<%= hdnLowPriority.ClientID %>').value);
            var MediumPriority = parseFloat(document.getElementById('<%= hdnMediumPriority.ClientID %>').value);
            var HighPriority = parseFloat(document.getElementById('<%= hdnHighPriority.ClientID %>').value);
            var options = {
                series: [{
                    name: "Total Tickets",
                    //data: [10, 41, 35, 51, 49, 82, 69, 91, 18],
                    data: [MediumPriority, HighPriority, LowPriority]
                }],
                chart: {
                    foreColor: "#9ba7b2",
                    height: 180,
                    type: 'line',
                    zoom: {
                        enabled: false
                    },
                    toolbar: {
                        show: !1,
                    },
                    dropShadow: {
                        enabled: !0,
                        top: 3,
                        left: 14,
                        blur: 4,
                        opacity: .12,
                        color: "#fc185a"
                    },
                },
                dataLabels: {
                    enabled: false
                },
                stroke: {
                    curve: 'smooth'
                },
                fill: {
                    type: 'gradient',
                    gradient: {
                        shade: 'dark',
                        gradientToColors: ['#7928ca'],
                        shadeIntensity: 1,
                        type: 'vertical',
                        opacityFrom: 1,
                        opacityTo: 1,
                        // stops: [0, 100, 100, 100]
                    },
                },
                colors: ["#ff0080"],
                grid: {
                    show: true,
                    borderColor: 'rgba(0, 0, 0, 0.15)',
                    strokeDashArray: 4,
                },
                tooltip: {
                    theme: "dark",
                },
                xaxis: {
                    categories: ['Medium', 'High', 'low'],
                }
            };

            var chart = new ApexCharts(document.querySelector("#chart2"), options);
            chart.render();

            var openPercent = parseFloat(document.getElementById('<%= lblOpenPer.ClientID %>').innerText);
            var holdPercent = parseFloat(document.getElementById('<%= lblHoldPer.ClientID %>').innerText);
            var wipPercent = parseFloat(document.getElementById('<%= lblWipPer.ClientID %>').innerText);
            var closedPercent = parseFloat(document.getElementById('<%= lblClosedPer.ClientID %>').innerText);
            var resolvedPercent = parseFloat(document.getElementById('<%= lblResolvedPer.ClientID %>').innerText);

            // Ticket by Status
            var options = {
                series: [closedPercent, resolvedPercent, openPercent, wipPercent, holdPercent],
                chart: {
                    height: 290,
                    type: 'donut',
                },
                legend: {
                    position: 'bottom',
                    show: !1
                },
                labels: ['Closed', 'Resolved', 'Open', 'WIP', 'Hold'],
                fill: {
                    type: 'gradient',
                    gradient: {
                        shade: 'dark',
                        gradientToColors: ['#ee0979', '#17ad37', '#ec6ead', '#fc185a', ' #009efd'],
                        shadeIntensity: 1,
                        type: 'vertical',
                        opacityFrom: 1,
                        opacityTo: 1,
                        //stops: [0, 100, 100, 100]
                    },
                },
                colors: ["#ff6a00", "#98ec2d", "#3494e6", "#ffc107", "#2af598"],
                dataLabels: {
                    enabled: !1
                },
                plotOptions: {
                    pie: {
                        donut: {
                            size: "85%"
                        }
                    }
                },
                responsive: [{
                    breakpoint: 480,
                    options: {
                        chart: {
                            height: 270
                        },
                        legend: {
                            position: 'bottom',
                            show: !1
                        }
                    }
                }]
            };

            var chart = new ApexCharts(document.querySelector("#chart5"), options);
            chart.render();





        });

    </script>

    <script src="https://pcv-demo.hitachi-systems-mc.com:2020/assets/plugins/apexchart/apexcharts.min.js"></script>

</asp:Content>

