using System.Data;
using System.Data.SqlClient;

namespace WebAPISecurityJWT.Models
{
    public interface IEmpDataAccess
    {
        List<Employee> GetEmps();
        List<Employee> GetEmpsUsingSP();
        Employee GetEmpById(int ecode);
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int ecode);
        void DeleteEmpUsingSP(int ecode);
    }

    public class EmployeeDataAccess : IEmpDataAccess
    {
        SqlConnection con;
        SqlCommand cmd;
        public EmployeeDataAccess()
        {
            //configure connection
            string conStr = "Data Source=(localdb)\\ProjectModels;Initial Catalog=EmpDB;Integrated Security=True;";
            con = new SqlConnection(conStr);
        }
        public List<Employee> GetEmps()
        {
            List<Employee> list = new List<Employee>();

            try
            {
                //configure command for SELECT ALL: select * from tbl_employee
                cmd = new SqlCommand("select ecode,ename,salary,deptid from tbl_employee", con);
                cmd.CommandType = CommandType.Text;

                //open the connection
                con.Open();

                //execute the command
                SqlDataReader sdr = cmd.ExecuteReader();

                //traverse the records and put them into collection
                while (sdr.Read())
                {
                    Employee emp = new Employee
                    {
                        Ecode = sdr.GetInt32(0),
                        Ename = sdr.GetString(1),
                        Salary = sdr.GetInt32(2),
                        Deptid = sdr.GetInt32(3)
                    };

                    list.Add(emp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }

            //return the records
            return list;
        }

        public List<Employee> GetEmpsUsingSP()
        {
            List<Employee> list = new List<Employee>();

            try
            {
                //configure command for Stored Procedure
                cmd = new SqlCommand("sp_getemps", con);
                //must specify command type as StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;

                //open the connection
                con.Open();

                //execute the command
                SqlDataReader sdr = cmd.ExecuteReader();

                //traverse the records and put them into collection
                while (sdr.Read())
                {
                    Employee emp = new Employee
                    {
                        Ecode = sdr.GetInt32(0),
                        Ename = sdr.GetString(1),
                        Salary = sdr.GetInt32(2),
                        Deptid = sdr.GetInt32(3)
                    };

                    list.Add(emp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }

            //return the records
            return list;
        }
        public Employee GetEmpById(int ecode)
        {
            try
            {
                //configure command for SELECT BY ID
                cmd = new SqlCommand("select ecode,ename,salary,deptid from tbl_employee where ecode=@ec", con);
                cmd.CommandType = CommandType.Text;

                //specify parameter value
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", ecode);

                //open connection and execute the command
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                //read the record
                if (sdr.Read())
                {
                    Employee emp = new Employee
                    {
                        Ecode = sdr.GetInt32(0),
                        Ename = sdr.GetString(1),
                        Salary = sdr.GetInt32(2),
                        Deptid = sdr.GetInt32(3)
                    };
                    con.Close();
                    return emp;
                }
                else
                {
                    throw new Exception("Record not found!");
                }
            }
            catch (Exception ex)
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
            try
            {
                //configure command for INSERT
                cmd = new SqlCommand("insert into tbl_employee values(@ec,@en,@sal,@did)", con);
                cmd.CommandType = CommandType.Text;

                //specify the values for the INSERT parameters
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", emp.Ecode);
                cmd.Parameters.AddWithValue("@en", emp.Ename);
                cmd.Parameters.AddWithValue("@sal", emp.Salary);
                cmd.Parameters.AddWithValue("@did", emp.Deptid);

                //open connection
                con.Open();

                //execute the command
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }
        public void UpdateEmployee(Employee emp)
        {
            try
            {
                //configure command for UPDATE
                cmd = new SqlCommand("update tbl_employee set ename=@en,salary=@sal,deptid=@did where ecode=@ec", con);
                cmd.CommandType = CommandType.Text;

                //specify the values for the UPDATE parameters
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", emp.Ecode);
                cmd.Parameters.AddWithValue("@en", emp.Ename);
                cmd.Parameters.AddWithValue("@sal", emp.Salary);
                cmd.Parameters.AddWithValue("@did", emp.Deptid);

                //open connection
                con.Open();

                //execute the command
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }
        public void DeleteEmployee(int ecode)
        {
            try
            {
                //configure the command for DELETE BY ID
                cmd = new SqlCommand("delete from tbl_employee where ecode=@ec", con);
                cmd.CommandType = CommandType.Text;

                //specify parameter value
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", ecode);

                //open connection and execute the command
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }

        public void DeleteEmpUsingSP(int ecode)
        {
            try
            {
                //configure the command for Stored Procedure
                cmd = new SqlCommand("sp_delete_emp_byid", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //specify parameter value
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", ecode);

                //open connection and execute the command
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }

    }
}
