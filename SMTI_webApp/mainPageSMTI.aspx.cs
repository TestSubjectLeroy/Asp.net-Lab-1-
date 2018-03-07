using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySqlConnect;

namespace SMTI_webApp
{
    public partial class mainPageSMTI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               StadardStatus();
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            DisableBox(false);
            ButtonStatus(false,true);
        }

        protected void Save_Click(object sender, EventArgs e)
        {


            StudentsClass saveNow = new StudentsClass();
            saveNow.AddNewStudent(txtStudentNumber.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtEmail.Text.Trim());
            gvStudents.DataSource = saveNow.RetrieveAllStudentsInfo();
            gvStudents.DataBind();
            StadardStatus();
        }

        protected void edit_OnClick(object sender, EventArgs e)
        {

            string stNum = (sender as LinkButton).CommandArgument;

            StudentsClass viewStudent = new StudentsClass();
            DataTable theStudent = viewStudent.ViewSingleStudent(stNum);

            txtStudentNumber.Text = theStudent.Rows[0]["StudentNumber"].ToString().Trim();
            txtFirstName.Text = theStudent.Rows[0]["FirstName"].ToString();
            txtLastName.Text = theStudent.Rows[0]["LastName"].ToString();
            txtEmail.Text = theStudent.Rows[0]["Email"].ToString();

            DisableBox(false);
            txtStudentNumber.ReadOnly = true;
            ButtonStatus(false,true);

        }

        protected void delete_OnClick(object sender, EventArgs e)
        {
            string stNum = (sender as LinkButton).CommandArgument;

            StudentsClass viewStudent = new StudentsClass();

            viewStudent.DeleteSingleStudent(stNum);
            StadardStatus();

            //SqlConnection sqlConn = new SqlConnection();
            //sqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["SMTI_Db"].ConnectionString;

            //sqlConn.Open();

            //SqlCommand sqlCmd = new SqlCommand("DeleteStudentByNumber", sqlConn);
            //sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@StudentNumber", stNum);
            //sqlCmd.ExecuteNonQuery();
            //sqlConn.Close();

            StadardStatus();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            StadardStatus();
        }

        protected void lnkHisProjects_OnClick(object sender, EventArgs e) {

            string stNum = (sender as LinkButton).CommandArgument;

            StudentsClass viewStudentProject = new StudentsClass();
            gvThisStudentProjects.DataSource  = viewStudentProject.hisProjects(stNum);
            gvThisStudentProjects.DataBind();

            var FillTableProjects = new ProjectsClass();
            gvProjects.DataSource = FillTableProjects.RetrieveAllProjectsInfo();
            gvProjects.DataBind();

            StudentsClass viewStudentInfo = new StudentsClass();
            DataTable theStudent = viewStudentInfo.ViewSingleStudent(stNum);


            txtStudentNumber.Text = theStudent.Rows[0]["StudentNumber"].ToString().Trim();
            txtFirstName.Text = theStudent.Rows[0]["FirstName"].ToString();
            txtLastName.Text = theStudent.Rows[0]["LastName"].ToString();
            txtEmail.Text = theStudent.Rows[0]["Email"].ToString();


            DisableBox(true);
        }

        protected void LnkAdd_OnClick(object sender, EventArgs e) {

            string pjCode = (sender as LinkButton).CommandArgument;
            string pjSNum = txtStudentNumber.Text;

            var addingIt = new ProjectsClass();
            addingIt.AddProjectToStudent(pjCode, pjSNum);

            StudentsClass viewStudentProject = new StudentsClass();
            gvThisStudentProjects.DataSource = viewStudentProject.hisProjects(pjSNum);
            gvThisStudentProjects.DataBind();

         }

        protected void lnkRemove_OnClick(object sender, EventArgs e) {

            string pjCode = (sender as LinkButton).CommandArgument;
            string pjSNum = txtStudentNumber.Text;

            var removingIt = new ProjectsClass();

            removingIt.DeleteProjectOfStudent(pjCode, pjSNum);
            StudentsClass viewStudentProject = new StudentsClass();
            gvThisStudentProjects.DataSource = viewStudentProject.hisProjects(pjSNum);
            gvThisStudentProjects.DataBind();

        }




        //side functions.....
        public void DisableBox(bool status)

            {
            txtStudentNumber.ReadOnly = status;
            txtFirstName.ReadOnly = status;
            txtLastName.ReadOnly = status;
            txtEmail.ReadOnly = status;

            }

        public void Clear()
        {
            txtStudentNumber.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";

            gvThisStudentProjects.DataSource = null;
            gvThisStudentProjects.DataBind();
            gvProjects.DataSource = null;
            gvProjects.DataBind();
            gvStudents.DataSource = null;
            gvStudents.DataBind();
        }

        public void ButtonStatus(bool top, bool low) {
           
            btnNew.Enabled = top;
            btnCancel.Enabled = low;
            btnSave.Enabled = low;
            
        }

        public void StadardStatus()
        {
            Clear();
            DisableBox(true);
            ButtonStatus(true, false);

            var FillTableStudent = new StudentsClass();
            gvStudents.DataSource = FillTableStudent.RetrieveAllStudentsInfo();
            gvStudents.DataBind();
        }

      
    }
}
