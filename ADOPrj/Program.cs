


namespace ADOPrj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("1.Add employee");
                Console.WriteLine("2.Delete emp by id");
                Console.WriteLine("3.Update employee");
                Console.WriteLine("4.Display all emps");
                Console.WriteLine("5.Find emp");
                Console.WriteLine("0.Exit");
                Console.Write("Enter choice:");
                choice=int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        DeleteEmp();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DisplayAll(); 
                        break;
                    case 5:
                        FindEmp();
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("invalid option!!!");
                        break;
                }
            } while (choice != 0);            
        }

        static void AddEmployee()
        {
            //Take user input for INSERT
            Employee emp=new Employee ();

            Console.Write("Enter ecode:");
            emp.Ecode=int.Parse(Console.ReadLine());
            Console.Write("Enter ename:");
            emp.Ename = Console.ReadLine();
            Console.Write("Enter salary:");
            emp.Salary = int.Parse(Console.ReadLine());
            Console.Write("Enter deptid:");
            emp.Deptid = int.Parse(Console.ReadLine());

            //insert using DAL object
            //AdoConnected dal=new AdoConnected ();
            AdoDisconnected dal = new AdoDisconnected();
            dal.AddEmployee(emp);
            Console.WriteLine("Record inserted");

            DisplayAll();
        }
        static void UpdateEmployee()
        {
            //Take user input for UPDATE
            Employee emp = new Employee();

            Console.Write("Enter ecode for update:");
            emp.Ecode = int.Parse(Console.ReadLine());
            Console.Write("Enter ename:");
            emp.Ename = Console.ReadLine();
            Console.Write("Enter salary:");
            emp.Salary = int.Parse(Console.ReadLine());
            Console.Write("Enter deptid:");
            emp.Deptid = int.Parse(Console.ReadLine());

            //update using DAL object
            //AdoConnected dal = new AdoConnected();
            AdoDisconnected dal = new AdoDisconnected();
            dal.UpdateEmployee(emp);
            Console.WriteLine("Record updated");

            DisplayAll();
        }
        static void DeleteEmp()
        {
            Console.Write("Enter ecode for delete:");
            int ecode = int.Parse(Console.ReadLine());

            //delete using DAL layer
            //AdoConnected dal = new AdoConnected();
            AdoDisconnected dal = new AdoDisconnected();
            dal.DeleteEmployee(ecode);
            //dal.DeleteEmpUsingSP(ecode);
            Console.WriteLine("Record deleted");

            DisplayAll();
        }
        static void FindEmp()
        {
            try
            {
                Console.Write("Enter ecode to search:");
                int ecode = int.Parse(Console.ReadLine());

                //get employe by id using DAL
                //AdoConnected dal = new AdoConnected();
                AdoDisconnected dal = new AdoDisconnected();
                Employee emp = dal.GetEmpById(ecode);

                //display the record
                Console.WriteLine($"{emp.Ecode}\t{emp.Ename}\t{emp.Salary}\t{emp.Deptid}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void DisplayAll()
        {
            //AdoConnected dal = new AdoConnected();
            AdoDisconnected dal = new AdoDisconnected();
            List<Employee> employees = dal.GetEmps();
            //List<Employee> employees = dal.GetEmpsUsingSP();

            //display the records
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"{emp.Ecode}\t{emp.Ename}\t{emp.Salary}\t{emp.Deptid}");
            }
        }
    }
}
