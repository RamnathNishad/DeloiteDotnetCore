namespace MVCCorePrj.Models
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
}
