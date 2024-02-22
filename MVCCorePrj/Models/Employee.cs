using System.ComponentModel.DataAnnotations;

namespace MVCCorePrj.Models
{
    public class Employee
    {
        [Required]
        public int Ecode {  get; set; }

        [Required]
        [Length(3,10,ErrorMessage ="employee name must be between 3 to 10 characters")]        
        public string Ename { get; set; }

        [Required]
        //[Range(1000,50000)]
        [SalaryValidation(ErrorMessage ="Salary must be 5000/- and above")]
        public int Salary {  get; set; }
        
        [Required]
        [RegularExpression(@"\d{3,3}",ErrorMessage ="invalid deptid, it must be exactly 3-digit")]
        public int Deptid { get; set; }

    }
}
