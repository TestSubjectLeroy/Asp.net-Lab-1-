using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySqlConnect;


namespace SMTI_webApp
{
    public partial class ProjectsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StadardStatus();
            }
        }












        public void DisableBox(bool status)

        {
            txtProjectCode.ReadOnly = status;
            txtProjectTitle.ReadOnly = status;
            txtDueDate.ReadOnly = status;

        }

        public void Clear()
        {
            txtProjectCode.Text = "";
            txtProjectTitle.Text = "";
            txtDueDate.Text = "";
        }

        public void ButtonStatus(bool top, bool low)
        {

            btnNew.Enabled = top;
            btnCancel.Enabled = low;
            btnSave.Enabled = low;
        }

        public void StadardStatus()
        {
            var FillTable = new SqlConnClass();
            gvProjects.DataSource = FillTable.RetrieveAllProjectsInfo();
            gvProjects.DataBind();
            Clear();
            DisableBox(true);
            ButtonStatus(true, false);
        }

   
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            DisableBox(false);
            ButtonStatus(false, true);
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            StadardStatus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnClass saveNow = new SqlConnClass();

            saveNow.AddNewProjects(txtProjectCode.Text.Trim(), txtProjectTitle.Text.Trim(), Convert.ToDateTime(txtDueDate.Text.Trim()));
            gvProjects.DataSource = saveNow.RetrieveAllProjectsInfo();
            gvProjects.DataBind();
            StadardStatus();

        }

        protected void lnkEdit_OnClick(object sender, EventArgs e)
        {
            string pjCode = (sender as LinkButton).CommandArgument;
           
            SqlConnClass viewProject = new SqlConnClass();
           
            DataTable theProject = viewProject.ViewSingleProject(pjCode);

            txtProjectCode.Text = theProject.Rows[0]["Project_Code"].ToString().Trim();
            txtProjectTitle.Text = theProject.Rows[0]["Project_Title"].ToString();
            txtDueDate.Text =theProject.Rows[0]["Due_Date"].ToString();

            DisableBox(false);
            txtProjectCode.ReadOnly = true;
            ButtonStatus(false, true);
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            string pjCode = (sender as LinkButton).CommandArgument;

            SqlConnClass viewProject = new SqlConnClass();

            viewProject.DeleteSingleProjects(pjCode);
            StadardStatus();
        }
    }
}