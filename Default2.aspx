<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .gap-5 {
            gap: 2.6rem !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">


    <div class="row g-2">

        <div class="col-xxl-8 d-flex align-items-stretch">
            <div class="card w-100 overflow-hidden rounded-4 mb-3">
                <div class="card-body position-relative p-4">
                    <div class="row g-2">
                        <div class="col-12 col-sm-10">
                            <div class="d-flex align-items-center gap-3 mb-5">
                                <%--<asp:Image ID="img" runat="server" class="rounded-circle bg-grd-info p-1" width="60" height="60" alt="user"/>--%>

                                <img src="assets/images/avatars/01.png" class="rounded-circle bg-grd-info p-1" width="60" height="60" alt="user">
                                <div class="">
                                    <p class="mb-0 fw-semibold">Welcome back</p>
                                    <h4 class="fw-semibold mb-0 fs-4 mb-0">Jhon Anderson!</h4>
                                </div>
                                <div class="">
                                    <select id="input7" class="form-select form-select-sm  rounded-5">
											<option selected="">Service Desk</option>
											<option>One</option>
											<option>Two</option>
											<option>Three</option>
										</select>
    
                                </div><div class="">
                                     <select id="input2" class="form-select form-select-sm  rounded-5">
									<option selected="">Category</option>
									<option>One</option>
									<option>Two</option>
									<option>Three</option>
					</select>
                                </div><div class="">
                                     <select id="input4" class="form-select form-select-sm  rounded-5">
									<option selected="">Date</option>
									<option>One</option>
									<option>Two</option>
									<option>Three</option>
					</select>
                                </div>
                            </div>
                            <div class="d-flex align-items-center gap-5">
                                <div class="">
                                    <h4 class="mb-1 fw-semibold d-flex align-content-center">43027<i class="ti ti-arrow-up-right fs-5 lh-base text-success"></i>
                                    </h4>
                                    <p class="mb-3">Total Tickets</p>

                                </div>
                                <div class="vr"></div>
                                <div class="">
                                    <h4 class="mb-1 fw-semibold d-flex align-content-center">787<i class="ti ti-arrow-up-right fs-5 lh-base text-success"></i>
                                    </h4>
                                    <p class="mb-3">Open Tickets</p>

                                </div>
                                <div class="vr"></div>
                                <div class="">
                                    <h4 class="mb-1 fw-semibold d-flex align-content-center">456<i class="ti ti-arrow-up-right fs-5 lh-base text-success"></i>
                                    </h4>
                                    <p class="mb-3">Closed Tickets</p>

                                </div>
                                <div class="vr"></div>
                                <div class="">
                                    <h4 class="mb-1 fw-semibold d-flex align-content-center">678<i class="ti ti-arrow-up-right fs-5 lh-base text-success"></i>
                                    </h4>
                                    <p class="mb-3">Resolved</p>

                                </div>
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
                                <p class="mb-0">35%</p>
                            </div>
                        </div>
                        <div class="d-flex align-items-center justify-content-between">
                            <p class="mb-0 d-flex align-items-center gap-2 w-25">Resolved</p>
                            <div class="">
                                <p class="mb-0">48%</p>
                            </div>
                        </div>
                        <div class="d-flex align-items-center justify-content-between">
                            <p class="mb-0 d-flex align-items-center gap-2 w-25">Hold</p>
                            <div class="">
                                <p class="mb-0">27%</p>
                            </div>
                        </div>
                        <div class="d-flex align-items-center justify-content-between">
                            <p class="mb-0 d-flex align-items-center gap-2 w-25">WIP</p>
                            <div class="">
                                <p class="mb-0">27%</p>
                            </div>
                        </div>
                        <div class="d-flex align-items-center justify-content-between">
                            <p class="mb-0 d-flex align-items-center gap-2 w-25">Closed</p>
                            <div class="">
                                <p class="mb-0">27%</p>
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
        <div class="col-md-6 mt-0">
            <div class="card rounded-4">

                
                <div class="card-body">
                    <div class="d-flex align-items-center justify-content-between">
    <h6 class="mb-0">Design by Assignee</h6>

</div>
                    <div id="chart3"></div>
                </div>
            </div>
        </div>
        <div class="col-md-6 mt-0">
            <div class="card rounded-4">

              
            <div class="card-body">
                  <div class="d-flex align-items-center justify-content-between">
      <h6 class="mb-0">Ticket by Category</h6>


  </div>
                <div id="chart3a"></div>
            </div>
            </div>
        </div>



    </div>


    <!--end row-->

    <script>

        $(function () {
            "use strict";


            // Details by Severity

            var options = {
                series: [{
                    name: "Desktops",
                    data: [4, 10, 6]
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

            var options = {
                series: [{
                    name: "Desktops",
                    //ata: [10, 41, 35, 51, 49, 82, 69, 91, 18],
                    data: [4, 25, 14]
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



            // Design by Assignee

            var options = {
                series: [{
                    name: "Total grdd",
                    data: [44, 25, 57, 56, 61, 58, 63, 60, 66]

                }],
                chart: {
                    foreColor: "#9ba7b2",
                    height: 250,
                    type: 'bar',
                    zoom: {
                        enabled: false
                    },
                    toolbar: {
                        show: !1,
                    }
                },
                fill: {
                    type: 'gradient',
                    gradient: {
                        shade: 'dark',
                        gradientToColors: ['#7928ca'],
                        shadeIntensity: 1,
                        type: 'vertical',
                        //opacityFrom: 0.8,
                        //opacityTo: 0.1,
                        stops: [0, 100, 100, 100]
                    },
                },
                colors: ["#ff0080"],
                plotOptions: {
                    bar: {
                        horizontal: false,
                        borderRadius: 4,
                        borderRadiusApplication: 'around',
                        borderRadiusWhenStacked: 'last',
                        columnWidth: '35%',
                    }
                },
                dataLabels: {
                    enabled: false
                },
                stroke: {
                    show: !0,
                    width: 4,
                    colors: ["transparent"]
                },
                grid: {
                    show: true,
                    borderColor: 'rgba(0, 0, 0, 0.15)',
                    strokeDashArray: 4,
                },
                tooltip: {
                    theme: "dark",
                },
                xaxis: {
                    categories: ['Na', 'Na', 'Na', 'Na', 'Na', 'Na', 'Na', 'Na', 'Na'],
                }
            };

            var chart = new ApexCharts(document.querySelector("#chart3"), options);
            chart.render();



            // Ticket by Category

            var options = {
                series: [{

                    name: "Customers",
                    data: [76, 85, 101, 98, 87, 105, 91, 114, 94]

                }],
                chart: {
                    foreColor: "#9ba7b2",
                    height: 250,
                    type: 'bar',
                    zoom: {
                        enabled: false
                    },
                    toolbar: {
                        show: !1,
                    }
                },
                fill: {
                    type: 'gradient',
                    gradient: {
                        shade: 'dark',
                        gradientToColors: ['#ffd200', '#00c6fb', '#7928ca'],
                        shadeIntensity: 1,
                        type: 'vertical',
                        //opacityFrom: 0.8,
                        //opacityTo: 0.1,
                        stops: [0, 100, 100, 100]
                    },
                },
                colors: ["#005bea"],
                plotOptions: {
                    bar: {
                        horizontal: false,
                        borderRadius: 4,
                        borderRadiusApplication: 'around',
                        borderRadiusWhenStacked: 'last',
                        columnWidth: '35%',
                    }
                },
                dataLabels: {
                    enabled: false
                },
                stroke: {
                    show: !0,
                    width: 4,
                    colors: ["transparent"]
                },
                grid: {
                    show: true,
                    borderColor: 'rgba(0, 0, 0, 0.15)',
                    strokeDashArray: 4,
                },
                tooltip: {
                    theme: "dark",
                },
                xaxis: {
                    categories: ['na', 'na', 'na', 'na', 'na', 'na', 'na', 'na', 'na'],
                }
            };

            var chart = new ApexCharts(document.querySelector("#chart3a"), options);
            chart.render();




            // Ticket by Status
            var options = {
                series: [58, 25, 25, 70, 4],
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

