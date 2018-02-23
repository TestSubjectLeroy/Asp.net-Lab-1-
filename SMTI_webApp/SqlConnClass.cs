using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




namespace MySqlConnect
{
    public class SqlConnClass 

    {
        SqlConnection sqlConn = new SqlConnection();
        public DataTable sqlTable = new DataTable();


        public SqlConnClass()
        {
           sqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["SMTI_Db"].ConnectionString;
        }


        ///STUDENTS
            //VIEW ALL STUDENTS
            //exec procedure StuddentViewAll and fill table with all students
        public DataTable RetrieveAllStudentsInfo()
        {
            try
            {
                sqlConn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("StudentViewAll", sqlConn);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(sqlTable);
            }
            catch (Exception)
            {


            }
            finally {
                sqlConn.Close();
            }

            return sqlTable;
        }



        //  Add/update STUDENT
        public void AddNewStudent(string stNumber, string fName, string lName, string email)
        {

            try
            {
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("StudentCreateOrUpdate", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@StudentNumber", stNumber);
                sqlCmd.Parameters.AddWithValue("@FirstName", fName);
                sqlCmd.Parameters.AddWithValue("@LastName", lName);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.ExecuteNonQuery();

            }
            catch (Exception)
            {


            }
            finally
            {
                sqlConn.Close();
            }

        }
        //VIEW Single STUDENT
        public DataTable ViewSingleStudent(string stNumber)
        {
            try
            {
                sqlConn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("StudentViewByNumber", sqlConn);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@StudentNumber", stNumber);
                sqlDa.Fill(sqlTable);


            }
            catch (Exception)
            {


            }
            finally
            {
                sqlConn.Close();
            }

            return sqlTable;

        }

        //DELETE STUDENTS
        public void DeleteSingleStudent(string stNumber)
        {
            try
            {
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("DeleteStudentByNumber", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@StudentNumber", stNumber);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally
            {
                sqlConn.Close();
            }
            
        }

        //AllStudent's Projects

        public DataTable hisProjects(string stNum) {

            try
            {
                sqlConn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ViewProjectsOfStudents", sqlConn);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@StudentNumber", stNum);
                sqlDa.Fill(sqlTable);


            }
            catch (Exception)
            {


            }
            finally
            {
                sqlConn.Close();
            }

            return sqlTable;
             
        }






     ///PROJECTS


        // VIEW ALL PROJECTS
        //exec procedure ProjectsViewAll and fill table with all Projects------------------------
        public DataTable RetrieveAllProjectsInfo()
        {
            try
            {
                sqlConn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ProjectsViewAll", sqlConn);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(sqlTable);
            }
            catch (Exception)
            {
            }
            finally
            {
                sqlConn.Close();
            }

            return sqlTable;
        }

        //ADD A PROJECT
        //exec Procedure ProjectCreateOrUpdate to ADD or Update a Projects
        public void AddNewProjects (string pjCode, string pjTitle, DateTime pjDueDate)
        {

            try
            {
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("ProjectsCreateOrUpdate", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Project_Code", pjCode);
                sqlCmd.Parameters.AddWithValue("@Project_Title", pjTitle);
                sqlCmd.Parameters.AddWithValue("@Due_Date", pjDueDate);
                sqlCmd.ExecuteNonQuery();

            }
            catch (Exception)
            {


            }
            finally
            {
                sqlConn.Close();
            }
        }

        //DELETE PROJECT

        public void DeleteSingleProjects(string pjCode)
        {
            try
            {
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("DeleteProjectByCode", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Project_Code", pjCode);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally
            {
                sqlConn.Close();
            }

        }

        //VIEW Single Project
        public DataTable ViewSingleProject(string pjCode)
        {
            try
            {
                sqlConn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ProjectViewByCode", sqlConn);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@Project_Code", pjCode);
                sqlDa.Fill(sqlTable);
            }
            catch (Exception)
            {


            }
            finally
            {
                sqlConn.Close();
            }

            return sqlTable;

        }









    }
}