using CURD_ADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CURD_ADO.NET.DAL
{
    public class Employe1DAL
    {


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Employe1DAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public List<Employee1> GetAllEmployee()
        {
            List<Employee1> elist = new List<Employee1>();
            string qry = "select * from Employee1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee1 e = new Employee1();
                    e.Id = Convert.ToInt32(dr["Id"]);
                    e.Name = dr["Name"].ToString();
                    e.Salary = Convert.ToInt32(dr["Salary"]);
                    elist.Add(e);
                }
            }
            con.Close();
            return elist;
        }
        public Employee1 GetEmployee1ById(int id)
        {
            Employee1 e = new Employee1();
            string qry = "select * from Employee1 where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    e.Id = Convert.ToInt32(dr["Id"]);
                    e.Name = dr["Name"].ToString();
                    e.Salary = Convert.ToInt32(dr["Salary"]);
                  
                }
            }
            con.Close();
            return e;
        }

        public int AddEmployee(Employee1 emp)
        {
            string qry = "insert into Employee1 values(@name,@salary)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateEmployee(Employee1 emp)
        {
            string qry = "update Employee1 set Name=@name , Salary=@salary where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        public int DeleteEmployee(int id)
        {
            string qry = "delete from Employee1 where Id=@id";
             cmd = new SqlCommand(qry, con);
             cmd.Parameters.AddWithValue("@id", id);
             con.Open();
             int result = cmd.ExecuteNonQuery();
             con.Close();
             return result;

         
        }

    }
}
