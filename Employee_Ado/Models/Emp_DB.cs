using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Employee_Ado.Models;

namespace Employee_Ado.Models
{
    public class Emp_DB
    {
        //declare connection string
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //Return list of all Employees
        public List<empInfo> ListAll()
        {
            List<empInfo> lst = new List<empInfo>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new empInfo
                    {
                        Employee_id = Convert.ToInt32(rdr["Employee_id"]),
                        name = rdr["name"].ToString(),
                        age = rdr["age"].ToString(),
                        state = rdr["state"].ToString(),
                        country = rdr["country"].ToString(),
                    });
                }
                return lst;
            }
        }

        //Method for Adding an Employee
        public int Add(empInfo emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Employee_id", emp.Employee_id);
                com.Parameters.AddWithValue("@name", emp.name);
                com.Parameters.AddWithValue("@age", emp.age);
                com.Parameters.AddWithValue("@state", emp.state);
                com.Parameters.AddWithValue("@country", emp.country);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }

        //Method for Updating Employee record
        public int Update(empInfo emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Employee_id", emp.Employee_id);
                com.Parameters.AddWithValue("@name", emp.name);
                com.Parameters.AddWithValue("@age", emp.age);
                com.Parameters.AddWithValue("@state", emp.state);
                com.Parameters.AddWithValue("@country", emp.country);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }

        //Method for Deleting an Employee
        public int Delete(int Employee_id)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteStudent", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Employee_id", Employee_id);
                i = com.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
    }
}