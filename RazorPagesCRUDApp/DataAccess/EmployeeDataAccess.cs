using System.Data.SqlClient;
using System.Data;

namespace RazorPagesCRUDApp.DataAccess
{
    public class EmployeeDataAccess
    {
        SqlConnection con;
        SqlCommand cmd;

        public EmployeeDataAccess()
        {
            string conStr = "Data Source=(localdb)\\ProjectModels;Initial Catalog=EmpDB;Integrated Security=True;";
            con = new SqlConnection(conStr);
        }

        public List<Employee> GetEmps()
        {
            cmd = new SqlCommand("select * from tbl_employee",con);
            cmd.CommandType = CommandType.Text;

            List<Employee> list = new List<Employee>();
            con.Open();
            SqlDataReader sdr=cmd.ExecuteReader();

            while(sdr.Read())
            {
                Employee emp = new Employee
                {
                   Ecode=sdr.GetInt32(0),
                   Ename=sdr.GetString(1),
                   Salary=sdr.GetInt32(2),
                   Deptid=sdr.GetInt32 (3)
                };
                list.Add(emp);
            }

            return list;
        }
        public Employee GetEmpById(int id)
        {
            try
            {
                cmd = new SqlCommand("select * from tbl_employee where ecode=@ec", con);
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", id);
                
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    Employee emp = new Employee
                    {
                        Ecode = sdr.GetInt32(0),
                        Ename = sdr.GetString(1),
                        Salary = sdr.GetInt32(2),
                        Deptid = sdr.GetInt32(3)
                    };
                    return emp;
                }
                else
                {
                    throw new Exception("Record not present");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void AddEmployee(Employee emp)
        {
            cmd = new SqlCommand("insert into tbl_employee values(@ec,@en,@sal,@did)",con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ec", emp.Ecode);
            cmd.Parameters.AddWithValue("@en", emp.Ename);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            cmd.Parameters.AddWithValue("@did", emp.Deptid);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteEmp(int ecode)
        {
            cmd = new SqlCommand("delete from tbl_employee where ecode=@ec", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ec", ecode);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateEmployee(Employee emp)
        {
            cmd = new SqlCommand("update tbl_employee set ename=@en,salary=@sal,deptid=@did where ecode=@ec", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ec", emp.Ecode);
            cmd.Parameters.AddWithValue("@en", emp.Ename);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            cmd.Parameters.AddWithValue("@did", emp.Deptid);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
