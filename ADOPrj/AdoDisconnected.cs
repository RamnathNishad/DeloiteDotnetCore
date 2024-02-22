using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace ADOPrj
{
    internal class AdoDisconnected
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public AdoDisconnected()
        {
            //configure connection
            string conStr = "Data Source=(localdb)\\ProjectModels;Initial Catalog=EmpDB;Integrated Security=True;";
            con = new SqlConnection(conStr);

            //configure DataAdapter
            da = new SqlDataAdapter("select * from tbl_employee", con);

            //fill the DataSet with result
            ds = new DataSet();
            da.Fill(ds, "tbl_employee");

            //add primary key constraint in DataSet Table
            ds.Tables[0].Constraints.Add("pk1", ds.Tables[0].Columns[0], true);
        }
        public List<Employee> GetEmps()
        {
            List<Employee> list= new List<Employee>();
            //traverse the DataSet Rows and add the records into collection
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Employee emp = new Employee
                {
                    Ecode = (int)row[0],
                    Ename = row[1].ToString(),
                    Salary = (int)row[2],
                    Deptid = (int)row[3]
                };

                //add the record into collection
                list.Add(emp);
            }
            //return the records
            return list;
        }
        public Employee GetEmpById(int ecode)
        {
            //find the record 
            DataRow[] rows = ds.Tables[0].Select("ecode=" + ecode);

            if(rows.Length>0)
            {
                //return the record found
                Employee emp = new Employee
                {
                    Ecode = (int)rows[0][0],
                    Ename = rows[0][1].ToString(),
                    Salary = (int)rows[0][2],
                    Deptid = (int)rows[0][3]
                };
                return emp;
            }
            else
            {
                throw new Exception("Record not present");
            }
        }

        public void AddEmployee(Employee emp)
        {
            //create a new row in the DataTable of DataSet
            DataRow row = ds.Tables[0].NewRow();
            //specify the column values of the newly created row
            row[0] = emp.Ecode;
            row[1] = emp.Ename;
            row[2] = emp.Salary;
            row[3] = emp.Deptid;
            //Add this row in the rows collection of DataTable of DataSet
            ds.Tables[0].Rows.Add(row);
            //Save changes to Database using DataAdapter
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "tbl_employee");
        }
        public void DeleteEmployee(int ecode)
        {
            //select the rows in DataTable rows for delete
            DataRow[] rows = ds.Tables[0].Select("ecode=" + ecode );
            if(rows.Length>0)
            {
                //delete the row
                foreach (DataRow row in rows)
                {
                    row.Delete();
                }
                //Save changes to Database using DataAdapter
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "tbl_employee");
            }
            else
            {
                throw new Exception("Record not found");
            }
        }
        public void UpdateEmployee(Employee emp)
        {
            //select the rows in DataTable rows for update
            DataRow[] rows = ds.Tables[0].Select("ecode=" + emp.Ecode);
            if (rows.Length > 0)
            {
                //update the rows
                foreach (DataRow row in rows)
                {
                    row[1] = emp.Ename;
                    row[2] =emp.Salary;
                    row[3] = emp.Deptid;
                }
                //Save changes to Database using DataAdapter
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "tbl_employee");
            }
            else
            {
                throw new Exception("Record not found");
            }
        }
    }
}
