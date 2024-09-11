﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="HelpDesk_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   <div id="stepper1" class="bs-stepper">
		  <div class="card">
			
			<div class="card-header">
				<div class="d-lg-flex flex-lg-row align-items-lg-center justify-content-lg-between" role="tablist">
					<div class="step" data-target="#test-l-1">
					  <div class="step-trigger" role="tab" id="stepper1trigger1" aria-controls="test-l-1">
						<div class="bs-stepper-circle">1</div>
						<div class="">
							<h5 class="mb-0 steper-title">Personal Info</h5>
							<p class="mb-0 steper-sub-title">Enter Your Details</p>
						</div>
					  </div>
					</div>
					<div class="bs-stepper-line"></div>
					<div class="step" data-target="#test-l-2">
						<div class="step-trigger" role="tab" id="stepper1trigger2" aria-controls="test-l-2">
						  <div class="bs-stepper-circle">2</div>
						  <div class="">
							  <h5 class="mb-0 steper-title">Account Details</h5>
							  <p class="mb-0 steper-sub-title">Setup Account Details</p>
						  </div>
						</div>
					  </div>
					<div class="bs-stepper-line"></div>
					<div class="step" data-target="#test-l-3">
						<div class="step-trigger" role="tab" id="stepper1trigger3" aria-controls="test-l-3">
						  <div class="bs-stepper-circle">3</div>
						  <div class="">
							  <h5 class="mb-0 steper-title">Education</h5>
							  <p class="mb-0 steper-sub-title">Education Details</p>
						  </div>
						</div>
					  </div>
					  <div class="bs-stepper-line"></div>
						<div class="step" data-target="#test-l-4">
							<div class="step-trigger" role="tab" id="stepper1trigger4" aria-controls="test-l-4">
							<div class="bs-stepper-circle">4</div>
							<div class="">
								<h5 class="mb-0 steper-title">Work Experience</h5>
								<p class="mb-0 steper-sub-title">Experience Details</p>
							</div>
							</div>
						</div>
				  </div>
			 </div>
		    <div class="card-body">
			  <div class="bs-stepper-content">
				<form onSubmit="return false">
				  <div id="test-l-1" role="tabpanel" class="bs-stepper-pane" aria-labelledby="stepper1trigger1">
					<h5 class="mb-1">Your Personal Information</h5>
					<p class="mb-4">Enter your personal information to get closer to copanies</p>

					<div class="row g-3">
						<div class="col-12 col-lg-6">
							<label class="form-label">First Name</label>
							<input type="text" class="form-control" placeholder="First Name">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Last Name</label>
							<input type="text" class="form-control" placeholder="Last Name">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Phone Number</label>
							<input type="text" class="form-control" placeholder="Phone Number">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">E-mail Address</label>
							<input type="text" class="form-control" placeholder="Enter Email Address">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Country</label>
							<select class="form-select">
								<option selected>---</option>
								<option value="1">One</option>
								<option value="2">Two</option>
								<option value="3">Three</option>
							  </select>
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Language</label>
							<select class="form-select">
								<option selected>---</option>
								<option value="1">One</option>
								<option value="2">Two</option>
								<option value="3">Three</option>
							  </select>
						</div>
						<div class="col-12 col-lg-6">
							<button class="btn btn-grd-primary px-4" onclick="stepper1.next()">Next<i class='bx bx-right-arrow-alt ms-2'></i></button>
						</div>
					</div><!---end row-->
					
				  </div>

				  <div id="test-l-2" role="tabpanel" class="bs-stepper-pane" aria-labelledby="stepper1trigger2">

					<h5 class="mb-1">Account Details</h5>
					<p class="mb-4">Enter Your Account Details.</p>

					<div class="row g-3">
						<div class="col-12 col-lg-6">
							<label class="form-label">Username</label>
							<input type="text" class="form-control" placeholder="jhon@123">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">E-mail Address</label>
							<input type="text" class="form-control" placeholder="example@xyz.com">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Password</label>
							<input type="password" class="form-control" value="12345678">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Confirm Password</label>
							<input type="password" class="form-control" value="12345678">
						</div>
						<div class="col-12">
							<div class="d-flex align-items-center gap-3">
							  <button class="btn btn-grd-info px-4" onclick="stepper1.previous()"><i class='bx bx-left-arrow-alt me-2'></i>Previous</button>
								<button class="btn btn-grd-primary px-4" onclick="stepper1.next()">Next<i class='bx bx-right-arrow-alt ms-2'></i></button>
							</div>
						</div>
					</div><!---end row-->
					
				  </div>

				  <div id="test-l-3" role="tabpanel" class="bs-stepper-pane" aria-labelledby="stepper1trigger3">
					<h5 class="mb-1">Your Education Information</h5>
					<p class="mb-4">Inform companies about your education life</p>

					<div class="row g-3">
						<div class="col-12 col-lg-6">
							<label class="form-label">School Name</label>
							<input type="text" class="form-control" placeholder="School Name">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Board Name</label>
							<input type="text" class="form-control" placeholder="Board Name">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">University Name</label>
							<input type="text" class="form-control" placeholder="University Name">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Course Name</label>
							<select class="form-select">
								<option selected>---</option>
								<option value="1">One</option>
								<option value="2">Two</option>
								<option value="3">Three</option>
							  </select>
						</div>
						<div class="col-12">
							<div class="d-flex align-items-center gap-3">
							  <button class="btn btn-grd-info px-4" onclick="stepper1.previous()"><i class='bx bx-left-arrow-alt me-2'></i>Previous</button>
								<button class="btn btn-grd-primary px-4" onclick="stepper1.next()">Next<i class='bx bx-right-arrow-alt ms-2'></i></button>
							</div>
						</div>
					</div><!---end row-->
					
				  </div>

				  <div id="test-l-4" role="tabpanel" class="bs-stepper-pane" aria-labelledby="stepper1trigger4">
					<h5 class="mb-1">Work Experiences</h5>
					<p class="mb-4">Can you talk about your past work experience?</p>

					<div class="row g-3">
						<div class="col-12 col-lg-6">
							<label class="form-label">Experience 1</label>
							<input type="text" class="form-control" placeholder="Experience 1">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Position</label>
							<input type="text" class="form-control" placeholder="Position">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Experience 2</label>
							<input type="text" class="form-control" placeholder="Experience 2">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Position</label>
							<input type="text" class="form-control" placeholder="Position">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Experience 3</label>
							<input type="text" class="form-control" placeholder="Experience 3">
						</div>
						<div class="col-12 col-lg-6">
							<label class="form-label">Position</label>
							<input type="text" class="form-control" placeholder="Position">
						</div>
						<div class="col-12">
							<div class="d-flex align-items-center gap-3">
							  <button class="btn btn-grd-info px-4" onclick="stepper1.previous()"><i class='bx bx-left-arrow-alt me-2'></i>Previous</button>
								<button class="btn btn-grd-primary px-4" onclick="stepper1.next()">Next<i class='bx bx-right-arrow-alt ms-2'></i></button>
							</div>
						</div>
					</div><!---end row-->
					
				  </div>
				</form>
			  </div>
			   
			</div>
		   </div>
		 </div>
</asp:Content>

