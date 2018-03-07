using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMTI_webApp;
using System.Data;
using System.Data.SqlClient;
using MySqlConnect;
using System.Configuration;

namespace SMTI_webApp
{
   

    public class StudentsClass 
    {
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public SqlConnection sqlConn = new SqlConnection();
        public DataTable sqlTable = new DataTable();


        public StudentsClass()
        {
            sqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["SMTI_Db"].ConnectionString;
        }
        public StudentsClass(string studentNumber, string firstName, string lastName, string email)
        {
            this.StudentNumber = studentNumber;
            this.FirstName = firstName;
            this.LastName = LastName;
            this.Email = email;
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
            finally
            {
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

        public DataTable hisProjects(string stNum)
        {

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



    }
}