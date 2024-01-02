<%@ Page Title="" Language="C#" MasterPageFile="~/Documentation.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .col-sm-6 {
    -webkit-flex: 0 0 50%;
    -ms-flex: 0 0 50%;
    flex: 100%;
    max-width: 100%;
}
    </style>
      <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
    <div class="container-fluid">
         <div class="row">
          <div class="col-lg-12">
            <h2><b>PROGRAM REGISTRATION</b></h2>
          </div>
        </div>
        <!-- ./row -->
        <div class="row">
          <div class="col-12 col-sm-6">
            <div class="card card-primary card-tabs">
              <div class="card-header p-0 pt-1">
                <ul class="nav nav-tabs" id="custom-tabs-one-tab" role="tablist">
                  <li class="nav-item">
                    <a class="nav-link active" id="custom-tabs-one-home-tab" data-toggle="pill" href="#custom-tabs-one-home" role="tab" aria-controls="custom-tabs-one-home" aria-selected="true">Insert</a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" id="custom-tabs-one-profile-tab" data-toggle="pill" href="#custom-tabs-one-profile" role="tab" aria-controls="custom-tabs-one-profile" aria-selected="false">Update</a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" id="custom-tabs-one-messages-tab" data-toggle="pill" href="#custom-tabs-one-messages" role="tab" aria-controls="custom-tabs-one-messages" aria-selected="false">Delete</a>
                  </li>
                </ul>
              </div>
              <div class="card-body">
                <div class="tab-content" id="custom-tabs-one-tabContent">
                  <div class="tab-pane fade show active" id="custom-tabs-one-home" role="tabpanel" aria-labelledby="custom-tabs-one-home-tab">
        <div class="form-group">
         
                       <div class="col-lg-12">
                      <asp:Label ID="lblproname" runat="server" Text="Program Name:"></asp:Label>
                      <asp:TextBox ID="txtproname" runat="server" CssClass="form-control w-80" placeholder="Program name"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtproname"
                                CssClass="text-danger" ErrorMessage="The program name is required." />
                  </div>
                     
                 <div class="col-lg-12">
                      <asp:Label ID="lblmqacode" runat="server" Text="MQA Code:"></asp:Label>
                      <asp:TextBox ID="txtmqacode" runat="server" CssClass="form-control w-80" placeholder="MQA code"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtmqacode"
                                CssClass="text-danger" ErrorMessage="The mqa code is required." />
                  </div>
                      <div class="col-lg-12">
                      <asp:Label ID="lblduration" runat="server" Text="Duration (in Months):"></asp:Label>
                      <asp:TextBox ID="txtduration" runat="server" CssClass="form-control w-80" placeholder="Duration"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtduration"
                                CssClass="text-danger" ErrorMessage="The duration is required." />
                  </div>

                         <div class="col-lg-12">
                      <asp:Label ID="lblshortsem" runat="server" Text="Number of Short Semesters:"></asp:Label>
                      <asp:TextBox ID="txtshortsem" runat="server" CssClass="form-control w-80" placeholder="Number of short semesters"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtshortsem"
                                CssClass="text-danger" ErrorMessage="The shorts semester is required." />
                  </div>
                      <div class="col-lg-12">
                      <asp:Label ID="lbllongsem" runat="server" Text="Number of Long Semesters:"></asp:Label>
                      <asp:TextBox ID="txtlongsem" runat="server" CssClass="form-control w-80" placeholder="Number of long semesters"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtlongsem"
                                CssClass="text-danger" ErrorMessage="The long semesters is required." />
                          <asp:Label ID="lblmsg" runat="server" CssClass="text-center" ForeColor="Green"></asp:Label><br />
                  </div>
                </div>
                           <div class="row">
            <div class="col-10 text-right mb-2 mt-0">
            <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary"/>
          </div>
        </div>
                  </div>
                  <div class="tab-pane fade" id="custom-tabs-one-profile" role="tabpanel" aria-labelledby="custom-tabs-one-profile-tab">
                     Mauris tincidunt mi at erat gravida, eget tristique urna bibendum. Mauris pharetra purus ut ligula tempor, et vulputate metus facilisis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Maecenas sollicitudin, nisi a luctus interdum, nisl ligula placerat mi, quis posuere purus ligula eu lectus. Donec nunc tellus, elementum sit amet ultricies at, posuere nec nunc. Nunc euismod pellentesque diam.
                  </div>
                  <div class="tab-pane fade" id="custom-tabs-one-messages" role="tabpanel" aria-labelledby="custom-tabs-one-messages-tab">
                     Morbi turpis dolor, vulputate vitae felis non, tincidunt congue mauris. Phasellus volutpat augue id mi placerat mollis. Vivamus faucibus eu massa eget condimentum. Fusce nec hendrerit sem, ac tristique nulla. Integer vestibulum orci odio. Cras nec augue ipsum. Suspendisse ut velit condimentum, mattis urna a, malesuada nunc. Curabitur eleifend facilisis velit finibus tristique. Nam vulputate, eros non luctus efficitur, ipsum odio volutpat massa, sit amet sollicitudin est libero sed ipsum. Nulla lacinia, ex vitae gravida fermentum, lectus ipsum gravida arcu, id fermentum metus arcu vel metus. Curabitur eget sem eu risus tincidunt eleifend ac ornare magna.
                  </div>
                </div>
              </div>
              <!-- /.card -->
            </div>
          </div>
        </div>
        </div>
        </section>
          </div>
</asp:Content>

