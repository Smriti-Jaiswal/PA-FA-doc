<%@ Page Title="Log in" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" Async="true" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     <style>
        .w-80{
            width:80% !important;
        }
    </style>
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="login-box">
  <div class="card card-outline card-primary">
    <div class="card-header text-center">
 <%-- <img src="../Content/dist/img/logo.png" alt="logo" class="img-fluid" style="width:250px"/>--%>
              <img src="../Content/dist/img/AdminLTELogo.png" alt="logo" class="img-fluid" style="width:100px"/>
    </div>
    <div class="card-body">
      <p class="login-box-msg">Log in to start your session</p>
          <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
<div class="input-group col-md-12">
          <asp:TextBox runat="server" ID="Email" CssClass="form-control w-80" placeholder="Email" />
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
               <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
        </div>
       <div class="input-group col-md-12">
        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control w-80" placeholder="Password" />
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
           <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
        </div>
          <div class="row">
            <div class="col-12 text-center mb-2">
              <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-primary" />
          </div>
        </div>
      <p class="mb-0">
        <a href="Register.aspx" class="text-center">Register a new membership</a>
      </p>
    </div>
  
  </div>
</div>           
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled"></asp:HyperLink>
                 
                </p>
                    </div>
            </section>
        </div>
    </div>
</asp:Content>

