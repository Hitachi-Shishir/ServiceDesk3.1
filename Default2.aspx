<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
       <div class="col-md-3 col-6">
           <div class="card rounded-4">
               <div class="card-body">
                   <div class="d-flex align-items-center gap-3 mb-2">
                       <div class="">
                           <h2 class="mb-0">01</h2>
                       </div>
                       <div class="">
                           <p class="dash-lable d-flex align-items-center gap-1 rounded mb-0 bg-success text-success bg-opacity-10">
                               <span class="material-icons-outlined fs-6">arrow_upward</span>24.7%
            
                           </p>
                       </div>
                   </div>
                   <p class="mb-0">Logged Today</p>
                   

               </div>
           </div>
       </div>
       <div class="col-md-3 col-6">
           <div class="card rounded-4">
               <div class="card-body">
                   <div class="d-flex align-items-center gap-3 mb-2">
                       <div class="">
                           <h2 class="mb-0">07</h2>
                       </div>
                       <div class="">
                           <p class="dash-lable d-flex align-items-center gap-1 rounded mb-0 bg-success text-success bg-opacity-10">
                               <span class="material-icons-outlined fs-6">arrow_upward</span>24.7%
            
                           </p>
                       </div>
                   </div>
                   <p class="mb-0">Logged last 7 Days </p>
                  

               </div>
           </div>
       </div>
       <div class="col-md-3 col-6">
           <div class="card rounded-4">
               <div class="card-body">
                   <div class="d-flex align-items-center gap-3 mb-2">
                       <div class="">
                           <h2 class="mb-0">56</h2>
                       </div>
                       <div class="">
                           <p class="dash-lable d-flex align-items-center gap-1 rounded mb-0 bg-success text-success bg-opacity-10">
                               <span class="material-icons-outlined fs-6">arrow_upward</span>24.7%
            
                           </p>
                       </div>
                   </div>
                   <p class="mb-0">Logged 30 Days</p>


               </div>
           </div>
       </div>
       <div class="col-md-3 col-6">
           <div class="card rounded-4">
               <div class="card-body">
                   <div class="d-flex align-items-center gap-3 mb-2">
                       <div class="">
                           <h2 class="mb-0">10777</h2>
                       </div>
                       <div class="">
                           <p class="dash-lable d-flex align-items-center gap-1 rounded mb-0 bg-success text-success bg-opacity-10">
                               <span class="material-icons-outlined fs-6">arrow_upward</span>24.7%
            
                           </p>
                       </div>
                   </div>
                   <p class="mb-0">Total Tickets</p>
                   

               </div>
           </div>
       </div>
       <div class="col-12 col-xl-8">
           <div class="card w-100 rounded-4">
               <div class="card-body">
                   <div class="d-flex align-items-start justify-content-between mb-3">
                       <div class="">
                           <h5 class="mb-0">Sales & Views</h5>
                       </div>
                       <div class="dropdown">
                           <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle"
                               data-bs-toggle="dropdown">
                               <span class="material-icons-outlined fs-5">more_vert</span>
                           </a>
                           <ul class="dropdown-menu">
                               <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                               <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                               <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                           </ul>
                       </div>
                   </div>
                   <div id="chart5"></div>
                   <div
                       class="d-flex flex-column flex-lg-row align-items-start justify-content-around border p-3 rounded-4 mt-3 gap-3">
                       <div class="d-flex align-items-center gap-4">
                           <div class="">
                               <p class="mb-0 data-attributes">
                                   <span
                                       data-peity='{ "fill": ["#2196f3", "rgb(255 255 255 / 12%)"], "innerRadius": 32, "radius": 40 }'>5/7</span>
                               </p>
                           </div>
                           <div class="">
                               <p class="mb-1 fs-6 fw-bold">Monthly</p>
                               <h2 class="mb-0">65,127</h2>
                               <p class="mb-0"><span class="text-success me-2 fw-medium">16.5%</span><span>55.21 USD</span></p>
                           </div>
                       </div>
                       <div class="vr"></div>
                       <div class="d-flex align-items-center gap-4">
                           <div class="">
                               <p class="mb-0 data-attributes">
                                   <span
                                       data-peity='{ "fill": ["#ffd200", "rgb(255 255 255 / 12%)"], "innerRadius": 32, "radius": 40 }'>5/7</span>
                               </p>
                           </div>
                           <div class="">
                               <p class="mb-1 fs-6 fw-bold">Yearly</p>
                               <h2 class="mb-0">984,246</h2>
                               <p class="mb-0"><span class="text-success me-2 fw-medium">24.9%</span><span>267.35 USD</span></p>
                           </div>
                       </div>
                   </div>
               </div>
           </div>
       </div>
       <div class="col-12 col-xl-4">
           <div class="card w-100 rounded-4">
               <div class="card-body">
                   <div class="d-flex flex-column gap-3">
                       <div class="d-flex align-items-start justify-content-between">
                           <div class="">
                               <h5 class="mb-0">Order Status</h5>
                           </div>
                           <div class="dropdown">
                               <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle"
                                   data-bs-toggle="dropdown">
                                   <span class="material-icons-outlined fs-5">more_vert</span>
                               </a>
                               <ul class="dropdown-menu">
                                   <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                                   <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                                   <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                               </ul>
                           </div>
                       </div>
                       <div class="position-relative">
                           <div class="piechart-legend">
                               <h2 class="mb-1">68%</h2>
                               <h6 class="mb-0">Total Sales</h6>
                           </div>
                           <div id="chart6"></div>
                       </div>
                       <div class="d-flex flex-column gap-3">
                           <div class="d-flex align-items-center justify-content-between">
                               <p class="mb-0 d-flex align-items-center gap-2 w-25">
                                   <span
                                       class="material-icons-outlined fs-6 text-primary">fiber_manual_record</span>Sales
                               </p>
                               <div class="">
                                   <p class="mb-0">68%</p>
                               </div>
                           </div>
                           <div class="d-flex align-items-center justify-content-between">
                               <p class="mb-0 d-flex align-items-center gap-2 w-25">
                                   <span
                                       class="material-icons-outlined fs-6 text-danger">fiber_manual_record</span>Product
                               </p>
                               <div class="">
                                   <p class="mb-0">25%</p>
                               </div>
                           </div>
                           <div class="d-flex align-items-center justify-content-between">
                               <p class="mb-0 d-flex align-items-center gap-2 w-25">
                                   <span
                                       class="material-icons-outlined fs-6 text-success">fiber_manual_record</span>Income
                               </p>
                               <div class="">
                                   <p class="mb-0">14%</p>
                               </div>
                           </div>
                       </div>
                   </div>
               </div>
           </div>
       </div>

   </div>

     <div class="row">
          <div class="col-12 col-xl-12">
            <div class="card rounded-4">
              <div class="card-header py-3">
                <div class="d-flex align-items-center justify-content-between">
                  <h5 class="mb-0">Area Chart</h5>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <span class="material-icons-outlined fs-5">more_vert</span>
                    </a>
                    <ul class="dropdown-menu">
                      <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                    </ul>
                  </div>
                </div>
              </div>
              <div class="card-body">
                <div id="chart1"></div>
              </div>
            </div>
          </div>
          <div class="col-12 col-xl-12">
            <div class="card rounded-4">
              <div class="card-header py-3">
                <div class="d-flex align-items-center justify-content-between">
                  <h5 class="mb-0">Line Chart</h5>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <span class="material-icons-outlined fs-5">more_vert</span>
                    </a>
                    <ul class="dropdown-menu">
                      <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                    </ul>
                  </div>
                </div>
              </div>
              <div class="card-body">
                <div id="chart2"></div>
              </div>
            </div>
          </div>
          <div class="col-12 col-xl-12">
            <div class="card rounded-4">
              <div class="card-header py-3">
                <div class="d-flex align-items-center justify-content-between">
                  <h5 class="mb-0">Bar Chart</h5>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <span class="material-icons-outlined fs-5">more_vert</span>
                    </a>
                    <ul class="dropdown-menu">
                      <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                    </ul>
                  </div>
                </div>
              </div>
              <div class="card-body">
                <div id="chart3"></div>
              </div>
            </div>
          </div>
          <div class="col-12 col-xl-6">
            <div class="card rounded-4">
              <div class="card-header py-3">
                <div class="d-flex align-items-center justify-content-between">
                  <h5 class="mb-0">Pie Chart</h5>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <span class="material-icons-outlined fs-5">more_vert</span>
                    </a>
                    <ul class="dropdown-menu">
                      <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                    </ul>
                  </div>
                </div>
              </div>
              <div class="card-body">
                <div id="chart4"></div>
              </div>
            </div>
          </div>
          <div class="col-12 col-xl-6">
            <div class="card rounded-4">
              <div class="card-header py-3">
                <div class="d-flex align-items-center justify-content-between">
                  <h5 class="mb-0">Donught Chart</h5>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <span class="material-icons-outlined fs-5">more_vert</span>
                    </a>
                    <ul class="dropdown-menu">
                      <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                    </ul>
                  </div>
                </div>
              </div>
              <div class="card-body">
                <div id="chart5"></div>
              </div>
            </div>
          </div>
          <div class="col-12 col-xl-6">
            <div class="card rounded-4">
              <div class="card-header py-3">
                <div class="d-flex align-items-center justify-content-between">
                  <h5 class="mb-0">Radial Chart</h5>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <span class="material-icons-outlined fs-5">more_vert</span>
                    </a>
                    <ul class="dropdown-menu">
                      <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                    </ul>
                  </div>
                </div>
              </div>
              <div class="card-body">
                <div id="chart6"></div>
              </div>
            </div>
          </div>
          <div class="col-12 col-xl-6">
            <div class="card rounded-4">
              <div class="card-header py-3">
                <div class="d-flex align-items-center justify-content-between">
                  <h5 class="mb-0">Radial Bar Chart</h5>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <span class="material-icons-outlined fs-5">more_vert</span>
                    </a>
                    <ul class="dropdown-menu">
                      <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                      <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                    </ul>
                  </div>
                </div>
              </div>
              <div class="card-body">
                <div id="chart7"></div>
              </div>
            </div>
          </div>
        
        
        </div><!--end row-->

</asp:Content>

