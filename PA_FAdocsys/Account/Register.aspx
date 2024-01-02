<%@ Page Title="Registration" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <style>
        .w-80{
            width:80% !important;
            margin-bottom:0px!important;
        }
    </style>
    <div class="register-box">
  <div class="card card-outline card-primary">
    <div class="card-header text-center">
         <%--<img src="../Content/dist/img/logo.png" alt="logo" class="img-fluid" style="width:250px"/>--%>
              <img src="../Content/dist/img/AdminLTELogo.png" alt="logo" class="img-fluid" style="width:100px"/>
    </div>
    <div class="card-body">
      <p class="login-box-msg">Register a new membership</p>
           <div class="form-horizontal">
         <div class="form-group mb-0">
                 <div class="input-group col-md-12">
         <asp:TextBox runat="server" ID="UserName" CssClass="form-control w-80" placeholder="Username" />                              
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
                     <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />  
        </div>
              </div>
     <div class="form-group mb-0">
            <div class="input-group col-md-12 mb-0">
            <asp:TextBox runat="server" ID="Email" TextMode="Email" CssClass="form-control w-80" placeholder="Email" />
            
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
               <%-- <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email"  CssClass="text-danger" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>--%>
        </div>
            </div>
           <div class="form-group mb-0">
               <div class="input-group col-md-12 mt-0">
         <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control w-80" placeholder="Password" />
          
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
                      <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
        </div>
               </div>
      <div class="form-group mb-3">
                         <div class="input-group col-md-12">
    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control w-80" placeholder="Retype password"/>
           
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
        </div>
        <div class="row">
          <div class="col-12 mt-3 text-center">
          <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-primary" />
          </div>
        </div>
               </div>
      <a href="Login.aspx" class="text-center">I already have a membership</a>
    </div>  
  </div>
</div>

        </div>
</asp:Content>

