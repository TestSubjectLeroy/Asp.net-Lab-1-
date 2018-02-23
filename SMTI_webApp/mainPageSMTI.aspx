<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainPageSMTI.aspx.cs" Inherits="SMTI_webApp.mainPageSMTI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
     <link href="Css/myCustom.css" rel="stylesheet" />
</head>
<body>
   <div class="container">
     <div class="navbar-wrapper">
      <div class="container">
        <nav class="navbar navbar-inverse navbar-static-top">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#menuIcon" aria-expanded="false" aria-controls="navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              <a class="navbar-brand" href="#">Project name</a>
            </div>
            <div id="menuIcon" class="navbar-collapse collapse">
              <ul class="nav navbar-nav">
                <li class="active"><a href="#">Home</a></li>
                <li><a href="mainPageSMTI.aspx">Students</a></li>
                <li><a href="ProjectsForm.aspx">Projects</a></li>
              </ul>
            </div>
          </div>
        </nav>
      </div>
    </div>



    <form  class="container" id="studentForm" runat="server">
       <div class="container row">
         <div class="col-sm-6" >

          <div class="col-sm-8">
            <h1>Student Info</h1>
            <div >
                <asp:TextBox ID="txtStudentNumber" runat="server" cssclass="form-control myTextBox"   placeholder="Student Number" required="required" TextMode="Number" />
                <br />
            </div>
            <div >
                <asp:TextBox ID="txtFirstName" runat="server" cssclass="form-control myTextBox" placeholder="First Name" required="required"  />
                <br />
            </div>
              <div>
                <asp:TextBox ID="txtLastName" runat="server" cssclass="form-control myTextBox" placeholder="Last Name" required="required" />
                <br />
            </div>
              <div >
                <asp:TextBox ID="txtEmail" runat="server" cssclass="form-control myTextBox" placeholder="Email" required="required" TextMode="Email" />
                <br />
                  </div>
            
               <div  >
            <asp:Button ID="btnNew" CssClass="btn" Text=" New" runat="server" OnClick="btnNew_Click"  />
            <asp:Button ID="btnSave"  CssClass="btn" Text="Save" runat="server" OnClick="Save_Click" />
            <asp:Button ID="btnCancel" CssClass="btn" type="button" Text="Cancel" runat="server" OnClick="btnCancel_Click" formnovalidate="true" />
            <br />
          </div>
        </div>
        <div class="col-sm-11">
            <h5>His Projects:</h5>
            <asp:GridView ID="gvThisStudentProjects" AutoGenerateColumns="false" runat="server">
                 <Columns>
                    <asp:BoundField DataField = "Project_Code" HeaderText="Project Code" />
                    <asp:BoundField DataField = "Project_Title" HeaderText="Project Title" />
                    <asp:BoundField DataField = "Due_Date" HeaderText="Due Date" DataFormatString="{0:yyyy/MM/dd}" /> 
                    <asp:TemplateField HeaderText="Options">
                            <ItemTemplate>
                             <asp:LinkButton id="LnkRemove" CssClass="btn btn-xs btn-danger"  CommandArgument='<%# Eval("Project_Code") %>' runat="server" OnClientClick="return confirm('Are you sure you want to Remove this Project ?')" >Remove</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
      </div>
   

        <div class="col-sm-6 " >
         <div class="col-sm-6" >
             <h2> Student List</h2>
            <asp:GridView ID="gvStudents" CssClass="table-hover table-bordered" AutoGenerateColumns ="False" runat="server"  Width="531px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"  >
                   <AlternatingRowStyle BackColor="White" />
                   <Columns>
                       <asp:BoundField DataField ="StudentNumber" HeaderText="Student Number" ItemStyle-Width="10%" ItemStyle-Wrap="false"  />
                        <asp:BoundField DataField ="FirstName" HeaderText="First Name" ItemStyle-Wrap="false " >
                      
                        <HeaderStyle HorizontalAlign="Center" />
                       </asp:BoundField>
                        <asp:BoundField DataField ="LastName" HeaderText="Last Name" ItemStyle-Wrap="false" >
                        <HeaderStyle HorizontalAlign="Center" />
                       </asp:BoundField>
                        <asp:BoundField DataField ="Email" HeaderText=" Email"  ItemStyle-Wrap="false">
                     
                       <HeaderStyle HorizontalAlign="Center" />
                       </asp:BoundField>
                     
                       <asp:TemplateField HeaderText="Options">
                            <ItemTemplate>
                            <asp:LinkButton ID="lnkHisProjects" CssClass="btn btn-xs btn-default" CommandArgument='<%# Eval("StudentNumber") %>' runat="server" OnClick="lnkHisProjects_OnClick" >Projects</asp:LinkButton>
                             <asp:LinkButton id="lnkEdit" CssClass="btn btn-xs btn-default "  CommandArgument='<%# Eval("StudentNumber") %>' runat="server" OnClick="edit_OnClick">Edit</asp:LinkButton>
                             <asp:LinkButton id="LnkDel" CssClass="btn btn-xs btn-default"  CommandArgument='<%# Eval("StudentNumber") %>' runat="server" OnClick="delete_OnClick" OnClientClick="return confirm('Are you sure you want to delete this student ?')" >Delete</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                 </Columns>
                   <FooterStyle BackColor="#CCCC99" />
                   <HeaderStyle HorizontalAlign="Center" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                   <RowStyle BackColor="#F7F7DE" />
                   <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#FBFBF2" />
                   <SortedAscendingHeaderStyle BackColor="#848384" />
                   <SortedDescendingCellStyle BackColor="#EAEAD3" />
                   <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
             <br />
            </div>
            <br />
            <hr />
             <div class="col-sm-11" >
                 <h2>Project Available</h2>
                  <asp:GridView ID="gvProjects" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField = "Project_Code" HeaderText="Project Code" />
                    <asp:BoundField DataField = "Project_Title" HeaderText="Project Title" />
                    <asp:BoundField DataField = "Due_Date" HeaderText="Due Date" DataFormatString="{0:yyyy/MM/dd}" /> 
                       <asp:TemplateField HeaderText="Options">
                            <ItemTemplate>
                             <asp:LinkButton id="LnkAdd" CssClass="btn btn-xs btn-success"  CommandArgument='<%# Eval("Project_Code") %>' runat="server"  OnClientClick="return confirm('Are you sure you want to Add this Projects ?')" >Add</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                       </Columns>
            </asp:GridView> 
             </div>
         </div>
       </div>
     
   </form>
    <script src="Js/bootstrap.min.js"></script>
 </div>
</body>
</html>
