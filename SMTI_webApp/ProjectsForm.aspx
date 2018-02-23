<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectsForm.aspx.cs" Inherits="SMTI_webApp.ProjectsForm" %>

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
              <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              <a class="navbar-brand" href="#">Project name</a>
            </div>
            <div id="navbar" class="navbar-collapse collapse">
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

 <div class="container">
  <form class="row container" id="studentForm" runat="server">
      <div class="col-md-6">
            <h1>Project Info</h1>
            <div>

                <asp:TextBox ID="txtProjectCode" runat="server" cssclass="form-control myTextBox"   placeholder="Project Code" required="required"  />
            </div>
          <br />
            <div>
                <asp:TextBox ID="txtProjectTitle" runat="server" cssclass="form-control myTextBox" placeholder="Project Title" required="required"  />
            </div>
          <br />
              <div>
                <asp:TextBox ID="txtDueDate" runat="server" cssclass="form-control myTextBox" placeholder="Due Date" TextMode="Date" required="required" />
                  </div>
          <br />
           <div>
                <asp:TextBox ID="TextBox1" runat="server" cssclass="form-control myTextBox" placeholder="Due Date" />
            </div>
          <br />
            <br />
               <div >
            <asp:Button ID="btnNew" CssClass="btn" Text=" New" runat="server" OnClick="btnNew_Click"  />
            <asp:Button ID="btnSave"  CssClass="btn" Text="Save" runat="server" OnClick="btnSave_Click"  />
            <asp:Button ID="btnCancel" CssClass="btn" type="button" Text="Cancel" runat="server" OnClick="btnCancel_Click1"   formnovalidate="true"  />
          </div>
       
       </div>
   

        <div class="col-md-6">
         <h2> Project List</h2>
            <asp:GridView ID="gvProjects" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField = "Project_Code" HeaderText="Project Code" />
                    <asp:BoundField DataField = "Project_Title" HeaderText="Project Title" />
                    <asp:BoundField DataField = "Due_Date" HeaderText="Due Date" DataFormatString="{0:yyyy/MM/dd}" /> 
                    <asp:TemplateField HeaderText="Options">
                            <ItemTemplate>
                             <asp:LinkButton id="lnkEdit" CssClass="btn btn-xs btn-primary "  CommandArgument='<%# Eval("Project_Code") %>' runat="server" OnClick="lnkEdit_OnClick">Edit</asp:LinkButton>
                             <asp:LinkButton id="LnkDelete" CssClass="btn btn-xs btn-danger"  CommandArgument='<%# Eval("Project_Code") %>' runat="server" OnClick="lnkDelete_OnClick" OnClientClick="return confirm('Are you sure you want to Delete this Project ?')" >Delete</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                </Columns>
            </asp:GridView> 
         </div>
    
   </form>
</div>
    <script src="Js/bootstrap.min.js"></script>
        </div>
</body>
</html>
