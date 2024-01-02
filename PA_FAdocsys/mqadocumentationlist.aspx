<%@ Page Title="MQA Documentation List" Language="C#" MasterPageFile="~/Documentation.master" AutoEventWireup="true" CodeFile="mqadocumentationlist.aspx.cs" Inherits="mqadocumentationlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <style>
           .select2-container .select2-selection--single {
    box-sizing: border-box;
    cursor: pointer;
    display: block;
    height: 38px;
    width: 1000px;
    user-select: none;
    -webkit-user-select: none;
}
            </style>
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
            <h3 style="text-align:center">MQA Document PA Submission Checklist</h3>
          </div>
        </div>
       <br />
       <div class="text-center">
    <asp:Button ID="mqapa" runat="server" Text="MQA/PA" CssClass="btn btn-primary" OnClick="mqapa_Click"/>
       <asp:Button ID="mqafa" runat="server" Text="MQA/FA" CssClass="btn btn-primary"  />
               </div>
             <asp:Panel ID="papanel" runat="server" Visible="false"><br /><br />
       <div>
              <div class="card card-primary card-outline">
          <div class="card-header">
            <h3 class="card-title">
              <i class="fas fa-file-alt"></i>
            MQA Document Submission Checklist (PA Submission)
            </h3>
          </div>
          <div class="card-body" id="dvTab">
              <asp:HiddenField ID="hfTab" runat="server" />
            <ul class="nav nav-tabs" id="custom-content-below-tab" role="tablist">
              <li class="nav-item">
                <a class="nav-link active" id="insertmqapa-tab" data-toggle="pill" href="#insertmqapa" role="tab" aria-controls="insertmqapa" aria-selected="true">Add MQA/PA</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" id="updatemqapa-tab" data-toggle="pill" href="#updatemqapa" role="tab" aria-controls="updatemqapa" aria-selected="false">Update MQA/PA</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" id="deletemqapa-tab" data-toggle="pill" href="#deletemqapa" role="tab" aria-controls="deletemqapa" aria-selected="false">Delete MQA/PA</a>
              </li>
            </ul>
            <div class="tab-content" id="custom-content-below-tabContent">
              <div class="tab-pane fade show active" id="insertmqapa" role="tabpanel" aria-labelledby="insertmqapa-tab">             
               <asp:Label ID="lblprogram" runat="server" Text="Program Name:"></asp:Label>
               <asp:DropDownList ID="ddlprogram" runat="server" DataSourceID="ObjectDataprogram" DataTextField="programname" DataValueField="transid"
                    CssClass="form-control w-80 programSelect" AppendDataBoundItems="true" style="height:1000px" AutoPostBack="true" OnSelectedIndexChanged="ddlprogram_SelectedIndexChanged" >
           <asp:ListItem Text="-----Please Select-----" Value="">
                     </asp:ListItem> 
               </asp:DropDownList>
               <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlprogram"
                                CssClass="text-danger" ErrorMessage="Please select a program name." ValidationGroup="mqa"  /><br /><br />
               <%-- <asp:HiddenField ID="hfprogtransid" runat="server" Value= '<%# Eval("transid") %>'/>--%>
                              <asp:Panel ID="Panel3" runat="server" Visible="false">
                                  <asp:Repeater ID="Repeater1" runat="server" DataSourceID="objds_dummy" OnItemDataBound="Repeater1_ItemDataBound">
                                      <HeaderTemplate>
                                          <table class="table table-bordered">                                          
                                                  <tr>
                                                      <th>No.</th>
                                                      <th>Document</th>
                                                      <th>Conditions</th>
                                                      <th>Remarks</th>
                                                      <th>AQD Initial</th>
                                                  </tr>                                     
                                      </HeaderTemplate>
                                      <ItemTemplate>
                                          <asp:Repeater ID="parepeater" runat="server" DataSourceID="ObjectDataSourcemqapa">
                                              <ItemTemplate>
                                                  <tr>
                                                      <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
                                                          <asp:HiddenField ID="hfpatransid" runat="server" Value='<%# Eval("transid") %>' />
                                                      </td>
                                                      <td>
                                                          <asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("doctype") %>'></asp:Label>
                                                      </td>
                                                      <td>
                                                          <asp:TextBox ID="txtconditions" runat="server" CssClass="form-control" type='<%#(((RepeaterItem)Container).ItemIndex+1).ToString()=="15"?"Date":"Text"%>'></asp:TextBox>
                                                      </td>
                                                      <td>
                                                          <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control" type='<%#(((RepeaterItem)Container).ItemIndex+1).ToString()=="15"?"Date":"Text"%>'></asp:TextBox>
                                                      </td>
                                                      <td>
                                                          <asp:TextBox ID="txtaqdinitial" runat="server" CssClass="form-control" type='<%#(((RepeaterItem)Container).ItemIndex+1).ToString()=="15"?"Date":"Text"%>'></asp:TextBox>

                                                      </td>
                                                  </tr>
                                              </ItemTemplate>
                                          </asp:Repeater>
                                          <asp:Repeater ID="Repeater2" runat="server">
                                                 <ItemTemplate>
                                    <tr>
                                        <td> <asp:Label ID="Label3" runat="server" Text="14" Visible='<%# Eval("doctype").ToString() == "Approval Senate" ? true : false %>'></asp:Label></td>

                                        <td>
                                              <asp:HiddenField ID="hftransid" runat="server" Value='<%# Eval("transid") %>' />
                                           <%# Eval("doctype") %>

                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Visible=' <%# Eval("doctype").ToString() == "Approval Senate" ? true : false %>'>
                                                 <asp:ListItem Value="Yes">
                                                 &nbsp; Yes
                                                </asp:ListItem>
                                                <asp:ListItem Value="No">
                                                   &nbsp; No
                                                </asp:ListItem>
                                            </asp:RadioButtonList>

                                             <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="Date"  Visible=' <%# Eval("doctype").ToString() == "Date of Senate Meeting" ? true : false %>'></asp:TextBox>
                                             <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="3"  Visible=' <%# Eval("doctype").ToString() == "Dean’s Verification" ? true : false %>'></asp:TextBox>
                                             <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="3"  Visible=' <%# Eval("doctype").ToString() == "Director of Curriculum Affairs Approval" ? true : false %>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="<br><br>(Signature)" Visible='<%# Eval("doctype").ToString() == "Dean’s Verification" ? true : false %>'></asp:Label>
                                             <asp:Label ID="Label2" runat="server" Text="<br><br>(Signature)" Visible='<%# Eval("doctype").ToString() == "Director of Curriculum Affairs Approval" ? true : false %>'></asp:Label>
                                        </td>
                                       <%-- </td>--%>
                                    </tr>
                                   <%-- <tr>
                                        <td>Date of Senate Meeting</td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" type="Date"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Dean’s Verification</td>
                                        <td>
                                            <textarea id="TextArea1" cols="20" rows="2" runat="server" class="form-control"></textarea></td>
                                        <td><br /><br />(Signature)</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Director of Curriculum Affairs Approval</td>
                                        <td>
                                            <textarea id="TextArea2" cols="20" rows="2" runat="server" class="form-control"></textarea></td>
                                        <td><br /><br />(Signature)</td>
                                    </tr>--%>
                                </ItemTemplate>
                                          </asp:Repeater>
                                      </ItemTemplate>
                                      <FooterTemplate>
                                          </table>
                                      </FooterTemplate>
                                      
                                  </asp:Repeater>
                <div class="row">
            <div class="col-12 text-right mb-2 mt-0">
             <asp:Button ID="btn_mqapasave" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_mqapasave_Click"  ValidationGroup="mqa" />
          </div>
                               </div>            
                   </asp:Panel>
              </div>
              <div class="tab-pane fade" id="updatemqapa" role="tabpanel" aria-labelledby="updatemqapa-tab">
                  <asp:Label ID="lblselectpro" runat="server" Text="Program Name:"></asp:Label><br />
               <asp:DropDownList ID="ddlselectpro" runat="server" DataSourceID="ObjectDataprogram" DataTextField="programname" 
                   DataValueField="transid" CssClass="form-control w-80 programSelect" AppendDataBoundItems="true" 
                   OnSelectedIndexChanged="ddlselectpro_SelectedIndexChanged" AutoPostBack="true" >
                    <asp:ListItem Text="-----Please Select-----" Value="">
                     </asp:ListItem>   
               </asp:DropDownList>
               <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlselectpro"
                                CssClass="text-danger" ErrorMessage="Please select a program name." ValidationGroup="updatemqa"  /><br /><br />
               <%-- <asp:HiddenField ID="hfprogtransid" runat="server" Value= '<%# Eval("transid") %>'/>--%>
                  <asp:Panel ID="Panel2" runat="server" Visible="false">
            <asp:Repeater ID="updaterepeater" runat="server" DataSourceID="ObjectDataSource2">
                  <HeaderTemplate>
            <table class="table table-bordered table-striped">
                 <thead>
                <tr>
                      <th>No.</th>
                    <th>Document</th>
                    <th>Conditions</th>
                    <th>Remarks</th>
                    <th>AQD Initial</th>
                </tr>
                        </thead>
          </HeaderTemplate>
             
          <ItemTemplate>
             <tr>
                <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
           <asp:HiddenField ID="HiddenField1" runat="server" />
                <%--    <asp:Label ID="HiddenField1" runat="server" Visible="false"></asp:Label>--%>
                <asp:HiddenField ID="hfuptransid" runat="server" Value='<%# Eval("transid") %>' />
                </td>
                <td> <asp:Label ID="lbldocument" runat="server" Text='<%#Eval("doctype") %>'></asp:Label></td>
                  <td>
                      <asp:TextBox ID="txtcon" runat="server" CssClass="form-control" type='<%#(((RepeaterItem)Container).ItemIndex+1).ToString()=="15"?"Date":"Text"%>'></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtre" runat="server" CssClass="form-control" type='<%#(((RepeaterItem)Container).ItemIndex+1).ToString()=="15"?"Date":"Text"%>'></asp:TextBox></td>
                  <td>
                      <asp:TextBox ID="txtaqdinit" runat="server" CssClass="form-control" type='<%#(((RepeaterItem)Container).ItemIndex+1).ToString()=="15"?"Date":"Text"%>'></asp:TextBox></td>
             </tr>
          </ItemTemplate>
             
          <FooterTemplate>
             </table>
          </FooterTemplate>

            </asp:Repeater>
                <div class="row">
            <div class="col-12 text-right mb-2 mt-0">
             <asp:Button ID="btnupmqapa" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnupmqapa_Click" ValidationGroup="updatemqa"  />
          </div>
                               </div>
                      </asp:Panel>
               
</div>
              <div class="tab-pane fade" id="deletemqapa" role="tabpanel" aria-labelledby="deletemqapa-tab">
              <asp:Label ID="lbldprogram" runat="server" Text="Program Name:"></asp:Label><br />
               <asp:DropDownList ID="ddldprogram" runat="server" DataSourceID="ObjectDataprogram" DataTextField="programname" DataValueField="transid" 
                   CssClass="form-control w-80 programSelect" AppendDataBoundItems="true" AutoPostBack="true" 
                   OnSelectedIndexChanged="ddldeleteprogram_SelectedIndexChanged">
                    <asp:ListItem Text="-----Please Select-----" Value="">
                     </asp:ListItem>   
               </asp:DropDownList>
               <asp:RequiredFieldValidator runat="server" ControlToValidate="ddldprogram"
                                CssClass="text-danger" ErrorMessage="Please select a program name." ValidationGroup="deletemqa"  /><br /><br />
               <%-- <asp:HiddenField ID="hfprogtransid" runat="server" Value= '<%# Eval("transid") %>'/>--%>
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Repeater ID="deletemqarepeater" runat="server">
                  <HeaderTemplate>
            <table class="table table-bordered table-striped">
                 <thead>
                <tr>
                      <th>No.</th>
                    <th>Document</th>
                    <th>Conditions</th>
                    <th>Remarks</th>
                    <th>AQD Initial</th>
                     <th>Action</th>
                </tr>
                        </thead>
          </HeaderTemplate>
             
          <ItemTemplate>
             <tr>
                <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
         <asp:HiddenField ID="hfdeltransid" runat="server" Value='<%# Eval("transid") %>' />
                </td>
                <td><%#Eval("doctype") %></td>
                  <td>
                      <%#Eval("conditions") %></td>
                <td>
              <%#Eval("remarks") %></td>
                  <td>
                    <%#Eval("aqdinitial") %></td>
                 <td>
                     <asp:CheckBox ID="chkdelete" runat="server"/>
                 </td>
             </tr>
          </ItemTemplate>
             
          <FooterTemplate>
             </table>
          </FooterTemplate>

            </asp:Repeater>
                <div class="row">
            <div class="col-12 text-right mb-2 mt-0">
             <asp:Button ID="btndeletemqa" runat="server" Text="Delete" CssClass="btn btn-primary" ValidationGroup="deletemqa" 
                 OnClick="btndeletemqa_Click" OnClientClick="return confirm('Are you sure want to delete this record?');" Visible="false"/>
          </div>
                               </div>
                           </asp:Panel>
               
              </div>
            </div>         
            </div>

          <!-- /.card -->
        </div>
           
           </div>
            </asp:Panel>
       <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="rectification_vw" 
           TypeName="NSDocumentation.blmqapadocs"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="repeater_vw" 
           TypeName="NSDocumentation.blmqapadocs"></asp:ObjectDataSource>
       <asp:ObjectDataSource ID="ObjectDataSourcemqapa" runat="server" SelectMethod="mqapa_vw" 
           TypeName="NSDocumentation.blmqapadocs"></asp:ObjectDataSource>
       <asp:ObjectDataSource ID="ObjectDataprogram" runat="server" SelectMethod="grid_vw" 
           TypeName="NSDocumentation.blprogram"></asp:ObjectDataSource>
       <asp:ObjectDataSource runat="server" ID="objds_dummy" SelectMethod="dummydt" TypeName="Clsutility">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="row_num" Type="Int32"></asp:Parameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
     <%--  <asp:ObjectDataSource ID="ObjectDataSourcetransid" runat="server" SelectMethod="vwbytransid" TypeName="NSDocumentation.blupdatemqapadocs+bldeletemqapadocs">
           <SelectParameters>
               <asp:Parameter DbType="Guid" Name="programid"></asp:Parameter>
           </SelectParameters>
       </asp:ObjectDataSource>--%>
       </div>
  </section>
          </div>
      <footer class="main-footer">
    <div class="float-right d-none d-sm-block">
      <b>Version</b> 3.1.0
    </div>
    <strong>Copyright &copy; 2014-2021 <a href="https://adminlte.io">AdminLTE.io</a>.</strong> All rights reserved.
  </footer>
   
<script>
    $(document).ready(function () {
        $(".programSelect").select2();
    });
</script>s
    
   <script type="text/javascript">
              $(document).ready(function () {
                  var selectedTab = $("#<%=hfTab.ClientID%>");
                  var tabId = selectedTab.val() != "" ? selectedTab.val() : "add-tab";
                 $('#dvTab a[href="#' + tabId + '"]').tab('show');
                 $("#dvTab a").click(function () {
                     selectedTab.val($(this).attr("href").substring(1));
                 });
             });
        </script>
</asp:Content>

