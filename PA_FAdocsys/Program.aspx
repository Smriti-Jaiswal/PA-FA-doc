<%@ Page Title="Program" Language="C#" MasterPageFile="~/Documentation.master" AutoEventWireup="true" CodeFile="Program.aspx.cs" Inherits="Program" %>

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
            <h4>PROGRAM REGISTRATION</h4>
          </div>
        </div>
        <!-- ./row -->
        <div class="row" id="dvTab">
          <div class="col-12 col-sm-6">
            <div class="card card-primary card-tabs">
              <div class="card-header p-0 pt-1">
                    <asp:HiddenField ID="hfTab" runat="server" />
                <ul class="nav nav-tabs" id="custom" role="tablist">
                  <li class="nav-item">
                    <a class="nav-link active" id="add-tab" data-toggle="pill" href="#add" role="tab" aria-controls="add">Add Program</a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" id="edit-tab" data-toggle="pill" href="#edit" role="tab" aria-controls="edit">Update Program</a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" id="remove-tab" data-toggle="pill" href="#remove" role="tab" aria-controls="remove">Delete Program</a>
                  </li>
                </ul>
              </div>
              <div class="card-body">
                <div class="tab-content" id="custom-tabs-one-tabContent">
                  <div class="tab-pane fade show active" id="add" role="tabpanel" aria-labelledby="add-tab">
        <div class="form-group">
         
                       <div class="col-lg-12">
                             <h4><b>ADD PROGRAM DETAILS</b></h4>
                      <asp:Label ID="lblproname" runat="server" Text="Program Name:"></asp:Label>
                      <asp:TextBox ID="txtproname" runat="server" CssClass="form-control w-80" placeholder="Program name"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtproname"
                                CssClass="text-danger" ErrorMessage="The program name is required." SetFocusOnError="true" ValidationGroup="valid" />
                  </div>
                     
                 <div class="col-lg-12">
                      <asp:Label ID="lblmqacode" runat="server" Text="MQA Code:"></asp:Label>
                      <asp:TextBox ID="txtmqacode" runat="server" CssClass="form-control w-80" placeholder="MQA code"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtmqacode"
                                CssClass="text-danger" ErrorMessage="The mqa code is required." SetFocusOnError="true" ValidationGroup="valid" />
                  </div>
                      <div class="col-lg-12">
                      <asp:Label ID="lblduration" runat="server" Text="Duration (in Months):"></asp:Label>
                      <asp:TextBox ID="txtduration" runat="server" CssClass="form-control w-80" TextMode="Number" placeholder="Duration"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtduration"
                                CssClass="text-danger" ErrorMessage="The duration is required." SetFocusOnError="true" ValidationGroup="valid"/>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
    ControlToValidate="txtduration" runat="server"
    ErrorMessage="Only numbers is allowed."
    ValidationExpression="\d+" ValidationGroup="valid">
</asp:RegularExpressionValidator>
                  </div>

                         <div class="col-lg-12">
                      <asp:Label ID="lblshortsem" runat="server" Text="Number of Short Semesters:"></asp:Label>
                      <asp:TextBox ID="txtshortsem" runat="server" CssClass="form-control w-80" TextMode="Number" placeholder="Number of short semesters"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtshortsem"
                                CssClass="text-danger" ErrorMessage="The shorts semester is required." SetFocusOnError="true" ValidationGroup="valid" />
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
    ControlToValidate="txtshortsem" runat="server"
    ErrorMessage="Only numbers is allowed."
    ValidationExpression="\d+" ValidationGroup="valid">
</asp:RegularExpressionValidator>
                  </div>
                      <div class="col-lg-12">
                      <asp:Label ID="lbllongsem" runat="server" Text="Number of Long Semesters:"></asp:Label>
                      <asp:TextBox ID="txtlongsem" runat="server" CssClass="form-control w-80" TextMode="Number" placeholder="Number of long semesters"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtlongsem"
                                CssClass="text-danger" ErrorMessage="The long semesters is required." SetFocusOnError="true" ValidationGroup="valid" />
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
    ControlToValidate="txtlongsem" runat="server"
    ErrorMessage="Only numbers is allowed."
    ValidationExpression="\d+" ValidationGroup="valid">
</asp:RegularExpressionValidator>
                          <asp:Label ID="lblmsg" runat="server" CssClass="text-right" ForeColor="Green"></asp:Label><br />
                  </div>
                </div>
                           <div class="row">
            <div class="col-12 text-right mb-2 mt-0">
            <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_Save" ValidationGroup="valid"/>
          </div>
                               <div>
                                   <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
<HeaderTemplate>
    <table class="example1 table table-bordered table-striped">
         <thead>
                  <tr>
                    <th>Sl.No</th>
                      <asp:Label runat="server" ID="tdInfoHeader" Visible="false">transid</asp:Label>
                    <th>Program Name</th>
                    <th>MQA Code</th>
                    <th>Duration (in Months)</th>
                    <th>Number of Short Semesters</th>
                      <th>Number of Long Semesters</th>
                  </tr>
                  </thead>
           </HeaderTemplate>
        <ItemTemplate>
       <tr>
       <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%></td>
        <ItemTemplate runat="server" ID="tdInfoHeader" Visible="false"><%#Eval("transid") %>
      </ItemTemplate>
      <td><%#Eval("programname") %></td>
      <td><%#Eval("mqacode") %></td>
      <td><%#Eval("duration") %></td>
     <td><%#Eval("shortsem") %></td>
    <td><%#Eval("longsem") %></td>
    </tr>
    </ItemTemplate>
      <FooterTemplate>
     </table>
    </FooterTemplate>
     </asp:Repeater>
         </div>
        </div>
                  </div>
                   
                  <div class="tab-pane fade" id="edit" role="tabpanel" aria-labelledby="edit-tab">
       <div>
           <h4><b>PROGRAM DETAILS</b></h4>
                                   <asp:Repeater ID="Repeater2" runat="server" DataSourceID="ObjectDataSource1" OnItemCommand="Repeater2_ItemCommand">
<HeaderTemplate>
    <table class="example1 table table-bordered table-striped">
         <thead>
                  <tr>
                    <th>Sl.No</th>
                    <th>Program Name</th>
                    <th>MQA Code</th>
                    <th>Duration (in Months)</th>
                    <th>Number of Short Semesters</th>
                      <th>Number of Long Semesters</th>
                      <th>Action</th>
                  </tr>
                  </thead>
           </HeaderTemplate>
        <ItemTemplate>
       <tr id="tr1" runat="server">
       <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%> 
           <asp:HiddenField ID="hfuptransid" runat="server" Value='<%# Eval("transid") %>'/>
       </td>
      <td>
          <asp:Label ID="lblpronm" runat="server" Text='<%#Eval("programname") %>'></asp:Label>
      </td>
      <td>
           <asp:Label ID="lblmcd" runat="server" Text='<%#Eval("mqacode") %>'></asp:Label>
      </td>
           <td>
          <asp:Label ID="lbldrtn" runat="server" Text='<%#Eval("duration") %>'></asp:Label>
           </td>         
     <td>
           <asp:Label ID="lblssem" runat="server" Text='<%#Eval("shortsem") %>'></asp:Label>
     </td>   
    <td>
          <asp:Label ID="lbllsem" runat="server" Text='<%#Eval("longsem") %>'></asp:Label>
    </td>
    <td> <asp:Button ID="updt" runat="server" Text="Edit" CssClass="btn btn-warning"/></td>          
    </tr>
    </ItemTemplate>
      <FooterTemplate>
     </table>
    </FooterTemplate>
     </asp:Repeater>
         </div>
       <div class="form-group">
           <asp:Panel ID="Panel1" runat="server" Visible="false">
               <asp:HiddenField ID="hfield" runat="server" />
                         <div class="col-lg-12">
                      <asp:Label ID="lblpname" runat="server" Text="Program Name:"></asp:Label>
                      <asp:TextBox ID="txtpname" runat="server" CssClass="form-control w-80" placeholder="Program name"></asp:TextBox>
                              <asp:RequiredFieldValidator runat="server" ControlToValidate="txtpname"
                                CssClass="text-danger" ErrorMessage="The program name is required." ValidationGroup="update" />
                  </div>

                 <div class="col-lg-12">
                      <asp:Label ID="lblcode" runat="server" Text="MQA Code:"></asp:Label>
                      <asp:TextBox ID="txtcode" runat="server" CssClass="form-control w-80" placeholder="MQA code"></asp:TextBox>
                      <asp:RequiredFieldValidator runat="server" ControlToValidate="txtcode"
                                CssClass="text-danger" ErrorMessage="The mqa code is required." ValidationGroup="update"  />
                  </div>
                      
                      <div class="col-lg-12">
                      <asp:Label ID="lbldura" runat="server" Text="Duration (in Months):"></asp:Label>
                      <asp:TextBox ID="txtdura" runat="server" CssClass="form-control w-80" placeholder="Duration"></asp:TextBox>
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="txtdura"
                                CssClass="text-danger" ErrorMessage="The duration is required." ValidationGroup="update"  />
                  </div>

                         <div class="col-lg-12">
                      <asp:Label ID="lblss" runat="server" Text="Number of Short Semesters:"></asp:Label>
                      <asp:TextBox ID="txtss" runat="server" CssClass="form-control w-80" placeholder="Number of short semesters"></asp:TextBox>
                              <asp:RequiredFieldValidator runat="server" ControlToValidate="txtss"
                                CssClass="text-danger" ErrorMessage="The short semester is required." ValidationGroup="update" />
                  </div>
                      <div class="col-lg-12">
                      <asp:Label ID="lblls" runat="server" Text="Number of Long Semesters:"></asp:Label>
                      <asp:TextBox ID="txtls" runat="server" CssClass="form-control w-80" placeholder="Number of long semesters"></asp:TextBox>
                          <asp:RequiredFieldValidator runat="server" ControlToValidate="txtls"
                                CssClass="text-danger" ErrorMessage="The long semester is required." ValidationGroup="update"  />
                          <asp:Label ID="lblmessage" runat="server" CssClass="text-center" ForeColor="Green"></asp:Label><br />
                           
                  </div>
                  
            
                       
                     <div class="row">
            <div class="col-12 text-right mb-2 mt-0">
          <asp:Button runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnup_Click" ValidationGroup="update" />
          </div>
                         </div>
                   
                       
                         
                       </asp:Panel>
                        </div>
                         </div>
                  <div class="tab-pane fade" id="remove" role="tabpanel" aria-labelledby="remove-tab">
                      <asp:HiddenField ID="hdfldid" runat="server" />
                      <div>

                          <h4><b>PROGRAM DETAILS</b></h4>
                            <asp:Repeater ID="Repeater3" runat="server" DataSourceID="ObjectDataSource1">
<HeaderTemplate>
    <table class="example1 table table-bordered table-striped">
         <thead>
                  <tr>
                    <th>Sl.No</th>
                    <th>Program Name</th>
                    <th>MQA Code</th>
                    <th>Duration (in Months)</th>
                    <th>Number of Short Semesters</th>
                      <th>Number of Long Semesters</th>
                      <th>Action</th>
                  </tr>
                  </thead>
           </HeaderTemplate>
        <ItemTemplate>
       <tr>
        <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%> 
           <asp:HiddenField ID="hfdtransid" runat="server" Value= '<%# Eval("transid") %>'/>
       </td>
      <td>
          <asp:Label ID="lbldpronm" runat="server" Text='<%#Eval("programname") %>'></asp:Label>
      </td>
      <td>
           <asp:Label ID="lbldmcd" runat="server" Text='<%#Eval("mqacode") %>'></asp:Label>
      </td>
           <td>
          <asp:Label ID="lblddrtn" runat="server" Text='<%#Eval("duration") %>'></asp:Label>
           </td>         
     <td>
           <asp:Label ID="lbldssem" runat="server" Text='<%#Eval("shortsem") %>'></asp:Label>
     </td>   
    <td>
          <asp:Label ID="lbldlsem" runat="server" Text='<%#Eval("longsem") %>'></asp:Label>
    </td>
           <td><asp:CheckBox ID="chbx" runat="server" /></td>
    </tr>
    </ItemTemplate>
      <FooterTemplate>
     </table>
    </FooterTemplate>
     </asp:Repeater>   
                      </div>
                    <asp:Label ID="lbldmsg" runat="server" CssClass="text-center" ForeColor="Green"></asp:Label><br />
                 
                  <div class="row">
            <div class="col-12 text-right mb-2 mt-0">
          <asp:Button runat="server" Text="Delete" CssClass="btn btn-primary" ValidationGroup="delete" OnClick="btndlt_Click" OnClientClick="return confirm('Are you sure want to delete this program?');"/>
          </div>
                  </div> 
                         </div>          
              <!-- /.card -->
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="grid_vw" TypeName="NSDocumentation.blprogram"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="grid_vw" TypeName="NSDocumentation.blupdateprogram">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="grid_vw" TypeName="NSDocumentation.bldeleteprogram"></asp:ObjectDataSource>
            </div>
          </div>
                
        </div>
        </div>
            </div>
       </div>
        </section>         
          </div>
      <footer class="main-footer">
    <div class="float-right d-none d-sm-block">
      <b>Version</b> 3.1.0
    </div>
    <strong>Copyright &copy; 2021-2022 <a href="https://adminlte.io">AdminLTE.io</a>.</strong> All rights reserved.
  </footer>

   <script type="text/javascript">
              $(document).ready(function () {
                  var selectedTab = $("#<%=hfTab.ClientID%>");
                  var tabId = selectedTab.val() != "" ? selectedTab.val() : "insertmqapa-tab";
                 $('#dvTab a[href="#' + tabId + '"]').tab('show');
                 $("#dvTab a").click(function () {
                     selectedTab.val($(this).attr("href").substring(1));
                 });
             });
        </script>
</asp:Content>

