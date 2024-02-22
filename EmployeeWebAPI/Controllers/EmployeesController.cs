using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;


namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        readonly IMapper _mapper;
        readonly IEmpDataAccess dal;
        public EmployeesController(IMapper mapper, IEmpDataAccess dal)
        {
            _mapper = mapper;
            this.dal = dal;
        }

        [HttpGet]
        //[Route("GetAllEmps")]
        public List<Employee> Get()
        {           

            //EmployeeDataAccess dal=new EmployeeDataAccess();
            List<Employee> employees = dal.GetEmps();
            return employees;
        }
        
        //api/Employees/101
        [HttpGet("{id}")]
        //[Route("GetEmpByEcode/{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                //EmployeeDataAccess dal = new EmployeeDataAccess();
                Employee employee = dal.GetEmpById(id);

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        //api/Employees/201
        //[HttpGet]
        ////[Route("GetEmpsByDeptid/{id}")]
        //public List<Employee> Get(int id)
        //{
        //    EmployeeDataAccess dal = new EmployeeDataAccess();
        //    List<Employee> emps=new List<Employee>
        //    {
        //        new Employee{Ecode=101,Ename="ram",Salary=1111,Deptid=id},
        //        new Employee{Ecode=102,Ename="ravi",Salary=2222,Deptid=id},
        //        new Employee{Ecode=103,Ename="rahul",Salary=3333,Deptid=id},

        //    };

        //    return emps;
        //}


        //[HttpGet("{name}")]
        //public Employee Get(string name)
        //{
        //    //EmployeeDataAccess dal = new EmployeeDataAccess();
        //    //Employee employee = dal.GetEmpById(id);

        //    Employee employee = new Employee
        //    {
        //        Ecode=123,
        //        Ename=name,
        //        Salary=133,
        //        Deptid=206
        //    };

        //    return employee;
        //}

        [HttpPost]
        //[Route("AddEmployee")]
        public ActionResult Post([FromBody] Employee employee)
        {
            try
            {
                //EmployeeDataAccess dal = new EmployeeDataAccess();
                dal.AddEmployee(employee);
                return Ok("Record inserted successfully");
                //return success
                 
            }
            catch (Exception ex)
            {
                //return error 
                return BadRequest(ex.Message);
            }  
        }

        [HttpDelete("{id}")]
        //[Route("DeleteEmpById/{id}")]
        public void Delete(int id)
        {
            //EmployeeDataAccess dal = new EmployeeDataAccess();
            dal.DeleteEmployee(id);
        }

        [HttpPut]
        //[Route("UpdateEmp")]
        public void Put(Employee employee)
        {
            //EmployeeDataAccess dal = new EmployeeDataAccess();
            dal.UpdateEmployee(employee);
        }

        //[HttpGet]
        //[Route("AddNumbers/{x}/{y}")]
        //public int AddNumbers(int x,int y )
        //{
        //    return x + y;
        //}

        //[HttpPost]
        //[Route("Add/{x}/{y}")]
        //public int Add(int x, int y)
        //{
        //    return x + y;
        //}


        [HttpGet]
        [Route("GetCustomer")]
        public CustomerDestination GetCustomer()
        {
            CustomerSource source = new CustomerSource
            {
                CustId=1001,
                CustName="Alex",
                City="Texas",
                Region="r1"
            };
            ////mannual mapping
            //CustomerDestination destination = new CustomerDestination
            //{
            //    CustId = source.CustId,
            //    CustName = source.CustName
            //};

            //using AutoMapper
            //configure and create mapper object
            MapperConfiguration config = new MapperConfiguration(c => 
                                    c.CreateMap<CustomerSource, CustomerDestination>());
            
            IMapper mapper=config.CreateMapper();

            //map the source to destination
            CustomerDestination destination =mapper.Map<CustomerDestination>(source);

            return destination;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public List<CustomerDestination> GetCustomers()
        {
            List<CustomerSource> sourceList = new List<CustomerSource>
            {
                new CustomerSource{CustId=1,CustName="C1",City="Blr",Region="r1"},
                new CustomerSource{CustId=2,CustName="C2",City="Dli",Region="r2"},
                new CustomerSource{CustId=3,CustName="C3",City="Hyd",Region="r3"}
            };

            //using AutoMapper
            //MapperConfiguration config = new MapperConfiguration(c =>
            //                     c.CreateMap<CustomerSource, CustomerDestination>());

            //IMapper mapper = config.CreateMapper();

            //map source to destination
            List<CustomerDestination> destinationlist = _mapper.Map<List<CustomerDestination>>(sourceList);

            return destinationlist;
        }
    }
}
