using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMTI_webApp
{
    public class ProjectsClass
    {




        public SqlConnection sqlConn = new SqlConnection();
        public DataTable sqlTable = new DataTable();


        public ProjectsClass()
        {
            sqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["SMTI_Db"].ConnectionString;
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
        public void AddNewProjects(string pjCode, string pjTitle, DateTime pjDueDate)
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




        //LINK PROJECT TO STUDENT!!

        public void AddProjectToStudent(string pjCode, string pjSNum)
        {

            try
            {
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("AddProjectToStudent", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Project_Code", pjCode);
                sqlCmd.Parameters.AddWithValue("@StudentNumber", pjSNum);
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

        public void DeleteProjectOfStudent(string pjCode, string pjSNum)
        {
            try
            {
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("DeleteProjectOfStudent", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Project_Code", pjCode);
                sqlCmd.Parameters.AddWithValue("@StudentNumber", pjSNum);
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
    }
}